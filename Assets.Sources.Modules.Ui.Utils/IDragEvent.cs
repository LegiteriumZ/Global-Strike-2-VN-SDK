using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IDragEvent : ListenerEvent, IDragHandler, IEventSystemHandler
{
	public void OnDrag(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
