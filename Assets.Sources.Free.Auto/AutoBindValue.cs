using Assets.Sources.Free.UI;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.Auto;

public class AutoBindValue : AbstractAutoValue
{
	private const string EFFECT = "effect";

	private const string UI = "ui";

	private AutoField bindField;

	private string targetField;

	private string targetIndex;

	private string targetKey;

	private string targetType;

	public AutoField BindField
	{
		get
		{
			return bindField;
		}
		set
		{
			bindField = value;
		}
	}

	public string TargetField
	{
		get
		{
			return targetField;
		}
		set
		{
			targetField = value;
		}
	}

	public string TargetIndex
	{
		get
		{
			return targetIndex;
		}
		set
		{
			targetIndex = value;
		}
	}

	public string TargetKey
	{
		get
		{
			return targetKey;
		}
		set
		{
			targetKey = value;
		}
	}

	public string TargetType
	{
		get
		{
			return targetType;
		}
		set
		{
			targetType = value;
		}
	}

	public override IAutoValue Parse(string config)
	{
		string[] array = config.Split("|");
		if (array.Length == 2 && array[0] == "bind")
		{
			AutoBindValue autoBindValue = new AutoBindValue();
			string[] array2 = array[1].Split("_$$$_");
			initFromConfigString(autoBindValue, array2);
			if (array2.Length == 4)
			{
				return autoBindValue;
			}
		}
		return null;
	}

	public static void initFromConfigString(AutoBindValue at, string[] paras)
	{
		if (paras.Length != 4)
		{
			return;
		}
		at.TargetType = paras[0];
		at.TargetKey = paras[1];
		at.TargetIndex = paras[2];
		at.TargetField = paras[3];
		int num = int.Parse(at.targetIndex);
		if (!at.targetType.Equals("ui"))
		{
			return;
		}
		SimpleFreeUI ui = MonoBehaviourSingleton<FreeUiManager>.Instance.GetUi(at.targetKey);
		if (ui != null)
		{
			if (num == 0)
			{
				at.BindField = ui.GetBindField(at.targetField);
				if (at.BindField == null)
				{
					Debug.LogError("No such field,field can not bind to ui: " + at.targetKey + "  index: " + at.targetIndex + "  field     " + at.targetField);
				}
			}
			else if (num <= ui.ComponentCount)
			{
				if (!(ui.FreeComponents[num - 1] is FreeBaseComponent freeBaseComponent))
				{
					Debug.LogError("No such effect,field can not bind to component: " + at.targetKey + "  index: " + at.targetIndex + "  field     " + at.targetField);
				}
				else
				{
					at.BindField = freeBaseComponent.GetField(at.targetField);
				}
				if (at.BindField == null)
				{
					Debug.LogError("No such field,field can not bind to component: " + at.targetKey + "  index: " + at.targetIndex + "  field     " + at.targetField);
				}
			}
			else
			{
				Debug.LogError("Out of range,field can not bind to ui: " + at.targetKey + "  index: " + at.targetIndex + "  field     " + at.targetField);
			}
		}
		else
		{
			Debug.LogError("No such effect,field can not bind to ui: " + at.targetKey + "  index: " + at.targetIndex + "  field     " + at.targetField);
		}
	}

	public override void SetValue(params string[] value)
	{
	}

	public override AutoValueData Frame(int frameTime)
	{
		AutoValueData = BindField.auto.Frame(frameTime);
		return base.Frame(frameTime);
	}
}
