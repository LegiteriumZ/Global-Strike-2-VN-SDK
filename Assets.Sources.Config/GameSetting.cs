using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Generated.Table;
using Assets.Sources.CsvLoader;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using Assets.UiFramework.Libs;
using NetData;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJNetworking.BattleServer;
using SSJJUserCmd;
using Sharpen;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Sources.Config;

public class GameSetting
{
	private static LoggerAdapter _logger;

	public const int FrameLimitMax = 200;

	public const int FrameLimitMin = 60;

	private static ConfigData _config;

	public static bool SpaceJumpOpen;

	private static bool _inited;

	private static Action _action;

	private static List<Vector2> _screenSize;

	private static int[] _antiAliasLevel;

	public static ConfigData Config
	{
		get
		{
			if (_config == null)
			{
				_config = CreateNewConfig();
				FilterGameSize();
			}
			if (!_inited && GameSettingLoader.Instance.Table.GetRowList().Count > 0)
			{
				ResetToDefaultValue(_config);
				GetSavedConfig(_config);
				_inited = true;
			}
			return _config;
		}
	}

	static GameSetting()
	{
		_logger = new LoggerAdapter(typeof(GameSetting));
		SpaceJumpOpen = false;
		_screenSize = new List<Vector2>();
		_antiAliasLevel = new int[4] { 0, 2, 4, 8 };
	}

	private static void FilterGameSize()
	{
		_screenSize.Add(new Vector2(3840f, 2160f));
		_screenSize.Add(new Vector2(2736f, 1824f));
		_screenSize.Add(new Vector2(2560f, 1600f));
		_screenSize.Add(new Vector2(2560f, 1440f));
		_screenSize.Add(new Vector2(2560f, 1080f));
		_screenSize.Add(new Vector2(2048f, 1152f));
		_screenSize.Add(new Vector2(1920f, 1200f));
		_screenSize.Add(new Vector2(1920f, 1080f));
		_screenSize.Add(new Vector2(1680f, 1050f));
		_screenSize.Add(new Vector2(1600f, 900f));
		_screenSize.Add(new Vector2(1440f, 900f));
		_screenSize.Add(new Vector2(1366f, 768f));
		_screenSize.Add(new Vector2(1280f, 1024f));
		_screenSize.Add(new Vector2(1280f, 960f));
		_screenSize.Add(new Vector2(1280f, 768f));
		_screenSize.Add(new Vector2(1024f, 768f));
		_screenSize.Add(new Vector2(800f, 600f));
		Vector2 vector = new Vector2(Display.main.systemWidth, Display.main.systemHeight);
		bool flag = false;
		for (int num = _screenSize.Count - 1; num >= 0; num--)
		{
			if (NotSupported(_screenSize[num]))
			{
				_screenSize.Remove(num);
			}
			else if ((int)_screenSize[num].x == (int)vector.x && (int)_screenSize[num].y == (int)vector.y)
			{
				flag = true;
			}
		}
		CalculateBestScreenSize(vector);
		if (!flag)
		{
			_screenSize.Add(0, vector);
		}
	}

