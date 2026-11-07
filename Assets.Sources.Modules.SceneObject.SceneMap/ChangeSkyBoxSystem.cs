using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class ChangeSkyBoxSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private IGroup<SceneObjectEntity> _group;

	private SceneObjectEntity _entity;

	public ChangeSkyBoxSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.Skybox, SceneObjectMatcher.SceneMap, SceneObjectMatcher.SkyboxUnityObjects, SceneObjectMatcher.SkyBoxChange));
		_time = contexts.time.time;
		_entity = contexts.sceneObject.sceneMapEntity;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			ChangeSkyBox(item, _time.ClientRealTime);
		}
	}

	private void changeSkyBoxMaterialTexture(SceneObjectEntity entity)
	{
		Texture2D[] value = null;
		Texture2D[] value2 = null;
		entity.skyboxUnityObjects.skyboxTextures.TryGetValue((int)entity.lightMapChange.From, out value);
		entity.skyboxUnityObjects.skyboxTextures.TryGetValue((int)entity.lightMapChange.To, out value2);
		if (value != null && value2 != null)
		{
			int num = entity.skyboxUnityObjects.SkyboxMaterials.Length;
			for (int i = 0; i < num; i++)
			{
				Material mat = entity.skyboxUnityObjects.SkyboxMaterials[i];
				Texture2D mainTexture = value[i];
				Texture2D texture = value2[i];
				InitMaterial(mat, mainTexture, texture);
			}
		}
		entity.ReplaceSkyBoxChangeObjects(entity.skyBoxChange.From, entity.skyBoxChange.To, entity.skyBoxChange.Mode);
	}

	private void InitMaterial(Material mat, Texture2D mainTexture, Texture2D texture2)
	{
		if (mat.shader.name != "SSJJ/Skybox2")
		{
			mat.shader = Shader.Find("SSJJ/Skybox2");
		}
		mat.SetFloat("_Progress", 0f);
		mat.SetTexture("_MainTex", mainTexture);
		mat.SetTexture("_MainTex2", texture2);
	}

	private void ChangeSkyBox(SceneObjectEntity entity, int clientRealTime)
	{
		if (entity.skyBoxChange.From != entity.skyBoxChangeObjects.From || entity.skyBoxChange.To != entity.skyBoxChangeObjects.To)
		{
			changeSkyBoxMaterialTexture(entity);
		}
		float duration = entity.skyBoxChange.Duration;
		float num = clientRealTime - entity.skyBoxChange.BeginTime;
		if (num > duration)
		{
			num = duration;
		}
		float num2 = Mathf.Clamp(num / duration, 0f, 1f);
		if (entity.skyBoxChangeObjects.Mode == 0)
		{
			Material[] skyboxMaterials = entity.skyboxUnityObjects.SkyboxMaterials;
			for (int i = 0; i < skyboxMaterials.Length; i++)
			{
				skyboxMaterials[i].SetFloat("_Progress", num2);
			}
		}
		if (num2 >= 1f)
		{
			entity.RemoveSkyBoxChange();
		}
	}
}
