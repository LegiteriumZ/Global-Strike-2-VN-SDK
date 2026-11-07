using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Group;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.RpgDuel;

namespace Assets.Sources.Modules.Ui.Mode;

internal class RpgDuelMode : RpgMode
{
	public RpgDuelMode(Contexts contexts)
		: base(contexts)
	{
		RemovePlayerbackSystem<PveTeamScoreModel>();
		RemovePlayerbackSystem<PveFirstWinModel>();
		RemovePlayerbackSystem<RpgTaskTargetModel>();
		RemovePlayerbackSystem<PveScoreRankModel>();
		RemovePlayerbackSystem<RpgTableTaskModel>();
		RemovePlayerbackSystem<PveAllKillInfoModel>();
		RemovePlayerbackSystem<PlayerBagModel>();
		AddPlaybackSystem(new TeamScoreModel());
		AddPlaybackSystem(new RpgDuelIndividualInfoModel());
		AddPlaybackSystem(new RpgDuelPlayerBagModel());
	}
}
