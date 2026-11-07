using Assets.Sources.Components.Time;

public class freeRpg_107000ModelNotLeaveRoomProvider : IfreeRpg_107000ModelNotLeaveRoomProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelNotLeaveRoomProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.mystery.NotLeaveRoomTime > 0)
		{
			_gameRuleContext.mystery.NotLeaveRoomTime -= time.FrameInterval;
			if (_gameRuleContext.mystery.NotLeaveRoomTime <= 0)
			{
				_gameRuleContext.mystery.IsNotLeaveRoom = false;
			}
		}
	}

	public bool IsShowNotLeaveRoom()
	{
		return _gameRuleContext.mystery.IsNotLeaveRoom;
	}

	public float RefreshMinute()
	{
		return _gameRuleContext.mystery.NotLeaveRoomTime / 1000 / 60;
	}

	public float RefreshSecond()
	{
		return _gameRuleContext.mystery.NotLeaveRoomTime / 1000 % 60;
	}
}
