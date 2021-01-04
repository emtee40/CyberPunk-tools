using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class localizationPersistenceLocDataMap : ISerializable
	{
		[Ordinal(0)]  [RED("entries")] public CArray<localizationPersistenceLocDataMapEntry> Entries { get; set; }

		public localizationPersistenceLocDataMap(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
