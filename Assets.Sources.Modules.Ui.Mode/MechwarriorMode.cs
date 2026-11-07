using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.Mechwarrior;

namespace Assets.Sources.Modules.Ui.Mode;

public class MechwarriorMode : AbstractMode
{
	public MechwarriorMode(Contexts contexts)
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
		AddPlaybackSystem(new CommonPlayerHonoraryModel());
		AddPlaybackSystem(new PlayerScoreInfoModel());
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new CommonGameOverModel());
		AddPlaybackSystem(new GroupBestKillModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new CommonMessageModel());
		MechwarriorIndividualScoreInfoModel system7 = new MechwarriorIndividualScoreInfoModel();
		AddPlaybackSystem(system7);
		AddPlaybackSystem(new MechwarriorSelectMechWeaponModel());
		AddPlaybackSystem(new MechwarriorHumanEnergyModel());
		AddPlaybackSystem(new MechwarriorHeroGrowupModel());
		AddPlaybackSystem(new MechwarriorStartGameModel());
		AddPlaybackSystem(new MechwarriorMessageModel());
		AddPlaybackSystem(new MechwarriorSkillIconModel());
		AddPlaybackSystem(new MechwarriorMechModel());
		AddPlaybackSystem(new MechwarriorRankModel());
		AddPlaybackSystem(new MechwarrionDecisiveBattleModel());
	}
}
