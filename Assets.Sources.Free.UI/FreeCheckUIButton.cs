using Assets.Sources.Modules.Ui.Utils;
using Res.Assets.Scripts.ExImage;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Free.UI;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(CanvasRenderer))]
[ExecuteInEditMode]
public class FreeCheckUIButton : ProtectImage
{
	public enum CheckUiMode
	{
		Image = 1,
		Button = 2,
		Select = 4,
		Single = 8
	}

	public string NowUseSpriteSign;

	[SerializeField]
	public Sprite DefaultStateSprite;

	[SerializeField]
	public Sprite DownStateSprite;

	[SerializeField]
	public Sprite HoverStateSprite;

	[SerializeField]
	public Sprite ActiveDefaultStateSprite;

	[SerializeField]
	public Sprite ActiveHoverStateSprite;

	[SerializeField]
	public Sprite ActiveDownSprite;

	[SerializeField]
	public Sprite DisabledStateSprite;

	private UILisenter _listener;

	public bool AutoNative;

	[SerializeField]
	private int _mode;

	[SerializeField]
	private bool _interactable = true;

	[SerializeField]
	private bool _select;

	[SerializeField]
	private bool _isDown;

	[SerializeField]
	private bool _mouseEnter;

	public UILisenter Listener => _listener;

	public CheckUiMode Mode
	{
		get
		{
			return (CheckUiMode)_mode;
		}
		set
		{
			if (_mode != (int)value)
			{
				_mode = (int)value;
				ShowImage();
			}
		}
	}

	public bool Interactable
	{
		get
		{
			return _interactable;
		}
		set
		{
			if (_interactable != value)
			{
				_interactable = value;
				ShowImage();
			}
		}
	}

	public bool Select
	{
		get
		{
			return _select;
		}
		set
		{
			if (_select != value)
			{
				_select = value;
				ShowImage();
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		_listener = this.TryAddComponent<UILisenter>();
		_listener.onPointerEnter.Add(Enter);
		_listener.onPointerExit.Add(Exit);
		_listener.onPointerUp.Add(Up);
		_listener.onPointerDown.Add(Down);
		base.sprite = DefaultStateSprite;
	}

	public void SetSprite(int index, Sprite loadedSprite)
	{
		switch (index)
		{
		case 0:
			DefaultStateSprite = loadedSprite;
			DownStateSprite = loadedSprite;
			break;
		case 1:
			HoverStateSprite = loadedSprite;
			break;
		case 2:
			ActiveDefaultStateSprite = loadedSprite;
			ActiveHoverStateSprite = loadedSprite;
			ActiveDownSprite = loadedSprite;
			break;
		default:
			DisabledStateSprite = loadedSprite;
			break;
		}
		ShowImage();
	}

	private void ShowImage()
	{
		if (!Interactable)
		{
			SetSprite(DisabledStateSprite, "DisabledStateSprite");
		}
		else if (Select)
		{
			if (_isDown)
			{
				SetSprite(ActiveDownSprite, "ActiveDownSprite");
			}
			else if (_mouseEnter)
			{
				SetSprite(ActiveHoverStateSprite, "ActiveDownSprite");
			}
			else
			{
				SetSprite(ActiveDefaultStateSprite, "ActiveDefaultStateSprite");
			}
		}
		else if (_isDown)
		{
			SetSprite(DownStateSprite, "DownStateSprite");
		}
		else if (_mouseEnter)
		{
			SetSprite(HoverStateSprite, "HoverStateSprite");
		}
		else
		{
			SetSprite(DefaultStateSprite, "DefaultStateSprite");
		}
	}

	private bool CanTouch()
	{
		if (raycastTarget && base.isActiveAndEnabled)
		{
			return Interactable;
		}
		return false;
	}

	private bool HasMode(CheckUiMode md)
	{
		return (Mode & md) == md;
	}

	private void Enter(GameObject go, BaseEventData data)
	{
		if (HasMode(CheckUiMode.Button) && CanTouch())
		{
			_mouseEnter = true;
			ShowImage();
		}
	}

	private void Exit(GameObject go, BaseEventData data)
	{
		if (HasMode(CheckUiMode.Button) && CanTouch())
		{
			_mouseEnter = false;
			ShowImage();
		}
	}

	private void Up(GameObject go, BaseEventData data)
	{
		if (HasMode(CheckUiMode.Button) && CanTouch())
		{
			_isDown = false;
			ShowImage();
		}
	}

	private void Down(GameObject go, BaseEventData data)
	{
		if (HasMode(CheckUiMode.Button) && CanTouch())
		{
			_isDown = true;
			ShowImage();
		}
	}

	private void SetSprite(Sprite spr, string sign)
	{
		if (spr != null)
		{
			NowUseSpriteSign = sign;
			base.sprite = spr;
			if (AutoNative)
			{
				SetNativeSize();
			}
		}
	}

	public void ResetFlag()
	{
		_mouseEnter = false;
		_isDown = false;
		Select = false;
		ShowImage();
	}

	private void Update()
	{
		if (CanTouch() && HasMode(CheckUiMode.Select) && HasMode(CheckUiMode.Single) && Select && Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			Camera camera = ((base.canvas.renderMode == RenderMode.ScreenSpaceOverlay) ? null : base.canvas.worldCamera);
			if (!RectTransformUtility.RectangleContainsScreenPoint(base.rectTransform, mousePosition, camera))
			{
				ResetFlag();
			}
			else if ((!(camera != null) || !(camera.WorldToScreenPoint(base.rectTransform.position).z > camera.farClipPlane)) && !Raycast(Input.mousePosition, camera))
			{
				ResetFlag();
			}
		}
	}
}
