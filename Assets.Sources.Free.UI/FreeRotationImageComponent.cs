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
using UnityEngine.UI;

namespace Assets.Sources.Free.UI;

public class FreeRotationImageComponent : FreeBaseComponent
{
	private readonly FreeBaseImage _image;

	private IEnumerator _enumerator;

	private bool _decrement;

	private float _amount;

	private string _imageUrl;

	public string ImageUrl
	{
		get
		{
			return _imageUrl;
		}
		set
		{
			if (_imageUrl == value)
			{
				return;
			}
			_imageUrl = value;
			if (_image == null)
			{
				return;
			}
			if (FreeBaseComponent.IsNullString(_imageUrl) || !_imageUrl.EndsWith(".atf"))
			{
				_image.sprite = null;
				return;
			}
			if (_enumerator != null)
			{
				BaseAsyncManager.Instance.StopCoroutine(_enumerator);
				_enumerator = null;
			}
			AssetInfo assetInfoGenImageUrl = GetAssetInfoGenImageUrl(_imageUrl);
			if (!FreeResourceUtility.CheckSetImage(_image, assetInfoGenImageUrl, ComponentData))
			{
				_enumerator = FreeResourceUtility.LoadImage(_image, assetInfoGenImageUrl, ComponentData);
				BaseAsyncManager.Instance.StartCoRoutine(_enumerator);
			}
		}
	}

	public FreeRotationImageComponent()
	{
		base.Type = 8;
		base.ValueType = 2;
		ComponentData = new FreeImageComponent.ImageComponentData();
		AssetInfoDirs = new Dictionary<string, AssetInfo>();
		GameObject gameObject = new GameObject("RotationImage");
		_image = gameObject.AddComponent<FreeBaseImage>();
		_image.raycastTarget = false;
		_image.sprite = TextureUtility.GetTransparentSprite();
		_image.type = Image.Type.Filled;
		_image.fillMethod = Image.FillMethod.Radial360;
		_image.fillAmount = 0f;
		_image.fillOrigin = 0;
		_image.fillClockwise = true;
		UnityObject = new UnityUiObject(gameObject);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	public override void Initial(params object[] ini)
	{
		InitialAuto(ini[1] as string);
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length > 1)
		{
			_image.fillClockwise = !FreeDataHelperUtility.EqualStringArrayIdx(array, 1, "true");
		}
		_decrement = FreeDataHelperUtility.EqualStringArrayIdx(array, 2, "true");
		if (array.Length > 3)
		{
			_image.fillOrigin = int.Parse(array[3]);
		}
		SetValueAdapter.SetValueData data = SetValueAdapter.Instance.GetData();
		SetValueAdapter.SetValueData data2 = SetValueAdapter.Instance.GetData();
		data.SetValueInt = 0;
		data2.SetValueStr = array[0];
		SetValue(data, data2);
		SetValueAdapter.Instance.Release(data, data2);
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

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		base.Frame(uiDataManager, frameTime, gGroup);
		foreach (AutoField auto in Autos)
		{
			if ((auto.field == "v" || string.IsNullOrEmpty(auto.field)) && ToUI().InHierarchyVisible)
			{
				_amount = (float)auto.auto.Frame(frameTime).Float;
				_amount = (_decrement ? (1f - _amount) : _amount);
				_image.fillAmount = _amount;
			}
		}
	}

	protected override void SetAutoValueTo(AutoField autoField, int frameTime)
	{
		base.SetAutoValueTo(autoField, frameTime);
		if ("r" == autoField.field)
		{
			ToUI().Rotation = 0f;
			double num = autoField.auto.Frame(frameTime).Float * 3.1415927410125732 / 180.0;
			ToUI().Rotation = (float)num;
		}
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
		ComponentData.ImageWidth = (ComponentData.ComponentWidth = width);
		ComponentData.ImageHeight = (ComponentData.ComponentHeight = heigth);
		_image.rectTransform.sizeDelta = new Vector2(width, heigth);
	}

	public override IFreeComponent Clone()
	{
		return new FreeRotationImageComponent();
	}
}
