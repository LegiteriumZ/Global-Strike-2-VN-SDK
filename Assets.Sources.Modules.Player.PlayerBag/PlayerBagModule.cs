using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.PlayerBag;

public class PlayerBagModule : GameModule
{
	private PlayerWeaponConfigPreLoadSystem _weaponConfigPreloadSystem;

	public PlayerBagModule(Contexts contexts)
		: base(contexts)
	{
		_weaponConfigPreloadSystem = new PlayerWeaponConfigPreLoadSystem(contexts);
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new PlayerBagEntityCreateSystem(contexts));
		systems.Add(new WeaponEntityCreateSystem(contexts));
	}

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerWeaponInitSystem(contexts));
		systems.Add(new WeaponClipInitSystem(contexts));
		systems.Add(new WeaponReloadInitSystem(contexts));
		systems.Add(new WeaponAttackInitSystem(contexts));
		systems.Add(new WeaponDirectionInitSystem(contexts));
		systems.Add(new WeaponSpecialInitSystem(contexts));
		systems.Add(new WeaponPowerInitSystem(contexts));
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PlayerWeaponInitSystem(contexts));
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_weaponConfigPreloadSystem);
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_weaponConfigPreloadSystem);
	}
}
