using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Assets.Libs.UiEditor.RunTime.RunTimeLogic.RunTimeNode;
using Assets.Scripts;
using Assets.Scripts.Effect.Level;
using Assets.Scripts.Input;
using Assets.Scripts.PlatformRunTime;
using Assets.Scripts.Utility;
using Assets.Scripts.Utility.Pool;
using Assets.Scripts.Utility.Sound;
using Assets.Sources.Chat;
using Assets.Sources.Components;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Components.BattleServer;
using Assets.Sources.Components.Chat;
using Assets.Sources.Components.Cross;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Chat;
using Assets.Sources.Components.SceneObject;
using Assets.Sources.Components.Snapshot;
using Assets.Sources.Components.Time;
using Assets.Sources.Components.Unload;
using Assets.Sources.Components.UserComand;
using Assets.Sources.Config;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework.System;
using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Modules;
using Assets.Sources.Networking.Packet;
using Assets.Sources.Networking.Server;
using Assets.Sources.Snapshots;
using Assets.Sources.Systems.GameRule;
using Assets.Sources.Systems.PacketHandle;
using Assets.Sources.Systems.Snapshot;
using Assets.Sources.Systems.Time;
using Assets.Sources.Systems.UserCommand;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Accessory;
using Assets.Sources.Utils.AssetManager;
using Assets.Sources.Utils.Effect;
using Assets.Sources.Utils.EventLogger;
using Assets.Sources.Utils.MoviePro;
using Assets.Sources.Utils.Weapon;
using CommonUtils;
using DefaultNamespace;
using NetData;
using SSJJ.BattleLoading;
using SSJJAsset.AssetBundle;
using SSJJAsset.AssetManager;
using SSJJBase.Constant;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Obscure;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using SSJJBase.Utility;
using SSJJRunTimeDataSample;
using SSJJUIEditor.UI;
using Sources.Utils.Ui;
using UnityEngine;
using UnityEngine.SceneManagement;
using physics.engine;
using physics.pool;

public class GameController : MonoBehaviour
{
	public static GameController Instance;

	public static IRecord Record;

	protected bool _initFinish;

	public string[] BootConfig;

	public bool OpenAvater;

	public bool IsOpenLod;

	public MovieCaptureManager MovieCaptureManager;

	public SSJJSystem _systems;

	private int _startLoadingTime;

	private const int FrameLimit = 100;

	public bool InitFinish => _initFinish;

	[DllImport("SSJJ1Plugin", CharSet = CharSet.Auto)]
	public static extern void BringToTop();

	[DllImport("SSJJ1Plugin", CharSet = CharSet.Auto)]
	public static extern void SetFullScreen();

	private void Awake()
	{
		CultureInfo.DefaultThreadCurrentCulture = CultureInfo.InvariantCulture;
		CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.InvariantCulture;
		CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
		Thread.CurrentThread.CurrentCulture = cultureInfo;
		Thread.CurrentThread.CurrentUICulture = cultureInfo;
		if (File.Exists("LookSceneDebug.txt"))
		{
			base.transform.GetComponent<GameController>().enabled = false;
			if (base.transform.GetComponent<OfflineGameController>() == null)
			{
				base.transform.gameObject.AddComponent<OfflineGameController>();
			}
		}
		else
		{
			InitSceneLoadAction();
			DebugLogger.EnableLog = false;
			EventPool.GetInstance().SetPoolInstance(new SharpEventPool());
			WeEngineUtil.InitNativeLibrary();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			Instance = this;
		}
	}

	private void InitGlobalDevProperties()
	{
		GlobalProperties.Instance.Properties["System"] = SystemInfo.operatingSystem;
		GlobalProperties.Instance.Properties["prn"] = SystemInfo.processorType;
		GlobalProperties.Instance.Properties["prf"] = SystemInfo.processorFrequency;
		GlobalProperties.Instance.Properties["prc"] = SystemInfo.processorCount;
		GlobalProperties.Instance.Properties["gdn"] = SystemInfo.graphicsDeviceName;
		GlobalProperties.Instance.Properties["gdms"] = SystemInfo.graphicsMemorySize;
		GlobalProperties.Instance.Properties["mts0"] = SystemInfo.maxTextureSize;
		GlobalProperties.Instance.Properties["mcs0"] = SystemInfo.maxCubemapSize;
		GlobalProperties.Instance.Properties["tms0"] = SystemInfo.systemMemorySize;
		GlobalProperties.Instance.Properties["sysType"] = ((IntPtr.Size == 8) ? "64" : "32");
		GlobalProperties.Instance.Properties["screen"] = $"{Screen.width}×{Screen.height}";
	}

