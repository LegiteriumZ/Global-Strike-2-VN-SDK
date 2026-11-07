using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.UiFramework.Libs;

public class DropZone : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IDropHandler, IPointerExitHandler
{
	public IDragTarget DragTarget;

	public int Id;

	public int Slot;

	public void OnPointerExit(PointerEventData data)
	{
		_ = null == data.pointerDrag;
	}

	public void OnPointerEnter(PointerEventData data)
	{
		if (!(null == data.pointerDrag))
		{
			Dragable component = data.pointerDrag.GetComponent<Dragable>();
			if (!(null == component) && DragTarget != null)
			{
				DragTarget.OnDragHover(this, component);
			}
		}
	}

	public void OnDrop(PointerEventData data)
	{
		if (null == data.pointerDrag)
		{
			return;
		}
		Dragable component = data.pointerDrag.GetComponent<Dragable>();
		if (null == component)
		{
			return;
		}
		Canvas component2 = component.GetComponent<Canvas>();
		if (null != component2)
		{
			Object.Destroy(component2);
		}
		if (null != component.transform.parent)
		{
			GridLayoutGroup component3 = component.transform.parent.GetComponent<GridLayoutGroup>();
			if (null != component3)
			{
				component3.enabled = true;
			}
		}
		if (DragTarget != null)
		{
			DragTarget.OnEndDrag(this, component);
		}
	}
}
