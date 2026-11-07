using Assets.Sources.Constant;
using Assets.Sources.Modules.Player.Attack.Action;

namespace Assets.Sources.Modules.Player.Attack.Utils;

public class WolfClawConfig
{
	private static WolfClawConfig[] _doubleConfigs = new WolfClawConfig[3]
	{
		new WolfClawConfig
		{
			MinCount = 0,
			MaxCount = 0,
			Min = 1000,
			Max = 2000,
			AddDist = 0f,
			Effect = 0,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 1,
			MaxCount = 1,
			Min = 1000,
			Max = 2000,
			AddDist = 0.1f,
			Effect = 1,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 2,
			MaxCount = 2,
			Min = 1000,
			Max = 1500,
			AddDist = 0.15f,
			Effect = 2,
			Offset = -40,
			Pardon = 80
		}
	};

	private static WolfClawConfig[] _rpgDoubleConfigs = new WolfClawConfig[8]
	{
		new WolfClawConfig
		{
			MinCount = 0,
			MaxCount = 0,
			Min = 1000,
			Max = 2000,
			AddDist = 0f,
			Effect = 0,
			Offset = -50,
			Pardon = 200
		},
		new WolfClawConfig
		{
			MinCount = 1,
			MaxCount = 1,
			Min = 1000,
			Max = 2000,
			AddDist = 0.1f,
			Effect = 1,
			Offset = -50,
			Pardon = 200
		},
		new WolfClawConfig
		{
			MinCount = 2,
			MaxCount = 5,
			Min = 1000,
			Max = 1500,
			AddDist = 0.15f,
			Effect = 2,
			Offset = -50,
			Pardon = 150
		},
		new WolfClawConfig
		{
			MinCount = 6,
			MaxCount = 10,
			Min = 800,
			Max = 1200,
			AddDist = 0.25f,
			Effect = 3,
			Offset = -40,
			Pardon = 125
		},
		new WolfClawConfig
		{
			MinCount = 11,
			MaxCount = 15,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -40,
			Pardon = 100
		},
		new WolfClawConfig
		{
			MinCount = 16,
			MaxCount = 30,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -30,
			Pardon = 90
		},
		new WolfClawConfig
		{
			MinCount = 31,
			MaxCount = 60,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -30,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 61,
			MaxCount = 999,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -25,
			Pardon = 70
		}
	};

	private static WolfClawConfig[] _samuraiSwordDoubleConfigs = new WolfClawConfig[4]
	{
		new WolfClawConfig
		{
			MinCount = 0,
			MaxCount = 0,
			Min = 1000,
			Max = 2000,
			AddDist = 0f,
			Effect = 0,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 1,
			MaxCount = 1,
			Min = 500,
			Max = 1000,
			AddDist = 0.1f,
			Effect = 1,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 2,
			MaxCount = 2,
			Min = 400,
			Max = 800,
			AddDist = 0.15f,
			Effect = 2,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 3,
			MaxCount = 3,
			Min = 300,
			Max = 600,
			AddDist = 0.15f,
			Effect = 3,
			Offset = -40,
			Pardon = 80
		}
	};

	private static WolfClawConfig[] _samuraiSwordRpgDoubleConfigs = new WolfClawConfig[8]
	{
		new WolfClawConfig
		{
			MinCount = 0,
			MaxCount = 0,
			Min = 1000,
			Max = 2000,
			AddDist = 0f,
			Effect = 0,
			Offset = -50,
			Pardon = 200
		},
		new WolfClawConfig
		{
			MinCount = 1,
			MaxCount = 1,
			Min = 1000,
			Max = 2000,
			AddDist = 0.1f,
			Effect = 1,
			Offset = -50,
			Pardon = 200
		},
		new WolfClawConfig
		{
			MinCount = 2,
			MaxCount = 5,
			Min = 1000,
			Max = 1500,
			AddDist = 0.15f,
			Effect = 2,
			Offset = -50,
			Pardon = 150
		},
		new WolfClawConfig
		{
			MinCount = 6,
			MaxCount = 10,
			Min = 800,
			Max = 1200,
			AddDist = 0.25f,
			Effect = 3,
			Offset = -40,
			Pardon = 125
		},
		new WolfClawConfig
		{
			MinCount = 11,
			MaxCount = 15,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 3,
			Offset = -40,
			Pardon = 100
		},
		new WolfClawConfig
		{
			MinCount = 16,
			MaxCount = 30,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 3,
			Offset = -30,
			Pardon = 90
		},
		new WolfClawConfig
		{
			MinCount = 31,
			MaxCount = 60,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 3,
			Offset = -30,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 61,
			MaxCount = 999,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 3,
			Offset = -25,
			Pardon = 70
		}
	};

