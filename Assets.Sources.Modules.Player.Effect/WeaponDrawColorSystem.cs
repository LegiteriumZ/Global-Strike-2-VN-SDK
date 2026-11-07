using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Utils.Weapon;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class WeaponDrawColorSystem : IPreRenderSystem
{
	private IGroup<PlayerEntity> _thirdGroup;

	private IGroup<PlayerEntity> _firstGroup;

	private IGroup<PlayerEntity> _BackWeaponGroup;

	private WeaponColorData _defaultWeaponColorData;

	public WeaponDrawColorSystem(Contexts contexts)
	{
		_defaultWeaponColorData = new WeaponColorData
		{
			R = 1f,
			G = 1f,
			B = 1f,
			A = 1f
		};
		_firstGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.BasicInfo));
		_thirdGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.BasicInfo));
		_BackWeaponGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BackWeaponUnityObjects, PlayerMatcher.BasicInfo));
	}

	public void OnPreRender()
	{
		foreach (PlayerEntity item in _BackWeaponGroup)
		{
			SkinnedMeshRenderer[] skinRenders = item.backWeaponUnityObjects.Render.getSkinRenders();
			WeaponColorData entityBackWeaponColorData = GetEntityBackWeaponColorData(item);
			if (!IsColorEqual(entityBackWeaponColorData, item.backWeaponUnityObjects.Render.getWeaponColorData()))
			{
				item.backWeaponUnityObjects.Render.setWeaponColorData(entityBackWeaponColorData);
				WeaponUtility.SetWeaponColor(entityBackWeaponColorData, skinRenders);
			}
		}
		foreach (PlayerEntity item2 in _thirdGroup)
		{
			SkinnedMeshRenderer[] weaponSkinnedMeshRenders = item2.thirdPersonUnityObjects.WeaponSkinnedMeshRenders;
			WeaponColorData entityWeaponColorData = GetEntityWeaponColorData(item2);
			if (!IsColorEqual(entityWeaponColorData, item2.thirdPersonUnityObjects.ColorData))
			{
				item2.thirdPersonUnityObjects.ColorData = entityWeaponColorData;
				WeaponUtility.SetWeaponColor(entityWeaponColorData, weaponSkinnedMeshRenders);
			}
		}
		foreach (PlayerEntity item3 in _firstGroup)
		{
			SkinnedMeshRenderer[] weaponSkinnedMeshRenderers = item3.firstPersonUnityObjects.WeaponSkinnedMeshRenderers;
			WeaponColorData entityWeaponColorData2 = GetEntityWeaponColorData(item3);
			if (!IsColorEqual(entityWeaponColorData2, item3.firstPersonUnityObjects.ColorData))
			{
				item3.firstPersonUnityObjects.ColorData = entityWeaponColorData2;
				WeaponUtility.SetWeaponColor(entityWeaponColorData2, weaponSkinnedMeshRenderers);
			}
		}
	}

	private WeaponColorData GetEntityBackWeaponColorData(PlayerEntity entity)
	{
		ISnapshot latestSnapshot = Contexts.sharedInstance.snapshot.snapshots.LatestSnapshot;
		PlayerEntityData value = null;
		WeaponColorData weaponColorData = null;
		if (latestSnapshot.PlayerEntityDataDict.TryGetValue(entity.entityId.Value, out value))
		{
			weaponColorData = value.BackWeaponColorData;
		}
		if (weaponColorData == null)
		{
			weaponColorData = _defaultWeaponColorData;
		}
		return weaponColorData;
	}

	private WeaponColorData GetEntityWeaponColorData(PlayerEntity entity)
	{
		ISnapshot latestSnapshot = Contexts.sharedInstance.snapshot.snapshots.LatestSnapshot;
		PlayerEntityData value = null;
		WeaponColorData weaponColorData = null;
		if (latestSnapshot.PlayerEntityDataDict.TryGetValue(entity.entityId.Value, out value))
		{
			weaponColorData = value.WeaponColorData;
		}
		if (weaponColorData == null)
		{
			weaponColorData = _defaultWeaponColorData;
		}
		return weaponColorData;
	}

	private bool IsColorEqual(WeaponColorData newColorData, WeaponColorData originColorData)
	{
		if (Mathf.Approximately(newColorData.A, originColorData.A) && Mathf.Approximately(newColorData.B, originColorData.B) && Mathf.Approximately(newColorData.G, originColorData.G))
		{
			return Mathf.Approximately(newColorData.R, originColorData.R);
		}
		return false;
	}
}
