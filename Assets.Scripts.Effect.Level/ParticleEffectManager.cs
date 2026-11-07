using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Scripts.Effect.Level.EffectLevelCaculate;
using Assets.Sources.Config;
using Assets.Sources.Utils.Effect;
using SSJJBase.Logger;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Scripts.Effect.Level;

public class ParticleEffectManager : MonoBehaviourSingleton<ParticleEffectManager>
{
	private readonly bool _isOpen = true;

	public int OriginParticleLevel = -1;

	public List<ParticlePara> Particles = new List<ParticlePara>();

	private readonly Dictionary<PaticleInstanceType, IEffectLevelCaculate> _caculates = new Dictionary<PaticleInstanceType, IEffectLevelCaculate>();

	private const int NOT_FOUND_SPECIAL_LEVEL = -1;

	private Dictionary<PaticleInstanceType, string> _typeStrCache = new Dictionary<PaticleInstanceType, string>();

	public bool IsOpen => _isOpen;

	public void Init()
	{
		_caculates.Clear();
		_typeStrCache.Clear();
		Particles.Clear();
		_caculates.Add(PaticleInstanceType.scene, new DefaultEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.accessory, new DefaultEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.weapon, new WeaponEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.player, new DefaultEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.playerskin, new DefaultEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.weaponskin, new DefaultEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.effect, new DefaultEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.skill, new DefaultEffectLevelCaculate());
		_caculates.Add(PaticleInstanceType.npc, new DefaultEffectLevelCaculate());
		for (int i = 0; i <= 9; i++)
		{
			Dictionary<PaticleInstanceType, string> typeStrCache = _typeStrCache;
			int key = i;
			PaticleInstanceType paticleInstanceType = (PaticleInstanceType)i;
			typeStrCache.Add((PaticleInstanceType)key, paticleInstanceType.ToString());
		}
		GameSetting.RegisterApplyCallBack(RefreshParticleLevel);
	}

	public void RegisterParticleInstance(PaticlePrefabInstancecs instance, PaticleInstanceType type, string codeName)
	{
		if (!_isOpen || string.IsNullOrEmpty(codeName) || instance == null || instance.instance == null)
		{
			return;
		}
		if (!MonoBehaviourSingleton<ParticleEffectLoader>.Instance.IsSpecailParticle(codeName))
		{
			UpdateParticleShow(instance);
		}
		for (int i = 0; i < Particles.Count; i++)
		{
			if (Particles[i].Instance == instance)
			{
				return;
			}
		}
		if (!_typeStrCache.TryGetValue(type, out var value))
		{
			value = type.ToString();
			_typeStrCache[type] = value;
		}
		ParticlePara particlePara = new ParticlePara();
		Particles.Add(particlePara);
		particlePara.Instance = instance;
		particlePara.InstanceName = instance.instance.name;
		particlePara.Type = type;
		particlePara.CodeName = codeName;
		particlePara.ParticleLevel = SingletonInstance<ParticleEffectVisibleConfig>.Instance.GetLevel(instance.instance.name, codeName, type.ToString());
		instance.SetshowLevel(particlePara.ParticleLevel);
		InstanceParticleCommonSet(instance, GameSetting.Config.EffectParticleLevel, particlePara.ParticleLevel, particlePara.CodeName);
	}

	public void RefreshParticleLevel()
	{
		if (!_isOpen)
		{
			return;
		}
		this.Info("RefreshParticleLevel ... " + GameSetting.Config.EffectParticleLevel);
		for (int i = 0; i < Particles.Count; i++)
		{
			if (Particles[i].Instance != null)
			{
				InstanceParticleCommonSet(Particles[i].Instance, GameSetting.Config.EffectParticleLevel, Particles[i].ParticleLevel, Particles[i].CodeName);
			}
		}
	}

	private void InstanceParticleCommonSet(PaticlePrefabInstancecs instance, int configLevel, int particleLevel, string codeName)
	{
		if (MonoBehaviourSingleton<ParticleEffectLoader>.Instance.IsSpecailParticle(codeName))
		{
			instance.RefreshLevelActive(levelVisiable: true);
		}
		else if (MonoBehaviourSingleton<ParticleEffectLoader>.Instance.IsSpecailParticleName(instance.instance.name))
		{
			instance.RefreshLevelActive(levelVisiable: true);
		}
		else
		{
			instance.RefreshLevelActive(configLevel >= particleLevel);
		}
	}

	public int GetParticleLevel(GameObject particleGameObject, PaticleInstanceType type)
	{
		IEffectLevelCaculate value = null;
		if (_caculates.TryGetValue(type, out value))
		{
			return value.GetEffectLevel(particleGameObject);
		}
		return -1;
	}

	public void Update()
	{
		if (Time.frameCount % 15 != 0 || GameSetting.Config.EffectParticleDistance == 100)
		{
			return;
		}
		for (int i = 0; i < Particles.Count; i++)
		{
			if (Particles[i].Instance != null && !MonoBehaviourSingleton<ParticleEffectLoader>.Instance.IsSpecailParticle(Particles[i].CodeName) && Particles[i].Instance.GetLevelVisiable() && Particles[i].Instance.GetNowVisiable())
			{
				UpdateParticleShow(Particles[i].Instance);
			}
		}
	}

	public void UpdateParticleShow(PaticlePrefabInstancecs paticlePrefabInstancecs)
	{
		if (paticlePrefabInstancecs.GetshowLevel() == 0)
		{
			return;
		}
		GameObject ins = paticlePrefabInstancecs.GetIns();
		if (ins == null)
		{
			return;
		}
		if (!(Vector3.Distance(Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform.position, ins.transform.position) < (float)(GameSetting.Config.EffectParticleDistance * 100)) && !(Vector3.Distance(Vector3.zero, ins.transform.position) < (float)(GameSetting.Config.EffectParticleDistance * 100)))
		{
			paticlePrefabInstancecs.SetshowDistance(isShow: false);
			if (ins.IsActiveSelf())
			{
				ins.SetObjectActive(isactive: false);
			}
		}
		else
		{
			paticlePrefabInstancecs.SetshowDistance(isShow: true);
			if (!ins.IsActiveSelf())
			{
				ins.SetObjectActive(paticlePrefabInstancecs.GetLevelVisiable());
			}
		}
	}
}
