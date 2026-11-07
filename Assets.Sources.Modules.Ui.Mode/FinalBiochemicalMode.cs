using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.FinalBio;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class FinalBiochemicalMode : AbstractMode
{
	public FinalBiochemicalMode(Contexts contexts)
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
		AddPlaybackSystem(new RadarMapModel());
		AddPlaybackSystem(new MiniMapModel());
		AddPlaybackSystem(new BiochemicalTeamScoreModel());
		AddPlaybackSystem(new BiochemicalHeroKillDamageModel());
		AddPlaybackSystem(new BiochemicalDamageScoreModel());
		AddPlaybackSystem(new BiochemicalSkillProgressBarModel());
		AddPlaybackSystem(new BiochemicalSelectHeroWeaponModel());
		AddPlaybackSystem(new BiochemicalSelectVariantModel());
		AddPlaybackSystem(new BiochemicalCarboxylicModel());
		AddPlaybackSystem(new BiochemicalSerumModel());
		AddPlaybackSystem(new BiochemicalIndividualScoreInfoModel());
		AddPlaybackSystem(new BiochemicalGameOverModel());
		AddPlaybackSystem(new BiochemicalKillBroadModel());
		AddPlaybackSystem(new Biochemical3SelectVariantModel());
		AddPlaybackSystem(new FinalBioDecisiveBattleModel());
		AddPlaybackSystem(new FinalBioHumanityGrowUpModel());
		AddPlaybackSystem(new FinalBioVariantsGrowUpModel());
		AddPlaybackSystem(new FinalBioMessageModel());
		AddPlaybackSystem(new FinalBioStartGameModel());
		AddPlaybackSystem(new FinalBioSkillIconModel());
		AddPlaybackSystem(new FinalBioChangeHumanityModel());
		AddPlaybackSystem(new FinalBioQueenWeaponModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new RpgExplodeoilModel());
	}
}
