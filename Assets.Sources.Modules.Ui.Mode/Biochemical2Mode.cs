using Assets.Sources.Ui.Model.Biochemical;
using Assets.Sources.Ui.Model.Biochemical2;
using Assets.Sources.Ui.Model.Biochemical3;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

internal class Biochemical2Mode : AbstractMode
{
	public Biochemical2Mode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		AddPlaybackSystem(new KillMessageModel());
		AddPlaybackSystem(new PlayerStateModel());
		AddPlaybackSystem(new WeaponStateModel());
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new BiochemicalHonoraryModel());
		AddPlaybackSystem(new Biochemical2StartGameModel());
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
		AddPlaybackSystem(new Biochemical2IndividualScoreInfoModel());
		AddPlaybackSystem(new BiochemicalGameOverModel());
		AddPlaybackSystem(new BiochemicalMessageModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new WaitPlayerModel());
		AddPlaybackSystem(new Biochemical2SkillBoardModel());
		AddPlaybackSystem(new Biochemical2SkillBarModel());
		AddPlaybackSystem(new Biochemical2SkillMessageModel());
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new Biochemical3SelectVariantModel());
		AddPlaybackSystem(new RpgExplodeoilModel());
	}
}
