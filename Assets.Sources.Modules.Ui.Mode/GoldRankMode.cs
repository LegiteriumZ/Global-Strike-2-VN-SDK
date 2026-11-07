using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.GunFight;

namespace Assets.Sources.Modules.Ui.Mode;

internal class GoldRankMode : AbstractMode
{
	public GoldRankMode(Contexts contexts)
		: base(contexts)
	{
		AddPlaybackSystem(new RadarMapModel());
		AddPlaybackSystem(new MiniMapModel());
		AddPlaybackSystem(new KillMessageModel());
		AddPlaybackSystem(new PlayerStateModel());
		AddPlaybackSystem(new WeaponStateModel());
		AddPlaybackSystem(new CommonPlayerHonoraryModel());
		AddPlaybackSystem(new PlayerScoreInfoModel());
		AddPlaybackSystem(new CommonKillBroadModel());
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new GunFightIndividualInfoModel());
		AddPlaybackSystem(new GunFightTextMessageModel());
	}
}
