using Assets.Sources.Ui.Model.Group;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.RpgArmament;

public class RpgArmamentTeamScoreModel : TeamScoreModel
{
	protected override void SetTeam2Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString2 = StringCache.LongToString(0L);
	}

	protected override void SetTeam1Score(long arg1, long arg2)
	{
		_viewModel.TeamScoreString1 = StringCache.LongToString(0L);
	}
}
