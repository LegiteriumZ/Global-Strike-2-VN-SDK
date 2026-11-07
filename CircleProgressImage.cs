using System;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CircleProgressImage : Image
{
	private static readonly Vector3[] s_Xy = new Vector3[4];

	private static readonly Vector3[] s_Uv = new Vector3[4];

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		if (base.overrideSprite == null)
		{
			base.OnPopulateMesh(toFill);
			return;
		}
		switch (base.type)
		{
		case Type.Simple:
		case Type.Sliced:
		case Type.Tiled:
			base.OnPopulateMesh(toFill);
			break;
		case Type.Filled:
			GenerateFilledSprite(toFill, base.preserveAspect);
			break;
		}
	}

	private void GenerateFilledSprite(VertexHelper toFill, bool preserveAspect)
	{
		toFill.Clear();
		if (base.fillAmount < 0.001f)
		{
			return;
		}
		Vector4 vector = new Vector4(base.overrideSprite.rect.x, base.overrideSprite.rect.y, base.overrideSprite.rect.width, base.overrideSprite.rect.height);
		Vector4 vector2 = new Vector4(0f, 0f, 1f, 1f);
		UIVertex simpleVert = UIVertex.simpleVert;
		simpleVert.color = color;
		float num = vector2.x;
		float num2 = vector2.y;
		float num3 = vector2.z;
		float num4 = vector2.w;
		if (base.fillMethod == FillMethod.Horizontal || base.fillMethod == FillMethod.Vertical)
		{
			if (base.fillMethod == FillMethod.Horizontal)
			{
				float num5 = (num3 - num) * base.fillAmount;
				if (base.fillOrigin == 1)
				{
					vector.x = vector.z - (vector.z - vector.x) * base.fillAmount;
					num = num3 - num5;
				}
				else
				{
					vector.z = vector.x + (vector.z - vector.x) * base.fillAmount;
					num3 = num + num5;
				}
			}
			else if (base.fillMethod == FillMethod.Vertical)
			{
				float num6 = (num4 - num2) * base.fillAmount;
				if (base.fillOrigin == 1)
				{
					vector.y = vector.w - (vector.w - vector.y) * base.fillAmount;
					num2 = num4 - num6;
				}
				else
				{
					vector.w = vector.y + (vector.w - vector.y) * base.fillAmount;
					num4 = num2 + num6;
				}
			}
		}
		s_Xy[0] = new Vector2(vector.x, vector.y);
		s_Xy[1] = new Vector2(vector.x, vector.w);
		s_Xy[2] = new Vector2(vector.z, vector.w);
		s_Xy[3] = new Vector2(vector.z, vector.y);
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
					int num7 = ((base.fillOrigin > 1) ? 1 : 0);
					float t;
					float t2;
					float t3;
					float t4;
					if (base.fillOrigin == 0 || base.fillOrigin == 2)
					{
						t = 0f;
						t2 = 1f;
						if (i == num7)
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
						if (i == num7)
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
					s_Xy[0].x = Mathf.Lerp(vector.x, vector.z, t3);
					s_Xy[1].x = s_Xy[0].x;
					s_Xy[2].x = Mathf.Lerp(vector.x, vector.z, t4);
					s_Xy[3].x = s_Xy[2].x;
					s_Xy[0].y = Mathf.Lerp(vector.y, vector.w, t);
					s_Xy[1].y = Mathf.Lerp(vector.y, vector.w, t2);
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
					s_Xy[0].x = Mathf.Lerp(vector.x, vector.z, t5);
					s_Xy[1].x = s_Xy[0].x;
					s_Xy[2].x = Mathf.Lerp(vector.x, vector.z, t6);
					s_Xy[3].x = s_Xy[2].x;
					s_Xy[0].y = Mathf.Lerp(vector.y, vector.w, t7);
					s_Xy[1].y = Mathf.Lerp(vector.y, vector.w, t8);
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

	private static void AddQuad(VertexHelper vertexHelper, Vector2 posMin, Vector2 posMax, Color32 color, Vector2 uvMin, Vector2 uvMax)
	{
		int currentVertCount = vertexHelper.currentVertCount;
		vertexHelper.AddVert(new Vector3(posMin.x, posMin.y, 0f), color, new Vector2(uvMin.x, uvMin.y));
		vertexHelper.AddVert(new Vector3(posMin.x, posMax.y, 0f), color, new Vector2(uvMin.x, uvMax.y));
		vertexHelper.AddVert(new Vector3(posMax.x, posMax.y, 0f), color, new Vector2(uvMax.x, uvMax.y));
		vertexHelper.AddVert(new Vector3(posMax.x, posMin.y, 0f), color, new Vector2(uvMax.x, uvMin.y));
		vertexHelper.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		vertexHelper.AddTriangle(currentVertCount + 2, currentVertCount + 3, currentVertCount);
	}
}
