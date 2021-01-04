using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class gameForceVisionModuleQuestEvent : redEvent
	{
		[Ordinal(0)]  [RED("meshComponentNames")] public CArray<CName> MeshComponentNames { get; set; }
		[Ordinal(1)]  [RED("moduleName")] public CName ModuleName { get; set; }

		public gameForceVisionModuleQuestEvent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
