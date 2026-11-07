using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.Logger;
using SSJJBase.String;
using SSJJBase.Thread;
using Sharpen;
using UnityEngine;
using UnityEngine.UI;
using share;

namespace Assets.Sources.Free.UI;

public class FreeBaseComponent : BaseAutoFields, IFreeComponent
{
	public const int TYPE_IMAGE = 1;

	public const int TYPE_TEXT = 2;

	public const int TYPE_NUMBER = 3;

	public const int TYPE_LIST = 4;

	public const int TYPE_RADER = 5;

	public const int TYPE_EXP = 6;

	public const int TYPE_SMALLMAP = 7;

	public const int TYPE_R_IMAGE = 8;

	public const int TYPE_BUTTON = 9;

	public const int TYPE_CHECKBOX = 10;

	public const int TYPE_DIRECTION = 11;

	public const int TYPE_SCROllVIEW = 12;

	public const int TYPE_SLIDER = 13;

	protected IUiObject UnityObject;

	protected IComponentGroup Group;

	protected bool ShowZero;

	public FreeBaseDataElement DataElement;

	public List<AutoField> ToBeBindAutoFields;

	public FreeImageComponent.ImageComponentData ComponentData;

	public Dictionary<string, AssetInfo> AssetInfoDirs;

	protected FreeUIEvent FreeEvent;

	protected static LoggerAdapter Logger;

	public bool HasSetPos;

	public string ParentKey;

	private int _type;

	private int _valueType;

	public bool IsIKeyboardResponder { get; set; }

	public float OriginalX => DataElement.X;

	public float OriginalY => DataElement.Y;

	public bool IsNoMouse => DataElement.NoMouse;

	public bool CanDrag
	{
		get
		{
			return DataElement.CanDrag;
		}
		set
		{
			DataElement.CanDrag = value;
		}
	}

	public string EventKey
	{
		get
		{
			return DataElement.EventKey;
		}
		set
		{
			if (!IsNullString(value))
			{
				DataElement.EventKey = value;
				AddEvent();
			}
			SetEventKey();
		}
	}

	public FreeUIEvent FreeUIEvent
	{
		get
		{
			if (FreeEvent == null)
			{
				FreeEvent = new FreeUIEvent();
			}
			return FreeEvent;
		}
	}

	public int Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	public int ValueType
	{
		get
		{
			return _valueType;
		}
		set
		{
			_valueType = value;
		}
	}

	public string Key
	{
		get
		{
			return DataElement.Key;
		}
		set
		{
			DataElement.Key = value;
		}
	}

	protected IAutoValue ValueAuto => GetAuto("v");

	public SimpleFreeUI FreeUi { get; set; }

	public FreeBaseComponent()
	{
		ToBeBindAutoFields = new List<AutoField>();
		FreeEvent = new FreeUIEvent();
		if (Logger == null)
		{
			Logger = new LoggerAdapter("FreeUI");
		}
		DataElement.Init();
	}

	public AssetInfo GetAssetInfoGenImageUrl(string imageUrl)
	{
		if (!AssetInfoDirs.TryGetValue(imageUrl, out var value))
		{
			value = FreeResourceUtility.GetUiAssetPath(imageUrl, DataElement.ComponentName);
			AssetInfoDirs[imageUrl] = value;
		}
		return value;
	}

	public virtual void Destroy()
	{
		DataElement.ResetData();
		UnityObject.ResetData();
		ToBeBindAutoFields = new AList<AutoField>();
		ComponentData = new FreeImageComponent.ImageComponentData();
		AssetInfoDirs = new Dictionary<string, AssetInfo>();
	}

	public virtual void AddEvent()
	{
	}

	public virtual void SetEventKey()
	{
	}

	public virtual IFreeComponent Clone()
	{
		return new FreeBaseComponent();
	}

	public virtual IUiObject ToUI()
	{
		return UnityObject;
	}

	public virtual void Initial(params object[] init)
	{
	}

	protected virtual void SetPureValue(string value)
	{
	}

	protected virtual void SetPosSpecailLogic()
	{
	}

	public void SetParentKey(string parentKey)
	{
		ParentKey = parentKey;
	}

