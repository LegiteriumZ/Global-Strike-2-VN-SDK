using System;
using System.Collections.Generic;
using SSJJBase.Extensions;

namespace Assets.Sources.Free.Auto;

public abstract class BaseAutoFields
{
	public const int AUTO_SET = 0;

	public const int AUTO_START_OLD = 1;

	public const int AUTO_START_NEW = 2;

	public const int AUTO_STOP_OLD = 3;

	public const int AUTO_STOP_NEW = 4;

	public List<AutoField> Autos;

	protected BaseAutoFields()
	{
		Autos = new List<AutoField>();
	}

	public static void StartAutos(List<AutoField> autos, int index = 0)
	{
		if (index == 0)
		{
			for (int i = 0; i < autos.Count; i++)
			{
				autos[i].auto.Start();
			}
		}
		else if (index > 0 && index <= autos.Count)
		{
			autos[index - 1].auto.Start();
		}
	}

	public void StartAuto(int index = 0)
	{
		StartAutos(Autos, index);
	}

	public static void StopAutos(List<AutoField> autos, int index = 0)
	{
		if (index == 0)
		{
			for (int i = 0; i < autos.Count; i++)
			{
				autos[i].auto.Stop();
			}
		}
		else if (index > 0 && index <= autos.Count)
		{
			autos[index - 1].auto.Stop();
		}
	}

	protected void StopAuto(int index = 0)
	{
		StopAutos(Autos, index);
	}

	protected IAutoValue GetAuto(string field)
	{
		for (int i = 0; i < Autos.Count; i++)
		{
			AutoField autoField = Autos[i];
			if (autoField.field == field)
			{
				return autoField.auto;
			}
		}
		return null;
	}

	public static string SetValue(List<AutoField> autos, int autoIndex, string value)
	{
		int num = autoIndex / 100;
		int index = autoIndex % 100;
		if (num == 2 || num == 1)
		{
			StartAutos(autos, index);
		}
		else
		{
			StopAutos(autos, index);
		}
		if (num == 2 || num == 4 || num == 0)
		{
			if (num == 2 || num == 4)
			{
				SetAutoValues(autos, value, index);
			}
			if (num == 0)
			{
				return value;
			}
		}
		return null;
	}

	public static void SetAutoValues(List<AutoField> autos, string vs, int index)
	{
		if (index == 0)
		{
			for (int i = 0; i < autos.Count; i++)
			{
				autos[i].auto.SetValue(vs);
			}
		}
		else if (index > 0 && index <= autos.Count)
		{
			autos[index - 1].auto.SetValue(vs);
		}
	}

	protected void SetAutoValue(string vs, int index = 0)
	{
		SetAutoValues(Autos, vs, index);
	}

	public void InitialAuto(string config)
	{
		if (string.IsNullOrEmpty(config))
		{
			return;
		}
		string[] array = config.Split("|||");
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i].IndexOf("=", StringComparison.Ordinal);
			if (num > 0)
			{
				InitialOneAuto(array[i].Substring(0, num), array[i].Substring(num + 1));
			}
		}
	}

	private void InitialOneAuto(string field, string config)
	{
		IAutoValue autoValue = Assets.Sources.Free.Auto.AutoValue.Parse(config);
		if (autoValue != null)
		{
			InitialAutoValue(field, autoValue);
			Autos.Add(new AutoField(field, autoValue));
		}
	}

	protected abstract void InitialAutoValue(string field, IAutoValue auto);

	protected void AutoValue(int frameTime)
	{
		for (int i = 0; i < Autos.Count; i++)
		{
			AutoField auto = Autos[i];
			SetAutoValueTo(auto, frameTime);
		}
	}

	protected abstract void SetAutoValueTo(AutoField auto, int frammeTime);
}
