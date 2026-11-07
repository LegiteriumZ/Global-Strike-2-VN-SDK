using System;
using System.Collections.Generic;
using System.Xml;
using Assets.Generated.Table;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.CsvLoader;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.Res;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Accessory;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils;
using Assets.Sources.Utils.AssetManager;
using Assets.Sources.Utils.Pool;
using Assets.Sources.Utils.Ui;
using Assets.Sources.XmlAsset;
using CommonUtils;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using SSJJUIEditor.ParticleEditor;
using UnityEngine;

namespace Assets.Sources.Particle;

public class ParticleManager
{
	private static ParticleManager _instance;

	private readonly CaseInSensitiveDictionary<List<EntityHangEffectData>> _entityHangEffectDatas = new CaseInSensitiveDictionary<List<EntityHangEffectData>>();

	private readonly CaseInSensitiveDictionary<List<EventEffectData>> _eventEffectDatas = new CaseInSensitiveDictionary<List<EventEffectData>>();

	private readonly CaseInSensitiveDictionary<List<LineLinkEffectData>> _lineLinkEffectDatas = new CaseInSensitiveDictionary<List<LineLinkEffectData>>();

	private readonly Dictionary<int, List<LineLinkStartEffectData>> _lineLinkStartEffectDatas = new Dictionary<int, List<LineLinkStartEffectData>>();

	private readonly Dictionary<int, List<PlayerTitleEffectData>> _playerTitleEffectDatas = new Dictionary<int, List<PlayerTitleEffectData>>();

	private readonly Dictionary<int, List<LineLinkFinishEffectData>> _lineLinkFinishEffectDatas = new Dictionary<int, List<LineLinkFinishEffectData>>();

	private readonly CaseInSensitiveDictionary<List<MoveEntityEffectData>> _moveEntityEffectDatas = new CaseInSensitiveDictionary<List<MoveEntityEffectData>>();

	private readonly CaseInSensitiveDictionary<List<TailEffectData>> _tailEffectDatas = new CaseInSensitiveDictionary<List<TailEffectData>>();

	private readonly CaseInSensitiveDictionary<List<PlayerAnimEffectData>> _playerAnimEffectDatas = new CaseInSensitiveDictionary<List<PlayerAnimEffectData>>();

	private readonly CaseInSensitiveDictionary<List<PlayerInfoEffectData>> _playerInfoEffectDatas = new CaseInSensitiveDictionary<List<PlayerInfoEffectData>>();

	private readonly Dictionary<int, List<PlayerInfoParticleLoopEffectData>> _playerInfoParticleEffectDatas = new Dictionary<int, List<PlayerInfoParticleLoopEffectData>>();

	private readonly Dictionary<int, List<PlayerInfoAttackEffectData>> _playerInfoAttackEffectDatas = new Dictionary<int, List<PlayerInfoAttackEffectData>>();

	private readonly CaseInSensitiveDictionary<List<SceneBuffEffectData>> _sceneBuffEffectDatas = new CaseInSensitiveDictionary<List<SceneBuffEffectData>>();

	private readonly CaseInSensitiveDictionary<List<AttachEventEffectData>> _showBodyEffectDatas = new CaseInSensitiveDictionary<List<AttachEventEffectData>>();

	private readonly CaseInSensitiveDictionary<CameraEffectConfigItem> _cameraEffectDatas = new CaseInSensitiveDictionary<CameraEffectConfigItem>();

	private readonly Dictionary<int, SoundConfigData> _SoundDatas = new Dictionary<int, SoundConfigData>();

	private readonly Dictionary<string, SoundConfigData> _SoundCareerDatas = new Dictionary<string, SoundConfigData>();

	private readonly Dictionary<int, EventParticleData> _eventParticleDatas = new Dictionary<int, EventParticleData>();

	private PlayerVolumeConfig _volumeData;

	private readonly Dictionary<int, List<DragoonStatusEffectData>> _dragoonStatusEffectDatas = new Dictionary<int, List<DragoonStatusEffectData>>();

	private readonly Dictionary<IgnoreCaseString, Dictionary<IgnoreCaseString, AssetInfo>> _particleDatas = new Dictionary<IgnoreCaseString, Dictionary<IgnoreCaseString, AssetInfo>>();

	private readonly Dictionary<Type, Dictionary<IgnoreCaseString, AssetInfo>> _typeParticleDatas = new Dictionary<Type, Dictionary<IgnoreCaseString, AssetInfo>>();

