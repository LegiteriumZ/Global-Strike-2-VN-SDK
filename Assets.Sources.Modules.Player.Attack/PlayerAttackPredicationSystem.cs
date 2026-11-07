using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.SharePredicationApapter;
using Assets.Sources.Modules.Player.Attack.WeaponAttack;
using Assets.Sources.Utils;
using SSJJAnim.Weapon;
using SSJJBase.Logger;
using SSJJUserCmd;
using Sources.Modules.Player.Attack.WeaponAttack;

namespace Assets.Sources.Modules.Player.Attack;

public class PlayerAttackPredicationSystem : IPredicateSystem
{
	private readonly Dictionary<int, IPredicateSystem> _subSystems = new Dictionary<int, IPredicateSystem>();

	protected readonly WeaponContext WeaponContext;

	private readonly WorldCameraContext _cameraContext;

	private readonly SnapshotContext _snapContext;

	public PlayerAttackPredicationSystem(Contexts contexts)
	{
		WeaponPredicationUtility.Init();
		WeaponContext = contexts.weapon;
		_cameraContext = contexts.worldCamera;
		_snapContext = contexts.snapshot;
		_subSystems.Add(8, new KnifeAttackPredicationSystem(contexts));
		_subSystems.Add(210, new KunlunGongzhuKnifeAttackPredicationSystem(contexts));
		_subSystems.Add(117, new HanSwordAttackPredicationSystem(contexts));
		_subSystems.Add(0, new GrenadePredicationSystem(contexts));
		_subSystems.Add(1, new RiflePredicationSystem(contexts));
		_subSystems.Add(3, new RifleMeleePredicationSystem(contexts));
		_subSystems.Add(4, new RifleMelee2PredicationSystem(contexts));
		_subSystems.Add(9, new PistolPredicationSystem(contexts));
		_subSystems.Add(12, new PistolColt1873PredicationSystem(contexts));
		_subSystems.Add(10, new PistolMeleePredicationSystem(contexts));
		_subSystems.Add(11, new PistolMelee2PredicationSystem(contexts));
		_subSystems.Add(15, new ShotGunPistolPredicationSystem(contexts));
		_subSystems.Add(16, new SlimeGunPredicationSystem(contexts));
		_subSystems.Add(5, new SniperRiflePredicationSystem(contexts));
		_subSystems.Add(6, new SniperRifle2PredicationSystem(contexts));
		_subSystems.Add(7, new SniperRifle3PredicationSystem(contexts));
		_subSystems.Add(17, new ShotGunPredicationSystem(contexts));
		_subSystems.Add(14, new DoubleShotGunPredicationSystem(contexts));
		_subSystems.Add(13, new ShotGunMeleePredicationSystem(contexts));
		_subSystems.Add(18, new RifleScopePredicationSystem(contexts));
		_subSystems.Add(19, new RifleScope2PredicationSystem(contexts));
		_subSystems.Add(20, new DoublePistolPredicationSystem(contexts));
		_subSystems.Add(21, new BurstPistolPredicationSystem(contexts));
		_subSystems.Add(22, new DoubleRiflelPredicationSystem(contexts));
		_subSystems.Add(24, new GatlingPredicationSystem(contexts));
		_subSystems.Add(25, new DoubleScythePredicationSystem(contexts));
		_subSystems.Add(26, new BarrelShotGunPredicationSystem(contexts));
		_subSystems.Add(27, new BloodShotGunPredicationSystem(contexts));
		_subSystems.Add(28, new SawPredicationSystem(contexts));
		_subSystems.Add(29, new Cz75PredicationSystem(contexts));
		_subSystems.Add(30, new UavPredicationSystem(contexts));
		_subSystems.Add(31, new SlingShotPredicationSystem(contexts));
		_subSystems.Add(32, new PistolScopePredicationSystem(contexts));
		_subSystems.Add(33, new PistolScope2PredicationSystem(contexts));
		_subSystems.Add(23, new DoubleUziPredicationSystem(contexts));
		_subSystems.Add(34, new BowPredicationSystem(contexts));
		_subSystems.Add(35, new GhostTwinsPredicationSystem(contexts));
		_subSystems.Add(36, new GhostTwinsSpecialPredicationSystem(contexts));
		_subSystems.Add(37, new M60PredicationSystem(contexts));
		_subSystems.Add(76, new WhiteTigerPredicationSystem(contexts));
		_subSystems.Add(38, new RoarSniperPredicationSystem(contexts));
		_subSystems.Add(39, new RoarSniperSpecialPredicationSystem(contexts));
		_subSystems.Add(40, new PistolStormHerosPredicationSystem(contexts));
		_subSystems.Add(43, new Qbz95HeroPredicationSystem(contexts));
		_subSystems.Add(41, new TripleAttackKnifePredicationSystem(contexts));
		_subSystems.Add(42, new GoldSaberPredicationSystem(contexts));
		_subSystems.Add(44, new GoldSnakeKnifePredicationSystem(contexts));
		_subSystems.Add(45, new ElectricPistolPredicationSystem(contexts));
		_subSystems.Add(46, new ElectricRiflePredicationSystem(contexts));
		_subSystems.Add(47, new GrenadeRiflePredicationSystem(contexts));
		_subSystems.Add(48, new GrenadeRifleSpecialPredicationSystem(contexts));
		_subSystems.Add(49, new MiniDeathRiflePredicationSystem(contexts));
		_subSystems.Add(50, new MiniDeath1RiflePredicationSystem(contexts));
		_subSystems.Add(51, new Mp5IcePredicationSystem(contexts));
		_subSystems.Add(52, new BurstRiflePredicationSystem(contexts));
		_subSystems.Add(53, new BowBurnPredicationSystem(contexts));
		_subSystems.Add(54, new Type97PredicationSystem(contexts));
		_subSystems.Add(55, new WolfClawPredicationSystem(contexts));
		_subSystems.Add(56, new AngerFireScarPredicationSystem(contexts));
		_subSystems.Add(57, new AngerFireScarSpecialPredicationSystem(contexts));
		_subSystems.Add(58, new BladeShieldPredicationSystem(contexts));
		_subSystems.Add(59, new BladeShieldHeroPredicationSystem(contexts));
		_subSystems.Add(60, new G36CPredicationSystem(contexts));
		_subSystems.Add(61, new G36CSpecialPredicationSystem(contexts));
		_subSystems.Add(62, new HighGrenadeGPredicationSystem(contexts));
		_subSystems.Add(63, new M249RocketPredicationSystem(contexts));
		_subSystems.Add(64, new Mp7a1TacticPredicationSystem(contexts));
		_subSystems.Add(65, new FN2000PredicationSystem(contexts));
		_subSystems.Add(66, new Ad16CrazyDevilPredicationSystem(contexts));
		_subSystems.Add(67, new GatlingGPredicationSystem(contexts));
		_subSystems.Add(68, new Ak47LegendPredicationSystem(contexts));
		_subSystems.Add(69, new Mp5Sd6PredicationSystem(contexts));
		_subSystems.Add(70, new PistolRiotshieldPredicationSystem(contexts));
		_subSystems.Add(71, new PistolRiotshield1PredicationSystem(contexts));
		_subSystems.Add(72, new TmpPredicationSystem(contexts));
		_subSystems.Add(73, new DartsRedflashPredicationSystem(contexts));
		_subSystems.Add(74, new RpgRedflashPredicationSystem(contexts));
		_subSystems.Add(75, new ShotGunLaserPredicationSystem(contexts));
		_subSystems.Add(77, new P28CannonPredicationSystem(contexts));
		_subSystems.Add(78, new SanDanHeroSpecial(contexts));
		_subSystems.Add(79, new BowGodPredicationSystem(contexts));
		_subSystems.Add(80, new BlackLightCrossbowSpecial(contexts));
		_subSystems.Add(81, new AK47RedflashPredicationSystem(contexts));
		_subSystems.Add(82, new Mk14RedflashPredicationSystem(contexts));
		_subSystems.Add(83, new PhotonDeformationPredicationSystem(contexts));
		_subSystems.Add(84, new PhotonDeformationSpecialPredicationSystem(contexts));
		_subSystems.Add(85, new GlockRedflashPredicationSystem(contexts));
		_subSystems.Add(86, new AwpHellSnakePredicationSystem(contexts));
		_subSystems.Add(87, new MetalStormPredicationSystem(contexts));
		_subSystems.Add(88, new PhotonCombinationPredicationSystem(contexts));
		_subSystems.Add(89, new PhotonPistolCombinationPredicationSystem(contexts));
		_subSystems.Add(96, new PhotonPistolCombinationPredicationSystem(contexts));
		_subSystems.Add(90, new R28RiflePredicationSystem(contexts));
		_subSystems.Add(91, new HeroBladePredicationSystem(contexts));
		_subSystems.Add(92, new RevolverRedflashPredicationSystem(contexts));
		_subSystems.Add(93, new GlockHellSnakePredicationSystem(contexts));
		_subSystems.Add(94, new AwmLegendBasePredicationSystem(contexts));
		_subSystems.Add(95, new AwmLegendBaseSpecialPredicationSystem(contexts));
		_subSystems.Add(97, new BlackLightCrossbowPredicationSystem(contexts));
		_subSystems.Add(98, new LightingStarPredicationSystem(contexts));
		_subSystems.Add(99, new AwakeClawPredicationSystem(contexts));
		_subSystems.Add(100, new MikadukiSwordPredicationSystem(contexts));
		_subSystems.Add(101, new RPG7RocketPredicationSystem(contexts));
		_subSystems.Add(102, new FakeDoubleMeleePredicationSystem(contexts));
		_subSystems.Add(103, new Ak47StrikePredicationSystem(contexts));
		_subSystems.Add(106, new PistolElectricPredicationSystem(contexts));
		_subSystems.Add(104, new M4a1LegendBasePredicationSystem(contexts));
		_subSystems.Add(105, new M4a1LegendBase2PredicationSystem(contexts));
		_subSystems.Add(107, new DummyAttackPredicationSystem(contexts));
		_subSystems.Add(207, new DummyAttackPredicationSystem(contexts));
		_subSystems.Add(108, new JusticeFromAbovePredicationSystem(contexts));
		_subSystems.Add(109, new PistolFrozenAirPredicationSystem(contexts));
		_subSystems.Add(110, new BladeStrikePredicationSystem(contexts));
		_subSystems.Add(111, new AnimalAttackPredicationSystem(contexts));
		_subSystems.Add(112, new RevolverBattlePredicationSystem(contexts));
		_subSystems.Add(113, new DeagleStrikePredicationSystem(contexts));
		_subSystems.Add(114, new Qbz951stPredicationSystem(contexts));
		_subSystems.Add(115, new MikadukiSwordDklPredicationSystem(contexts));
		_subSystems.Add(116, new G3sg1PredicationSystem(contexts));
		_subSystems.Add(118, new Spas12PredicationSystem(contexts));
		_subSystems.Add(120, new ElectriElementPredicationSystem(contexts));
		_subSystems.Add(119, new HonorShieldPredicationSystem(contexts));
		_subSystems.Add(121, new M4A1GPredicationSystem(contexts));
		_subSystems.Add(123, new AwmStrikePredicationSystem(contexts));
		_subSystems.Add(124, new RiderSlingShotPredicationSystem(contexts));
		_subSystems.Add(125, new RiderSwordPredicationSystem(contexts));
		_subSystems.Add(126, new RiderGrenadePredicationSystem(contexts));
		_subSystems.Add(127, new RiderDouGunPredicationSystem(contexts));
		_subSystems.Add(128, new NbrKnifeAttackPredicationSystem(contexts));
		_subSystems.Add(122, new Mechfar2AttackPredication(contexts));
		_subSystems.Add(129, new CyBerPunkSwordAttackPredicationSystem(contexts));
		_subSystems.Add(130, new MentalBursterPredicationSystem(contexts));
		_subSystems.Add(131, new InfiniteHand1PredicationSystem(contexts));
		_subSystems.Add(132, new InfiniteHand1Change1PredicationSystem(contexts));
		_subSystems.Add(133, new InfiniteHand1Change2PredicationSystem(contexts));
		_subSystems.Add(134, new RifleScope3PredicationSystem(contexts));
		_subSystems.Add(135, new RifleOpticorPredicationSystem(contexts));
		_subSystems.Add(136, new RifleMeleeNotSpecialPredicationSystem(contexts));
		_subSystems.Add(137, new RifleMeleeSpecialPredicationSystem(contexts));
		_subSystems.Add(138, new InductionPredicationSystem(contexts));
		_subSystems.Add(139, new RiflePistolPredicationSystem(contexts));
		_subSystems.Add(140, new SwordHeavenJudgeAttackPredicationSystem(contexts));
		_subSystems.Add(141, new SelfDisciplineGunPredicationSystem(contexts));
		_subSystems.Add(142, new ShowGunGrenadePredicationSystem(contexts));
		_subSystems.Add(143, new DaggerBulletBursterPredicationSystem(contexts));
		_subSystems.Add(144, new GatlingDouRage1PredicationSystem(contexts));
		_subSystems.Add(145, new GatlingDouRage2PredicationSystem(contexts));
		_subSystems.Add(146, new BlockCombinedPredicationSystem(contexts));
		_subSystems.Add(147, new M4A1KnightPredicationSystem(contexts));
		_subSystems.Add(148, new VoidSpearPredicationSystem(contexts));
		_subSystems.Add(149, new BlockCombinedFlamethrowerSystem(contexts));
		_subSystems.Add(151, new RevengeBerserkerM4a1PredicationSystem(contexts));
		_subSystems.Add(150, new ArcElectricShotgunPredicationSystem(contexts));
		_subSystems.Add(152, new Ak47UniquePredicationSystem(contexts));
		_subSystems.Add(153, new AutoPistolMeleePredicationSystem(contexts));
		_subSystems.Add(154, new BursterNailsKnifePredicationSystem(contexts));
		_subSystems.Add(155, new ShotGunLaserLitePredicationSystem(contexts));
		_subSystems.Add(156, new LittlePiggyPredicationSystem(contexts));
		_subSystems.Add(157, new HunterVssPredicationSystem(contexts));
		_subSystems.Add(159, new DawnLightShotgunPredicationSystem(contexts));
		_subSystems.Add(160, new WindBoxerPredicationSystem(contexts));
		_subSystems.Add(161, new GuarddianStickPredicationSystem(contexts));
		_subSystems.Add(158, new MG4PredictionSystem(contexts));
		_subSystems.Add(162, new CrystalBowPredicationSystem(contexts));
		_subSystems.Add(163, new TrickDaggerPredicationSystem(contexts));
		_subSystems.Add(164, new TwinsInfinitePredicationSystem(contexts));
		_subSystems.Add(165, new CrossNailShotgunPredicationSystem(contexts));
		_subSystems.Add(166, new PhasewalkerPredicationSystem(contexts));
		_subSystems.Add(167, new BananaPistolPredicationSystem(contexts));
		_subSystems.Add(168, new ShotGunWalkerPredicationSystem(contexts));
		_subSystems.Add(2, new Rifle2PredicationSystem(contexts));
		_subSystems.Add(169, new DoubleBladePredicationSystem(contexts));
		_subSystems.Add(172, new TrickGlassDartsPredicationSystem(contexts));
		_subSystems.Add(170, new M4a1ProPredicationSystem(contexts));
		_subSystems.Add(171, new UspProPredicationSystem(contexts));
		_subSystems.Add(181, new VoidJumpPredicationSystem(contexts));
		_subSystems.Add(173, new JudgeEyeRifle1PredicationSystem(contexts));
		_subSystems.Add(174, new JudgeEyeRifle2PredicationSystem(contexts));
		_subSystems.Add(175, new VoidLinkPredicationSystem(contexts));
		_subSystems.Add(177, new HeroClosePredicationSystem(contexts));
		_subSystems.Add(178, new HeroWomanClosePredication(contexts));
		_subSystems.Add(176, new HeroGunPredicationSystem(contexts));
		_subSystems.Add(179, new LegoShotgunPistolPredicationSystem(contexts));
		_subSystems.Add(180, new SniperGuardianPredicationSystem(contexts));
		_subSystems.Add(182, new ThunderScepterPredicationSystem(contexts));
		_subSystems.Add(183, new HormoneInjectionPredicationSystem(contexts));
		_subSystems.Add(184, new HeroWeaponBasePredicationSystem(contexts));
		_subSystems.Add(185, new ShieldCannonPredicationSystem(contexts));
		_subSystems.Add(186, new Shak12PredicationSystem(contexts));
		_subSystems.Add(187, new M2MachineGunPredicationSystem(contexts));
		_subSystems.Add(188, new DataCubePredicationSystem(contexts));
		_subSystems.Add(189, new PickaxePredicationSystem(contexts));
		_subSystems.Add(190, new ParasiticSniperPredicationSystem(contexts));
		_subSystems.Add(191, new FishSwordPredicationSystem(contexts));
		_subSystems.Add(192, new Type91DaggerPredicationSystem(contexts));
		_subSystems.Add(193, new LightEdgeGrenadePredicationSystem(contexts));
		_subSystems.Add(194, new BlockShortBowPredicationSystem(contexts));
		_subSystems.Add(195, new SkyDomeBeaconPredicationSystem(contexts));
		_subSystems.Add(196, new SpikeRiflePredicationSystem(contexts));
		_subSystems.Add(197, new BlinkShadowPredicationSystem(contexts));
		_subSystems.Add(198, new HandOfZeusPredicationSystem(contexts));
		_subSystems.Add(199, new Qbz97PredicationSystem(contexts));
		_subSystems.Add(200, new BigFishSwordPredicationSystem(contexts));
		_subSystems.Add(201, new M249MoonPredicationSystem(contexts));
		_subSystems.Add(202, new SeaOfSharkPredicationSystem(contexts));
		_subSystems.Add(203, new WhiteSwordGunPredicationSystem(contexts));
		_subSystems.Add(204, new ShadowDemonBayonetPredicationSystem(contexts));
		_subSystems.Add(205, new ShadowDemonPredicationSystem(contexts));
		_subSystems.Add(206, new FeatherBowPredicationSystem(contexts));
		_subSystems.Add(208, new Sa58FuturePredicationSystem(contexts));
		_subSystems.Add(209, new YueTuPredicationSystem(contexts));
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (WeaponContext == null)
		{
			return;
		}
		if (_cameraContext.hasCameraData && _cameraContext.cameraData.IsUsingXpSkill && cmd is UserCmd userCmd)
		{
			userCmd.Buttons &= -833;
			userCmd.Weapon = 0;
			userCmd.BagId = 0;
			userCmd.QButton = false;
		}
		if (myPlayer.basicInfo.IsDead || myPlayer.currentWeapon.WeaponInfo == null || myPlayer.basicInfo.Current.UsingBigSkill)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !myPlayer.CanAttack(currentWeaponEntity) || (_snapContext.snapshots.NowSnapshot != null && _snapContext.snapshots.NowSnapshot.ControlId > 0 && _snapContext.snapshots.NowSnapshot.ControlId != myPlayer.entityId.Value))
		{
			return;
		}
		if (myPlayer.currentWeapon.WeaponInfo.SharedPredication)
		{
			WeaponPredicationUtility.CommonWeaponArgs.CmdPropertiesAdapter.Cmd = cmd;
			WeaponPredicationUtility.CommonWeaponArgs.WeaponPropertiesAdapter.WeaponEntity = currentWeaponEntity;
			WeaponPredicationUtility.CommonWeaponArgs.PlayerPropertiesAdapter = myPlayer;
			AttackPredicationManager.Instance.OnPredicate(WeaponPredicationUtility.CommonWeaponArgs);
			return;
		}
		IPredicateSystem value;
		if (currentWeaponEntity.special.SpecialMode)
		{
			_subSystems.TryGetValue((int)(myPlayer.currentWeapon.WeaponInfo as IWeaponInfo).SpecialAttackType, out value);
		}
		else
		{
			_subSystems.TryGetValue((int)(myPlayer.currentWeapon.WeaponInfo as IWeaponInfo).AttackType, out value);
		}
		if (value == null)
		{
			this.LogErrorFormat("Attack\u3000Predication is not implemented for {0}", myPlayer.currentWeapon.WeaponInfo.Name);
		}
		else
		{
			value.OnPredicate(myPlayer, cmd);
		}
	}
}
