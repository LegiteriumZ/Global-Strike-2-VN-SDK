using System.Collections.Generic;
using SSJJBase.Thread;
using SSJJUserCmd;

namespace Assets.Sources.Framework;

public abstract class GameModule : IGameModule
{
	private Contexts _contexts;

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

	public List<IResourceLoadSystem> PlaybackResourceLoadSystems => _playbackResourceLoadSystems;

	public List<IResourceInitSystem> PlaybackResourceInitSystems => _playbackResourceInitSystems;

	public List<IPredicateSystem> PredicationSystems => _predicationSystems;

	public List<IPlaybackSystem> PlaybackSystems => _playbackSystems;

	public List<IAfterPredicationSystem> AfterPredicationSystems => _afterPredicationSystems;

	public List<IPreRenderSystem> PreRenderSystems => _preRenderSystems;

	public List<IRenderSystem> RenderSystems => _renderSystems;

	public List<IResourceLoadSystem> ResourceLoadSystems => _resourceLoadSystems;

	public List<IResourceLoadSystem> CommonResourceLoadSystems => _commonResourceLoadSystems;

	public List<IResourceInitSystem> ResourceInitSystems => _resourceInitSystems;

	public List<IEntityDestroySystem> EntityDestroySystems => _entityDestroySystems;

	public List<IEntityPreDestroySystem> EntityPreDestroySystems => _entityPreDestroySystems;

	public List<IEntityPostDestroySystem> EntityPostDestroySystems => _entityPostDestroySystems;

	public Contexts Contexts => _contexts;

	public virtual bool BlockSibling { get; set; }

