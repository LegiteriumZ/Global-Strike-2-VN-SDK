using System;
using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class SimpleFreeUI : MonoBehaviour, IComponentGroup, IUIUpdater, ICursorControl
{
	private string _key;

	private List<IFreeComponent> _components;

	private List<AutoField> _autos;

	private List<AutoField> toBeBindAutos;

	private SimpleFreeUiViewer _viewer;

	private int _totalTime;

	public bool AtBottom;

	public int Layer;

	private IShowStyle _showStyle;

	private int _currentTime;

	public float OrignalX;

	public float OrignalY;

	public int OrignalWidth;

	public int OrignalHeight;

	private IUiObject _uiObject;

	private int _screenWidth;

	private int _screenHeight;

	public Action<bool> SetVisiable;

	public string ScrollViewKey;

	public int ScrollViewContentIndex;

	private bool _visible;

	private FreeSmallMapComponent _smallMapComponent;

	public int OriginSizeWidth = Screen.width;

	public int OriginSizeHeighht = Screen.height;

	private static readonly List<int> LstBuffer = new List<int>(8);

	public IUiObject UiObject => _uiObject;

	public string Key
	{
		get
		{
			return _key;
		}
		set
		{
			_key = value;
		}
	}

	public bool Visible
	{
		get
		{
			return base.gameObject.IsActiveSelf();
		}
		set
		{
			if (_visible != value && SetVisiable != null)
			{
				SetVisiable(value);
			}
			_visible = value;
			base.gameObject.SetObjectActive(value);
		}
	}

	public float X
	{
		get
		{
			return _uiObject.PosX;
		}
		set
		{
			_uiObject.PosX = value;
		}
	}

	public float Y
	{
		get
		{
			return _uiObject.PosY;
		}
		set
		{
			_uiObject.PosY = value;
		}
	}

	public int Width
	{
		get
		{
			return _uiObject.Width;
		}
		set
		{
			_uiObject.Width = value;
		}
	}

	public int Height
	{
		get
		{
			return _uiObject.Height;
		}
		set
		{
			_uiObject.Height = value;
		}
	}

	public float Alpha
	{
		get
		{
			return _uiObject.Alpha;
		}
		set
		{
			_uiObject.Alpha = value;
		}
	}

	public float ScaleX
	{
		get
		{
			return _uiObject.ScaleX;
		}
		set
		{
			_uiObject.ScaleX = value;
		}
	}

	public float ScaleY
	{
		get
		{
			return _uiObject.ScaleY;
		}
		set
		{
			_uiObject.ScaleY = value;
		}
	}

	public bool ShowMouse
	{
		get
		{
			for (int i = 0; i < _components.Count; i++)
			{
				if (_components[i].ShowMouse())
				{
					return true;
				}
			}
			return false;
		}
	}

	public string EventKey => "";

	public FreeSmallMapComponent SmallMapComponent
	{
		get
		{
			if (_smallMapComponent == null)
			{
				for (int i = 0; i < FreeComponents.Count; i++)
				{
					if (FreeComponents[i].Type == 7)
					{
						_smallMapComponent = FreeComponents[i] as FreeSmallMapComponent;
						break;
					}
				}
			}
			return _smallMapComponent;
		}
	}

	public List<IFreeComponent> FreeComponents => _components;

	public int ComponentCount => _components.Count;

	public bool IsDisabled { get; set; }

	public int CloseDelay { get; set; }

	private void Awake()
	{
		_components = new List<IFreeComponent>();
		_autos = new List<AutoField>();
		toBeBindAutos = new List<AutoField>();
		Contexts.sharedInstance.userCommand.input.CursorControls.Add(this);
		_uiObject = new UnityUiObject(base.gameObject);
		_screenWidth = Screen.width;
		_screenHeight = Screen.height;
	}

	public void AddUpdater()
	{
		IsDisabled = false;
		MonoBehaviourSingleton<SimpleUIUpdater>.Instance.AddUpdaterDic(this, Key);
		MonoBehaviourSingleton<SimpleUIUpdater>.Instance.AddSimpleDic(this, Key);
	}

	public void CheckSetScrollView(string keyWord, int index)
	{
		ScrollViewKey = keyWord;
		ScrollViewContentIndex = index;
	}

	public void SetFreeLink(string link)
	{
	}

	private void OnDestroy()
	{
		ResetData(isDestroy: true);
	}

	public void ResetData(bool isDestroy)
	{
		ScrollViewKey = null;
		ResetEvent();
		for (int i = 0; i < _components.Count; i++)
		{
			IFreeComponent freeComponent = _components[i];
			if (freeComponent.IsIKeyboardResponder)
			{
				IKeyboardResponder item = freeComponent as IKeyboardResponder;
				Contexts.sharedInstance.userCommand.input.KeyboardResponders.Remove(item);
			}
			if (freeComponent is FreeCheckBoxComponent)
			{
				List<IFreeComponent> buttonList = (freeComponent as FreeCheckBoxComponent).GetButtonList();
				for (int j = 0; j < buttonList.Count; j++)
				{
					IKeyboardResponder item2 = buttonList[j] as IKeyboardResponder;
					Contexts.sharedInstance.userCommand.input.KeyboardResponders.Remove(item2);
				}
			}
			freeComponent.Destroy();
		}
		if (MonoBehaviourSingleton<SimpleUIUpdater>.HasInstance)
		{
			MonoBehaviourSingleton<SimpleUIUpdater>.Instance.RemoveUpdaterDic(this, Key);
			MonoBehaviourSingleton<SimpleUIUpdater>.Instance.RemoveSimpleDic(this, Key);
		}
		if (!(GameController.Instance == null))
		{
			Contexts.sharedInstance.userCommand.input.CursorControls.Remove(this);
		}
	}

	public void ResetEvent()
	{
		for (int i = 0; i < _components.Count; i++)
		{
			_components[i].FreeUIEvent.ResetEvent();
		}
	}

	public FreeUIEvent GetFreeUiEvent()
	{
		for (int i = 0; i < _components.Count; i++)
		{
			IFreeComponent freeComponent = _components[i];
			if (freeComponent.FreeUIEvent.HasEvent())
			{
				return freeComponent.FreeUIEvent;
			}
		}
		return null;
	}

	public void SetChild(IFreeComponent component, string parentKey = "")
	{
		GameObject obj = component.ToUI().GameObject;
		Vector3 localPosition = obj.transform.localPosition;
		obj.transform.SetParent(base.transform);
		obj.transform.localPosition = localPosition;
		component.SetRelation(this);
		component.SetParentKey(parentKey);
	}

	public void SetParentKey(string width, string height)
	{
		int num = Screen.width;
		int num2 = Screen.height;
		if (!string.IsNullOrEmpty(width) && !string.IsNullOrEmpty(height))
		{
			num = int.Parse(width);
			num2 = int.Parse(height);
			_uiObject.Anchor = new Vector2(0f, 1f);
			_uiObject.GameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(num, num2);
		}
		OriginSizeWidth = num;
		OriginSizeHeighht = num2;
	}

	public void AddComponent(IFreeComponent component)
	{
		if (!_components.Contains(component))
		{
			_components.Add(component);
		}
	}

	public static void SetValue(string key, SimpleProto simpleProto, List<IFreeComponent> components)
	{
		LstBuffer.Clear();
		for (int i = 0; i < 8; i++)
		{
			LstBuffer.Add(0);
		}
		for (int j = 1; j < simpleProto.Ks.Count; j++)
		{
			if (simpleProto.Ks[j] <= components.Count)
			{
				IFreeComponent freeComponent = components[simpleProto.Ks[j] - 1];
				int valueType = freeComponent.ValueType;
				SetValueAdapter.SetValueData data = SetValueAdapter.Instance.GetData();
				SetValueAdapter.SetValueData data2 = SetValueAdapter.Instance.GetData();
				switch (valueType)
				{
				case 1:
					data.SetValueInt = simpleProto.Ins[j - 1];
					data2.SetValueInt = simpleProto.Ins[components.Count + LstBuffer[valueType]];
					freeComponent.SetValue(data, data2);
					break;
				case 2:
					data.SetValueInt = simpleProto.Ins[j - 1];
					data2.SetValueStr = simpleProto.Ss[LstBuffer[valueType] + 1];
					freeComponent.SetValue(data, data2);
					break;
				case 3:
					data.SetValueInt = simpleProto.Ins[j - 1];
					data2.SetValueBool = (simpleProto.Bs[LstBuffer[valueType]] ? 1 : (-1));
					freeComponent.SetValue(data, data2);
					break;
				case 4:
					data.SetValueInt = simpleProto.Ins[j - 1];
					data2.SetValueFloat = simpleProto.Fs[LstBuffer[valueType]];
					freeComponent.SetValue(data, data2);
					break;
				case 5:
					data.SetValueInt = simpleProto.Ins[j - 1];
					data2.SetValueDouble = simpleProto.Ds[LstBuffer[valueType]];
					freeComponent.SetValue(data, data2);
					break;
				case 6:
					data.SetValueInt = simpleProto.Ins[j - 1];
					data2.SetValueLong = simpleProto.Ls[LstBuffer[valueType]];
					freeComponent.SetValue(data, data2);
					break;
				case 7:
					data.SetValueStr = simpleProto.Ss[LstBuffer[valueType] + 1];
					data2.SetValueProto = simpleProto;
					freeComponent.SetValue(data, data2);
					LstBuffer[2] = LstBuffer[2] + 1;
					break;
				}
				LstBuffer[valueType] += 1;
				SetValueAdapter.Instance.Release(data, data2);
			}
		}
	}

	public void OnFrame(IUIDataManager uiDataManager, int frameTime)
	{
		SimpleFreeUIData sFreeUIata = uiDataManager.SFreeUIata;
		if (sFreeUIata.IsChanged(52, Key))
		{
			List<SimpleProto> data = sFreeUIata.GetData(52, Key);
			for (int i = 0; i < data.Count; i++)
			{
				SetValue(Key, data[i], _components);
			}
			sFreeUIata.ResetChange(52, Key);
		}
		if (sFreeUIata.IsChanged(51, Key))
		{
			List<SimpleProto> data2 = sFreeUIata.GetData(51, Key);
			for (int j = 0; j < data2.Count; j++)
			{
				_showStyle = FreeUIUtil.GetInstance().GetShowStyle(data2[j]);
				_totalTime = data2[j].Ks[2];
			}
			_currentTime = 0;
			sFreeUIata.ResetChange(51, Key);
		}
		for (int k = 0; k < _components.Count; k++)
		{
			_components[k].Frame(uiDataManager, frameTime, this);
		}
		_currentTime += frameTime;
		if (_showStyle != null)
		{
			_showStyle.Show(this, _currentTime, _totalTime);
		}
		if (_screenWidth != Screen.width || _screenHeight != Screen.height)
		{
			for (int l = 0; l < _components.Count; l++)
			{
				_components[l].RefreshPosition();
			}
			_screenWidth = Screen.width;
			_screenHeight = Screen.height;
		}
	}

	public void OnFrameEnd()
	{
		foreach (AutoField toBeBindAuto in toBeBindAutos)
		{
			if (toBeBindAuto.field == "x")
			{
				toBeBindAuto.auto.SetValue(Convert.ToString(X));
			}
			if (toBeBindAuto.field == "y")
			{
				toBeBindAuto.auto.SetValue(Convert.ToString(Y));
			}
			if (toBeBindAuto.field == "width")
			{
				toBeBindAuto.auto.SetValue(Convert.ToString(Width));
			}
			if (toBeBindAuto.field == "height")
			{
				toBeBindAuto.auto.SetValue(Convert.ToString(Height));
			}
		}
	}

	public IFreeComponent GetComponent(int index)
	{
		if (index < _components.Count && index >= 0)
		{
			return _components[index];
		}
		return null;
	}

	public void SetAnthor()
	{
		if (_components.Count > 0)
		{
			RectTransform component = base.transform.GetComponent<RectTransform>();
			Vector2 anchorMin = (base.transform.GetComponent<RectTransform>().anchorMax = _components[0].ToUI().Anchor);
			component.anchorMin = anchorMin;
		}
	}

	public void UIUpdate(int frameTime)
	{
		OnFrame(UIDataManager.Instance, frameTime);
	}

	public int GetCursorState()
	{
		if (!ShowMouse || !Visible)
		{
			return 0;
		}
		return 16;
	}

	public int GetForbidButtons()
	{
		if (RuleUtilty.IsUltimateChallenge())
		{
			return 0;
		}
		return 175;
	}

	public void initAutos(string config)
	{
		if (config == null)
		{
			return;
		}
		string[] array = config.Split("|||");
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i].IndexOf("=");
			if (num > 0)
			{
				InitialOneAuto(array[i].Substring(0, num), array[i].Substring(num + 1));
			}
		}
		StartAuto();
	}

	private void StartAuto()
	{
		for (int i = 0; i < _autos.Count; i++)
		{
			_autos[i].auto.Start();
		}
	}

	private void InitialOneAuto(string field, string config)
	{
		IAutoValue autoValue = AutoValue.Parse(config);
		if (autoValue != null)
		{
			InitialAutoValue(field, autoValue);
			_autos.Add(new AutoField(field, autoValue));
		}
	}

	private void InitialAutoValue(string field, IAutoValue auto)
	{
	}

	public void initToBeBindAutos(string config)
	{
		if (config == null)
		{
			return;
		}
		string[] array = config.Split("|||");
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i].IndexOf("=");
			if (num > 0)
			{
				InitialOneToBeBindAuto(array[i].Substring(0, num), array[i].Substring(num + 1));
			}
		}
	}

	private void InitialOneToBeBindAuto(string field, string config)
	{
		AutoConstValue auto = new AutoConstValue();
		InitialAutoValue(field, auto);
		toBeBindAutos.Add(new AutoField(field, auto));
	}

	public AutoField GetBindField(string targetField)
	{
		AutoField result = null;
		foreach (AutoField toBeBindAuto in toBeBindAutos)
		{
			if (toBeBindAuto.field.Equals(targetField))
			{
				result = toBeBindAuto;
				break;
			}
		}
		return result;
	}
}
