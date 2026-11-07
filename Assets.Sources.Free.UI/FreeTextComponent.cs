using Assets.Sources.Free.Data;
using Assets.Sources.Free.Render;
using Assets.Sources.Modules.Ui;
using Assets.UiFramework.Libs;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Free.UI;

public class FreeTextComponent : FreeBaseComponent
{
	private Text _text;

	private string style;

	private static UiResourcesLoader _loader;

	public FreeTextComponent()
	{
		base.Type = 2;
		base.ValueType = 2;
		if (_loader == null)
		{
			_loader = (UiResourcesLoader)AbstractModel.GetUiResourceLoader();
		}
		GameObject gameObject = new GameObject("Text");
		_text = gameObject.AddComponent<Text>();
		_text.horizontalOverflow = HorizontalWrapMode.Overflow;
		_text.verticalOverflow = VerticalWrapMode.Overflow;
		_text.raycastTarget = false;
		UnityObject = new UnityUiObject(gameObject);
		UnityObject.GameObject.transform.SetParent(MonoBehaviourSingleton<FreeUiManager>.Instance.GetTemplateParent());
	}

	private void SetNormalFont()
	{
		_loader.Load("fonts", "Assets/Res/Assets/Fonts/simsun.ttf", FontCallDone);
	}

	private void SetBoldFont()
	{
		_loader.Load("fonts", "Assets/Res/Assets/Fonts/simsun.ttf", delegate(Object v)
		{
			FontCallDone(v);
			_text.fontStyle = FontStyle.Bold;
		});
	}

	private void FontCallDone(Object v)
	{
		if (_text != null && v != null)
		{
			_text.font = (Font)v;
		}
		else
		{
			this.LogError("Font not found " + _text);
		}
	}

	public override void Frame(IUIDataManager uiDataManager, int frameTime, IComponentGroup gGroup)
	{
		base.Frame(uiDataManager, frameTime, gGroup);
		if (base.ValueAuto != null)
		{
			string @string = base.ValueAuto.Frame(frameTime).String;
			if (!FreeBaseComponent.IsNullString(@string))
			{
				SetText(@string);
			}
		}
	}

	protected override void SetPureValue(string v)
	{
		SetText(v);
	}

	private void SetText(string value)
	{
		_text.text = value;
	}

	public override void Initial(params object[] ini)
	{
		InitialAuto(ini[1] as string);
		style = ini[0].ToString();
		string[] array = ini[0].ToString().Split("_$$$_");
		_text.fontSize = (int)float.Parse(array[1]);
		ColorUtility.TryParseHtmlString("#" + array[2], out var color);
		_text.color = color;
		if (array[3] == "true")
		{
			SetBoldFont();
		}
		else
		{
			SetNormalFont();
		}
		string text = array[5];
		if (string.IsNullOrEmpty(text))
		{
			text = "center";
		}
		string text2 = array[6];
		if (string.IsNullOrEmpty(text2))
		{
			text2 = "center";
		}
		if (text == "left" && text2 == "bottom")
		{
			_text.alignment = TextAnchor.LowerLeft;
		}
		else if (text == "left" && text2 == "center")
		{
			_text.alignment = TextAnchor.MiddleLeft;
		}
		else if (text == "left" && text2 == "top")
		{
			_text.alignment = TextAnchor.UpperLeft;
		}
		else if (text == "center" && text2 == "bottom")
		{
			_text.alignment = TextAnchor.LowerCenter;
		}
		else if (text == "center" && text2 == "center")
		{
			_text.alignment = TextAnchor.MiddleCenter;
		}
		else if (text == "center" && text2 == "top")
		{
			_text.alignment = TextAnchor.UpperCenter;
		}
		else if (text == "right" && text2 == "bottom")
		{
			_text.alignment = TextAnchor.LowerRight;
		}
		else if (text == "right" && text2 == "center")
		{
			_text.alignment = TextAnchor.MiddleRight;
		}
		else if (text == "right" && text2 == "top")
		{
			_text.alignment = TextAnchor.UpperRight;
		}
		SetValueAdapter.SetValueData data = SetValueAdapter.Instance.GetData();
		SetValueAdapter.SetValueData data2 = SetValueAdapter.Instance.GetData();
		data.SetValueInt = 0;
		data2.SetValueStr = array[0];
		SetValue(data, data2);
		SetValueAdapter.Instance.Release(data, data2);
		SetPosSpecailLogic();
	}

	protected override void SetPosSpecailLogic()
	{
		if (_text.alignment == TextAnchor.LowerLeft || _text.alignment == TextAnchor.MiddleLeft || _text.alignment == TextAnchor.UpperLeft)
		{
			ToUI().PosX += 4f;
		}
	}

	protected void CreateTextFieldImage(int textureType, string textureUrl)
	{
	}

	public override void SetPos(IComponentGroup freeUI, float x, float y, int width, int height, int relative, int parent, bool isInWorld = true)
	{
		base.SetPos(freeUI, x, y, width, height, relative, parent, isInWorld);
		UnityObject.Width = width;
		UnityObject.Height = height;
	}

	public override IFreeComponent Clone()
	{
		return new FreeTextComponent();
	}

	protected override string[] GetValue()
	{
		return new string[1] { _text.text };
	}
}
