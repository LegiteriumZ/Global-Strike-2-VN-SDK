using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PeekabooZhuanPantHandler : ApcPacketHandler<PeekabooChooseData>
{
	private MessageContext _msgContext;

	public PeekabooZhuanPantHandler(Contexts contexts)
	{
		_msgContext = contexts.message;
	}

	public override int MethodId()
	{
		return 79;
	}

	public override void Handle(PeekabooChooseData data)
	{
		_msgContext.peekabooMessageData.chooseChanged = true;
		_msgContext.peekabooMessageData.selectOK = false;
		_msgContext.peekabooMessageData.chooseData = data;
	}
}
