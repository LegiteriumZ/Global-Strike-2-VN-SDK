using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.FinalBio;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.SuperBio;

namespace Assets.Sources.Modules.Ui.Mode;

public class SuperBiochemicalMode : AbstractMode
{
	public SuperBiochemicalMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		AddPlaybackSystem(new KillMessageModel());
		AddPlaybackSystem(new PlayerStateModel());
		AddPlaybackSystem(new WeaponStateModel());
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new BiochemicalHonoraryModel());
		AddPlaybackSystem(new BiochemicalNewVariantsGrowUpModel());
		AddPlaybackSystem(new BiochemicalKillBroadModel());
		AddPlaybackSystem(new RadarMapModel());
		AddPlaybackSystem(new MiniMapModel());
		AddPlaybackSystem(new BiochemicalTeamScoreModel());
		AddPlaybackSystem(new BiochemicalHeroKillDamageModel());
		AddPlaybackSystem(new BiochemicalDamageScoreModel());
		AddPlaybackSystem(new BiochemicalSkillIconModel());
		AddPlaybackSystem(new BiochemicalSkillProgressBarModel());
		AddPlaybackSystem(new BiochemicalDecisiveBattleModel());
		AddPlaybackSystem(new BiochemicalSelectHeroWeaponModel());
		AddPlaybackSystem(new BiochemicalSelectVariantModel());
		AddPlaybackSystem(new BiochemicalCarboxylicModel());
		AddPlaybackSystem(new BiochemicalSerumModel());
		AddPlaybackSystem(new BiochemicalIndividualScoreInfoModel());
		AddPlaybackSystem(new BiochemicalGameOverModel());
		AddPlaybackSystem(new BiochemicalMessageModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new Biochemical3SelectVariantModel());
		AddPlaybackSystem(new RpgExplodeoilModel());
		AddPlaybackSystem(new SuperBioHumanityGrowUpModel());
		AddPlaybackSystem(new SuperBioStartGameModel());
		AddPlaybackSystem(new SuperBioVariantsGrowUpModel());
		AddPlaybackSystem(new FinalBioChangeHumanityModel());
		AddPlaybackSystem(new SuperBioMessageModel());
	}
}
