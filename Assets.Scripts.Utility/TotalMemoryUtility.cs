using System;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Sources.Config;
using Assets.Sources.Utils.EventLogger;
using SSJJBase.Logger;
using SSJJBase.Utility;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Utility;

public class TotalMemoryUtility
{
	private static readonly bool IsUseTotalMemory = true;

	private static readonly LoggerAdapter Logger = new LoggerAdapter(typeof(TotalMemoryUtility));

	private static float _startTime;

	private static int _startMemoryBytes;

	private static bool _isGameOverSum;

	private static long _startAllocHeapMemory;

	private static int _textureMemory;

	private static int _meshMemory;

	private static int _particleCount;

	private static int _gameObjectCount;

	private static readonly List<string> Weapons = new List<string>();

	private static readonly List<string> Players = new List<string>();

	private static List<Scene> _allScenes;

	private static Stopwatch _wStopwatch = new Stopwatch();

	private static int _unloadGameObjCount;

	private static int _selfCircleWeaponCount;

	private static int _live2dCount;

	private static float _live2dTextureMem;

	private static float beforeMemory = 0f;

	private static float MIN_MEMORY = 0.1f;

	private static float MAX_MEMORY = 3f;

	private static float MEMORY_INTERVAL = 0.02f;

	private static readonly List<UnityEngine.Object> References = new List<UnityEngine.Object>();

	public static void SetSelfCircle(int count)
	{
		_selfCircleWeaponCount += count;
	}

	public static void SetUnloadCount(int count)
	{
		_unloadGameObjCount += count;
	}

	public static void LoadWeapon(string weapon)
	{
		if (!Weapons.Contains(weapon))
		{
			Weapons.Add(weapon);
		}
	}

	public static void LoadPlayer(string player)
	{
		if (!Players.Contains(player))
		{
			Players.Add(player);
		}
	}

	public static void UnloadScenes(Scene unloadesScene)
	{
		if (_allScenes == null)
		{
			return;
		}
		for (int i = 0; i < _allScenes.Count; i++)
		{
			if (_allScenes[i].Equals(unloadesScene))
			{
				_allScenes.Remove(unloadesScene);
				break;
			}
		}
	}

	public static void LoadScenes(Scene loadedScene, LoadSceneMode loadSceneMode)
	{
		if (_allScenes == null)
		{
			_allScenes = new List<Scene>();
			for (int i = 0; i < SceneManager.sceneCount; i++)
			{
				Scene sceneAt = SceneManager.GetSceneAt(i);
				_allScenes.Add(sceneAt);
			}
		}
		if (!_allScenes.Contains(loadedScene))
		{
			_allScenes.Add(loadedScene);
		}
	}

	public static void SignMemory(string sign)
	{
		int num = AccessProcessMemoryUtilty.CalculateWSPrivate(Process.GetCurrentProcess().Id);
		if ((float)num - beforeMemory > 5120f)
		{
			Logger.Info("MemroryMemroryMemroryMemroryMemrory " + sign + " Diff >> " + ((float)num - beforeMemory) / 1024f + "  All >> " + (float)num / 1024f);
		}
		beforeMemory = num;
	}

	public static int GetCurrentMemory()
	{
		return AccessProcessMemoryUtilty.CalculateWSPrivate(Process.GetCurrentProcess().Id) / 1024;
	}