	public virtual void SetPos(IComponentGroup freeUI, float x, float y, int width, int height, int relative, int parent, bool isInWorld = true)
	{
		if (!CheckCanSetPos())
		{
			return;
		}
		HasSetPos = true;
		DataElement.IsInWorld = isInWorld;
		DataElement.Relative = relative;
		DataElement.Parent = parent;
		Group = freeUI;
		DataElement.X = x;
		DataElement.Y = y;
		DataElement.Width = width;
		DataElement.Height = height;
		IUiObject uiObject = ToUI();
		uiObject.Width = width;
		uiObject.Height = height;
		DataElement.StartX = 0f;
		DataElement.StartY = 0f;
		int num = 0;
		int num2 = 0;
		if (parent <= 0)
		{
			if (FreeUi != null)
			{
				num = FreeUi.OriginSizeWidth;
				num2 = FreeUi.OriginSizeHeighht;
			}
			else
			{
				num = Screen.width;
				num2 = Screen.height;
			}
		}
		else
		{
			IFreeComponent component = freeUI.GetComponent(parent - 1);
			num = component.ToUI().Width;
			num2 = component.ToUI().Height;
			DataElement.StartX = component.ToUI().PosX;
			DataElement.StartY = component.ToUI().PosY;
		}
		if (DataElement.OriginParent == null)
		{
			DataElement.OriginParent = uiObject.Parent;
		}
		SetXy(uiObject, relative, DataElement.StartX, DataElement.StartY, num, num2, x, y, parent <= 0 && isInWorld);
		if (freeUI is FreeListComponent)
		{
			uiObject.PosY = y;
		}
		if (parent > 0 && isInWorld)
		{
			IFreeComponent component2 = freeUI.GetComponent(parent - 1);
			DataElement.NewParent = component2.ToUI().GameObject.transform;
		}
	}

	private void ChangePos(IUiObject control, bool isInWorldPos, int width, int height)
	{
		if (isInWorldPos)
		{
			control.PosX -= (float)width / 2f;
			control.PosY -= (float)height / 2f;
		}
	}

	public void ChangeAnchor(IUiObject control, Vector2 vector2, int width, int height)
	{
		control.PosX += (0f - vector2.x + control.Anchor.x) * (float)width;
		control.PosY += (vector2.y - control.Anchor.y) * (float)height;
		control.Anchor = vector2;
	}

	public void RefreshPosition()
	{
		SetPos(Group, DataElement.X, DataElement.Y, DataElement.Width, DataElement.Height, DataElement.Relative, DataElement.Parent);
	}

	public virtual void SetValue(SetValueAdapter.SetValueData a, SetValueAdapter.SetValueData b)
	{
		int setValueInt = a.SetValueInt;
		int num = setValueInt / 100;
		int index = setValueInt % 100;
		if (num == 2 || num == 1)
		{
			StartAuto(index);
		}
		else
		{
			StopAuto(index);
		}
		if (num == 2 || num == 4 || num == 0)
		{
			string setValueStr = b.SetValueStr;
			if (IsNullString(setValueStr))
			{
				ToUI().ActiveVisible = false;
			}
			else
			{
				ToUI().ActiveVisible = true;
			}
			if (num == 2 || num == 4)
			{
				SetAutoValue(setValueStr, index);
			}
			if (num == 0)
			{
				SetPureValue(setValueStr);
			}
		}
	}

	private void SetXy(IUiObject control, int relative, float startX, float startY, int width, int height, float x, float y, bool isInWorldPos)
	{
		control.Anchor = new Vector2(0f, 1f);
		DataElement.NewAnchor = new Vector2(0f, 1f);
		switch (relative)
		{
		default:
			return;
		case 0:
			control.PosX = startX + x;
			control.PosY = startY + y;
			DataElement.NewAnchor = Vector2.up;
			break;
		case 1:
			control.PosX = startX + (float)width - x;
			control.PosY = startY + y;
			DataElement.NewAnchor = Vector2.one;
			break;
		case 2:
			control.PosX = startX + x;
			control.PosY = startY + (float)height - y;
			DataElement.NewAnchor = Vector2.zero;
			break;
		case 3:
			control.PosX = startX + (float)width - x;
			control.PosY = startY + (float)height - y;
			DataElement.NewAnchor = Vector2.right;
			break;
		case 4:
			control.PosX = startX + (float)width / 2f - x;
			control.PosY = startY + (float)height / 2f - y;
			DataElement.NewAnchor = Vector2.one / 2f;
			break;
		case 5:
			control.PosX = startX + (float)width / 2f + x;
			control.PosY = startY + (float)height / 2f - y;
			DataElement.NewAnchor = Vector2.one / 2f;
			break;
		case 6:
			control.PosX = startX + (float)width / 2f - x;
			control.PosY = startY + (float)height / 2f + y;
			DataElement.NewAnchor = Vector2.one / 2f;
			break;
		case 7:
			control.PosX = startX + (float)width / 2f + x;
			control.PosY = startY + (float)height / 2f + y;
			DataElement.NewAnchor = Vector2.one / 2f;
			break;
		case 8:
			control.PosX = startX + (float)width / 2f - x;
			control.PosY = startY + y;
			DataElement.NewAnchor = new Vector2(0.5f, 1f);
			break;
		case 9:
			control.PosX = startX + (float)width / 2f - x;
			control.PosY = startY + (float)height - y;
			DataElement.NewAnchor = new Vector2(0.5f, 0f);
			break;
		case 10:
			control.PosX = startX + x;
			control.PosY = startY + (float)height / 2f - y;
			DataElement.NewAnchor = new Vector2(0f, 0.5f);
			break;
		case 11:
			control.PosX = startX + (float)width - x;
			control.PosY = startY + (float)height / 2f - y;
			DataElement.NewAnchor = new Vector2(1f, 0.5f);
			break;
		}
		DataElement.NewAnchor = new Vector2(0f, 1f);
	}

