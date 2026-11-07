using System.Collections.Generic;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class SceneWeaponRenderFactory
{
	private static SceneWeaponRenderFactory _instance;

	public Dictionary<string, ISceneWeaponRenderInfo> dict = new Dictionary<string, ISceneWeaponRenderInfo>
	{
		{
			"detective_grenade",
			new DetevctiveGrenadeRenderInfo()
		},
		{
			"c4",
			new C4RenderInfo()
		},
		{
			"electric_grenade",
			new ElecticeGrenadeRenderInfo()
		},
		{
			"electric_grenade1",
			new ElecticeGrenadeRenderInfo()
		},
		{
			"electric_grenade2",
			new ElecticeGrenadeRenderInfo()
		},
		{
			"m4a1_legend2",
			new M4A1LegendRenderInfo()
		},
		{
			"deagle_strike",
			new DeagleStrikeSceneRenderInfo()
		},
		{
			"hero_blade",
			new HeroBladeSceneRenderInfo()
		},
		{
			"grenade_strike",
			new GrenadeStrikSceneRenderInfo()
		},
		{
			"mental_burster",
			new MentalBursterSceneWeaponRenderInfo()
		},
		{
			"mental_burster1",
			new MentalBursterSceneWeaponRenderInfo()
		},
		{
			"mental_burster2",
			new MentalBursterSceneWeaponRenderInfo()
		},
		{
			"rifle_opticor",
			new RifleOpticorSceneWeaponRenderInfo()
		},
		{
			"cola_grenade",
			new ColaGrenadeSceneWeaponRenderInfo()
		},
		{
			"gatling_dou_rage_overload",
			new GatlingDouRage2SceneWeaponRenderInfo()
		},
		{
			"grenade_wasp",
			new GrenadeWaspSceneWeaponRenderInfo()
		},
		{
			"xcom_grenade",
			new GrenadeWaspSceneWeaponRenderInfo()
		},
		{
			"random_king2",
			new RandomKingSceneWeaponRenderInfo()
		},
		{
			"void_spear",
			new VoidSpearSceneWeaponRenderInfo()
		},
		{
			"claymore_tactical_180",
			new ClaymoreTacticalRenderinfo()
		},
		{
			"claymore_tactical_360",
			new ClaymoreTacticalRenderinfo()
		},
		{
			"m18a1_claymore",
			new ClaymoreTacticalRenderinfo()
		},
		{
			"m18a1_claymore1",
			new ClaymoreTacticalRenderinfo()
		},
		{
			"m18a1_claymore2",
			new ClaymoreTacticalRenderinfo()
		},
		{
			"banana_pistol",
			new ClaymoreTacticalRenderinfo()
		},
		{
			"mp5_ice",
			new MP5IceRenderinfo()
		},
		{
			"mp5_ice1",
			new MP5IceRenderinfo()
		},
		{
			"gear_mouse",
			new GearMouseRenderInfo()
		},
		{
			"storm_heroes",
			new StormHeroesRenderinfo()
		},
		{
			"storm_heroes1",
			new StormHeroesRenderinfo()
		},
		{
			"blacklightcrossbow",
			new BlacklightcrossbowRenderInfo()
		},
		{
			"blacklightcrossbow1",
			new BlacklightcrossbowRenderInfo()
		},
		{
			"blacklightcrossbow2",
			new BlacklightcrossbowRenderInfo()
		},
		{
			"ak47_legend_t",
			new AK47LegentRenderInfo()
		},
		{
			"ak47_legend_ct",
			new AK47LegentRenderInfo()
		},
		{
			"minideath",
			new MiniDeathRenderInfo()
		},
		{
			"minideath1",
			new MiniDeathRenderInfo()
		},
		{
			"glock_redflash",
			new GlockflashRenderInfo()
		},
		{
			"glock_redflash1",
			new GlockflashRenderInfo()
		},
		{
			"photon_deformation",
			new PhotondeformationflashRenderInfo()
		},
		{
			"photon_deformation1",
			new PhotondeformationflashRenderInfo()
		},
		{
			"blade_strike",
			new BladeStrikeRenderInfo()
		},
		{
			"glock_hell_snake",
			new GlockHellSnakeRenderInfo()
		},
		{
			"glock_hell_snake1",
			new GlockHellSnakeRenderInfo()
		},
		{
			"glock_hell_snake2",
			new GlockHellSnakeRenderInfo()
		},
		{
			"pistol_electric",
			new PistolElectricRenderInfo()
		},
		{
			"revolver_battle",
			new RevolverBattleRenderInfo()
		},
		{
			"revolver_battle1",
			new RevolverBattleRenderInfo()
		},
		{
			"revolver_battle2",
			new RevolverBattleRenderInfo()
		},
		{
			"darts_redflash",
			new DartsredflashRenderInfo()
		},
		{
			"darts_redflash1",
			new DartsredflashRenderInfo()
		},
		{
			"type91_dagger",
			new Type91DaggerRenderInfo()
		},
		{
			"type91_dagger1",
			new Type91DaggerRenderInfo()
		},
		{
			"type91_dagger2",
			new Type91DaggerRenderInfo()
		},
		{
			"type91_dagger3",
			new Type91DaggerRenderInfo()
		},
		{
			"sky_dome_beacon",
			new SkyDomeBeaconRenderInfo()
		},
		{
			"sky_dome_beacon1",
			new SkyDomeBeaconRenderInfo()
		},
		{
			"sky_dome_beacon2",
			new SkyDomeBeaconRenderInfo()
		},
		{
			"c4_claymore",
			new C4ClaymoreRenderInfo()
		},
		{
			"thunder_boom",
			new ThunderBoomRenderInfo()
		},
		{
			"thunder_boom1",
			new ThunderBoomRenderInfo()
		},
		{
			"thunder_boom2",
			new ThunderBoomRenderInfo()
		},
		{
			"shotgun_pistol_stone",
			new ShotgunPistolStoneRenderInfo()
		},
		{
			"grenade_universe",
			new GrenadLockUniverseSceneRenderInfo()
		},
		{
			"grenade_universe1",
			new GrenadLockUniverseSceneRenderInfo()
		},
		{
			"grenade_universe2",
			new GrenadLockUniverseSceneRenderInfo()
		},
		{
			"grenade_lock",
			new GrenadLockUniverseSceneRenderInfo()
		},
		{
			"grenade_lock1",
			new GrenadLockUniverseSceneRenderInfo()
		},
		{
			"grenade_lock2",
			new GrenadLockUniverseSceneRenderInfo()
		},
		{
			"grenade_dubhe",
			new GrenadeDubheSceneRenderInfo()
		},
		{
			"grenade_dubhe1",
			new GrenadeDubheSceneRenderInfo()
		},
		{
			"grenade_dubhe2",
			new GrenadeDubheSceneRenderInfo()
		},
		{
			"grenade_alioth",
			new GrenadeWaspSceneWeaponRenderInfo()
		},
		{
			"grenade_alioth1",
			new GrenadeWaspSceneWeaponRenderInfo()
		},
		{
			"grenade_alioth2",
			new GrenadeWaspSceneWeaponRenderInfo()
		},
		{
			"firecracker",
			new GrenadeSceneWeaponRenderInfo()
		},
		{
			"shutter_flashbang2",
			new GrenadeShutterWeaponRenderInfo()
		},
		{
			"shutter_flashbang1",
			new GrenadeShutterWeaponRenderInfo()
		},
		{
			"shutter_flashbang",
			new GrenadeShutterWeaponRenderInfo()
		},
		{
			"lover2025_grenade",
			new GrenadeLover2025SceneWeaponRenderInfo()
		}
	};

	private readonly ISceneWeaponRenderInfo _default = new DefaultSceneWeaponRenderInfo();

	private readonly ISceneWeaponRenderInfo _grenade = new GrenadeSceneWeaponRenderInfo();

	public static SceneWeaponRenderFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SceneWeaponRenderFactory();
			}
			return _instance;
		}
	}

	public ISceneWeaponRenderInfo GetRenderInfo(string name, int weaponType)
	{
		if (dict.ContainsKey(name))
		{
			return dict[name];
		}
		if (weaponType.Equals(3))
		{
			return _grenade;
		}
		return _default;
	}
}
