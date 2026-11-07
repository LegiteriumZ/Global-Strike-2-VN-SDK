using SSJJBase.Logger;

namespace Assets.Sources.Utils;

public class UnloadSign
{
	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(UnloadSign));

	public static float UnloadThirdResTime;

	public static bool UnloadThirdRes;

	public static float UnloadPoolResTime;

	public static bool UnloadPoolRes;

	public static void CheckUnload(float time)
	{
		if (time - UnloadPoolResTime > 210f)
		{
			UnloadPoolResTime = time;
			UnloadPoolRes = true;
		}
		if (time - UnloadThirdResTime > 260f)
		{
			UnloadThirdResTime = time;
			UnloadThirdRes = true;
		}
	}
}
