using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class ISelectEvent : ListenerEvent, ISelectHandler, IEventSystemHandler
{
	public void OnSelect(BaseEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
