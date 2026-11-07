using UnityEngine;

public static class SSJJColorExtensions
{
	public static bool CompareAlpha(this Color color, float alpha)
	{
		if (!Mathf.Approximately(color.a, alpha))
		{
			return false;
		}
		return true;
	}

	public static bool CompareEqual(this Color color, Color otherColor)
	{
		if (!Mathf.Approximately(color.r, otherColor.r))
		{
			return false;
		}
		if (!Mathf.Approximately(color.g, otherColor.g))
		{
			return false;
		}
		if (!Mathf.Approximately(color.b, otherColor.b))
		{
			return false;
		}
		if (!Mathf.Approximately(color.a, otherColor.a))
		{
			return false;
		}
		return true;
	}

	public static void SetColorAlpha(this Color color, ref Color targetColor, float alpha)
	{
		targetColor.a = alpha;
	}

	public static void SetColor(this Color color, ref Color targetColor, Color otherColor)
	{
		targetColor.r = otherColor.r;
		targetColor.g = otherColor.g;
		targetColor.b = otherColor.b;
		targetColor.a = otherColor.a;
	}
}
