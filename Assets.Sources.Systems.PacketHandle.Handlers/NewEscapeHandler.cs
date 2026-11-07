using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class NewEscapeHandler : ApcPacketHandler<NewEscapeMessageData>
{
	private GameRuleContext _gameRuleContext;

	public NewEscapeHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 344;
	}

	public override void Handle(NewEscapeMessageData data)
	{
		if (data.Type == NewEscapeMessageType.WAITINGFINALESCAPE || data.Type == NewEscapeMessageType.WARNINGFINALESCAPE)
		{
			Contexts.sharedInstance.message.newEscapeTipsShow.TipsEvent.Add(new NewEscapeMessageData
			{
				Type = NewEscapeMessageType.WAITINGTRIGGER,
				CustomId = 11,
				Time = data.Time
			});
		}
		if (data.Type == NewEscapeMessageType.WARNINGCHASE || data.Type == NewEscapeMessageType.STARTCHASE || data.Type == NewEscapeMessageType.WAITINGFINALESCAPE || data.Type == NewEscapeMessageType.WARNINGFINALESCAPE || data.Type == NewEscapeMessageType.OPENDOOR || data.Type == NewEscapeMessageType.WAITINGCHASE || data.Type == NewEscapeMessageType.WARNINGFIELDINFECTION || data.Type == NewEscapeMessageType.WARNINGFIELDINFECTIONCANCEL || data.Type == NewEscapeMessageType.WAITINGOPENDOOR || data.Type == NewEscapeMessageType.WAITINGTRIGGER || data.Type == NewEscapeMessageType.PLAYERACTIVEDISTRIBUTION || data.Type == NewEscapeMessageType.WAITINGPLAYER)
		{
			Contexts.sharedInstance.message.newEscapeTipsShow.TipsEvent.Add(data);
			NotifyManager.ForceInvoke(117);
		}
	}
}
