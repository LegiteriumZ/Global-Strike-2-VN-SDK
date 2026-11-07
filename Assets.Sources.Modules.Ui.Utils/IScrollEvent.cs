using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IScrollEvent : ListenerEvent, IScrollHandler, IEventSystemHandler
{
	public void OnScroll(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
