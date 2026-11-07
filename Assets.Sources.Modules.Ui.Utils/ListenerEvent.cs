using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Modules.Ui.Utils;

public class ListenerEvent : MonoBehaviour
{
	public delegate void TriggerDelegate(GameObject go, BaseEventData data);

	private TriggerDelegate triggerEvent;

	protected bool EventEnable()
	{
		if (!base.isActiveAndEnabled)
		{
			return false;
		}
		return true;
	}

	public void Add(TriggerDelegate d)
	{
		triggerEvent = (TriggerDelegate)Delegate.Combine(triggerEvent, d);
	}

	public void Remove(TriggerDelegate d)
	{
		triggerEvent = (TriggerDelegate)Delegate.Remove(triggerEvent, d);
	}

	public void Clear()
	{
		triggerEvent = null;
	}

	public void Invoke(GameObject go, BaseEventData data)
	{
		if (triggerEvent != null)
		{
			triggerEvent(go, data);
		}
	}
}
