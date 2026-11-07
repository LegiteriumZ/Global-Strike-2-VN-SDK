using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class ISubmitEvent : ListenerEvent, ISubmitHandler, IEventSystemHandler
{
	public void OnSubmit(BaseEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
