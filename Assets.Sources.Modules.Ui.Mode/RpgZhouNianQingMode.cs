using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.RpgZhouNianQing;

namespace Assets.Sources.Modules.Ui.Mode;

public class RpgZhouNianQingMode : RpgMode
{
	public RpgZhouNianQingMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<PveScoreRankModel>();
		RemovePlayerbackSystem<RpgTaskTargetModel>();
		RemovePlayerbackSystem<PveHomeHpModel>();
		AddPlaybackSystem(new RpgZhouNianQingScoreRankModel());
		AddPlaybackSystem(new RpgZhouNianQingMainHomeModel());
		AddPlaybackSystem(new RpgZhouNianQingHomeModel());
	}
}
