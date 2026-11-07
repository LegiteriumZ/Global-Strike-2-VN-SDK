using Assets.Sources.Framework;
using Assets.Sources.Utils.ComponentInit;
using Entitas;
using SSJJBase.Thread;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class ThirdPersonCleanupSystem : IEntityDestroySystem, IResourceLoadSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private readonly IGroup<PlayerEntity> _thirdPersonPlayers;

	public ThirdPersonCleanupSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.Destroy));
		_thirdPersonPlayers = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects));
	}

	public void OnEntityDestroy()
	{
		foreach (PlayerEntity player in _players)
		{
			PlayerEntityUtility.CleanupThirdPersonUnityObjects(player);
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (PlayerEntity thirdPersonPlayer in _thirdPersonPlayers)
		{
			if (thirdPersonPlayer.basicInfo.Current.RoleColors != thirdPersonPlayer.thirdPersonUnityObjects.DyeingColors || thirdPersonPlayer.basicInfo.Current.DyeingColor != thirdPersonPlayer.thirdPersonUnityObjects.WeaponDyeingColors)
			{
				PlayerEntityUtility.CleanupThirdPersonUnityObjects(thirdPersonPlayer);
			}
		}
	}
}
