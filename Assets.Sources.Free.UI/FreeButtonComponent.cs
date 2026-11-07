using System.Collections.Generic;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.Singleton;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Free.UI;

public class FreeButtonComponent : FreeBaseComponent, IKeyboardResponder
{
	private readonly FreeCheckUIButton _button;

	private readonly Dictionary<int, string> _keydict = new Dictionary<int, string>();

	private bool _fix = true;

	private bool _reverseX;

	private bool _reverseY;

	private KeyCode _keyCode;

	private bool _doublePressCancel;

	private string _buttonName;

	private float _beginDragX;

	private float _beginDragY;

	private float _beginSfX;

	private float _beginSfY;

	private string _dragEventKey = "";

	public FreeButtonComponent()
	{
		base.Type = 9;
		base.ValueType = 2;
		GameObject gameObject = new GameObject("FreeButton__");
		_button = gameObject.AddComponent<FreeCheckUIButton>();
		_button.Mode = (FreeCheckUIButton.CheckUiMode)7;
		_button.Listener.onPointerUp.Add(OnUp);
		_button.Listener.onMove.Add(OnMove);
		_button.Listener.onPointerExit.Add(OnExit);
		_button.Listener.onPointerUp.Add(OnPointerClickDelegate);
		_button.Listener.onPointerEnter.Add(OnPointerEnterDelegate);
		_button.Listener.onPointerExit.Add(OnPointerExitDelegate);
		_button.Listener.onDrag.Add(OnDragDelegate);
		_button.Listener.onBeginDrag.Add(OnBeginDragDelegate);
		_button.Listener.onEndDrag.Add(OnEndDragDelegate);
		_button.Interactable = false;
		UnityObject = new UnityUiObject(gameObject);
		base.IsIKeyboardResponder = true;
		_buttonName = "freeButton";
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	private void OnPointerClickDelegate(GameObject go, BaseEventData data)
	{
		if (data is PointerEventData)
		{
			PointerEventData eventData = data as PointerEventData;
			FreeUIEvent freeEvent = new FreeUIEvent();
			this.ImagePointClick(ref freeEvent, eventData, _dragEventKey);
			this.SendTcpMsg(freeEvent);
		}
	}

	private void OnPointerEnterDelegate(GameObject go, BaseEventData data)
	{
		if (data is PointerEventData)
		{
			FreeUIEvent freeEvent = new FreeUIEvent();
			this.ImagePointerEnter(ref freeEvent, _dragEventKey);
			this.SendTcpMsg(freeEvent);
		}
	}

	private void OnPointerExitDelegate(GameObject go, BaseEventData data)
	{
		if (data is PointerEventData)
		{
			FreeUIEvent freeEvent = new FreeUIEvent();
			this.ImagePointerExit(ref freeEvent, _dragEventKey);
			this.SendTcpMsg(freeEvent);
		}
	}

	private void OnBeginDragDelegate(GameObject go, BaseEventData data)
	{
		if (data is PointerEventData)
		{
			PointerEventData eventData = data as PointerEventData;
			this.ImageBeginDrag(eventData, ref _beginDragX, ref _beginDragY, ref _beginSfX, ref _beginSfY);
		}
	}

	private void OnDragDelegate(GameObject go, BaseEventData data)
	{
		if (data is PointerEventData)
		{
			PointerEventData eventData = data as PointerEventData;
			this.ImageDraging(eventData, _beginDragX, _beginDragY, _beginSfX, _beginSfY, _fix);
		}
	}

	private void OnEndDragDelegate(GameObject go, BaseEventData data)
	{
		if (data is PointerEventData)
		{
			PointerEventData eventData = data as PointerEventData;
			FreeUIEvent freeEvent = new FreeUIEvent();
			this.ImageEndDrag(eventData, _beginDragX, _beginDragY, _beginSfX, _beginSfY, _fix, ref freeEvent, _dragEventKey, Autos);
			this.SendTcpMsg(freeEvent);
		}
	}

	public FreeCheckUIButton GetButton()
	{
		return _button;
	}

	protected override void SetPureValue(string v)
	{
		int value = 0;
		StringCache.TryGetInt(v, out value);
		switch (value)
		{
		case 0:
			_button.Interactable = true;
			_button.Select = true;
			break;
		case 1:
			_button.Select = false;
			break;
		case 2:
			_button.Interactable = true;
			break;
		case 3:
			_button.Interactable = false;
			_button.Select = false;
			break;
		}
	}

	private void OnExit(GameObject go, BaseEventData data)
	{
		if (!FreeEvent.HasEvent() && _keydict.TryGetValue(0, out var value))
		{
			FreeEvent.Event = 6;
			FreeEvent.Key.Key = FreeEvent.Event;
			FreeEvent.Key.Ss.Add(value);
		}
	}

	private void OnMove(GameObject go, BaseEventData data)
	{
		if (FreeEvent.HasEvent())
		{
			return;
		}
		string value;
		if (_button.Interactable)
		{
			if (_keydict.TryGetValue(1, out value) && !FreeBaseComponent.IsNullString(value))
			{
				FreeEvent.Event = 6;
				FreeEvent.Key.Key = FreeEvent.Event;
				FreeEvent.Key.Ss.Add(value);
			}
		}
		else if (_keydict.TryGetValue(5, out value) && !FreeBaseComponent.IsNullString(value))
		{
			FreeEvent.Event = 6;
			FreeEvent.Key.Key = FreeEvent.Event;
			FreeEvent.Key.Ss.Add(value);
		}
	}

	private void OnUp(GameObject go, BaseEventData data)
	{
		if (!FreeEvent.HasEvent())
		{
			OnUpListener();
		}
	}

	private void OnUpListener()
	{
		string value3;
		if (_button.Interactable)
		{
			if (_button.Select)
			{
				string value;
				if (_doublePressCancel)
				{
					_button.Select = false;
					if (_keydict.TryGetValue(0, out value) && !FreeBaseComponent.IsNullString(value))
					{
						FreeEvent.Event = 6;
						FreeEvent.Key.Key = FreeEvent.Event;
						FreeEvent.Key.Ss.Add(value);
					}
				}
				else if (_keydict.TryGetValue(2, out value) && !FreeBaseComponent.IsNullString(value))
				{
					FreeEvent.Event = 6;
					FreeEvent.Key.Key = FreeEvent.Event;
					FreeEvent.Key.Ss.Add(value);
					SendSliderValueEvent();
				}
			}
			else
			{
				_button.Select = true;
				if (_keydict.TryGetValue(2, out var value2) && !FreeBaseComponent.IsNullString(value2))
				{
					FreeEvent.Event = 6;
					FreeEvent.Key.Key = FreeEvent.Event;
					FreeEvent.Key.Ss.Add(value2);
					SendSliderValueEvent();
				}
			}
		}
		else if (_keydict.TryGetValue(4, out value3) && !FreeBaseComponent.IsNullString(value3))
		{
			FreeEvent.Event = 6;
			FreeEvent.Key.Key = FreeEvent.Event;
			FreeEvent.Key.Ss.Add(value3);
		}
	}

	private void SendSliderValueEvent()
	{
		string text = null;
		for (int i = 0; i < Autos.Count; i++)
		{
			AutoField autoField = Autos[i];
			if (autoField.field == "sliderValue")
			{
				text = autoField.auto.Frame(0).String;
			}
		}
		string value = null;
		if (!string.IsNullOrEmpty(text) && _keydict.TryGetValue(0, out value))
		{
			FreeUIEvent freeUIEvent = new FreeUIEvent();
			freeUIEvent.Event = 7;
			freeUIEvent.Key.Key = freeUIEvent.Event;
			freeUIEvent.Key.Ss.Add(value);
			freeUIEvent.Key.Ss.Add(text);
			MonoBehaviourSingleton<FreeUiManager>.Instance.SendFreeMessage(freeUIEvent.Key, this);
		}
	}

	public override void SetEventKey()
	{
		if (string.IsNullOrEmpty(DataElement.EventKey) || DataElement.EventKey.Trim() == "")
		{
			DataElement.EventKey = _buttonName + "_normal," + _buttonName + "_hover," + _buttonName + "_active," + _buttonName + "_disable," + _buttonName + "_pressWhenDisabled," + _buttonName + "_hoverWhenDisabled";
			_dragEventKey = _buttonName;
		}
		AddEvent();
	}

	public override void AddEvent()
	{
		_button.Interactable = true;
		string[] array = DataElement.EventKey.Split(',');
		for (int i = 0; i < array.Length; i++)
		{
			_keydict[i] = array[i];
		}
	}

	public override void Initial(params object[] ini)
	{
		InitialAuto(ini[1] as string);
		float w = 0f;
		float h = 0f;
		string[] array = ini[0].ToString().Split("_$$$_");
		DoPivot(array);
		bool num = DoSize(array, ref w, ref h);
		_fix = FreeDataHelperUtility.EqualStringArrayIdx(array, 7, "true");
		DataElement.NoMouse = FreeDataHelperUtility.EqualStringArrayIdx(array, 8, "true");
		string t = "";
		if (FreeDataHelperUtility.GetStringArrayIdx(array, 9, ref t))
		{
			int result = 0;
			if (int.TryParse(t, out result))
			{
				if (result == 1)
				{
					_reverseX = true;
				}
				if (result == 2)
				{
					_reverseY = true;
				}
				if (result == 3)
				{
					_reverseX = true;
					_reverseY = true;
				}
			}
		}
		int t2 = 0;
		FreeDataHelperUtility.GetStringArrayIdx(array, 11, ref t2);
		_keyCode = (KeyCode)t2;
		FreeDataHelperUtility.GetStringArrayIdx(array, 10, ref DataElement.ComponentName);
		FreeDataHelperUtility.GetStringArrayIdx(array, 12, ref _buttonName);
		_doublePressCancel = FreeDataHelperUtility.EqualStringArrayIdx(array, 13, "true");
		if (num)
		{
			if (!FreeBaseComponent.IsNullString(array[0]))
			{
				Load(FreeResourceUtility.LoadButtonSprite(LoadDefualtSpr, array[0], DataElement.ComponentName, w, h));
			}
			if (!FreeBaseComponent.IsNullString(array[1]))
			{
				Load(FreeResourceUtility.LoadButtonSprite(LoadHighLightSpr, array[1], DataElement.ComponentName, w, h));
			}
			if (!FreeBaseComponent.IsNullString(array[2]))
			{
				Load(FreeResourceUtility.LoadButtonSprite(LoadPressedSpr, array[2], DataElement.ComponentName, w, h));
			}
			if (!FreeBaseComponent.IsNullString(array[3]))
			{
				Load(FreeResourceUtility.LoadButtonSprite(LoadDisableSpr, array[3], DataElement.ComponentName, w, h));
			}
		}
		else
		{
			_button.SetObjectActive(isactive: false);
		}
	}

	public override bool ShowMouse()
	{
		return !DataElement.NoMouse;
	}

	private void LoadDefualtSpr(Sprite spr, string name)
	{
		if (_button != null)
		{
			_button.SetSprite(0, spr);
			spr.name = name;
		}
	}

	private void LoadHighLightSpr(Sprite spr, string name)
	{
		if (_button != null)
		{
			_button.SetSprite(1, spr);
			spr.name = name;
		}
	}

	private void LoadPressedSpr(Sprite spr, string name)
	{
		if (_button != null)
		{
			_button.SetSprite(2, spr);
			spr.name = name;
		}
	}

	private void LoadDisableSpr(Sprite spr, string name)
	{
		if (_button != null)
		{
			_button.SetSprite(3, spr);
			spr.name = name;
		}
	}

	private bool DoPivot(string[] info)
	{
		if (info.Length > 4)
		{
			string[] array = info[4].Split(",");
			if (array.Length == 2 && float.TryParse(array[0], out var result) && float.TryParse(array[1], out var result2))
			{
				RectTransform rectTransform = _button.transform as RectTransform;
				if (rectTransform != null)
				{
					rectTransform.pivot = new Vector2(result, result2);
				}
				return true;
			}
		}
		return false;
	}

	private bool DoSize(string[] info, ref float w, ref float h)
	{
		if (info.Length > 5)
		{
			string[] array = info[5].Split(",");
			if (array.Length == 2 && float.TryParse(array[0], out w) && float.TryParse(array[1], out h))
			{
				(_button.transform as RectTransform).sizeDelta = new Vector2(w, h);
				return true;
			}
		}
		return false;
	}

	public override void SetPos(IComponentGroup freeUI, float x, float y, int width, int height, int relative, int parent, bool isInWorld = true)
	{
		if (width == -1 && height == -1)
		{
			width = Screen.width;
			height = Screen.height;
			x = 0f;
			y = 0f;
		}
		base.SetPos(freeUI, x, y, width, height, relative, parent, isInWorld);
	}

	public override IFreeComponent Clone()
	{
		return new FreeButtonComponent();
	}

	public bool OnKeyDown(KeyCode key)
	{
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == _keyCode)
		{
			OnUpListener();
		}
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public override void Destroy()
	{
		base.Destroy();
		_button.Interactable = false;
		_button.ResetFlag();
	}
}
