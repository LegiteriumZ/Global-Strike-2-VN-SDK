using System.Collections.Generic;
using careerConfigPackage;
using share.constant;

namespace Assets.Sources.Constant.Career;

public class PlayerCareerConstantUtility
{
	public static string Rpg10500002 = "rpg_10500002";

	private static Dictionary<string, int> _careerHeights = new Dictionary<string, int>
	{
		{ "death", 290 },
		{ "kingslayer", 290 },
		{ "doun", 200 },
		{ "snake_doun", 200 },
		{ "howitzer", 220 },
		{ "howitzer_skyfire", 220 },
		{ "howitzerwoman", 190 },
		{ "howitzerwoman_skyfire", 190 },
		{ "queen", 230 },
		{ "phantom", 170 },
		{ "petrified", 220 },
		{ "metalman", 220 },
		{ "boss06", 1500 },
		{ "mechfar", 400 },
		{ "mechfar2", 300 },
		{ "mechnear", 400 },
		{ "mechbomberman", 400 },
		{ "boss08", 500 },
		{ "boss09", 700 },
		{ "boss10", 400 },
		{ "boss1007", 400 },
		{ "rpg_carbrite_captain", 400 },
		{ "cat", 90 },
		{ "pig", 80 },
		{ "chicken", 120 },
		{ "rpg_10004121", 300 },
		{ "rpg_10003116", 300 },
		{ "rpg_10003125", 350 },
		{ "rpg_minion_parasitism", 250 },
		{ "rpg_minion_boomer", 300 },
		{ "rpg_cabrite_captain", 350 },
		{ "pvegatling", 250 },
		{ "pvepetrified_1", 250 },
		{ "rpg_minion_boomer2", 300 },
		{ "rpg_cabrite_5", 200 },
		{ "rpg_10003107", 250 },
		{ "rpg_10003117", 250 },
		{ "rpg_10004101", 220 },
		{ "p3hero", 220 },
		{ "pandoraMonther_baigu", 205 }
	};

	private static HashSet<string> _careerHeightScale = new HashSet<string> { "cat", "pig", "chicken" };

	private static Dictionary<string, int> _careerHeightOffset = new Dictionary<string, int>
	{
		{ "cat", 10 },
		{ "pig", 10 },
		{ "chicken", 10 },
		{ "weapon_cat", 10 },
		{ "weapon_pig", 10 },
		{ "weapon_chicken", 10 }
	};

	public static bool IsMech(string career)
	{
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		if (PlayerCareerUtil.IsMech(career) || PlayerCareerUtil.IsMech2(career))
		{
			return true;
		}
		return false;
	}

	public static bool IsMechKing(string career)
	{
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		if (career == "mech_king" || career == "mechnear")
		{
			return true;
		}
		return false;
	}

	public static bool IsHumanity(string career)
	{
		switch (career)
		{
		case "rpg_10004108":
			return false;
		case "rpg_10004109":
			return false;
		case "rpg_10004110":
			return false;
		default:
			if (string.IsNullOrEmpty(career))
			{
				return false;
			}
			return PlayerCareerUtil.IsHumanity(career);
		}
	}

	public static bool IsDoun(string career)
	{
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		return PlayerCareerUtil.IsNormalZombie(career);
	}

	public static bool IsEmpress(string career)
	{
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		return PlayerCareerUtil.IsZombieHero(career);
	}

	public static bool IsNoHuMan(string career)
	{
		if (!IsDoun(career) && !IsEmpress(career))
		{
			return IsHero(career);
		}
		return true;
	}

	public static bool IsFemale(string career)
	{
		switch (career)
		{
		case "herowoman":
		case "herowoman_close":
		case "herowoman_gun":
		case "herowoman_skyfire":
		case "howitzerwoman":
		case "howitzerwoman_skyfire":
			return true;
		default:
			return false;
		}
	}

	public static bool IsHero(string career)
	{
		return PlayerCareerUtil.IsHumanHero(career);
	}

	public static bool IsHaveOwerStepSound(string career)
	{
		if (string.IsNullOrEmpty(career))
		{
			return false;
		}
		switch (career)
		{
		default:
			if (!PlayerCareerUtil.IsMech2(career))
			{
				return false;
			}
			goto case "mechfar";
		case "mechfar":
		case "mechnear":
		case "mechbomberman":
		case "cat":
			return true;
		}
	}

	public static bool IsRemoteVariant(string career)
	{
		switch (career)
		{
		case "pvegunman":
		case "pveawp":
		case "pverocket_1":
		case "pverocket_2":
			return true;
		default:
			return false;
		}
	}

	public static int GetHeight(string career, float scale = 0f)
	{
		if (!_careerHeights.TryGetValue(career, out var value) && !string.IsNullOrEmpty(career))
		{
			PlayerCareerConfig config = CareerConfigManager.GetInstance().GetConfig(career);
			if (config != null)
			{
				value = (int)config.careerHeight;
			}
		}
		if (_careerHeightScale.Contains(career))
		{
			value = (int)((float)value * (1f + scale));
		}
		if (_careerHeightOffset.TryGetValue(career, out var value2))
		{
			value += value2;
		}
		return value;
	}

	public static bool IsShowShield(string career)
	{
		switch (career)
		{
		case "rpg_bookofdoom":
		case "rpg_bookofdoom1":
		case "rpg_bookofdoom2":
		case "rpg_skin_bookofdoom_forest":
		case "rpg_skin_bookofdoom_magic_elf":
			return false;
		default:
			return true;
		}
	}
}
