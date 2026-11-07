using UnityEngine;
using UnityEngine.Sprites;
using UnityEngine.UI;

namespace Res.Assets.Scripts.ExImage;

public class ScreenFillImage : ProtectImage
{
	public Color FillCol = Color.black;

	private Sprite activeSprite
	{
		get
		{
			if (!(base.overrideSprite != null))
			{
				return base.sprite;
			}
			return base.overrideSprite;
		}
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		if (base.sprite != null && base.overrideSprite != null && base.type == Type.Simple)
		{
			Vector4 drawingDimensions = GetDrawingDimensions(base.preserveAspect);
			Vector4 vector = ((activeSprite != null) ? DataUtility.GetOuterUV(activeSprite) : Vector4.zero);
			Color color = this.color;
			toFill.Clear();
			toFill.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.y), color, new Vector2(vector.x, vector.y));
			toFill.AddVert(new Vector3(drawingDimensions.x, drawingDimensions.w), color, new Vector2(vector.x, vector.w));
			toFill.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.w), color, new Vector2(vector.z, vector.w));
			toFill.AddVert(new Vector3(drawingDimensions.z, drawingDimensions.y), color, new Vector2(vector.z, vector.y));
			toFill.AddTriangle(0, 1, 2);
			toFill.AddTriangle(2, 3, 0);
			int startIndex = 4;
			Vector2 anchoredPosition = base.rectTransform.anchoredPosition;
			float num = Screen.height;
			float num2 = Screen.width;
			Vector4 range = new Vector4((0f - num2) / 2f - anchoredPosition.x, num2 / 2f - anchoredPosition.x, (0f - num) / 2f - anchoredPosition.y, num / 2f - anchoredPosition.y);
			Vector3 vector2 = new Vector3(drawingDimensions.x, drawingDimensions.y);
			Vector3 vector3 = new Vector3(drawingDimensions.x, drawingDimensions.w);
			Vector3 vector4 = new Vector3(drawingDimensions.z, drawingDimensions.w);
			Vector3 vector5 = new Vector3(drawingDimensions.z, drawingDimensions.y);
			AddRectImg(toFill, new Vector3(range.x, range.z), new Vector3(range.x, drawingDimensions.y), vector2, new Vector3(drawingDimensions.x, range.z), range, ref startIndex);
			AddRectImg(toFill, new Vector3(range.x, drawingDimensions.y), new Vector3(range.x, drawingDimensions.w), vector3, vector2, range, ref startIndex);
			AddRectImg(toFill, new Vector3(range.x, drawingDimensions.w), new Vector3(range.x, range.w), new Vector3(drawingDimensions.x, range.w), vector3, range, ref startIndex);
			AddRectImg(toFill, vector3, new Vector3(drawingDimensions.x, range.w), new Vector3(drawingDimensions.z, range.w), vector4, range, ref startIndex);
			AddRectImg(toFill, vector4, new Vector3(drawingDimensions.z, range.w), new Vector3(range.y, range.w), new Vector3(range.y, drawingDimensions.w), range, ref startIndex);
			AddRectImg(toFill, vector5, vector4, new Vector3(range.y, drawingDimensions.w), new Vector3(range.y, drawingDimensions.y), range, ref startIndex);
			AddRectImg(toFill, new Vector3(drawingDimensions.z, range.z), vector5, new Vector3(range.y, drawingDimensions.y), new Vector3(range.y, range.z), range, ref startIndex);
			AddRectImg(toFill, new Vector3(drawingDimensions.x, range.z), vector2, vector5, new Vector3(drawingDimensions.z, range.z), range, ref startIndex);
		}
		else
		{
			base.OnPopulateMesh(toFill);
		}
	}

	private void AddRectImg(VertexHelper toFill, Vector3 lb, Vector3 lt, Vector3 rt, Vector3 rb, Vector4 range, ref int startIndex)
	{
		lb.x = Mathf.Clamp(lb.x, range.x, range.y);
		lt.x = Mathf.Clamp(lt.x, range.x, range.y);
		rt.x = Mathf.Clamp(rt.x, range.x, range.y);
		rb.x = Mathf.Clamp(rb.x, range.x, range.y);
		lb.y = Mathf.Clamp(lb.y, range.z, range.w);
		lt.y = Mathf.Clamp(lt.y, range.z, range.w);
		rt.y = Mathf.Clamp(rt.y, range.z, range.w);
		rb.y = Mathf.Clamp(rb.y, range.z, range.w);
		Vector3 vector = rt - lb;
		if (!(Mathf.Abs(vector.x) < 0.0001f) && !(Mathf.Abs(vector.y) < 0.0001f))
		{
			toFill.AddVert(lb, FillCol, Vector2.zero);
			toFill.AddVert(lt, FillCol, Vector2.zero);
			toFill.AddVert(rt, FillCol, Vector2.zero);
			toFill.AddVert(rb, FillCol, Vector2.zero);
			toFill.AddTriangle(startIndex, startIndex + 1, startIndex + 2);
			toFill.AddTriangle(startIndex + 2, startIndex + 3, startIndex);
			startIndex += 4;
		}
	}

	private Vector4 GetDrawingDimensions(bool shouldPreserveAspect)
	{
		Vector4 vector = ((activeSprite == null) ? Vector4.zero : DataUtility.GetPadding(activeSprite));
		Vector2 vector2 = ((activeSprite == null) ? Vector2.zero : new Vector2(activeSprite.rect.width, activeSprite.rect.height));
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
