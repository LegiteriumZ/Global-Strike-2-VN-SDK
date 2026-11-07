using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.RpgGroup;
using Assets.Sources.Ui.Model.RpgStealExpert;

namespace Assets.Sources.Modules.Ui.Mode;

internal class RpgStealExpertMode : RpgMode
{
	public RpgStealExpertMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<PveTeamScoreModel>();
		RemovePlayerbackSystem<PveFirstWinModel>();
		RemovePlayerbackSystem<RpgBotHpModel>();
		RemovePlayerbackSystem<RpgTaskTargetModel>();
		RemovePlayerbackSystem<PveScoreRankModel>();
		RemovePlayerbackSystem<RpgTableTaskModel>();
		RemovePlayerbackSystem<PveAllKillInfoModel>();
		AddPlaybackSystem(new TeamScoreModel());
		AddPlaybackSystem(new RpgGroupWaitPlayerModel());
		AddPlaybackSystem(new RpgStealExpertIndividualInfoModel());
	}
}
