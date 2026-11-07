using System.Collections.Generic;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class SceneMapModule : GameModule
{
	private LoadSkyboxSystem _loadSkyboxSystem;

	private LoadLightMapSystem _loadLightMapSystem;

	private SceneHomeGunGridSystem _sceneHomeGunGridSystem;

	protected override void OnAddResourceInitSystems(Contexts contexts, List<IResourceInitSystem> systems)
	{
		systems.Add(_loadSkyboxSystem);
		systems.Add(_loadLightMapSystem);
		systems.Add(new SceneEffectInitSystem(contexts.sceneObject));
	}

	protected override void OnAddEntityCreateSystems(Contexts contexts, List<IEntityCreateSystem> systems)
	{
		systems.Add(new SceneMapEntityCreateSystem(contexts));
		systems.Add(new LoadPyEngineSystem(contexts));
	}

	protected override void OnAddResourceLoadSystems(Contexts contexts, List<IResourceLoadSystem> systems)
	{
		systems.Add(new LoadSceneViewSystem(contexts));
		systems.Add(_loadSkyboxSystem);
		systems.Add(_loadLightMapSystem);
		systems.Add(new LoadSceneSoundSystem(contexts));
		systems.Add(new LoadSceneEffectSystem(contexts));
		systems.Add(_sceneHomeGunGridSystem);
	}

	protected override void OnAddPlaybackSystems(Contexts contexts, List<IPlaybackSystem> systems)
	{
		systems.Add(new ChangeLightMapSystem(contexts));
		systems.Add(new ChangeSkyBoxSystem(contexts));
		systems.Add(new HideSkyboxSystem(contexts));
		systems.Add(new LoadCustomWaterSystem(contexts));
		systems.Add(new LoadSceneBloomSystem(contexts));
		systems.Add(new SceneRenderPvsStateSystem(contexts));
	}

	protected override void OnAddRenderSystems(Contexts contexts, List<IRenderSystem> systems)
	{
		systems.Add(new MapEffectRenderSystem(contexts));
		systems.Add(_sceneHomeGunGridSystem);
	}

	public SceneMapModule(Contexts contexts)
		: base(contexts)
	{
		_loadSkyboxSystem = new LoadSkyboxSystem(contexts);
		_loadLightMapSystem = new LoadLightMapSystem(contexts);
		_sceneHomeGunGridSystem = new SceneHomeGunGridSystem(contexts);
	}
}
