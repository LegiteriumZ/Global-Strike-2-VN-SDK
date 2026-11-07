using System.Collections.Generic;
using Assets.Sources.Components.Unload;
using Assets.Sources.Info.Weapon;
using SSJJAnim.Weapon;
using UnityEngine;

namespace Assets.Sources.Utils;

public class SelfCircleUnloadThirdPersonWeaponUtility
{
	public static void LoadThirdRes(PlayerEntity playerEntity, IWeaponInfo weaponInfo, WeaponSkinInfo weaponSkinInfo)
	{
		UnloadThirdWeaponResComponent unloadThirdWeaponRes = Contexts.sharedInstance.unload.unloadThirdWeaponResEntity.unloadThirdWeaponRes;
		if (unloadThirdWeaponRes.ResRecords == null)
		{
			unloadThirdWeaponRes.ResRecords = new List<UnloadThirdWeaponResComponent.RecordRes>();
		}
		string name = weaponInfo.Name;
		bool flag = false;
		foreach (UnloadThirdWeaponResComponent.RecordRes resRecord in unloadThirdWeaponRes.ResRecords)
		{
			if (playerEntity.entityId.Value == resRecord.EntityId)
			{
				if (resRecord.WeaponName == name)
				{
					flag = true;
					resRecord.IsUsing = true;
					resRecord.LastUseTime = (int)Time.time;
				}
				else
				{
					resRecord.IsUsing = false;
				}
			}
		}
		if (!flag)
		{
			UnloadThirdWeaponResComponent.RecordRes item = new UnloadThirdWeaponResComponent.RecordRes
			{
				IsUsing = true,
				LastUseTime = (int)Time.time,
				WeaponName = name,
				EntityId = playerEntity.entityId.Value
			};
			unloadThirdWeaponRes.ResRecords.Add(item);
		}
	}
}
