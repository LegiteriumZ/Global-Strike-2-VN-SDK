using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Assets.Libs.ForAce;
using Assets.Scripts;
using Assets.Scripts.Asset;
using Assets.Scripts.BattleLoading;
using Assets.Scripts.Effect.Level;
using Assets.Scripts.Input;
using Assets.Scripts.PlatformRunTime;
using Assets.Scripts.Utility;
using Assets.Scripts.Utility.Pool;
using Assets.Scripts.Utility.Sound;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Map;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.CsvLoader;
using Assets.Sources.Free.UI;
using Assets.Sources.Free.Utility;
using Assets.Sources.Info.Camera;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.GameRule;
using Assets.Sources.Info.Map;
using Assets.Sources.Info.Res;
using Assets.Sources.Info.ThirdWeaponAnim;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.Weapon.WeaponInfo.Info;
using Assets.Sources.Info.WeaponAnim;
using Assets.Sources.Particle;
using Assets.Sources.Utils;
using Assets.Sources.Utils.AssetManager;
using Assets.Sources.Utils.EventLogger;
using Assets.Sources.Utils.Ui;
using Assets.Sources.XmlAsset;
using Assets.Tests.LookScene;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using SSJJ.UI.Buttons.Battle;
using SSJJAnim.Parser;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJAsset.AssetBundle;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using SSJJNetworking.BattleServer;
using SSJJSceneLoader;
using SSJJUniRx;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SSJJ.BattleLoading;

public class BattleLoadingManager : MonoBehaviourSingleton<BattleLoadingManager>
{
	private readonly BattleLoadingModel _progressModel = new BattleLoadingModel();

	private SceneParsedData _sceneParsedData;

	private byte[] _mapData;

	private Contexts _contexts;

	private string _backImage;

	public BattleLoadingModel ProgressModel => _progressModel;

	private List<string> GetPreloadBundleList(IMapInfo mapInfo, OnGameinitData data)
	{
		List<string> list = new List<string>();
		list.Add(mapInfo.AssetBundleName);
		if (0 == 0)
		{
			list.Add("fonts");
			list.Add("ui/common");
			list.Add("effect/common");
			list.Add("number");
			list.Add("uimaterial");
			list.Add("skybox");
			list.Add("effectprefab/hole");
			list.Add("uiprefabs/common");
			list.Add("uiprefabs/weapon");
			list.Add("playereffectprefab/playerhpbar");
			list.Add("sound/player");
			list.Add("effect/rpgcommon");
			list.Add("effect/pvecommon");
			list.Add("uiconfig");
			list.Add("sound/common");
			if (RuleUtilty.IsRpg(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
			{
				list.Add("uiprefabs/rpg");
				list.Add("uiprefabs/pvecommon");
			}
			foreach (string defaultWeapon in WeaponConstant.DefaultWeaponList)
			{
				IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(defaultWeapon);
				if (weaponInfo != null)
				{
					list.Add(weaponInfo.AssetBundleName);
				}
			}
			foreach (string player in data.PlayerList)
			{
				ICareerInfo careerInfo = CareerInfoFactory.Instance.GetCareerInfo(player);
				list.Add(careerInfo.PrefabBundleName);
			}
			foreach (string weapon in data.WeaponList)
			{
				IWeaponInfo weaponInfo2 = WeaponInfoFactory.Instance.GetWeaponInfo(weapon);
				if (weaponInfo2 != null)
				{
					list.Add(weaponInfo2.AssetBundleName);
				}
			}
		}
		return list;
	}

	private List<AssetInfo> GetPreloadAssetInfoList(OnGameinitData data)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		List<AssetInfo> list = new List<AssetInfo>();
		if (0 == 0)
		{
			list.Add(new AssetInfo("effectprefab/handcamera", "HandCamera", typeof(GameObject)));
			List<string> list2 = new List<string>();
			foreach (string weapon in data.WeaponList)
			{
				if (WeaponInfoFactory.Instance.GetWeaponInfo(weapon) != null && !WeaponConstant.DefaultWeaponList.Contains(weapon) && !list2.Contains(weapon))
				{
					list2.Add(weapon);
				}
			}
			list2.Add("m4a1");
			list2.Add("ak47");
			list2.Add("awp");
			list2.Add("deagle");
			foreach (string item in list2)
			{
				ThirdResUnloadUtility.AddToDontDestoryWeaponList(item);
				IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(item);
				if (weaponInfo != null && !RuleUtilty.IsUltimateChallenge() && RuleUtilty.IsPveModel(raceType))
				{
					list.Add(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ThirdWeaponAnimationXmlAssetName, typeof(ThirdWeaponAnimInfo)));
				}
			}
			foreach (string sceneWeapon in data.SceneWeaponList)
			{
				if (!(sceneWeapon == "dagger"))
				{
					IWeaponInfo weaponInfo2 = WeaponInfoFactory.Instance.GetWeaponInfo(sceneWeapon);
					if (weaponInfo2 != null && !WeaponConstant.DefaultWeaponList.Contains(sceneWeapon) && weaponInfo2 is GrenadeWeaponInfo)
					{
						RuleUtilty.IsUltimateChallenge();
					}
				}
			}
			foreach (string viewWeapon in data.ViewWeaponList)
			{
				IWeaponInfo weaponInfo3 = WeaponInfoFactory.Instance.GetWeaponInfo(viewWeapon);
				if (weaponInfo3 != null && !WeaponConstant.DefaultWeaponList.Contains(viewWeapon) && !RuleUtilty.IsUltimateChallenge() && RuleUtilty.IsPveModel(raceType))
				{
					list.Add(new AssetInfo(weaponInfo3.AnimConfigBundleName, weaponInfo3.ViewAnimConfigAssetName, typeof(WeaponAnimAsset)));
					list.Add(new AssetInfo(weaponInfo3.AssetBundleName, weaponInfo3.ViewCameraConfigAssetName, typeof(FirstHandCameraConfig)));
				}
			}
			foreach (string item2 in data.HandName)
			{
				if (item2.Equals("man") || item2.Equals("woman"))
				{
					list.Add(new AssetInfo($"viewhand/{item2}", $"Assets/Res/Assets/viewhand/{item2}/model.prefab", typeof(FirstPersonHand)));
				}
			}
			if (RuleUtilty.IsUltimateChallenge())
			{
				IWeaponInfo weaponInfo4 = WeaponInfoFactory.Instance.GetWeaponInfo("fist");
				if (weaponInfo4 != null)
				{
					list.Add(new AssetInfo(weaponInfo4.AssetBundleName, weaponInfo4.ViewWeaponAssetName, typeof(GameObject)));
					list.Add(new AssetInfo(weaponInfo4.AssetBundleName, weaponInfo4.ViewWeaponAnimationAssetName, typeof(SJAnimationAsset)));
					list.Add(new AssetInfo(weaponInfo4.AssetBundleName, weaponInfo4.ViewHandAnimationAssetName, typeof(SJAnimationAsset)));
					list.Add(new AssetInfo(weaponInfo4.AnimConfigBundleName, weaponInfo4.ViewAnimConfigAssetName, typeof(WeaponAnimAsset)));
					list.Add(new AssetInfo(weaponInfo4.AssetBundleName, weaponInfo4.ViewCameraConfigAssetName, typeof(FirstHandCameraConfig)));
					list.Add(new AssetInfo(weaponInfo4.AssetBundleName, weaponInfo4.ThirdAssetName, typeof(GameObject), optional: true));
					list.Add(new AssetInfo(weaponInfo4.AssetBundleName, weaponInfo4.ThirdWeaponAnimationAssetName, typeof(SJAnimationAsset)));
					list.Add(new AssetInfo(weaponInfo4.AssetBundleName, weaponInfo4.ThirdWeaponAnimationXmlAssetName, typeof(ThirdWeaponAnimInfo)));
				}
			}
		}
		return list;
	}

