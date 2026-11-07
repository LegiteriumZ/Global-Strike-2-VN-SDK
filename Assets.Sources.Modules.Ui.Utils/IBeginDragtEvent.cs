using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IBeginDragtEvent : ListenerEvent, IBeginDragHandler, IEventSystemHandler
{
	public void OnBeginDrag(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
