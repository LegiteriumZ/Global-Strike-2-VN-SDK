using Assets.Sources.Ui.Model.BigHead;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;

namespace Assets.Sources.Modules.Ui.Mode;

internal class BigHeadMode : AbstractMode
{
	public BigHeadMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new TeamScoreModel());
		AddPlaybackSystem(new BigHeadIndividualScoreInfoModel());
		AddPlaybackSystem(new BigHeadStrikeIndividualScoreInfoModel());
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
		AddPlaybackSystem(new BigHeadHonoraryModel());
		AddPlaybackSystem(new PlayerScoreInfoModel());
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new CommonGameOverModel());
		AddPlaybackSystem(new BigHeadProgressModel());
		AddPlaybackSystem(new BigHeadMessageModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new AddHpCrossModel());
	}
}
