using System;
using UnityEngine;

namespace Assets.Sources.Constant;

public class ScreenConstant
{
	public const int Screenration43 = 0;

	public const int Screenration1610 = 1;

	public const int Screenration169 = 2;

	public const float Viewscale = 0.2f;

	public const float PiArithmetic1 = 0.008726647f;

	public const float PiArithmetic2 = 360f / (float)Math.PI;

	public const float PiArithmetic3 = (float)Math.PI / 360f;

	public static int GetScreenRation()
	{
		float num = (float)Screen.width / (float)Screen.height;
		float num2 = Mathf.Abs(num - 1.3333334f);
		float num3 = Mathf.Abs(num - 1.6f);
		float num4 = Mathf.Abs(num - 1.7777778f);
		if (num2 > num3)
		{
			if (num3 > num4)
			{
				return 2;
			}
			return 1;
		}
		return 0;
	}

	public static int GetScreenWidth()
	{
		int screenRation = GetScreenRation();
		if ((uint)(screenRation - 1) <= 1u)
		{
			return 1280;
		}
		return 1024;
	}

	public static int GetScreenHeight()
	{
		return GetScreenRation() switch
		{
			2 => 720, 
			1 => 800, 
			_ => 768, 
		};
	}
}
