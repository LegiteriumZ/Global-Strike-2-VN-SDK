using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgEnemyAttributeHandler : ApcPacketHandler<BotAffixesData>
{
	private GameRuleContext _gameRuleContext;

	public AcgEnemyAttributeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1104;
	}

	public override void Handle(BotAffixesData data)
	{
		if (_gameRuleContext.acgEnemyInfo.AcgEnemyAttribute == null)
		{
			_gameRuleContext.acgEnemyInfo.AcgEnemyAttribute = new Dictionary<int, List<int>>();
		}
		_gameRuleContext.acgEnemyInfo.AcgEnemyAttribute.Add(data.Id, data.Affixes);
	}
}
