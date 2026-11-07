using NetData;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SkatePressDataHandler : ApcPacketHandler<BooleanData>
{
	private readonly GameRuleContext _gameRuleContext;

	public SkatePressDataHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 274;
	}

	public override void Handle(BooleanData data)
	{
		_gameRuleContext.skatePress.IsPress = data.Data;
		_gameRuleContext.skatePress.StartTime = UnityEngine.Time.time;
		_gameRuleContext.skatePress.RemainTime = 1f;
	}
}