	private ParticleManager()
	{
	}

	public void AddToDict<T>(Dictionary<int, List<T>> dict, int key, object value, string xmlPath, bool isCover) where T : class, IEquatable<T>
	{
		if (dict == null)
		{
			return;
		}
		if (!dict.TryGetValue(key, out var value2))
		{
			dict[key] = new List<T> { (T)value };
			return;
		}
		if (value2.Count > 0 && !isCover)
		{
			value2[0] = (T)value;
			return;
		}
		for (int i = 0; i < value2.Count; i++)
		{
			if (value2[i].Equals(value))
			{
				return;
			}
		}
		value2.Add((T)value);
	}

	public void AddToDict<T>(CaseInSensitiveDictionary<List<T>> dict, string key, object value, string xmlPath) where T : class, IEquatable<T>
	{
		if (dict == null)
		{
			return;
		}
		if (!dict.TryGetValue(key, out var value2))
		{
			dict[key] = new List<T> { (T)value };
			return;
		}
		for (int i = 0; i < value2.Count; i++)
		{
			if (value2[i].Equals(value))
			{
				return;
			}
		}
		this.LogWarnFormat("{0} already exists at {1},{2} will replace it, XmlPath:{3}", value2, key, value, xmlPath);
		value2.Add((T)value);
	}

	public static void InitSceneParticleXmlLoadResults(LoadResults loadResults, string scene)
	{
		if (loadResults.ContainsKey(scene + "_SceneParticleXml") || loadResults.ContainsKey(scene + "_SceneEffectXml"))
		{
			Instance().Parse($"sceneobject/{scene}", loadResults[scene + "_SceneParticleXml"].Object as ParticleXmlAsset, loadResults[scene + "_SceneEffectXml"].Object as EffectXmlAsset, $"Assets/Res/Assets/sceneObject/{scene}/effect");
		}
	}

	public static void InitAccessoryParticleXmlLoadResults(LoadResults loadResults, string accessoryName)
	{
		AccessoryCache.AccessoryPath accessory = AccessoryCache.GetAccessory(accessoryName);
		if (loadResults.ContainsKey(accessory.ParticleXmlRequest) || loadResults.ContainsKey(accessory.EffectXmlRequest))
		{
			Instance().Parse(accessory.BundlePath, loadResults[accessory.ParticleXmlRequest].Object as ParticleXmlAsset, loadResults[accessory.EffectXmlRequest].Object as EffectXmlAsset, accessory.EffectDirPath);
		}
	}

	public static void InitSkillParticleXmlLoadResults(LoadResults loadResults, string skill)
	{
		if (loadResults.ContainsKey(skill + "_SkillParticleXml") || loadResults.ContainsKey(skill + "_SkillEffectXml"))
		{
			Instance().Parse($"skill/{skill}", loadResults[skill + "_SkillParticleXml"].Object as ParticleXmlAsset, loadResults[skill + "_SkillEffectXml"].Object as EffectXmlAsset, $"Assets/Res/Assets/skill/{skill}/effect");
		}
		if (loadResults.ContainsKey(skill + "_SkillSoundXml"))
		{
			new SounfConfigXmlAsset().ParseXmlImmediatory((loadResults[skill + "_SkillSoundXml"].Object as TextAsset).ToString());
		}
	}

	public static void InitWeaponParticleXmlLoadResults(LoadResults loadResults, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo skinInfo)
	{
		if (loadResults != null)
		{
			if (weaponInfo != null && (loadResults.ContainsKey("WeaponParticleXml") || loadResults.ContainsKey("WeaponEffectXml")))
			{
				Instance().Parse(weaponInfo.AssetBundleName, loadResults["WeaponParticleXml"].Object as ParticleXmlAsset, loadResults["WeaponEffectXml"].Object as EffectXmlAsset, weaponInfo.EffectPath);
			}
			if (skinInfo != null && (loadResults.ContainsKey("WeaponSkinParticleXml") || loadResults.ContainsKey("WeaponSkinEffectXml")))
			{
				Instance().Parse(skinInfo.AssetBundleName, loadResults["WeaponSkinParticleXml"].Object as ParticleXmlAsset, loadResults["WeaponSkinEffectXml"].Object as EffectXmlAsset, skinInfo.GetEffectPath(weaponInfo.Name));
			}
			if (weaponInfo != null && loadResults.ContainsKey("WeaponEventParticleXML"))
			{
				Instance().ParseEventParticle((loadResults["WeaponEventParticleXML"].Object as TextAsset).ToString());
			}
		}
	}

