using Assets.Sources.Components.Time;
using I2.Loc;
using NetData;

public class commonKickVoteUIProvider : IcommonKickVoteUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	public commonKickVoteUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.kickOut.voteVisible)
		{
			_gameRuleContext.kickOut.showTime += time.FrameInterval;
		}
	}

	public bool KickVoteShow()
	{
		return _gameRuleContext.kickOut.voteVisible;
	}

	public float Agree()
	{
		Vote vote = new Vote();
		vote.IsAgree = true;
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(41, vote);
		return 0f;
	}

	public float Disagree()
	{
		Vote vote = new Vote();
		vote.IsAgree = false;
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(41, vote);
		return 0f;
	}

	public string getTimerText()
	{
		int num = 16 - _gameRuleContext.kickOut.showTime / 1000;
		if (num >= 1)
		{
			return $"({num}s)";
		}
		return "";
	}

	public bool isResult()
	{
		return _gameRuleContext.kickOut.isResult;
	}

	public string GetName()
	{
		if (_gameRuleContext.hasKickOut && _gameRuleContext.kickOut.votePanel != null)
		{
			return _battleRoomContext.playerInfo.GetOneKillInfo(_gameRuleContext.kickOut.votePanel.KickPlayerId).PlayerName;
		}
		return "";
	}

	public string GetReason()
	{
		if (_gameRuleContext.hasKickOut && _gameRuleContext.kickOut.votePanel != null)
		{
			return ScriptLocalization.Get("kickReason" + _gameRuleContext.kickOut.votePanel.Reason);
		}
		return "";
	}

	public string GetRejest()
	{
		if (_gameRuleContext.hasKickOut && _gameRuleContext.kickOut.votePanel != null)
		{
			return _gameRuleContext.kickOut.votePanel.Rejest.ToString();
		}
		return "";
	}

	public string GetAgree()
	{
		if (_gameRuleContext.hasKickOut && _gameRuleContext.kickOut.votePanel != null)
		{
			return _gameRuleContext.kickOut.votePanel.Agree.ToString();
		}
		return "";
	}
}
