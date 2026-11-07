namespace Assets.Sources.Free.Effect;

public class RaderImage
{
	public string RadarImage;

	public float ScaleX;

	public float ScaleY;

	public float Alpha;

	public string SmallMapFullImg;

	public float RealWidth;

	public float RealHeight;

	public bool RotateWithRader;

	public int Mask;

	public RaderImage()
	{
		ScaleX = 100f;
		ScaleY = 100f;
		Alpha = 100f;
		RadarImage = "";
		SmallMapFullImg = "";
	}

	public bool IsMask()
	{
		return Mask == 1;
	}

	public bool UseMask()
	{
		if (Mask != 2)
		{
			return Mask == 4;
		}
		return true;
	}

	public bool IsFull()
	{
		if (Mask != 3)
		{
			return Mask == 4;
		}
		return true;
	}
}
