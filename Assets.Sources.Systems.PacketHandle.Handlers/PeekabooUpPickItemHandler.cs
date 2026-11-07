using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PeekabooUpPickItemHandler : ApcPacketHandler<PeekabooPickItemData>
{
	private MessageContext _context;

	public PeekabooUpPickItemHandler(Contexts contexts)
	{
		_context = contexts.message;
	}

	public override int MethodId()
	{
		return 80;
	}

	public override void Handle(PeekabooPickItemData data)
	{
		_context.peekabooMessageData.pickItemChanged = true;
		_context.peekabooMessageData.pickItemData = data;
	}
}
