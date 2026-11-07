using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IDeselectEvent : ListenerEvent, IDeselectHandler, IEventSystemHandler
{
	public void OnDeselect(BaseEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
