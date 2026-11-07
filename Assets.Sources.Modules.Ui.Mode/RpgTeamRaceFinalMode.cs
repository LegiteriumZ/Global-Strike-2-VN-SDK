using Assets.Sources.Ui.Model.RpgTeamRace;

namespace Assets.Sources.Modules.Ui.Mode;

internal class RpgTeamRaceFinalMode : RpgGroupMode
{
	public RpgTeamRaceFinalMode(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void AdditionUi()
	{
		AddPlaybackSystem(new RpgTeamRaceFinalInfoModel());
		AddPlaybackSystem(new RpgTeamRaceScoreRankModel());
		AddPlaybackSystem(new RpgTeamRaceSkillStateModel());
		AddPlaybackSystem(new RpgTeamRaceItemModel());
		AddPlaybackSystem(new RpgTeamRaceMessageModel());
	}
}
