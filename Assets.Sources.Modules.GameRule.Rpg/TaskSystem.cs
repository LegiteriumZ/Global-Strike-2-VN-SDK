using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using NotifyEvent;

namespace Assets.Sources.Modules.GameRule.Rpg;

public class TaskSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public TaskSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		bool flag = false;
		for (int i = 0; i < _gameRuleContext.task.TaskList.Count; i++)
		{
			TaskInfo taskInfo = _gameRuleContext.task.TaskList[i];
			if (taskInfo.Progress >= taskInfo.Total)
			{
				taskInfo.RemainTime -= _timeComponent.FrameInterval;
			}
			if (taskInfo.RemainTime < 0)
			{
				_gameRuleContext.task.TaskList.RemoveAt(i);
				i--;
				flag = true;
			}
		}
		if (flag)
		{
			NotifyManager.ForceInvoke(10);
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return _gameRuleContext.currentRule.Rule.IsRpg();
	}
}