	private void InitGlobalProperties()
	{
		GlobalProperties.Instance.Properties["CharId"] = TplManager.Instance.GetBootConfig().CharId;
		GlobalProperties.Instance.Properties["Version"] = "0.0.0.5";
		GlobalProperties.Instance.Properties["Branch"] = "origin/abroad_2024_12_17_viet";
		GlobalProperties.Instance.Properties["Commit"] = "55ae00b0013fa47583635b28f2798119277896d8";
		GlobalProperties.Instance.Properties["ResourceBase"] = TplManager.Instance.GetBootConfig().ResourceBase;
		GlobalProperties.Instance.Properties["IsBootCmd"] = TplManager.Instance.GetBootConfig().IsBootCmd;
		GlobalProperties.Instance.Properties["RoomId"] = TplManager.Instance.GetBootConfig().RoomId;
		GlobalProperties.Instance.Properties["LoginId"] = TplManager.Instance.GetBootConfig().LoginId;
		GlobalProperties.Instance.Properties["BattleServerIp"] = TplManager.Instance.GetBootConfig().BattleServerIp;
		GlobalProperties.Instance.Properties["BattleServerTcpPort"] = TplManager.Instance.GetBootConfig().BattleServerTcpPort;
		MonoBehaviourSingleton<ScreenShotManager>.Instance.ParseResouceBase(TplManager.Instance.GetBootConfig().ResourceBase);
	}

	public void StartLoading()
	{
		_startLoadingTime = (int)Time.realtimeSinceStartup;
	}

	public void LoadingOver()
	{
		int num = (int)Time.realtimeSinceStartup - _startLoadingTime;
		GlobalProperties.Instance.Properties["GameLoadingTime0"] = num;
		EventLogger.Instance.StageLogger("LoadingTimeDuring:" + num, StartStageEnum.LoadingTime);
	}

	private IEnumerator Start()
	{
		SetFullScreen();
		BringToTop();
		StartLoading();
		SetupHttps();
		Seed.Instance.RandomSeed();
		yield return SceneManager.LoadSceneAsync("BattleLoading", LoadSceneMode.Additive);
		Application.runInBackground = true;
		InitDisplay();
		InitGlobalDevProperties();
		EventLogger.Instance.StageLogger("StartStageEnum.ApplySetting", StartStageEnum.ApplySetting);
		Application.logMessageReceived += ApplicationOnLogMessageReceived;
		yield return InitBootConfigFromCommand(BootConfig);
		EventLogger.Instance.StageLogger(TplManager.Instance.GetBootConfig().ResourceBase, StartStageEnum.InitCmd);
		if (CheckPlatformEffect())
		{
			InitGlobalProperties();
			AssetBundleManagerUtility.InitResourceUrl();
			GlobalProperties.Instance.Properties["rVersion"] = AssetBundleManager.GetAssetBundleManifestMd5();
			EventLogger.Instance.StageLogger(TplManager.Instance.GetBootConfig().ResourceBase, StartStageEnum.InitResUrl);
			base.gameObject.AddComponent<UnityMainThreadDispatcher>();
			Contexts sharedInstance = Contexts.sharedInstance;
			CreateSingletonEntities(sharedInstance);
			_systems = new SSJJSystem();
			CreateBasicSystems(sharedInstance);
			EventLogger.Instance.StageLogger("StartStageEnum.InitEntities", StartStageEnum.InitEntities);
			yield return InitAssetBundleManager();
			EventLogger.Instance.StageLogger(AssetBundleManager.GetAssetBundleManifestMd5(), StartStageEnum.InitBundleManager);
			yield return LoadTables();
			EventLogger.Instance.StageLogger("StartStageEnum.InitTables", StartStageEnum.InitTables);
			yield return LoadConfig();
			EventLogger.Instance.StageLogger("StartStageEnum.InitConfig", StartStageEnum.InitAnimConfig);
			GameSetting.Apply();
			InitOther();
			_initFinish = true;
			this.Info("Start Finish");
		}
	}

