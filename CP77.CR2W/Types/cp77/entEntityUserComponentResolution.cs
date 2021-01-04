using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class entEntityUserComponentResolution : CVariable
	{
		[Ordinal(0)]  [RED("id")] public CRUID Id { get; set; }
		[Ordinal(1)]  [RED("include")] public raRef<entEntityTemplate> Include { get; set; }
		[Ordinal(2)]  [RED("mode")] public CEnum<entEntityUserComponentResolutionMode> Mode { get; set; }

		public entEntityUserComponentResolution(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
