using Assets.Sources.Components.Time;

public class peekabooModelPeekAbooTeamScoreGUIProvider : IpeekabooModelPeekAbooTeamScoreGUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public peekabooModelPeekAbooTeamScoreGUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public string updateTextInfo(int index)
	{
		switch (index)
		{
		case 0:
		{
			int minutes = Contexts.sharedInstance.battleRoom.sectionTime.Minutes;
			if (minutes < 10)
			{
				return "0" + minutes;
			}
			return string.Concat(minutes);
		}
		case 1:
		{
			int seconds = Contexts.sharedInstance.battleRoom.sectionTime.Seconds;
			if (seconds < 10)
			{
				return "0" + seconds;
			}
			return string.Concat(seconds);
		}
		case 2:
			return string.Concat(Contexts.sharedInstance.gameRule.broadcastScore.Team1Score);
		case 3:
			return string.Concat(Contexts.sharedInstance.gameRule.broadcastScore.Team2Score);
		case 4:
			return string.Concat(Contexts.sharedInstance.gameRule.broadcastScore.WinScore);
		case 5:
			return string.Concat(Contexts.sharedInstance.gameRule.broadcastScore.CurrentScore);
		case 6:
			return string.Concat(Contexts.sharedInstance.battleRoom.playerInfo.Team1.Count);
		case 7:
			return string.Concat(Contexts.sharedInstance.battleRoom.playerInfo.Team2.Count);
		default:
			return "0";
		}
	}
}
