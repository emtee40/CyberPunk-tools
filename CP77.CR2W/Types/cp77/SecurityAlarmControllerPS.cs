using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class SecurityAlarmControllerPS : MasterControllerPS
	{
		[Ordinal(0)]  [RED("securityAlarmSetup")] public SecurityAlarmSetup SecurityAlarmSetup { get; set; }
		[Ordinal(1)]  [RED("securityAlarmState")] public CEnum<ESecuritySystemState> SecurityAlarmState { get; set; }

		public SecurityAlarmControllerPS(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
