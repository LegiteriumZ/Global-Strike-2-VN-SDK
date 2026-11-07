using System.Collections.Generic;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Free.UI;

public class FreeSliderComponent : FreeBaseComponent
{
	private Transform _up;

	private Transform _point;

	private Transform _background;

	private Texture2D _backTexture2D;

	private Texture2D _upTexture2D;

	private Texture2D _pointTexture2D;

	private Slider _slider;

	private Text _sliderValueTxt;

	private int currentValue;

	private int maxValue;

	private int lastAutoValue;

	public string KeyWord => base.FreeUi.Key;

	public FreeSliderComponent()
	{
		base.Type = 13;
		base.ValueType = 2;
		AssetInfoDirs = new Dictionary<string, AssetInfo>();
		GameObject engineObj = new GameObject("SliderUi");
		UnityObject = new UnityUiObject(engineObj);
		UnityObject.Anchor = new Vector2(0f, 1f);
		UnityObject.GameObject.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	private void LoadBackImageOver(Texture2D texture2D)
	{
		_backTexture2D = texture2D;
		LoadingOverSetData();
	}

	private void LoadUpImageOver(Texture2D texture2D)
	{
		_upTexture2D = texture2D;
		LoadingOverSetData();
	}

	private void LoadPointImageOver(Texture2D texture2D)
	{
		_pointTexture2D = texture2D;
		LoadingOverSetData();
	}

	private void LoadSliderOver(GameObject gameObject)
	{
		gameObject.name = base.Key;
		_background = gameObject.transform.Find("Background");
		_up = gameObject.transform.Find("Fill Area/Fill");
		_point = gameObject.transform.Find("Handle Slide Area/Handle");
		_sliderValueTxt = gameObject.transform.Find("Value").GetComponent<Text>();
		_slider = gameObject.GetComponent<Slider>();
		_slider.value = (int)((float)currentValue * 1f / ((float)maxValue * 1f));
		Debug.LogFormat("max value: {0}", maxValue);
		gameObject.transform.SetParent(ToUI().GameObject.transform.parent);
		RectTransform component = gameObject.GetComponent<RectTransform>();
		Vector2 anchorMax = (gameObject.GetComponent<RectTransform>().anchorMin = ToUI().Anchor);
		component.anchorMax = anchorMax;
		RectTransform component2 = ToUI().GameObject.GetComponent<RectTransform>();
		gameObject.GetComponent<RectTransform>().pivot = component2.pivot;
		gameObject.GetComponent<RectTransform>().localPosition = component2.localPosition;
		gameObject.GetComponent<RectTransform>().sizeDelta = component2.sizeDelta;
		gameObject.name = "Slider";
		ToUI().GameObject = gameObject;
		lastAutoValue = (int)_slider.value;
		LoadingOverSetData();
		_slider.onValueChanged.AddListener(OnValueChange);
	}

	private void LoadingOverSetData()
	{
		if (_backTexture2D != null && _upTexture2D != null && _pointTexture2D != null && _up != null)
		{
			_background.GetComponent<Image>().sprite = Sprite.Create(_backTexture2D, new Rect(0f, 0f, _backTexture2D.width, _backTexture2D.height), new Vector2(0f, 1f));
			_up.GetComponent<Image>().sprite = Sprite.Create(_upTexture2D, new Rect(0f, 0f, _upTexture2D.width, _upTexture2D.height), new Vector2(0f, 1f));
			_point.GetComponent<Image>().sprite = Sprite.Create(_pointTexture2D, new Rect(0f, 0f, _pointTexture2D.width, _pointTexture2D.height), new Vector2(0f, 1f));
		}
	}

	public override void Initial(params object[] ini)
	{
		InitialAuto(ini[1] as string);
		string[] array = (ini[0] as string).Split("_$$$_");
		if (array.Length > 1)
		{
			string[] array2 = array[0].Split(',');
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadTexture2D(GetAssetInfoGenImageUrl(array2[0]), LoadBackImageOver));
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadTexture2D(GetAssetInfoGenImageUrl(array2[1]), LoadUpImageOver));
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadTexture2D(GetAssetInfoGenImageUrl(array2[2]), LoadPointImageOver));
			BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadSlider(LoadSliderOver));
			string[] array3 = array[1].Split(',');
			currentValue = int.Parse(array3[0]);
			maxValue = int.Parse(array3[1]);
		}
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		base.Frame(uiDataManager, frameTime, gGroup);
		AutoField valueAuto = GetValueAuto();
		if (valueAuto != null && _slider != null)
		{
			int num = (int)valueAuto.auto.Frame(frameTime).Float;
			int num2 = (int)_slider.value * maxValue;
			if (num != num2)
			{
				_slider.value = (float)num * 1f / (float)maxValue;
			}
		}
		if (_sliderValueTxt != null && _sliderValueTxt.enabled)
		{
			_sliderValueTxt.text = string.Concat((int)(_slider.value * (float)maxValue));
		}
	}

	private void OnValueChange(float arg0)
	{
		AutoField valueAuto = GetValueAuto();
		int num = (int)_slider.value * maxValue;
		string[] value = new string[1] { num.ToString() };
		valueAuto.auto.SetValue(value);
	}

	private AutoField GetValueAuto()
	{
		for (int i = 0; i < Autos.Count; i++)
		{
			AutoField autoField = Autos[i];
			if (autoField.field == "v")
			{
				return autoField;
			}
		}
		return null;
	}

	public override IFreeComponent Clone()
	{
		return new FreeSliderComponent();
	}

	protected override void handleToBeBindField(AutoField auto)
	{
		base.handleToBeBindField(auto);
		if (auto.field.Equals("sliderValue"))
		{
			auto.auto.SetValue(GetValue());
		}
	}

	protected override string[] GetValue()
	{
		if (_slider != null)
		{
			string text = string.Concat((int)(_slider.value * (float)maxValue));
			return new string[1] { text };
		}
		return new string[1] { "" };
	}
}
