using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Ui.Weapon;

public class WeaponModule : GameModule
{
	private readonly WeaponModelDelegate _delegate;

	public WeaponModule(Contexts contexts)
		: base(contexts)
	{
		_delegate = new WeaponModelDelegate(contexts);
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(_delegate);
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_delegate);
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_delegate);
	}
}