	private static void CalculateBestScreenSize(Vector2 currRe, bool resetNow = false)
	{
		if (currRe.y < 768f)
		{
			AbstractModel.BestScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			AbstractModel.BestScreenSize = new Vector2(1024f, 768f);
		}
		else if (currRe.y < 1450f)
		{
			AbstractModel.BestScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
			AbstractModel.BestScreenSize = new Vector2(currRe.x, currRe.y);
		}
		else if (currRe.y < 1800f)
		{
			AbstractModel.BestScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			AbstractModel.BestScreenSize = new Vector2(1680f, 1050f);
		}
		else
		{
			AbstractModel.BestScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			bool flag = false;
			for (int num = 5; num >= 2; num--)
			{
				if ((int)currRe.y % num == 0 && currRe.y / (float)num >= 900f)
				{
					AbstractModel.BestScreenSize = currRe / num;
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				AbstractModel.BestScreenSize = new Vector2(1680f, 1050f);
			}
		}
		if (!resetNow)
		{
			return;
		}
		GameObject[] rootGameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
		foreach (GameObject gameObject in rootGameObjects)
		{
			CanvasScaler component = gameObject.GetComponent<CanvasScaler>();
			if (component != null && !gameObject.name.StartsWith("mcgamesetting"))
			{
				component.uiScaleMode = AbstractModel.BestScaleMode;
				component.referenceResolution = AbstractModel.BestScreenSize;
			}
		}
	}

	private static bool NotSupported(Vector2 size)
	{
		Resolution[] resolutions = Screen.resolutions;
		for (int i = 0; i < resolutions.Length; i++)
		{
			Resolution resolution = resolutions[i];
			if (resolution.width == (int)size.x && resolution.height == (int)size.y)
			{
				return false;
			}
		}
		return true;
	}

	private static int GetGameSizeIndex(int width, int height)
	{
		int num = _screenSize.FindIndex((Vector2 v) => (int)v.x == width && (int)v.y == height);
		if (num <= 0)
		{
			return 0;
		}
		return num;
	}

	public static ConfigData CreateNewConfig()
	{
		ConfigData configData = new ConfigData();
		ResetToDefaultValue(configData);
		GetSavedConfig(configData);
		return configData;
	}

	private static int GetDefaultFrameLimit()
	{
		int refreshRate = Screen.currentResolution.refreshRate;
		if (refreshRate < 60)
		{
			return 60;
		}
		if (refreshRate > 100)
		{
			return 100;
		}
		return refreshRate;
	}

	public static void InitGameSizeConfig()
	{
		GameSettingTable.Row row = GameSettingLoader.Instance.Table.Find_Property("GameSize");
		if (row != null)
		{
			row.Select = new string[_screenSize.Count];
			for (int i = 0; i < _screenSize.Count; i++)
			{
				row.Select[i] = _screenSize[i].x + "*" + _screenSize[i].y;
			}
			row.DefaultSelect = _screenSize[0].x + "*" + _screenSize[0].y;
		}
	}

	public static void ResetToDefaultValue(ConfigData configConstant)
	{
		List<GameSettingTable.Row> rowList = GameSettingLoader.Instance.Table.GetRowList();
		Type typeFromHandle = typeof(ConfigData);
		foreach (GameSettingTable.Row item in rowList)
		{
			ResetToDefaultValue(typeFromHandle.GetField(item.Property), item, configConstant);
		}
		configConstant.GameSize = GetGameSizeIndex(Display.main.systemWidth, Display.main.systemHeight);
		configConstant.FrameLimit = GetDefaultFrameLimit();
		if (SystemInfo.systemMemorySize / 1000 < 4)
		{
			configConstant.QualityLevel = 1;
			configConstant.ShowThirdWeapon = 0;
			configConstant.TextureQuality = 2;
			configConstant.PlayerShadow = 0;
			configConstant.AntiAliasLevel = 0;
		}
		GameSoundConfig copyconfig = new GameSoundConfig((float)configConstant.WeaponVolume / 100f, (float)configConstant.EnvironmentVolume / 100f, (float)configConstant.AsideVolume / 100f, (float)configConstant.StepVolume / 100f, (float)configConstant.VoiceListenVolume / 100f, (float)configConstant.VoiceSpeakVolume / 100f, (float)configConstant.BgmSpeakVolume / 100f);
		GameSoundManager.InitConfig(ref copyconfig);
		_logger.InfoFormat("System Memory Size : {0} GB", SystemInfo.systemMemorySize / 1000);
	}

	public static void ResetToDefaultValue(FieldInfo field, GameSettingTable.Row row, ConfigData config)
	{
		if (field != null)
		{
			if (row.Type == GameSettingTable.ControlType.Slider)
			{
				field.SetValue(config, int.Parse(row.DefaultSelect));
			}
			else
			{
				field.SetValue(config, Array.IndexOf(row.Select, row.DefaultSelect));
			}
		}
	}

	public static void CheckVersion()
	{
		foreach (GameSettingTable.Row row in GameSettingLoader.Instance.Table.GetRowList())
		{
			if (string.IsNullOrEmpty(row.Property))
			{
				continue;
			}
			string key = row.Property + "Version";
			int version = row.Version;
			if (!PlayerPrefs.HasKey(key) || PlayerPrefs.GetInt(key) < version)
			{
				PlayerPrefs.SetInt(key, version);
				if (PlayerPrefs.HasKey(row.Property))
				{
					PlayerPrefs.DeleteKey(row.Property);
				}
			}
		}
	}

	private static void GetSavedConfig(ConfigData configConstant)
	{
		CheckVersion();
		FieldInfo[] fields = typeof(ConfigData).GetFields();
		foreach (FieldInfo fieldInfo in fields)
		{
			if (!PlayerPrefs.HasKey(fieldInfo.Name))
			{
				continue;
			}
			int @int = PlayerPrefs.GetInt(fieldInfo.Name);
			fieldInfo.SetValue(configConstant, @int);
			bool flag = false;
			GameSettingTable.Row row = GameSettingLoader.Instance.Table.Find_Name(fieldInfo.Name);
			if (row != null)
			{
				if (row.Type == GameSettingTable.ControlType.Slider && (@int < int.Parse(row.Select[0]) || @int > int.Parse(row.Select[1])))
				{
					flag = true;
				}
				else if (row.Type != GameSettingTable.ControlType.Slider && (@int < 0 || @int >= row.Select.Length))
				{
					flag = true;
				}
			}
			if (flag)
			{
				_logger.ErrorFormat("Saved Game Setting Value {0} Error : {1}", fieldInfo.Name, @int);
				if (fieldInfo.Name == "CrossColorIndex")
				{
					configConstant.CrossTypeIndex = 0;
				}
			}
		}
		GameSoundConfig copyconfig = new GameSoundConfig((float)configConstant.WeaponVolume / 100f, (float)configConstant.EnvironmentVolume / 100f, (float)configConstant.AsideVolume / 100f, (float)configConstant.StepVolume / 100f, (float)configConstant.VoiceListenVolume / 100f, (float)configConstant.VoiceSpeakVolume / 100f, (float)configConstant.BgmSpeakVolume / 100f);
		GameSoundManager.InitConfig(ref copyconfig);
		configConstant.FrameLimit = ((configConstant.FrameLimit < 60) ? 60 : configConstant.FrameLimit);
		configConstant.SuggestFlag = 3;
	}

	public static void Save(ConfigData newValue)
	{
		Type typeFromHandle = typeof(ConfigData);
		FieldInfo[] fields = typeFromHandle.GetFields();
		FieldInfo[] array;
		if (newValue.QualityLevel == 0)
		{
			array = fields;
			foreach (FieldInfo fieldInfo in array)
			{
				if (fieldInfo.Name.StartsWith("Custom"))
				{
					string name = fieldInfo.Name.Substring(6);
					FieldInfo field = typeFromHandle.GetField(name);
					fieldInfo.SetValue(newValue, field.GetValue(newValue));
				}
			}
		}
		array = fields;
		foreach (FieldInfo obj in array)
		{
			SaveProperty(value: (int)obj.GetValue(newValue), key: obj.Name);
		}
		PlayerPrefs.Save();
		Copy(_config, newValue);
	}

	public static void Copy(ConfigData desConfig, ConfigData srcConfig)
	{
		FieldInfo[] fields = typeof(ConfigData).GetFields();
		foreach (FieldInfo obj in fields)
		{
			object value = obj.GetValue(srcConfig);
			obj.SetValue(desConfig, value);
		}
	}

	private static void SaveProperty(string key, int value)
	{
		PlayerPrefs.SetInt(key, value);
	}

	public static void Apply()
	{
		QualitySettings.shadows = ShadowQuality.Disable;
		int antiAliasLevel = Config.AntiAliasLevel;
		if (antiAliasLevel > -1 && antiAliasLevel < _antiAliasLevel.Length)
		{
			QualitySettings.antiAliasing = _antiAliasLevel[antiAliasLevel];
		}
		else
		{
			QualitySettings.antiAliasing = _antiAliasLevel[0];
		}
		QualitySettings.masterTextureLimit = Config.TextureQuality;
		QualitySettings.lodBias = 1f;
		switch (QualitySettings.masterTextureLimit)
		{
		case 2:
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
			break;
		case 1:
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
			break;
		default:
			QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
			break;
		}
		MonoBehaviourSingleton<MyQualitySettings>.Instance.SetShadowLevel((MyQualitySettings.QualityLevel)Config.PlayerShadow);
		AudioListener.volume = (float)Config.NewTotalVolume / 100f;
		QualitySettings.vSyncCount = Config.VSync;
		Application.targetFrameRate = Config.FrameLimit;
		Config.MouseSmooth = ((Config.MouseSmoothSwitch == 1) ? Config.MouseSmooth : 0);
		GameSoundConfig copyconfig = new GameSoundConfig((float)Config.WeaponVolume / 100f, (float)Config.EnvironmentVolume / 100f, (float)Config.AsideVolume / 100f, (float)Config.StepVolume / 100f, (float)Config.VoiceListenVolume / 100f, (float)Config.VoiceSpeakVolume / 100f, (float)Config.BgmSpeakVolume / 100f);
		GameSoundManager.InitConfig(ref copyconfig);
		int num = Display.main.systemWidth;
		int num2 = Display.main.systemHeight;
		if (_screenSize.Count > Config.GameSize && Config.GameSize > -1)
		{
			num = (int)_screenSize[Config.GameSize].x;
			num2 = (int)_screenSize[Config.GameSize].y;
		}
		if (num < 512 || num2 < 256 || num > 8192 || num2 > 8192)
		{
			_logger.ErrorFormat("SetResolution error [{0}] {1} x {2}", Config.GameSize, num, num2);
			for (int i = 0; i < _screenSize.Count; i++)
			{
				if (_screenSize[i].x > 0f && _screenSize[i].y > 0f)
				{
					num = (int)_screenSize[1].x;
					num2 = (int)_screenSize[1].y;
				}
			}
			if (num < 512 || num2 < 256)
			{
				num = 800;
				num2 = 600;
			}
			else if (num > 8192 || num2 > 8192)
			{
				num = 1920;
				num2 = 1080;
			}
		}
		SendServer();
		VoiceUtility.AdjustVoiceVolume();
		if (!MonoBehaviourSingleton<ScreenShotManager>.Instance.IsExclusiveWindowMode)
		{
			Screen.SetResolution(num, num2, fullscreen: true);
		}
		else
		{
			Screen.SetResolution(num, num2, FullScreenMode.ExclusiveFullScreen);
		}
		MouseMove.Init();
		CalculateBestScreenSize(new Vector2(num, num2), resetNow: true);
		if (_action != null)
		{
			_action();
		}
	}

	public static void UpdateSquatKey()
	{
		List<KeyBinding> keyBindings = Contexts.sharedInstance.userCommand.input.KeyBindings;
		for (int num = keyBindings.Count - 1; num >= 0; num--)
		{
			if (keyBindings[num].KeyCodes[0] == KeyCode.LeftShift || keyBindings[num].KeyCodes[0] == KeyCode.RightShift)
			{
				keyBindings.RemoveAt(num);
			}
			else if (keyBindings[num].KeyCodes[0] == KeyCode.LeftCommand || keyBindings[num].KeyCodes[0] == KeyCode.RightControl)
			{
				keyBindings.RemoveAt(num);
			}
			else if (keyBindings[num].KeyCodes[0] == KeyCode.L)
			{
				keyBindings.RemoveAt(num);
			}
		}
	}

	public static void SendServer()
	{
		IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
		NetData.ConfigData configData = new NetData.ConfigData();
		configData.SpaceDuckJump = Config.SpaceJump == 1 || SpaceJumpOpen;
		configData.CtrlDuck = Config.SquatKey == 1;
		if (server.State == BattleServerState.Connected)
		{
			server.SendTcpMessage(140, configData);
		}
	}

	public static void RegisterApplyCallBack(Action cbAction)
	{
		_action = (Action)Delegate.Combine(_action, cbAction);
	}

	public static string GetSize()
	{
		if (Config.GameSize > -1 && Config.GameSize < _screenSize.Count)
		{
			return _screenSize[Config.GameSize].x + " " + _screenSize[Config.GameSize].y;
		}
		return "Error";
	}
}
