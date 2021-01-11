using System;
using System.Collections.Generic;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Threading.Tasks;
using Catel.IoC;
using CP77.Common.Services;
using CP77.Common.Tools.FNV1A;
using WolvenKit.Common;

namespace CP77.CR2W
{
    /// <summary>
    /// Collection of common modding utilities.
    /// </summary>
    public static partial class ModTools
    {
        private static readonly ILoggerService Logger = ServiceLocator.Default.ResolveType<ILoggerService>();
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="infolder"></param>
        /// <param name="useBuffers"></param>
        /// <param name="useTextures"></param>
        /// <param name="import"></param>
        /// <param name="keep"></param>
        /// <param name="clean"></param>
        /// <returns></returns>
        public static bool Recombine(DirectoryInfo infolder, 
            bool useBuffers, 
            bool useTextures,
            bool import,    //create new
            bool keep,
            bool clean,
            bool unsaferaw  
        )
        {
            var allFiles = infolder.GetFiles("*", SearchOption.AllDirectories).ToList(); 
            var buffersDict = new Dictionary<string, List<FileInfo>>();
            
            // get all buffers and textures to recombine
            // if both buffers and textures is selected and a file has both buffers and textures
            // then the texture has priority
            if (useBuffers) GetBuffers();
            if (useTextures) GetTextures();
            
            // loop through the buffersDict
            foreach (var (parentPath, buffers) in buffersDict)
            {
                var ext = Path.GetExtension(parentPath)[1..];
                
                var values = Enum.GetValues(typeof(ECookedFileFormat))
                    .Cast<ECookedFileFormat>()
                    .Select(_ => $".{_}");
                var canImport = values.Any(e => e == ext);
                
                // if the parent cr2w exists
                if (File.Exists(parentPath))
                {
                    AppendBuffersToFile(parentPath, buffers);
                }
                // if no parent exists then import the raw file into redengine
                else if (import && canImport)
                {
                    //TODO: switch and call import
                    
                }

                // if clean is selected, delete the buffer files
                if (clean)
                {
                    //TODO: loop and delet buffers
                }
            }
            
            

            return true;


            #region local methods

            void GetBuffers()
            {
                var buffersList = allFiles.Where(_ => _.Extension == ".buffer");
                foreach (var fileInfo in buffersList)
                {
                    // buffer path e.g. stand__rh_hold_tray__serve_milkshakes__01.scenerid.11.buffer
                    // removes 7 characters (".buffer") and then removes the variable length extension (".11")
                    var relpath = fileInfo.FullName;//[(infolder.FullName.Length + 1)..];
                    var parentpath = Path.ChangeExtension(relpath.Remove(relpath.Length - 7), "").TrimEnd('.');
                    var key = parentpath;//FNV1A64HashAlgorithm.HashString(parentpath);

                    // add buffer
                    if (!buffersDict.ContainsKey(key))
                        buffersDict.Add(key, new List<FileInfo>());
                    buffersDict[key].Add(fileInfo);
                }
            }
            
            void GetTextures()
            {
                if (!import && !unsaferaw)
                    return;
                
                var texturesList = allFiles.Where(_ => _.Extension == ".dds");
                foreach (var fileInfo in texturesList)
                {
                    // dds path e.g. stand__rh_hold_tray__serve_milkshakes__01.dds
                    // rename to xbm and hash
                    var relpath = fileInfo.FullName;//[(infolder.FullName.Length + 1)..];
                    var parentpath = Path.ChangeExtension(relpath, "xbm");
                    var key = parentpath;//FNV1A64HashAlgorithm.HashString(parentpath);

                    // add buffer
                    if (!buffersDict.ContainsKey(key))
                        buffersDict.Add(key, new List<FileInfo>());
                    else
                        // there can always only be one texture and it get's priority
                        buffersDict[key] = new List<FileInfo>(); 
                    buffersDict[key].Add(fileInfo);
                }
            }

            static CR2WFile TryReadCr2WFile(BinaryReader br)
            {
                // peak if cr2w
                if (br.BaseStream.Length < 4) 
                    return null;
                br.BaseStream.Seek(0, SeekOrigin.Begin);
                var magic = br.ReadUInt32();
                var isCr2wFile = magic == CR2WFile.MAGIC;
                if (!isCr2wFile) 
                    return null;
                
                var cr2w = new CR2WFile();
                try
                {
                    //TODO: verify cr2w integrity
                    br.BaseStream.Seek(0, SeekOrigin.Begin);
                    cr2w.ReadImportsAndBuffers(br);
                }
                catch (Exception e)
                {
                    return null;
                }
                
                return cr2w;
            }

            void AppendBuffersToFile(string parentPath, List<FileInfo> buffers)
            {
                //check if cr2w
                using var fileStream = new FileStream(parentPath, FileMode.Open, FileAccess.ReadWrite);
                using var fileReader = new BinaryReader(fileStream);

                var cr2w = TryReadCr2WFile(fileReader); 
                if (cr2w == null)
                {
                    Logger.LogString($"Failed to read cr2w file {parentPath}", Logtype.Error);
                    return;
                }
                
                if (keep)
                {
                    // remove old buffers 
                    fileReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    fileStream.SetLength(cr2w.Header.fileSize);
                        
                    // kraken the buffers and handle textures
                    using var fileWriter = new BinaryWriter(fileStream);
                    fileWriter.BaseStream.Seek(0, SeekOrigin.End);
                    cr2w.Buffers.Clear();
                    for (var i = 0; i < buffers.Count; i++)
                    {
                        var buffer = buffers[i];
                        if (!buffer.Exists)
                            continue;

                        var inbuffer = ReadBuffer(buffer);
                        if (inbuffer.Length < 1) continue;

                        var offset = (uint)fileWriter.BaseStream.Position;
                        var (zsize, crc) = fileWriter.CompressAndWrite(inbuffer);
                        cr2w.Buffers.Add(new CR2WBufferWrapper(new CR2WBuffer()
                        {
                            flags = 0,                              //TODO: find out what these are
                            index = (uint)i,
                            offset = offset,
                            diskSize = zsize,
                            memSize = (uint)inbuffer.Length,
                            crc32 = crc
                        }));
                    }

                    // write cr2w headers
                    fileWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    cr2w.WriteHeader(fileWriter);
                }
                else
                {
                    //TODO: switch and call import with existing 
                }
                
            }

            byte[] ReadBuffer(FileInfo buffer)
            {
                using var fs = new FileStream(buffer.FullName, FileMode.Open, FileAccess.Read);
                using var br = new BinaryReader(fs);
                // if dds file, delete the 
                if (unsaferaw)
                {
                    var bext = buffer.Extension;
                    switch (bext)
                    {
                        case ".dds":
                            // check if dx10
                            fs.Seek(84, SeekOrigin.Begin);
                            var fourcc = br.ReadInt32();
                            // delete dds header
                            if (fourcc != 808540228) //is dx10
                            {
                                fs.Seek(148, SeekOrigin.Begin);
                                return br.ReadBytes((int)fs.Length - 148);
                            }
                            else
                            {
                                fs.Seek(128, SeekOrigin.Begin);
                                return br.ReadBytes((int)fs.Length - 128);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    return Catel.IO.StreamExtensions.ToByteArray(fs);
                }

                return Array.Empty<byte>();
            }

            #endregion
            
        }
    }
}