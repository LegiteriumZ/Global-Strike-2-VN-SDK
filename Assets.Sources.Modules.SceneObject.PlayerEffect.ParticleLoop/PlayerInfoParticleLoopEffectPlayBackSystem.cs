using Assets.Sources.Components.SceneObject.PlayerEffect;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.PlayerEffect.ParticleLoop;

public class PlayerInfoParticleLoopEffectPlayBackSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private IGroup<SceneObjectEntity> _effectGroup;

	public PlayerInfoParticleLoopEffectPlayBackSystem(Contexts contexts)
	{
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.PlayerParticleLoopEffect, SceneObjectMatcher.UnityObjects).NoneOf(SceneObjectMatcher.Destroy));
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			PlayerParticleLoopEffectComponent playerParticleLoopEffect = item.playerParticleLoopEffect;
			playerParticleLoopEffect.RenderTime += _time.FrameInterval;
			for (int i = 0; i < playerParticleLoopEffect.EffectList.Count; i++)
			{
				int index = playerParticleLoopEffect.EffectList[i];
				string key = playerParticleLoopEffect.EffectNameList[index];
				if (playerParticleLoopEffect.RenderTime > i * playerParticleLoopEffect.EffectInterval && !playerParticleLoopEffect.EffectShow[i])
				{
					playerParticleLoopEffect.EffectShow[i] = true;
					GameObject gameObject = item.unityObjects.LoadResults[key].GameObject;
					gameObject.SetObjectActive(isactive: false);
					gameObject.SetObjectActive(isactive: true);
					VectorCoordConverter.SsjjToUnity(item.position.Origin, out var dest);
					gameObject.transform.position = dest;
				}
			}
		}
	}
}
