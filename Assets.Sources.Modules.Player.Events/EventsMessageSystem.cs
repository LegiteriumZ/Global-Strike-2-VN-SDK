using Assets.Sources.Framework;
using I2.Loc;
using NotifyEvent;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.Player.Events;

public class EventsMessageSystem : IResourceLoadSystem
{
	private MessageContext _messageContext;

	private PlayerContext _playerContext;

	public EventsMessageSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_messageContext = contexts.message;
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		if (_playerContext.cameraOwnerEntity == null || !_playerContext.cameraOwnerEntity.hasEvents || _playerContext.cameraOwnerEntity.events.Events == null)
		{
			return;
		}
		foreach (int @event in _playerContext.cameraOwnerEntity.events.Events)
		{
			ProcessMessage(@event);
		}
		_playerContext.cameraOwnerEntity.events.Events = null;
	}

	private void ProcessMessage(int eventId)
	{
		switch (eventId)
		{
		case 12:
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("ChangeThreeMode"), 1000);
			NotifyManager.ForceInvoke(38);
			break;
		case 13:
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("ChangeOneMode"), 1000);
			NotifyManager.ForceInvoke(38);
			break;
		}
	}
}
