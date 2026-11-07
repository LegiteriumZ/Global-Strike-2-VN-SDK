using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Components.Time;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.ViewEffectLogic;

public abstract class AbstractViewWeaponEffectLogic : IViewWeaponEffectLogic, IWeaponEffectLogic
{
	protected TimeContext _timeContext;

	protected TimeComponent _timeComponent;

	private Dictionary<GameObject, IFireEffectControl> _fireEffects;

	protected Func<PlayerEntity, WeaponEntity, string, string, int> Func;

	private List<IPaticlePrefabInstancecs> _paticlesArrayByParticleName;

	public bool Inited { get; private set; }

	public virtual void Init(PlayerEntity player)
	{
		Inited = true;
		_timeContext = Contexts.sharedInstance.time;
		_timeComponent = _timeContext.time;
	}

	protected void Hide(PlayerEntity player)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (!IsFireEffect(particle.Value))
			{
				particle.Value.SetInsActive(flag: false);
			}
		}
	}

	private bool IsFireEffect(IPaticlePrefabInstancecs ins)
	{
		return (ins as PaticlePrefabInstancecs).transform.GetComponentsInChildren<IFireEffectControl>(includeInactive: true).Length != 0;
	}

	public Dictionary<IParticleKey, IPaticlePrefabInstancecs> GetParticles(PlayerEntity player)
	{
		return player.GetFirstPersonPatricles();
	}

	public Dictionary<IgnoreCaseString, SkinnedMeshRenderer> GetSkins(PlayerEntity player)
	{
		return player.GetFirstPersonSkins();
	}

	public void SetAllParticleVisiable(PlayerEntity player, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			particle.Value.SetInsActive(flag);
		}
	}

	protected void SetSkinVisible(Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins, IgnoreCaseString key, bool flag)
	{
		if (skins != null && skins.TryGetValue(key, out var value))
		{
			value.enabled = flag;
		}
	}

	public void SetParticleActiveBySkinName(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.JointName.Equals(name))
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	public void DestoryParticleFireControlByParticleName(PlayerEntity player, string name)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals(name))
			{
				particle.Value.GetIns().GetComponent<IFireEffectControl>().SetNoUse();
			}
		}
	}

	public void SetParticleNoFireControlByParticleName(PlayerEntity player, string name)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (!particle.Key.PatricleName.Equals(name))
			{
				continue;
			}
			if (_fireEffects == null)
			{
				_fireEffects = new Dictionary<GameObject, IFireEffectControl>();
			}
			IFireEffectControl value = null;
			if (!_fireEffects.TryGetValue(particle.Value.GetIns(), out value))
			{
				value = particle.Value.GetIns().GetComponent<IFireEffectControl>();
				_fireEffects.Add(particle.Value.GetIns(), value);
			}
			if (value != null)
			{
				if (value.enabled)
				{
					value.enabled = false;
				}
				value.SetRender(flag: true);
			}
		}
	}

	public IFireEffectControl GetFireControlByParticleName(PlayerEntity player, string name)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals(name))
			{
				IFireEffectControl component = particle.Value.GetIns().GetComponent<IFireEffectControl>();
				if (component != null)
				{
					return component;
				}
			}
		}
		return null;
	}

	public void SetParticleActiveParticleNameGenIndexOfLessZero(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Info.IndexOf(name, StringComparison.Ordinal) < 0)
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	public void SetParticleActiveParticleNameGenIndexOf(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Info.IndexOf(name, StringComparison.Ordinal) > 0)
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	public void SetParticleActiveParticleNameGenIndexOfZero(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Info.IndexOf(name, StringComparison.Ordinal) >= 0)
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	public void SetParticleActiveParticleNameGenIndexOfBySkinName(PlayerEntity player, WeaponEntity weapon, string name, Func<PlayerEntity, WeaponEntity, string, string, int> func)
	{
		if (func == null)
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Info.IndexOf(name, StringComparison.Ordinal) > 0)
			{
				int num = func(player, weapon, particle.Key.JointName, particle.Key.PatricleName);
				if (num >= 0)
				{
					particle.Value.SetInsActive(num > 0);
				}
			}
		}
	}

	public void SetParticleActiveParticleName(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals(name))
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	public void SetParticleActiveBySkinName(PlayerEntity player, WeaponEntity weapon, Func<PlayerEntity, WeaponEntity, string, string, int> func)
	{
		if (func == null)
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			int num = func(player, weapon, particle.Key.JointName, particle.Key.PatricleName);
			if (num >= 0)
			{
				particle.Value.SetInsActive(num > 0);
			}
		}
	}

	public IPaticlePrefabInstancecs GetPaticleBySkinName(PlayerEntity player, string name)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.JointName.Equals(name))
			{
				return particle.Value;
			}
		}
		return null;
	}

	public IPaticlePrefabInstancecs GetPaticleByParticleName(PlayerEntity player, string name)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
		{
			if (particle.Key.PatricleName.Equals(name))
			{
				return particle.Value;
			}
		}
		return null;
	}

	public List<IPaticlePrefabInstancecs> GetPaticlesArrayByParticleName(PlayerEntity player, string name)
	{
		if (_paticlesArrayByParticleName == null)
		{
			_paticlesArrayByParticleName = new List<IPaticlePrefabInstancecs>();
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(player))
			{
				if (particle.Key.PatricleName.Equals(name))
				{
					_paticlesArrayByParticleName.Add(particle.Value);
				}
			}
		}
		return _paticlesArrayByParticleName;
	}

	public abstract void Update(PlayerEntity player, WeaponEntity currentWeapon, int raceType);
}
