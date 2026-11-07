using UnityEngine;

namespace Assets.Sources.Free.Utility;

public class ImageCoverUv
{
	public Vector2 leftTop;

	public Vector2 rightTop;

	public Vector2 leftBottom;

	public Vector2 rightBottom;

	public int coverX;

	public int coverY;

	public override string ToString()
	{
		return string.Concat("coverX: ", coverX, " coverY: ", coverY, " leftTop: ", leftTop, " rightTop: ", rightTop, "  leftBottom: ", leftBottom, " rightBottom： ", rightBottom);
	}
}