	public static void SumMemory(bool isGameOver)
	{
		if (!IsUseTotalMemory)
		{
			return;
		}
		try
		{
			GC.Collect();
			int num = AccessProcessMemoryUtilty.CalculateWSPrivate(Process.GetCurrentProcess().Id);
			float memory = (float)num / 1024f / 1024f;
			ConvertMemory(ref memory);
			GlobalProperties.Instance.Properties["ParticleLevel0"] = GameSetting.Config.EffectParticleLevel;
			EventLogger.Instance.StageLogger("ParticleLevel0 :" + GameSetting.Config.EffectParticleLevel, StartStageEnum.ParticleEffectListener);
			GlobalProperties.Instance.Properties.Remove("ParticleLevel0");
			string text = "";
			if (isGameOver)
			{
				if (_isGameOverSum)
				{
					return;
				}
				ForceUnloadResUtility.UnloadRes();
				_wStopwatch.Start();
				_isGameOverSum = !_isGameOverSum;
				_textureMemory = GetObjectMemory(typeof(Texture2D));
				_meshMemory = GetMeshMemory();
				UpdateLive2DCost();
				_gameObjectCount = GetAllObjects().Count / 100;
				_particleCount = GetAllParticles() / 10;
				text = text + " MemoryDiff:" + (float)(num - _startMemoryBytes) / 1024f / 1024f + "GB  AllTime:" + (int)(Time.realtimeSinceStartup - _startTime);
				text = text + "  HeapAll:" + (int)((float)GC.GetTotalMemory(forceFullCollection: false) / 1024f / 1024f) + "MB";
				text = text + "  HeapDiff:" + (int)((float)(GC.GetTotalMemory(forceFullCollection: false) - _startAllocHeapMemory) / 1024f / 1024f) + "MB";
				text = text + " WeaponCount:" + Weapons.Count;
				text = text + " TextureMemory:" + _textureMemory + "MB";
				text = text + " MeshMemory:" + _meshMemory + "MB";
				text = string.Concat(text, " GameObjectCount:" + _gameObjectCount);
				text = text + " PlayerCount:" + Players.Count;
				text = string.Concat(text, " ParticleCount:" + _particleCount);
				text = string.Concat(text, " UnloadCount:" + _unloadGameObjCount);
				text = string.Concat(text, " SelfCircleWeaponCount:" + _selfCircleWeaponCount);
				text = text + " AvgFps:" + FpsDisplay.GetInstance().GetFpsAverage();
				text = text + " live2dCount:" + _live2dCount;
				text = text + " live2dTextureMem:" + _live2dTextureMem + "MB";
				if (memory > 0f && Time.realtimeSinceStartup - _startTime > 20f)
				{
					GlobalProperties.Instance.Properties["MemBytes0"] = num / 1024;
					if (num - _startMemoryBytes > 0)
					{
						GlobalProperties.Instance.Properties["MemDiff0"] = (num - _startMemoryBytes) / 1024;
					}
					else
					{
						GlobalProperties.Instance.Properties["MemDiff0"] = 0;
					}
					GlobalProperties.Instance.Properties["MemTime0"] = (int)(Time.realtimeSinceStartup - _startTime);
					GlobalProperties.Instance.Properties["MemHeapAll0"] = (int)((float)GC.GetTotalMemory(forceFullCollection: false) / 1024f / 1024f);
					GlobalProperties.Instance.Properties["MemHeapDiff0"] = (int)((float)(GC.GetTotalMemory(forceFullCollection: false) - _startAllocHeapMemory) / 1024f / 1024f);
					GlobalProperties.Instance.Properties["MemWeapon0"] = Weapons.Count;
					GlobalProperties.Instance.Properties["MemPlayer0"] = Players.Count;
					GlobalProperties.Instance.Properties["MemTexture0"] = _textureMemory;
					GlobalProperties.Instance.Properties["MemMesh0"] = _meshMemory;
					GlobalProperties.Instance.Properties["MemGameObjectCount0"] = _gameObjectCount;
					GlobalProperties.Instance.Properties["MemParticleCount0"] = _particleCount;
					GlobalProperties.Instance.Properties["MemLive2DCount0"] = _live2dCount;
					GlobalProperties.Instance.Properties["UnityNp"] = TplManager.Instance.GameBootConfig.UnityNp;
					if (_unloadGameObjCount > 0)
					{
						GlobalProperties.Instance.Properties["UnloadCount0"] = _unloadGameObjCount;
					}
					if (_selfCircleWeaponCount > 0)
					{
						GlobalProperties.Instance.Properties["SelfCircleWeaponCount0"] = _selfCircleWeaponCount;
					}
					EventLogger.Instance.StageLogger("TMemory:" + memory + "GB. " + text, StartStageEnum.TotalMemory);
				}
				_wStopwatch.Stop();
				Logger.Info("Caculate Time Cost " + (float)_wStopwatch.ElapsedMilliseconds / 1000f + "s.");
			}
			else
			{
				_startTime = Time.realtimeSinceStartup;
				_startMemoryBytes = num;
				_startAllocHeapMemory = GC.GetTotalMemory(forceFullCollection: false);
			}
		}
		catch (Exception args)
		{
			Logger.ErrorFormat("GetMemoryError {0}", args);
		}
	}

	private static void ConvertMemory(ref float memory)
	{
		if (Mathf.Approximately(memory, 0f))
		{
			return;
		}
		if (memory < MIN_MEMORY)
		{
			memory = MIN_MEMORY;
			return;
		}
		if (memory >= MAX_MEMORY)
		{
			memory = MAX_MEMORY;
			return;
		}
		for (float num = MIN_MEMORY; num <= MAX_MEMORY; num += MEMORY_INTERVAL)
		{
			if (memory < num)
			{
				memory = num;
				break;
			}
		}
	}

	private static int GetMeshMemory()
	{
		float num = 0f;
		List<GameObject> allObjects = GetAllObjects();
		for (int i = 0; i < allObjects.Count; i++)
		{
			MeshFilter component = allObjects[i].GetComponent<MeshFilter>();
			ParticleSystemRenderer component2 = allObjects[i].GetComponent<ParticleSystemRenderer>();
			SkinnedMeshRenderer component3 = allObjects[i].GetComponent<SkinnedMeshRenderer>();
			if (component != null)
			{
				num += GetObjectCapcity(component.sharedMesh);
			}
			else if (component2 != null)
			{
				if (component2.renderMode == ParticleSystemRenderMode.Mesh)
				{
					num += GetObjectCapcity(component2.mesh);
				}
			}
			else if (component3 != null)
			{
				num += GetObjectCapcity(component3.sharedMesh);
			}
		}
		return (int)num;
	}

