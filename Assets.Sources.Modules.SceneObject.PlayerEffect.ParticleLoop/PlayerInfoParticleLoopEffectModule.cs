using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.ParticleLoop;

public class PlayerInfoParticleLoopEffectModule : GameModule
{
	public PlayerInfoParticleLoopEffectModule(Contexts contexts)
		: base(contexts)
	{
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerInfoParticleLoopEffectCreateSystem(contexts));
		systems.Add(new PlayerInfoParticleLoopEffectPlayBackSystem(contexts));
		systems.Add(new PlayerInfoParticleLoopEffectDestorySystem(contexts));
	}
}
