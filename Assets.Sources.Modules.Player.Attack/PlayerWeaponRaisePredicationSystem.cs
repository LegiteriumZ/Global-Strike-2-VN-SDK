using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.SharePredicationApapter;
using Assets.Sources.Modules.Player.Attack.WeaponRaise;
using Assets.Sources.Utils;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack;

internal class PlayerWeaponRaisePredicationSystem : IPredicateSystem
{
	private readonly IPredicateSystem _defaultPredicateSystem;

	private static readonly Dictionary<string, IPredicateSystem> _subSystems = new Dictionary<string, IPredicateSystem>();

	protected readonly WeaponContext WeaponContext;

	public static Dictionary<string, IPredicateSystem> SubSystems => _subSystems;

	public PlayerWeaponRaisePredicationSystem(Contexts contexts)
	{
		WeaponContext = contexts.weapon;
		_subSystems.Add("Special", new SpecialRaisePrediactionSystem(contexts));
		_subSystems.Add("Attack", new AttackRaisePrediactionSystem(contexts));
		_subSystems.Add("Default", new DefaultRaisePrediactionSystem(contexts));
		_subSystems.Add("GlockRedflash", new GlockRedflashRaisePrediactionSystem(contexts));
		_subSystems.Add("HeroBlade", new HeroBladeRaisePredicactionSystem(contexts));
		_subSystems.Add("AwmLegend", new AwmLegendRaisePredicactionSystem(contexts));
		_subSystems.Add("RPG7Rocket", new Rpg7RocketRaisePrediactionSystem(contexts));
		_subSystems.Add("Ak47Strike", new Ak47StrikeRaisePredicactionSystem(contexts));
		_subSystems.Add("DeagleStrike", new DeagleStrikeRaisePredicactionSystem(contexts));
		_subSystems.Add("RiderDouGun", new RiderDouGunRaisePrediactionSystem(contexts));
		_defaultPredicateSystem = new DefaultRaisePrediactionSystem(contexts);
		_subSystems.Add("VoidSpear", new VoidSpearRaisePredicationSystem(contexts));
		_subSystems.Add("TrickDaggerAttack", new TrickDaggerAttackRaisePredicationSystem(contexts));
		_subSystems.Add("TwinsInfinite", new TwinsInfiniteRaisePrediactionSystem(contexts));
		_subSystems.Add("BlinkShadow", new BlinkShadowRaisePredicationSystem(contexts));
		_subSystems.Add("M249Moon", new M249MoonRaisePredicationSystem(contexts));
		_subSystems.Add("Dragonknight2021", new Dragonknight2021RaisePredicationSystem(contexts));
		_subSystems.Add("ScarLegend", new ScarLegendRaisePredicationSystem(contexts));
		_subSystems.Add("FeatherBow", new FeatherBowRaisePredicationSystem(contexts));
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (WeaponContext == null || myPlayer.basicInfo.IsDead || myPlayer.currentWeapon.WeaponInfo == null)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null || !currentWeaponEntity.special.IsRaise)
		{
			return;
		}
		if (myPlayer.currentWeapon.WeaponInfo.SharedPredication)
		{
			WeaponPredicationUtility.CommonWeaponArgs.CmdPropertiesAdapter.Cmd = cmd;
			WeaponPredicationUtility.CommonWeaponArgs.WeaponPropertiesAdapter.WeaponEntity = currentWeaponEntity;
			WeaponPredicationUtility.CommonWeaponArgs.PlayerPropertiesAdapter = myPlayer;
			RaisePredicationManager.Instance.OnPredicate(WeaponPredicationUtility.CommonWeaponArgs);
		}
		else
		{
			_subSystems.TryGetValue(myPlayer.currentWeapon.WeaponInfo.RaiseType, out var value);
			if (value == null)
			{
				value = _defaultPredicateSystem;
			}
			value.OnPredicate(myPlayer, cmd);
		}
		currentWeaponEntity.special.IsRaise = false;
	}
}
