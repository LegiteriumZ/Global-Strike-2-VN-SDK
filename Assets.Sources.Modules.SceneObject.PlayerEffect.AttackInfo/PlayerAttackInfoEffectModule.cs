using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.AttackInfo;

public class PlayerAttackInfoEffectModule : GameModule
{
	public PlayerAttackInfoEffectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerAttackInfoEffectCreateSystem(contexts));
		systems.Add(new PlayerAttackInfoEffectPlayBackSystem(contexts));
		systems.Add(new PlayerAttackInfoEffectDestorySystem(contexts));
	}
}
