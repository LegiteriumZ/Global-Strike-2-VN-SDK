using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadLightMapSystem : LoadAndInitResourceSystem<SceneObjectEntity>
{
	private IGroup<SceneObjectEntity> _group;

	private IGroup<SceneObjectEntity> _initGroup;

	private TimeContext _timeContext;

	public LoadLightMapSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneMap, SceneObjectMatcher.LightMapChange, SceneObjectMatcher.LightMapUnityObjects).NoneOf(SceneObjectMatcher.LoadLightMapResource));
		_initGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneMap, SceneObjectMatcher.LightMapChange, SceneObjectMatcher.LightMapUnityObjects, SceneObjectMatcher.LightMapResource));
	}

	protected override IGroup<SceneObjectEntity> GetLoadGroup()
	{
		return _group;
	}

	protected override IGroup<SceneObjectEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override void OnLoadEntityResource(SceneObjectEntity entity)
	{
		IMapInfo mapInfo = entity.sceneMap.MapInfo;
		float from = entity.lightMapChange.From;
		float to = entity.lightMapChange.To;
		int mode = entity.lightMapChange.Mode;
		if (mode != 0)
		{
			return;
		}
		if (entity.lightMapUnityObjects.Materials.Length == 0)
		{
			Dictionary<int, Material>.ValueCollection materials = entity.mapUnityObjects.MapObject.GetComponent<BaseSceneRender>().GetMaterials();
			if (materials.Count > 0)
			{
				Material[] array = new Material[materials.Count];
				int num = 0;
				foreach (Material item in materials)
				{
					array[num++] = item;
				}
				entity.ReplaceLightMapUnityObjects((int)from, (int)to, mode, array);
			}
		}
		int num2 = (int)from;
		int num3 = (int)to;
		if (num2 != entity.lightMapUnityObjects.From || num3 != entity.lightMapUnityObjects.To)
		{
			AssetInfo[] array2 = new AssetInfo[12];
			for (int i = 0; i < 6; i++)
			{
				array2[i] = new AssetInfo(mapInfo.AssetBundleName, GetLightMapName(i, num2));
				array2[i + 6] = new AssetInfo(mapInfo.AssetBundleName, GetLightMapName(i, num3));
			}
			entity.AddLoadLightMapResource(new LoadRequests(array2), GetLoadIdentifier(num2, num3));
		}
	}

	private string GetLightMapName(int index, int lightMapIndex)
	{
		return string.Format("lightmap{0}{1}", index, (lightMapIndex == 0) ? "" : ("_" + lightMapIndex));
	}

	private string GetLoadIdentifier(int from, int to)
	{
		return $"{from}-{to}";
	}

	protected override bool IsResourceMatch(SceneObjectEntity entity)
	{
		float from = entity.lightMapChange.From;
		float to = entity.lightMapChange.To;
		return GetLoadIdentifier((int)from, (int)to) == (string)entity.lightMapResource.Identifier;
	}

	protected override void CleanResouceComponent(SceneObjectEntity entity)
	{
		entity.RemoveLightMapResource();
	}

	protected override void OnInitEntityResource(SceneObjectEntity entity)
	{
		float from = entity.lightMapChange.From;
		float to = entity.lightMapChange.To;
		Material[] materials = entity.lightMapUnityObjects.Materials;
		foreach (Material mat in materials)
		{
			ReplaceMateraial(mat, entity.lightMapResource.LoadResults);
		}
		entity.lightMapUnityObjects.From = (int)from;
		entity.lightMapUnityObjects.To = (int)to;
		entity.lightMapUnityObjects.Mode = entity.lightMapChange.Mode;
		entity.lightMapChange.BeginTime = _timeContext.time.ClientRealTime;
	}

	private void ReplaceMateraial(Material mat, LoadResults loadResults)
	{
		int renderQueue = mat.renderQueue;
		Texture texture = mat.GetTexture("_LightMap");
		int num = Convert.ToInt32(new Regex("lightmap([0-9])").Match(texture.name).Groups[1].Value);
		if (mat.shader.name != "SSJJ/UnityMap2")
		{
			mat.shader = Shader.Find("SSJJ/UnityMap2");
			mat.renderQueue = renderQueue;
		}
		mat.SetFloat("_Progress", 0f);
		mat.SetTexture("_LightMap", loadResults[num].Object as Texture2D);
		mat.SetTexture("_LightMap2", loadResults[num + 6].Object as Texture2D);
	}
}