	private List<string> GetPreloadViewhandBundleList(OnGameinitData data)
	{
		List<string> list = new List<string>();
		foreach (string item in data.HandName)
		{
			if (!item.Equals("man") && !item.Equals("woman"))
			{
				list.Add($"viewhand/{item}");
			}
		}
		return list;
	}

	public void LoadResourceAndWaitBattleBegin(OnGameinitData data)
	{
		RuleUtilty.InitUltimateChallenge();
		IMapInfo mapInfo = BattleSingletonInstance<MapInfoFactory>.Instance.GetMapInfo(data.SceneId);
		List<string> preloadBundleList = GetPreloadBundleList(mapInfo, data);
		List<AssetInfo> preloadAssetInfoList = GetPreloadAssetInfoList(data);
		List<string> preloadViewhandBundleList = GetPreloadViewhandBundleList(data);
		BaseAsyncManager.Instance.StartCoRoutine(Step(mapInfo, preloadBundleList, preloadAssetInfoList, preloadViewhandBundleList, data));
		MonoBehaviourSingleton<AceClientManager>.Instance.CheckAceSwitch();
		MonoBehaviourSingleton<AceClientManager>.Instance.CheckAceOpenRuleList();
		if ((!Contexts.sharedInstance.battleRoom.roomData.Data.IsMatch && !MonoBehaviourSingleton<AceClientManager>.Instance.CheckRuleOpen()) || TplManager.Instance.GameBootConfig.NpOpen)
		{
			MonoBehaviourSingleton<AceClientManager>.Instance.Close();
		}
		MonoBehaviourSingleton<AceClientManager>.Instance.GameAceInit();
		OpenNp();
	}

	public void OpenNp()
	{
		if (PlatformConstant.IsTx(TplManager.Instance.GameBootConfig.Platform) && (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 2 || Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 3 || Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 19))
		{
			if (GameController.Instance.GetComponent<ExecuteGG>() == null)
			{
				GameController.Instance.gameObject.AddComponent<ExecuteGG>();
			}
			TplManager.Instance.GameBootConfig.UnityNp = 1;
		}
	}

	public void LoadOfflineResources(OnGameinitData data)
	{
		RuleUtilty.InitUltimateChallenge();
		IMapInfo mapInfo = BattleSingletonInstance<MapInfoFactory>.Instance.GetMapInfo(data.SceneId);
		List<string> preloadBundleList = GetPreloadBundleList(mapInfo, data);
		List<AssetInfo> preloadAssetInfoList = GetPreloadAssetInfoList(data);
		List<string> preloadViewhandBundleList = GetPreloadViewhandBundleList(data);
		BaseAsyncManager.Instance.StartCoRoutine(Step(mapInfo, preloadBundleList, preloadAssetInfoList, preloadViewhandBundleList, data));
	}

