using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class TDIncentiveDataHandler : ApcPacketHandler<IntData>
{
	private GameRuleContext _gameRuleContext;

	public TDIncentiveDataHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 75;
	}

	public override void Handle(IntData data)
	{
		_gameRuleContext.pveIncentiveView.IncentiveData = data;
		_gameRuleContext.pveIncentiveView.Dirty = true;
	}
}
