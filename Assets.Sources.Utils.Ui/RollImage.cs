using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace Assets.Sources.Utils.Ui;

public class RollImage : Image
{
	[SerializeField]
	[Range(0f, 1f)]
	public float _RollXAmount = 1f;

	[SerializeField]
	[Range(0f, 1f)]
	public float _UvxRange = 1f;

	public float RollXAmount
	{
		get
		{
			return _RollXAmount;
		}
		set
		{
			_RollXAmount = value;
			SetAllDirty();
		}
	}

	public float UvxRange
	{
		get
		{
			return _UvxRange;
		}
		set
		{
			_UvxRange = value;
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
			Sprite sprite = ((base.overrideSprite != null) ? base.overrideSprite : base.sprite);
			Vector4 drawingDimensions = GetDrawingDimensions(base.preserveAspect);
			Vector4 vector = ((sprite != null) ? DataUtility.GetOuterUV(sprite) : Vector4.zero);
			Color color = this.color;
			toFill.Clear();
			float x = vector.x;
			float z = vector.z;
			float num = drawingDimensions.z - drawingDimensions.x;
			float num2 = (z - x) * UvxRange;
			z = x + num2;
			float num3 = num * RollXAmount;
			float x2 = vector.x + num2 * (1f - RollXAmount);
			toFill.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.y), color, new Vector2(x2, vector.y));
			toFill.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.w), color, new Vector2(x2, vector.w));
			toFill.AddVert(new Vector3(drawingDimensions.x + num3, drawingDimensions.w), color, new Vector2(z, vector.w));
			toFill.AddVert(new Vector3(drawingDimensions.x + num3, drawingDimensions.y), color, new Vector2(z, vector.y));
			toFill.AddTriangle(0, 1, 2);
			toFill.AddTriangle(2, 3, 0);
			if (Mathf.Abs(RollXAmount - 1f) > 0.001f)
			{
				toFill.AddVert(new Vector3(drawingDimensions.x + num3, drawingDimensions.y), color, new Vector2(x, vector.y));
				toFill.AddVert(new Vector3(drawingDimensions.x + num3, drawingDimensions.w), color, new Vector2(x, vector.w));
				toFill.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.w), color, new Vector2(x2, vector.w));
				toFill.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.y), color, new Vector2(x2, vector.y));
				toFill.AddTriangle(4, 5, 6);
				toFill.AddTriangle(6, 7, 4);
			}
		}
		else
		{
			base.OnPopulateMesh(toFill);
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
