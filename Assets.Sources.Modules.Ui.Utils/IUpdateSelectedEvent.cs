using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IUpdateSelectedEvent : ListenerEvent, IUpdateSelectedHandler, IEventSystemHandler
{
	public void OnUpdateSelected(BaseEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
