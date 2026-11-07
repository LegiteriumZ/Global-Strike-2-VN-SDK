using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.Accessory;

public class PlayerAccessoryModule : GameModule
{
	private BackAccessoryLoadSystem _accessoryLoadSystem;

	private BackWeaponLoadSystem _backWeaponLoadSystem;

	private WaistJewelryAccessoryLoadSystem _waistJewelryAccessoryLoadSystem;

	private ViewAccessoryLoadSystem _viewAccessoryLoadSystem;

	public PlayerAccessoryModule(Contexts contexts)
		: base(contexts)
	{
		_accessoryLoadSystem = new BackAccessoryLoadSystem(contexts);
		_backWeaponLoadSystem = new BackWeaponLoadSystem(contexts);
		_waistJewelryAccessoryLoadSystem = new WaistJewelryAccessoryLoadSystem(contexts);
		_viewAccessoryLoadSystem = new ViewAccessoryLoadSystem(contexts);
	}

	protected override void OnAddPlaybackResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_accessoryLoadSystem);
		systems.Add(_backWeaponLoadSystem);
		systems.Add(_waistJewelryAccessoryLoadSystem);
		systems.Add(_viewAccessoryLoadSystem);
	}

	protected override void OnAddPlaybackResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_accessoryLoadSystem);
		systems.Add(_backWeaponLoadSystem);
		systems.Add(_waistJewelryAccessoryLoadSystem);
		systems.Add(_viewAccessoryLoadSystem);
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(_accessoryLoadSystem);
		systems.Add(new ViewAccessoryPlaybackSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new BackAccessoryRenderSystem(contexts));
		systems.Add(new WaistJewelryAccessoryRenderSystem(contexts));
		systems.Add(new ViewAccessoryRenderSystem(contexts));
	}
}
