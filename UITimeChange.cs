using Assets.Sources.Free.UI;
using Assets.Sources.Utils.Ui;
using SSJJBase.Extensions;
using UnityEngine;

internal class UITimeChange
{
	public int FromTime;

	public int ToTime;

	public float FromValue;

	public float ToValue;

	public string Field;

	public UITimeChange(int ft = 0, int tt = 0, float fv = 0f, float tv = 0f, string field = "")
	{
		FromTime = ft;
		ToTime = tt;
		FromValue = fv;
		ToValue = tv;
		Field = field;
	}

	public void SetValue(int currentTime, int totalTime, SimpleFreeUI ui)
	{
		if (currentTime < FromTime || currentTime > ToTime)
		{
			return;
		}
		float num = FromValue + (ToValue - FromValue) * (float)(currentTime - FromTime) / (float)(ToTime - FromTime);
		if (Field == "x")
		{
			ui.X = ui.OrignalX + num;
		}
		if (Field == "y")
		{
			ui.Y = ui.OrignalY + num;
		}
		if (FromValue < 0f)
		{
			num = ToValue * (float)(currentTime - FromTime) / (float)(ToTime - FromTime);
		}
		if (Field == "w")
		{
			ui.Width = (int)((float)ui.OrignalWidth + num);
		}
		if (Field == "h")
		{
			ui.Height = (int)((float)ui.OrignalHeight + num);
		}
		if (Field == "a")
		{
			ui.Alpha = num;
		}
		if (!(Field == "s"))
		{
			return;
		}
		int componentCount = ui.ComponentCount;
		for (int i = 0; i < componentCount; i++)
		{
			IFreeComponent component = ui.GetComponent(i);
			if (component != null)
			{
				component.ToUI().GameObject.TryAddComponent<UiScale>().Scale = new Vector2(num, num);
			}
		}
	}
}
