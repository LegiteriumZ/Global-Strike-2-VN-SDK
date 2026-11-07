using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.Time;
using UnityEngine;

public class AllRoundSinglesModelSelectModeProvider : IAllRoundSinglesModelSelectModeProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected MessageContext _message;

	protected PlayerContext _playerContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	private int _curMp;

	private int _needMp;

	private Contexts contexts;

	private int SelectedIndex;

	private int RemainStartTime = 5000;

	private int RemainTotalTime = 8000;

	private int GameOverUiShowTime;

	private bool IsSend;

	public AllRoundSinglesModelSelectModeProvider(Contexts contexts)
	{
		this.contexts = contexts;
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
		_message = contexts.message;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public float Confirm()
	{
		if (SelectedIndex == 5)
		{
			SelectedIndex = Random.Range(0, 5);
		}
		Sendtcp();
		return 0f;
	}

	private void Reset()
	{
		GameOverUiShowTime = 0;
	}

	public float GetCountDown()
	{
		return (float)GameOverUiShowTime / 1000f;
	}

	public bool IsShow()
	{
		int num = _battleRoomContext.roomData.Data.WinScore / 2 + 1;
		if (_gameRuleContext.broadcastScore.Team2Score >= num || _gameRuleContext.broadcastScore.Team1Score >= num)
		{
			return false;
		}
		if (GameOverUiShowTime <= RemainStartTime)
		{
			return GameOverUiShowTime > 0;
		}
		return false;
	}

	public bool IsWin()
	{
		return _battleRoomContext.gameOver.IsWin;
	}

	public void OnFrame(TimeComponent time)
	{
		GameOverComponent gameOver = _battleRoomContext.gameOver;
		if (gameOver.IsGameOverDataChange)
		{
			gameOver.IsGameOverDataChange = false;
			IsSend = false;
			GameOverUiShowTime = RemainTotalTime;
		}
		if (GameOverUiShowTime >= 0)
		{
			GameOverUiShowTime -= time.FrameInterval;
		}
		if (GameOverUiShowTime <= 400 && GameOverUiShowTime > 0 && !IsSend && !IsWin())
		{
			Sendtcp();
		}
	}

	private void Sendtcp()
	{
		IsSend = true;
		contexts.battleServer.battleServer.Server.SendTcpMessage(160, SelectedIndex);
		Reset();
	}

	public float Select0()
	{
		SelectedIndex = 0;
		return 0f;
	}

	public bool IsSelect0()
	{
		return SelectedIndex == 0;
	}

	public float Select1()
	{
		SelectedIndex = 1;
		return 0f;
	}

	public bool IsSelect1()
	{
		return SelectedIndex == 1;
	}

	public float Select2()
	{
		SelectedIndex = 2;
		return 0f;
	}

	public bool IsSelect2()
	{
		return SelectedIndex == 2;
	}

	public float Select3()
	{
		SelectedIndex = 3;
		return 0f;
	}

	public bool IsSelect3()
	{
		return SelectedIndex == 3;
	}

	public float Select4()
	{
		SelectedIndex = 4;
		return 0f;
	}

	public bool IsSelect4()
	{
		return SelectedIndex == 4;
	}

	public float Select5()
	{
		SelectedIndex = 5;
		return 0f;
	}

	public bool IsSelect5()
	{
		return SelectedIndex == 5;
	}
}
