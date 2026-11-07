using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.UiFramework.Libs;

[DisallowMultipleComponent]
public class Dragable : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IDragHandler, IEndDragHandler
{
	public IDragSource DragSource;

	public int Id;

	public int Slot;

	public void OnBeginDrag(PointerEventData data)
	{
		Canvas canvas = base.gameObject.GetComponent<Canvas>();
		if (null == canvas)
		{
			canvas = base.gameObject.AddComponent<Canvas>();
		}
		if (null != base.transform.parent)
		{
			GridLayoutGroup component = base.transform.parent.GetComponent<GridLayoutGroup>();
			if (null != component)
			{
				component.enabled = false;
			}
		}
		canvas.overrideSorting = true;
		canvas.sortingOrder = 200;
		if (DragSource != null)
		{
			DragSource.OnStartDrag(this);
		}
	}

	public void OnDrag(PointerEventData data)
	{
		base.gameObject.transform.position = data.position;
	}

	public void OnEndDrag(PointerEventData data)
	{
		if (null != base.transform.parent)
		{
			GridLayoutGroup component = base.transform.parent.GetComponent<GridLayoutGroup>();
			if (null != component)
			{
				component.enabled = true;
			}
		}
		Transform parent = base.gameObject.transform.parent;
		if (null != parent)
		{
			RectTransform component2 = parent.GetComponent<RectTransform>();
			if (null != component2)
			{
				LayoutRebuilder.ForceRebuildLayoutImmediate(component2);
			}
		}
		Canvas component3 = base.gameObject.GetComponent<Canvas>();
		if (null != component3)
		{
			Object.Destroy(component3);
		}
	}
}
