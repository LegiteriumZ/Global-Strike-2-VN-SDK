namespace Assets.Sources.Constant;

internal class HitBoxGroupUtilty
{
	private static bool IsHeadGroup(string boneName)
	{
		return boneName == "Bip01_Head";
	}

	private static bool IsChestGroup(string boneName)
	{
		switch (boneName)
		{
		default:
			return boneName == "Bip01_Spine3";
		case "Bip01_Neck":
		case "Bip01_Spine1":
		case "Bip01_Spine2":
			return true;
		}
	}

	private static bool IsStomachGroup(string boneName)
	{
		if (!(boneName == "Bip01_Spine"))
		{
			return boneName == "Bip01_Pelvis";
		}
		return true;
	}

	private static bool IsLeftArmGroup(string boneName)
	{
		if (!(boneName == "Bip01_L_Forearm") && !(boneName == "Bip01_L_UpperArm"))
		{
			return boneName == "Bip01_L_Hand";
		}
		return true;
	}

	private static bool IsRightArmGroup(string boneName)
	{
		if (!(boneName == "Bip01_R_UpperArm") && !(boneName == "Bip01_R_Forearm"))
		{
			return boneName == "Bip01_R_Hand";
		}
		return true;
	}

	private static bool IsDunPaiGroup(string boneName)
	{
		return boneName == "dunpai";
	}

	private static bool IsLeftLegGroup(string boneName)
	{
		if (!(boneName == "Bip01_L_Thigh") && !(boneName == "Bip01_L_Calf"))
		{
			return boneName == "Bip01_L_Foot";
		}
		return true;
	}

	private static bool IsRightLegGroup(string boneName)
	{
		if (!(boneName == "Bip01_R_Thigh") && !(boneName == "Bip01_R_Calf"))
		{
			return boneName == "Bip01_R_Foot";
		}
		return true;
	}

	public static int GetHitGroup(string boneName)
	{
		if (IsHeadGroup(boneName))
		{
			return 1;
		}
		if (IsChestGroup(boneName))
		{
			return 2;
		}
		if (IsStomachGroup(boneName))
		{
			return 3;
		}
		if (IsLeftLegGroup(boneName))
		{
			return 7;
		}
		if (IsRightLegGroup(boneName))
		{
			return 6;
		}
		if (IsLeftArmGroup(boneName))
		{
			return 4;
		}
		if (IsRightArmGroup(boneName))
		{
			return 5;
		}
		if (IsDunPaiGroup(boneName))
		{
			return 9;
		}
		return 8;
	}
}
