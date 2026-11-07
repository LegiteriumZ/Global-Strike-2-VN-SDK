using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class MechWarriorMessageHandler : ApcPacketHandler<MechWarriorMessageData>
{
	private MessageContext _messageContext;

	public MechWarriorMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 95;
	}

	public override void Handle(MechWarriorMessageData data)
	{
		if (data.WaitingPlayerNumSpecified)
		{
			_messageContext.mechwarriorMessageData.WaitPlayerCount = data.WaitingPlayerNum;
		}
		if (data.Type == MechWarriorMessageType.ULTIMATETIMESTART)
		{
			_messageContext.mechwarriorMessageData.UltimateTime = data.Time;
			_messageContext.mechwarriorMessageData.IsUltimateTime = true;
			NotifyManager.ForceInvoke(64);
		}
		else if (data.Type == MechWarriorMessageType.MECHLEVELUP)
		{
			_messageContext.mechwarriorMessageData.MechLvup = true;
			NotifyManager.ForceInvoke(65);
		}
		_messageContext.mechwarriorMessageData.MessageType = (int)data.Type;
		NotifyManager.ForceInvoke(21);
	}
}
