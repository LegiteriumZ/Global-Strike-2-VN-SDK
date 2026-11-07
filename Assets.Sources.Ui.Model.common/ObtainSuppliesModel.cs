using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using Sharpen;
using Sources.Utils.Ui;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class ObtainSuppliesModel : AbstractModel, IPlaybackSystem, ISetWeaponContext, ISetPlayerContext, ISetBattleRoomContext
{
	private ObtainSuppliesViewModel _viewModel;

	private bool _isThirdPersonView;

	private static string _assetBundleName = "ui/halfLoadedRes/obtainSupplies";

	private static Dictionary<string, AssetInfo> _assets = new Dictionary<string, AssetInfo>
	{
		{
			"Ammunitionpack",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/ammunitionpack.png")
		},
		{
			"Mp5MrFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/mp5wr.png")
		},
		{
			"DartsredFlashBeattack",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/darts_redflash.png")
		},
		{
			"FlashBeattack",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/rpg_redflash.png")
		},
		{
			"ShotgunLaserBeattack",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/shotgun_laser.png")
		},
		{
			"M60E6BloodangerAneer",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/m60e6bloodanger.png")
		},
		{
			"ShengHuaZhiDi",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/skill2.png")
		},
		{
			"HurtDeep",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/mp5wr.png")
		},
		{
			"PistolElectric",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/screenEffect1.png")
		},
		{
			"RevolverBattleEffect",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/in_battle.png")
		},
		{
			"SkinRevolverBattlePurpEffect",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/in_battle1.png")
		},
		{
			"HolidayBossEffect",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/in_battle.png")
		},
		{
			"DeadEyeFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/aim_effect.png")
		},
		{
			"skinDeadEyeFlagpurp",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/aim_effect1.png")
		},
		{
			"SlowDownPistolFlag",
			new AssetInfo(_assetBundleName, "Assetsjinjie1/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/effect.png")
		},
		{
			"JinJie1",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/jinjie1.png")
		},
		{
			"JinJie2",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/jinjie2.png")
		},
		{
			"JinJie3",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/jinjie3.png")
		},
		{
			"ElectricElementChongci",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/electric_element_chongci.png")
		},
		{
			"CyberPunkSwordBurn",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/cyber_punk_sword_burn.png")
		},
		{
			"PlayerMedicalpackageFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/addhp.png")
		},
		{
			"PlayerAccelerateFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/quickmovement.png")
		},
		{
			"WildFire",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/wildfire.png")
		},
		{
			"Obtainsupplies",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/obtainsupplies.png")
		},
		{
			"AwakeBio_PlayerEnergyshieldFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/biochemicalshell.png")
		},
		{
			"SoulLink",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/soullink.png")
		},
		{
			"Bio_PlayerAccelerateFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/obtainsupplies.png")
		},
		{
			"PlayerHumanUpspeedFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/obtainsupplies.png")
		},
		{
			"PlayerEnergyshieldFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/obtainsupplies.png")
		},
		{
			"UseingSnakeSpirit",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/opuseingsnakespirit.png")
		},
		{
			"PollutionShielding",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/pollutionshielding.png")
		},
		{
			"SwordHellSnakeShield",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/sword_hell_snake_shield.png")
		},
		{
			"BladeshieldDun",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/BladeShiled.png")
		},
		{
			"Rpg_PlayerAccelerateFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/quickmovement.png")
		},
		{
			"UltimateTime",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/wildfire.png")
		},
		{
			"BeDeathCall",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/deathcall.png")
		},
		{
			"PlayerWeaponFlashFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/quickmovement.png")
		},
		{
			"RpgSkillQiji",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/quickmovement.png")
		},
		{
			"M60E6Addhp",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/addhp.png")
		},
		{
			"AwmLegendLiuxue",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/awmlegend.png")
		},
		{
			"RpgBeattackGedang",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/beattackgedang.png")
		},
		{
			"RpgButterflyGrenadeKill",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/beattackgedang.png")
		},
		{
			"Ammunitionpackage",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/ammunitionpack.png")
		},
		{
			"Incentivetask",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/ammunitionpack.png")
		},
		{
			"RageSkillUsing",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/rage.png")
		},
		{
			"Gliding",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/quickmovement.png")
		},
		{
			"RpgLiziH",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/lizi_h.png")
		},
		{
			"RpgLiziL",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/lizi_l.png")
		},
		{
			"XiyaLiangzihudun",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/hudun.png")
		},
		{
			"DamageDeep",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/damagedeep.png")
		},
		{
			"HeroColdDeathHubiBuff",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/effect.png")
		},
		{
			"P90HeroHuanrao",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/zhufengzhanshi.png")
		},
		{
			"GRENADE_SHAXING",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/darts_redflash.png")
		},
		{
			"RpgYemolaixi",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/ymlx.png")
		},
		{
			"jiShenti",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/jiShenti.png")
		},
		{
			"pingmuDuwu",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/pingmuDuwu.png")
		},
		{
			"mouseyear_bai",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/mouseyear_bai.png")
		},
		{
			"mouseyear_hong",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/mouseyear_hong.png")
		},
		{
			"mouseyear_huang",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/mouseyear_huang.png")
		},
		{
			"mouseyear_lan",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/mouseyear_lan.png")
		},
		{
			"hudun",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/hudun.png")
		},
		{
			"twinsInfinity",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/twinsInfinity.png")
		},
		{
			"void_jump_wz",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/void_jump_wz.png")
		},
		{
			"hufeng",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/hufeng.png")
		},
		{
			"stealh",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/stealh.png")
		},
		{
			"nianye",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/nianye.png")
		},
		{
			"fogHurt",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfloadedres/obtainSupplies/fogHurt.png")
		},
		{
			"ScarLegend",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/densefog.png")
		},
		{
			"FeatherBowMarkFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/densefog.png")
		},
		{
			"FeatherBow",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/effect.png")
		},
		{
			"DarkDiamond",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/anshuijing.png")
		},
		{
			"HaSuTaoZhuangJiNeng",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/hasutaozhuangjineng.png")
		},
		{
			"HuanguangboSkill",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/P1_hunluan.png")
		},
		{
			"rechengxiang",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/rechengxiang.png")
		},
		{
			"laserheropistolShield",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/laserheropistol_Shield.png")
		},
		{
			"Storm_Shotgun_Shield",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/ammunitionpack.png")
		},
		{
			"SlideFlag",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/effect.png")
		},
		{
			"jiandong",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/jiandong.png")
		},
		{
			"aixin",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/aixin.png")
		},
		{
			"duration",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/skill2.png")
		},
		{
			"wavespavement",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/wavespavement.png")
		},
		{
			"DiaoChan_Biyue1",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/hudun_0_p1.png")
		},
		{
			"DiaoChan_Biyue2",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/hudun_25_p1.png")
		},
		{
			"DiaoChan_Biyue3",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/hudun_50_p1.png")
		},
		{
			"DiaoChan_Biyue4",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/hudun_75_p1.png")
		},
		{
			"LegendEnergy",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/legendEnergy.png")
		},
		{
			"yufeng_p1",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/yufeng_p1.png")
		},
		{
			"Berserker",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/p3_quanpingtexiao.png")
		},
		{
			"JinGang",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/jinganglian_p1.png")
		},
		{
			"ZiLongHuTi",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/chongci_p1.png")
		},
		{
			"rainbowPistol_combo",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/rainbowPistol_combo.png")
		},
		{
			"elec_red",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/elec_red.png")
		},
		{
			"elec_blue",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/elect_blue.png")
		},
		{
			"star_ring",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/star_ring.png")
		},
		{
			"heiyan",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/yanjiang.png")
		},
		{
			"hailang",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/hailang.png")
		},
		{
			"leixi",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/quanping_liexi.png")
		},
		{
			"light_sniper",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/light_sniper.png")
		},
		{
			"blockUmbrella",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/blockUmbrella.png")
		},
		{
			"skinBlockUmbrellaFlower",
			new AssetInfo(_assetBundleName, "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/skinBlockUmbrellaFlower.png")
		}
	};

	private static Dictionary<string, AssetInfo> _centerAssets = new Dictionary<string, AssetInfo> { 
	{
		"PollutionShielding",
		new AssetInfo("ui/biomodel", "Assets/Res/Assets/ui/GameGUIRes/bioModel/obtainsupplies/pollutionshielding_center.png")
	} };

	private static HashSet<string> _notChangeAlpha = new HashSet<string> { "DeadEyeFlag", "skinDeadEyeFlagpurp", "stealh" };

	private static HashSet<string> _thirdViewHasState = new HashSet<string> { "Gliding", "ElectricElementChongci" };

	private List<string> _states = new List<string>();

	private float _flag = 1f;

	private bool _changeAlpha = true;

	private Color redColor = new Color(1f, 0.5f, 0.5f);

	private WeaponContext _weaponContext;

	private PlayerContext _playerContext;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ObtainSuppliesViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.ShowShow)
			{
				UpdateAlpha(_timeComponent.FrameInterval);
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		_viewModel.CenterShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_State_Ammunitionpack, SetAmmunitionpack, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Ammunitionpackage, SetAmmunitionpackage, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Incentivetask, SetIncentivetask, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RageSkillUsing, SetRageSkillUsing, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Gliding, SetGliding, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerWeaponFlashFlag, SetPlayerWeaponFlashFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_BladeshieldDun, SetBladeshieldDun, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Mp5MrFlag, SetMp5MrFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_DartsredFlashBeattack, SetDartsredFlashBeattack, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_FlashBeattack, SetFlashBeattack, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_ShotgunLaserBeattack, SetShotgunLaserBeattack, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_M60E6BloodangerAneer, SetM60E6BloodangerAneer, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgSkillQiji, SetRpgSkillQiji, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_HeroColdDeathShenhan, SetHeroColdDeathShenhan, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_HeroColdDeathHubiBuff, SetHeroColdDeathHubiBuff, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PollutionShielding, SetPollutionShielding, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerMedicalpackageFlag, SetPlayerMedicalpackageFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_Obtainsupplies, SetObtainsupplies, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_M60E6Addhp, SetM60E6Addhp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerEnergyshieldSpeedFlag, SetPlayerEnergyshieldSpeedFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerAccelerateFlag, SetPlayerAccelerateFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_BioPlayerAccelerateFlag, SetBioPlayerAccelerateFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgPlayerAccelerateFlag, SetRpgPlayerAccelerateFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerHumanUpspeedFlag, SetPlayerHumanUpspeedFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerEnergyshieldFlag, SetPlayerEnergyshieldFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_AwakePlayerEnergyshieldFlag, SetAwakePlayerEnergyshieldFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_UltimateTime, SetUltimateTime, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_PlayerDeathcallFlag, SetPlayerDeathcallFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_UseingSnakeSpirit, SetUseingSnakeSpirit, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_SwordHellSnakeShield, SetSwordHellSnakeShield, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_AwmLegendLiuxue, SetAwmLegendLiuxue, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_DamageDeep, SetDamageDeep, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_IsThirdPersonView, SetIsThirdPersonView, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_ShengHuaZhiDi, SetShengHuaZhiDi, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_HurtDeep, SetHurtDeep, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_PistolElectric, SetPistolElectric, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_RevolverBattleEffect, SetRevolverBattleEffect, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_SkinRevolverBattlePrupEffect, SetSkinRevolverBattlePurpEffect, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_HolidayBossEffect, SetHolidayBossEffect, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_DeadEyeFlag, SetDeadEyeFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_SkinDeadEyeFlagPurp, SetSkinDeadEyeFlagPurp, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_SlowDownPistolFlag, SetSlowDownPistolFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_JinJie1, SetJinJie1, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_JinJie2, SetJinJie2, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_JinJie3, SetJinJie3, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_ElectricElementChongci, SetElectricElementChongci, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_RpgBeattackGedang, SetRpgBeattackGedang, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_RpgButterflyGrenadeKill, SetRpgButterflyGrenadeKill, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_CyberPunkSwordBurn, SetCyberPunkSwordBurn, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_WildFire, SetWildFire, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_SoulLink, SetSoulLink, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_BeDeathCall, SetBeDeathCall, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgLiziH, SetRpgLiziH, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgLiziL, SetRpgLiziL, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_XiyaLiangzihudun, SetXiyaLiangzihudun, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_HeroColdDeathHubiBuff, SetHeroColdDeathHubi, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_P90HeroHuanrao, SetP90HeroHuanrao, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_GRENADE_SHAXING, Set_GRENADE_SHAXING, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveState_RpgYemolaixi, SetRpgYemolaixi, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_PingmuDuwu, SetRpgPingmuDuwu, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_JiShenti, SetRpgJiShenti, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_MouseYearBai, SetMouseYearBai, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_MouseYearHuang, SetMouseYearHuang, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_MouseYearLan, SetMouseYearLan, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_MouseYearHong, SetMouseYearHong, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_MAGIC_SHIELD, SetMagicShield, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_TWINS_INFINITE, SetTwinInfinite, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_VOID_JUMP_MASK_EFFECT, SetVoidJumpTransport, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_VOID_JUMP_TRANSPORT_P1, SetTwinInfinite, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_CUTTLEFISH_GRENADE_IN_CHAOS, SetCuttleFish, null, initinvoke: false, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_Hufeng_Quanping, SetHufeng, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_Stealh, SetStealh, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_NianYe, SetNianYe, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_FogHurt, SetFogHurt, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_TANGYUANP1, SetPlayerAccelerateFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_ShieldP1, SetBeDeathCall, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_EV_SCAR_LEGEND_FLAG, SetScarLegend, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_EV_FEATHER_BOW_MARK_FLAG, SetFeatherBowMarkFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(GetFeatherBowEffectLevel, SetFeatherBow, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_DARK_DIAMOND_WRATH, SetDarkDiamond, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_HASU_YOULING_REBACK, SetHaSuTaoZhuangJiNeng, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_HASU_HUNLUANGUANGBO_VALUE, SetHuanguangboSkill, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_THERMAL_SCOPE, SetThermalScopeView, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_LASER_HERO_PISTOL_SHIELD, SetlaserheropistolShield, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_STORM_SHOTGUN_SHIELD, SetStormShotgun_shield, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_SLIDE_STATUS, SetSlideFlag, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_COZYWINTER_FROZEN_GRADUALLY, SetJianDong, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_JIU_WEI_AIXIN_BEHIT, SetAiXin, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_HYPER_REVOLVER_FIRE_RING_DURATION, SetDuraTion, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_WAVES_PAVEMENT, SetWavesPavement, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_GaiaSniper_Flag, SetRageSkillUsing, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_GaiaSniper_Blink, SetElectricElementChongci, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_DiaoChan_Biyue1, SetDiaoChan_Biyue1, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_DiaoChan_Biyue2, SetDiaoChan_Biyue2, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_DiaoChan_Biyue3, SetDiaoChan_Biyue3, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_DiaoChan_Biyue4, SetDiaoChan_Biyue4, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_yufeng_p1, SetYufegnP1, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_status_rainbowpistol_combo, SetRainBowPistolCombo, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_LEGENDENERGY, SetLegendEnergy, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_BERSERKER_AXE_HERO_SPIRIT, SetBerserker, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_HolyRosaryJinGang, SetJinGang, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_ZiLongHuTi, SetZiLongHuTi, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_RPG_BOSS_AI_GIRL_ELEC_P1_RED, SetRpgBossAigirlElectP1Red, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_RPG_BOSS_AI_GIRL_ELEC_P1_BLUE, SetRpgBossAigirlElectP1Blue, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_GREY_CORE_STAR_CIRCLE, SetGREY_CORE_STAR_CIRCLE, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_DARKFIRE_RIFLE_POWER, SetDARKFIRE_RIFLE_POWE, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_DARKFIRE_RIFLE_POWER_WAVE, SetDARKFIRE_RIFLE_POWER_WAVE, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_SHOTGUN_LEGEND_BREAK, SetSHOTGUN_LEGEND_BREAK, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_LIGHT_SNIPER_RAMPAGE, SetLIGHT_SNIPER_RAMPAGE, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_BLOCK_UMBRELLA, SetBlockUmbrella, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.GetStatus_SKIN_BLOCK_UMBRELLA_FLOWER, SetSkinBlockUmbrellaFlower, null, initinvoke: true, isFrameSeparation: true);
		foreach (int key in SingletonInstance<ObtainSupplieParser>.Instance.GetObtainSupplieConfig().Keys)
		{
			AddObtainSupplieConfgiAsset(key);
		}
	}

	private void AddObtainSupplieConfgiAsset(int playerStatus)
	{
		Dictionary<int, string> obtainSupplieConfig = SingletonInstance<ObtainSupplieParser>.Instance.GetObtainSupplieConfig();
		if (!_assets.ContainsKey(obtainSupplieConfig[playerStatus]) && obtainSupplieConfig.ContainsKey(playerStatus))
		{
			string pngUrl = obtainSupplieConfig[playerStatus];
			string text = _assetBundleName;
			string format = "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/obtainSupplies/{0}.png";
			if (pngUrl.StartsWith("/"))
			{
				string[] array = pngUrl.Split('/');
				text = array[1] + "/" + array[2];
				format = "Assets/Res/Assets{0}.png";
			}
			_assets.Add(pngUrl, new AssetInfo(text.ToLower(), string.Format(format, pngUrl)));
			NotifyManager.MakeTempNotify(() => Contexts.sharedInstance.player.cameraOwnerEntity != null && Contexts.sharedInstance.player.cameraOwnerEntity.HasStatus(playerStatus), delegate(bool arg1, bool arg2)
			{
				SetObtain(arg2, pngUrl);
			}, null, initinvoke: true, isFrameSeparation: true);
		}
	}

	private void SetNewAddObtainSupplieConfig()
	{
		List<int> newAddConfig = SingletonInstance<ObtainSupplieParser>.Instance.GetNewAddConfig();
		if (newAddConfig != null && newAddConfig.Count > 0)
		{
			for (int i = 0; i < newAddConfig.Count; i++)
			{
				int playerStatus = newAddConfig[i];
				AddObtainSupplieConfgiAsset(playerStatus);
			}
			newAddConfig.Clear();
		}
	}

	public bool GetFeatherBowEffectLevel()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.basicInfo.Data.WeaponName == "feather_bow")
		{
			if (currentWeaponEntity.hasSpecial)
			{
				return (currentWeaponEntity.special.EffectLevel & 0x10) > 0;
			}
			return false;
		}
		return false;
	}

	private void SetDarkDiamond(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DarkDiamond");
	}

	private void SetFeatherBow(bool arg1, bool arg2)
	{
		SetObtain(arg2, "FeatherBow");
	}

	private void SetCuttleFish(bool arg1, bool arg2)
	{
		SetObtain(arg2, "hunluan");
	}

	private void SetVoidJumpTransport(bool arg1, bool arg2)
	{
		SetObtain(arg2, "void_jump_wz");
	}

	private void SetTwinInfinite(bool arg1, bool arg2)
	{
		SetObtain(arg2, "twinsInfinity");
	}

	private void SetMagicShield(bool arg1, bool arg2)
	{
		SetObtain(arg2, "hudun");
	}

	private void SetRpgPingmuDuwu(bool arg1, bool arg2)
	{
		SetObtain(arg2, "pingmuDuwu");
	}

	private void SetRpgJiShenti(bool arg1, bool arg2)
	{
		SetObtain(arg2, "jiShenti");
	}

	private void SetMouseYearBai(bool arg1, bool arg2)
	{
		SetObtain(arg2, "mouseyear_bai");
	}

	private void SetMouseYearHong(bool arg1, bool arg2)
	{
		SetObtain(arg2, "mouseyear_hong");
	}

	private void SetMouseYearHuang(bool arg1, bool arg2)
	{
		SetObtain(arg2, "mouseyear_huang");
	}

	private void SetMouseYearLan(bool arg1, bool arg2)
	{
		SetObtain(arg2, "mouseyear_lan");
	}

	private void SetP90HeroHuanrao(bool arg1, bool arg2)
	{
		SetObtain(arg2, "P90HeroHuanrao");
	}

	private void SetRpgYemolaixi(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RpgYemolaixi");
	}

	private void Set_GRENADE_SHAXING(bool arg1, bool arg2)
	{
		SetObtain(arg2, "GRENADE_SHAXING");
	}

	private void SetStealh(bool arg1, bool arg2)
	{
		SetObtain(arg2, "stealh");
	}

	private void SetHufeng(bool arg1, bool arg2)
	{
		SetObtain(arg2, "hufeng");
	}

	private void SetHeroColdDeathHubi(bool arg1, bool arg2)
	{
		SetObtain(arg2, "HeroColdDeathHubiBuff");
	}

	private void SetXiyaLiangzihudun(bool arg1, bool arg2)
	{
		SetObtain(arg2, "XiyaLiangzihudun");
	}

	private void SetRpgLiziL(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RpgLiziL");
	}

	private void SetRpgLiziH(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RpgLiziH");
	}

	private void SetScarLegend(bool arg1, bool arg2)
	{
		SetObtain(arg2, "ScarLegend");
	}

	private void SetBeDeathCall(bool arg1, bool arg2)
	{
		SetObtain(arg2, "BeDeathCall");
	}

	private void SetSoulLink(bool arg1, bool arg2)
	{
		SetObtain(arg2, "SoulLink");
	}

	private void SetWildFire(bool arg1, bool arg2)
	{
		SetObtain(arg2, "WildFire");
	}

	private void SetCyberPunkSwordBurn(bool arg1, bool arg2)
	{
		SetObtain(arg2, "CyberPunkSwordBurn");
	}

	private void SetRpgBeattackGedang(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RpgBeattackGedang");
	}

	private void SetRpgButterflyGrenadeKill(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RpgButterflyGrenadeKill");
	}

	private void SetElectricElementChongci(bool arg1, bool arg2)
	{
		SetObtain(arg2, "ElectricElementChongci");
	}

	private void SetDiaoChan_Biyue1(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DiaoChan_Biyue1");
	}

	private void SetDiaoChan_Biyue2(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DiaoChan_Biyue2");
	}

	private void SetDiaoChan_Biyue3(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DiaoChan_Biyue3");
	}

	private void SetDiaoChan_Biyue4(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DiaoChan_Biyue4");
	}

	private void SetYufegnP1(bool arg1, bool arg2)
	{
		SetObtain(arg2, "yufeng_p1");
	}

	private void SetRainBowPistolCombo(bool arg1, bool arg2)
	{
		SetObtain(arg2, "rainbowPistol_combo");
	}

	private void SetLegendEnergy(bool arg1, bool arg2)
	{
		SetObtain(arg2, "LegendEnergy");
	}

	private void SetBerserker(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Berserker");
	}

	private void SetJinGang(bool arg1, bool arg2)
	{
		SetObtain(arg2, "JinGang");
	}

	private void SetZiLongHuTi(bool arg1, bool arg2)
	{
		SetObtain(arg2, "ZiLongHuTi");
	}

	private void SetRpgBossAigirlElectP1Red(bool arg1, bool arg2)
	{
		SetObtain(arg2, "elec_red");
	}

	private void SetRpgBossAigirlElectP1Blue(bool arg1, bool arg2)
	{
		SetObtain(arg2, "elec_blue");
	}

	private void SetHaSuTaoZhuangJiNeng(bool arg1, bool arg2)
	{
		SetObtain(arg2, "HaSuTaoZhuangJiNeng");
	}

	private void SetHuanguangboSkill(bool arg1, bool arg2)
	{
		SetObtain(arg2, "HuanguangboSkill");
	}

	private void SetlaserheropistolShield(bool arg1, bool arg2)
	{
		SetObtain(arg2, "laserheropistolShield");
	}

	private string GetWeaponName()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		string text = ((currentWeaponEntity != null) ? currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (string.IsNullOrEmpty(text) && _playerContext.isCameraOwner)
		{
			return _playerContext.cameraOwnerEntity.basicInfo.Current.CurrentWeaponName;
		}
		return text;
	}

	private void SetJinJie1(bool arg1, bool arg2)
	{
		SetObtain(arg2, "JinJie1", GetWeaponName());
	}

	private void SetJinJie2(bool arg1, bool arg2)
	{
		SetObtain(arg2, "JinJie2", GetWeaponName());
	}

	private void SetJinJie3(bool arg1, bool arg2)
	{
		SetObtain(arg2, "JinJie3", GetWeaponName());
	}

	private void SetSlowDownPistolFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "SlowDownPistolFlag", GetWeaponName());
	}

	private void SetDeadEyeFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DeadEyeFlag", GetWeaponName());
	}

	private void SetSkinDeadEyeFlagPurp(bool arg1, bool arg2)
	{
		SetObtain(arg2, "skinDeadEyeFlagpurp", GetWeaponName());
	}

	private void SetRevolverBattleEffect(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RevolverBattleEffect", GetWeaponName());
	}

	private void SetSkinRevolverBattlePurpEffect(bool arg1, bool arg2)
	{
		SetObtain(arg2, "SkinRevolverBattlePurpEffect", GetWeaponName());
	}

	private void SetHolidayBossEffect(bool arg1, bool arg2)
	{
		SetObtain(arg2, "HolidayBossEffect", GetWeaponName());
	}

	private void SetAmmunitionpackage(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Ammunitionpackage");
	}

	private void SetStormShotgun_shield(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Storm_Shotgun_Shield");
	}

	private void SetIncentivetask(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Incentivetask");
	}

	private void SetRageSkillUsing(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RageSkillUsing");
	}

	private void SetGliding(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Gliding");
	}

	private void SetPlayerWeaponFlashFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PlayerWeaponFlashFlag");
	}

	private void SetBladeshieldDun(bool arg1, bool arg2)
	{
		SetObtain(arg2, "BladeshieldDun");
	}

	private void SetMp5MrFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Mp5MrFlag");
	}

	private void SetDartsredFlashBeattack(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DartsredFlashBeattack");
	}

	private void SetFlashBeattack(bool arg1, bool arg2)
	{
		SetObtain(arg2, "FlashBeattack");
	}

	private void SetShotgunLaserBeattack(bool arg1, bool arg2)
	{
		SetObtain(arg2, "ShotgunLaserBeattack");
	}

	private void SetM60E6BloodangerAneer(bool arg1, bool arg2)
	{
		SetObtain(arg2, "M60E6BloodangerAneer");
	}

	private void SetRpgSkillQiji(bool arg1, bool arg2)
	{
		SetObtain(arg2, "RpgSkillQiji");
	}

	private void SetM60E6Addhp(bool arg1, bool arg2)
	{
		SetObtain(arg2, "M60E6Addhp");
	}

	private void SetHeroColdDeathShenhan(bool arg1, bool arg2)
	{
		SetObtain(arg2, "HeroColdDeathShenhan", GetWeaponName());
	}

	private void SetHeroColdDeathHubiBuff(bool arg1, bool arg2)
	{
		SetObtain(arg2, "HeroColdDeathHubiBuff", GetWeaponName());
	}

	private void SetPollutionShielding(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PollutionShielding");
	}

	private void SetPlayerMedicalpackageFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PlayerMedicalpackageFlag");
	}

	private void SetObtainsupplies(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Obtainsupplies");
	}

	private void SetPlayerEnergyshieldSpeedFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PlayerEnergyshieldSpeedFlag");
	}

	private void SetPlayerAccelerateFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PlayerAccelerateFlag");
	}

	private void SetBioPlayerAccelerateFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Bio_PlayerAccelerateFlag");
	}

	private void SetRpgPlayerAccelerateFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Rpg_PlayerAccelerateFlag");
	}

	private void SetPlayerHumanUpspeedFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PlayerHumanUpspeedFlag");
	}

	private void SetPlayerEnergyshieldFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PlayerEnergyshieldFlag");
	}

	private void SetFinalPlayerEnergyshieldFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "FinalBio_PlayerEnergyshieldFlag");
	}

	private void SetAwakePlayerEnergyshieldFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "AwakeBio_PlayerEnergyshieldFlag");
	}

	private void SetUltimateTime(bool arg1, bool arg2)
	{
		SetObtain(arg2, "UltimateTime");
	}

	private void SetPlayerDeathcallFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PlayerDeathcallFlag");
	}

	private void SetUseingSnakeSpirit(bool arg1, bool arg2)
	{
		SetObtain(arg2, "UseingSnakeSpirit");
	}

	private void SetSwordHellSnakeShield(bool arg1, bool arg2)
	{
		SetObtain(arg2, "SwordHellSnakeShield");
	}

	private void SetAwmLegendLiuxue(bool arg1, bool arg2)
	{
		SetObtain(arg2, "AwmLegendLiuxue");
	}

	private void SetDamageDeep(bool arg1, bool arg2)
	{
		SetObtain(arg2, "DamageDeep");
	}

	private void SetHurtDeep(bool arg1, bool arg2)
	{
		SetObtain(arg2, "HurtDeep");
	}

	private void SetAmmunitionpack(bool arg1, bool arg2)
	{
		SetObtain(arg2, "Ammunitionpack");
	}

	private void SetThermalScopeView(bool arg1, bool arg2)
	{
		SetObtain(arg2, "rechengxiang");
	}

	private void SetShengHuaZhiDi(bool arg1, bool arg2)
	{
		SetObtain(arg2, "ShengHuaZhiDi", GetWeaponName());
	}

	private void SetPistolElectric(bool arg1, bool arg2)
	{
		SetObtain(arg2, "PistolElectric", GetWeaponName());
	}

	private void SetNianYe(bool arg1, bool arg2)
	{
		SetObtain(arg2, "nianye");
	}

	private void SetFogHurt(bool arg1, bool arg2)
	{
		SetObtain(arg2, "fogHurt");
	}

	private void SetFeatherBowMarkFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "FeatherBowMarkFlag");
	}

	private void SetSlideFlag(bool arg1, bool arg2)
	{
		SetObtain(arg2, "SlideFlag");
	}

	private void SetJianDong(bool arg1, bool arg2)
	{
		SetObtain(arg2, "jiandong");
	}

	private void SetAiXin(bool arg1, bool arg2)
	{
		SetObtain(arg2, "aixin");
	}

	private void SetDuraTion(bool arg1, bool arg2)
	{
		SetObtain(arg2, "duration");
	}

	private void SetWavesPavement(bool arg1, bool arg2)
	{
		SetObtain(arg2, "wavespavement");
	}

	private void SetGREY_CORE_STAR_CIRCLE(bool arg1, bool arg2)
	{
		SetObtain(arg2, "star_ring");
	}

	private void SetDARKFIRE_RIFLE_POWE(bool arg1, bool arg2)
	{
		SetObtain(arg2, "heiyan");
	}

	private void SetDARKFIRE_RIFLE_POWER_WAVE(bool arg1, bool arg2)
	{
		SetObtain(arg2, "hailang");
	}

	private void SetSHOTGUN_LEGEND_BREAK(bool arg1, bool arg2)
	{
		SetObtain(arg2, "leixi");
	}

	private void SetLIGHT_SNIPER_RAMPAGE(bool arg1, bool arg2)
	{
		SetObtain(arg2, "light_sniper");
	}

	private void SetBlockUmbrella(bool arg1, bool arg2)
	{
		SetObtain(arg2, "blockUmbrella");
	}

	private void SetSkinBlockUmbrellaFlower(bool arg1, bool arg2)
	{
		SetObtain(arg2, "skinBlockUmbrellaFlower");
	}

	private void SetIsThirdPersonView(bool ov, bool flag)
	{
		_isThirdPersonView = flag;
		if (_isThirdPersonView && !RuleUtilty.IsSurvivalPvp(_battleRoomContext.roomData.Data.RaceType) && _battleRoomContext.roomData.Data.RaceType != 120 && _weaponContext.currentWeaponEntity != null && _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName != "goldhoop_bar" && _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName != "thunder_submachinegun_legend1" && _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName != "thunder_submachinegun_legend2")
		{
			_viewModel.ShowShow = false;
			return;
		}
		ShowLast();
		_viewModel.ShowShow = _states.Count > 0;
	}

	private void SetObtain(bool flag, string state, string weaponName = "")
	{
		if (UiIEventCondition.Get_uiRoomData_GameRule().IsBio3() && state != "PollutionShielding" && _states.Contains("PollutionShielding"))
		{
			return;
		}
		if (flag)
		{
			if (!_states.Contains(state))
			{
				_states.Add(state);
			}
			if (!_assets.ContainsKey(state))
			{
				return;
			}
			ObtainSuppliesViewModel viewModel = _viewModel;
			ObtainSuppliesViewModel viewModel2 = _viewModel;
			ObtainSuppliesViewModel viewModel3 = _viewModel;
			Sprite sprite3 = (_viewModel.RtSprite = this.GetLoader().RetriveSprite(string.IsNullOrEmpty(weaponName) ? _assets[state] : new AssetInfo(string.Format(_assets[state].BundleName, weaponName), string.Format(_assets[state].AssetName, weaponName)), delegate(Sprite sprite)
			{
				ObtainSuppliesViewModel viewModel4 = _viewModel;
				ObtainSuppliesViewModel viewModel5 = _viewModel;
				ObtainSuppliesViewModel viewModel6 = _viewModel;
				Sprite sprite8 = (_viewModel.RtSprite = sprite);
				Sprite sprite10 = (viewModel6.LbSprite = sprite8);
				Sprite ltSprite2 = (viewModel5.RbSprite = sprite10);
				viewModel4.LtSprite = ltSprite2;
			}));
			Sprite sprite5 = (viewModel3.LbSprite = sprite3);
			Sprite ltSprite = (viewModel2.RbSprite = sprite5);
			viewModel.LtSprite = ltSprite;
			_flag = 1f;
			_changeAlpha = !_notChangeAlpha.Contains(state);
			_viewModel.ShowAlpha = 0.5f;
			_viewModel.ShowShow = !_isThirdPersonView || (_isThirdPersonView && _thirdViewHasState.Contains(state)) || _battleRoomContext.roomData.Data.RaceType == 120 || RuleUtilty.IsSurvivalPvp(_battleRoomContext.roomData.Data.RaceType);
			if (!_centerAssets.ContainsKey(state))
			{
				_viewModel.CenterShow = false;
				return;
			}
			_viewModel.CenterSprite = this.GetLoader().RetriveSprite(_centerAssets[state], delegate(Sprite sprite)
			{
				_viewModel.CenterSprite = sprite;
				_viewModel.CenterNtvsize();
			});
			_viewModel.CenterShow = true;
		}
		else
		{
			if (_states.Contains(state))
			{
				_states.Remove(state);
				ShowLast();
			}
			_viewModel.ShowShow = _states.Count > 0;
			if (!_viewModel.ShowShow)
			{
				_viewModel.CenterShow = false;
			}
			_viewModel.RtColor = new Color(1f, 1f, 1f);
			_viewModel.RbColor = new Color(1f, 1f, 1f);
		}
	}

	private void ShowLast()
	{
		if (_states.Count <= 0)
		{
			return;
		}
		string text = _states.Last();
		if (_assets.ContainsKey(text))
		{
			ObtainSuppliesViewModel viewModel = _viewModel;
			ObtainSuppliesViewModel viewModel2 = _viewModel;
			ObtainSuppliesViewModel viewModel3 = _viewModel;
			Sprite sprite3 = (_viewModel.RtSprite = this.GetLoader().RetriveSprite(_assets[text], delegate(Sprite sprite)
			{
				ObtainSuppliesViewModel viewModel4 = _viewModel;
				ObtainSuppliesViewModel viewModel5 = _viewModel;
				ObtainSuppliesViewModel viewModel6 = _viewModel;
				Sprite sprite8 = (_viewModel.RtSprite = sprite);
				Sprite sprite10 = (viewModel6.LbSprite = sprite8);
				Sprite ltSprite2 = (viewModel5.RbSprite = sprite10);
				viewModel4.LtSprite = ltSprite2;
			}));
			Sprite sprite5 = (viewModel3.LbSprite = sprite3);
			Sprite ltSprite = (viewModel2.RbSprite = sprite5);
			viewModel.LtSprite = ltSprite;
		}
		_changeAlpha = !_notChangeAlpha.Contains(text);
		if (!_centerAssets.ContainsKey(text))
		{
			_viewModel.CenterShow = false;
			return;
		}
		_viewModel.CenterSprite = this.GetLoader().RetriveSprite(_centerAssets[text], delegate(Sprite sprite)
		{
			_viewModel.CenterSprite = sprite;
			_viewModel.CenterNtvsize();
		});
		_viewModel.CenterShow = true;
	}

	private void UpdateAlpha(int frameTime)
	{
		if (!_changeAlpha)
		{
			_viewModel.ShowAlpha = 1f;
			return;
		}
		if (_states.Contains("twinsInfinity") && UiIEventCondition.Get_weaponState_WeaponName().Contains("twins_infinity") && _viewModel.RbColor != redColor && _viewModel.RtColor != redColor)
		{
			_viewModel.RbColor = redColor;
			_viewModel.RtColor = redColor;
		}
		float num = _viewModel.ShowAlpha + (float)frameTime / 1000f * 0.5f * _flag;
		if (num >= 1f)
		{
			_flag = -1f;
			num = 1f;
		}
		else if ((double)num <= 0.5)
		{
			_flag = 1f;
			num = 0.5f;
		}
		_viewModel.ShowAlpha = num;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		SetNewAddObtainSupplieConfig();
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