	protected override void InitialAutoValue(string field, IAutoValue auto)
	{
		if (auto != null)
		{
			if ("x" == field)
			{
				auto.SetValue(DataElement.X.ToString());
			}
			if ("y" == field)
			{
				auto.SetValue(DataElement.Y.ToString());
			}
			if ("w" == field)
			{
				auto.SetValue(StringCache.IntToString(ToUI().Width));
			}
			if ("h" == field)
			{
				auto.SetValue(StringCache.IntToString(ToUI().Height));
			}
			if ("a" == field)
			{
				auto.SetValue((ToUI().Alpha * 1000f).ToString());
			}
			if ("r" == field)
			{
				auto.SetValue(((double)(ToUI().Rotation * 180f) / Math.PI).ToString());
			}
			if ("vi" == field)
			{
				auto.SetValue(ToUI().ActiveVisible.ToString());
			}
			if ("ap" == field)
			{
				auto.SetValue(ToUI().PosX + "," + ToUI().PosY + "," + ToUI().Rotation);
			}
			if ("ar" == field)
			{
				auto.SetValue(ToUI().PosX + "," + ToUI().PosY + "," + ToUI().Rotation);
			}
		}
	}

	protected override void SetAutoValueTo(AutoField autoField, int frammeTime)
	{
		if ("x" == autoField.field)
		{
			float x = (float)autoField.auto.Frame(frammeTime).Float;
			SetPos(Group, x, DataElement.Y, ToUI().Width, ToUI().Height, DataElement.Relative, DataElement.Parent);
		}
		if ("y" == autoField.field)
		{
			float y = (float)autoField.auto.Frame(frammeTime).Float;
			SetPos(Group, DataElement.X, y, ToUI().Width, ToUI().Height, DataElement.Relative, DataElement.Parent);
		}
		if ("w" == autoField.field)
		{
			ToUI().Width = (int)autoField.auto.Frame(frammeTime).Float;
		}
		if ("h" == autoField.field)
		{
			ToUI().Height = (int)autoField.auto.Frame(frammeTime).Float;
		}
		if ("a" == autoField.field)
		{
			ToUI().Alpha = (float)autoField.auto.Frame(frammeTime).Float / 1000f;
		}
		if ("r" == autoField.field)
		{
			ToUI().Rotation = (float)autoField.auto.Frame(frammeTime).Float * (float)Math.PI / 180f;
		}
		if ("vi" == autoField.field)
		{
			ToUI().ActiveVisible = Convert.ToBoolean(autoField.auto.Frame(frammeTime).String);
		}
		if ("ap" == autoField.field)
		{
			Vector3D vector3D = autoField.auto.Frame(frammeTime).Vector3D;
			ToUI().PosX = (float)vector3D.x;
			ToUI().PosY = (float)vector3D.y;
		}
		if ("ar" == autoField.field)
		{
			Vector3D vector3D2 = autoField.auto.Frame(frammeTime).Vector3D;
			ToUI().Rotation = (float)vector3D2.z;
		}
	}

	public virtual bool CheckCanSetPos()
	{
		return true;
	}

	public virtual void Frame(IUIDataManager uiDataManager, int frammeTime, IComponentGroup gGroup)
	{
		AutoValue(frammeTime);
		SetToBeBindField();
	}

