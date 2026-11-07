using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.Player.EntityCreate;

public class PlayerEntityCreateModule : GameModule
{
	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new PlayerEntityCreateSystem(contexts));
		systems.Add(new PlayerPartEntityCreateSystem(contexts));
		systems.Add(new FakePlayerEntityCreateModule(contexts));
	}

	public PlayerEntityCreateModule(Contexts contexts)
		: base(contexts)
	{
	}
}
