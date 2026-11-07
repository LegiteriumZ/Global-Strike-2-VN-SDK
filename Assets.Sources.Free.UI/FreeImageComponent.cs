using System.Collections;
using System.Collections.Generic;
using Assets.RUI;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using Assets.Sources.Utils.Ui;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Free.UI;

public class FreeImageComponent : FreeBaseComponent
{
	public class ImageComponentData
	{
		public bool Has;

		public int ImageWidth;

		public int ImageHeight;

		public int ComponentWidth;

		public int ComponentHeight;

		public ImageComponentData()
		{
		}

		public ImageComponentData(int imageWidth, int imageHeight)
		{
			ImageWidth = imageWidth;
			ImageHeight = imageHeight;
		}

		public ImageComponentData(int imageWidth, int imageHeight, int componentWidth, int componentHeight)
		{
			ImageWidth = imageWidth;
			ImageHeight = imageHeight;
			ComponentWidth = componentWidth;
			ComponentHeight = componentHeight;
		}

		public override string ToString()
		{
			return "ImageWidht: " + ImageWidth + "  ImageHeight: " + ImageHeight + " ComponentWidth: " + ComponentWidth + "  ComponentHeight : " + ComponentHeight;
		}
	}

	private FreeBaseImage _image;

	private bool _isFixed;

	private EventTrigger _eventTrigger;

	private float _beginDragX;

	private float _beginDragY;

	private float _beginSfX;

	private float _beginSfY;

	private string _imageUrl;

	private IEnumerator _enumerator;

	private bool _reverseX;

	private bool _reverseY;

	public string ImageUrl
	{
		get
		{
			return _imageUrl;
		}
		set
		{
			if (_imageUrl == value || value == null)
			{
				return;
			}
			_imageUrl = value;
			if (FreeBaseComponent.IsNullString(_imageUrl) || !_imageUrl.EndsWith(".atf"))
			{
				StopTask();
				_image.sprite = null;
				return;
			}
			StopTask();
			AssetInfo assetInfoGenImageUrl = GetAssetInfoGenImageUrl(_imageUrl);
			if (!FreeResourceUtility.CheckSetImage(_image, assetInfoGenImageUrl, ComponentData))
			{
				_enumerator = FreeResourceUtility.LoadImage(_image, assetInfoGenImageUrl, ComponentData);
				BaseAsyncManager.Instance.StartCoRoutine(_enumerator);
			}
		}
	}

	private void StopTask()
	{
		if (_enumerator != null)
		{
			BaseAsyncManager.Instance.StopCoroutine(_enumerator);
			_enumerator = null;
		}
	}

	public FreeImageComponent()
	{
		base.Type = 1;
		base.ValueType = 2;
		ComponentData = new ImageComponentData();
		AssetInfoDirs = new Dictionary<string, AssetInfo>();
		GameObject gameObject = new GameObject("Image");
		_image = gameObject.AddComponent<FreeBaseImage>();
		_image.raycastTarget = false;
		_image.sprite = TextureUtility.GetTransparentSprite();
		UnityObject = new UnityUiObject(gameObject);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	public override void Destroy()
	{
		base.Destroy();
		_image.raycastTarget = false;
		_imageUrl = null;
		_enumerator = null;
	}

	private void AddEntry(EventTriggerType entryType, UnityAction<PointerEventData> call)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = entryType;
		entry.callback.AddListener(delegate(BaseEventData data)
		{
			call((PointerEventData)data);
		});
		_eventTrigger.triggers.Add(entry);
	}

	public override void AddEvent()
	{
		_eventTrigger = UnityObject.GameObject.GetComponent<EventTrigger>();
		if (_eventTrigger == null)
		{
			_eventTrigger = UnityObject.GameObject.AddComponent<EventTrigger>();
			_image.raycastTarget = true;
		}
		_eventTrigger.triggers.Clear();
		AddEntry(EventTriggerType.PointerClick, OnPointerClickDelegate);
		AddEntry(EventTriggerType.PointerEnter, OnPointerEnterDelegate);
		AddEntry(EventTriggerType.PointerExit, OnPointerExitDelegate);
		if (base.CanDrag)
		{
			AddEntry(EventTriggerType.BeginDrag, OnBeginDragDelegate);
			AddEntry(EventTriggerType.Drag, OnDragDelegate);
			AddEntry(EventTriggerType.EndDrag, OnEndDragDelegate);
		}
	}

	private void OnBeginDragDelegate(PointerEventData eventData)
	{
		this.ImageBeginDrag(eventData, ref _beginDragX, ref _beginDragY, ref _beginSfX, ref _beginSfY);
	}

	private void OnDragDelegate(PointerEventData eventData)
	{
		this.ImageDraging(eventData, _beginDragX, _beginDragY, _beginSfX, _beginSfY, _isFixed);
	}

	private void OnEndDragDelegate(PointerEventData eventData)
	{
		this.ImageEndDrag(eventData, _beginDragX, _beginDragY, _beginSfX, _beginSfY, _isFixed, ref FreeEvent, DataElement.EventKey, Autos);
	}

	private void OnPointerExitDelegate(PointerEventData eventData)
	{
		this.ImagePointerExit(ref FreeEvent, DataElement.EventKey);
	}

