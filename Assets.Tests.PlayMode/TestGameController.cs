using System.Collections;
using Assets.Scripts;
using Assets.Scripts.Input;
using Assets.Sources.Config;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Systems.Time;
using Assets.Sources.Utils;
using Entitas;
using SSJJAsset.AssetBundle;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.Thread;
using UnityEngine;
using UnityEngine.Networking;
using physics.engine;

namespace Assets.Tests.PlayMode;

public class TestGameController : MonoBehaviourSingleton<TestGameController>
{
	private Systems _systems;

	private void Awake()
	{
		WeEngineUtil.InitNativeLibrary();
	}

	public IEnumerator Init(Contexts contexts, IGameModule gameModule)
	{
		base.gameObject.AddComponent<UnityMainThreadDispatcher>();
		base.gameObject.AddComponent<SystemProfiler>();
		base.gameObject.AddComponent<InputCollector>();
		AssetBundleManagerUtility.InitResourceUrl();
		GameController.CreateSingletonEntities(contexts);
		_systems = new Systems();
		CreateSystems(contexts, gameModule);
		yield return InitAssetBundleManager();
		yield return LoadTables();
		yield return CareerData.LoadConfig();
	}

	public void CreateFpsSystems(Contexts contexts, IGameModule module)
	{
		Feature feature = new Feature("FpsSystems");
		feature.Add(new GameModuleFeature(contexts, module));
		feature.Initialize();
		_systems.Add(feature);
	}

	private IEnumerator LoadTables()
	{
		yield return WeaponInfoLoader.Instance.Load();
		yield return AudioRolloffLoader.Instance.Load();
		yield return WeaponCrossLoader.Instance.Load();
	}

	private IEnumerator InitAssetBundleManager()
	{
		string md5 = null;
		if (!GameEnvironment.IsSimulation)
		{
			UnityWebRequest www = UnityWebRequest.Get(TplManager.Instance.GetBootConfig().ResourceBase + AssetBundleUtility.GetPlatformName() + "/version.php");
			yield return www.Send();
			if (!www.isNetworkError)
			{
				md5 = www.downloadHandler.text;
				this.InfoFormat("InitAssetBundleManager url {0}, msd:{1} ", www.url, md5);
				AssetBundleManager.SetAssetBundleManifestMd5(md5);
			}
			else
			{
				this.InfoFormat("InitAssetBundleManager error {0} ", www.url);
				this.LogErrorFormat("InitAssetBundleManager error {0} ", www.url);
			}
		}
		IEnumerator enumerator = AssetBundleManager.Initialize(md5);
		if (enumerator != null)
		{
			yield return StartCoroutine(enumerator);
		}
	}

	private void CreateSystems(Contexts contexts, IGameModule module)
	{
		Feature feature = new Feature("EntitasSystems");
		feature.Add(new FrameTimeSystem(contexts));
		feature.Add(new RenderTimeSystem(contexts));
		feature.Add(new GameModuleFeature(contexts, module));
		feature.Initialize();
		_systems.Add(feature);
	}

	protected override void OnDestroy()
	{
		base.OnDestroy();
		if (_systems != null)
		{
			_systems.Cleanup();
		}
	}

	private void Update()
	{
		if (_systems != null)
		{
			InputCollector.Instance.Collect(Time.deltaTime);
			_systems.Execute();
			InputCollector.Instance.Reset();
		}
	}

	public void Destroy()
	{
		Object.DestroyImmediate(base.gameObject);
	}
}