	public static void InitPlayerParticleXmlLoadResults(LoadResults loadResults, ICareerInfo careerInfo, PlayerSkinInfo playerSkin)
	{
		if (loadResults.ContainsKey("PlayerParticleXml") || loadResults.ContainsKey("PlayerEffectXml"))
		{
			Instance().Parse(careerInfo.PrefabBundleName, loadResults["PlayerParticleXml"].Object as ParticleXmlAsset, loadResults["PlayerEffectXml"].Object as EffectXmlAsset, careerInfo.EffectPath);
		}
		if (loadResults.ContainsKey("PlayerSkinEffectXml") && loadResults.ContainsKey("PlayerSkinParticleXml"))
		{
			Instance().Parse(playerSkin.PrefabBundleName, loadResults["PlayerSkinParticleXml"].Object as ParticleXmlAsset, loadResults["PlayerSkinEffectXml"].Object as EffectXmlAsset, playerSkin.EffectPath);
		}
	}

	public static void InitNpcParticleXmlLoadResults(LoadResults loadResults, string career)
	{
		if (loadResults.ContainsKey("NpcParticleXml") || loadResults.ContainsKey("NpcEffectXml"))
		{
			Instance().Parse("npc/" + career, loadResults["NpcParticleXml"].Object as ParticleXmlAsset, loadResults["NpcEffectXml"].Object as EffectXmlAsset, $"Assets/Res/Assets/npc/{career}/effect");
		}
	}

