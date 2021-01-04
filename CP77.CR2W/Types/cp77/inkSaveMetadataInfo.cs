using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class inkSaveMetadataInfo : IScriptable
	{
		[Ordinal(0)]  [RED("initialLoadingScreenID")] public CUInt64 InitialLoadingScreenID { get; set; }
		[Ordinal(1)]  [RED("internalName")] public CString InternalName { get; set; }
		[Ordinal(2)]  [RED("isValid")] public CBool IsValid { get; set; }
		[Ordinal(3)]  [RED("level")] public CDouble Level { get; set; }
		[Ordinal(4)]  [RED("lifePath")] public CEnum<inkLifePath> LifePath { get; set; }
		[Ordinal(5)]  [RED("locationName")] public CString LocationName { get; set; }
		[Ordinal(6)]  [RED("playTime")] public CDouble PlayTime { get; set; }
		[Ordinal(7)]  [RED("playthroughTime")] public CDouble PlaythroughTime { get; set; }
		[Ordinal(8)]  [RED("saveID")] public CUInt32 SaveID { get; set; }
		[Ordinal(9)]  [RED("saveIndex")] public CInt32 SaveIndex { get; set; }
		[Ordinal(10)]  [RED("saveType")] public CEnum<inkSaveType> SaveType { get; set; }
		[Ordinal(11)]  [RED("timestamp")] public CUInt64 Timestamp { get; set; }
		[Ordinal(12)]  [RED("trackedQuest")] public CString TrackedQuest { get; set; }

		public inkSaveMetadataInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
