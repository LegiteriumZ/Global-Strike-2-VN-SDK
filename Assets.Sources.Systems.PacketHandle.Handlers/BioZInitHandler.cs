using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class BioZInitHandler : ApcPacketHandler<NBioZInitData>
{
	private GameRuleContext _gameRuleContext;

	public BioZInitHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1108;
	}

	public override void Handle(NBioZInitData data)
	{
		Contexts.sharedInstance.message.bioZInit.BioZInitData = data;
		NotifyManager.ForceInvoke(124);
	}
}
