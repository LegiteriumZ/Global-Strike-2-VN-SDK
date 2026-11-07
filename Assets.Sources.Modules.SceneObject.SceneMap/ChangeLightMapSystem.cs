using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class ChangeLightMapSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private IGroup<SceneObjectEntity> _group;

	private IGroup<SceneObjectEntity> _unitygroup;

	private Light MainLight;

	public ChangeLightMapSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.LightMapChange, SceneObjectMatcher.LightMapUnityObjects).NoneOf(SceneObjectMatcher.LoadLightMapResource));
		_unitygroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.LightMapChange));
		_time = contexts.time.time;
		Shader.SetGlobalFloat("_LightIntensity", 0f);
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			ChangeLight(item, _time.ClientRealTime);
		}
		foreach (SceneObjectEntity item2 in _unitygroup)
		{
			ChangeUnityLight(item2, _time.ClientRealTime);
		}
	}

	private void ChangeLight(SceneObjectEntity entity, int clientRealTime)
	{
		if (entity.lightMapUnityObjects.From == entity.lightMapUnityObjects.To)
		{
			return;
		}
		float duration = entity.lightMapChange.Duration;
		float num = clientRealTime - entity.lightMapChange.BeginTime;
		if (num > duration)
		{
			num = duration;
		}
		float num2 = Mathf.Clamp(num / duration, 0f, 1f);
		if (entity.lightMapUnityObjects.Mode == 0)
		{
			Material[] materials = entity.lightMapUnityObjects.Materials;
			for (int i = 0; i < materials.Length; i++)
			{
				materials[i].SetFloat("_Progress", num2);
			}
		}
		else
		{
			if (entity.lightMapUnityObjects.Mode != 1)
			{
				return;
			}
			if (MainLight == null)
			{
				Light[] array = Object.FindObjectsOfType<Light>();
				foreach (Light light in array)
				{
					if (light.type == LightType.Directional)
					{
						MainLight = light;
						break;
					}
				}
			}
			if (MainLight != null)
			{
				MainLight.intensity = Mathf.Lerp(entity.lightMapChange.From, entity.lightMapChange.To, num2);
			}
		}
	}

	private void ChangeUnityLight(SceneObjectEntity entity, int clientRealTime)
	{
		float duration = entity.lightMapChange.Duration;
		float num = clientRealTime - entity.lightMapChange.BeginTime;
		if (num > duration)
		{
			num = duration;
		}
		float t = Mathf.Clamp(num / duration, 0f, 1f);
		if (entity.lightMapChange.Mode != 1)
		{
			return;
		}
		if (MainLight == null)
		{
			Light[] array = Object.FindObjectsOfType<Light>();
			foreach (Light light in array)
			{
				if (light.type == LightType.Directional)
				{
					MainLight = light;
					break;
				}
			}
		}
		if (MainLight != null)
		{
			MainLight.intensity = Mathf.Lerp(entity.lightMapChange.From, entity.lightMapChange.To, t);
			Shader.SetGlobalFloat("_LightIntensity", Mathf.Clamp(1f - MainLight.intensity, 0f, 0.5f));
		}
		if (num > duration)
		{
			entity.RemoveLightMapChange();
		}
	}
}
