using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class KillOtherUiUpdateHandler : ApcPacketHandler<RightUIData>
{
	private GameRuleContext _gameRuleContext;

	public KillOtherUiUpdateHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 233;
	}

	public override void Handle(RightUIData data)
	{
		_gameRuleContext.rightUi.Data = data;
	}
}
