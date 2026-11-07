using System.Collections.Generic;
using Assets.Sources.Constant;
using SSJJAsset.Asset;
using SSJJBase.Cache;
using SSJJBase.Manager;
using SSJJBase.String;
using Sharpen;

namespace Assets.Sources.Info.Res;

internal class ResConfigFactory : BattleSingletonInstance<ResConfigFactory>
{
	private readonly Dictionary<int, List<ExplosionConfig>> _explosionConfigs = new Dictionary<int, List<ExplosionConfig>>();

	private readonly Dictionary<int, ExplosionEffectConfig> _explosionEffectConfigs = new Dictionary<int, ExplosionEffectConfig>();

	private readonly List<HitResConfig> _hitConstantResConfigs = new AList<HitResConfig>();

	private readonly List<BloodResConfig> _bloodConstantResConfigs = new AList<BloodResConfig>();

	private readonly ObjectCache<int, HitResConfig> _hitResConfigs = new ObjectCache<int, HitResConfig>(new HitResDefaultCreate());

	private readonly ObjectCache<int, BloodResConfig> _bloodResConfigs = new ObjectCache<int, BloodResConfig>(new BloodResDefaultCreate());

	private readonly ObjectCache<IgnoreCaseString, MoveEntityConfig> _moveEntityResConfigs = new ObjectCache<IgnoreCaseString, MoveEntityConfig>(null);

	private readonly ObjectCache<IgnoreCaseString, MoveEntityTailConfig> _moveEntityTailResConfigs = new ObjectCache<IgnoreCaseString, MoveEntityTailConfig>(null);

	private readonly ObjectCache<int, HoleResConfig> _holeResConfigs = new ObjectCache<int, HoleResConfig>(new HoleResDefaultCreate());

	private readonly ObjectCache<int, RailResConfig> _railResConfigs = new ObjectCache<int, RailResConfig>(new RailResDefaultCreate());

	private readonly Dictionary<string, CommonParticleResConfig> _defaultParticleResConfigs = new Dictionary<string, CommonParticleResConfig>();

	private readonly AssetInfo _defalutGrenadeTailInfo;

	public override void Clear()
	{
		_moveEntityTailResConfigs.Clear();
		_bloodResConfigs.Clear();
		_hitResConfigs.Clear();
		_bloodConstantResConfigs.Clear();
		_hitConstantResConfigs.Clear();
		_explosionEffectConfigs.Clear();
		_explosionConfigs.Clear();
		_holeResConfigs.Clear();
		_railResConfigs.Clear();
	}

	public ResConfigFactory()
	{
		_hitConstantResConfigs.Add(new HitResConfig("effect/common", "Assets/Res/Assets/effect/common/particle/event_95.prefab", 1, -1, 1100));
		_hitConstantResConfigs.Add(new HitResConfig("effect/common", "Assets/Res/Assets/effect/common/particle/event_96.prefab", 2, -1, 1100));
		_hitConstantResConfigs.Add(new HitResConfig("effect/common", "Assets/Res/Assets/effect/common/particle/event_97.prefab", 0, -1, 1100));
		_hitConstantResConfigs.Add(new HitResConfig("effect/rpgcommon", "Assets/Res/Assets/effect/rpgcommon/particle/event_98.prefab", 3, -3, 1100));
		_hitConstantResConfigs.Add(new HitResConfig("effect/pvecommon", "Assets/Res/Assets/effect/pvecommon/particle/event_98.prefab", 3, -2, 1100));
		_hitConstantResConfigs.Add(new HitResConfig("effect/biomode", "Assets/Res/Assets/effect/bioMode/particle/event_98.prefab", 3, -4, 1100));
		_hitConstantResConfigs.Add(new HitResConfig("effect/common", "Assets/Res/Assets/effect/common/hitmetal/Prefab/hitmetal.prefab", 100, -1, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/herohitheroblood_-3/herohitheroblood.prefab", 4, -3, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/herohitheroblood_6/herohitheroblood.prefab", 4, 6, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/herohitheroblood_19/herohitheroblood.prefab", 4, 19, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/herohitheroblood_24/herohitheroblood.prefab", 4, 24, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/herohitheroblood_29/herohitheroblood.prefab", 4, 29, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/herohitheroblood_2019/herohitheroblood.prefab", 4, 2019, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/voiddeviceblood_1003/voiddeviceblood.prefab", 5, 1003, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effectprefab/hit", "Assets/Res/Assets/effectPrefab/hit/herohitheroblood_19/herohitheroblood.prefab", 4, 100, 500));
		_hitConstantResConfigs.Add(new HitResConfig("effect/mechwarrior2mode", "Assets/Res/Assets/effect/mechWarrior2Mode/particle/event_138.prefab", 6, 100, 1100));
		_bloodConstantResConfigs.Add(new BloodResConfig("effectprefab/wallblood", "Assets/Res/Assets/effectprefab/wallblood/bio/blood.prefab", 0, -4));
		_bloodConstantResConfigs.Add(new BloodResConfig("effectprefab/wallblood", "Assets/Res/Assets/effectprefab/wallblood/rpgcommon/blood.prefab", 1, -3));
		_bloodConstantResConfigs.Add(new BloodResConfig("effectprefab/wallblood", "Assets/Res/Assets/effectprefab/wallblood/pvecommon/blood.prefab", 2, -2));
		_bloodConstantResConfigs.Add(new BloodResConfig("effectprefab/wallblood", "Assets/Res/Assets/effectprefab/wallblood/common/blood.prefab", 3, -1));
		_defalutGrenadeTailInfo = new AssetInfo("effectprefab/tail", "Assets/Res/Assets/effectprefab/tail/grenade.prefab");
	}

