using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BigHeadProgressHandler : ApcPacketHandler<BigHeadProgressData>
{
	private GameRuleContext _gameRuleContext;

	public BigHeadProgressHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 64;
	}

	public override void Handle(BigHeadProgressData data)
	{
		_gameRuleContext.bigHeadProgress.Lv = data.Lv;
		NotifyManager.ForceInvoke(56);
		_gameRuleContext.bigHeadProgress.Progress = data.Progress;
	}
}
