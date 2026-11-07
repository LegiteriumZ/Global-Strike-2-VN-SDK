using System.Collections.Generic;
using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Utils.AssetManager;
using NetData;
using SSJJAnim.Weapon;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearWeaponPoolPushHandler : ApcPacketHandler<WeaponPoolPush>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearWeaponPoolPushHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 259;
	}

	public override void Handle(WeaponPoolPush data)
	{
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		mouseYear.MasterWeaponPools = data.MasterWeaponPool;
		mouseYear.SecondWeaponPools = data.SecondWeaponPool;
		mouseYear.CloseWeaponPools = data.ClosedWeaponPool;
		mouseYear.GrenadeWeaponPools = data.GrenadeWeaponPool;
		RandomWeapons(ref mouseYear.MasterWeaponPools);
		PreloadWeapons(mouseYear.MasterWeaponPools);
		RandomWeapons(ref mouseYear.SecondWeaponPools);
		PreloadWeapons(mouseYear.SecondWeaponPools);
		RandomWeapons(ref mouseYear.CloseWeaponPools);
		PreloadWeapons(mouseYear.CloseWeaponPools);
		RandomWeapons(ref mouseYear.GrenadeWeaponPools);
		PreloadWeapons(mouseYear.GrenadeWeaponPools);
	}

	private void RandomWeapons(ref List<string> weapons)
	{
		if (weapons != null && weapons.Count != 0)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < 10; i++)
			{
				int index = Random.Range(0, weapons.Count);
				list.Add(weapons[index]);
			}
			weapons = list;
		}
	}

	private void PreloadWeapons(List<string> weapons)
	{
		if (weapons == null || weapons.Count == 0)
		{
			return;
		}
		foreach (string weapon in weapons)
		{
			IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(weapon);
			if (weaponInfo != null)
			{
				this.Info("PreLoad Weapon > " + weapon);
				SingletonInstance<AssetPool>.Instance.LoadAndAdd(weaponInfo.GetWeaponIconAssetInfo(""), BaseAsyncManager.Instance);
			}
		}
	}
}
