namespace Assets.Sources.Utils;

public class TextureUnit
{
	public string TextureName;

	public int Width;

	public int Height;

	public string ToSave()
	{
		return TextureName + "_" + Width + "_" + Height;
	}
}
