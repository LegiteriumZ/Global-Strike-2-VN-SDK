using UnityEngine;

namespace OrbCreationExtensions;

public static class Vector2Extensions
{
	public static string MakeString(this Vector2 v)
	{
		return "<" + v.x + "," + v.y + ">";
	}

	public static string MakeString(this Vector2 v, int decimals)
	{
		if (decimals <= 0)
		{
			return "<" + Mathf.RoundToInt(v.x) + "," + Mathf.RoundToInt(v.y) + ">";
		}
		string format = "{0:F" + decimals + "}";
		return "<" + string.Format(format, v.x) + "," + string.Format(format, v.y) + ">";
	}

	public static Vector2 Product(this Vector2 v1, Vector2 v2)
	{
		return new Vector2(v1.x * v2.x, v1.y * v2.y);
	}

	public static float InProduct(this Vector2 v1, Vector2 v2)
	{
		return v1.x * v2.x + v1.y * v2.y;
	}

	public static Vector2 Abs(this Vector2 v)
	{
		return new Vector2(Mathf.Abs(v.x), Mathf.Abs(v.y));
	}

	public static bool IsEqual(this Vector2 v1, Vector2 v2)
	{
		if (v1.x == v2.x)
		{
			return v1.y == v2.y;
		}
		return false;
	}

	public static bool DiffBetween(this Vector2 v1, Vector2 v2, float from, float to)
	{
		if (v1.x - v2.x < to && v1.x - v2.x > from && v1.y - v2.y < to)
		{
			return v1.y - v2.y > from;
		}
		return false;
	}

	public static bool IsDiffSmallEnough(this Vector2 v1, Vector2 v2, float maxDiff)
	{
		if (v1.x - v2.x < maxDiff && v2.x - v1.x < maxDiff && v1.y - v2.y < maxDiff)
		{
			return v2.y - v1.y < maxDiff;
		}
		return false;
	}

	public static bool IsAllSmaller(this Vector2 v1, Vector2 v2)
	{
		if (v1.x < v2.x)
		{
			return v1.y < v2.y;
		}
		return false;
	}

	public static bool IsBarycentricInTriangle(this Vector2 v)
	{
		if (v.x >= 0f && v.y >= 0f)
		{
			return v.x + v.y <= 1.01f;
		}
		return false;
	}
}
