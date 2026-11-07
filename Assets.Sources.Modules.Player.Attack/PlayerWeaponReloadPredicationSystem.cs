using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.SharePredicationApapter;
using Assets.Sources.Modules.Player.Attack.WeaponReload;
using Assets.Sources.Utils;
using SSJJAnim.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack;

public class PlayerWeaponReloadPredicationSystem : IPredicateSystem
{
	private readonly Dictionary<string, IPredicateSystem> _subSystems = new Dictionary<string, IPredicateSystem>();

	private readonly WeaponContext _weaponContext;

	public PlayerWeaponReloadPredicationSystem(Contexts contexts)
	{
		_weaponContext = contexts.weapon;
		_subSystems.Add(ReloadType.None.ToString(), new NoneReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Default.ToString(), new DefaultReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.ShotGun.ToString(), new ShotGunReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Double.ToString(), new DoubleReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Cz75.ToString(), new Cz75ReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.M60.ToString(), new M60ReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Corbett.ToString(), new CorbettReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.GatlingG.ToString(), new GatlingGReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Mp5Sd6.ToString(), new Mp5Sd6ReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Riotshield.ToString(), new RiotshieldReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.NotSpecial.ToString(), new NotSpecialReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.SanDanHero.ToString(), new SanDanHeroReloadPredictionSystem(contexts));
		_subSystems.Add(ReloadType.Qbz95Hero.ToString(), new Qbz95HeroReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.GlockRedflash.ToString(), new GlockRedflashReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.RevolverRedflash.ToString(), new RevolverRedflashReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.Rpg7Rocket.ToString(), new Rpg7RocketReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.Ak47Strike.ToString(), new Ak47StrikeReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.PistolElectric.ToString(), new PistolElectricReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.M4a1Legend2.ToString(), new M4a1LegendReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Ak47Legend.ToString(), new Ak47LegendReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Kriss.ToString(), new KrissReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.RevolverBattle.ToString(), new RevolverBattleReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.DeagleStrike.ToString(), new DeagleStrikeReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.Spas12.ToString(), new Spas12ReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.Bow.ToString(), new BowReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.RiderDouGun.ToString(), new RiderDouGunReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.InfiniteHand1Change1.ToString(), new InfiniteHand1Change1ReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Special.ToString(), new SpecialReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.Ak47Unique.ToString(), new Ak47UniqueReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.PhaseWalker.ToString(), new PhaseWalkerReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.TwinsInfinite.ToString(), new TwinsInfiniteReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.BlackLightCrossBow.ToString(), new BlackLightCrossBowReloadPrediactionSystem(contexts));
		_subSystems.Add(ReloadType.M4A1Pro.ToString(), new M4A1ProReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.JudgeEyeRifle.ToString(), new JudgeEyeRifleReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.SniperGuardian.ToString(), new SniperGuardianReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.ThunderScepter.ToString(), new ThunderScepterReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.M249Moon.ToString(), new M249MoonReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.Dragonknight2021.ToString(), new Dragonknight2021ReloadPredicationSystem(contexts));
		_subSystems.Add(ReloadType.ScarLegend.ToString(), new ScarLegendReloadPredicationSystem(contexts));
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (myPlayer.basicInfo.IsDead)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		if (!myPlayer.currentWeapon.WeaponInfo.SharedPredication)
		{
			IPredicateSystem value = null;
			string reloadType = currentWeaponEntity.basicInfo.Info.ReloadType;
			if (myPlayer.CanReload(currentWeaponEntity))
			{
				if (!_subSystems.TryGetValue(reloadType, out value))
				{
					value = _subSystems["Default"];
				}
				value?.OnPredicate(myPlayer, cmd);
			}
		}
		else
		{
			WeaponPredicationUtility.CommonWeaponArgs.CmdPropertiesAdapter.Cmd = cmd;
			WeaponPredicationUtility.CommonWeaponArgs.WeaponPropertiesAdapter.WeaponEntity = currentWeaponEntity;
			WeaponPredicationUtility.CommonWeaponArgs.PlayerPropertiesAdapter = myPlayer;
			ReloadPredicationManager.Instance.OnPredicate(WeaponPredicationUtility.CommonWeaponArgs);
		}
	}
}
