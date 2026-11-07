using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Quest;
using Assets.Sources.Info.Quest;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgQuestHandler : ApcPacketHandler<AcgTask>
{
	private GameRuleContext _gameRuleContext;

	public AcgQuestHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1107;
	}

	public override void Handle(AcgTask data)
	{
		if (_gameRuleContext.acgQuest.AcgQuestList == null)
		{
			_gameRuleContext.acgQuest.AcgQuestList = new List<IAcgQuest>();
		}
		if (data.Show)
		{
			foreach (IAcgQuest acgQuest2 in _gameRuleContext.acgQuest.AcgQuestList)
			{
				if (acgQuest2.id == data.Id)
				{
					acgQuest2.isCleared = data.Finish;
					acgQuest2.time = data.Time;
					return;
				}
			}
			AcgQuest acgQuest = new AcgQuest();
			acgQuest.id = data.Id;
			acgQuest.isCleared = data.Finish;
			acgQuest.time = data.Time;
			_gameRuleContext.acgQuest.AcgQuestList.Add(acgQuest);
			return;
		}
		for (int i = 0; i < _gameRuleContext.acgQuest.AcgQuestList.Count; i++)
		{
			if (_gameRuleContext.acgQuest.AcgQuestList[i].id == data.Id)
			{
				_gameRuleContext.acgQuest.AcgQuestList.RemoveAt(i);
				break;
			}
		}
	}
}
