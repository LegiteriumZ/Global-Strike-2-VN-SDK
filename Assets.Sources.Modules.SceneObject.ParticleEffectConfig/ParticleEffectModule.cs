using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.ParticleEffectConfig;

public class ParticleEffectModule : GameModule
{
	private LoadParticleEffectConfigSystem _loadAndInitSystem;

	private HangEffectLoadSystem _hangsystem;

	public ParticleEffectModule(Contexts contexts)
		: base(contexts)
	{
		_loadAndInitSystem = new LoadParticleEffectConfigSystem(contexts);
		_hangsystem = new HangEffectLoadSystem(contexts);
	}

	protected override void OnAddPlaybackResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_loadAndInitSystem);
		systems.Add(_hangsystem);
	}

	protected override void OnAddPlaybackResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_loadAndInitSystem);
		systems.Add(_hangsystem);
	}
}
