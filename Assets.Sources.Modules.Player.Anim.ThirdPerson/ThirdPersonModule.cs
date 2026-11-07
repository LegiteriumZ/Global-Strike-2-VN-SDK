using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Player.Anim.ThirdPerson.AnimWarp;
using Assets.Sources.Modules.Player.Anim.ThirdPerson.TPS;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class ThirdPersonModule : GameModule
{
	private LoadThirdPersonSystem _loadThirdPersonSystem;

	private ThirdPersonCleanupSystem _thirdPersonCleanupSystem;

	protected override void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
		systems.Add(new PlayerLegAnimInitSystem(contexts));
		systems.Add(new PlayerTorseAnimInitSystem(contexts));
	}

	protected override void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
		systems.Add(new PlayerLegAnimInitSystem(contexts));
		systems.Add(new PlayerTorseAnimInitSystem(contexts));
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new PlayerAnimThreadDispatchSystem(contexts));
		systems.Add(new PlayerLegAnimPlaybackSystem(contexts));
		systems.Add(new PlayerLegWrapAnimPlaybackSystem(contexts));
		systems.Add(new PlayerTorseAnimPlaybackSystem(contexts));
		systems.Add(new GPUAnimSystem(contexts));
		systems.Add(new LegAnimSystem(contexts));
		systems.Add(new TpsLegAnimSystem(contexts));
		systems.Add(new LegWarpAnimSystem(contexts));
		systems.Add(new TorseAnimSystem(contexts));
		systems.Add(new TpsTorseAnimSystem(contexts));
		systems.Add(new TorseWarpAnimSystem(contexts));
		systems.Add(new OrientationAnimSystem(contexts));
	}

	protected override void OnAddPreRenderSystems(Contexts contexts, List<IPreRenderSystem> systems)
	{
		systems.Add(new SwitchThirdPersonSystem(contexts));
		systems.Add(new PlayerBoneMaskSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new PlayerJointsRenderSystem(contexts));
		systems.Add(new ThirdPersonScaleSystem(contexts));
	}

	protected override void OnAddPlaybackResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_loadThirdPersonSystem);
	}

	protected override void OnAddPlaybackResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_loadThirdPersonSystem);
	}

	protected override void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
		systems.Add(_thirdPersonCleanupSystem);
	}

	protected override void OnAddAfterPredicationSystems(Contexts contexts, List<IAfterPredicationSystem> systems)
	{
		systems.Add(new PlayerDyBoneSystem(contexts));
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(_thirdPersonCleanupSystem);
	}

	public ThirdPersonModule(Contexts contexts)
		: base(contexts)
	{
		_loadThirdPersonSystem = new LoadThirdPersonSystem(contexts);
		_thirdPersonCleanupSystem = new ThirdPersonCleanupSystem(contexts);
	}
}
