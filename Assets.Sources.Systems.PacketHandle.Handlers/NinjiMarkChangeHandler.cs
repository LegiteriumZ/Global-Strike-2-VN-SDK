using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class NinjiMarkChangeHandler : ApcPacketHandler<PosGroupChangeData>
{
	private GameRuleContext _gameRuleContext;

	public NinjiMarkChangeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 221;
	}

	public override void Handle(PosGroupChangeData data)
	{
		_gameRuleContext.ninjiMark.NinjiHhurt = true;
	}
}
