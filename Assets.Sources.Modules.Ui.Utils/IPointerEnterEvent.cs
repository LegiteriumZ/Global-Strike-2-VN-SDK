using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IPointerEnterEvent : ListenerEvent, IPointerEnterHandler, IEventSystemHandler
{
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
