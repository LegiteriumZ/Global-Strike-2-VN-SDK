using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class OtherProgressHandler : ApcPacketHandler<OtherProgressData>
{
	private GameRuleContext _gameRuleContext;

	public OtherProgressHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 223;
	}

	public override void Handle(OtherProgressData data)
	{
		_gameRuleContext.otherProgress.ProgressVal = data.Progress;
	}
}
