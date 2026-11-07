using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IEndDragEvent : ListenerEvent, IEndDragHandler, IEventSystemHandler
{
	public void OnEndDrag(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