	private static void UpdateLive2DCost()
	{
		_live2dCount = 0;
		_live2dTextureMem = 0f;
		List<GameObject> allObjects = GetAllObjects();
		int num = LayerMask.NameToLayer("spine");
		for (int i = 0; i < allObjects.Count; i++)
		{
			if (allObjects[i].layer != num)
			{
				continue;
			}
			if (allObjects[i].GetComponent<SkeletonAnimation>() != null)
			{
				MeshRenderer component = allObjects[i].GetComponent<MeshRenderer>();
				_live2dTextureMem += GetObjectCapcity(component.sharedMaterial.mainTexture);
				_live2dCount++;
				continue;
			}
			Camera component2 = allObjects[i].GetComponent<Camera>();
			if (component2 != null)
			{
				_live2dTextureMem += GetObjectCapcity(component2.targetTexture);
			}
		}
	}

	private static int GetObjectMemory(Type type)
	{
		float num = 0f;
		UnityEngine.Object[] array = Resources.FindObjectsOfTypeAll(type);
		for (int i = 0; i < array.Length; i++)
		{
			if (!(array[i] == null) && !array[i].Equals(null) && (array[i].hideFlags == HideFlags.None || array[i].hideFlags == HideFlags.NotEditable || array[i].hideFlags == HideFlags.HideInHierarchy || array[i].hideFlags == HideFlags.HideInInspector))
			{
				References.Add(array[i]);
			}
		}
		for (int j = 0; j < References.Count; j++)
		{
			num += GetObjectCapcity(References[j]);
		}
		return (int)num;
	}

	private static float GetObjectCapcity(UnityEngine.Object obj)
	{
		if (obj == null)
		{
			return 0f;
		}
		if (obj is Texture2D)
		{
			Texture2D texture2D = obj as Texture2D;
			int num = 0;
			num = ((texture2D.format == TextureFormat.ARGB32) ? (texture2D.width * texture2D.height * 32) : ((texture2D.format == TextureFormat.DXT1) ? (texture2D.width * texture2D.height * 4) : ((texture2D.format == TextureFormat.DXT5) ? (texture2D.width * texture2D.height * 8) : ((texture2D.format != TextureFormat.RGB24) ? (texture2D.width * texture2D.height * 8) : (texture2D.width * texture2D.height * 24)))));
			return 1.333f * (float)num / 8f / 1024f / 1024f;
		}
		if (obj is RenderTexture)
		{
			RenderTexture renderTexture = obj as RenderTexture;
			int num2 = 0;
			num2 = ((renderTexture.format != 0) ? (renderTexture.width * renderTexture.height * 8) : (renderTexture.width * renderTexture.height * 32));
			return 1.333f * (float)num2 / 8f / 1024f / 1024f;
		}
		if (obj is Mesh)
		{
			Mesh mesh = obj as Mesh;
			return (float)((mesh.uv2.Length * 2 + mesh.uv.Length * 2 + mesh.vertexCount * 10 + mesh.triangles.Length) * 4) / 1024f / 1024f;
		}
		return 0f;
	}

	public static int GetAllParticles()
	{
		int num = 0;
		List<GameObject> allObjects = GetAllObjects();
		for (int i = 0; i < allObjects.Count; i++)
		{
			if (allObjects[i] != null && allObjects[i].GetComponent<ParticleSystem>() != null)
			{
				num++;
			}
		}
		return num;
	}

	public static List<GameObject> GetAllObjects()
	{
		List<GameObject> list = new List<GameObject>();
		if (_allScenes == null)
		{
			return list;
		}
		GameObject gameObject = GameObject.Find("FirstHand");
		if (gameObject != null && !_allScenes.Contains(gameObject.scene))
		{
			_allScenes.Add(gameObject.scene);
		}
		for (int i = 0; i < _allScenes.Count; i++)
		{
			List<GameObject> gameObjects = GetGameObjects(_allScenes[i].GetRootGameObjects());
			list.AddRange(gameObjects);
		}
		return list;
	}

	public static List<GameObject> GetGameObjects(GameObject[] gamesObjectsArray)
	{
		List<GameObject> list = new List<GameObject>();
		if (gamesObjectsArray == null)
		{
			return list;
		}
		for (int i = 0; i < gamesObjectsArray.Length; i++)
		{
			GetGameObjectsInner(list, gamesObjectsArray[i]);
		}
		return list;
	}

	public static void GetGameObjectsInner(List<GameObject> list, GameObject objGameObject)
	{
		if (!(objGameObject == null))
		{
			list.Add(objGameObject);
			for (int i = 0; i < objGameObject.transform.childCount; i++)
			{
				list.Add(objGameObject.transform.GetChild(i).gameObject);
				GetGameObjectsInner(list, objGameObject.transform.GetChild(i).gameObject);
			}
		}
	}
}
