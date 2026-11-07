using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearCarProgressPushHandler : ApcPacketHandler<CarProgressPush>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearCarProgressPushHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 253;
	}

	public override void Handle(CarProgressPush data)
	{
		_gameRuleContext.mouseYear.CarProcess = data.Progress;
	}
}
