using Assets.Libs.Bloom;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadSceneBloomSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _scenes;

	private readonly BloomParser _bloomParser;

	public LoadSceneBloomSystem(Contexts contexts)
	{
		_scenes = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneBloom));
		_bloomParser = new BloomParser();
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity scene in _scenes)
		{
			if (!scene.sceneBloom.IsInit)
			{
				scene.sceneBloom.IsInit = true;
				_bloomParser.Parse(scene.sceneBloom.Datas, scene.sceneBloom.Loader);
			}
		}
	}
}
