using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Attack.WeaponLock;
using SSJJAnim.Weapon;
using SSJJUserCmd;

namespace Assets.Sources.Modules.Player.Attack;

internal class PlayerWeaponLockPredicationSystem : IPredicateSystem
{
	private readonly IPredicateSystem _defaultPredicateSystem;

	private readonly Dictionary<int, IPredicateSystem> _subSystems = new Dictionary<int, IPredicateSystem>();

	private readonly Dictionary<string, IPredicateSystem> _specialSystems = new Dictionary<string, IPredicateSystem>();

	protected readonly WeaponContext WeaponContext;

	public PlayerWeaponLockPredicationSystem(Contexts contexts)
	{
		WeaponContext = contexts.weapon;
		_subSystems.Add(37, new M60LockPredicationSystem(contexts));
		_subSystems.Add(76, new M60LockPredicationSystem(contexts));
		_subSystems.Add(67, new GatlingGLockPredicationSystem(contexts));
		_subSystems.Add(87, new MetalStormLockPrediactionSystem(contexts));
		_subSystems.Add(107, new DummyLockPredicationSystem(contexts));
		_subSystems.Add(122, new DummyLockPredicationSystem(contexts));
		_defaultPredicateSystem = new DefaultLockPrediactionSystem(contexts);
		_specialSystems.Add("awm_wolf", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("qbz95_wolf", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("xm1014_wolf", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("m4a1_dawn", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("lr4_dawn", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("m1887_dawn", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("hunter_ak47", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("hunter_xm1014", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("hunter_vss", new WolfSuitLockPrediactionSystem(contexts));
		_specialSystems.Add("hero_weapon_base", new HeroWeaponBaseLockPredicationSystem(contexts));
		_specialSystems.Add("hero_close", new HeroCloseLockPredicationSystem(contexts));
		_specialSystems.Add("herowoman_close", new HeroCloseLockPredicationSystem(contexts));
		_specialSystems.Add("light_with_shadow", new UsingBigSkillLockPredictionSystem(contexts));
	}

	public void OnPredicate(PlayerEntity myPlayer, IUserCmd cmd)
	{
		if (WeaponContext == null || myPlayer.basicInfo.IsDead || myPlayer.currentWeapon.WeaponInfo == null)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = WeaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			IPredicateSystem value;
			if (_specialSystems.ContainsKey(currentWeaponEntity.basicInfo.Info.Name))
			{
				value = _specialSystems[currentWeaponEntity.basicInfo.Info.Name];
			}
			else if (currentWeaponEntity.special.SpecialMode)
			{
				_subSystems.TryGetValue((int)(myPlayer.currentWeapon.WeaponInfo as IWeaponInfo).SpecialAttackType, out value);
			}
			else
			{
				_subSystems.TryGetValue((int)(myPlayer.currentWeapon.WeaponInfo as IWeaponInfo).AttackType, out value);
			}
			if (value == null)
			{
				value = _defaultPredicateSystem;
			}
			value.OnPredicate(myPlayer, cmd);
		}
	}
}
