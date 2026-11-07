using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class BiochemicalMode : AbstractMode
{
	public BiochemicalMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		AddPlaybackSystem(new KillMessageModel());
		AddPlaybackSystem(new PlayerStateModel());
		AddPlaybackSystem(new WeaponStateModel());
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new BiochemicalHonoraryModel());
		AddPlaybackSystem(new BiochemicalHumanityGrowUpModel());
		AddPlaybackSystem(new BiochemicalStartGameModel());
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
	}
}
