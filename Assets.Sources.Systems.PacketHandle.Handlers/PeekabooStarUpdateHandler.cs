using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PeekabooStarUpdateHandler : ApcPacketHandler<PeekabooStarData>
{
	private MessageContext _context;

	public PeekabooStarUpdateHandler(Contexts contexts)
	{
		_context = contexts.message;
	}

	public override int MethodId()
	{
		return 73;
	}

	public override void Handle(PeekabooStarData data)
	{
		_context.peekabooMessageData.starsCountChanged = true;
		_context.peekabooMessageData.starData = data;
	}
}
