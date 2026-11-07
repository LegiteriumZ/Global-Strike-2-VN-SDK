using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.GroupGunKing;

namespace Assets.Sources.Modules.Ui.Mode;

public class GroupGunKingMode : AbstractMode
{
	public GroupGunKingMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerBagModel());
		RadarMapModel system = new RadarMapModel();
		AddPlaybackSystem(system);
		MiniMapModel system2 = new MiniMapModel();
		AddPlaybackSystem(system2);
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		KillMessageModel system3 = new KillMessageModel();
		AddPlaybackSystem(system3);
		PlayerStateModel system4 = new PlayerStateModel();
		AddPlaybackSystem(system4);
		WeaponStateModel system5 = new WeaponStateModel();
		AddPlaybackSystem(system5);
		AddPlaybackSystem(new PlayerScoreInfoModel());
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new GroupBestKillModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new CommonIndividualScoreInfoModel());
		AddPlaybackSystem(new GroupGunKingHonoraryModel());
		AddPlaybackSystem(new GroupGunKingTeamScoreModel());
		AddPlaybackSystem(new GroupGunKingWeaponSelectModel());
		AddPlaybackSystem(new GroupGunKingMessageModel());
		AddPlaybackSystem(new GroupGunKingGameOverModel());
	}
}
