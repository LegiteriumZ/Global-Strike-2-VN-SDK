using System;
using System.Collections;
using Assets.Scripts.Input;
using Assets.Sources.Config;
using Assets.Sources.Framework.System;
using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Modules;
using Assets.Sources.Systems.GameRule;
using Assets.Sources.Systems.PacketHandle;
using Assets.Sources.Systems.Snapshot;
using Assets.Sources.Systems.Time;
using Assets.Sources.Systems.UserCommand;
using Assets.Sources.Utils.EventLogger;
using Assets.Tests.PlayMode.UI;
using DefaultNamespace;
using NetData;
using SSJJ.BattleLoading;
using SSJJAsset.AssetBundle;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJUserCmd;
using UnityEngine;
using UnityEngine.SceneManagement;
using physics;
using physics.engine;
using physics.pool;

public class OfflineGameController : GameController
{
	public static OfflineGameSetting setting;

	public static bool isOffline;

	private static bool isFly;

	private void Awake()
	{
		EventPool.GetInstance().SetPoolInstance(new SharpEventPool());
		WeEngineUtil.InitNativeLibrary();
		GameController.Instance = this;
	}

	private IEnumerator Start()
	{
		yield return SceneManager.LoadSceneAsync("BattleLoading", LoadSceneMode.Additive);
		Application.runInBackground = true;
		if (BootConfig == null)
		{
			BootConfig = new string[0];
		}
		yield return InitBootConfigFromCommand(BootConfig);
		EventLogger.Instance.StageLogger(TplManager.Instance.GetBootConfig().ResourceBase, StartStageEnum.InitCmd);
		AssetBundleManagerUtility.InitResourceUrl();
		EventLogger.Instance.StageLogger(TplManager.Instance.GetBootConfig().ResourceBase, StartStageEnum.InitResUrl);
		GameController.CreateSingletonEntities(Contexts.sharedInstance);
		_systems = new SSJJSystem();
		yield return InitAssetBundleManager();
		EventLogger.Instance.StageLogger(AssetBundleManager.GetAssetBundleManifestMd5(), StartStageEnum.InitBundleManager);
		yield return LoadTables();
		EventLogger.Instance.StageLogger("StartStageEnum.InitTables", StartStageEnum.InitTables);
		yield return CareerData.LoadConfig();
		EventLogger.Instance.StageLogger("StartStageEnum.InitAnimConfig", StartStageEnum.InitAnimConfig);
		GameSetting.Apply();
		InitOther();
		_initFinish = true;
		isOffline = true;
	}

	public void InitOfflineData()
	{
		Contexts sharedInstance = Contexts.sharedInstance;
		OnGameinitData onGameinitData = new OnGameinitData();
		sharedInstance.battleRoom.roomData.Data = new RoomData();
		setting = GetComponent<OfflineGameSetting>();
		onGameinitData.SceneId = setting.SceneId;
		sharedInstance.battleRoom.roomData.Data.SceneId = setting.SceneId;
		sharedInstance.battleRoom.roomData.Data.RaceType = setting.SceneId;
		sharedInstance.battleRoom.roomData.Data.SubRaceType = 0;
		sharedInstance.battleRoom.roomData.Data.FreeType = "";
		new TestUiBaseGameRule();
		sharedInstance.gameRule.SetCurrentRule(new TestUiBaseGameRule());
		MonoBehaviourSingleton<BattleLoadingManager>.Instance.LoadOfflineResources(onGameinitData);
	}

	private void Update()
	{
		InputCollector.Instance.Collect(Time.deltaTime);
		if (_systems != null)
		{
			try
			{
				_systems.Execute();
				InputCollector.Instance.Reset();
			}
			catch (Exception args)
			{
				this.LogErrorFormat("Error: {0}", args);
			}
		}
		if (Contexts.sharedInstance.player.myPlayerEntity != null)
		{
			if (Input.GetKeyUp(KeyCode.F))
			{
				isFly = !isFly;
			}
			if (Input.GetKeyUp(KeyCode.R))
			{
				Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().ThirdMode = !Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().ThirdMode;
			}
		}
	}

	public override void CreateFpsSystems(Contexts contexts)
	{
		Feature feature = new Feature("EntitasSystems");
		feature.Add(new PacketHandleFeature(contexts));
		feature.Add(new TimeFeature(contexts));
		feature.Add(new UserCommandFeature(contexts));
		feature.Add(new SnapshotFeature(contexts));
		feature.Add(new GameRuleFeature(contexts));
		feature.Add(new GameModuleFeature(contexts, new OfflineGameModule(contexts)));
		feature.Initialize();
		_systems.Add(feature);
	}

	public static void GetPlayerOffes(IUserCmd cmd, int speed, IPyPlayerMove adapter, IPyMove pmove, IPyUserCmd _pyCmd)
	{
		if (isFly)
		{
			float f = (float)(cmd.CameraYaw / 100) * 0.01745f;
			float f2 = (float)(90 - cmd.CameraPitch / 100) * 0.01745f;
			float f3 = (float)(cmd.CameraYaw / 100 - 90) * 0.01745f;
			float num = Mathf.Sin(f2) * (Mathf.Cos(f) * cmd.MoveForward + Mathf.Cos(f3) * cmd.MoveRight) * 0.001f;
			float num2 = Mathf.Sin(f2) * (Mathf.Sin(f) * cmd.MoveForward + Mathf.Sin(f3) * cmd.MoveRight) * 0.001f;
			float num3 = Mathf.Cos(f2) * (cmd.MoveForward + cmd.MoveRight) * 0.001f;
			adapter.SetPosition((float)adapter.GetX() + num * (float)speed, (float)adapter.GetY() + num2 * (float)speed, (float)adapter.GetZ() + num3 * (float)speed);
		}
		else
		{
			pmove.SetMove(adapter, _pyCmd, speed);
		}
	}

	public void OnGUI()
	{
		if (Contexts.sharedInstance.player.myPlayerEntity != null)
		{
			GUILayout.BeginVertical();
			GUIStyle gUIStyle = new GUIStyle();
			gUIStyle.fontSize = 20;
			gUIStyle.normal.textColor = Color.white;
			GUILayout.Space(50f);
			GUILayout.Label("F键开启外挂-" + isFly, gUIStyle);
			GUILayout.Label("R键开启第三人称-" + Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().ThirdMode, gUIStyle);
			GUILayout.EndVertical();
		}
	}
}
