using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IPointerClickEvent : ListenerEvent, IPointerClickHandler, IEventSystemHandler
{
	public void OnPointerClick(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