	protected void InitOther()
	{
		LogBaseInfo();
		CheckSupportGpuInstance();
		if (SpecailDebug.Instance.DataSampler)
		{
			MonoBehaviourSingleton<DataSampleController>.Instance.Init(isOpen: true, SingletonInstance<AssetPool>.Instance, FpsDisplay.GetInstance());
			MonoBehaviourSingleton<DataSampleController>.Instance.StartSample();
		}
		StringCache.Init();
	}

	private void UiEditorDataInit()
	{
		BattleSingletonInstance<DataProviderManager>.Instance.Init(Contexts.sharedInstance);
		TextStyleManager.Instance.Init();
	}

	private void LogBaseInfo()
	{
		this.InfoFormat("Version : {0}", "0.0.0.5");
		this.InfoFormat("Branch : {0}", "origin/abroad_2024_12_17_viet");
		this.InfoFormat("Commit : {0}", "55ae00b0013fa47583635b28f2798119277896d8");
	}

	private void InitSceneLoadAction()
	{
		SceneManager.sceneUnloaded += TotalMemoryUtility.UnloadScenes;
		SceneManager.sceneLoaded += TotalMemoryUtility.LoadScenes;
	}

	private void CheckSupportGpuInstance()
	{
		bool supportsInstancing = SystemInfo.supportsInstancing;
		GlobalProperties.Instance.Properties["SupportInstance0"] = supportsInstancing;
		EventLogger.Instance.StageLogger("SupportInstance:" + supportsInstancing, StartStageEnum.Dx);
	}

