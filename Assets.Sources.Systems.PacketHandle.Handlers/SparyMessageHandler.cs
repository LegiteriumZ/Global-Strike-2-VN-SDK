using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SparyMessageHandler : ApcPacketHandler<SprayMessageData>
{
	private MessageContext _messageContext;

	public SparyMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 38;
	}

	public override void Handle(SprayMessageData data)
	{
		_messageContext.sparyMessageData.Type = data.Type;
		_messageContext.sparyMessageData.Changed = true;
		NotifyManager.ForceInvoke(42);
	}
}
