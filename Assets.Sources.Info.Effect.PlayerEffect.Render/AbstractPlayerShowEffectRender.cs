using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using Assets.Sources.Info.UnityObjects;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public abstract class AbstractPlayerShowEffectRender : IPlayerShowEffectRender
{
	private readonly Dictionary<GameObject, Dictionary<ParticleKey, PaticlePrefabInstancecs>> _dics = new Dictionary<GameObject, Dictionary<ParticleKey, PaticlePrefabInstancecs>>();

	public abstract void Init(PlayerEntity player);

	public abstract void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom);

	public Dictionary<ParticleKey, PaticlePrefabInstancecs> GetParticles(GameObject careerGameObject)
	{
		if (careerGameObject == null)
		{
			return null;
		}
		Dictionary<ParticleKey, PaticlePrefabInstancecs> value = null;
		if (!_dics.TryGetValue(careerGameObject, out value))
		{
			value = new Dictionary<ParticleKey, PaticlePrefabInstancecs>();
			_dics[careerGameObject] = value;
			PaticlePrefabInstancecs[] componentsInChildren = careerGameObject.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			for (int num = componentsInChildren.Length - 1; num >= 0; num--)
			{
				PaticlePrefabInstancecs paticlePrefabInstancecs = componentsInChildren[num];
				if (!(paticlePrefabInstancecs.instance == null))
				{
					ParticleKey key = new ParticleKey(paticlePrefabInstancecs.gameObject.name, paticlePrefabInstancecs.instance.name);
					if (!value.ContainsKey(key))
					{
						value.Add(key, paticlePrefabInstancecs);
					}
					else
					{
						paticlePrefabInstancecs.SetInsActive(flag: false);
					}
				}
			}
		}
		return value;
	}

	public void SetParticleActiveBySkinName(PlayerEntity player, Func<PlayerEntity, string, string, int> func)
	{
		foreach (KeyValuePair<ParticleKey, PaticlePrefabInstancecs> particle in GetParticles(player.thirdPersonUnityObjects.ThirdTran.BodyTransform.gameObject))
		{
			int num = func(player, particle.Key.JointName, particle.Key.PatricleName);
			if (num >= 0)
			{
				particle.Value.SetInsActive(num > 0);
			}
		}
	}

	public void SetParticleActiveParticleNameGenIndexOf(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<ParticleKey, PaticlePrefabInstancecs> particle in GetParticles(player.thirdPersonUnityObjects.ThirdTran.BodyTransform.gameObject))
		{
			if (particle.Key.PatricleName.Info.IndexOf(name, StringComparison.Ordinal) > 0)
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	public void SetParticleActiveParticleName(PlayerEntity player, string name, bool flag)
	{
		foreach (KeyValuePair<ParticleKey, PaticlePrefabInstancecs> particle in GetParticles(player.thirdPersonUnityObjects.ThirdTran.BodyTransform.gameObject))
		{
			if (particle.Key.PatricleName.Equals(name))
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}
}