	private void SetupHttps()
	{
		ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback(RemoteCertificateValidationCallback));
	}

	private bool RemoteCertificateValidationCallback(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
	{
		bool result = true;
		if (sslPolicyErrors != 0)
		{
			for (int i = 0; i < chain.ChainStatus.Length; i++)
			{
				if (chain.ChainStatus[i].Status != X509ChainStatusFlags.RevocationStatusUnknown)
				{
					chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
					chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
					chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
					chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
					if (!chain.Build((X509Certificate2)certificate))
					{
						result = false;
						break;
					}
				}
			}
		}
		return result;
	}

	protected void InitDisplay()
	{
		Screen.fullScreen = true;
		if (Display.main.systemWidth < 512 || Display.main.systemHeight < 256 || Display.main.systemWidth > 8192 || Display.main.systemHeight > 8192)
		{
			this.LogErrorFormat("GameController SetResolution error {0} x {1}", Display.main.systemWidth, Display.main.systemHeight);
		}
		else
		{
			Screen.SetResolution(Display.main.systemWidth, Display.main.systemHeight, fullscreen: true);
		}
	}

	private Dictionary<string, string> ParseCommandLine(string[] args)
	{
		this.InfoFormat("Start ParseCommondLine , ArgsLen > {0}", args.Length);
		foreach (string args2 in args)
		{
			this.InfoFormat("GameBootConfig: {0}", args2);
		}
		this.Info("End ParseCommondLine");
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		for (int j = 0; j < args.Length; j++)
		{
			string text = args[j];
			if (args[j].StartsWith("--"))
			{
				string key = text.Remove(0, 2);
				string value = "";
				if (j + 1 < args.Length && !args[j + 1].StartsWith("-"))
				{
					value = args[j + 1];
				}
				dictionary[key] = value;
			}
			if (args[j].StartsWith("-") && !args[j].StartsWith("--"))
			{
				string key2 = text.Replace("-", "");
				string value2 = "";
				if (j + 1 < args.Length && !args[j + 1].StartsWith("-"))
				{
					value2 = args[j + 1];
				}
				dictionary[key2] = value2;
			}
		}
		return dictionary;
	}

	private bool CheckPlatformEffect()
	{
		if (PlatformRunTime.CanRunTime("LocalTest", TplManager.Instance.GameBootConfig.Platform))
		{
			return true;
		}
		return false;
	}

	protected IEnumerator InitBootConfigFromCommand(string[] bootArg)
	{
		if (bootArg == null)
		{
			yield break;
		}
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		this.InfoFormat("arg.len {0}  cmdargs.len {1}", bootArg.Length, commandLineArgs.Length);
		Dictionary<string, string> dictionary = ParseCommandLine((bootArg.Length != 0) ? bootArg : commandLineArgs);
		if (dictionary.ContainsKey("ua"))
		{
			GlobalProperties.Instance.Properties["ua"] = dictionary["ua"];
		}
		if (dictionary.ContainsKey("la"))
		{
			string text = dictionary["la"];
			EventLogger.Instance.StageLogger("", StartStageEnum.ParseBase64, text);
			if (text.EndsWith("/"))
			{
				text = text.Substring(0, text.Length - 1);
			}
			this.InfoFormat("json org:{0}", text);
			BootConfigData bootConfig = ProtoBufUtility.Deserialize<BootConfigData>(Base62Utility.base62Decode(text.ToCharArray()));
			TplManager.Instance.GameBootConfig = BootConfigLoader.LoadBootConfig(bootConfig);
			TplManager.Instance.GameBootConfig.IsBootCmd = true;
			MonoBehaviourSingleton<BattleLoadingManager>.Instance.ProgressModel.IsRpg.Value = TplManager.Instance.GameBootConfig.HallModeRuleId == 2;
			this.InfoFormat("GameBootConfig: {0}", TplManager.Instance.GameBootConfig.ToString());
			EventLogger.Instance.StageLogger("", StartStageEnum.ParseBase64Succ, text);
		}
		if (dictionary.ContainsKey("preload_dir"))
		{
			string text2 = dictionary["preload_dir"];
			if (!string.IsNullOrEmpty(text2))
			{
				this.InfoFormat("Cache Path {0}", text2);
				if (!Directory.Exists(text2))
				{
					Directory.CreateDirectory(text2);
				}
				AssetBundleLoader.SetCachePath(text2);
			}
		}
		if (dictionary.ContainsKey("windowmode"))
		{
			MonoBehaviourSingleton<ScreenShotManager>.Instance.IsExclusiveWindowMode = dictionary["windowmode"].Equals("exclusive");
			this.Info("IsExclusiveWindowMode > " + MonoBehaviourSingleton<ScreenShotManager>.Instance.IsExclusiveWindowMode);
		}
		if (dictionary.ContainsKey("configrevise") && dictionary["configrevise"] == "1")
		{
			TplManager.Instance.GameBootConfig.ConfigFileRevise = true;
		}
		if (dictionary.ContainsKey("npopen") && dictionary["npopen"] == "1")
		{
			TplManager.Instance.GameBootConfig.NpOpen = true;
		}
		if (dictionary.ContainsKey("configmd5"))
		{
			TplManager.Instance.GameBootConfig.configMd5 = dictionary["configmd5"];
		}
		if (dictionary.ContainsKey("isGolbalRoom"))
		{
			TplManager.Instance.GameBootConfig.isGolbalRoom = dictionary["isGolbalRoom"] == "1";
		}
		yield return null;
	}

	private void ApplicationOnLogMessageReceived(string condition, string stackTrace, LogType type)
	{
		if (LogType.Exception == type)
		{
			this.LogErrorFormat("Unity Exception {0}, {1} ", condition, stackTrace);
		}
	}

	private void OnDestroy()
	{
		if (_systems != null)
		{
			_systems.Cleanup();
			_systems = null;
		}
	}

	protected IEnumerator InitAssetBundleManager()
	{
		string md5 = null;
		if (!GameEnvironment.IsSimulation)
		{
			string versionUrl = AssetBundleManagerUtility.GetResourceBaseURL(TplManager.Instance.GetBootConfig().ResourceBase) + AssetBundleUtility.GetPlatformName() + "/version.php";
			WebClientStringDownloader www = new WebClientStringDownloader();
			yield return www.DownloadString(versionUrl);
			if (www.GetError() == null)
			{
				md5 = www.GetResult();
				if (!string.IsNullOrEmpty(md5))
				{
					md5 = md5.Trim();
				}
				this.InfoFormat("InitAssetBundleManager url {0}, msd:{1} ", versionUrl, md5);
				if (md5.Length > 64)
				{
					this.LogErrorFormat("InitAssetBundleManager url {0} error {1} ", versionUrl, www.GetError());
				}
				AssetBundleManager.SetAssetBundleManifestMd5(md5);
			}
			else
			{
				this.InfoFormat("InitAssetBundleManager url {0} error {1} ", versionUrl, www.GetError());
				this.LogErrorFormat("InitAssetBundleManager url {0} error {1} ", versionUrl, www.GetError());
			}
			if (string.IsNullOrEmpty(md5))
			{
				this.LogError("md5 check null !!!");
			}
		}
		yield return AssetBundleManager.Initialize(md5);
	}

	protected IEnumerator LoadTables()
	{
		yield return WeaponInfoLoader.Instance.Load();
		yield return PlayerAnimationLoader.Instance.Load();
		yield return ResConfigLoader.Instance.Load();
		yield return MapInfoLoader.Instance.Load();
		yield return EffectConfigLoader.Instance.Load();
		yield return WeaponSkillLoader.Instance.Load();
		yield return WeaponCrossLoader.Instance.Load();
		yield return LocalEntityEffectLoader.Instance.Load();
		yield return AudioRolloffLoader.Instance.Load();
		yield return GameSettingLoader.Instance.Load();
		yield return GameMessageLoader.Instance.Load();
		yield return GameMessagePvpLoader.Instance.Load();
		yield return SoundSystemLoader.Instance.Load();
		yield return WeaponSkinInfoLoader.Instance.Load();
		yield return PlayerSkinInfoLoader.Instance.Load();
		yield return MonoBehaviourSingleton<AutoSoundLoader>.Instance.Load();
		yield return MonoBehaviourSingleton<BgmSoundLoader>.Instance.Load();
		yield return CommonParticleResLoader.Instance.Load();
		yield return SingletonInstance<WeaponSkinColorLoader>.Instance.Load();
		yield return SceneBuffLoader.Instance.Load();
		yield return MonoBehaviourSingleton<ParticleEffectLoader>.Instance.Load();
		yield return BattleSingletonInstance<UiAssetReferenceLoader>.Instance.Load();
		yield return PlayerInfoSkillLoader.Instance.Load();
		yield return AccessoryConfigLoader.Instance.Load();
		yield return GPUAnimInfoLoader.Instance.Load();
	}

	protected IEnumerator LoadConfig()
	{
		yield return CareerData.LoadConfig();
		yield return SingletonInstance<ChampionWeaponAndSkillParser>.Instance.LoadConfig();
		yield return SingletonInstance<AccessoryHeadChangeParser>.Instance.LoadConfig();
		yield return SingletonInstance<UiMessageParser>.Instance.LoadConfig();
		yield return SingletonInstance<ObtainSupplieParser>.Instance.LoadConfig();
		yield return SingletonInstance<MonsterSkillIconsConfigParser>.Instance.LoadConfig();
		yield return SingletonInstance<ParticleEffectVisibleConfig>.Instance.LoadConfig();
	}

	private void Update()
	{
		if (Record == null || !Record.UpdateGame())
		{
			InputCollector.Instance.Collect(Time.deltaTime);
			if (_systems != null)
			{
				_systems.Execute();
				InputCollector.Instance.Reset();
			}
		}
	}

	public void CreateBasicSystems(Contexts contexts)
	{
		Feature feature = new Feature("BasicSystems");
		feature.Add(new PacketHandleFeature(contexts));
		feature.Initialize();
		_systems.Add(feature);
	}

	public virtual void CreateFpsSystems(Contexts contexts)
	{
		Feature feature = new Feature("EntitasSystems");
		feature.Add(new TimeFeature(contexts));
		feature.Add(new UserCommandFeature(contexts));
		feature.Add(new SnapshotFeature(contexts));
		feature.Add(new GameRuleFeature(contexts));
		feature.Add(new GameModuleFeature(contexts, new TopLevelGameModule(contexts)));
		feature.Initialize();
		_systems.Add(feature);
		UiEditorDataInit();
	}

	public static void CreateSingletonEntities(Contexts contexts)
	{
		BattleRoomEntity battleRoomEntity = contexts.battleRoom.CreateEntity();
		battleRoomEntity.AddComponent(8, new GameStateComponent
		{
			State = BattleGameState.Idle
		});
		battleRoomEntity.AddAssetPool(SingletonInstance<AssetPool>.Instance);
		battleRoomEntity.AddGameObjectPool(MonoBehaviourSingleton<UnityGameObjectPool>.Instance);
		battleRoomEntity.AddComponent(13, new PlayerInfoComponent());
		battleRoomEntity.AddComponent(10, new LobbyInfoComponent());
		battleRoomEntity.AddSceneItemInfo(new Dictionary<string, Dictionary<int, PeekabooItemTmpData>>());
		battleRoomEntity.AddComponent(15, new RoomDataComponent());
		battleRoomEntity.AddComponent(11, new MapInfoComponent());
		battleRoomEntity.AddComponent(17, new SectionTimeComponent());
		battleRoomEntity.AddComponent(4, new BestKillComponent());
		battleRoomEntity.AddComponent(5, new EngineEntityComponent());
		battleRoomEntity.AddComponent(7, new GameOverComponent());
		battleRoomEntity.AddComponent(1, new AntiAddictionComponent());
		battleRoomEntity.AddComponent(0, new AceComponent());
		BattleServerEntity battleServerEntity = contexts.battleServer.CreateEntity();
		battleServerEntity.AddComponent(0, new BattleServerComponent
		{
			Server = new BattleServer(new SnapShotCompress(), ClientTcpMethod.IgnoreTcpList, SpecailDebug.Instance.GetUdpBytes)
		});
		battleServerEntity.AddComponent(1, new HealthComponent());
		TimeEntity timeEntity = contexts.time.CreateEntity();
		timeEntity.AddComponent(1, new TimeComponent());
		timeEntity.AddComponent(0, new CommonTimerComponent());
		contexts.snapshot.CreateEntity().AddComponent(0, new SnapshotsComponent());
		UserCommandEntity userCommandEntity = contexts.userCommand.CreateEntity();
		userCommandEntity.AddComponent(0, new CommandsComponent());
		userCommandEntity.AddComponent(1, new InputComponent());
		contexts.worldCamera.SetCameraMode(PlayerCameraModeEnum.First);
		contexts.worldCamera.SetCameraData(newIsUsingXpSkill: false, 0f, 0f, 0f, 0f, 0, 0, newIsTps: false, 0, 0);
		CrossEntity crossEntity = contexts.cross.CreateEntity();
		crossEntity.AddComponent(2, new CrossSpreadComponent());
		crossEntity.AddComponent(4, new HitCrossComponent());
		SceneObjectEntity sceneObjectEntity = contexts.sceneObject.CreateEntity();
		sceneObjectEntity.AddComponent(99, new ParticleLodComponent());
		sceneObjectEntity.particleLod.SizeUnits = new List<IParticleSizeUnit>(320);
		contexts.chat.CreateEntity().AddChatJobHistroy(default(ChatInputData), new Queue<string>(), new MarkGroup<IChatHistroyData>(), new MarkGroup<IChatHistroyData>(), new MarkGroup<IChatHistroyData>(), new MarkGroup<IChatHononaryData>());
		UnloadEntity unloadEntity = contexts.unload.CreateEntity();
		unloadEntity.AddComponent(2, new UnloadGamePoolComponent());
		unloadEntity.AddComponent(4, new UnloadThirdWeaponResComponent());
		contexts.sceneObject.CreateEntity().AddComponent(88, new MyWeaponEditorUiComponent());
		contexts.sceneObject.CreateEntity().AddComponent(115, new RuleUiCompoent());
		SingletonComponentUtils.CreateSingletonEntities(contexts);
	}

	private void OnApplicationQuit()
	{
	}
}