	protected virtual void SetToBeBindField()
	{
		foreach (AutoField toBeBindAutoField in ToBeBindAutoFields)
		{
			handleToBeBindField(toBeBindAutoField);
		}
	}

	protected virtual void handleToBeBindField(AutoField auto)
	{
		if (auto.field == "x")
		{
			auto.auto.SetValue(Convert.ToString(0f - ToUI().Parent.localPosition.x));
		}
		if (auto.field == "y")
		{
			auto.auto.SetValue(Convert.ToString(ToUI().Parent.localPosition.y));
		}
		if (auto.field == "width")
		{
			auto.auto.SetValue(Convert.ToString(ToUI().Width));
		}
		if (auto.field == "height")
		{
			auto.auto.SetValue(Convert.ToString(ToUI().Height));
		}
	}

	protected virtual string[] GetValue()
	{
		return new string[1] { "" };
	}

	protected void SetArabicNumberSpriteCenter(int number, int index, Sprite numberSprite)
	{
		int imageCount = SetArabicNumberData(number, index, numberSprite);
		SetArabicNumberCenter(imageCount, numberSprite);
	}

	protected void SetArabicNumberSpriteRight(int number, int index, Sprite numberSprite)
	{
		int imageCount = SetArabicNumberData(number, index, numberSprite);
		SetArabicNumberRight(imageCount, numberSprite);
	}

	protected void SetArabicNumberSpriteLeft(int number, int index, Sprite numberSprite)
	{
		int imageCount = SetArabicNumberData(number, index, numberSprite);
		SetArabicNumberLeft(imageCount, numberSprite);
	}

	private int SetArabicNumberData(int number, int index, Sprite numberSprite)
	{
		return 0;
	}

	private void SetArabicNumberRight(int imageCount, Sprite numberSprite)
	{
	}

	private void SetArabicNumberLeft(int imageCount, Sprite numberSprite)
	{
	}

	private void SetArabicNumberCenter(int imageCount, Sprite numberSprite)
	{
	}

	protected void SetNumber(IUiObject sprite, int number)
	{
		sprite.FindComponentInChildren<Text>().text = StringCache.IntToString(number);
	}

	protected void Load(IEnumerator func)
	{
		if (UnityObject != null && UnityObject.GameObject != null)
		{
			BaseAsyncManager.Instance.StartCoroutine(func);
		}
		else
		{
			Logger.ErrorFormat("{0} missing gameobejct ", this);
		}
	}

	public static bool IsNullString(string str)
	{
		if (!string.IsNullOrEmpty(str))
		{
			return str.Equals("null");
		}
		return true;
	}

	public void AddKeyBoardResponder()
	{
		if (IsIKeyboardResponder && this is IKeyboardResponder item)
		{
			Contexts.sharedInstance.userCommand.input.KeyboardResponders.Add(item);
		}
	}

	public virtual bool ShowMouse()
	{
		if (!DataElement.NoMouse && !string.IsNullOrEmpty(EventKey))
		{
			return !IsNullString(EventKey);
		}
		return false;
	}

	public string ToStr()
	{
		return string.Concat("Type >> ", Type, "  ValueType >> ", ValueType, "  UnityObject >> ", UnityObject, "  GeType >> ", GetType());
	}

	public void initToBeBindAutos(string config)
	{
		if (config == null)
		{
			return;
		}
		string[] array = StringExtension.Split(config, "|||");
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i].IndexOf("=");
			if (num > 0)
			{
				InitialOneToBeBindAuto(array[i].Substring(0, num), array[i].Substring(num + 1));
			}
		}
	}

	public virtual void SetRelation(SimpleFreeUI freeUi)
	{
		FreeUi = freeUi;
	}

	private void InitialOneToBeBindAuto(string field, string config)
	{
		AutoConstValue auto = new AutoConstValue();
		InitialAutoValue(field, auto);
		if (ToBeBindAutoFields == null)
		{
			ToBeBindAutoFields = new List<AutoField>();
		}
		ToBeBindAutoFields.Add(new AutoField(field, auto));
	}

	public AutoField GetField(string targetField)
	{
		AutoField result = null;
		foreach (AutoField toBeBindAutoField in ToBeBindAutoFields)
		{
			if (toBeBindAutoField.field.Equals(targetField))
			{
				result = toBeBindAutoField;
				break;
			}
		}
		return result;
	}
}
