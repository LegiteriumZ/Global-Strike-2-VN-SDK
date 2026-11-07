using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.GoldExplode;

namespace Assets.Sources.Modules.Ui.Mode;

public class GoldExplodeMode : AbstractMode
{
	public GoldExplodeMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		AddPlaybackSystem(new KillMessageModel());
		AddPlaybackSystem(new PlayerStateModel());
		AddPlaybackSystem(new WeaponStateModel());
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new CommonPlayerHonoraryModel());
		AddPlaybackSystem(new PlayerScoreInfoModel());
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new BlastLikesModel());
		AddPlaybackSystem(new BlastByLikesModel());
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new RadarMapModel());
		AddPlaybackSystem(new MiniMapModel());
		AddPlaybackSystem(new BlastModelTeamScoreModel());
		AddPlaybackSystem(new BlastModelStartGameModel());
		AddPlaybackSystem(new C4StateProgressBarModel());
		AddPlaybackSystem(new BlastModelC4Model());
		AddPlaybackSystem(new BlastMessageModel());
		AddPlaybackSystem(new BlastGameOverModel());
		AddPlaybackSystem(new GoldExplodeIndividualScoreInfoModel());
		AddPlaybackSystem(new GoldExplodeIndividualMoneyModel());
		AddPlaybackSystem(new GoldExplodeMoneyModel());
		AddPlaybackSystem(new GoldExplodeBuyWeaponModel());
		AddPlaybackSystem(new GoldExplodeInBuyAreaModel());
		AddPlaybackSystem(new GoldExplodeMessageModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new BlastTacticsSoundModel());
	}
}
