using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class FloatingMessageHandler : ApcPacketHandler<FloatingMessageData>
{
	private MessageContext _messageContext;

	public FloatingMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 211;
	}

	public override void Handle(FloatingMessageData data)
	{
		_messageContext.floatingMessage.DragoonData = data;
	}
}
