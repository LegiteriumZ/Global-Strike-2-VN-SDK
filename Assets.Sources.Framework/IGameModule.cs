using System.Collections.Generic;

namespace Assets.Sources.Framework;

public interface IGameModule
{
	List<IEntityCreateSystem> EntityCreateSystems { get; }

	List<IModuleInitSystem> InitializeSystems { get; }

	List<IPredicationInitSystem> PredicationInitSystems { get; }

	List<IPlaybackInitSystem> PlaybackInitSystems { get; }

	List<IPredicateSystem> PredicationSystems { get; }

	List<IPlaybackSystem> PlaybackSystems { get; }

	List<IPreRenderSystem> PreRenderSystems { get; }

	List<IRenderSystem> RenderSystems { get; }

	List<IResourceLoadSystem> ResourceLoadSystems { get; }

	List<IResourceLoadSystem> CommonResourceLoadSystems { get; }

	List<IResourceInitSystem> ResourceInitSystems { get; }

	List<IResourceLoadSystem> PlaybackResourceLoadSystems { get; }

	List<IResourceInitSystem> PlaybackResourceInitSystems { get; }

	List<IEntityDestroySystem> EntityDestroySystems { get; }

	List<IEntityPreDestroySystem> EntityPreDestroySystems { get; }

	List<IEntityPostDestroySystem> EntityPostDestroySystems { get; }

	List<IAfterPredicationSystem> AfterPredicationSystems { get; }

	void Init();
}
