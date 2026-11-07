using Assets.Sources.Ui.Model.Blast;
using Assets.Sources.Ui.Model.BroadSword;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.DeathMatch;

namespace Assets.Sources.Modules.Ui.Mode;

public class BroadSwordMode : AbstractMode
{
	public BroadSwordMode(Contexts contexts)
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
		AddPlaybackSystem(new BroadSwordTeamScoreModel());
		AddPlaybackSystem(new BlastMessageModel());
		AddPlaybackSystem(new BlastGameOverModel());
		AddPlaybackSystem(new DeathMatchBestKillModel());
		AddPlaybackSystem(new BroadSwordIndividualInfoModel());
		AddPlaybackSystem(new DeathMatchReliveProgressModel());
		AddPlaybackSystem(new DeathMatchMessageModel());
	}
}
