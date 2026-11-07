using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Modules.Ui.Utils;

public class UILisenter : MonoBehaviour
{
	private ListenerEvent _onPointerEnter;

	private ListenerEvent _onPointerExit;

	private ListenerEvent _onDrag;

	private ListenerEvent _onDrop;

	private ListenerEvent _onPointerDown;

	private ListenerEvent _onPointerUp;

	private ListenerEvent _onPointerClick;

	private ListenerEvent _onSelect;

	private ListenerEvent _onDeselect;

	private ListenerEvent _onScroll;

	private ListenerEvent _onMove;

	private ListenerEvent _onUpdateSelected;

	private ListenerEvent _onBeginDrag;

	private ListenerEvent _onEndDrag;

	private ListenerEvent _onSubmit;

	private ListenerEvent _onCancel;

	public ListenerEvent onPointerEnter
	{
		get
		{
			if (_onPointerEnter == null)
			{
				_onPointerEnter = this.TryAddComponent<IPointerEnterEvent>();
			}
			return _onPointerEnter;
		}
	}

	public ListenerEvent onPointerExit
	{
		get
		{
			if (_onPointerExit == null)
			{
				_onPointerExit = this.TryAddComponent<IPointerEixtEvent>();
			}
			return _onPointerExit;
		}
	}

	public ListenerEvent onDrag
	{
		get
		{
			if (_onDrag == null)
			{
				_onDrag = this.TryAddComponent<IDragEvent>();
			}
			return _onDrag;
		}
	}

	public ListenerEvent onDrop
	{
		get
		{
			if (_onDrop == null)
			{
				_onDrop = this.TryAddComponent<IDropEvent>();
			}
			return _onDrop;
		}
	}

	public ListenerEvent onPointerDown
	{
		get
		{
			if (_onPointerDown == null)
			{
				_onPointerDown = this.TryAddComponent<IPointerDownEvent>();
			}
			return _onPointerDown;
		}
	}

	public ListenerEvent onPointerUp
	{
		get
		{
			if (_onPointerUp == null)
			{
				_onPointerUp = this.TryAddComponent<IPointerUpEvent>();
			}
			return _onPointerUp;
		}
	}

	public ListenerEvent onPointerClick
	{
		get
		{
			if (_onPointerClick == null)
			{
				_onPointerClick = this.TryAddComponent<IPointerClickEvent>();
			}
			return _onPointerClick;
		}
	}

	public ListenerEvent onSelect
	{
		get
		{
			if (_onSelect == null)
			{
				_onSelect = this.TryAddComponent<ISelectEvent>();
			}
			return _onSelect;
		}
	}

	public ListenerEvent onDeselect
	{
		get
		{
			if (_onDeselect == null)
			{
				_onDeselect = this.TryAddComponent<IDeselectEvent>();
			}
			return _onDeselect;
		}
	}

	public ListenerEvent onScroll
	{
		get
		{
			if (_onScroll == null)
			{
				_onScroll = this.TryAddComponent<IScrollEvent>();
			}
			return _onScroll;
		}
	}

	public ListenerEvent onMove
	{
		get
		{
			if (_onMove == null)
			{
				_onMove = this.TryAddComponent<IMoveEvent>();
			}
			return _onMove;
		}
	}

	public ListenerEvent onUpdateSelected
	{
		get
		{
			if (_onUpdateSelected == null)
			{
				_onUpdateSelected = this.TryAddComponent<IUpdateSelectedEvent>();
			}
			return _onUpdateSelected;
		}
	}

	public ListenerEvent onBeginDrag
	{
		get
		{
			if (_onBeginDrag == null)
			{
				_onBeginDrag = this.TryAddComponent<IBeginDragtEvent>();
			}
			return _onBeginDrag;
		}
	}

	public ListenerEvent onEndDrag
	{
		get
		{
			if (_onEndDrag == null)
			{
				_onEndDrag = this.TryAddComponent<IEndDragEvent>();
			}
			return _onEndDrag;
		}
	}

	public ListenerEvent onSubmit
	{
		get
		{
			if (_onSubmit == null)
			{
				_onSubmit = this.TryAddComponent<ISubmitEvent>();
			}
			return _onSubmit;
		}
	}

	public ListenerEvent onCancel
	{
		get
		{
			if (_onCancel == null)
			{
				_onCancel = this.TryAddComponent<ICancelEvent>();
			}
			return _onCancel;
		}
	}
}
