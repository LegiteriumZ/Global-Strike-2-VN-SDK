using System;
using System.Collections.Generic;
using Assets.Sources.Modules.Common;
using Entitas;

namespace Assets.Sources.Modules.Player;

public class PlayerContextResourceInfo : IContextResourceInfo, IContextDestroyInfo, IContextCommonInfo
{
	private readonly IGroup<PlayerEntity> _loadResourceEntities;

	private readonly IGroup<PlayerEntity> _destroyEntities;

	private readonly int[] _loadComponentIds = new int[9] { 97, 94, 95, 91, 92, 98, 99, 93, 96 };

	private readonly int[] _unityComponentIds = new int[9] { 103, 90, 100, 84, 86, 106, 109, 88, 101 };

	private readonly Type[] _componentTypes = PlayerComponentsLookup.componentTypes;

	public int[] LoadComponentIds => _loadComponentIds;

	public int[] UnityComponentIds => _unityComponentIds;

	public Type[] ComponentTypes => _componentTypes;

	public List<IEntity> LoadResourceEntities => _loadResourceEntities.GetEntities();

	public string[] ComponentNames => PlayerComponentsLookup.componentNames;

	public int DestroyComponentId => 1;

	public List<IEntity> DestoryEntities => _destroyEntities.GetEntities();

	public PlayerContextResourceInfo(Contexts contexts)
	{
		_loadResourceEntities = contexts.player.GetGroup(PlayerMatcher.AnyOf(PlayerMatcher.LoadThirdPersonResource, PlayerMatcher.LoadFirstPersonViewResource, PlayerMatcher.LoadModelEffectResource, PlayerMatcher.LoadAccessoryResource, PlayerMatcher.LoadBackWeaponResource, PlayerMatcher.LoadViewAccessoryResource, PlayerMatcher.LoadWaistJewelryAccessoryResource, PlayerMatcher.LoadPlayerVolumeResource, PlayerMatcher.LoadBagWeaponConfigResource));
		_destroyEntities = contexts.player.GetGroup(PlayerMatcher.AnyOf(PlayerMatcher.Destroy));
	}
}
