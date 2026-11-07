using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class UpdateGameRuleDamageEventHandler : ApcPacketHandler<GameRuleDamagerData>
{
	private GameRuleContext _gameRuleContext;

	private MessageContext _messageContext;

	public UpdateGameRuleDamageEventHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 208;
	}

	public override void Handle(GameRuleDamagerData data)
	{
		RpgTipsEventData rpgTipsEventData = new RpgTipsEventData();
		if (data.GameRuleEnergyRageReduce > 0)
		{
			_gameRuleContext.kingTreasuryData.Wave = 1;
			rpgTipsEventData.TypeId = -12603;
		}
		else if (data.GameRulePhysicsRageReduce > 0)
		{
			_gameRuleContext.kingTreasuryData.Wave = 2;
			rpgTipsEventData.TypeId = -12604;
		}
		else
		{
			switch (data.GameRuleFilterWeaponType)
			{
			case 1:
				_gameRuleContext.kingTreasuryData.Wave = 3;
				rpgTipsEventData.TypeId = -12605;
				break;
			case 12:
				_gameRuleContext.kingTreasuryData.Wave = 4;
				rpgTipsEventData.TypeId = -12606;
				break;
			case 10:
				_gameRuleContext.kingTreasuryData.Wave = 5;
				rpgTipsEventData.TypeId = -12607;
				break;
			case 5:
				_gameRuleContext.kingTreasuryData.Wave = 6;
				rpgTipsEventData.TypeId = -12608;
				break;
			case 6:
				_gameRuleContext.kingTreasuryData.Wave = 7;
				rpgTipsEventData.TypeId = -12609;
				break;
			}
		}
		if (rpgTipsEventData.TypeId != 0)
		{
			rpgTipsEventData.Time1 = 3000;
			_messageContext.gameTipsShow.TipsEvent.Add(rpgTipsEventData);
			NotifyManager.ForceInvoke(14);
		}
	}
}
