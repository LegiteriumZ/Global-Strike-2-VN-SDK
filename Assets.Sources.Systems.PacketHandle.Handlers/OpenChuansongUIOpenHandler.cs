using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class OpenChuansongUIOpenHandler : ApcPacketHandler<IntData>
{
	private GameRuleContext _context;

	public OpenChuansongUIOpenHandler(Contexts contexts)
	{
		_context = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 612;
	}

	public override void Handle(IntData data)
	{
		_context.rpgTreasureBossData.showChuansongUI = true;
	}
}
