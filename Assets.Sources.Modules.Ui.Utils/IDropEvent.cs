using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IDropEvent : ListenerEvent, IDropHandler, IEventSystemHandler
{
	public void OnDrop(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
