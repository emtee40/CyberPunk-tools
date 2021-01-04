using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class questSetLootInteractionAccess_NodeType : questIItemManagerNodeType
	{
		[Ordinal(0)]  [RED("accessible")] public CBool Accessible { get; set; }
		[Ordinal(1)]  [RED("objectRef")] public gameEntityReference ObjectRef { get; set; }

		public questSetLootInteractionAccess_NodeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
