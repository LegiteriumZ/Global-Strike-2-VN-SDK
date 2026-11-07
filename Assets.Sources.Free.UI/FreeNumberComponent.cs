using System.Globalization;
using Assets.Sources.Free.Auto;
using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Free.Utility;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Free.UI;

public class FreeNumberComponent : FreeBaseComponent
{
	private readonly Text _text;

	private int _index = -1;

	private int _len;

	private string _pos = "";

	private float _bufferFloat = -100000000f;

	private int Index
	{
		get
		{
			return _index;
		}
		set
		{
			if (value != _index)
			{
				_index = value;
				BaseAsyncManager.Instance.StartCoroutine(FreeResourceUtility.LoadNumberFont(_text, _index));
			}
		}
	}

	public FreeNumberComponent()
	{
		base.Type = 3;
		base.ValueType = 2;
		GameObject gameObject = new GameObject("Number");
		_text = gameObject.AddComponent<Text>();
		_text.horizontalOverflow = HorizontalWrapMode.Overflow;
		_text.verticalOverflow = VerticalWrapMode.Overflow;
		_text.alignment = TextAnchor.UpperLeft;
		_text.raycastTarget = false;
		UnityObject = new UnityUiObject(gameObject);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	public override IFreeComponent Clone()
	{
		return new FreeNumberComponent();
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		base.Frame(uiDataManager, frameTime, gGroup);
		IAutoValue auto = GetAuto("font");
		if (auto != null)
		{
			string[] array = auto.Frame(frameTime).String.Split('_');
			if (array.Length == 3)
			{
				Index = int.Parse(array[0]);
				DataElement.Width = int.Parse(array[1]);
				DataElement.Height = int.Parse(array[2]);
			}
		}
		if (base.ValueAuto != null && ToUI().ActiveVisible)
		{
			float num = (float)base.ValueAuto.Frame(frameTime).Float;
			if (Mathf.Abs(num - _bufferFloat) > 1E-05f)
			{
				SetPureValue(num.ToString(CultureInfo.InvariantCulture));
				_bufferFloat = num;
			}
		}
	}

	protected override void SetPureValue(string v)
	{
		if (!FreeBaseComponent.IsNullString(v))
		{
			int value = 0;
			float result = 0f;
			if (StringCache.TryGetInt(v, out value))
			{
				SetNumber(v);
			}
			else if (float.TryParse(v, out result))
			{
				SetNumber(StringCache.IntToString((int)result));
			}
			else
			{
				FreeBaseComponent.Logger.ErrorFormat("error free number input :{0}", v);
			}
		}
	}

	private void SetNumber(string number)
	{
		_text.text = (ShowZero ? number.PadLeft(_len, '0') : number);
	}

	public override void Initial(params object[] ini)
	{
		if (ini.Length > 1)
		{
			InitialAuto(ini[1] as string);
		}
		string[] array = (ini[0] as string).Split('_');
		int t = 0;
		FreeDataHelperUtility.GetStringArrayIdx(array, 1, ref t);
		Index = t;
		FreeDataHelperUtility.GetStringArrayIdx(array, 2, ref DataElement.Width);
		FreeDataHelperUtility.GetStringArrayIdx(array, 3, ref DataElement.Height);
		FreeDataHelperUtility.GetStringArrayIdx(array, 4, ref _len);
		FreeDataHelperUtility.GetStringArrayIdx(array, 5, ref _pos);
		ShowZero = FreeDataHelperUtility.EqualStringArrayIdx(array, 6, "true");
		UnityObject.Width = DataElement.Width * _len;
		UnityObject.Height = DataElement.Height;
		if (array.Length >= 8)
		{
			UnityObject.ScaleX = float.Parse(array[7]);
			UnityObject.ScaleY = float.Parse(array[7]);
		}
		if (_pos == "center")
		{
			_text.alignment = TextAnchor.UpperCenter;
		}
		else if (_pos == "left")
		{
			_text.alignment = TextAnchor.UpperLeft;
		}
		else if (_pos == "right")
		{
			_text.alignment = TextAnchor.UpperRight;
		}
		SetValueAdapter.SetValueData data = SetValueAdapter.Instance.GetData();
		SetValueAdapter.SetValueData data2 = SetValueAdapter.Instance.GetData();
		data.SetValueInt = 0;
		data2.SetValueStr = array[0];
		SetValue(data, data2);
		SetValueAdapter.Instance.Release(data, data2);
	}

	protected override string[] GetValue()
	{
		return new string[1] { _text.text };
	}
}