	private static WolfClawConfig[] _awakeClawDoubleConfigs = new WolfClawConfig[5]
	{
		new WolfClawConfig
		{
			MinCount = 0,
			MaxCount = 0,
			Min = 1000,
			Max = 2000,
			AddDist = 0f,
			Effect = 0,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 1,
			MaxCount = 1,
			Min = 1000,
			Max = 2000,
			AddDist = 0.1f,
			Effect = 1,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 2,
			MaxCount = 2,
			Min = 1000,
			Max = 1500,
			AddDist = 0.15f,
			Effect = 2,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 3,
			MaxCount = 3,
			Min = 800,
			Max = 1200,
			AddDist = 0.2f,
			Effect = 2,
			Offset = -40,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 4,
			MaxCount = 4,
			Min = 800,
			Max = 1200,
			AddDist = 0.25f,
			Effect = 2,
			Offset = -40,
			Pardon = 80
		}
	};

	private static WolfClawConfig[] _awakeClawRpgDoubleConfigs = new WolfClawConfig[8]
	{
		new WolfClawConfig
		{
			MinCount = 0,
			MaxCount = 0,
			Min = 1000,
			Max = 2000,
			AddDist = 0f,
			Effect = 0,
			Offset = -50,
			Pardon = 200
		},
		new WolfClawConfig
		{
			MinCount = 1,
			MaxCount = 1,
			Min = 1000,
			Max = 2000,
			AddDist = 0.1f,
			Effect = 1,
			Offset = -50,
			Pardon = 200
		},
		new WolfClawConfig
		{
			MinCount = 2,
			MaxCount = 5,
			Min = 1000,
			Max = 1500,
			AddDist = 0.15f,
			Effect = 2,
			Offset = -50,
			Pardon = 150
		},
		new WolfClawConfig
		{
			MinCount = 6,
			MaxCount = 10,
			Min = 800,
			Max = 1200,
			AddDist = 0.25f,
			Effect = 3,
			Offset = -40,
			Pardon = 125
		},
		new WolfClawConfig
		{
			MinCount = 11,
			MaxCount = 15,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -40,
			Pardon = 100
		},
		new WolfClawConfig
		{
			MinCount = 16,
			MaxCount = 30,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -30,
			Pardon = 90
		},
		new WolfClawConfig
		{
			MinCount = 31,
			MaxCount = 60,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -30,
			Pardon = 80
		},
		new WolfClawConfig
		{
			MinCount = 61,
			MaxCount = 999,
			Min = 500,
			Max = 1000,
			AddDist = 0.5f,
			Effect = 4,
			Offset = -25,
			Pardon = 70
		}
	};

	public int MinCount { get; set; }

	public int MaxCount { get; set; }

	public int Min { get; set; }

	public int Max { get; set; }

	public float AddDist { get; set; }

	public int Effect { get; set; }

	public int Offset { get; set; }

	public int Pardon { get; set; }

	public static WolfClawConfig[] GetDoubleConfigs(WeaponEntity currentWeapon, int raceType)
	{
		if (RuleUtilty.IsPve(raceType) || RuleUtilty.IsRpg(raceType))
		{
			switch (currentWeapon.basicInfo.Data.WeaponName)
			{
			case "wolfclaw":
			case "wolfclaw1":
			case "wolfclaw2":
				return _rpgDoubleConfigs;
			case "samurai_sword":
			case "samurai_sword1":
			case "samurai_sword2":
				return _samuraiSwordRpgDoubleConfigs;
			case "awake_claw":
			case "awake_claw1":
			case "awake_claw2":
				return _awakeClawRpgDoubleConfigs;
			}
		}
		else
		{
			switch (currentWeapon.basicInfo.Data.WeaponName)
			{
			case "wolfclaw":
			case "wolfclaw1":
			case "wolfclaw2":
				return _doubleConfigs;
			case "samurai_sword":
			case "samurai_sword1":
			case "samurai_sword2":
				return _samuraiSwordDoubleConfigs;
			case "awake_claw":
			case "awake_claw1":
			case "awake_claw2":
				return _awakeClawDoubleConfigs;
			}
		}
		return new WolfClawConfig[0];
	}

	public static int GetWolfClawDoubleLevel(WeaponEntity currentWeapon)
	{
		if (currentWeapon == null || !currentWeapon.hasBasicInfo)
		{
			return 0;
		}
		switch (currentWeapon.basicInfo.Data.WeaponName)
		{
		case "wolfclaw":
		case "wolfclaw1":
		case "wolfclaw2":
		case "awake_claw":
		case "awake_claw1":
		case "awake_claw2":
			return WolfClawFrameAction.GetWolfClawDoubleLevel(currentWeapon);
		default:
			return 0;
		}
	}
}
