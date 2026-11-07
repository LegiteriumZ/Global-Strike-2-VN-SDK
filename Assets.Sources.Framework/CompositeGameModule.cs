using System.Collections.Generic;

namespace Assets.Sources.Framework;

public class CompositeGameModule : IGameModule
{
	private readonly List<IGameModule> _modules = new List<IGameModule>();

	private List<IEntityCreateSystem> _entityCreateSystems;

	private List<IModuleInitSystem> _initializeSystems;

	private List<IPredicationInitSystem> _predicationInitSystems;

	private List<IPlaybackInitSystem> _playbackInitSystems;

	private List<IPredicateSystem> _predicationSystems;

	private List<IAfterPredicationSystem> _afterPredicationSystems;

	private List<IPlaybackSystem> _playbackSystems;

	private List<IPreRenderSystem> _preRenderSystems;

	private List<IRenderSystem> _renderSystems;

	private List<IResourceLoadSystem> _resourceLoadSystems;

	private List<IResourceLoadSystem> _commonResourceLoadSystems;

	private List<IResourceInitSystem> _resourceInitSystems;

	private List<IResourceLoadSystem> _playbackResourceLoadSystems;

	private List<IResourceInitSystem> _playbackResourceInitSystems;

	private List<IEntityDestroySystem> _entityDestroySystems;

	private List<IEntityPreDestroySystem> _entityPreDestroySystems;

	private List<IEntityPostDestroySystem> _entityPostDestroySystems;

	public List<IEntityCreateSystem> EntityCreateSystems => _entityCreateSystems;

	public List<IModuleInitSystem> InitializeSystems => _initializeSystems;

	public List<IPredicationInitSystem> PredicationInitSystems => _predicationInitSystems;

	public List<IPlaybackInitSystem> PlaybackInitSystems => _playbackInitSystems;

	public List<IPredicateSystem> PredicationSystems => _predicationSystems;

	public List<IPlaybackSystem> PlaybackSystems => _playbackSystems;

	public List<IPreRenderSystem> PreRenderSystems => _preRenderSystems;

	public List<IRenderSystem> RenderSystems => _renderSystems;

	public List<IResourceLoadSystem> ResourceLoadSystems => _resourceLoadSystems;

	public List<IResourceLoadSystem> CommonResourceLoadSystems => _commonResourceLoadSystems;

	public List<IResourceInitSystem> ResourceInitSystems => _resourceInitSystems;

	public List<IResourceLoadSystem> PlaybackResourceLoadSystems => _playbackResourceLoadSystems;

	public List<IResourceInitSystem> PlaybackResourceInitSystems => _playbackResourceInitSystems;

	public List<IEntityDestroySystem> EntityDestroySystems => _entityDestroySystems;

	public List<IEntityPreDestroySystem> EntityPreDestroySystems => _entityPreDestroySystems;

	public List<IEntityPostDestroySystem> EntityPostDestroySystems => _entityPostDestroySystems;

	public List<IAfterPredicationSystem> AfterPredicationSystems => _afterPredicationSystems;

	public CompositeGameModule AddModule(IGameModule module)
	{
		_modules.Add(module);
		return this;
	}

	public void Init()
	{
		foreach (IGameModule module in _modules)
		{
			module.Init();
		}
		_entityCreateSystems = new List<IEntityCreateSystem>();
		_initializeSystems = new List<IModuleInitSystem>();
		_predicationInitSystems = new List<IPredicationInitSystem>();
		_playbackInitSystems = new List<IPlaybackInitSystem>();
		_predicationSystems = new List<IPredicateSystem>();
		_afterPredicationSystems = new List<IAfterPredicationSystem>();
		_playbackSystems = new List<IPlaybackSystem>();
		_preRenderSystems = new List<IPreRenderSystem>();
		_renderSystems = new List<IRenderSystem>();
		_resourceLoadSystems = new List<IResourceLoadSystem>();
		_commonResourceLoadSystems = new List<IResourceLoadSystem>();
		_resourceInitSystems = new List<IResourceInitSystem>();
		_playbackResourceLoadSystems = new List<IResourceLoadSystem>();
		_playbackResourceInitSystems = new List<IResourceInitSystem>();
		_entityDestroySystems = new List<IEntityDestroySystem>();
		_entityPreDestroySystems = new List<IEntityPreDestroySystem>();
		_entityPostDestroySystems = new List<IEntityPostDestroySystem>();
		foreach (IGameModule module2 in _modules)
		{
			_initializeSystems.AddRange(module2.InitializeSystems);
			_entityCreateSystems.AddRange(module2.EntityCreateSystems);
			_predicationInitSystems.AddRange(module2.PredicationInitSystems);
			_predicationSystems.AddRange(module2.PredicationSystems);
			_afterPredicationSystems.AddRange(module2.AfterPredicationSystems);
			_playbackInitSystems.AddRange(module2.PlaybackInitSystems);
			_playbackSystems.AddRange(module2.PlaybackSystems);
			_preRenderSystems.AddRange(module2.PreRenderSystems);
			_renderSystems.AddRange(module2.RenderSystems);
			_resourceLoadSystems.AddRange(module2.ResourceLoadSystems);
			_commonResourceLoadSystems.AddRange(module2.CommonResourceLoadSystems);
			_resourceInitSystems.AddRange(module2.ResourceInitSystems);
			_playbackResourceLoadSystems.AddRange(module2.PlaybackResourceLoadSystems);
			_playbackResourceInitSystems.AddRange(module2.PlaybackResourceInitSystems);
			_entityDestroySystems.AddRange(module2.EntityDestroySystems);
			_entityPreDestroySystems.AddRange(module2.EntityPreDestroySystems);
			_entityPostDestroySystems.AddRange(module2.EntityPostDestroySystems);
		}
	}
}
