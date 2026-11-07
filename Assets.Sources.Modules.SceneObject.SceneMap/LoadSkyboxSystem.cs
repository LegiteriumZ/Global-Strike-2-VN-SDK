using System.Collections.Generic;
using Assets.Sources.Framework;
using Entitas;
using SSJJAsset.Asset;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadSkyboxSystem : LoadAndInitResourceSystem<SceneObjectEntity>
{
	private IGroup<SceneObjectEntity> _loadGroup;

	private IGroup<SceneObjectEntity> _initGroup;

	public LoadSkyboxSystem(Contexts contexts)
	{
		_loadGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.Skybox, SceneObjectMatcher.SceneMap).NoneOf(SceneObjectMatcher.LoadSkyboxResource, SceneObjectMatcher.SkyboxResource, SceneObjectMatcher.SkyboxUnityObjects));
		_initGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.Skybox, SceneObjectMatcher.SceneMap, SceneObjectMatcher.SkyboxResource).NoneOf(SceneObjectMatcher.SkyboxUnityObjects));
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
		LoadSkybox(entity);
	}

	private void LoadSkybox(SceneObjectEntity entity)
	{
		int skyboxId = entity.skybox.SkyboxId;
		AssetInfo info = new AssetInfo("skybox", "Skybox");
		entity.AddLoadSkyboxResource(new LoadRequests(info), skyboxId);
	}

	protected override bool IsResourceMatch(SceneObjectEntity entity)
	{
		return true;
	}

	protected override void CleanResouceComponent(SceneObjectEntity entity)
	{
		entity.RemoveSkyboxResource();
	}

	protected override void OnInitEntityResource(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.skyboxResource.LoadResults[0].GameObject;
		IMapAssetLoader assetLoader = entity.sceneMap.AssetLoader;
		Texture2D texture = assetLoader.GetTexture("skybox0");
		Texture2D texture2 = assetLoader.GetTexture("skybox1");
		Texture2D texture3 = assetLoader.GetTexture("skybox2");
		Texture2D texture4 = assetLoader.GetTexture("skybox3");
		Texture2D texture5 = assetLoader.GetTexture("skybox4");
		Texture2D texture6 = assetLoader.GetTexture("skybox5");
		Dictionary<int, Texture2D[]> dictionary = null;
		for (int i = 1; i < 3; i++)
		{
			Texture2D texture7 = assetLoader.GetTexture("skybox0_" + i);
			if (texture7 == null)
			{
				break;
			}
			if (dictionary == null)
			{
				dictionary = new Dictionary<int, Texture2D[]>();
				dictionary[0] = new Texture2D[6] { texture, texture2, texture3, texture4, texture5, texture6 };
			}
			Texture2D texture8 = assetLoader.GetTexture("skybox1_" + i);
			Texture2D texture9 = assetLoader.GetTexture("skybox2_" + i);
			Texture2D texture10 = assetLoader.GetTexture("skybox3_" + i);
			Texture2D texture11 = assetLoader.GetTexture("skybox4_" + i);
			Texture2D texture12 = assetLoader.GetTexture("skybox5_" + i);
			dictionary[i] = new Texture2D[6] { texture7, texture8, texture9, texture10, texture11, texture12 };
		}
		Material material = gameObject.transform.Find("Right").GetComponent<MeshRenderer>().material;
		Material material2 = gameObject.transform.Find("Left").GetComponent<MeshRenderer>().material;
		Material material3 = gameObject.transform.Find("Top").GetComponent<MeshRenderer>().material;
		Material material4 = gameObject.transform.Find("Bottom").GetComponent<MeshRenderer>().material;
		Material material5 = gameObject.transform.Find("Front").GetComponent<MeshRenderer>().material;
		Material material6 = gameObject.transform.Find("Back").GetComponent<MeshRenderer>().material;
		InitMaterial(material);
		InitMaterial(material2);
		InitMaterial(material3);
		InitMaterial(material4);
		InitMaterial(material5);
		InitMaterial(material6);
		material.mainTexture = texture;
		material2.mainTexture = texture2;
		material3.mainTexture = texture3;
		material4.mainTexture = texture4;
		material5.mainTexture = texture5;
		material6.mainTexture = texture6;
		entity.AddSkyboxUnityObjects(entity.skybox.SkyboxId, gameObject, new Material[6] { material, material2, material3, material4, material5, material6 }, dictionary);
	}

	private static void InitMaterial(Material mat)
	{
		mat.mainTexture = null;
	}
}
