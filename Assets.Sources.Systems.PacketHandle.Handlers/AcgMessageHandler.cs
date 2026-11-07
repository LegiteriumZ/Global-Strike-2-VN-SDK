using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Message.Common;
using Assets.Sources.Utils.Timer;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class AcgMessageHandler : ApcPacketHandler<AcgMessage>
{
	private MessageContext _messageContext;

	private TimeContext _timeContext;

	private ISSJJTimer _timer;

	public AcgMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_timeContext = contexts.time;
	}

	public override int MethodId()
	{
		return 1106;
	}

	public override void Handle(AcgMessage data)
	{
		if (!data.CanShow)
		{
			SSJJTimerUtils.RemoveTimer(_timeContext.commonTimer.CommonTimer, "EV" + data.Type);
		}
		else
		{
			if (_messageContext.gameMessageData.AcgMessageQueue.Count == 4)
			{
				SSJJTimerUtils.RemoveTimer(_timeContext.commonTimer.CommonTimer, _messageContext.gameMessageData.AcgMessageQueue.Dequeue().timerId);
			}
			if (_timeContext.commonTimer.CommonTimer.TryGetValue("EV" + data.Type, out _timer))
			{
				_timer.ResetTimer();
			}
			else
			{
				_messageContext.gameMessageData.AcgMessageQueue.Enqueue(new GameMessageDataComponent.AcgMessageData(data.Type, data.Name, "EV" + data.Type));
				SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "EV" + data.Type, new SSJJTimer(data.Time));
			}
		}
		NotifyManager.ForceInvoke(111);
	}
}
