using System.Collections.Generic;
using Entitas.VisualDebugging.Unity;

namespace Assets.Sources.Framework.System;

public sealed class GameModuleFeature : Feature
{
	private EntityCreateSystem _entityCreateSystem;

	private PlaybackInitSystem _playbackInitSystem;

	private PredicationInitSystem _predicationInitSystem;

	private PlaybackSystem _playbackSystem;

	private PredicationSystem _predicationSystem;

	private AfterPredicationSystem _afterPredicationSystem;

	private ResourceLoadSystem _resourceLoadSystem;

	private CommonResourceLoadSystem _commonResourceLoadSystem;

	private ResourceInitSystem _resourceInitSystem;

	private PlaybackResourceLoadSystem _playbackResourceLoadSystem;

	private PlaybackResourceInitSystem _playbackResourceInitSystem;

	private PreRenderSystem _preRenderSystem;

	private RenderSystem _renderSystem;

	private EntityPreDestroySystem _entityPreDestroySystem;

	private EntityDestroySystem _entityDestroySystem;

	private EntityPostDestroySystem _entityPostDestroySystem;

	private List<SystemInfo> _debugInfos = new List<SystemInfo>();

	private float _deltaTime;

	public static GameModuleFeature Instance { get; private set; }

	public void Clear()
	{
		Instance = null;
		_debugInfos.Clear();
		_entityCreateSystem.Systems.Clear();
		_playbackInitSystem.Systems.Clear();
		_predicationInitSystem.Systems.Clear();
		_playbackSystem.Systems.Clear();
		_predicationSystem.Systems.Clear();
		_afterPredicationSystem.Systems.Clear();
		_resourceLoadSystem.Systems.Clear();
		_commonResourceLoadSystem.Systems.Clear();
		_resourceInitSystem.Systems.Clear();
		_playbackResourceLoadSystem.Systems.Clear();
		_playbackResourceInitSystem.Systems.Clear();
		_preRenderSystem.Systems.Clear();
		_renderSystem.Systems.Clear();
		_entityPreDestroySystem.Systems.Clear();
		_entityDestroySystem.Systems.Clear();
		_entityPostDestroySystem.Systems.Clear();
		_entityCreateSystem = null;
		_playbackInitSystem = null;
		_predicationInitSystem = null;
		_playbackSystem = null;
		_predicationSystem = null;
		_afterPredicationSystem = null;
		_resourceLoadSystem = null;
		_commonResourceLoadSystem = null;
		_resourceInitSystem = null;
		_playbackResourceLoadSystem = null;
		_playbackResourceInitSystem = null;
		_preRenderSystem = null;
		_renderSystem = null;
		_entityPreDestroySystem = null;
		_entityDestroySystem = null;
		_entityPostDestroySystem = null;
	}

	public GameModuleFeature(Contexts contexts, IGameModule topLevelGameModule)
	{
		Instance = this;
		topLevelGameModule.Init();
		Add(new ModuleInitSystem(topLevelGameModule));
		Add(_entityCreateSystem = new EntityCreateSystem(topLevelGameModule));
		Add(_playbackInitSystem = new PlaybackInitSystem(contexts, topLevelGameModule));
		Add(_predicationInitSystem = new PredicationInitSystem(contexts, topLevelGameModule));
		Add(_playbackResourceLoadSystem = new PlaybackResourceLoadSystem(topLevelGameModule));
		Add(_playbackResourceInitSystem = new PlaybackResourceInitSystem(topLevelGameModule));
		Add(_playbackSystem = new PlaybackSystem(contexts, topLevelGameModule));
		Add(_predicationSystem = new PredicationSystem(contexts, topLevelGameModule));
		Add(_afterPredicationSystem = new AfterPredicationSystem(topLevelGameModule));
		Add(_resourceLoadSystem = new ResourceLoadSystem(topLevelGameModule));
		Add(_commonResourceLoadSystem = new CommonResourceLoadSystem(topLevelGameModule));
		Add(_resourceInitSystem = new ResourceInitSystem(topLevelGameModule));
		Add(_preRenderSystem = new PreRenderSystem(topLevelGameModule));
		Add(_renderSystem = new RenderSystem(topLevelGameModule));
		Add(_entityPreDestroySystem = new EntityPreDestroySystem(topLevelGameModule));
		Add(_entityDestroySystem = new EntityDestroySystem(topLevelGameModule));
		Add(_entityPostDestroySystem = new EntityPostDestroySystem(topLevelGameModule));
	}
}
