using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class PeekabooMessageUpdateDataHandler : ApcPacketHandler<PeekAbooMessageData>
{
	private MessageContext _context;

	public PeekabooMessageUpdateDataHandler(Contexts context)
	{
		_context = context.message;
	}

	public override int MethodId()
	{
		return 76;
	}

	public override void Handle(PeekAbooMessageData data)
	{
		if (PeekAbooMessageType.ZHUANPANSELECTSUCCESS == data.Type)
		{
			_context.peekabooMessageData.selectOKChanged = true;
		}
		_context.peekabooMessageData.changed = true;
		_context.peekabooMessageData.humanityBackChanged = true;
		_context.peekabooMessageData.sceneItemControlStateChanged = true;
		_context.peekabooMessageData.data = data;
	}
}
