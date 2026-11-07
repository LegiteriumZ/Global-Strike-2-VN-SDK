using Assets.Sources.Config;
using Assets.Sources.Framework;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class SceneEffectVisiablePlaybackSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _scenes;

	private int _originEffectLevel;

	public SceneEffectVisiablePlaybackSystem(Contexts contexts)
	{
		_scenes = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneEffect, SceneObjectMatcher.UnityObjects));
		_originEffectLevel = -100;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity scene in _scenes)
		{
			int effectParticleLevel = GameSetting.Config.EffectParticleLevel;
			if (_originEffectLevel != effectParticleLevel)
			{
				int level = scene.sceneEffect.Level;
				scene.unityObjects.LoadResults[0].GameObject.SetObjectActive(level <= effectParticleLevel);
				_originEffectLevel = effectParticleLevel;
			}
		}
	}
}
