using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.SceneObject.NewNpc.Hp;
using Assets.Sources.Modules.SceneObject.NewNpc.StatusEffect;

namespace Assets.Sources.Modules.SceneObject.NewNpc;

public class NewNpcModule : GameModule
{
	private NpcLoadSystem _loadSystem;

	public NewNpcModule(Contexts contexts)
		: base(contexts)
	{
		_loadSystem = new NpcLoadSystem(contexts);
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new NpcEntityCreateSystem(contexts));
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		systems.Add(new NpcCleanupSystem(contexts));
	}

	protected override void OnAddEntityPreDestroySystems(Contexts contexts, List<IEntityPreDestroySystem> systems)
	{
		systems.Add(new NpcEntityDestroySystem(contexts));
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_loadSystem);
		systems.Add(new NpcStatusEffectLoadSystem(contexts));
	}

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_loadSystem);
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new NpcAnimSystem(contexts));
		systems.Add(new NpcDrawColorSystem(contexts));
		systems.Add(new NpcTransformRenderSystem(contexts));
		systems.Add(new NpcNameAndEffectDisplaySystem(contexts));
		systems.Add(new NpcStatusEffectRenderSystem(contexts));
		systems.Add(new NpcChickenEffectRenderSystem(contexts));
		systems.Add(new NpcHpEffectRenderSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new NpcTransformPlaybackSystem(contexts));
	}
}