	private void OnPointerEnterDelegate(PointerEventData eventData)
	{
		this.ImagePointerEnter(ref FreeEvent, DataElement.EventKey);
	}

	private void OnPointerClickDelegate(PointerEventData eventData)
	{
		this.ImagePointClick(ref FreeEvent, eventData, DataElement.EventKey);
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		if (!_image.enabled)
		{
			return;
		}
		base.Frame(uiDataManager, frameTime, gGroup);
		for (int i = 0; i < Autos.Count; i++)
		{
			AutoField autoField = Autos[i];
			if ((autoField.field == "v" || string.IsNullOrEmpty(autoField.field)) && ToUI().ActiveVisible)
			{
				float p = (float)autoField.auto.Frame(frameTime).Float;
				SetPercent(p, _image);
			}
			if (autoField.field == "percentH" && ToUI().ActiveVisible)
			{
				float percentHeightWithAtlas = (float)autoField.auto.Frame(frameTime).Float;
				_image.SetPercentHeightWithAtlas(percentHeightWithAtlas);
			}
			_ = autoField.field == "cover";
			if (autoField.field == "url")
			{
				string @string = autoField.auto.Frame(frameTime).String;
				if (!FreeBaseComponent.IsNullString(@string))
				{
					SetPureValue(@string);
				}
			}
		}
	}

	protected override void SetPureValue(string value)
	{
		if (value.Length < 3 && base.ValueAuto != null && base.ValueAuto is AutoTimeStringValue)
		{
			int value2 = 0;
			if (StringCache.TryGetInt(value, out value2))
			{
				AutoTimeStringValue autoTimeStringValue = (AutoTimeStringValue)base.ValueAuto;
				if (value2 > 0 && value2 <= autoTimeStringValue.Size())
				{
					ImageUrl = autoTimeStringValue.GetUrl(value2 - 1);
				}
			}
		}
		else
		{
			ImageUrl = value;
		}
	}

	protected void SetImageOpacityUv(int origWidth, int origHeight, Image image)
	{
	}

	public override void Initial(params object[] ini)
	{
		InitialAuto(ini[1] as string);
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length > 1)
		{
			string[] array2 = array[1].Split(',');
			if (array2.Length == 2)
			{
				_image.rectTransform.pivot = new Vector2(float.Parse(array2[0]), float.Parse(array2[1]));
			}
		}
		if (array.Length > 2)
		{
			string[] array3 = array[2].Split(',');
			if (array3.Length == 2)
			{
				int.TryParse(array3[0], out ComponentData.ImageWidth);
				int.TryParse(array3[1], out ComponentData.ImageHeight);
				ComponentData.Has = true;
			}
		}
		FreeDataHelperUtility.ContainStringArrayIdx(array, 3, ".atf");
		_isFixed = FreeDataHelperUtility.EqualStringArrayIdx(array, 4, "true");
		DataElement.NoMouse = FreeDataHelperUtility.EqualStringArrayIdx(array, 5, "true");
		FreeDataHelperUtility.EqualStringArrayIdx(array, 6, "");
		FreeDataHelperUtility.EqualStringArrayIdx(array, 7, "");
		string t = "";
		if (FreeDataHelperUtility.GetStringArrayIdx(array, 8, ref t))
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
		FreeDataHelperUtility.GetStringArrayIdx(array, 9, ref DataElement.ComponentName);
		if (!ComponentData.Has)
		{
			ComponentData.ImageWidth = UnityObject.Width;
			ComponentData.ImageHeight = UnityObject.Height;
		}
		SetValueAdapter.SetValueData data = SetValueAdapter.Instance.GetData();
		SetValueAdapter.SetValueData data2 = SetValueAdapter.Instance.GetData();
		data.SetValueInt = 0;
		data2.SetValueStr = array[0];
		SetValue(data, data2);
		SetValueAdapter.Instance.Release(data, data2);
		_image.SetImageUvReverse(_reverseX, _reverseY, ComponentData.ComponentWidth, ComponentData.ComponentHeight);
	}

	public override void SetPos(IComponentGroup freeUI, float x, float y, int width, int heigth, int relative, int parent, bool isInWorld = true)
	{
		if (width == -1 && heigth == -1)
		{
			width = Screen.width;
			heigth = Screen.height;
			x = 0f;
			y = 0f;
		}
		base.SetPos(freeUI, x, y, width, heigth, relative, parent, isInWorld);
		ComponentData.ComponentWidth = width;
		ComponentData.ComponentHeight = heigth;
		_image.rectTransform.sizeDelta = new Vector2(width, heigth);
	}

	public override bool CheckCanSetPos()
	{
		if (GetAuto("percentH") != null)
		{
			return !HasSetPos;
		}
		return true;
	}

	public override IFreeComponent Clone()
	{
		return new FreeImageComponent();
	}

	protected void SetPercent(float p, Image image)
	{
		if (_image.type != Image.Type.Filled)
		{
			_image.type = Image.Type.Filled;
			_image.fillMethod = Image.FillMethod.Horizontal;
			_image.fillOrigin = 0;
		}
		image.fillAmount = p;
	}

	protected override string[] GetValue()
	{
		return new string[1] { ImageUrl };
	}
}
