using System.Collections.Generic;
using Assets.Sources.Components.Weapon;
using Assets.Sources.Framework;
using Assets.Sources.Info.Weapon;
using Entitas;
using NetData;
using SSJJAnim.Weapon;
using SSJJBase.Logger;
using weapon.predicateSystem;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class WeaponEntityCreateSystem : IEntityCreateSystem
{
	private readonly IGroup<PlayerBagEntity> _normalBags;

	private readonly PlayerBagContext _playerBagContext;

	private readonly WeaponContext _weaponContext;

	private readonly IGroup<WeaponEntity> _destroyGroup;

	private readonly PlayerContext _playerContext;

	private readonly List<int> _destoryList = new List<int>();

	public WeaponEntityCreateSystem(Contexts contexts)
	{
		_playerBagContext = contexts.playerBag;
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
		_normalBags = _playerBagContext.GetGroup(PlayerBagMatcher.AllOf(PlayerBagMatcher.BasicInfo).NoneOf(PlayerBagMatcher.C4Bag));
		_destroyGroup = contexts.weapon.GetGroup(WeaponMatcher.Destroy);
	}

	public void OnEntityCreate()
	{
		_destoryList.Clear();
		foreach (WeaponEntity item in _weaponContext)
		{
			_destoryList.Add(item.weaponId.Value);
		}
		foreach (PlayerBagEntity normalBag in _normalBags)
		{
			PlayerBagData data = normalBag.basicInfo.Data;
			CreateWeaponEntity(data.FirstWeapon, data.BagId, 1, 0);
			CreateWeaponEntity(data.SecondaryWeapon, data.BagId, 2, 0);
			CreateWeaponEntity(data.MeleeWeapon, data.BagId, 3, 0);
			CreateWeaponEntity(data.BombWeapons0, data.BagId, 4, 0);
			CreateWeaponEntity(data.BombWeapons1, data.BagId, 4, 1);
			CreateWeaponEntity(data.BombWeapons2, data.BagId, 4, 2);
		}
		if (_playerBagContext.c4BagEntity != null)
		{
			CreateWeaponEntity(_playerBagContext.c4Bag.C4Weapon, -1, 5, 0);
		}
		foreach (int destory in _destoryList)
		{
			WeaponEntity entityWithWeaponId = _weaponContext.GetEntityWithWeaponId(destory);
			if (entityWithWeaponId != null)
			{
				entityWithWeaponId.isDestroy = true;
			}
		}
		foreach (WeaponEntity item2 in _destroyGroup)
		{
			item2.Destroy();
		}
	}

	private void CreateWeaponEntity(BaseWeaponData data, int bagId, int slot, int index)
	{
		if (data == null)
		{
			return;
		}
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(data.WeaponName);
		PredicationConfig predicationConfig = PredicationConfigFactory.Instance.GetPredicationConfig(data.WeaponName);
		if (weaponInfo == null)
		{
			this.LogErrorFormat("WeaponInfo not exist when create entity {0} bagId {1} slot {2} index {3}", data.WeaponName, bagId, slot, index);
			return;
		}
		WeaponEntity weaponEntity = _weaponContext.GetEntityWithWeaponId(data.Id);
		if (weaponEntity == null)
		{
			weaponEntity = _weaponContext.CreateEntity();
			weaponEntity.AddWeaponId(data.Id);
			weaponEntity.AddSlot(bagId, slot, index);
			weaponEntity.AddSpread(0f, weaponInfo.SpreadScaleY);
			weaponEntity.AddAccuracy(weaponInfo.DefaultAccuracy);
			weaponEntity.AddBasicInfo(data, weaponInfo, predicationConfig);
			weaponEntity.AddClip(weaponInfo.MaxClip, weaponInfo.MaxCarryClip, weaponInfo.MaxClip2, weaponInfo.MaxCarryClip2, weaponInfo.MaxClip, weaponInfo.MaxClip2, weaponInfo.MaxCarryClip, weaponInfo.MaxCarryClip2);
			weaponEntity.AddMeleeAttack(newMeleeAttack: false, newMeleeStartAttack: false);
			weaponEntity.AddComponent(14, new ReloadComponent());
			weaponEntity.AddComponent(3, new AttackComponent());
			weaponEntity.AddComponent(10, new DirectionComponent());
			weaponEntity.AddComponent(6, new BurstModeComponent());
			weaponEntity.AddComponent(16, new SpecialComponent());
			weaponEntity.AddComponent(13, new PowerComponent());
			weaponEntity.AddComponent(5, new BlockTimerComponent());
			weaponEntity.AddAttach(weaponInfo.AttachFactory.Craete());
			weaponEntity.special.RaiseAttackDelay = 300;
		}
		_destoryList.Remove(data.Id);
		weaponEntity.basicInfo.Data = data;
	}
}
