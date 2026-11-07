namespace Assets.Sources.Constant;

public class SceneBufTypeUtility
{
	public const string Stronghold = "stronghold";

	public const string Kongzhiqi = "kongzhiqi";

	public const string Kongzhiqi1 = "kongzhiqi1";

	public const string Kongzhiqi2 = "kongzhiqi2";

	public const string YINYANG_GRENADE_BIG_MIRROR = "YINYANG_GRENADE_BIG_MIRROR";

	public static bool IsSkillBuffer(string bufferName)
	{
		if (SkillNameConstant.InSkillNameList(bufferName))
		{
			return true;
		}
		return false;
	}

	public static bool IsYingyangBigMirror(string bufferName)
	{
		return bufferName == "YINYANG_GRENADE_BIG_MIRROR";
	}

	public static int ConvertYinyangHyPlayerId(int playerId)
	{
		return -playerId + 999999;
	}
}