	public static void InitSceneParticleXmlLoadRequests(LoadRequests loadRequests, string scene)
	{
		loadRequests.AddAsset(scene + "_SceneParticleXml", new AssetInfo($"sceneobject/{scene}", $"Assets/Res/Assets/sceneObject/{scene}/effect/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true));
		loadRequests.AddAsset(scene + "_SceneEffectXml", new AssetInfo($"sceneobject/{scene}", $"Assets/Res/Assets/sceneObject/{scene}/effect/effectConfig.xml", typeof(EffectXmlAsset), optional: true));
	}

	public static void InitAccessoryParticleXmlLoadRequests(LoadRequests loadRequests, string accessoryName)
	{
		AccessoryCache.AccessoryPath accessory = AccessoryCache.GetAccessory(accessoryName);
		loadRequests.AddAsset(accessory.ParticleXmlRequest, new AssetInfo(accessory.BundlePath, accessory.ParticleXmlPath, typeof(ParticleXmlAsset), optional: true));
		loadRequests.AddAsset(accessory.EffectXmlRequest, new AssetInfo(accessory.BundlePath, accessory.EffectXmlPath, typeof(EffectXmlAsset), optional: true));
	}

	public static void InitSkillParticleXmlLoadRequests(LoadRequests loadRequests, string skill)
	{
		loadRequests.AddAsset(skill + "_SkillParticleXml", new AssetInfo($"skill/{skill}", $"Assets/Res/Assets/skill/{skill}/effect/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true));
		loadRequests.AddAsset(skill + "_SkillEffectXml", new AssetInfo($"skill/{skill}", $"Assets/Res/Assets/skill/{skill}/effect/effectConfig.xml", typeof(EffectXmlAsset), optional: true));
		loadRequests.AddAsset(skill + "_SkillSoundXml", new AssetInfo($"skill/{skill}", $"Assets/Res/Assets/skill/{skill}/effect/soundconfig.xml", typeof(TextAsset), optional: true));
	}

	public static void InitWeaponParticleXmlLoadRequests(LoadRequests loadRequests, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo weaponSkinInfo)
	{
		loadRequests.AddAsset("WeaponParticleXml", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ParticleXmlAssetName, typeof(ParticleXmlAsset), optional: true));
		loadRequests.AddAsset("WeaponEffectXml", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.EffectXmlAssetName, typeof(EffectXmlAsset), optional: true));
		loadRequests.AddAsset("WeaponSoundXml", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.SoundXmlAssetName, typeof(SounfConfigXmlAsset), optional: true));
		loadRequests.AddAsset("WeaponEventParticleXML", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.EventParticleXmlAssetName, typeof(TextAsset), optional: true));
		if (weaponSkinInfo != null && weaponSkinInfo.HasParticleLogic)
		{
			loadRequests.AddAsset("WeaponLogicXml", weaponSkinInfo.GetParticleLogicAssetInfo(weaponInfo.Name));
		}
		else
		{
			loadRequests.AddAsset("WeaponLogicXml", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.LogicXmlAssetName, typeof(ParticleEditorLogicAsset), optional: true));
		}
		if (weaponSkinInfo != null && weaponSkinInfo.HasEffectConfig)
		{
			AssetInfo particleEffectAssetInfo = weaponSkinInfo.GetParticleEffectAssetInfo(weaponInfo.Name);
			if (!particleEffectAssetInfo.Equals(AssetInfo.None))
			{
				loadRequests.AddAsset("WeaponSkinParticleXml", particleEffectAssetInfo);
			}
			AssetInfo effectConfigAssetInfo = weaponSkinInfo.GetEffectConfigAssetInfo(weaponInfo.Name);
			if (!effectConfigAssetInfo.Equals(AssetInfo.None))
			{
				loadRequests.AddAsset("WeaponSkinEffectXml", effectConfigAssetInfo);
			}
		}
	}

	public static void InitPlayerParticleXmlLoadRequests(LoadRequests loadRequests, ICareerInfo career, PlayerSkinInfo skinInfo)
	{
		loadRequests.AddAsset("PlayerParticleXml", new AssetInfo(career.PrefabBundleName, career.ParticleXmlAssetName, typeof(ParticleXmlAsset), optional: true));
		loadRequests.AddAsset("PlayerEffectXml", new AssetInfo(career.PrefabBundleName, career.EffectXmlAssetName, typeof(EffectXmlAsset), optional: true));
		loadRequests.AddAsset("PlayerSoundXml", new AssetInfo(career.PrefabBundleName, career.SoundEffectXmlAssetName, typeof(SounfConfigXmlAsset), optional: true));
		if (skinInfo != null)
		{
			loadRequests.AddAsset("PlayerSkinEffectXml", skinInfo.EffectConfigAsset);
			loadRequests.AddAsset("PlayerSkinParticleXml", skinInfo.ParticleEffectAsset);
		}
	}

	public static void InitNpcParticleXmlLoadRequests(LoadRequests loadRequests, string career)
	{
		loadRequests.AddAsset("NpcParticleXml", new AssetInfo("npc/" + career, "particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true));
		loadRequests.AddAsset("NpcEffectXml", new AssetInfo("npc/" + career, "effectConfig.xml", typeof(EffectXmlAsset), optional: true));
	}

	public static ParticleManager Instance()
	{
		if (_instance == null)
		{
			_instance = new ParticleManager();
		}
		return _instance;
	}

	private T GetEntityData<T>(List<T> list) where T : BaseEffectData
	{
		if (list == null || list.Count == 0)
		{
			return null;
		}
		return list[list.Count - 1];
	}

	public bool TryGetSound(int id, out SoundConfigData data)
	{
		return _SoundDatas.TryGetValue(id, out data);
	}

	public bool TryGetSound(int id, string career, out SoundConfigData data)
	{
		string key = career + "_" + id;
		return _SoundCareerDatas.TryGetValue(key, out data);
	}

	public void AddSoundData(SoundConfigData data)
	{
		SoundConfigData value;
		if (data.hasCareer())
		{
			string key = data.career + "_" + data.EventId;
			if (!_SoundCareerDatas.TryGetValue(key, out value))
			{
				_SoundCareerDatas[key] = data;
			}
		}
		else if (!_SoundDatas.TryGetValue(data.EventId, out value))
		{
			_SoundDatas[data.EventId] = data;
		}
	}

	public EventEffectData GetEventEntityData(int eventId)
	{
		if (eventId == 0)
		{
			return null;
		}
		string key = StringCache.IntToString(eventId);
		if (_eventEffectDatas.TryGetValue(key, out var value))
		{
			return value[value.Count - 1];
		}
		return null;
	}

	public LineLinkEffectData GetLineLinkEffectData(string entityName, bool isHasWeaponSkin)
	{
		if (_lineLinkEffectDatas.TryGetValue(entityName, out var value))
		{
			if (value == null || value.Count == 0)
			{
				return null;
			}
			LineLinkEffectData result = value[0];
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].WeaponSkin == 1 && isHasWeaponSkin)
				{
					result = value[i];
					break;
				}
				if (value[i].WeaponSkin == 0 && !isHasWeaponSkin)
				{
					result = value[i];
					break;
				}
			}
			return result;
		}
		return null;
	}

	public LineLinkStartEffectData GetLineLinkStartEffectData(int entityName, bool isHasWeaponSkin)
	{
		if (_lineLinkStartEffectDatas.TryGetValue(entityName, out var value))
		{
			if (value == null || value.Count == 0)
			{
				return null;
			}
			LineLinkStartEffectData result = value[0];
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].WeaponSkin == 1 && isHasWeaponSkin)
				{
					result = value[i];
					break;
				}
				if (value[i].WeaponSkin == 0 && !isHasWeaponSkin)
				{
					result = value[i];
					break;
				}
			}
			return result;
		}
		return null;
	}

	public LineLinkFinishEffectData GetLineLinkFinishEffectData(int entityName, bool isHasWeaponSkin)
	{
		if (_lineLinkFinishEffectDatas.TryGetValue(entityName, out var value))
		{
			if (value == null || value.Count == 0)
			{
				return null;
			}
			LineLinkFinishEffectData result = value[0];
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i].WeaponSkin == 1 && isHasWeaponSkin)
				{
					result = value[i];
					break;
				}
				if (value[i].WeaponSkin == 0 && !isHasWeaponSkin)
				{
					result = value[i];
					break;
				}
			}
			return result;
		}
		return null;
	}

	public MoveEntityEffectData GetMoveEntityEffectData(string entityName)
	{
		if (_moveEntityEffectDatas.TryGetValue(entityName, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public TailEffectData GetTailEffectData(string entityName)
	{
		if (_tailEffectDatas.TryGetValue(entityName, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public PlayerTitleEffectData GetTitleEffectData(int entityName)
	{
		if (_playerTitleEffectDatas.TryGetValue(entityName, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public PlayerAnimEffectData GetPlayerAnimEffectData(string playerCareer, int legsAnim)
	{
		SimpleParams simpleParams = SimpleParams.Create(playerCareer, legsAnim);
		if (!AnimationNameCache.TryGet(simpleParams, out var cachedata))
		{
			cachedata = $"{playerCareer}_{legsAnim}";
			AnimationNameCache.Add(simpleParams, cachedata);
		}
		else
		{
			simpleParams.Release();
		}
		if (_playerAnimEffectDatas.TryGetValue(cachedata, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public PlayerInfoParticleLoopEffectData GetPlayerInfoParticleLoopEffectData(int playerStatus)
	{
		if (_playerInfoParticleEffectDatas.TryGetValue(playerStatus, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public PlayerInfoAttackEffectData GetPlayerAttackInfoEffectData(int playerStatus)
	{
		if (_playerInfoAttackEffectDatas.TryGetValue(playerStatus, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public PlayerInfoEffectData GetPlayerInfoEffectData(string playerStatus)
	{
		if (_playerInfoEffectDatas.TryGetValue(playerStatus, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public SceneBuffEffectData GetSceneBuffEffectData(string entityName)
	{
		if (_sceneBuffEffectDatas.TryGetValue(entityName, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public AttachEventEffectData GetAttachBodyEffectData(string entityName)
	{
		if (_showBodyEffectDatas.TryGetValue(entityName, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public DragoonStatusEffectData GetDragoonStatusEffectData(int entityName)
	{
		if (_dragoonStatusEffectDatas.TryGetValue(entityName, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public static List<BaseEffectData> ParseParticleXml(string xmlText)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlText);
		XmlNode documentElement = xmlDocument.DocumentElement;
		List<BaseEffectData> list = new List<BaseEffectData>();
		if (documentElement != null)
		{
			foreach (XmlNode item in documentElement)
			{
				switch (item.Name)
				{
				case "lineLinkEffect":
					list.Add(new LineLinkEffectData().Parse(item));
					break;
				case "lineLinkStartEffect":
					list.Add(new LineLinkStartEffectData().Parse(item));
					break;
				case "lineLinkFinishEffect":
					list.Add(new LineLinkFinishEffectData().Parse(item));
					break;
				case "playerStateEffect":
					list.Add(new PlayerInfoEffectData().Parse(item));
					break;
				case "playerStatusEffect":
				{
					BaseEffectData baseEffectData = new PlayerInfoEffectData().Parse(item);
					if (baseEffectData != null)
					{
						list.Add(baseEffectData);
					}
					break;
				}
				case "playerTitleEffect":
					list.Add(new PlayerTitleEffectData().Parse(item));
					break;
				case "entityHangEffect":
					list.Add(new EntityHangEffectData().Parse(item));
					break;
				case "playerAnimEffect":
					list.Add(new PlayerAnimEffectData().Parse(item));
					break;
				case "moveEntityEffect":
					list.Add(new MoveEntityEffectData().Parse(item));
					break;
				case "sceneBuffEffect":
					list.Add(new SceneBuffEffectData().Parse(item));
					break;
				case "eventEffect":
					list.Add(new EventEffectData().Parse(item));
					break;
				case "attachEventEffect":
					list.Add(new AttachEventEffectData().Parse(item));
					break;
				case "dragoonStatusEffect":
					list.Add(new DragoonStatusEffectData().Parse(item));
					break;
				case "tailEffect":
					list.Add(new TailEffectData().Parse(item));
					break;
				case "LoopParticleEffect":
					list.Add(new PlayerInfoParticleLoopEffectData().Parse(item));
					break;
				case "playerStatusAttackEffect":
					list.Add(new PlayerInfoAttackEffectData().Parse(item));
					break;
				case "careerSkinEffect":
					list.Add(new CareerEffectData().Parse(item));
					break;
				}
			}
		}
		return list;
	}

	public void AddVolumeConfig(PlayerVolumeConfig config)
	{
		_volumeData = config;
	}

	public bool GetVolumeConfigData(string key, out PlayerVolumeConfig.ConfigData data)
	{
		if (_volumeData == null)
		{
			data = default(PlayerVolumeConfig.ConfigData);
			return false;
		}
		return _volumeData.TryGet(key, out data);
	}

	public void AddCameraEffect(CameraEffectConfigItem config)
	{
		_cameraEffectDatas[config.EffectName] = config;
	}

	public CameraEffectConfigItem GetCameraEffectData(string effectName)
	{
		if (_cameraEffectDatas.TryGetValue(effectName, out var value))
		{
			return value;
		}
		return null;
	}

	public MoveEntityEffectData GetMoveEffectData(string effectName)
	{
		if (_moveEntityEffectDatas.TryGetValue(effectName, out var value))
		{
			return GetEntityData(value);
		}
		return null;
	}

	public List<EntityHangEffectData> GetHangEffectData(string effectName)
	{
		if (_entityHangEffectDatas.TryGetValue(effectName, out var value))
		{
			return value;
		}
		return null;
	}

	public EventParticleData GetEventParticleData(int eventId)
	{
		if (_eventParticleDatas.TryGetValue(eventId, out var value))
		{
			return value;
		}
		return null;
	}

	private void ParseEventParticle(string xmlText)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlText);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement == null)
		{
			return;
		}
		foreach (XmlNode item in documentElement)
		{
			EventParticleData eventParticleData = new EventParticleData();
			eventParticleData.Parse(item);
			if (!_eventParticleDatas.ContainsKey(eventParticleData.EventType))
			{
				_eventParticleDatas[eventParticleData.EventType] = eventParticleData;
			}
		}
	}

	public static Dictionary<string, EffectConfig> ParseEffectXml(string xmlText)
	{
		Dictionary<string, EffectConfig> dictionary = new Dictionary<string, EffectConfig>();
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlText);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			foreach (XmlNode item in documentElement)
			{
				if ("EffectParticle".Equals(item.Name))
				{
					EffectConfig effectConfig = new EffectConfig();
					effectConfig.Parse(item);
					if (!dictionary.ContainsKey(effectConfig.EffectName))
					{
						dictionary.Add(effectConfig.EffectName, effectConfig);
					}
				}
			}
		}
		return dictionary;
	}

	public static SceneObjectEffectConfig ParseSceneObjectEffectXml(string xmlText)
	{
		XmlDocument xmlDocument = new XmlDocument();
		xmlDocument.LoadXml(xmlText);
		XmlNode documentElement = xmlDocument.DocumentElement;
		if (documentElement != null)
		{
			foreach (XmlNode item in documentElement)
			{
				if ("baseparticleeffect".Equals(item.Name))
				{
					SceneObjectEffectConfig sceneObjectEffectConfig = new SceneObjectEffectConfig();
					sceneObjectEffectConfig.Parse(item.FirstChild);
					return sceneObjectEffectConfig;
				}
			}
		}
		return null;
	}

	private static string GetEffectRealUrl(string effectPath)
	{
		string text = effectPath.Replace(".uf3d", "");
		int num = text.LastIndexOf("/", StringComparison.Ordinal);
		string text2 = text;
		if (num >= 0)
		{
			text2 = text.Substring(num + 1);
		}
		if (text.StartsWith("/"))
		{
			text = text.Substring(1);
		}
		if (text.StartsWith("effect/"))
		{
			text = text.Substring(7);
		}
		return "/" + text + "/Prefab/" + text2 + ".prefab";
	}

	public void Parse(string assertBundle, ParticleXmlAsset particleXml, EffectXmlAsset effectXml, string xmlPath)
	{
		Parse(assertBundle, particleXml, effectXml, xmlPath, xmlPath);
	}

	public void ParseEffect(string assertBundle, ParticleXmlAsset particleXml, EffectXmlAsset effectXml, string xmlPath, bool preLoadRes)
	{
		Parse(assertBundle, particleXml, effectXml, xmlPath, "Assets/Res/Assets/effect", preLoadRes);
	}

	public void ParsePreloadingEffect(string assertBundle, ParticleXmlAsset particleXml, EffectXmlAsset effectXml, string xmlPath, bool preLoadRes)
	{
		Parse(assertBundle, particleXml, effectXml, xmlPath, xmlPath, preLoadRes);
	}

	private void AddPartileInfo(string key, ref AssetInfo assetInfo)
	{
		if (!string.IsNullOrEmpty(assetInfo.AssetName) && !string.IsNullOrEmpty(assetInfo.BundleName))
		{
			IgnoreCaseString key2 = new IgnoreCaseString(key);
			IgnoreCaseString key3 = new IgnoreCaseString(assetInfo.BundleName);
			if (_particleDatas.TryGetValue(key2, out var value))
			{
				value[key2] = assetInfo;
				return;
			}
			value = new Dictionary<IgnoreCaseString, AssetInfo>();
			value.Add(key2, assetInfo);
			_particleDatas[key3] = value;
		}
	}

	private void AddPartileInfo(Type type, string key, ref AssetInfo assetInfo)
	{
		if (!string.IsNullOrEmpty(assetInfo.AssetName) && !string.IsNullOrEmpty(assetInfo.BundleName))
		{
			IgnoreCaseString key2 = new IgnoreCaseString(key);
			if (_typeParticleDatas.TryGetValue(type, out var value))
			{
				value[key2] = assetInfo;
				return;
			}
			value = new Dictionary<IgnoreCaseString, AssetInfo>();
			value.Add(key2, assetInfo);
			_typeParticleDatas[type] = value;
		}
	}

	private void AddPartileInfo<T>(string key, ref AssetInfo assetInfo)
	{
		Type typeFromHandle = typeof(T);
		AddPartileInfo(typeFromHandle, key, ref assetInfo);
	}

	public bool TryGetParticle(string assetbundle, string key, out AssetInfo result)
	{
		IgnoreCaseString key2 = new IgnoreCaseString(assetbundle);
		if (_particleDatas.TryGetValue(key2, out var value))
		{
			return value.TryGetValue(new IgnoreCaseString(key), out result);
		}
		result = default(AssetInfo);
		return false;
	}

	public bool TryGetParticle(Type type, string key, out AssetInfo result)
	{
		if (_typeParticleDatas.TryGetValue(type, out var value))
		{
			return value.TryGetValue(new IgnoreCaseString(key), out result);
		}
		result = default(AssetInfo);
		return false;
	}

	public bool TryGetParticle<T>(string key, out AssetInfo result)
	{
		return TryGetParticle(typeof(T), key, out result);
	}

	public AssetInfo TryGetSoundAsset(int eventId)
	{
		if (_SoundDatas.TryGetValue(eventId, out var value))
		{
			return value.AssetInfo;
		}
		return default(AssetInfo);
	}

	private void Parse(string assertBundle, ParticleXmlAsset particleXml, EffectXmlAsset effectXml, string xmlPath, string particleBasePath, bool preLoadRes = false)
	{
		if (effectXml != null)
		{
			foreach (KeyValuePair<string, EffectConfig> item in effectXml.Dict)
			{
				EffectConfig value = item.Value;
				AssetInfo assetInfo = new AssetInfo(assertBundle, particleBasePath + GetEffectRealUrl(value.EffectPath));
				AddPartileInfo<EffectConfig>(value.EffectName, ref assetInfo);
			}
		}
		if (particleXml == null)
		{
			return;
		}
		List<BaseEffectData> list = particleXml.List;
		if (list != null)
		{
			foreach (BaseEffectData item2 in list)
			{
				if (TryGetParticle<EffectConfig>(item2.EffectName, out var result))
				{
					item2.ParticleAssetInfo.BundleName = (item2.AssetInfo.BundleName = new IgnoreCaseString(assertBundle));
					string key = item2.Key;
					item2.AssetInfo.AssetName = new IgnoreCaseString(xmlPath + "/particle/" + item2.GetName() + ".prefab");
					item2.ParticleAssetInfo = result;
					if (preLoadRes)
					{
						SingletonInstance<AssetPool>.Instance.LoadAndAdd(new AssetInfo(item2.AssetInfo.BundleName, item2.AssetInfo.AssetName), BaseAsyncManager.Instance);
					}
					if (item2 is EntityHangEffectData)
					{
						AddToDict(_entityHangEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is MoveEntityEffectData)
					{
						AddToDict(_moveEntityEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is TailEffectData)
					{
						AddToDict(_tailEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is EventEffectData)
					{
						AddToDict(_eventEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is LineLinkEffectData)
					{
						AddToDict(_lineLinkEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is PlayerTitleEffectData)
					{
						AddToDict(_playerTitleEffectDatas, ((PlayerTitleEffectData)item2).TitleId, item2, xmlPath, isCover: true);
					}
					else if (item2 is LineLinkStartEffectData)
					{
						object obj = Enum.Parse(typeof(LinkEntityType), key, ignoreCase: true);
						if (obj != null)
						{
							LinkEntityType key2 = (LinkEntityType)obj;
							AddToDict(_lineLinkStartEffectDatas, (int)key2, item2, xmlPath, isCover: true);
						}
						else
						{
							DebugLogger.LogErrorFormat("{0} error", key);
						}
					}
					else if (item2 is LineLinkFinishEffectData)
					{
						object obj2 = Enum.Parse(typeof(LinkEntityType), key, ignoreCase: true);
						if (obj2 != null)
						{
							LinkEntityType key3 = (LinkEntityType)obj2;
							AddToDict(_lineLinkFinishEffectDatas, (int)key3, item2, xmlPath, isCover: true);
						}
						else
						{
							DebugLogger.LogErrorFormat("{0} error", key);
						}
					}
					else if (item2 is PlayerAnimEffectData)
					{
						AddToDict(_playerAnimEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is PlayerInfoEffectData)
					{
						AddToDict(_playerInfoEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is PlayerInfoAttackEffectData)
					{
						AddToDict(_playerInfoAttackEffectDatas, int.Parse(key), item2, xmlPath, isCover: true);
					}
					else if (item2 is SceneBuffEffectData)
					{
						AddToDict(_sceneBuffEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is AttachEventEffectData)
					{
						AddToDict(_showBodyEffectDatas, key, item2, xmlPath);
					}
					else if (item2 is DragoonStatusEffectData)
					{
						AddToDict(_dragoonStatusEffectDatas, int.Parse(key), item2, xmlPath, isCover: false);
					}
				}
				else if (item2 is PlayerInfoParticleLoopEffectData)
				{
					string key4 = item2.Key;
					AddToDict(_playerInfoParticleEffectDatas, int.Parse(key4), item2, xmlPath, isCover: true);
				}
				else
				{
					DebugLogger.LogFormat("config dont contains {0} !!!!!!", item2.EffectName);
				}
			}
		}
		else
		{
			this.LogError("particles list is Null");
		}
		LocalEntityEffectTable table = LocalEntityEffectLoader.Instance.Table;
		if (table == null)
		{
			return;
		}
		foreach (LocalEntityEffectTable.Row row in table.GetRowList())
		{
			string text = StringCache.IntToString(row.EventId);
			if (!_eventEffectDatas.ContainsKey(text))
			{
				_eventEffectDatas[text] = new List<EventEffectData>
				{
					new EventEffectData
					{
						EffectTime = ((row.LifeTime == -1) ? int.MaxValue : row.LifeTime),
						AssetInfo = (string.IsNullOrEmpty(row.Weapon) ? new AssetInfo("localentityeffectprefab/" + row.Prefab, row.Prefab, typeof(GameObject)) : new AssetInfo("weapon/" + row.Weapon, string.Format("Assets/Res/Assets/weapon/{0}/effect/{1}/Prefab/{1}.prefab", row.Weapon, row.Prefab))),
						EffectName = "LEEffect" + row.EventId
					}
				};
			}
		}
	}
}
