using System.Collections.Generic;
using Assets.Sources.Components;
using NetData;

namespace Assets.Sources.Free.Scene;

public class EntityStatusHandler : ISimpleMesssageHandler
{
	private const int STROKE = 1;

	public bool CanHandle(int key)
	{
		return key == 72;
	}

	public void Handle(SimpleProto data)
	{
		int num = data.Ins[0];
		int key = data.Ins[1];
		if (num != 1)
		{
			return;
		}
		if (!Contexts.sharedInstance.battleRoom.gameStateEntity.hasEntityStatus)
		{
			Contexts.sharedInstance.battleRoom.gameStateEntity.AddEntityStatus(new Dictionary<int, Dictionary<int, string>>());
		}
		EntityStatusComponent entityStatus = Contexts.sharedInstance.battleRoom.gameStateEntity.entityStatus;
		if (!entityStatus.StatusDictionary.ContainsKey(key))
		{
			entityStatus.StatusDictionary.Add(key, new Dictionary<int, string>());
		}
		entityStatus.StatusDictionary[key][num] = data.Ss[0].Trim();
		Contexts.sharedInstance.battleRoom.gameStateEntity.isOutline = false;
		foreach (KeyValuePair<int, Dictionary<int, string>> item in entityStatus.StatusDictionary)
		{
			foreach (KeyValuePair<int, string> item2 in entityStatus.StatusDictionary[item.Key])
			{
				if (item2.Value == "true")
				{
					Contexts.sharedInstance.battleRoom.gameStateEntity.isOutline = true;
					break;
				}
			}
			if (Contexts.sharedInstance.battleRoom.gameStateEntity.isOutline)
			{
				break;
			}
		}
	}
}
