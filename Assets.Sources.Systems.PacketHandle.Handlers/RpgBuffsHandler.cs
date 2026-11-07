using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class RpgBuffsHandler : ApcPacketHandler<SkillBuffData>
{
	private GameRuleContext _gameRuleContext;

	private List<SkillBuffData> _rpgbuffsList;

	private int _removedIndex;

	public RpgBuffsHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 341;
	}

	public override void Handle(SkillBuffData data)
	{
		if (!_gameRuleContext.hasRpgBuffs)
		{
			return;
		}
		_rpgbuffsList = _gameRuleContext.rpgBuffs.RpgBuffsList;
		if (_rpgbuffsList == null)
		{
			_rpgbuffsList = (_gameRuleContext.rpgBuffs.RpgBuffsList = new List<SkillBuffData>());
		}
		if (data.Duration == 1)
		{
			for (int i = 0; i < _rpgbuffsList.Count; i++)
			{
				if (_rpgbuffsList[i].Skillid == data.Skillid)
				{
					_rpgbuffsList[i].Active = ((_rpgbuffsList[i].Active < data.Active) ? data.Active : _rpgbuffsList[i].Active);
					return;
				}
			}
			_rpgbuffsList.Add(data);
		}
		else
		{
			if (data.Duration != -1)
			{
				return;
			}
			for (int j = 0; j < _rpgbuffsList.Count; j++)
			{
				if (_rpgbuffsList[j].Skillid == data.Skillid)
				{
					_removedIndex = j;
				}
			}
			_rpgbuffsList.RemoveAt(_removedIndex);
		}
	}
}
