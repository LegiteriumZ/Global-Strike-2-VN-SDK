using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Jump;
using Assets.Sources.Ui.Model.Rpg;

namespace Assets.Sources.Modules.Ui.Mode;

public class JumpMode : AbstractMode
{
	public JumpMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new PlayerRebornModel());
		AddPlaybackSystem(new StrokeAnalysisModel());
		AddPlaybackSystem(new PlayerStateModel());
		AddPlaybackSystem(new WeaponStateModel());
		AddPlaybackSystem(new RadarMapModel());
		AddPlaybackSystem(new MiniMapModel());
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new PlayerBagModel());
		AddPlaybackSystem(new JumpIndividualScoreInfoModel());
		AddPlaybackSystem(new JumpTeamScoreModel());
		AddPlaybackSystem(new JumpGameOverModel());
		AddPlaybackSystem(new JumpSaveProgressBarModel());
		AddPlaybackSystem(new JumpSpeedModel());
		AddPlaybackSystem(new JumpShortcutKeyDescriptionModel());
		AddPlaybackSystem(new RpgMessageModel());
	}
}
