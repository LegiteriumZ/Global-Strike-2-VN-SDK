using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

[AddComponentMenu("UI/Circle Image")]
public class CircleImage : Image
{
	[Tooltip("圆形或扇形填充比例")]
	[Range(0f, 1f)]
	public float fillPercent = 1f;

	[Tooltip("是否填充圆形")]
	public bool fill = true;

	[Tooltip("圆环宽度")]
	public float thickness = 5f;

	[Tooltip("圆形")]
	[Range(3f, 100f)]
	public int segements = 20;

	[Range(0f, 1f)]
	public float uvscale = 1f;

	[Range(-1f, 1f)]
	public float uvoffsetx;

	[Range(-1f, 1f)]
	public float uvoffsety;

	[Range(0f, 1f)]
	public float uvtexx = 1f;

	[Range(0f, 1f)]
	public float uvtexy = 1f;

	public Vector2 inneroffset;

	private List<Vector3> innerVertices;

	private List<Vector3> outterVertices;

	protected override void Awake()
	{
		base.Awake();
		innerVertices = new List<Vector3>();
		outterVertices = new List<Vector3>();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		innerVertices.Clear();
		outterVertices.Clear();
		float num = (float)Math.PI * 2f / (float)segements;
		int num2 = (int)((float)segements * fillPercent);
		float width = base.rectTransform.rect.width;
		float height = base.rectTransform.rect.height;
		float num3 = base.rectTransform.pivot.x * width;
		float num4 = base.rectTransform.pivot.x * width - thickness;
		Vector4 vector = ((base.overrideSprite != null) ? DataUtility.GetOuterUV(base.overrideSprite) : Vector4.zero);
		if (base.overrideSprite != null)
		{
			width = base.overrideSprite.textureRect.width;
			height = base.overrideSprite.textureRect.height;
		}
		else
		{
			width = base.sprite.textureRect.width;
			height = base.sprite.textureRect.height;
		}
		float num5 = (uvoffsetx + (vector.x + vector.z) * 0.5f) * uvscale;
		float num6 = (uvoffsety + (vector.y + vector.w) * 0.5f) * uvscale;
		float num7 = (vector.z - vector.x) / width * uvtexx;
		float num8 = (vector.w - vector.y) / height * uvtexy;
		float num9 = 0f;
		int num10;
		int num13;
		if (fill)
		{
			Vector2 zero = Vector2.zero;
			num10 = num2 + 1;
			UIVertex v = default(UIVertex);
			v.color = color;
			v.position = zero;
			v.uv0 = new Vector2(zero.x * num7 + num5, zero.y * num8 + num6);
			vh.AddVert(v);
			for (int i = 1; i < num10; i++)
			{
				float num11 = Mathf.Cos(num9);
				float num12 = Mathf.Sin(num9);
				zero = new Vector2(num11 * num3, num12 * num3);
				num9 += num;
				v = default(UIVertex);
				v.color = color;
				v.position = zero;
				v.uv0 = new Vector2(zero.x * num7 + num5, zero.y * num8 + num6);
				vh.AddVert(v);
				outterVertices.Add(zero);
			}
			num13 = num2 * 3;
			int num14 = 0;
			int num15 = 1;
			while (num14 < num13 - 3)
			{
				vh.AddTriangle(num15, 0, num15 + 1);
				num14 += 3;
				num15++;
			}
			if (fillPercent == 1f)
			{
				vh.AddTriangle(num10 - 1, 0, 1);
			}
			return;
		}
		num10 = num2 * 2;
		for (int j = 0; j < num10; j += 2)
		{
			float num16 = Mathf.Cos(num9);
			float num17 = Mathf.Sin(num9);
			num9 += num;
			Vector2 zero = new Vector3(inneroffset.x + num16 * num4, inneroffset.y + num17 * num4);
			UIVertex v = default(UIVertex);
			v.color = color;
			v.position = zero;
			v.uv0 = new Vector2(zero.x * num7 + num5, zero.y * num8 + num6);
			vh.AddVert(v);
			innerVertices.Add(zero);
			zero = new Vector3(num16 * num3, num17 * num3);
			v = default(UIVertex);
			v.color = color;
			v.position = zero;
			v.uv0 = new Vector2(zero.x * num7 + num5, zero.y * num8 + num6);
			vh.AddVert(v);
			outterVertices.Add(zero);
		}
		num13 = num2 * 3 * 2;
		int num18 = 0;
		int num19 = 0;
		while (num18 < num13 - 6)
		{
			vh.AddTriangle(num19 + 1, num19, num19 + 3);
			vh.AddTriangle(num19, num19 + 2, num19 + 3);
			num18 += 6;
			num19 += 2;
		}
		if (fillPercent == 1f)
		{
			vh.AddTriangle(num10 - 1, num10 - 2, 1);
			vh.AddTriangle(num10 - 2, 0, 1);
		}
	}

	public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
	{
		if (base.overrideSprite == null)
		{
			return true;
		}
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, screenPoint, eventCamera, out var localPoint);
		return Contains(localPoint, outterVertices, innerVertices);
	}

	private bool Contains(Vector2 p, List<Vector3> outterVertices, List<Vector3> innerVertices)
	{
		int crossNumber = 0;
		RayCrossing(p, innerVertices, ref crossNumber);
		RayCrossing(p, outterVertices, ref crossNumber);
		return (crossNumber & 1) == 1;
	}

	private void RayCrossing(Vector2 p, List<Vector3> vertices, ref int crossNumber)
	{
		int i = 0;
		for (int count = vertices.Count; i < count; i++)
		{
			Vector3 vector = vertices[i];
			Vector3 vector2 = vertices[(i + 1) % count];
			if (((vector.y <= p.y && vector2.y > p.y) || (vector.y > p.y && vector2.y <= p.y)) && p.x < vector.x + (p.y - vector.y) / (vector2.y - vector.y) * (vector2.x - vector.x))
			{
				crossNumber++;
			}
		}
	}
}
