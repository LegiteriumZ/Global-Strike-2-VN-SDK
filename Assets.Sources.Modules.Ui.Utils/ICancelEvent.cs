using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class ICancelEvent : ListenerEvent, ICancelHandler, IEventSystemHandler
{
	public void OnCancel(BaseEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