	public void Add(ExplosionConfig explosionConfig)
	{
		if (!_explosionConfigs.ContainsKey(explosionConfig.EventId))
		{
			_explosionConfigs.Add(explosionConfig.EventId, new AList<ExplosionConfig>());
		}
		_explosionConfigs[explosionConfig.EventId].Add(explosionConfig);
	}

	public AssetInfo GetDefaultGrenadeTailInfo()
	{
		return _defalutGrenadeTailInfo;
	}

	public ExplosionConfig GetExplosionConfig(int eventId, int resId)
	{
		if (!_explosionConfigs.ContainsKey(eventId))
		{
			return null;
		}
		ExplosionConfig explosionConfig = _explosionConfigs[eventId].Find((ExplosionConfig x) => x.ResTypeId == resId);
		if (explosionConfig == null)
		{
			explosionConfig = _explosionConfigs[eventId][0];
		}
		if (explosionConfig != null && explosionConfig.EventId == 69)
		{
			explosionConfig.EffectTime = 3000;
		}
		return explosionConfig;
	}

	public void Add(ExplosionEffectConfig explosionConfig)
	{
		if (!_explosionEffectConfigs.ContainsKey(explosionConfig.EventId))
		{
			_explosionEffectConfigs[explosionConfig.EventId] = explosionConfig;
		}
	}

	public ExplosionEffectConfig GetExplosionEffectConfig(int eventId)
	{
		if (!_explosionEffectConfigs.ContainsKey(eventId))
		{
			return ExplosionEffectConfig.DefaultConfig;
		}
		return _explosionEffectConfigs[eventId];
	}

	public void Add(CommonParticleResConfig config)
	{
		if (!_defaultParticleResConfigs.ContainsKey(config.Key))
		{
			_defaultParticleResConfigs.Add(config.Key, config);
		}
	}

	public CommonParticleResConfig GetDefaultParticleResConfig(string key)
	{
		CommonParticleResConfig value = null;
		if (_defaultParticleResConfigs.TryGetValue(key, out value))
		{
			return value;
		}
		return null;
	}

	public void Add(HoleResConfig item)
	{
		_holeResConfigs.Add(item.ResId, item);
	}

	public HoleResConfig GetHoleResConfig(int resId)
	{
		return _holeResConfigs.GetOrCreate(resId);
	}

	public void Add(RailResConfig item)
	{
		_railResConfigs.Add(item.ResId, item);
	}

	public RailResConfig GetRailResConfig(int resId)
	{
		return _railResConfigs.GetOrCreate(resId);
	}

	public HitResConfig GetHitResConfig(int resId)
	{
		return _hitResConfigs.GetOrCreate(resId);
	}

	public BloodResConfig GetBloodResConfig(int resId)
	{
		return _bloodResConfigs.GetOrCreate(resId);
	}

	public int GetSplashEventId(int type, int color)
	{
		if (type == 0)
		{
			return color switch
			{
				0 => 139, 
				1 => 140, 
				2 => 141, 
				_ => 142, 
			};
		}
		return color switch
		{
			0 => 143, 
			1 => 144, 
			2 => 145, 
			_ => 146, 
		};
	}

	public void Add(MoveEntityConfig config)
	{
		_moveEntityResConfigs.Add(config.Name, config);
	}

	public MoveEntityConfig GetMoveEntityConfig(string name)
	{
		return _moveEntityResConfigs.GetOrNull(name);
	}

	public void Add(MoveEntityTailConfig config)
	{
		_moveEntityTailResConfigs.Add(config.Name, config);
	}

	public MoveEntityTailConfig GetMoveEntityTailConfig(string name)
	{
		return _moveEntityTailResConfigs.GetOrNull(name);
	}

	public void FilterByRuleId(int ruleId)
	{
		RuleUtilty.GetFilterRuleSet(ruleId, out var ruleSet);
		FilterHitRes(ruleSet, _hitConstantResConfigs, _hitResConfigs);
		FilterBloodRes(ruleSet, _bloodConstantResConfigs, _bloodResConfigs);
	}

	private void FilterBloodRes(HashSet<int> ruleSet, List<BloodResConfig> bloodConstantResConfigs, ObjectCache<int, BloodResConfig> bloodResConfigs)
	{
		foreach (BloodResConfig bloodConstantResConfig in bloodConstantResConfigs)
		{
			if (ruleSet.Contains(bloodConstantResConfig.RuleModel) && bloodResConfigs.GetOrNull(bloodConstantResConfig.ResId) == null)
			{
				bloodResConfigs.Add(bloodConstantResConfig.ResId, bloodConstantResConfig);
			}
		}
	}

	private void FilterHitRes(HashSet<int> ruleSet, List<HitResConfig> hitConstantResConfigs, ObjectCache<int, HitResConfig> hitResConfigs)
	{
		foreach (HitResConfig hitConstantResConfig in hitConstantResConfigs)
		{
			if (ruleSet.Contains(hitConstantResConfig.RuleModel) && hitResConfigs.GetOrNull(hitConstantResConfig.ResId) == null)
			{
				hitResConfigs.Add(hitConstantResConfig.ResId, hitConstantResConfig);
			}
		}
	}

	public AssetInfo GetDefaultTail()
	{
		return new AssetInfo("effectprefab/tail", "Assets/Res/Assets/effectprefab/tail/default.prefab");
	}
}
