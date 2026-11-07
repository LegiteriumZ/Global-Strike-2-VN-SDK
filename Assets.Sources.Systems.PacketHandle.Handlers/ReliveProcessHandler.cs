using System.Collections.Generic;
using Assets.Sources.Components.GameRule.MechKing;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class ReliveProcessHandler : ApcPacketHandler<DynamicProcessData>
{
	private GameRuleContext _gameRuleContext;

	private List<int> deleteList = new List<int>();

	public ReliveProcessHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 340;
	}

	public override void Handle(DynamicProcessData data)
	{
		updateOrCreateData(data);
		removeCheck();
	}

	private void updateOrCreateData(DynamicProcessData data)
	{
		DynamicProcessUIData dynamicProcessUIData = getById(data.Id);
		if (dynamicProcessUIData == null)
		{
			dynamicProcessUIData = new DynamicProcessUIData();
			_gameRuleContext.reliveProcessData._allUIData[data.Id] = dynamicProcessUIData;
		}
		dynamicProcessUIData.merage(data);
	}

	private void removeCheck()
	{
		foreach (KeyValuePair<int, DynamicProcessUIData> allUIDatum in _gameRuleContext.reliveProcessData._allUIData)
		{
			if (allUIDatum.Value._type != 2 && (allUIDatum.Value._maxPower <= 0 || allUIDatum.Value._currentPower >= allUIDatum.Value._maxPower))
			{
				deleteList.Add(allUIDatum.Key);
			}
		}
		foreach (int delete in deleteList)
		{
			if (_gameRuleContext.reliveProcessData._allUIData.ContainsKey(delete))
			{
				_gameRuleContext.reliveProcessData._allUIData.Remove(delete);
			}
		}
		deleteList.Clear();
	}

	public DynamicProcessUIData getById(int id)
	{
		if (_gameRuleContext.reliveProcessData._allUIData.ContainsKey(id))
		{
			return _gameRuleContext.reliveProcessData._allUIData[id];
		}
		return null;
	}

	public DynamicProcessUIData getByType(int type)
	{
		foreach (DynamicProcessUIData value in _gameRuleContext.reliveProcessData._allUIData.Values)
		{
			if (value._type == type)
			{
				return value;
			}
		}
		return null;
	}
}
