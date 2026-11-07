using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IPointerDownEvent : ListenerEvent, IPointerDownHandler, IEventSystemHandler
{
	public void OnPointerDown(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
