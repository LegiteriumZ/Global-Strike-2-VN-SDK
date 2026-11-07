using UnityEngine;
using UnityEngine.UI;

public class RoundRectImage : Image
{
	public RectTransform targetRect;

	private Rect _cacheRect;

	private void LateUpdate()
	{
		if (targetRect != null)
		{
			if (_cacheRect != targetRect.rect)
			{
				SetVerticesDirty();
			}
			_cacheRect = targetRect.rect;
		}
	}

	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		toFill.Clear();
		if (targetRect != null)
		{
			Rect rect = base.rectTransform.rect;
			Rect rect2 = targetRect.rect;
			if (rect.Overlaps(rect2))
			{
				AddRectToHelper(toFill, new Vector2(rect.xMin, rect.yMax), new Vector2(rect2.xMin, rect.yMax), new Vector2(rect2.xMin, rect.yMin), new Vector2(rect.xMin, rect.yMin));
				AddRectToHelper(toFill, new Vector2(rect2.xMax, rect.yMax), new Vector2(rect.xMax, rect.yMax), new Vector2(rect.xMax, rect.yMin), new Vector2(rect2.xMax, rect.yMin));
				AddRectToHelper(toFill, new Vector2(rect2.xMin, rect.yMax), new Vector2(rect2.xMax, rect.yMax), new Vector2(rect2.xMax, rect2.yMax), new Vector2(rect2.xMin, rect2.yMax));
				AddRectToHelper(toFill, new Vector2(rect2.xMin, rect2.yMin), new Vector2(rect2.xMax, rect2.yMin), new Vector2(rect2.xMax, rect.yMin), new Vector2(rect2.xMin, rect.yMin));
			}
		}
	}

	private void AddRectToHelper(VertexHelper toFill, Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
	{
		Color32 color = this.color;
		toFill.AddVert(p1, color, new Vector2(0f, 1f));
		toFill.AddVert(p2, color, new Vector2(1f, 1f));
		toFill.AddVert(p3, color, new Vector2(1f, 0f));
		toFill.AddVert(p4, color, new Vector2(0f, 0f));
		int num = toFill.currentVertCount - 1;
		toFill.AddTriangle(num - 3, num - 2, num - 1);
		toFill.AddTriangle(num - 1, num, num - 3);
	}
}
