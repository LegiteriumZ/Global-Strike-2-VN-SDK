using System.Diagnostics;
using Assets.Sources.Components.Time;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;

public class commonAceReportProvider : IcommonAceReportProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	private int _autoCloseTime;

	public commonAceReportProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_autoCloseTime > 0)
		{
			_autoCloseTime -= time.FrameInterval;
			if (_autoCloseTime <= 0)
			{
				Close();
			}
		}
	}

	public bool IsAceReportShow()
	{
		if (_battleRoomContext == null || _battleRoomContext.ace == null || !_battleRoomContext.ace.IsRefresh)
		{
			return false;
		}
		if (_autoCloseTime <= 0)
		{
			_autoCloseTime = 10000;
		}
		return true;
	}

	public float ShowTime()
	{
		return _autoCloseTime / 1000 + 1;
	}

	public float CloseGame()
	{
		Close();
		return 0f;
	}

	private void Close()
	{
		_battleRoomContext.ace.IsRefresh = false;
		_autoCloseTime = 0;
		this.Info("Ace Exit Game");
		UnityMainThreadDispatcher.Enqueue(delegate
		{
			MonoBehaviourSingleton<GameExitManager>.Instance.ExitGame();
			ExecuteGG.CloseNPGameMon();
			if (!Application.isEditor)
			{
				Process.GetCurrentProcess().Kill();
			}
		});
	}
}
