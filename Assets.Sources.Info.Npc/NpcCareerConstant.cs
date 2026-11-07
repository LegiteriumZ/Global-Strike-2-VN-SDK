namespace Assets.Sources.Info.Npc;

public class NpcCareerConstant
{
	public const string TURKEY = "turkey";

	public const string XIAOTIANLANG = "xiaotianlang";

	public const string RAPTOR = "raptor";

	public const string VIPPET = "vippet";

	public const string POLYPIDE = "polypide";

	public const string DRAGOON01 = "dragoon01";

	public const string DRAGOON01_A1 = "dragoon01_a1";

	public const string DRAGOON02_A1 = "dragoon02_a1";

	public const string DRAGOON02_A2 = "dragoon02_a2";

	public const string DRAGOON03_A = "dragoon03_a";

	public const string DRAGOON03_B = "dragoon03_b";

	public const string DRAGOON03_C = "dragoon03_c";

	public const string rpg_11000001 = "rpg_11000001";

	public const string rpg_11000002 = "rpg_11000002";

	public const string rpg_11000003 = "rpg_11000003";

	public const string RPG_HANHAN = "rpg_hanhan";

	public const string RPG_JACK5 = "rpg_jack5";

	public const string ROCKER_HAMSTER01 = "rocketHamster01";

	public const string ROCKER_HAMSTER02 = "rocketHamster02";

	public const string ROCKER_HAMSTER03 = "rocketHamster03";

	public const string JIGUAN_BIRD01 = "jiguan_bird01";

	public const string JIGUAN_BIRD02 = "jiguan_bird02";

	public const string JIGUAN_BIRD03 = "jiguan_bird03";

	public const string JIGUAN_DEER01 = "jiguan_deer01";

	public const string JIGUAN_DEER02 = "jiguan_deer02";

	public const string JIGUAN_DEER03 = "jiguan_deer03";

	public const string SPIRITS_SWORD_NPC = "spirits_sword_npc";

	public const string JIGUAN_LONG01 = "jiguan_long01";

	public const string JIGUAN_LONG02 = "jiguan_long02";

	public const string JIGUAN_LONG03 = "jiguan_long03";

	public const string DOG_SANJIAOLONG = "dog_sanjiaolong";

	public const string DOG_JIALONG = "dog_jialong";

	public const string DOG_BAWANGLONG = "dog_bawanglong";

	public const string DOG_YILONG = "dog_yilong";

	public static int GetNpcNameHeight(string codeName)
	{
		switch (codeName)
		{
		case "xiaotianlang":
		case "raptor":
			return 80;
		case "vippet":
		case "rpg_11000001":
		case "rpg_11000002":
		case "rpg_jack5":
		case "dog_sanjiaolong":
		case "dog_bawanglong":
			return 130;
		case "dog_yilong":
		case "rpg_11000003":
			return 220;
		case "rocketHamster01":
		case "rocketHamster02":
		case "rocketHamster03":
		case "dog_jialong":
			return 150;
		default:
			return 100;
		}
	}
}
