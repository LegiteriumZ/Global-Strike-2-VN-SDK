namespace Assets.Scripts.PlatformRunTime;

public class PlatformConstant
{
	public const string PLATFORM_TGP = "tgp";

	public const string PLATFORM_QQ = "qqltfk";

	public const string PLATFORM_3366 = "3366";

	public const string PLATFORM_QQGAME = "qqgame";

	public const string PLATFORM_UNION = "union";

	public const string PLATFORM_IWAN = "iwan";

	public const string PLATFORM_WEBSITE = "website";

	public const string PLATFORM_XINYUE = "xinyue";

	public const string PLATFORM_TW = "tw";

	public const string PLATFORM_GM99 = "gm99";

	public const string PLATFORM_VIETNAM = "Vietnam";

	public const string PLATFORM_VIET = "viet";

	public static bool IsTw(string platform)
	{
		if (platform == "tw" || platform == "gm99")
		{
			return true;
		}
		return false;
	}

	public static bool IsTx(string platform)
	{
		switch (platform)
		{
		case "qqltfk":
		case "3366":
		case "qqgame":
		case "tgp":
		case "iwan":
		case "website":
		case "xinyue":
		case "union":
			return true;
		default:
			return false;
		}
	}

	public static bool IsOpenBaseQualityPlatform(string platform)
	{
		if (platform == "Vietnam" || platform == "viet")
		{
			return false;
		}
		return true;
	}
}
