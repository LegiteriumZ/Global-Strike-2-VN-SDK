using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class Bio3BioDebrisHandler : ApcPacketHandler<IntData>
{
	private readonly MessageContext _messageContext;

	public Bio3BioDebrisHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 240;
	}

	public override void Handle(IntData data)
	{
		_messageContext.bio3BioDebris.Count = data.Data;
		NotifyManager.ForceInvoke(75);
	}
}
