using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgInstructionHandler : ApcPacketHandler<TipsMessage>
{
	private GameRuleContext _gameRuleContext;

	public AcgInstructionHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 1103;
	}

	public override void Handle(TipsMessage data)
	{
		_gameRuleContext.acgInstruction.instruction = data;
		NotifyManager.ForceInvoke(110);
	}
}
