using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;

namespace Assets.Sources.Modules.Ui.Mode;

public class ExplodeMode : AbstractMode
{
	public ExplodeMode(Contexts contexts)
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
		AddPlaybackSystem(new CommonIndividualScoreInfoModel());
		AddPlaybackSystem(new MatchIndividualScoreInfoModel());
		AddPlaybackSystem(new GroupStrikeIndividualScoreInfoModel());
		AddPlaybackSystem(new BlastModelTeamScoreModel());
		AddPlaybackSystem(new BlastModelStartGameModel());
		AddPlaybackSystem(new C4StateProgressBarModel());
		AddPlaybackSystem(new BlastModelC4Model());
		AddPlaybackSystem(new BlastMessageModel());
		AddPlaybackSystem(new BlastGameOverModel());
		AddPlaybackSystem(new BestKillModel());
		AddPlaybackSystem(new BlastTacticsSoundModel());
	}
}
