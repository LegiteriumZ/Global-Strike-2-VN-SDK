using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class IPointerEixtEvent : ListenerEvent, IPointerExitHandler, IEventSystemHandler
{
	public void OnPointerExit(PointerEventData eventData)
	{
		if (EventEnable())
		{
			Invoke(base.gameObject, eventData);
		}
	}
}
