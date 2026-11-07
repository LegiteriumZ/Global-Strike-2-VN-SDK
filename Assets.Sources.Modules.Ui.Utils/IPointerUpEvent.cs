using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IPointerUpEvent : ListenerEvent, IPointerUpHandler, IEventSystemHandler
{
	public void OnPointerUp(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
