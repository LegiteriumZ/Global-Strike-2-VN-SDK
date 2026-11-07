using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class GuoShiWuShuangIconHandler : ApcPacketHandler<GuoShiWuShuangMessageData>
{
	private readonly GameRuleContext _gameRuleContext;

	public GuoShiWuShuangIconHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 400;
	}

	public override void Handle(GuoShiWuShuangMessageData data)
	{
		_gameRuleContext.guoShiWuShuangIcon.Buffs[data.Type] = new int[2] { data.Para, data.Para };
	}
}