	protected GameModule(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Init()
	{
		_initializeSystems = GetModuleInitSystems();
		_entityCreateSystems = GetEntityCreateSystems();
		_playbackSystems = GetPlaybackSystems();
		_playbackInitSystems = GetPlaybackInitSystems();
		_predicationInitSystems = GetPredicationInitSystems();
		_predicationSystems = GetPredicationSystems();
		_afterPredicationSystems = GerAfterPredicationSystems();
		_preRenderSystems = GetPreRenderSystems();
		_renderSystems = GetRenderSystems();
		_resourceLoadSystems = GetResourceLoadSystems();
		_commonResourceLoadSystems = GetCommonResourceLoadSystems();
		_resourceInitSystems = GetResourceInitSystems();
		_playbackResourceLoadSystems = GetPlaybackResourceLoadSystems();
		_playbackResourceInitSystems = GetPlaybackResourceInitSystems();
		_entityDestroySystems = GetEntityDestroySystems();
		_entityPreDestroySystems = GetEntityPreDestroySystems();
		_entityPostDestroySystems = GetEntityPostDestroySystems();
	}

	private List<IAfterPredicationSystem> GerAfterPredicationSystems()
	{
		List<IAfterPredicationSystem> list = new List<IAfterPredicationSystem>();
		OnAddAfterPredicationSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddAfterPredicationSystems(Contexts contexts, List<IAfterPredicationSystem> systems)
	{
	}

	private List<IResourceInitSystem> GetPlaybackResourceInitSystems()
	{
		List<IResourceInitSystem> list = new List<IResourceInitSystem>();
		OnAddPlaybackResourceInitSystems(_contexts, list);
		return list;
	}

	private List<IResourceLoadSystem> GetPlaybackResourceLoadSystems()
	{
		List<IResourceLoadSystem> list = new List<IResourceLoadSystem>();
		OnAddPlaybackResourceLoadSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddPlaybackResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
	}

	protected virtual void OnAddPlaybackResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
	}

	public List<IModuleInitSystem> GetModuleInitSystems()
	{
		List<IModuleInitSystem> list = new List<IModuleInitSystem>();
		OnAddInitializeSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddInitializeSystems(Contexts contexts, List<IModuleInitSystem> systems)
	{
	}

	public List<IEntityCreateSystem> GetEntityCreateSystems()
	{
		List<IEntityCreateSystem> list = new List<IEntityCreateSystem>();
		OnAddEntityCreateSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
	}

	public List<IEntityDestroySystem> GetEntityDestroySystems()
	{
		List<IEntityDestroySystem> list = new List<IEntityDestroySystem>();
		OnAddEntityDestroySystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddEntityDestroySystems(Contexts contexts, List<IEntityDestroySystem> systems)
	{
	}

	public List<IEntityPreDestroySystem> GetEntityPreDestroySystems()
	{
		List<IEntityPreDestroySystem> list = new List<IEntityPreDestroySystem>();
		OnAddEntityPreDestroySystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddEntityPreDestroySystems(Contexts contexts, List<IEntityPreDestroySystem> systems)
	{
	}

	public List<IEntityPostDestroySystem> GetEntityPostDestroySystems()
	{
		List<IEntityPostDestroySystem> list = new List<IEntityPostDestroySystem>();
		OnAddEntityPostDestroySystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddEntityPostDestroySystems(Contexts contexts, List<IEntityPostDestroySystem> systems)
	{
	}

	public List<IPredicationInitSystem> GetPredicationInitSystems()
	{
		List<IPredicationInitSystem> list = new List<IPredicationInitSystem>();
		OnAddPredicationInitSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddPredicationInitSystems(Contexts contexts, List<IPredicationInitSystem> systems)
	{
	}

	public List<IPlaybackInitSystem> GetPlaybackInitSystems()
	{
		List<IPlaybackInitSystem> list = new List<IPlaybackInitSystem>();
		OnAddPlaybackInitSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddPlaybackInitSystems(Contexts contexts, List<IPlaybackInitSystem> systems)
	{
	}

	public List<IPredicateSystem> GetPredicationSystems()
	{
		List<IPredicateSystem> list = new List<IPredicateSystem>();
		OnAddPredicationSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddPredicationSystems(Contexts contexts, List<IPredicateSystem> systems)
	{
	}

	public List<IPlaybackSystem> GetPlaybackSystems()
	{
		List<IPlaybackSystem> list = new List<IPlaybackSystem>();
		OnAddPlaybackSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
	}

	public List<IRenderSystem> GetRenderSystems()
	{
		List<IRenderSystem> list = new List<IRenderSystem>();
		OnAddRenderSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
	}

	public List<IPreRenderSystem> GetPreRenderSystems()
	{
		List<IPreRenderSystem> list = new List<IPreRenderSystem>();
		OnAddPreRenderSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddPreRenderSystems(Contexts contexts, List<IPreRenderSystem> systems)
	{
	}

	public List<IResourceLoadSystem> GetResourceLoadSystems()
	{
		List<IResourceLoadSystem> list = new List<IResourceLoadSystem>();
		OnAddResourceLoadSystems(_contexts, list);
		return list;
	}

	public List<IResourceLoadSystem> GetCommonResourceLoadSystems()
	{
		List<IResourceLoadSystem> list = new List<IResourceLoadSystem>();
		OnAddCommonResourceLoadSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddCommonResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
	}

	protected virtual void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
	}

	public List<IResourceInitSystem> GetResourceInitSystems()
	{
		List<IResourceInitSystem> list = new List<IResourceInitSystem>();
		OnAddResourceInitSystems(_contexts, list);
		return list;
	}

	protected virtual void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
	}

	public void OnPlaybackInit()
	{
		foreach (IPlaybackInitSystem playbackInitSystem in _playbackInitSystems)
		{
			playbackInitSystem.OnPlaybackInit();
		}
	}

	public void OnPredicatoinInit(PlayerEntity player)
	{
		foreach (IPredicationInitSystem predicationInitSystem in _predicationInitSystems)
		{
			predicationInitSystem.OnPredicatoinInit();
		}
	}

	public void OnPlayback()
	{
		foreach (IPlaybackSystem playbackSystem in _playbackSystems)
		{
			playbackSystem.OnPlayback();
		}
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (IResourceLoadSystem resourceLoadSystem in _resourceLoadSystems)
		{
			resourceLoadSystem.OnLoadResources(coRoutineManager);
		}
	}

	public void OnEntityDestroy()
	{
		foreach (IEntityDestroySystem entityDestroySystem in _entityDestroySystems)
		{
			entityDestroySystem.OnEntityDestroy();
		}
	}

	public void OnEntityCreate()
	{
		foreach (IEntityCreateSystem entityCreateSystem in _entityCreateSystems)
		{
			entityCreateSystem.OnEntityCreate();
		}
	}

	public void OnRender()
	{
		foreach (IRenderSystem renderSystem in _renderSystems)
		{
			renderSystem.OnRender();
		}
	}

	public void OnPreRender()
	{
		foreach (IPreRenderSystem preRenderSystem in _preRenderSystems)
		{
			preRenderSystem.OnPreRender();
		}
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		foreach (IPredicateSystem predicationSystem in _predicationSystems)
		{
			predicationSystem.OnPredicate(player, cmd);
		}
	}

	public void OnInitModule()
	{
		foreach (IModuleInitSystem initializeSystem in _initializeSystems)
		{
			initializeSystem.OnInitModule();
		}
	}

	public void OnInitResources()
	{
		foreach (IResourceInitSystem resourceInitSystem in _resourceInitSystems)
		{
			resourceInitSystem.OnInitResources();
		}
	}

	public void OnEntityPreDestroy()
	{
		foreach (IEntityPreDestroySystem entityPreDestroySystem in _entityPreDestroySystems)
		{
			entityPreDestroySystem.OnEntityPreDestroy();
		}
	}

	public void OnEntityPostDestroy()
	{
		foreach (IEntityPostDestroySystem entityPostDestroySystem in _entityPostDestroySystems)
		{
			entityPostDestroySystem.OnEntityPostDestroy();
		}
	}
}
