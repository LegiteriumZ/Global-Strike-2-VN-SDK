using System.Collections.Generic;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BuffDataHandler : ApcPacketHandler<BuffData>
{
	private readonly MessageContext _messageContext;

	public BuffDataHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 273;
	}

	public override void Handle(BuffData data)
	{
		_messageContext.sceneBuffMessageData.messageText = data.Data;
		_messageContext.sceneBuffMessageData.messageIndex = data.Index;
		_messageContext.sceneBuffMessageData.Args = new List<string>(data.Args);
		if (data.Index != 0)
		{
			NotifyManager.ForceInvoke(85);
		}
	}
}
