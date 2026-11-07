namespace Assets.Scripts.PlatformRunTime;

internal class PlatformRunTime
{
	public static bool CanRunTime(string clientPlatform, string bootConfigPlatform)
	{
		if (clientPlatform == "AVC")
		{
			if (PlatformConstant.IsTx(bootConfigPlatform))
			{
				return true;
			}
			return false;
		}
		return true;
	}
}
