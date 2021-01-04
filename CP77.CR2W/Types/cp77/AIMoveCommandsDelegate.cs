using System.IO;
using CP77.CR2W.Reflection;
using FastMember;
using static CP77.CR2W.Types.Enums;

namespace CP77.CR2W.Types
{
	[REDMeta]
	public class AIMoveCommandsDelegate : AIbehaviorScriptBehaviorDelegate
	{
		[Ordinal(0)]  [RED("animMoveOnSplineCommand")] public wCHandle<AIAnimMoveOnSplineCommand> AnimMoveOnSplineCommand { get; set; }
		[Ordinal(1)]  [RED("blendTime")] public CFloat BlendTime { get; set; }
		[Ordinal(2)]  [RED("companion")] public wCHandle<gameObject> Companion { get; set; }
		[Ordinal(3)]  [RED("controllerSetupName")] public CName ControllerSetupName { get; set; }
		[Ordinal(4)]  [RED("customMainAnimationName")] public CName CustomMainAnimationName { get; set; }
		[Ordinal(5)]  [RED("customStartAnimationName")] public CName CustomStartAnimationName { get; set; }
		[Ordinal(6)]  [RED("customStopAnimationName")] public CName CustomStopAnimationName { get; set; }
		[Ordinal(7)]  [RED("deadZoneRadius")] public CFloat DeadZoneRadius { get; set; }
		[Ordinal(8)]  [RED("desiredDistance")] public CFloat DesiredDistance { get; set; }
		[Ordinal(9)]  [RED("distanceToCompanion")] public CFloat DistanceToCompanion { get; set; }
		[Ordinal(10)]  [RED("firstWaitingDemandTimestamp")] public CFloat FirstWaitingDemandTimestamp { get; set; }
		[Ordinal(11)]  [RED("followTargetCommand")] public CHandle<AIFollowTargetCommand> FollowTargetCommand { get; set; }
		[Ordinal(12)]  [RED("globalInBlendTime")] public CFloat GlobalInBlendTime { get; set; }
		[Ordinal(13)]  [RED("globalOutBlendTime")] public CFloat GlobalOutBlendTime { get; set; }
		[Ordinal(14)]  [RED("hasSplineEndPoint")] public CBool HasSplineEndPoint { get; set; }
		[Ordinal(15)]  [RED("ignoreLineOfSightCheck")] public CBool IgnoreLineOfSightCheck { get; set; }
		[Ordinal(16)]  [RED("ignoreNavigation")] public CBool IgnoreNavigation { get; set; }
		[Ordinal(17)]  [RED("lookAtTarget")] public wCHandle<gameObject> LookAtTarget { get; set; }
		[Ordinal(18)]  [RED("lowestCompanionDistanceToEnd")] public CFloat LowestCompanionDistanceToEnd { get; set; }
		[Ordinal(19)]  [RED("mainSnapToTerrain")] public CBool MainSnapToTerrain { get; set; }
		[Ordinal(20)]  [RED("matchTargetSpeed")] public CBool MatchTargetSpeed { get; set; }
		[Ordinal(21)]  [RED("maxCompanionDistanceOnSpline")] public CFloat MaxCompanionDistanceOnSpline { get; set; }
		[Ordinal(22)]  [RED("maxSearchAngle")] public CFloat MaxSearchAngle { get; set; }
		[Ordinal(23)]  [RED("minSearchAngle")] public CFloat MinSearchAngle { get; set; }
		[Ordinal(24)]  [RED("moveOnSplineCommand")] public CHandle<AIMoveOnSplineCommand> MoveOnSplineCommand { get; set; }
		[Ordinal(25)]  [RED("movementType")] public CEnum<moveMovementType> MovementType { get; set; }
		[Ordinal(26)]  [RED("noWaitToEndCompanionDistance")] public CFloat NoWaitToEndCompanionDistance { get; set; }
		[Ordinal(27)]  [RED("noWaitToEndDistance")] public CFloat NoWaitToEndDistance { get; set; }
		[Ordinal(28)]  [RED("playerCompanion")] public wCHandle<PlayerPuppet> PlayerCompanion { get; set; }
		[Ordinal(29)]  [RED("previousCompanionDistanceToEnd")] public CFloat PreviousCompanionDistanceToEnd { get; set; }
		[Ordinal(30)]  [RED("reverse")] public CBool Reverse { get; set; }
		[Ordinal(31)]  [RED("run")] public CBool Run { get; set; }
		[Ordinal(32)]  [RED("shootingTarget")] public wCHandle<gameObject> ShootingTarget { get; set; }
		[Ordinal(33)]  [RED("shouldBeInFrontOfCompanion")] public CBool ShouldBeInFrontOfCompanion { get; set; }
		[Ordinal(34)]  [RED("shouldTeleportNow")] public CBool ShouldTeleportNow { get; set; }
		[Ordinal(35)]  [RED("spline")] public NodeRef Spline { get; set; }
		[Ordinal(36)]  [RED("splineEndPoint")] public Vector4 SplineEndPoint { get; set; }
		[Ordinal(37)]  [RED("sprint")] public CBool Sprint { get; set; }
		[Ordinal(38)]  [RED("startFromClosestPoint")] public CBool StartFromClosestPoint { get; set; }
		[Ordinal(39)]  [RED("startSnapToTerrain")] public CBool StartSnapToTerrain { get; set; }
		[Ordinal(40)]  [RED("startSnapToTerrainBlendTime")] public CFloat StartSnapToTerrainBlendTime { get; set; }
		[Ordinal(41)]  [RED("stopSnapToTerrain")] public CBool StopSnapToTerrain { get; set; }
		[Ordinal(42)]  [RED("stopSnapToTerrainBlendTime")] public CFloat StopSnapToTerrainBlendTime { get; set; }
		[Ordinal(43)]  [RED("stopWhenDestinationReached")] public CBool StopWhenDestinationReached { get; set; }
		[Ordinal(44)]  [RED("strafingTarget")] public wCHandle<gameObject> StrafingTarget { get; set; }
		[Ordinal(45)]  [RED("teleportDestination")] public Vector4 TeleportDestination { get; set; }
		[Ordinal(46)]  [RED("teleportToTarget")] public CBool TeleportToTarget { get; set; }
		[Ordinal(47)]  [RED("turnCharacterToMatchVelocity")] public CBool TurnCharacterToMatchVelocity { get; set; }
		[Ordinal(48)]  [RED("useAlertedState")] public CBool UseAlertedState { get; set; }
		[Ordinal(49)]  [RED("useCombatState")] public CBool UseCombatState { get; set; }
		[Ordinal(50)]  [RED("useMatchForSpeedForPlayer")] public CBool UseMatchForSpeedForPlayer { get; set; }
		[Ordinal(51)]  [RED("useOffMeshLinkReservation")] public CBool UseOffMeshLinkReservation { get; set; }
		[Ordinal(52)]  [RED("useStart")] public CBool UseStart { get; set; }
		[Ordinal(53)]  [RED("useStop")] public CBool UseStop { get; set; }
		[Ordinal(54)]  [RED("waitForCompanion")] public CBool WaitForCompanion { get; set; }

		public AIMoveCommandsDelegate(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name) { }
	}
}
