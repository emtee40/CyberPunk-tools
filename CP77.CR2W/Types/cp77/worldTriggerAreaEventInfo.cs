using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class worldTriggerAreaEventInfo : CVariable
	{
		[Ordinal(0)]  [RED("activatorID")] public CUInt32 ActivatorID { get; set; }
		[Ordinal(1)]  [RED("eventWorldPosition")] public Vector3 EventWorldPosition { get; set; }
		[Ordinal(2)]  [RED("nodeInstance")] public CHandle<worldTriggerAreaNodeInstance> NodeInstance { get; set; }
		[Ordinal(3)]  [RED("numActivatorsInArea")] public CUInt32 NumActivatorsInArea { get; set; }

		public worldTriggerAreaEventInfo(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
