using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;

namespace Assets.Sources.Modules.Ui.Mode;

public class NormalTeamMode : AbstractMode
{
	public NormalTeamMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerBagModel());
		RadarMapModel system = new RadarMapModel();
		AddPlaybackSystem(system);
		MiniMapModel system2 = new MiniMapModel();
		AddPlaybackSystem(system2);
		TeamScoreModel system3 = new TeamScoreModel();
		AddPlaybackSystem(system3);
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		KillMessageModel system4 = new KillMessageModel();
		AddPlaybackSystem(system4);
		PlayerStateModel system5 = new PlayerStateModel();
		AddPlaybackSystem(system5);
		WeaponStateModel system6 = new WeaponStateModel();
		AddPlaybackSystem(system6);
		AddPlaybackSystem(new CommonIndividualScoreInfoModel());
		AddPlaybackSystem(new MatchIndividualScoreInfoModel());
		AddPlaybackSystem(new GroupStrikeIndividualScoreInfoModel());
		AddPlaybackSystem(new CommonPlayerHonoraryModel());
		AddPlaybackSystem(new PlayerScoreInfoModel());
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new CommonGameOverModel());
		AddPlaybackSystem(new GroupBestKillModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new CommonMessageModel());
	}
}