	public IEnumerator Step(IMapInfo mapInfo, List<string> preloadBundleList, List<AssetInfo> assetList, List<string> viewHandBundleList, OnGameinitData data)
	{
		_progressModel.IsRpg.Value = RuleUtilty.IsRpg(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType);
		yield return LoadBack();
		SetGameRuleInfo();
		SetTipsInfo();
		_progressModel.Total.Value = preloadBundleList.Count + assetList.Count + 1;
		_progressModel.Loaded.Value = 0;
		SetLoadProgress(0.1f);
		EventLogger.Instance.StageLogger("StartStageEnum.LoadStart", StartStageEnum.LoadStart);
		this.InfoFormat("RaceType:{0}, SubType:{1}, FreeType:{2}, MapId:{3}", Contexts.sharedInstance.battleRoom.roomData.Data.RaceType, Contexts.sharedInstance.battleRoom.roomData.Data.SubRaceType, Contexts.sharedInstance.battleRoom.roomData.Data.FreeType, mapInfo.Id);
		this.InfoFormat("RaceType:{0}, SubType:{1}, FreeType:{2}, MapId:{3}", Contexts.sharedInstance.battleRoom.roomData.Data.RaceType, Contexts.sharedInstance.battleRoom.roomData.Data.SubRaceType, Contexts.sharedInstance.battleRoom.roomData.Data.FreeType, mapInfo.Id);
		IgnoreCaseString mapkey = new IgnoreCaseString("maps/map" + mapInfo.Id);
		SetLoadingTip(ScriptLocalization.Get("TipDownloadMap" + mapInfo.Id));
		AssetBundleLoadAssetOperation mapAssetOperation = AssetBundleManager.LoadAllAssetsAsync(ref mapkey);
		yield return StartCoroutine(UpdateLoadProgress(mapkey, 0.2f, mapAssetOperation));
		yield return mapAssetOperation;
		bool isUnityScene = MapRuleUtility.IsUnityScene(mapInfo.Id);
		if (isUnityScene)
		{
			string sceneName = "map_" + mapInfo.Id;
			IgnoreCaseString assetBundleName = new IgnoreCaseString("unitymaps/map_" + mapInfo.Id);
			AssetBundleLoadOperation unityMapOperation = AssetBundleManager.LoadLevelAsync(ref assetBundleName, sceneName, isAdditive: true);
			yield return StartCoroutine(UpdateLoadProgress(assetBundleName, 0.3f, unityMapOperation));
			yield return unityMapOperation;
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
			DynamicGI.UpdateEnvironment();
		}
		EventLogger.Instance.StageLogger("StartStageEnum.LoadMap", StartStageEnum.LoadMap);
		UnityEngine.Object[] allAssets = mapAssetOperation.GetAllAssets();
		Contexts.sharedInstance.battleRoom.mapInfo.MapInfo = mapInfo;
		if (TestBattleServer.IsLookScene)
		{
			Contexts.sharedInstance.battleRoom.mapInfo.AssetLoader = new LookSceneLoader();
		}
		else
		{
			Contexts.sharedInstance.battleRoom.mapInfo.AssetLoader = new MapAssetLoader(allAssets, mapkey);
		}
		if (!isUnityScene)
		{
			yield return ParseMap(mapInfo, Contexts.sharedInstance.battleRoom.mapInfo.AssetLoader.GetMapData(), 0.4f);
		}
		if (TestBattleServer.IsLookScene)
		{
			yield return WaitInitEngine();
		}
		this.Info("ParseMapOver");
		if (!TestBattleServer.IsLookScene)
		{
			yield return null;
			yield return OnlyLoadAssetBundle(viewHandBundleList, 0.5f);
			this.Info("Load View hand");
			yield return OnlyLoadAssetBundle(preloadBundleList, 0.6f);
			EventLogger.Instance.StageLogger("StartStageEnum.LoadBudnles", StartStageEnum.LoadBudnles);
			yield return LoadAssets(assetList, 0.8f);
			yield return PreLoadSceneAssets();
			EventLogger.Instance.StageLogger("StartStageEnum.LoadAssets", StartStageEnum.LoadAssets);
			SetGameRuleInfo();
			SetTipsInfo();
			UiAssetBundleUtils.GetAssetInfo(UiAssetBundleUtils.UiBundleName, string.Format("{0}", "Assets/Res/Assets/ui/GameGUIRes/common/textStyle.xml"));
			yield return LoadEffectAssets(0.81f);
			yield return LoadPlayerEffectAssets(data.PlayerList, 0.82f);
			yield return LoadPlayerSoundConfig(data.PlayerList, 0.83f);
			yield return LoadWeaponEffectAssets(data.WeaponList, 0.84f);
			yield return LoadWeaponSkinEffectAssets(data.WeaponSkinList, 0.85f, data.WeaponList);
			yield return PreLoadInstances(data, 0.86f);
			EventLogger.Instance.StageLogger("StartStageEnum.LoadEffects", StartStageEnum.LoadEffects);
		}
		yield return SceneManager.LoadSceneAsync("Battle", LoadSceneMode.Additive);
		SetLoadProgress(0.87f);
		EventLogger.Instance.StageLogger("StartStageEnum.LoadBattle", StartStageEnum.LoadBattle);
		if (!isUnityScene)
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("Battle"));
			DynamicGI.UpdateEnvironment();
		}
		this.Info("CreateFpsSystem");
		GameController.Instance.CreateFpsSystems(Contexts.sharedInstance);
		yield return null;
		SetGameRuleInfo();
		SetTipsInfo();
		yield return LoadUi(0.95f);
		SetLoadingTip(ScriptLocalization.Get("TipWaitGameStart"));
		EventLogger.Instance.StageLogger("StartStageEnum.GameStart", StartStageEnum.GameStart);
		string LobbySceneName = "LobbyOffline";
		if (OfflineGameController.setting == null || !OfflineGameController.setting.TurnOn || TestBattleServer.IsLookScene)
		{
			IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
			UdpConnectionIDData message = new UdpConnectionIDData
			{
				Id = server.ConnectionId
			};
			Contexts.sharedInstance.battleRoom.sectionTime.LoadingSuccessTime = TimeUtility.UnixTimeNow();
			this.Info("send loadingSuccess,connectionId: " + server.ConnectionId);
			server.SendTcpMessage(3, message);
			LobbySceneName = "Lobby";
		}
		MonoBehaviourSingleton<BgmSoundManager>.Instance.playBgmSound("0", 0);
		yield return WaitFirstPersonUnityObjects(0.99f);
		while (Contexts.sharedInstance.player.cameraOwnerEntity == null)
		{
			Contexts.sharedInstance.battleRoom.gameState.LoadingFinish = true;
			yield return null;
		}
		EventLogger.Instance.StageLogger("StartStageEnum.LoadEnd", StartStageEnum.LoadEnd);
		SetLoadProgress(1f);
		yield return SceneManager.UnloadSceneAsync(LobbySceneName);
		yield return SceneManager.UnloadSceneAsync("BattleLoading");
		LoadingSucAction();
		this.Info("BattleLoadingOver");
	}

	private IEnumerator WaitInitEngine()
	{
		while (!Contexts.sharedInstance.battleRoom.hasPyEngine)
		{
			if (Contexts.sharedInstance.battleRoom.hasPyEngine)
			{
				yield break;
			}
			yield return null;
		}
		yield return null;
	}

	private void LoadingSucAction()
	{
		Contexts.sharedInstance.sceneObject.ruleUiCompoent.IsLoad = true;
		Contexts.sharedInstance.battleRoom.gameState.LoadingFinish = true;
		FpsDisplay.GetInstance().StartRecordFps = true;
		MonoBehaviourSingleton<FreeUiManager>.Instance.ActivateCanvas();
		InputCollector.Instance.ResetRespondTime();
		MonoBehaviourSingleton<CaptureCameraManager>.Instance.SetEffect();
		MonoBehaviourSingleton<ParticleEffectListener>.Instance.StartListen();
		MonoBehaviourSingleton<AceClientManager>.Instance.LoginSucc();
		if (SpecailDebug.Instance.RecordFps)
		{
			MonoBehaviourSingleton<RecordFpsManager>.Instance.StartRec();
		}
		UnloadBack();
		UnityEngine.Object.Destroy(MonoBehaviourSingleton<BattleLoadingManager>.Instance.gameObject);
		Resources.UnloadUnusedAssets();
		TotalMemoryUtility.SumMemory(isGameOver: false);
		GameController.Instance.LoadingOver();
		BaseAsyncManager.Instance.StartCoRoutine(StartScreenThread());
	}

	private IEnumerator StartScreenThread()
	{
		do
		{
			yield return new WaitForSeconds(5f);
			Resources.UnloadUnusedAssets();
		}
		while (Contexts.sharedInstance.player.myPlayerEntity == null);
		MonoBehaviourSingleton<ScreenShotManager>.Instance.CreateScreenThread();
	}

	private static void ParseMapHandler(object context)
	{
		BattleLoadingManager battleLoadingManager = (BattleLoadingManager)context;
		DefaultByteArray defaultByteArray = new DefaultByteArray(battleLoadingManager._mapData);
		defaultByteArray.readInt();
		int num = defaultByteArray.readInt();
		ISceneParse sceneParse = null;
		DecalsProxy.DECALS_ID = 1;
		if (num >= 106)
		{
			sceneParse = new WeSceReader();
		}
		else if (num >= 104)
		{
			sceneParse = new SceParseVersionLess106();
		}
		else if (num >= 100)
		{
			sceneParse = new SceParseVersionLess104();
		}
		else
		{
			DecalsProxy.DECALS_ID = 0;
			sceneParse = new BspReader();
		}
		battleLoadingManager._sceneParsedData = sceneParse.parseForLogicThread(defaultByteArray);
		PyEngineUtility.InitPyEngine(battleLoadingManager._contexts, battleLoadingManager._mapData, Contexts.sharedInstance.battleRoom.roomData.EngineId, battleLoadingManager._sceneParsedData.map as BspClipMap);
	}

	private IEnumerator ParseMap(IMapInfo mapInfo, byte[] mapData, float fpercent)
	{
		SetLoadingTip(ScriptLocalization.Get("ParseMapData"));
		_mapData = mapData;
		_contexts = Contexts.sharedInstance;
		ThreadPool.QueueUserWorkItem(ParseMapHandler, this);
		float spercent = _progressModel.Progress.Value;
		while (_sceneParsedData == null)
		{
			if (spercent < fpercent)
			{
				spercent += 0.01f;
				SetLoadProgress(spercent);
			}
			yield return null;
		}
		_mapData = null;
		Contexts.sharedInstance.battleRoom.mapInfo.ParsedSceneDatas[mapInfo.Id] = _sceneParsedData;
	}

	private IEnumerator WaitFirstPersonUnityObjects(float fpercent)
	{
		SetLoadingTip(ScriptLocalization.Get("LoadingFirstPersonWeapon"));
		float lastPercent = _progressModel.Progress.Value;
		long startTime = TimeUtility.UnixTimeNow();
		while ((Contexts.sharedInstance.player.cameraOwnerEntity == null || (!Contexts.sharedInstance.player.cameraOwnerEntity.hasFirstPersonUnityObjects && !Contexts.sharedInstance.player.cameraOwnerEntity.hasThirdPersonUnityObjects)) && TimeUtility.UnixTimeNow() - startTime <= 10000)
		{
			if (lastPercent < fpercent)
			{
				lastPercent += 0.01f;
				SetLoadProgress(lastPercent);
			}
			yield return null;
		}
	}

	private IEnumerator LoadUi(float fpercent)
	{
		SetLoadingTip(ScriptLocalization.Get("InitUi"));
		yield return SingletonInstance<BossDescribeData>.Instance.LoadConfig();
		long startTime = TimeUtility.UnixTimeNow();
		float spercent = _progressModel.Progress.Value;
		float lastPercent = spercent;
		while ((AbstractModel.LoadCount == 0 || AbstractModel.InstantiateCount < AbstractModel.LoadCount) && TimeUtility.UnixTimeNow() - startTime <= 3000)
		{
			float val = spercent + ((AbstractModel.LoadCount > 0) ? ((fpercent - spercent) * (float)AbstractModel.InstantiateCount / (float)AbstractModel.LoadCount) : 0f);
			lastPercent = Math.Max(val, lastPercent);
			SetLoadProgress(lastPercent);
			yield return null;
		}
	}

	private void SetLoadProgress(float progress)
	{
		_progressModel.Progress.Value = progress;
	}

	private void SetGameRuleInfo()
	{
		if (Contexts.sharedInstance != null)
		{
			BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
			PlayerContext player = Contexts.sharedInstance.player;
			if (battleRoom.hasRoomData)
			{
				int raceType = battleRoom.roomData.Data.RaceType;
				string text = ScriptLocalization.Get($"_gameRuleInfo[{raceType}]");
				if (string.IsNullOrEmpty(text) && player.isMyPlayer)
				{
					text = ScriptLocalization.Get($"_gameRuleInfo[{raceType}][team{player.myPlayerEntity.basicInfo.Current.Team}]");
					if (string.IsNullOrEmpty(text))
					{
						return;
					}
				}
				if (!string.IsNullOrEmpty(text))
				{
					_progressModel.GameRuleInfo.Value = text.Replace("\\n", "\n");
					return;
				}
			}
		}
		_progressModel.GameRuleInfo.Value = "";
	}

	private void SetTipsInfo()
	{
		if (Contexts.sharedInstance != null)
		{
			BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
			if (battleRoom.hasRoomData)
			{
				int raceType = battleRoom.roomData.Data.RaceType;
				int num = 20;
				while (num > 0)
				{
					int num2 = UnityEngine.Random.Range(0, num);
					string value = ScriptLocalization.Get($"_tipsInfo[{GameRuleFactory.Instance.GetGameRule(raceType).GetTipsIndex()}][{num2}]");
					if (!string.IsNullOrEmpty(value))
					{
						_progressModel.TipsInfo.Value = value;
						return;
					}
					num = num2;
				}
			}
		}
		_progressModel.TipsInfo.Value = "";
	}

	private IEnumerator UpdateLoadProgress(IgnoreCaseString assetBundleName, float fpersent, AssetBundleLoadOperation operation)
	{
		float spercent = _progressModel.Progress.Value;
		while (!operation.IsDone())
		{
			float loadingProgressWithDeps = AssetBundleManager.GetLoadingProgressWithDeps(ref assetBundleName);
			float progress = operation.GetProgress();
			_progressModel.Progress.Value = spercent + loadingProgressWithDeps * (fpersent - spercent) * 0.8f + progress * (fpersent - spercent) * 0.2f;
			yield return null;
		}
	}

	private IEnumerator LoadBack()
	{
		AssetInfo configAsset = new AssetInfo("ui/load/loadconfig", "Assets/Res/Assets/ui/GameGUIRes/load/loadConfig.xml");
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(configAsset, BaseAsyncManager.Instance);
		long startTime = TimeUtility.UnixTimeNow();
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(configAsset))
		{
			if (TimeUtility.UnixTimeNow() - startTime > 20000)
			{
				yield break;
			}
			yield return null;
		}
		TextAsset textAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(configAsset) as TextAsset;
		if (textAsset != null)
		{
			_backImage = LoaderBackAsset.GetLoaderBackUrl(textAsset.text, Contexts.sharedInstance.battleRoom.roomData.Data.RaceType, Contexts.sharedInstance.battleRoom.roomData.Data.ChannelData, TplManager.Instance.GameBootConfig.Platform, Contexts.sharedInstance.player.isMyPlayer ? Contexts.sharedInstance.player.myPlayerEntity.GetTeam() : 0, TplManager.Instance.GameBootConfig.IsNewPlayer, TplManager.Instance.GameBootConfig.HallModeRuleId);
			if (!string.IsNullOrEmpty(_backImage))
			{
				yield return LoadBackImage(_backImage, _progressModel.BackSprite);
			}
		}
		AssetInfo cfgInfo = UiAssetBundleUtils.GetAssetInfo(UiAssetBundleUtils.UiBundleName, string.Format("{0}", "Assets/Res/Assets/ui/GameGUIRes/common/textStyle.xml"));
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(cfgInfo, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(cfgInfo))
		{
			yield return null;
		}
		TextAsset textAsset2 = SingletonInstance<AssetPool>.Instance.GetOrNull(cfgInfo) as TextAsset;
		if (textAsset2 != null)
		{
			TextStyleConfigParser.ParseConfig(textAsset2.text);
		}
	}

	private void UnloadBack()
	{
		if (!string.IsNullOrEmpty(_backImage))
		{
			MonoBehaviourSingleton<GarbageDestoryer>.Instance.RemoveLinker(new AssetInfo("ui/load/" + _backImage.Split('.')[0], "Assets/Res/Assets/ui/GameGUIRes/load/" + _backImage), isAlsoUnloadAb: true);
		}
	}

	private IEnumerator LoadBackImage(string image, ReactiveProperty<Sprite> sprite)
	{
		long startTime = TimeUtility.UnixTimeNow();
		AssetInfo imageAsset = new AssetInfo("ui/load/" + image.Split('.')[0], "Assets/Res/Assets/ui/GameGUIRes/load/" + image);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(imageAsset, BaseAsyncManager.Instance);
		while (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(imageAsset))
		{
			if (TimeUtility.UnixTimeNow() - startTime > 20000)
			{
				yield break;
			}
			yield return null;
		}
		Texture2D texture2D = SingletonInstance<AssetPool>.Instance.GetOrNull(imageAsset) as Texture2D;
		if (texture2D != null)
		{
			sprite.Value = Sprite.Create(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), Vector2.zero);
		}
	}

	private IEnumerator OnlyLoadAssetBundle(List<string> assetBundles, float fpercent)
	{
		int allCount = assetBundles.Count;
		int i = 0;
		foreach (string assetBundle in assetBundles)
		{
			this.DebugFormat("only load assetbundle {0} ", assetBundle);
			i++;
			IgnoreCaseString bundlekey = new IgnoreCaseString(assetBundle);
			AssetBundleLoadOperation loadOperation = AssetBundleManager.OnlyLoadAssetBundleAync(ref bundlekey);
			float spercent = _progressModel.Progress.Value;
			float percent = (fpercent - spercent) / (float)allCount;
			while (!loadOperation.IsDone())
			{
				float progress = loadOperation.GetProgress();
				float num = AssetBundleManager.GetLoadingProgressWithDeps(ref bundlekey) * 0.8f + progress * 0.2f;
				string text = string.Format(ScriptLocalization.Get("DownloadTip"), i, allCount, (int)(num * 100f));
				SetLoadingTip(text + bundlekey);
				_progressModel.Progress.Value = spercent + num * percent;
				yield return null;
			}
		}
		SetLoadProgress(fpercent);
	}

	private IEnumerator PreLoadSceneAssets()
	{
		Dictionary<AssetInfo, int> assetInfos = new Dictionary<AssetInfo, int>();
		if (RuleUtilty.IsPveModel(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			assetInfos.Add(new AssetInfo("playereffectprefab/playerhpbar", "PlayerHpBar", typeof(GameObject)), 4);
			assetInfos.Add(new AssetInfo("playereffectprefab/damagehinttext", "DamageHintText", typeof(GameObject)), 10);
			assetInfos.Add(new AssetInfo("effectprefab/hole", "bullet", typeof(GameObject)), 20);
		}
		else
		{
			assetInfos.Add(new AssetInfo("playereffectprefab/playerhpbar", "PlayerHpBar", typeof(GameObject)), 6);
			assetInfos.Add(new AssetInfo("effectprefab/hole", "bullet", typeof(GameObject)), 14);
		}
		Dictionary<AssetInfo, bool> finished = new Dictionary<AssetInfo, bool>();
		bool allFinish = false;
		foreach (KeyValuePair<AssetInfo, int> item in assetInfos)
		{
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(item.Key, BaseAsyncManager.Instance);
			finished[item.Key] = false;
		}
		while (!allFinish)
		{
			allFinish = true;
			foreach (KeyValuePair<AssetInfo, int> item2 in assetInfos)
			{
				if (finished[item2.Key])
				{
					continue;
				}
				if (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(item2.Key))
				{
					allFinish = false;
					continue;
				}
				object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(item2.Key);
				if (orNull != null && item2.Key.AssetType == typeof(GameObject))
				{
					for (int i = 0; i < item2.Value; i++)
					{
						MonoBehaviourSingleton<UnityGameObjectPool>.Instance.Add(item2.Key, (orNull as GameObject).CreateInstance());
					}
				}
				finished[item2.Key] = true;
			}
			yield return null;
		}
	}

	private IEnumerator LoadAssets(List<AssetInfo> assetInfos, float fpercent)
	{
		int allCount = assetInfos.Count;
		int i = 0;
		float spercent = _progressModel.Progress.Value;
		Dictionary<AssetInfo, bool> finished = new Dictionary<AssetInfo, bool>();
		bool allFinish = false;
		foreach (AssetInfo assetInfo in assetInfos)
		{
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(assetInfo, BaseAsyncManager.Instance);
			finished[assetInfo] = false;
		}
		while (!allFinish)
		{
			allFinish = true;
			foreach (AssetInfo assetInfo2 in assetInfos)
			{
				if (!finished[assetInfo2])
				{
					if (!SingletonInstance<AssetPool>.Instance.IsAssetLoadFinish(assetInfo2))
					{
						allFinish = false;
						continue;
					}
					this.DebugFormat("try preload {0}", assetInfo2);
					i++;
					string loadingTip = string.Format(ScriptLocalization.Get("DownloadTip"), i, allCount, i * 100 / allCount);
					SetLoadingTip(loadingTip);
					finished[assetInfo2] = true;
					_progressModel.Loaded.Value++;
					_progressModel.Progress.Value = spercent + (float)_progressModel.Loaded.Value / (float)allCount * (fpercent - spercent);
					SetLoadProgress(_progressModel.Progress.Value);
				}
			}
			yield return null;
		}
		SetLoadProgress(fpercent);
	}

	private IEnumerator LoadPlayerSoundConfig(List<string> playerList, float fpercent)
	{
		float spercent = _progressModel.Progress.Value;
		int count = 0;
		foreach (string player in playerList)
		{
			this.DebugFormat("try preloading sound asset {0}", player);
			string text = $"player/{player}";
			SetLoadingTip(ScriptLocalization.Get("ParseEffectTip") + text);
			AssetInfo sound = new AssetInfo(text, $"Assets/Res/Assets/player/{player}/effect/soundconfig.xml", typeof(TextAsset), optional: true);
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(sound, BaseAsyncManager.Instance);
			yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(sound);
			TextAsset textAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(sound) as TextAsset;
			if (textAsset != null)
			{
				new SounfConfigXmlAsset().ParseXmlImmediatory(textAsset.text);
			}
			count++;
			SetLoadProgress(spercent + (float)count / (float)playerList.Count * (fpercent - spercent));
		}
		SetLoadProgress(fpercent);
	}

	private IEnumerator LoadPlayerEffectAssets(List<string> playerList, float fpercent)
	{
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		float spercent = _progressModel.Progress.Value;
		int count = 0;
		if (RuleUtilty.IsPve(raceType))
		{
			foreach (string player in playerList)
			{
				string assetBundle = $"player/{player}";
				SetLoadingTip(ScriptLocalization.Get("ParseEffectTip") + assetBundle);
				AssetInfo effect = new AssetInfo(assetBundle, $"Assets/Res/Assets/player/{player}/effect/effectConfig.xml", typeof(EffectXmlAsset), optional: true);
				AssetInfo particle = new AssetInfo(assetBundle, $"Assets/Res/Assets/player/{player}/effect/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true);
				SingletonInstance<AssetPool>.Instance.LoadAndAdd(particle, BaseAsyncManager.Instance);
				SingletonInstance<AssetPool>.Instance.LoadAndAdd(effect, BaseAsyncManager.Instance);
				yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(particle);
				yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(effect);
				EffectXmlAsset effectXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(effect) as EffectXmlAsset;
				ParticleXmlAsset particleXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(particle) as ParticleXmlAsset;
				if (effectXmlAsset != null || particleXmlAsset != null)
				{
					ParticleManager.Instance().ParsePreloadingEffect(assetBundle, particleXmlAsset, effectXmlAsset, $"Assets/Res/Assets/player/{player}/effect", preLoadRes: false);
				}
				count++;
				SetLoadProgress(spercent + (float)count / (float)playerList.Count * (fpercent - spercent));
			}
		}
		SetLoadProgress(fpercent);
	}

	private IEnumerator PreLoadInstances(OnGameinitData data, float percent)
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (battleRoom != null)
		{
			IGameObjectPool pool = battleRoom.gameObjectPool.Pool;
			if (pool != null && data.PreloadInfoList != null && data.PreloadInfoList.Count > 0)
			{
				for (int i = 0; i < data.PreloadInfoList.Count; i++)
				{
					string[] array = data.PreloadInfoList[i].Split("$$");
					if (array.Length <= 2)
					{
						continue;
					}
					string text = ((array.Length != 0) ? array[0] : "");
					int.TryParse(array[1], out var total);
					int.TryParse(array[2], out var step);
					if (total <= 0 || step <= 0 || string.IsNullOrEmpty(text))
					{
						continue;
					}
					AssetInfo info = FreeResourceUtility.GetEffectAssetPath(text);
					if (!info.AssetName.Info.EndsWith(".prefab"))
					{
						continue;
					}
					SingletonInstance<AssetPool>.Instance.LoadAndAdd(info, BaseAsyncManager.Instance);
					yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(info);
					int j = 0;
					GameObject gameObject = SingletonInstance<AssetPool>.Instance.GetOrNull(info) as GameObject;
					if (!(gameObject != null))
					{
						continue;
					}
					for (; j < total; j += step)
					{
						for (int k = 0; k < step; k++)
						{
							pool.Add(info, UnityEngine.Object.Instantiate(gameObject));
						}
					}
				}
			}
		}
		SetLoadProgress(percent);
	}

	private IEnumerator LoadWeaponEffectAssets(List<string> weaponList, float fpercent)
	{
		float spercent = _progressModel.Progress.Value;
		int count = 0;
		foreach (string weapon in weaponList)
		{
			this.DebugFormat("try preloading weapon asset {0}", weapon);
			string assetBundle = $"weapon/{weapon}";
			SetLoadingTip(ScriptLocalization.Get("ParseEffectTip") + assetBundle);
			AssetInfo effect = new AssetInfo(assetBundle, $"Assets/Res/Assets/weapon/{weapon}/effect/effectConfig.xml", typeof(EffectXmlAsset), optional: true);
			AssetInfo particle = new AssetInfo(assetBundle, $"Assets/Res/Assets/weapon/{weapon}/effect/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true);
			AssetInfo sound = new AssetInfo(assetBundle, $"Assets/Res/Assets/weapon/{weapon}/effect/soundConfig.xml", typeof(TextAsset), optional: true);
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(particle, BaseAsyncManager.Instance);
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(effect, BaseAsyncManager.Instance);
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(sound, BaseAsyncManager.Instance);
			yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(particle);
			yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(effect);
			yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(sound);
			EffectXmlAsset effectXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(effect) as EffectXmlAsset;
			ParticleXmlAsset particleXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(particle) as ParticleXmlAsset;
			TextAsset textAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(sound) as TextAsset;
			if (effectXmlAsset != null || particleXmlAsset != null)
			{
				ParticleManager.Instance().ParsePreloadingEffect(assetBundle, particleXmlAsset, effectXmlAsset, $"Assets/Res/Assets/weapon/{weapon}/effect", preLoadRes: false);
			}
			if (textAsset != null)
			{
				new SounfConfigXmlAsset().ParseXmlImmediatory(textAsset.text);
			}
			count++;
			SetLoadProgress(spercent + (float)count / (float)weaponList.Count * (fpercent - spercent));
		}
		SetLoadProgress(fpercent);
	}

	private IEnumerator LoadWeaponSkinEffectAssets(List<string> weaponSkinList, float fpercent, List<string> weaponList)
	{
		float spercent = _progressModel.Progress.Value;
		int count = 0;
		foreach (string weaponSkin in weaponSkinList)
		{
			if (weaponSkin != "skin_sword_heaven_judge_guardian" && weaponSkin != "skin_grenade_lock_frozen" && weaponSkin != "skin_grenade_universe_frozen" && weaponSkin != "skin_rebirth_sword_pearl" && weaponSkin != "skin_grenade_lock_ruby" && weaponSkin != "skin_grenade_universe_ruby" && weaponSkin != "skin_grenade_lock_elec" && weaponSkin != "skin_grenade_universe_elec" && weaponSkin != "skin_grenade_alioth_purple" && weaponSkin != "skin_grenade_dubhe_purple")
			{
				continue;
			}
			WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(weaponSkin);
			string weaponName = "";
			string[] array = skinInfo.Weapon.Split(":");
			for (int i = 0; i < array.Length; i++)
			{
				if (weaponList.Contains(array[i]))
				{
					weaponName = array[i];
				}
			}
			if (!string.IsNullOrEmpty(weaponName))
			{
				string assetBundle = $"weaponskin/{weaponSkin}";
				AssetInfo effect = new AssetInfo(assetBundle, $"Assets/Res/Assets/weaponskin/{weaponSkin}/{weaponName}/effect/effectConfig.xml", typeof(EffectXmlAsset), optional: true);
				AssetInfo particle = new AssetInfo(assetBundle, $"Assets/Res/Assets/weaponskin/{weaponSkin}/{weaponName}/effect/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true);
				AssetInfo sound = new AssetInfo(assetBundle, $"Assets/Res/Assets/weaponskin/{weaponSkin}/{weaponName}/effect/soundConfig.xml", typeof(TextAsset), optional: true);
				SingletonInstance<AssetPool>.Instance.LoadAndAdd(particle, BaseAsyncManager.Instance);
				SingletonInstance<AssetPool>.Instance.LoadAndAdd(effect, BaseAsyncManager.Instance);
				SingletonInstance<AssetPool>.Instance.LoadAndAdd(sound, BaseAsyncManager.Instance);
				yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(particle);
				yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(effect);
				yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(sound);
				EffectXmlAsset effectXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(effect) as EffectXmlAsset;
				ParticleXmlAsset particleXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(particle) as ParticleXmlAsset;
				TextAsset textAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(sound) as TextAsset;
				if (effectXmlAsset != null || particleXmlAsset != null)
				{
					ParticleManager.Instance().ParsePreloadingEffect(assetBundle, particleXmlAsset, effectXmlAsset, $"Assets/Res/Assets/weaponskin/{weaponSkin}/{weaponName}/effect", preLoadRes: false);
				}
				if (textAsset != null)
				{
					new SounfConfigXmlAsset().ParseXmlImmediatory(textAsset.text);
				}
				count++;
				SetLoadProgress(spercent + (float)count / (float)weaponSkinList.Count * (fpercent - spercent));
			}
		}
		SetLoadProgress(fpercent);
	}

	private string GetRaceTypeEffect(int raceType)
	{
		if (raceType == 18106)
		{
			return StringCache.IntToString(18006);
		}
		if (RuleUtilty.IsRpgTower(raceType))
		{
			return "tower";
		}
		return StringCache.IntToString(raceType);
	}

	private IEnumerator LoadEffectAssets(float fpercent)
	{
		while (!Contexts.sharedInstance.battleRoom.hasRoomData)
		{
			yield return null;
		}
		int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
		string freeType = Contexts.sharedInstance.battleRoom.roomData.Data.FreeType;
		BattleSingletonInstance<ResConfigFactory>.Instance.FilterByRuleId(raceType);
		RuleUtilty.GetFilterRuleSet(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType, out var ruleSet);
		HashSet<string> set = EffectConfigLoader.Instance.GetEffectSubPath(ruleSet);
		if (100 == raceType)
		{
			set.Add(Contexts.sharedInstance.battleRoom.roomData.Data.FreeType + "Mode");
		}
		if (RuleUtilty.IsRpg(raceType))
		{
			set.Add("rpgMode_" + GetRaceTypeEffect(raceType));
		}
		if (raceType == 15002 || raceType == 15004 || raceType == 15003)
		{
			set.Add("rpgMode_" + 15000);
		}
		if (raceType == 18501 || raceType == 18502 || raceType == 18503)
		{
			set.Add("rpgTeamMode");
		}
		if (!string.IsNullOrEmpty(freeType))
		{
			set.Add(freeType + "Mode");
		}
		if (raceType >= 110003 && raceType <= 110012)
		{
			set.Add("freeRpg_" + 110003 + "Mode");
		}
		else
		{
			set.Add("freeRpg_" + (100000 + raceType - 10000) + "Mode");
		}
		if (RuleUtilty.IsBioEvoLutionMode(raceType))
		{
			set.Add("bioevolutionmode");
		}
		if (RuleUtilty.IsTpsAcgMode(raceType))
		{
			set.Add("TpsMode");
		}
		if (raceType == 126)
		{
			set.Add("bigheadKnife2Mode");
		}
		AssetInfo cfgInfo = UiAssetBundleUtils.GetModeResourceConfigAssetInfo(string.Concat(RuleUtilty.GetConfigRule(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType)));
		this.InfoFormat("cfgInfo {0} ", cfgInfo);
		SingletonInstance<AssetPool>.Instance.LoadAndAdd(cfgInfo, BaseAsyncManager.Instance);
		yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(cfgInfo);
		object orNull = SingletonInstance<AssetPool>.Instance.GetOrNull(cfgInfo);
		if (orNull != null && orNull is TextAsset)
		{
			ModeResourcesConfig modeResourcesConfig = ModeResourcesConfigParser.ParseConfig((orNull as TextAsset).text);
			if (modeResourcesConfig.Inited)
			{
				foreach (string modeEffectUrl in modeResourcesConfig.ModeEffectUrls)
				{
					if (!set.Contains(modeEffectUrl))
					{
						set.Add(modeEffectUrl);
					}
				}
			}
		}
		SetLoadingTip(ScriptLocalization.Get("ParseEffectTip"));
		float spercent = _progressModel.Progress.Value;
		int count = 0;
		foreach (string s in set)
		{
			this.InfoFormat("try preloading asset {0}", s);
			string assetBundle = $"effect/{s}";
			SetLoadingTip(ScriptLocalization.Get("ParseEffectTip") + assetBundle);
			AssetInfo effect = new AssetInfo(assetBundle, $"Assets/Res/Assets/effect/{s}/effectConfig.xml", typeof(EffectXmlAsset), optional: true);
			AssetInfo particle = new AssetInfo(assetBundle, $"Assets/Res/Assets/effect/{s}/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true);
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(particle, BaseAsyncManager.Instance);
			SingletonInstance<AssetPool>.Instance.LoadAndAdd(effect, BaseAsyncManager.Instance);
			yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(particle);
			yield return SingletonInstance<AssetPool>.Instance.WaitForAsset(effect);
			EffectXmlAsset effectXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(effect) as EffectXmlAsset;
			ParticleXmlAsset particleXmlAsset = SingletonInstance<AssetPool>.Instance.GetOrNull(particle) as ParticleXmlAsset;
			if (effectXmlAsset != null || particleXmlAsset != null)
			{
				ParticleManager.Instance().ParseEffect(assetBundle, particleXmlAsset, effectXmlAsset, $"Assets/Res/Assets/effect/{s}", preLoadRes: false);
			}
			count++;
			SetLoadProgress(spercent + (float)count / (float)set.Count * (fpercent - spercent));
		}
		SetLoadProgress(fpercent);
	}

	private void SetLoadingTip(string resource)
	{
		_progressModel.Tip.Value = resource;
	}
}
