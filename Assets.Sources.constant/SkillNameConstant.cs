namespace Assets.Sources.Constant;

public class SkillNameConstant
{
	public const string Ammunitionpackage = "AMMUNITIONPACKAGE";

	public const string Medicalpackage = "MEDICALPACKAGE";

	public const string Fever = "FEVER";

	public const string Accelerate = "ACCELERATE";

	public const string Bighradamplifier = "BIGHRADAMPLIFIER";

	public const string Damagedeepen = "DAMAGEDEEPEN";

	public const string Physicalfitness = "PHYSICALFITNESS";

	public const string Lingboweibu = "LINGBOWEIBU";

	public const string Jumpintensify = "JUMPINTENSIFY";

	public const string Stealth = "STEALTH";

	public const string Selfexplosion = "SELFEXPLOSION";

	public const string Bombintensify = "BOMBINTENSIFY";

	public const string Energyshield = "ENERGYSHIELD";

	public const string Herosword = "HEROSWORD";

	public const string Addhpbuffer = "ADDHPBUFFER";

	public const string MachineA = "MACHINE_A";

	public const string MachineB = "MACHINE_B";

	public const string MachineC = "MACHINE_C";

	public const string MachineD = "MACHINE_D";

	public const string MachineE = "MACHINE_E";

	public const string MachineF = "MACHINE_F";

	public const string MachineG = "MACHINE_G";

	public const string MachineH = "MACHINE_H";

	public const string RifleA = "RIFLE_A";

	public const string RifleB = "RIFLE_B";

	public const string RifleC = "RIFLE_C";

	public const string RifleD = "RIFLE_D";

	public const string RifleE = "RIFLE_E";

	public const string RifleF = "RIFLE_F";

	public const string RifleG = "RIFLE_G";

	public const string RifleH = "RIFLE_H";

	public const string SniperA = "SNIPER_A";

	public const string SniperB = "SNIPER_B";

	public const string SniperC = "SNIPER_C";

	public const string SniperD = "SNIPER_D";

	public const string SniperE = "SNIPER_E";

	public const string SniperF = "SNIPER_F";

	public const string SniperG = "SNIPER_G";

	public const string SniperH = "SNIPER_H";

	public const string ShotgunA = "SHOTGUN_A";

	public const string ShotgunB = "SHOTGUN_B";

	public const string ShotgunC = "SHOTGUN_C";

	public const string ShotgunD = "SHOTGUN_D";

	public const string ShotgunE = "SHOTGUN_E";

	public const string ShotgunF = "SHOTGUN_F";

	public const string ShotgunG = "SHOTGUN_G";

	public const string ShotgunH = "SHOTGUN_H";

	public const string ShotgunJ = "SHOTGUN_J";

	public const string ShotgunM = "SHOTGUN_M";

	public const string GeneralI = "GENERAL_I";

	public const string GeneralJ = "GENERAL_J";

	public const string GeneralK = "GENERAL_K";

	public const string GeneralL = "GENERAL_L";

	public const string GeneralM = "GENERAL_M";

	public static bool InSkillNameList(string skillName)
	{
		switch (skillName)
		{
		case "AMMUNITIONPACKAGE":
		case "MEDICALPACKAGE":
		case "ACCELERATE":
		case "BIGHRADAMPLIFIER":
		case "DAMAGEDEEPEN":
		case "PHYSICALFITNESS":
		case "LINGBOWEIBU":
		case "JUMPINTENSIFY":
		case "STEALTH":
		case "SELFEXPLOSION":
		case "BOMBINTENSIFY":
		case "ENERGYSHIELD":
		case "ADDHPBUFFER":
			return true;
		default:
			return false;
		}
	}

	public static int GetSkillIndex(string skillName)
	{
		switch (skillName)
		{
		case "AMMUNITIONPACKAGE":
			return 1;
		case "MEDICALPACKAGE":
		case "ADDHPBUFFER":
			return 8;
		case "ACCELERATE":
			return 0;
		case "BIGHRADAMPLIFIER":
			return 2;
		case "DAMAGEDEEPEN":
			return 4;
		case "PHYSICALFITNESS":
			return 9;
		case "LINGBOWEIBU":
			return 7;
		case "JUMPINTENSIFY":
			return 6;
		case "STEALTH":
			return 11;
		case "SELFEXPLOSION":
			return 10;
		case "BOMBINTENSIFY":
			return 3;
		case "ENERGYSHIELD":
			return 5;
		default:
			return 0;
		}
	}

	public static bool IsDisposableSkill(string skillName)
	{
		if ("AMMUNITIONPACKAGE" == skillName || "MEDICALPACKAGE" == skillName || "FEVER" == skillName || "ACCELERATE" == skillName || "BIGHRADAMPLIFIER" == skillName || "ADDHPBUFFER" == skillName)
		{
			return true;
		}
		return false;
	}
}
