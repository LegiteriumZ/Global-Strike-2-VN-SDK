using Assets.Sources.Ui.Model.RpgTeamRace;

namespace Assets.Sources.Modules.Ui.Mode;

internal class RpgTeamRaceMode : RpgGroupMode
{
	public RpgTeamRaceMode(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void AdditionUi()
	{
		AddPlaybackSystem(new RpgTeamRaceIndividualInfoModel());
		AddPlaybackSystem(new RpgTeamRaceScoreRankModel());
		AddPlaybackSystem(new RpgTeamRaceSkillStateModel());
		AddPlaybackSystem(new RpgTeamRaceItemModel());
		AddPlaybackSystem(new RpgTeamRaceMessageModel());
	}
}
