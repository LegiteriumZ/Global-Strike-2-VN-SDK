using System;
using Assets.Sources.Framework;
using Assets.Sources.Utils.ComponentInit;
using Entitas;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.Player.Anim.FirstPerson;

public class FirstPersonCleanupSystem : IEntityDestroySystem, IResourceLoadSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private readonly IGroup<PlayerEntity> _firstPersonplayers;

	public FirstPersonCleanupSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Destroy));
		_firstPersonplayers = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects));
	}

	public void OnEntityDestroy()
	{
		foreach (PlayerEntity player in _players)
		{
			PlayerEntityUtility.CleanupFirstPersonUnityObjects(player);
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (PlayerEntity firstPersonplayer in _firstPersonplayers)
		{
			if (firstPersonplayer.basicInfo.IsDead || !firstPersonplayer.isCameraOwner || !firstPersonplayer.isFirstPersonView || firstPersonplayer.currentWeapon.WeaponInfo.Name != firstPersonplayer.firstPersonUnityObjects.WeaponName || firstPersonplayer.currentWeapon.SkinName != firstPersonplayer.firstPersonUnityObjects.WeaponSkinName || Math.Abs(firstPersonplayer.currentWeapon.Worn - firstPersonplayer.firstPersonUnityObjects.Worn) > 0.01f || firstPersonplayer.basicInfo.Current.CurrentHandName != firstPersonplayer.firstPersonUnityObjects.PlayerHandName || firstPersonplayer.basicInfo.Current.RoleColors != firstPersonplayer.firstPersonUnityObjects.DyeingColors || firstPersonplayer.basicInfo.Current.DyeingColor != firstPersonplayer.firstPersonUnityObjects.WeaponDyeingColors)
			{
				PlayerEntityUtility.CleanupFirstPersonUnityObjects(firstPersonplayer);
			}
		}
	}
}
