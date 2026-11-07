using Assets.Sources.Components.GameRule.Rpg;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgCountListHandler : ApcPacketHandler<RpgCounterListData>
{
	private GameRuleContext _gameRuleContext;

	public RpgCountListHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 126;
	}

	public override void Handle(RpgCounterListData data)
	{
		foreach (RpgCounterData item2 in data.List)
		{
			if (item2.Now < item2.Max)
			{
				TaskInfo item = new TaskInfo
				{
					Id = item2.Id,
					Name = item2.Name,
					Progress = item2.Now,
					Total = item2.Max
				};
				_gameRuleContext.task.TaskList.Add(item);
			}
		}
		NotifyManager.ForceInvoke(10);
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
