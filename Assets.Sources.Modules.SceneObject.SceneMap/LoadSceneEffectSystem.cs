using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Assets.Generated.Table;
using Assets.Res.Assets.Scripts;
using Assets.Scripts.Effect.Level;
using Assets.Scripts.Fog;
using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Framework;
using Assets.Sources.Info.Effect.Scene;
using Assets.Sources.Utils.Sound;
using Entitas;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using SSJJMath;
using SSJJSceneLoader;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneMap;

public class LoadSceneEffectSystem : IResourceLoadSystem
{
	private readonly SceneObjectContext _sceneObjectContext;

	private readonly IGroup<SceneObjectEntity> _group;

	public LoadSceneEffectSystem(Contexts contexts)
	{
		_sceneObjectContext = contexts.sceneObject;
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.SceneMap, SceneObjectMatcher.MapUnityObjects).NoneOf(SceneObjectMatcher.MapEffect));
	}

	public void OnLoadResources(ICoRoutineManager coRoutineManager)
	{
		foreach (SceneObjectEntity item in _group)
		{
			LoadSceneEffect(item);
		}
	}

	private Texture2D[] GetSharedTexs(IMapAssetLoader assetLoader, SceneEffectTextureData[] textures)
	{
		Texture2D[] array = new Texture2D[textures.Length];
		for (int i = 0; i < textures.Length; i++)
		{
			array[i] = assetLoader.GetTexture(textures[i].NameWithoutExtension);
			if (array[i] == null)
			{
				this.LogErrorFormat("not found texture :{0}", textures[i].NameWithoutExtension);
			}
		}
		return array;
	}

	private void LoadSceneEffect(SceneObjectEntity entity)
	{
		IMapInfo mapInfo = entity.sceneMap.MapInfo;
		IMapAssetLoader assetLoader = entity.sceneMap.AssetLoader;
		string sceneEffectXml = entity.sceneMap.SceneEffectXml;
		GameObject gameObject = new GameObject("SceenEffectRoot");
		entity.AddMapEffect(gameObject, null);
		string sceneEffectConfigData = assetLoader.GetSceneEffectConfigData();
		if (sceneEffectConfigData != null)
		{
			foreach (SceneEffectConfig item in SceneEffectConfig.ReadConfig(sceneEffectConfigData))
			{
				SceneEffectData effectData = item.EffectData;
				SceneEffectTextureData[] effectTextureDatas = item.EffectTextureDatas;
				if (effectData.EffectType == "model_effect")
				{
					InitModelEffect(assetLoader, effectData, effectTextureDatas, gameObject);
				}
				else if (effectData.EffectType == "moveuv_decal_effect")
				{
					InitModelDecalUVEffect(assetLoader, effectData, effectTextureDatas);
				}
				else if (effectData.EffectType == "moveuv_model_effect")
				{
					InitMoveUvModelEffect(assetLoader, effectData, effectTextureDatas, gameObject);
				}
				else if (effectData.EffectType == "decal_effect")
				{
					InitSpriteDecalUVEffect(assetLoader, effectData, effectTextureDatas);
				}
				else if (effectData.EffectType == "reflection_effect")
				{
					SceneEffectTextureData[] cubeEffectTextureDatas = item.CubeEffectTextureDatas;
					InitReflectionEffect(assetLoader, effectData, effectTextureDatas, cubeEffectTextureDatas);
				}
				else if (effectData.EffectType == "sprite3d_effect")
				{
					InitSprite3dEffect(assetLoader, effectData, effectTextureDatas, gameObject);
				}
				else if (effectData.EffectType == "decal_rotation_effect")
				{
					InitDecalRotationEffect(assetLoader, effectData, effectTextureDatas);
				}
				else if (effectData.EffectType == "playerwater_effect")
				{
					AssetInfo info = new AssetInfo("sceneeffectprefab/playerwater", "PlayerWater");
					info.AssetType = typeof(GameObject);
					SceneObjectEntity sceneObjectEntity = _sceneObjectContext.CreateEntity();
					sceneObjectEntity.AddMapEffect(gameObject, null);
					sceneObjectEntity.AddLoadUnityObjects(new LoadRequests(info), sceneObjectEntity);
					sceneObjectEntity.mapEffect.Render = new PlayerWaterEffectRender();
				}
				else if (effectData.EffectType == "snow_effect")
				{
					AssetInfo info2 = new AssetInfo("sceneeffectprefab/snow", "Snow");
					info2.AssetType = typeof(GameObject);
					SceneObjectEntity sceneObjectEntity2 = _sceneObjectContext.CreateEntity();
					sceneObjectEntity2.AddMapEffect(gameObject, null);
					sceneObjectEntity2.AddLoadUnityObjects(new LoadRequests(info2), sceneObjectEntity2);
					sceneObjectEntity2.mapEffect.Render = new SnowEffectRender(effectData);
				}
				else if (effectData.EffectType == "water_effect")
				{
					AssetInfo info3 = new AssetInfo("sceneeffectprefab/watereffect", "WaterEffect");
					info3.AssetType = typeof(GameObject);
					SceneObjectEntity sceneObjectEntity3 = _sceneObjectContext.CreateEntity();
					sceneObjectEntity3.AddMapEffect(gameObject, null);
					sceneObjectEntity3.AddLoadUnityObjects(new LoadRequests(info3), sceneObjectEntity3);
					sceneObjectEntity3.mapEffect.Render = new WaterEffectRender(effectData);
				}
				else if (effectData.EffectType == "particle_effect")
				{
					if (effectData.ModelName == "pubu")
					{
						AssetInfo info4 = new AssetInfo(mapInfo.AssetBundleName, effectData.ModelName);
						info4.AssetType = typeof(GameObject);
						SceneObjectEntity sceneObjectEntity4 = _sceneObjectContext.CreateEntity();
						sceneObjectEntity4.AddMapEffect(gameObject, null);
						sceneObjectEntity4.AddLoadUnityObjects(new LoadRequests(info4), sceneObjectEntity4);
						sceneObjectEntity4.mapEffect.Render = new PubuEffectRender(effectData);
					}
					else
					{
						this.LogError("Not found scene effect " + effectData.EffectType + " : " + effectData.EffectName);
					}
				}
				else
				{
					this.LogError("Not found scene effect " + effectData.EffectType + " : " + effectData.EffectName);
				}
			}
		}
		if (!string.IsNullOrEmpty(sceneEffectXml))
		{
			foreach (SceneEffectConfig item2 in SceneEffectConfig.ReadEffectXml(sceneEffectXml))
			{
				if (item2.EffectData.EffectName == "JumpPoint" || item2.EffectData.EffectName == "SceneEffects")
				{
					SceneObjectEntity sceneObjectEntity5 = _sceneObjectContext.CreateEntity();
					sceneObjectEntity5.AddPosition(item2.EffectData.Position);
					sceneObjectEntity5.AddRotation(item2.EffectData.Rotation);
					sceneObjectEntity5.AddScale(Vector3.one * item2.EffectData.Scale);
					string text = (string.IsNullOrEmpty(item2.EffectData.ModelName) ? item2.EffectData.EffectName : item2.EffectData.ModelName);
					AssetInfo info5;
					if (assetLoader.GetPrefab(text) != null)
					{
						info5 = new AssetInfo(mapInfo.AssetBundleName, text, typeof(GameObject));
						sceneObjectEntity5.isUf3DResource = true;
					}
					else
					{
						info5 = new AssetInfo($"sceneobject/{text}", $"Assets/Res/Assets/sceneObject/{text}/model.prefab", typeof(GameObject));
					}
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(info5.AssetName.Info);
					int sceneLevel = SingletonInstance<SceneEffectLevelManager>.Instance.GetSceneLevel(fileNameWithoutExtension);
					sceneObjectEntity5.AddSceneEffect(sceneLevel);
					sceneObjectEntity5.AddLoadUnityObjects(new LoadRequests(info5), 0);
				}
				else if (item2.EffectData.EffectName == "SceneEvents" && !string.IsNullOrEmpty(item2.EffectData.SoundName) && !item2.EffectData.SoundName.EndsWith("yanhua.mp3"))
				{
					GameObject gameObject2 = new GameObject();
					gameObject2.transform.localPosition = VectorCoordConverter.SsjjToUnity(item2.EffectData.Position);
					AudioSource audioSource = gameObject2.AddComponent<AudioSource>();
					audioSource.dopplerLevel = 0.01f;
					audioSource.rolloffMode = AudioRolloffMode.Linear;
					audioSource.spatialBlend = 1f;
					audioSource.playOnAwake = true;
					audioSource.volume = GameSoundManager.Config.AsideVolume;
					audioSource.maxDistance = item2.EffectData.Radius;
					audioSource.minDistance = (float)item2.EffectData.Radius * 0.2f;
					audioSource.loop = true;
					MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.Scene, isMyself: false, audioSource, new AssetInfo("sound/scenesound", "Assets/Res/Assets/" + item2.EffectData.SoundName), 2000);
				}
			}
		}
		string sceneFogEffectConfigData = assetLoader.GetSceneFogEffectConfigData();
		if (sceneFogEffectConfigData != null)
		{
			InitFogEffect(sceneFogEffectConfigData);
		}
		assetLoader.GetBloomConfigData();
		string sceneU3DConfigData = assetLoader.GetSceneU3DConfigData();
		if (sceneU3DConfigData != null)
		{
			SceneObjectEntity sceneObjectEntity6 = Contexts.sharedInstance.sceneObject.CreateEntity();
			LoadRequests loadRequests = new LoadRequests();
			if (!sceneU3DConfigData.Contains("CartoonWater"))
			{
				loadRequests.AddAsset("BumpMap", new AssetInfo("effectprefab/customwater", "Assets/Res/Assets/effectprefab/customwater/BumpMap.png", typeof(Texture2D), optional: true));
				sceneObjectEntity6.AddCustomWater(assetLoader.GetSceneWaterConfigData(), 0);
			}
			else
			{
				loadRequests.AddAsset("BumpMap", new AssetInfo("effectprefab/customwater", "Assets/Res/Assets/effectprefab/customwater/CartoonBumpMap.png", typeof(Texture2D), optional: true));
				loadRequests.AddAsset("FoamMap", new AssetInfo("effectprefab/customwater", "Assets/Res/Assets/effectprefab/customwater/CartoonFoamBump.png", typeof(Texture2D), optional: true));
				sceneObjectEntity6.AddCustomWater(assetLoader.GetSceneWaterConfigData(), 1);
			}
			sceneObjectEntity6.AddLoadUnityObjects(loadRequests, typeof(Texture2D));
		}
	}

	private void InitFogEffect(string text)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(text);
		XmlElement documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			XmlNode firstChild = documentElement.FirstChild.FirstChild;
			SSJJFog sSJJFog = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.GetComponent<SSJJFog>();
			if (sSJJFog == null)
			{
				sSJJFog = Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.gameObject.AddComponent<SSJJFog>();
			}
			SSJJFog.FogConfig fogConfig = new SSJJFog.FogConfig(firstChild.Read("id", 0));
			fogConfig.Color = new Color((float)firstChild.Read("r", 0) / 255f, (float)firstChild.Read("g", 0) / 255f, (float)firstChild.Read("b", 0) / 255f);
			fogConfig.Density = firstChild.Read("maxdensity", 0f);
			fogConfig.Near = firstChild.Read("near", 0);
			fogConfig.Far = firstChild.Read("far", 0);
			fogConfig.IsUseHeight = firstChild.Read("useheight", 0) > 0;
			fogConfig.Height = firstChild.Read("height", 0);
			fogConfig.HeightScale = firstChild.Read("heightscale", 0);
			fogConfig.FogQualityLevel = firstChild.Read("qualitylevel", 0);
			fogConfig.HasFogArea = firstChild.Read("hasFogArea", 0) > 0;
			fogConfig.FogAreaCulling = firstChild.Read("isCullFogArea", 0) > 0;
			fogConfig.FogAreaMin = new Vector3(firstChild.Read("minx", 0f), firstChild.Read("miny", 0f), firstChild.Read("minz", 0f));
			fogConfig.FogAreaMax = new Vector3(firstChild.Read("maxx", 0f), firstChild.Read("maxy", 0f), firstChild.Read("maxz", 0f));
			sSJJFog.Fogs.Add(fogConfig);
			sSJJFog.InitFogShader(fogConfig);
		}
	}

	private void InitReflectionEffect(IMapAssetLoader assetLoader, SceneEffectData effectData, SceneEffectTextureData[] textures, SceneEffectTextureData[] cubeTextures)
	{
		Vector3 vector = new Vector3(2.1474836E+09f, 2.1474836E+09f, 2.1474836E+09f);
		Vector3 vector2 = new Vector3(-2.1474836E+09f, -2.1474836E+09f, -2.1474836E+09f);
		Mesh mesh = new Mesh();
		mesh.name = effectData.EffectName;
		List<Vector3> list = new List<Vector3>();
		for (int i = 0; i < effectData.VertexCount; i++)
		{
			list.Add(VectorCoordConverter.SsjjToUnity(effectData.VertexData[i]));
			vector = Vector3.Min(vector, list[list.Count - 1]);
			vector2 = Vector3.Max(vector2, list[list.Count - 1]);
		}
		PlayerWaterEffectRender.WaterFaces.Add(vector);
		PlayerWaterEffectRender.WaterFaces.Add(vector2);
		mesh.vertices = list.ToArray();
		int[] array = new int[effectData.IndexData.Length];
		for (int j = 0; j < effectData.IndexData.Length; j++)
		{
			array[j] = effectData.IndexData[effectData.IndexData.Length - 1 - j];
		}
		mesh.triangles = array;
		mesh.uv = effectData.UvData;
		GameObject gameObject = new GameObject(effectData.EffectName);
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		Material material = new Material(Shader.Find("SSJJ/WaterReflection"));
		material.renderQueue = 2200;
		Vector4 vector3 = VectorCoordConverter.SsjjToUnity(effectData.ReflectionProbeBoundMin);
		Vector4 vector4 = VectorCoordConverter.SsjjToUnity(effectData.ReflectionProbeBoundMax);
		Vector4 vector5 = default(Vector4);
		Vector4 vector6 = default(Vector4);
		vector5.x = Math.Min(vector3.x, vector4.x);
		vector5.y = Math.Min(vector3.y, vector4.y);
		vector5.z = Math.Min(vector3.z, vector4.z);
		vector6.x = Math.Max(vector3.x, vector4.x);
		vector6.y = Math.Max(vector3.y, vector4.y);
		vector6.z = Math.Max(vector3.z, vector4.z);
		Vector4 value = (vector5 + vector6) * 0.5f;
		for (int k = 0; k < effectData.VertexCount; k++)
		{
			vector5.x = Math.Min(vector5.x, list[k].x);
			vector5.y = Math.Min(vector5.y, list[k].y);
			vector5.z = Math.Min(vector5.z, list[k].z);
			vector6.x = Math.Max(vector6.x, list[k].x);
			vector6.y = Math.Max(vector6.y, list[k].y);
			vector6.z = Math.Max(vector6.z, list[k].z);
		}
		material.SetTexture("_Cubemap", assetLoader.GetCubemap(Path.GetFileNameWithoutExtension(cubeTextures[0].Name)));
		material.SetVector("_EnvBoxMin", vector6 * 10f);
		material.SetVector("_EnvBoxMax", vector5 * 10f);
		material.SetVector("_EnvBoxPos", value);
		meshRenderer.material = material;
		ModelTextureSheetAnimation modelTextureSheetAnimation = gameObject.AddComponent<ModelTextureSheetAnimation>();
		modelTextureSheetAnimation.Textures = GetSharedTexs(assetLoader, textures);
		modelTextureSheetAnimation.Speed = effectData.Time;
	}

	private void InitModelDecalUVEffect(IMapAssetLoader assetLoader, SceneEffectData effectData, SceneEffectTextureData[] textures)
	{
		Mesh mesh = new Mesh();
		mesh.name = effectData.EffectName;
		mesh.vertices = new Vector3[4]
		{
			VectorCoordConverter.SsjjToUnity(effectData.Pos0),
			VectorCoordConverter.SsjjToUnity(effectData.Pos1),
			VectorCoordConverter.SsjjToUnity(effectData.Pos2),
			VectorCoordConverter.SsjjToUnity(effectData.Pos3)
		};
		mesh.triangles = new int[6] { 0, 3, 1, 1, 3, 2 };
		float num = Vector3.Distance(effectData.Pos0, effectData.Pos1);
		float num2 = Vector3.Distance(effectData.Pos0, effectData.Pos3);
		mesh.uv = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, num2 / num / 2f),
			new Vector2(0f, num2 / num / 2f)
		};
		GameObject gameObject = new GameObject(effectData.EffectName);
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		Material material = new Material(Shader.Find("SSJJ/Diffuse"));
		material.mainTexture = assetLoader.GetTexture(Path.GetFileNameWithoutExtension(textures[0].Name));
		material.SetInt("_ZTest", 4);
		material.renderQueue = 2200;
		material.SetInt("_ZWrite", 1);
		material.SetInt("_Cull", effectData.Cull);
		meshRenderer.material = material;
		gameObject.AddComponent<UVEffect>().Speed = new Vector2(0f, (float)(-effectData.Time) * 0.001f);
	}

	private void InitMoveUvModelEffect(IMapAssetLoader assetLoader, SceneEffectData effectData, SceneEffectTextureData[] textures, GameObject root)
	{
		GameObject gameObject = assetLoader.GetPrefab(effectData.ModelName).CreateInstance();
		gameObject.transform.SetParent(root.transform);
		gameObject.transform.position = VectorCoordConverter.SsjjToUnity(effectData.Position);
		gameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(effectData.Rotation);
		ModelTextureSheetAnimation modelTextureSheetAnimation = gameObject.AddComponent<ModelTextureSheetAnimation>();
		modelTextureSheetAnimation.Textures = GetSharedTexs(assetLoader, textures);
		modelTextureSheetAnimation.Speed = effectData.Time;
		Material material = gameObject.GetComponentInChildren<MeshRenderer>().material;
		material.SetInt("_ZTest", 4);
		material.renderQueue = 2200;
		material.SetInt("_ZWrite", (effectData.SetDepthTest != 0) ? 1 : 0);
		material.SetInt("_Cull", effectData.Cull);
		if (effectData.RotationSpeed != 0)
		{
			Vector3 speedInAngle = VectorCoordConverter.SsjjRotationToUnity(effectData.RotationNormal) * effectData.RotationSpeed;
			gameObject.AddComponent<SpineMono>().SpeedInAngle = speedInAngle;
		}
		gameObject.transform.localScale = Vector3.one * effectData.Scale;
		gameObject.AddComponent<UVEffect>().Speed = new Vector2(0f, (float)effectData.Time * 0.001f);
	}

	private void InitModelEffect(IMapAssetLoader assetLoader, SceneEffectData effectData, SceneEffectTextureData[] textures, GameObject root)
	{
		GameObject gameObject = assetLoader.GetPrefab(effectData.ModelName).CreateInstance();
		gameObject.transform.SetParent(root.transform);
		gameObject.transform.position = VectorCoordConverter.SsjjToUnity(effectData.Position);
		gameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(effectData.Rotation);
		ModelTextureSheetAnimation modelTextureSheetAnimation = gameObject.AddComponent<ModelTextureSheetAnimation>();
		modelTextureSheetAnimation.Textures = GetSharedTexs(assetLoader, textures);
		modelTextureSheetAnimation.Speed = effectData.Time;
		Material material = gameObject.GetComponentInChildren<MeshRenderer>().material;
		material.SetInt("_ZTest", 4);
		material.renderQueue = 3001;
		material.SetInt("_ZWrite", (effectData.SetDepthTest != 0) ? 1 : 0);
		material.SetInt("_Cull", effectData.Cull);
		if (effectData.RotationSpeed != 0)
		{
			Vector3 speedInAngle = VectorCoordConverter.SsjjRotationToUnity(effectData.RotationNormal) * effectData.RotationSpeed;
			gameObject.AddComponent<SpineMono>().SpeedInAngle = speedInAngle;
		}
		gameObject.transform.localScale = Vector3.one * effectData.Scale;
	}

	private void InitSpriteDecalUVEffect(IMapAssetLoader assetLoader, SceneEffectData effectData, SceneEffectTextureData[] textures)
	{
		Mesh mesh = new Mesh();
		mesh.name = effectData.EffectName;
		mesh.vertices = new Vector3[4]
		{
			VectorCoordConverter.SsjjToUnity(effectData.Pos0),
			VectorCoordConverter.SsjjToUnity(effectData.Pos1),
			VectorCoordConverter.SsjjToUnity(effectData.Pos2),
			VectorCoordConverter.SsjjToUnity(effectData.Pos3)
		};
		mesh.triangles = new int[6] { 0, 3, 1, 1, 3, 2 };
		mesh.uv = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f)
		};
		GameObject gameObject = new GameObject(effectData.EffectName);
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		Material material = new Material(Shader.Find("SSJJ/Diffuse"));
		material.mainTexture = assetLoader.GetTexture(Path.GetFileNameWithoutExtension(textures[0].Name));
		material.SetInt("_ZTest", 4);
		material.renderQueue = 2200;
		material.SetInt("_ZWrite", (effectData.SetDepthTest != 0) ? 1 : 0);
		material.SetInt("_Cull", effectData.Cull);
		meshRenderer.material = material;
		ModelTextureSheetAnimation modelTextureSheetAnimation = gameObject.AddComponent<ModelTextureSheetAnimation>();
		modelTextureSheetAnimation.Textures = GetSharedTexs(assetLoader, textures);
		modelTextureSheetAnimation.Speed = effectData.Time;
	}

	private void InitDecalRotationEffect(IMapAssetLoader assetLoader, SceneEffectData effectData, SceneEffectTextureData[] textures)
	{
		Mesh mesh = new Mesh();
		mesh.name = effectData.EffectName;
		mesh.vertices = new Vector3[4]
		{
			VectorCoordConverter.SsjjToUnity(effectData.Pos0),
			VectorCoordConverter.SsjjToUnity(effectData.Pos1),
			VectorCoordConverter.SsjjToUnity(effectData.Pos2),
			VectorCoordConverter.SsjjToUnity(effectData.Pos3)
		};
		mesh.triangles = new int[6] { 0, 3, 1, 1, 3, 2 };
		mesh.uv = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(1f, 0f),
			new Vector2(1f, 1f),
			new Vector2(0f, 1f)
		};
		GameObject gameObject = new GameObject(effectData.EffectName);
		MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
		gameObject.AddComponent<MeshFilter>().mesh = mesh;
		Material material = new Material(Shader.Find("SSJJ/Diffuse"));
		material.mainTexture = assetLoader.GetTexture(Path.GetFileNameWithoutExtension(textures[0].Name));
		material.SetInt("_ZTest", 4);
		material.renderQueue = 2200;
		material.SetInt("_ZWrite", (effectData.SetDepthTest != 0) ? 1 : 0);
		material.SetInt("_Cull", effectData.Cull);
		meshRenderer.material = material;
		iTweenRotate iTweenRotate = gameObject.AddComponent<iTweenRotate>();
		iTweenRotate.Distance = new Vector3(0f, 360f, 0f);
		iTweenRotate.Time = effectData.Time;
	}

	private void InitSprite3dEffect(IMapAssetLoader assetLoader, SceneEffectData effectData, SceneEffectTextureData[] textures, GameObject root)
	{
		try
		{
			GameObject gameObject = new GameObject(effectData.EffectName);
			gameObject.transform.localPosition = VectorCoordConverter.SsjjToUnity((effectData.Pos0 + effectData.Pos1 + effectData.Pos2 + effectData.Pos3) * 0.25f);
			gameObject.transform.SetParent(root.transform);
			GameObject gameObject2 = new GameObject("1");
			gameObject2.transform.SetParent(gameObject.transform);
			if (Math.Abs((effectData.Pos0 - effectData.Pos1).x) > 0.1f)
			{
				gameObject2.transform.localScale = new Vector3(Math.Abs((effectData.Pos0 - effectData.Pos1).x), Math.Abs((effectData.Pos0 - effectData.Pos3).z)) * 0.5f;
			}
			else
			{
				gameObject2.transform.localScale = new Vector3(Math.Abs((effectData.Pos0 - effectData.Pos1).y), Math.Abs((effectData.Pos0 - effectData.Pos3).z)) * 0.5f;
			}
			gameObject2.transform.localPosition = Vector3.zero;
			SpriteRenderer spriteRenderer = gameObject2.AddComponent<SpriteRenderer>();
			Material material = new Material(Shader.Find("SSJJ/Diffuse"));
			material.SetInt("_ZTest", 4);
			material.renderQueue = 2200;
			material.SetInt("_ZWrite", (effectData.SetDepthTest != 0) ? 1 : 0);
			material.SetInt("_Cull", effectData.Cull);
			spriteRenderer.material = material;
			SpriteAnimation spriteAnimation = gameObject2.AddComponent<SpriteAnimation>();
			Sprite[] array = new Sprite[textures.Length];
			for (int i = 0; i < textures.Length; i++)
			{
				Texture2D texture = assetLoader.GetTexture(Path.GetFileNameWithoutExtension(textures[i].Name));
				array[i] = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), Vector2.one * 0.5f);
			}
			spriteAnimation.Sprites = array;
			if (effectData.Time > 0)
			{
				spriteAnimation.FrameRate = 1000 / effectData.Time;
			}
			else
			{
				spriteAnimation.FrameRate = textures.Length;
			}
		}
		catch (Exception arg)
		{
			this.LogErrorFormat("EffectName : {0} \n{1}", effectData.EffectName, arg);
		}
	}
}
