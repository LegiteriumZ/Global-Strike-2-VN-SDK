using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IMoveEvent : ListenerEvent, IMoveHandler, IEventSystemHandler
{
	public void OnMove(AxisEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
