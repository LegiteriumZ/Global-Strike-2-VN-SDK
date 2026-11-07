using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;

public class RpgHolidayMode : RpgMode
{
	public RpgHolidayMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<PveFirstWinModel>();
		RemovePlayerbackSystem<RpgTaskTargetModel>();
		RemovePlayerbackSystem<RpgTableTaskModel>();
		RemovePlayerbackSystem<PveScoreRankModel>();
	}
}
