using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class SInventoryOperationData : CVariable
	{
		[Ordinal(0)]  [RED("itemName")] public TweakDBID ItemName { get; set; }
		[Ordinal(1)]  [RED("operationType")] public CEnum<EItemOperationType> OperationType { get; set; }
		[Ordinal(2)]  [RED("quantity")] public CInt32 Quantity { get; set; }

		public SInventoryOperationData(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
