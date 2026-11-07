using Assets.Sources.Components.Time;

public class freeRpg_107000ModelTaskInfoProvider : IfreeRpg_107000ModelTaskInfoProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	public freeRpg_107000ModelTaskInfoProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public float RefreshTaskOne()
	{
		return _gameRuleContext.mystery.TaskOne;
	}

	public float RefreshTaskTwo()
	{
		return _gameRuleContext.mystery.TaskTwo;
	}

	public bool IsType1()
	{
		return _gameRuleContext.mystery.TaskTypeOne == 1;
	}

	public bool IsTaskInfoShow()
	{
		return _gameRuleContext.mystery.IsShowTaskInfo;
	}

	public bool IsShow1()
	{
		return _gameRuleContext.mystery.TaskTypeOne > 0;
	}

	public bool IsShow2()
	{
		return _gameRuleContext.mystery.TaskTypeTwo > 0;
	}
}
