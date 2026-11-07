using Assets.Sources.Components.Time;
using NetData;

public class peekabooModelPeekAbooGameOverGUIProvider : IpeekabooModelPeekAbooGameOverGUIProvider, IModuleProvider
{
	protected BattleRoomContext _roomContext;

	private PlayerContext _playerContext;

	protected readonly int remainTime = 3000;

	protected int showTimer;

	private int aliveCount;

	public peekabooModelPeekAbooGameOverGUIProvider(Contexts contexts)
	{
		_roomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		if (showTimer > 0)
		{
			showTimer -= time.FrameInterval;
		}
		if (_roomContext.gameOver.peekabooMissionChange)
		{
			_roomContext.gameOver.peekabooMissionChange = false;
			PeekabooResultScoreData peekabooData = _roomContext.gameOver.peekabooData;
			aliveCount = 0;
			if (peekabooData.AliveItem1Specified)
			{
				aliveCount++;
			}
			if (peekabooData.AliveItem2Specified)
			{
				aliveCount++;
			}
			if (peekabooData.AliveItem3Specified)
			{
				aliveCount++;
			}
			showTimer = remainTime;
		}
	}

	public bool updateImgItemVisible(int index)
	{
		return index < aliveCount;
	}

	public string updateImgItemSrcByIndex(int index)
	{
		PeekabooResultScoreData peekabooData = _roomContext.gameOver.peekabooData;
		if (index < aliveCount)
		{
			switch (index)
			{
			case 0:
				return ("/ui/GameGUIRes/peekabooModel/item/" + peekabooData.AliveItem1) ?? "";
			case 1:
				return ("/ui/GameGUIRes/peekabooModel/item/" + peekabooData.AliveItem2) ?? "";
			case 2:
				return ("/ui/GameGUIRes/peekabooModel/item/" + peekabooData.AliveItem3) ?? "";
			}
		}
		return "";
	}

	public bool updateRootVisible()
	{
		return showTimer > 0;
	}

	public bool updateTxtNameVisible(int index)
	{
		return index < aliveCount;
	}

	public string updateTxtNameByIndex(int index)
	{
		PeekabooResultScoreData peekabooData = _roomContext.gameOver.peekabooData;
		if (index < aliveCount)
		{
			switch (index)
			{
			case 0:
				return peekabooData.AlivePlayerName1;
			case 1:
				return peekabooData.AlivePlayerName2;
			case 2:
				return peekabooData.AlivePlayerName3;
			}
		}
		return "";
	}

	public bool updateWinItemVisible(int index)
	{
		return index < aliveCount;
	}

	public float updateConWinX(int index)
	{
		int num = 140 * aliveCount + (aliveCount - 1) * 40;
		return 710 + (500 - num) / 2;
	}

	public bool updateSurviveVisible()
	{
		if (_roomContext.gameOver.peekabooData == null)
		{
			return false;
		}
		return _roomContext.gameOver.peekabooData.OtherAliveNum > 0;
	}

	public float updateSurviveCount()
	{
		return _roomContext.gameOver.peekabooData.OtherAliveNum;
	}

	public string updateImgWinSrc()
	{
		if (_roomContext.gameOver.peekabooData.WinTeam == _playerContext.myPlayerEntity.GetTeam())
		{
			return "/ui/GameGUIRes/common/gameover/gamewin";
		}
		return "/ui/GameGUIRes/common/gameover/gamelose";
	}

	public bool updateItemContainerVisible()
	{
		if (_roomContext.gameOver.peekabooData.WinTeam == 2)
		{
			return false;
		}
		return aliveCount > 0;
	}
}
