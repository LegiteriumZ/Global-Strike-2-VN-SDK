using System.Collections.Generic;
using Assets.Sources.Systems.PacketHandle.Handlers;
using NetData;
using NotifyEvent;

public class HuLaoGuanPlayerHandler : ApcPacketHandler<HuLaoGuanCareerData>
{
	private GameRuleContext _gameRuleContext;

	public HuLaoGuanPlayerHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 343;
	}

	public override void Handle(HuLaoGuanCareerData data)
	{
		if (_gameRuleContext.huLaoGuanPlayerInfo.palyerInof == null)
		{
			_gameRuleContext.huLaoGuanPlayerInfo.palyerInof = new Dictionary<int, long>(4);
		}
		_gameRuleContext.huLaoGuanPlayerInfo.palyerInof[0] = data.Career1;
		_gameRuleContext.huLaoGuanPlayerInfo.palyerInof[1] = data.Career2;
		_gameRuleContext.huLaoGuanPlayerInfo.palyerInof[2] = data.Career3;
		_gameRuleContext.huLaoGuanPlayerInfo.palyerInof[3] = data.Career4;
		NotifyManager.ForceInvoke(116);
	}
}
