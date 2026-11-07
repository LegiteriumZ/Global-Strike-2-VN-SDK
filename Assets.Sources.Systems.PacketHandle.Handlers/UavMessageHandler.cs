using I2.Loc;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class UavMessageHandler : ApcPacketHandler<UavMessageData>
{
	private MessageContext _messageContext;

	public UavMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 122;
	}

	public override void Handle(UavMessageData data)
	{
		if (data.Type != 0)
		{
			switch (data.Type)
			{
			case UavMessageType.BEATTACK:
				_messageContext.gameTipsData.SetMessage(-1500);
				NotifyManager.ForceInvoke(66);
				NotifyManager.ForceInvoke(43);
				break;
			case UavMessageType.NOTDROP:
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BlackcrowNotDrop"));
				NotifyManager.ForceInvoke(38);
				break;
			case UavMessageType.TOOFAR:
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BlackcrowTooFar"));
				NotifyManager.ForceInvoke(38);
				break;
			case UavMessageType.DESTROY:
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BlackcrowDead"));
				NotifyManager.ForceInvoke(38);
				break;
			case UavMessageType.NOTFLY:
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("BlackcrowNotfly"));
				NotifyManager.ForceInvoke(38);
				break;
			}
		}
	}
}
