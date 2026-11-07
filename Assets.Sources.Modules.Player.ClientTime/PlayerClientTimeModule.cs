using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.ClientTime;

public class PlayerClientTimeModule : GameModule
{
	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerClientTimePredicationInitSystem(contexts));
	}

	public PlayerClientTimeModule(Contexts contexts)
		: base(contexts)
	{
	}
}
