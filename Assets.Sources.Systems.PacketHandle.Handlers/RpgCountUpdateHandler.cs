using System;
using Assets.Sources.Components.GameRule.Rpg;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgCountUpdateHandler : ApcPacketHandler<RpgCounterData>
{
	private GameRuleContext _gameRuleContext;

	private readonly Comparison<TaskInfo> _comparison;

	public RpgCountUpdateHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_comparison = TaskSortComparison;
	}

	public override int MethodId()
	{
		return 114;
	}

	public override void Handle(RpgCounterData data)
	{
		TaskInfo taskInfo = FindTask(data.Id);
		if (taskInfo == null)
		{
			taskInfo = new TaskInfo
			{
				Id = data.Id,
				Name = data.Name,
				Progress = data.Now,
				Total = data.Max
			};
			_gameRuleContext.task.TaskList.Add(taskInfo);
		}
		taskInfo.Progress = data.Now;
		taskInfo.IsUpdate = true;
		_gameRuleContext.task.TaskList.Sort(_comparison);
		NotifyManager.ForceInvoke(10);
	}

	private int TaskSortComparison(TaskInfo a, TaskInfo b)
	{
		float num = ((a.Total > 0) ? ((float)a.Progress / (float)a.Total) : 0f);
		float num2 = ((b.Total > 0) ? ((float)b.Progress / (float)b.Total) : 0f);
		if (num > num2)
		{
			return -1;
		}
		if (num < num2)
		{
			return 1;
		}
		return 0;
	}

	private TaskInfo FindTask(int id)
	{
		for (int i = 0; i < _gameRuleContext.task.TaskList.Count; i++)
		{
			TaskInfo taskInfo = _gameRuleContext.task.TaskList[i];
			if (taskInfo.Id == id)
			{
				return taskInfo;
			}
		}
		return null;
	}
}
