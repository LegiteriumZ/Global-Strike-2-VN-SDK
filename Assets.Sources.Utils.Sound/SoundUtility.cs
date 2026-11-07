using System;
using UnityEngine;

namespace Assets.Sources.Utils.Sound;

public class SoundUtility
{
	public static AnimationCurve GetCurve(int min, int max, float a, float b)
	{
		AnimationCurve animationCurve = new AnimationCurve();
		animationCurve.AddKey(min, 1f);
		for (float num = (float)min + b; num <= (float)(max - 1); num += b)
		{
			animationCurve.AddKey(num, (float)Math.Pow(a, (num - (float)min) / b));
		}
		int num2 = animationCurve.AddKey(max - 1, (float)Math.Pow(a, (float)(max - 1 - min) / b));
		animationCurve.AddKey(max, 0f);
		if (num2 > -1)
		{
			animationCurve.SmoothTangents(num2, 1f);
		}
		return animationCurve;
	}
}
