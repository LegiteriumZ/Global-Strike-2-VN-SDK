using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.RpgGuoZhan;
using Assets.Sources.Ui.Model.RpgZhouNianQing;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgGuoZhanMode : RpgMode
{
	public RpgGuoZhanMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<PveScoreRankModel>();
		RemovePlayerbackSystem<RpgTaskTargetModel>();
		RemovePlayerbackSystem<PveHomeHpModel>();
		RemovePlayerbackSystem<PveAllKillInfoModel>();
		AddPlaybackSystem(new RpgZhouNianQingMainHomeModel());
		AddPlaybackSystem(new RpgZhouNianQingHomeModel());
		AddPlaybackSystem(new RpgGuoZhanAllKillInfoModel());
		AddPlaybackSystem(new RpgGuoZhanScoreRankModel());
	}
}
