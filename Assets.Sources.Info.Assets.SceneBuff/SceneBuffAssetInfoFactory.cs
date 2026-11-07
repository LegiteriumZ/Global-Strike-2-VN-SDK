using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using I2.Loc;
using SSJJAsset.Asset;
using SSJJBase.Logger;

namespace Assets.Sources.Info.Assets.SceneBuff;

public class SceneBuffAssetInfoFactory
{
	private static SceneBuffAssetInfoFactory _instance;

	private Dictionary<string, ISceneBuffAssetInfo> _assetInfos = new Dictionary<string, ISceneBuffAssetInfo>();

	public static SceneBuffAssetInfoFactory Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = new SceneBuffAssetInfoFactory();
				_instance.Init();
			}
			return _instance;
		}
	}

	private void Init()
	{
		_assetInfos.Add("ammunition", new AmmunitionAssetInfo("ammunition"));
		_assetInfos.Add("virusy", new VirusyAssetInfo("virusy"));
		_assetInfos.Add("stronghold", new StrongHoldAssetInfo("weapon"));
		_assetInfos.Add("breakpoint", new BreakPointAssetInfo("breakpoint"));
		_assetInfos.Add("buy_skill", new BuySkillAssetInfo("buy_skill"));
		_assetInfos.Add("kongzhiqi", new KongzhiqiBufferAssetInfo("kongzhiqi"));
		_assetInfos.Add("kriss_heal", new KrissHealBufferAssetInfo("kriss_heal"));
		_assetInfos.Add("energydevice", new EnergyDeviceAssetInfo("energydevice"));
		_assetInfos.Add("ENERGY_PREPARE", new EnergyPrepareAssetInfo("ENERGY_PREPARE"));
		_assetInfos.Add("ENERGY_READY", new EnergyPrepareAssetInfo("ENERGY_READY"));
		_assetInfos.Add("SAFE_AREA", new SafeAreaAssetInfo("SAFE_AREA"));
		_assetInfos.Add("CYBER_ESCAPE_AREA", new ExtractionSceneBuffAssrtInfo(ScriptLocalization.Get("Extraction")));
		_assetInfos.Add("PVE_ICE_GRENADE_EXPLOSION_QUYU", new DefaultSceneBuffAssetInfo("PVE_ICE_GRENADE_EXPLOSION_QUYU", AssetInfo.None));
		_assetInfos.Add("jump_start", new DefaultSceneBuffAssetInfo("jump_start", AssetInfo.None));
		_assetInfos.Add("jump_stop", new DefaultSceneBuffAssetInfo("jump_stop", AssetInfo.None));
		_assetInfos.Add("acceleratebuf", new DefaultSceneBuffAssetInfo("acceleratebuf", AssetInfo.None));
	}

	public bool IsImplementedByCode(string name)
	{
		return _assetInfos.ContainsKey(name);
	}

	public ISceneBuffAssetInfo Get(string name)
	{
		if (name != "CYBER_ESCAPE_AREA")
		{
			SceneBuffEffectData sceneBuffEffectData = ParticleManager.Instance().GetSceneBuffEffectData(name);
			if (sceneBuffEffectData != null)
			{
				return new DefaultSceneBuffAssetInfo(sceneBuffEffectData.EffectName, new AssetInfo(null, null));
			}
		}
		if (!_assetInfos.ContainsKey(name))
		{
			BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
			if (battleRoom != null && battleRoom.hasRoomData)
			{
				if (RuleUtilty.IsNeedSkillSmallIcon(battleRoom.roomData.Data.RaceType))
				{
					return new SkillBufferAssetInfo(name);
				}
				if (battleRoom.roomData.Data.RaceType == 1002)
				{
					return new EnergyDeviceAssetInfo(name);
				}
			}
			this.InfoFormat("ISceneBuffAssetInfo {0} not implemented", name);
			return new WeaponAssetInfo(name);
		}
		return _assetInfos[name];
	}
}
