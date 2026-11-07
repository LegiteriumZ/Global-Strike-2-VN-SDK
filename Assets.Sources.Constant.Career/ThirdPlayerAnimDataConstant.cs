namespace Assets.Sources.Constant.Career;

internal static class ThirdPlayerAnimDataConstant
{
	public static string GetThirdPlayerAnimData(string career)
	{
		switch (career)
		{
		case "baofeng":
		case "huiselv":
		case "police":
		case "sanjiaozhou":
		case "sas":
		case "type2":
		case "ghost":
		case "meat":
		case "feihu":
		case "haiying":
		case "tezhongbing":
		case "type2_gold":
			return "manCT";
		case "death":
			return "death";
		case "doun":
			return "doun";
		case "hero":
			return "hero";
		case "howitzer":
			return "howitzer";
		case "herowoman":
			return "herowoman";
		case "howitzerwoman":
			return "howitzerwoman";
		case "phantom":
			return "phantom";
		case "twine":
			return "twine";
		case "petrified":
			return "petrified";
		case "queen":
			return "queen";
		case "death_ray":
			return "death_ray";
		case "saswoman":
		case "baofengwoman":
		case "haiyingwoman":
		case "feihuwoman":
		case "sanjiaozhouwoman":
		case "meatwoman":
		case "dajieda":
		case "luoli":
		case "lanbainvpu":
		case "heihongluoli":
		case "tongyun":
		case "aisha":
		case "schoolgirls":
		case "attendant":
		case "geiger":
		case "mirage":
			return "woman";
		case "blast":
			return "blast";
		case "boss01":
			return "boss01";
		case "boss02":
		case "boss02_1":
			return "boss02";
		case "mercenary":
		case "mercenary_1":
		case "mercenary_2":
			return "mercenary";
		case "pvepetrified":
			return "pvepetrified";
		case "researcher":
		case "researcher_1":
			return "researcher";
		case "mechfar":
			return "mechfar";
		case "mechnear":
			return "mechnear";
		default:
			return "";
		}
	}
}
