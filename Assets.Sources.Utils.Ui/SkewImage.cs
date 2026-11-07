using System;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace Assets.Sources.Utils.Ui;

public class SkewImage : Image
{
	[SerializeField]
	public Vector2 _Skew;

	private bool _canskew;

	private static readonly Vector3[] s_Xy = new Vector3[4];

	private static readonly Vector3[] s_Uv = new Vector3[4];

	public Vector2 Skew
	{
		get
		{
			return _Skew;
		}
		set
		{
			_Skew = value;
			SetAllDirty();
		}
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		if (base.sprite == null && base.overrideSprite == null)
		{
			base.OnPopulateMesh(toFill);
		}
		else if (base.type == Type.Simple)
		{
			_canskew = Mathf.Abs(Skew.x - 90f) > 0.01f && Mathf.Abs(Skew.y - 90f) > 0.01f;
			Sprite sprite = ((base.overrideSprite != null) ? base.overrideSprite : base.sprite);
			Vector4 drawingDimensions = GetDrawingDimensions(base.preserveAspect);
			Vector4 vector = ((sprite != null) ? DataUtility.GetOuterUV(sprite) : Vector4.zero);
			Color color = this.color;
			toFill.Clear();
			if (!_canskew)
			{
				toFill.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.y), color, new Vector2(vector.x, vector.y));
				toFill.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.w), color, new Vector2(vector.x, vector.w));
				toFill.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.w), color, new Vector2(vector.z, vector.w));
				toFill.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.y), color, new Vector2(vector.z, vector.y));
				toFill.AddTriangle(0, 1, 2);
				toFill.AddTriangle(2, 3, 0);
			}
			else
			{
				float num = drawingDimensions.z - drawingDimensions.x;
				float num2 = (drawingDimensions.w - drawingDimensions.y) * Mathf.Tan(Skew.x);
				float num3 = num * Mathf.Tan(Skew.y);
				toFill.AddVert(new Vector3(drawingDimensions.x + num2, drawingDimensions.y + num3), color, new Vector2(vector.x, vector.y));
				toFill.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.w), color, new Vector2(vector.x, vector.w));
				toFill.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.w), color, new Vector2(vector.z, vector.w));
				toFill.AddVert(new Vector3(drawingDimensions.z + num2, drawingDimensions.y + num3), color, new Vector2(vector.z, vector.y));
				toFill.AddTriangle(0, 1, 2);
				toFill.AddTriangle(2, 3, 0);
			}
		}
		else if (base.type == Type.Filled)
		{
			GenerateFilledSprite(toFill, base.preserveAspect);
		}
		else
		{
			base.OnPopulateMesh(toFill);
		}
	}

	private void GenerateFilledSprite(VertexHelper toFill, bool preserveAspect)
	{
		toFill.Clear();
		if (base.fillAmount < 0.001f)
		{
			return;
		}
		Sprite sprite = ((base.overrideSprite != null) ? base.overrideSprite : base.sprite);
		Vector4 drawingDimensions = GetDrawingDimensions(preserveAspect);
		Vector4 obj = ((sprite != null) ? DataUtility.GetOuterUV(sprite) : Vector4.zero);
		UIVertex simpleVert = UIVertex.simpleVert;
		simpleVert.color = color;
		float num = obj.x;
		float num2 = obj.y;
		float num3 = obj.z;
		float num4 = obj.w;
		_canskew = Mathf.Abs(Skew.x - 90f) > 0.01f && Mathf.Abs(Skew.y - 90f) > 0.01f;
		if (base.fillMethod == FillMethod.Horizontal || base.fillMethod == FillMethod.Vertical)
		{
			if (base.fillMethod == FillMethod.Horizontal)
			{
				float num5 = (num3 - num) * base.fillAmount;
				if (base.fillOrigin == 1)
				{
					drawingDimensions.x = drawingDimensions.z - (drawingDimensions.z - drawingDimensions.x) * base.fillAmount;
					num = num3 - num5;
				}
				else
				{
					drawingDimensions.z = drawingDimensions.x + (drawingDimensions.z - drawingDimensions.x) * base.fillAmount;
					num3 = num + num5;
				}
			}
			else if (base.fillMethod == FillMethod.Vertical)
			{
				float num6 = (num4 - num2) * base.fillAmount;
				if (base.fillOrigin == 1)
				{
					drawingDimensions.y = drawingDimensions.w - (drawingDimensions.w - drawingDimensions.y) * base.fillAmount;
					num2 = num4 - num6;
				}
				else
				{
					drawingDimensions.w = drawingDimensions.y + (drawingDimensions.w - drawingDimensions.y) * base.fillAmount;
					num4 = num2 + num6;
				}
			}
		}
		float num7 = drawingDimensions.z - drawingDimensions.x;
		float num8 = drawingDimensions.w - drawingDimensions.y;
		float num9 = 0f;
		float num10 = 0f;
		if (_canskew)
		{
			num9 = num8 * Mathf.Tan(Skew.x);
			num10 = num7 * Mathf.Tan(Skew.y);
		}
		s_Xy[0] = new Vector2(drawingDimensions.x + num9, drawingDimensions.y + num10);
		s_Xy[1] = new Vector2(drawingDimensions.x, drawingDimensions.w);
		s_Xy[2] = new Vector2(drawingDimensions.z, drawingDimensions.w);
		s_Xy[3] = new Vector2(drawingDimensions.z + num9, drawingDimensions.y + num10);
		s_Uv[0] = new Vector2(num, num2);
		s_Uv[1] = new Vector2(num, num4);
		s_Uv[2] = new Vector2(num3, num4);
		s_Uv[3] = new Vector2(num3, num2);
		if (base.fillAmount < 1f && base.fillMethod != 0 && base.fillMethod != FillMethod.Vertical)
		{
			if (base.fillMethod == FillMethod.Radial90)
			{
				if (RadialCut(s_Xy, s_Uv, base.fillAmount, base.fillClockwise, base.fillOrigin))
				{
					AddQuad(toFill, s_Xy, color, s_Uv);
				}
			}
			else if (base.fillMethod == FillMethod.Radial180)
			{
				for (int i = 0; i < 2; i++)
				{
					int num11 = ((base.fillOrigin > 1) ? 1 : 0);
					float t;
					float t2;
					float t3;
					float t4;
					if (base.fillOrigin == 0 || base.fillOrigin == 2)
					{
						t = 0f;
						t2 = 1f;
						if (i == num11)
						{
							t3 = 0f;
							t4 = 0.5f;
						}
						else
						{
							t3 = 0.5f;
							t4 = 1f;
						}
					}
					else
					{
						t3 = 0f;
						t4 = 1f;
						if (i == num11)
						{
							t = 0.5f;
							t2 = 1f;
						}
						else
						{
							t = 0f;
							t2 = 0.5f;
						}
					}
					s_Xy[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t3);
					s_Xy[1].x = s_Xy[0].x;
					s_Xy[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t4);
					s_Xy[3].x = s_Xy[2].x;
					s_Xy[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t);
					s_Xy[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t2);
					s_Xy[2].y = s_Xy[1].y;
					s_Xy[3].y = s_Xy[0].y;
					s_Uv[0].x = Mathf.Lerp(num, num3, t3);
					s_Uv[1].x = s_Uv[0].x;
					s_Uv[2].x = Mathf.Lerp(num, num3, t4);
					s_Uv[3].x = s_Uv[2].x;
					s_Uv[0].y = Mathf.Lerp(num2, num4, t);
					s_Uv[1].y = Mathf.Lerp(num2, num4, t2);
					s_Uv[2].y = s_Uv[1].y;
					s_Uv[3].y = s_Uv[0].y;
					float value = (base.fillClockwise ? (base.fillAmount * 2f - (float)i) : (base.fillAmount * 2f - (float)(1 - i)));
					if (RadialCut(s_Xy, s_Uv, Mathf.Clamp01(value), base.fillClockwise, (i + base.fillOrigin + 3) % 4))
					{
						AddQuad(toFill, s_Xy, color, s_Uv);
					}
				}
			}
			else
			{
				if (base.fillMethod != FillMethod.Radial360)
				{
					return;
				}
				for (int j = 0; j < 4; j++)
				{
					float t5;
					float t6;
					if (j < 2)
					{
						t5 = 0f;
						t6 = 0.5f;
					}
					else
					{
						t5 = 0.5f;
						t6 = 1f;
					}
					float t7;
					float t8;
					if (j == 0 || j == 3)
					{
						t7 = 0f;
						t8 = 0.5f;
					}
					else
					{
						t7 = 0.5f;
						t8 = 1f;
					}
					s_Xy[0].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t5);
					s_Xy[1].x = s_Xy[0].x;
					s_Xy[2].x = Mathf.Lerp(drawingDimensions.x, drawingDimensions.z, t6);
					s_Xy[3].x = s_Xy[2].x;
					s_Xy[0].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t7);
					s_Xy[1].y = Mathf.Lerp(drawingDimensions.y, drawingDimensions.w, t8);
					s_Xy[2].y = s_Xy[1].y;
					s_Xy[3].y = s_Xy[0].y;
					s_Uv[0].x = Mathf.Lerp(num, num3, t5);
					s_Uv[1].x = s_Uv[0].x;
					s_Uv[2].x = Mathf.Lerp(num, num3, t6);
					s_Uv[3].x = s_Uv[2].x;
					s_Uv[0].y = Mathf.Lerp(num2, num4, t7);
					s_Uv[1].y = Mathf.Lerp(num2, num4, t8);
					s_Uv[2].y = s_Uv[1].y;
					s_Uv[3].y = s_Uv[0].y;
					float value2 = (base.fillClockwise ? (base.fillAmount * 4f - (float)((j + base.fillOrigin) % 4)) : (base.fillAmount * 4f - (float)(3 - (j + base.fillOrigin) % 4)));
					if (RadialCut(s_Xy, s_Uv, Mathf.Clamp01(value2), base.fillClockwise, (j + 2) % 4))
					{
						AddQuad(toFill, s_Xy, color, s_Uv);
					}
				}
			}
		}
		else
		{
			AddQuad(toFill, s_Xy, color, s_Uv);
		}
	}

	private static void AddQuad(VertexHelper vertexHelper, Vector3[] quadPositions, Color32 color, Vector3[] quadUVs)
	{
		int currentVertCount = vertexHelper.currentVertCount;
		for (int i = 0; i < 4; i++)
		{
			vertexHelper.AddVert(quadPositions[i], color, quadUVs[i]);
		}
		vertexHelper.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		vertexHelper.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
	}

	private static bool RadialCut(Vector3[] xy, Vector3[] uv, float fill, bool invert, int corner)
	{
		if (fill < 0.001f)
		{
			return false;
		}
		if ((corner & 1) == 1)
		{
			invert = !invert;
		}
		if (!invert && fill > 0.999f)
		{
			return true;
		}
		float num = Mathf.Clamp01(fill);
		if (invert)
		{
			num = 1f - num;
		}
		num *= (float)Math.PI / 2f;
		float cos = Mathf.Cos(num);
		float sin = Mathf.Sin(num);
		RadialCut(xy, cos, sin, invert, corner);
		RadialCut(uv, cos, sin, invert, corner);
		return true;
	}

	private static void RadialCut(Vector3[] xy, float cos, float sin, bool invert, int corner)
	{
		int num = (corner + 1) % 4;
		int num2 = (corner + 2) % 4;
		int num3 = (corner + 3) % 4;
		if ((corner & 1) == 1)
		{
			if (sin > cos)
			{
				cos /= sin;
				sin = 1f;
				if (invert)
				{
					xy[num].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
					xy[num2].x = xy[num].x;
				}
			}
			else if (cos > sin)
			{
				sin /= cos;
				cos = 1f;
				if (!invert)
				{
					xy[num2].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
					xy[num3].y = xy[num2].y;
				}
			}
			else
			{
				cos = 1f;
				sin = 1f;
			}
			if (!invert)
			{
				xy[num3].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
			}
			else
			{
				xy[num].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
			}
			return;
		}
		if (cos > sin)
		{
			sin /= cos;
			cos = 1f;
			if (!invert)
			{
				xy[num].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
				xy[num2].y = xy[num].y;
			}
		}
		else if (sin > cos)
		{
			cos /= sin;
			sin = 1f;
			if (invert)
			{
				xy[num2].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
				xy[num3].x = xy[num2].x;
			}
		}
		else
		{
			cos = 1f;
			sin = 1f;
		}
		if (invert)
		{
			xy[num3].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
		}
		else
		{
			xy[num].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
		}
	}

	private Vector4 GetDrawingDimensions(bool shouldPreserveAspect)
	{
		Sprite sprite = ((base.overrideSprite != null) ? base.overrideSprite : base.sprite);
		Vector4 vector = ((sprite == null) ? Vector4.zero : DataUtility.GetPadding(sprite));
		Vector2 vector2 = ((sprite == null) ? Vector2.zero : new Vector2(sprite.rect.width, sprite.rect.height));
		Rect pixelAdjustedRect = GetPixelAdjustedRect();
		int num = Mathf.RoundToInt(vector2.x);
		int num2 = Mathf.RoundToInt(vector2.y);
		Vector4 vector3 = new Vector4(vector.x / (float)num, vector.y / (float)num2, ((float)num - vector.z) / (float)num, ((float)num2 - vector.w) / (float)num2);
		if (shouldPreserveAspect && vector2.sqrMagnitude > 0f)
		{
			float num3 = vector2.x / vector2.y;
			float num4 = pixelAdjustedRect.width / pixelAdjustedRect.height;
			if (num3 > num4)
			{
				float height = pixelAdjustedRect.height;
				pixelAdjustedRect.height = pixelAdjustedRect.width * (1f / num3);
				pixelAdjustedRect.y += (height - pixelAdjustedRect.height) * base.rectTransform.pivot.y;
			}
			else
			{
				float width = pixelAdjustedRect.width;
				pixelAdjustedRect.width = pixelAdjustedRect.height * num3;
				pixelAdjustedRect.x += (width - pixelAdjustedRect.width) * base.rectTransform.pivot.x;
			}
		}
		return new Vector4(pixelAdjustedRect.x + pixelAdjustedRect.width * vector3.x, pixelAdjustedRect.y + pixelAdjustedRect.height * vector3.y, pixelAdjustedRect.x + pixelAdjustedRect.width * vector3.z, pixelAdjustedRect.y + pixelAdjustedRect.height * vector3.w);
	}
}
