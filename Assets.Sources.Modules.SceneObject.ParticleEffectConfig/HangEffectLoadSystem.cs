using System.Collections.Generic;
using Assets.Sources.Components.SceneObject;
using Assets.Sources.Framework;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.XmlAsset;
using Entitas;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.ParticleEffectConfig;

public class HangEffectLoadSystem : LoadAndInitResourceSystem<SceneObjectEntity>
{
	private readonly IGroup<SceneObjectEntity> _loadGroup;

	private readonly IGroup<SceneObjectEntity> _initGroup;

	private SceneObjectContext _sceneObjectContext;

	public HangEffectLoadSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_loadGroup = _sceneObjectContext.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.HangEffectRes).NoneOf(SceneObjectMatcher.Destroy));
		_initGroup = _sceneObjectContext.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.HangEffectResult).NoneOf(SceneObjectMatcher.Destroy));
	}

	protected override IGroup<SceneObjectEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<SceneObjectEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override void OnLoadEntityResource(SceneObjectEntity entity)
	{
		LoadRequests loadRequests = new LoadRequests();
		HangEffectResComponent hangEffectRes = entity.hangEffectRes;
		foreach (string needSceneObject in hangEffectRes.NeedSceneObjectList)
		{
			ParticleManager.InitSceneParticleXmlLoadRequests(loadRequests, needSceneObject);
		}
		foreach (AssetInfo needPrefab in hangEffectRes.NeedPrefabList)
		{
			loadRequests.AddAsset(needPrefab.AssetName, needPrefab);
		}
		if (entity.hasHangEffectLoad)
		{
			entity.hangEffectLoad.LoadRequests = loadRequests;
			entity.hangEffectLoad.Identifier = hangEffectRes.GetHashCode();
		}
		else
		{
			entity.AddHangEffectLoad(loadRequests, hangEffectRes.GetHashCode());
		}
	}

	protected override bool IsResourceMatch(SceneObjectEntity entity)
	{
		return entity.hangEffectResult.Identifier.ToString() == entity.hangEffectRes.GetHashCode().ToString();
	}

	protected override void CleanResouceComponent(SceneObjectEntity entity)
	{
		if (!entity.isDestroy)
		{
			entity.RemoveHangEffectResult();
		}
	}

	protected override void OnInitEntityResource(SceneObjectEntity entity)
	{
		HangEffectResComponent hangEffectRes = entity.hangEffectRes;
		foreach (AssetInfo needPrefab in hangEffectRes.NeedPrefabList)
		{
			LoadPrefabFinish(entity, needPrefab);
		}
		hangEffectRes.NeedPrefabList.Clear();
		foreach (string needSceneObject in hangEffectRes.NeedSceneObjectList)
		{
			ParticleManager.InitSceneParticleXmlLoadResults(entity.hangEffectResult.LoadResults, needSceneObject);
			List<EntityHangEffectData> hangEffectData = ParticleManager.Instance().GetHangEffectData(needSceneObject);
			if (hangEffectData == null)
			{
				continue;
			}
			foreach (EntityHangEffectData item in hangEffectData)
			{
				if (entity.hangEffectResult.LoadResults[needSceneObject + "_SceneEffectXml"].Object is EffectXmlAsset effectXmlAsset && effectXmlAsset.Dict.TryGetValue(item.EffectName, out var value))
				{
					LoadPrefabRequest(entity, needSceneObject, item, value);
				}
			}
		}
		hangEffectRes.NeedSceneObjectList.Clear();
		if (!entity.isDestroy)
		{
			entity.RemoveHangEffectLoad();
			entity.RemoveHangEffectRes();
		}
	}

	private void LoadPrefabFinish(SceneObjectEntity entity, AssetInfo info)
	{
		GameObject gameObject = entity.hangEffectResult.LoadResults[info.AssetName].GameObject;
		Vector3 position = VectorCoordConverter.SsjjToUnity(entity.position.Origin);
		gameObject.transform.position = position;
	}

	private void LoadPrefabRequest(SceneObjectEntity entity, string scene, EntityHangEffectData effect, EffectConfig config)
	{
		SceneObjectEntity sceneObjectEntity = Contexts.sharedInstance.sceneObject.CreateEntity();
		sceneObjectEntity.AddPosition(entity.position.Origin);
		string effectPath = config.EffectPath;
		int num = effectPath.IndexOf('.');
		if (num != -1)
		{
			string text = null;
			string text2 = null;
			int num2 = effectPath.LastIndexOf('/');
			if (num2 != -1)
			{
				int num3 = effectPath.IndexOf('/');
				text2 = ((num3 == -1) ? effectPath.Substring(0, num) : effectPath.Substring(0, num3));
				text = effectPath.Substring(num2 + 1, num - num2 - 1);
			}
			else
			{
				text2 = effectPath.Substring(0, num);
				text = text2;
			}
			effectPath = text2 + "/" + text + "/Prefab/" + text;
			AssetInfo item = new AssetInfo($"sceneobject/{scene}", $"Assets/Res/Assets/sceneObject/{scene}/effect/{effectPath}.prefab", typeof(GameObject));
			sceneObjectEntity.AddHangEffectRes(new List<string>(), new List<AssetInfo> { item });
		}
	}
}
