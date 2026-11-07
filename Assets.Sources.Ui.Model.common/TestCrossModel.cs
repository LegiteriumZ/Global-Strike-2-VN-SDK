using System;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using SSJJAnim.Weapon;
using SSJJBase.Input;
using Sharpen;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class TestCrossModel : AbstractModel, IPlaybackSystem, ISetBattleServerContext, ICursorControl, IKeyboardResponder
{
	private TestCrossViewModel _viewModel;

	private BattleServerContext _battleServerContext;

	private string[] WeaponNames = new string[704]
	{
		"", "", "Name", "92fs", "92fs_gp", "aa12_hell_dragon", "aa12_hell_dragon1", "aa12_hell_dragon2", "aa12_hero", "aa12_hero1",
		"ad16", "ad16crazydevil", "ad16_demon", "ak12", "ak12_phoenix", "ak12_wukong", "ak47", "ak47test2", "ak47_a", "ak47_c",
		"ak47_dragon", "ak47_esg", "ak47_eternity", "ak47_g", "ak47_g1", "ak47_glory", "ak47_hero", "ak47_hero1", "ak47_legend_ct", "ak47_legend_t",
		"ak47_lego", "ak47_mars", "ak47_mars1", "ak47_mars2", "ak47_redflash", "ak47_redflash1", "ak47_rose", "ak47_spring", "ak47_y", "ak47_yh",
		"ak47_zh", "ak47_zs", "ak47_zy", "ak74u", "ak74u1", "ak74u2", "an94", "an94_bone", "an94_g", "an94_g1",
		"an94_ma", "angerfirescar", "angerfirescar1", "ar15", "ar15_bone", "ar15_gilding", "ar15_rage", "ar15_s", "ar15_xc", "aug",
		"auga3", "awake_claw", "awake_claw1", "awake_claw2", "awm_bilibili", "awm_bone", "awm_c", "awm_g", "awm_hero", "awm_hero1",
		"awm_legend_ct", "awm_legend_t", "awm_s", "awm_tlx", "awm_wolf", "awm_y", "awp", "awp_hell_snake", "awp_hell_snake1", "awp_hell_snake2",
		"axe", "axe_abyss", "axe_bone", "axe_g", "b92_wolf", "barrett_m107", "barrett_m107_c", "barrett_m107_dragon", "barrett_m107_g", "barrett_m107_glory",
		"barrett_m107_y", "bat", "bat_md", "bayonet_3", "bayonet_gilding", "beer_bottle", "bizon", "bizon_g", "blacklightcrossbow", "blacklightcrossbow1",
		"blacklightcrossbow2", "black_crow", "black_dagger", "black_dagger1", "black_dagger2", "black_pistol", "black_pistol1", "black_pistol2", "black_saber", "bladeshield_g",
		"bladeshield_hero", "bladeshield_hero1", "blood_double_edge", "blood_grenade", "blood_knife", "blood_m1887", "blood_m1932", "blood_mosin", "blunderbuss", "botweapon",
		"bot_bomb", "bow", "bow_burn", "bow_burn1", "bow_god", "bow_god1", "brambles", "brambles1", "brick_knife", "brick_knife_gold",
		"brokenlight_knife", "brokenlight_knife1", "burning_bombs", "burning_bombs_dragon", "burning_bottle", "burning_firecracker", "burst_assault", "burst_assault1", "biogrenade", "c4",
		"cat_claw", "cheyTacM200", "christmas_antler", "colt1873", "colt_boa", "colt_boa_g", "colt_bone", "corbett", "cqtc_shadow", "cqtc_shadow1",
		"crossbow", "crossbow_black", "crossbow_black1", "crossbow_black2", "crossbow_g", "crowbar", "cslr4", "cz75", "cz75_abyss", "cz75_g",
		"candy_grenade", "dagger", "dagger_1", "dagger_2", "dagger_3", "dagger_4", "dagger_5", "darts_redflash", "darts_redflash1", "deagle",
		"deagle_a", "deagle_c", "deagle_dragon", "deagle_g", "deagle_glory", "deagle_hunter", "deagle_i", "deagle_pulse", "deagle_pulse1", "deagle_pulse2",
		"deagle_uc", "deagle_warrior", "deagle_y", "death", "death_ray", "detective_grenade", "devil_eye", "double_baton", "double_bayonet", "double_deagle",
		"double_deagle_dark", "double_deagle_g", "double_fangs", "double_fangs_dark", "double_fangs_g", "double_fmg", "double_fmg_dark", "double_fmg_g", "double_grenade", "double_infinity",
		"double_infinity_g", "double_maul", "double_maul_g", "double_scythe", "double_scythe_hell", "double_scythe_hell1", "double_scythe", "double_uzi", "double_uzi_g", "double_uzi_rage",
		"doun", "dp_machinegun", "dp_machinegun1", "dp_machinegun2", "dsr_1", "dsr_rage", "dsr_redflash", "dsr_redflash1", "electric_grenade", "electric_grenade1",
		"electric_grenade2", "electric_pistol", "electric_rifle", "electric_rifle1", "electric_rifle2", "ether_double_edge", "fal", "famas", "famas_r", "famas_y",
		"fire_demon_rpg", "fire_demon_rpg1", "fire_demon_rpg2", "fn2000", "fn2000tactic", "fn2000tactic1", "fn2000tactic2", "flashgrenade", "g11_dg", "g18_metal_storm",
		"g18_metal_storm1", "g18_metal_storm2", "g36c_tactic", "g36c_tactic1", "g36c_tactic2", "galil", "ganjiang", "ganjiang_g", "ganjiang_moye_g", "gatling",
		"gatling_abyss", "gatling_abyss_horror", "gatling_g", "gatling_xmas", "gatling_y", "ghost_grenade", "ghost_rider", "ghost_rider1", "ghost_twins", "ghost_twins1",
		"glock", "glock_auto", "glock_auto1", "glock_auto2", "glock_hell_snake", "glock_hell_snake1", "glock_hell_snake2", "glock_redflash", "glock_redflash1", "gloves",
		"gloves_metal", "gold_saber", "gold_saber1", "gold_snake", "gold_snake1", "gold_terminator", "gold_terminator1", "grenade_abyss", "grenade_bilibili", "grenade_bone",
		"grenade_duck", "grenade_football", "grenade_hell_snake", "grenade_hell_snake1", "grenade_hell_snake2", "grenade_ice", "grenade_m9", "grenade_md", "grenade_rage", "grenade_redflash",
		"grenade_redflash1", "grenade_rpg_ice", "grenade_rpg_ice1", "grenade_rpg_ice2", "grenade_star_dark", "grenade_warrior", "grenade_wukong", "grenade", "grenade_pumpkin", "grenade_love",
		"grenade_mooncake", "grenade_smoke", "grenade_uc", "grenade_egg", "hammer", "hammer_g", "hero", "herowoman", "herowoman_skyfire", "hero_blade",
		"hero_cold_death", "hero_cold_death1", "hero_skyfire", "highgrenade_deathray", "highgrenade_deathray1", "highgrenade_deathray2", "hk416", "hkg11", "horror_claw", "howitzer",
		"howitzerwoman", "howitzerwoman_skyfire", "howitzer_skyfire", "hrc140_hell", "hrc140_hell1", "hrc140_hell2", "hunting_knife", "highgrenade", "highgrenade_g", "highgrenade_glory",
		"highgrenade_y", "ice_ax", "induction", "jackhammer", "jackhammer_g", "jms", "jms_bilibili", "jms_fight", "jms_warrior", "jms_wolf",
		"k28sword", "k28sword1", "k28sword2", "kac_reaper", "kac_reaper_g", "keris", "ketuo_knife", "ketuo_knife_1", "ketuo_knife_2", "ketuo_pistol",
		"ketuo_pistol1", "ketuo_pistol2", "kingslayer", "knife_cmdr", "knuckle", "kriss", "kriss1", "lamb_2nd", "laser_sword", "laser_sword_ch",
		"lighting_star", "lighting_star1", "lr4_dawn", "lr4_dragon", "lr4_rage", "m14", "m14_g", "m14_g1", "m14_hell", "m14_hell1",
		"m14_hell2", "m14_wukong", "m1887", "m1887_dawn", "m1887_y", "m1911", "m1911_jupiter", "m1911_rage", "m1932", "m1932_th",
		"m202flash", "m202flash_rpg", "m249", "m249_howitzer", "m249_rocket", "m249_warrior", "m249_y", "m3", "m32", "m32_1",
		"m32_2", "m32_a", "m32_g", "m3_rage", "m3_rage1", "m3_rage2", "m3_rage3", "m4", "m4a1", "m4a1_a",
		"m4a1_c", "m4a1_dawn", "m4a1_dragon", "m4a1_g", "m4a1_g1", "m4a1_glory", "m4a1_hero", "m4a1_hero1", "m4a1_ice", "m4a1_immortal",
		"m4a1_knight", "m4a1_knight1", "m4a1_knight2", "m4a1_pluto", "m4a1_s", "m4a1_test", "m4a1_y", "m4a1_zy", "m4a4", "m4a4_rage",
		"m4a4_spring", "m4a4_zh", "m4_g", "m500", "m500_fire", "m60", "m60e6bloodanger", "m60e6bloodanger1", "m60e6bloodanger2", "m60_1",
		"m60_2", "m60_roadmaster", "m79_howitzer", "m79_howitzer1", "m79_howitzer2", "m84_devil", "m84_devil1", "m84_devil2", "m96_shadow", "m9_devil",
		"m9_devil1", "m9_devil2", "mace", "magnetic_track_grenade", "magnetic_track_grenade1", "magnetic_track_grenade2", "mcx", "mc_backsword", "mc_masonrysword", "md_93r",
		"mechbomberman", "mechfar", "mechnear", "mech_akm", "mech_deagle", "mech_dou_akm", "mech_grenade", "mech_nbr", "metalman", "mg3",
		"mg3_g", "mikaduki_sword", "mikaduki_sword1", "mikaduki_sword_tradition", "mikaduki_sword_tradition1", "minideath", "minideath1", "mini_samurai_sword", "mk14_redflash", "mk14_redflash1",
		"mk14_redflash_ether", "mk14_redflash_ether1", "mk14_redflash_rose", "mk14_redflash_rose1", "mk14_redflash_wolfram", "mk14_redflash_wolfram1", "mk_roadmaster", "moye", "moye_g", "mp40",
		"mp5", "mp5sd6_devil", "mp5sd6_devil1", "mp5sd6_devil2", "mp5_ice", "mp5_ice1", "mp5_predator", "mp5_wr", "mp7a1tactic", "mp7a1tactic1",
		"mp7a1tactic2", "msr", "nbr_knife", "nbr_knife_c", "nbr_knife_dragon", "nbr_knife_g", "nbr_knife_glory", "nbr_knife_y", "nunchaku", "nunchaku_king",
		"nunchaku_king1", "nurse", "ots_tg", "p28cannon", "p28cannon1", "p28cannon2", "p90", "p90_hero", "p90_hero1", "p90_s",
		"p90_s1", "p90_s2", "pan", "pan_g", "petrified", "phantom", "photon_deformation", "photon_deformation1", "photon_grenade", "photon_grenade1",
		"photon_grenade_combination", "photon_grenade_combination1", "photon_pistol", "photon_pistol1", "photon_pistol_combination", "photon_pistol_combination1", "photon_sword", "photon_sword1", "photon_sword_combination", "photon_sword_combination1",
		"pveawp", "pvegatling", "pvegatling_boss1021", "px4", "qbu10", "qbu10_redstar", "qbu88", "qbz03", "qbz95", "qbz95_c",
		"qbz95_dragon", "qbz95_g", "qbz95_g1", "qbz95_hero", "qbz95_hero1", "qbz95_ht", "qbz95_tz", "qbz95_wolf", "qbz95_y", "qbz97",
		"queen", "r28rifle", "r28rifle1", "r28rifle2", "rage", "rage_rage", "revolver_redflash", "revolver_redflash1", "revolver_tube", "riotshield",
		"riotshield1", "ripper", "ripper_g", "roar_sniper_hero", "roar_sniper_hero1", "rpgcaptaionjz", "rpgcaptaionyc", "rpg_7", "rpg_7_1", "rpg_7_2",
		"rpg_by_parasitism", "rpg_captain_dp", "rpg_redflash", "rpg_redflash1", "rpk", "rpk_an", "rpk_bone", "rpk_g", "rpk_hero", "rpk_hero1",
		"rpk_legend_ct", "rpk_legend_t", "rpk_rage", "rpk_s", "rpk_y", "s2_copper_95", "s2_silver_95", "s3_copper_awm", "s3_silver_awm", "s4_copper_deagle",
		"s4_silver_deagle", "samurai_sword", "samurai_sword1", "samurai_sword2", "sanDan_hero", "sanDan_hero1", "saw", "sawed_pirate", "saw_bone", "saw_rage",
		"scar", "scar_77", "scar_an", "scar_c", "scar_dragon", "scar_g", "scar_g1", "scar_h", "scar_h1", "scar_h2",
		"scar_kingk", "scar_kingk1", "scar_md", "scar_s", "scar_y", "scimitar", "scout", "scythe", "selfexplosion", "sg551",
		"shotgun_3_barrel", "shotgun_laser", "shotgun_laser1", "shovel", "shovel_g", "shovel_rage", "skin_carbon_fiber_show", "skydeagle", "skydeagle1", "slingshot",
		"slingshot_bone", "slingshot_g", "slingshot_g_test", "smaw", "smaw_rpg", "snaker", "snake_doun", "snowball_gun", "spanner", "spiderexplosion",
		"ssg08", "stirling", "storm_heroes", "storm_heroes1", "svd", "svi1911", "sw_95", "sword_heaven", "sword_hell", "sword_hell_snake",
		"sword_hell_snake1", "sword_hell_snake2", "tanghulu", "tar21", "thomson", "thomson_g", "thunderous", "thunderous1", "thunder_hammer", "thunder_hammer1",
		"thunder_hammer2", "tigerfist", "tiger_teeth_fight_dagger", "grenade_m9", "tmp_tactics", "tmp_tactics1", "tmp_tactics2", "tp82_hell", "tp82_hell1", "tp82_hell2",
		"twine", "type56", "type97", "uav", "ultimax100", "ultimax100_1", "ultimax100_2", "ump45", "usp45", "usp45_bilibili",
		"usp45_devil", "usp45_devil1", "usp45_devil2", "usp_neptune", "venom_knife", "viper", "viper_rage", "vip_grenade", "vip_knife", "vss",
		"vss_1", "vss_2", "weird_transform_pistol", "whitetiger", "whitetiger1", "wolfclaw", "wolfclaw1", "wolfclaw2", "xm1014", "xm1014_wolf",
		"xm8", "xm8_4399", "xm8_qq", "zhangXinLeiGrenade"
	};

	private int _index = 2;

	private int _disableTime;

	private int _currIndex;

	private const int Delay = 600;

	private bool _mouseShow;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new TestCrossViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			_disableTime -= _timeComponent.FrameInterval;
			TestCrossViewModel viewModel = _viewModel;
			TestCrossViewModel viewModel2 = _viewModel;
			TestCrossViewModel viewModel3 = _viewModel;
			bool flag2 = (_viewModel.StartBtnButtonable = _disableTime <= 0);
			bool flag4 = (viewModel3.LastBtnButtonable = flag2);
			bool changeBtnButtonable = (viewModel2.NextBtnButtonable = flag4);
			viewModel.ChangeBtnButtonable = changeBtnButtonable;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ChangeBtnClicked.AddListener(delegate
		{
			if (WeaponNames.Contains(_viewModel.InputFieldText))
			{
				_currIndex = Array.IndexOf(WeaponNames, _viewModel.InputFieldText);
				_battleServerContext.battleServer.Server.SendTcpMessage(25, 10 + _currIndex);
				_disableTime = 600;
			}
		});
		_viewModel.NextBtnClicked.AddListener(delegate
		{
			if (_index < WeaponNames.Length - 1)
			{
				_index++;
			}
			_currIndex = _index;
			_battleServerContext.battleServer.Server.SendTcpMessage(25, 10 + _index);
			_disableTime = 600;
		});
		_viewModel.LastBtnClicked.AddListener(delegate
		{
			if (_index > 2)
			{
				_index--;
			}
			_currIndex = _index;
			_battleServerContext.battleServer.Server.SendTcpMessage(25, 10 + _index);
			_disableTime = 600;
		});
		_viewModel.StartBtnClicked.AddListener(delegate
		{
			if (WeaponNames.Contains(_viewModel.InputFieldText))
			{
				_index = Array.IndexOf(WeaponNames, _viewModel.InputFieldText);
				_currIndex = _index;
				_battleServerContext.battleServer.Server.SendTcpMessage(25, 10 + _index);
				_disableTime = 600;
			}
		});
	}

	private int GetWeaponKey()
	{
		string name = WeaponNames[_currIndex];
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(name);
		if (weaponInfo != null)
		{
			switch (weaponInfo.WeaponType)
			{
			case 1:
			case 5:
			case 6:
			case 8:
			case 10:
			case 12:
				return 1;
			case 0:
				return 2;
			case 2:
				return 3;
			case 3:
				return 4;
			case 4:
			case 14:
				return 5;
			}
		}
		return 0;
	}

	public int GetCursorState()
	{
		if (!_mouseShow)
		{
			return 0;
		}
		return 1;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		switch (key)
		{
		case KeyCode.C:
			_mouseShow = !_mouseShow;
			break;
		case KeyCode.V:
			if (_index < WeaponNames.Length - 1)
			{
				_index++;
			}
			_battleServerContext.battleServer.Server.SendTcpMessage(25, 10 + _index);
			_disableTime = 500;
			break;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
