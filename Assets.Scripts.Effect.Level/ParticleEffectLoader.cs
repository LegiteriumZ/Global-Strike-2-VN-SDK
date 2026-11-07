using System.Collections;
using System.Collections.Generic;
using SSJJBase.Singleton;

namespace Assets.Scripts.Effect.Level;

public class ParticleEffectLoader : MonoBehaviourSingleton<ParticleEffectLoader>
{
	public class SpecialConfig
	{
		public string Name;

		public string Type;
	}

	private readonly List<SpecialConfig> _specailEffects = new List<SpecialConfig>();

	private string[] nameStr = new string[1] { "lightening_sword_qs" };

	public IEnumerator Load()
	{
		SetSpecialEffectLevel();
		MonoBehaviourSingleton<ParticleEffectManager>.Instance.Init();
		yield break;
	}

	public bool IsSpecailParticle(string url)
	{
		for (int i = 0; i < _specailEffects.Count; i++)
		{
			if (_specailEffects[i].Name.Equals(url))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsSpecailParticleName(string str)
	{
		for (int i = 0; i < nameStr.Length; i++)
		{
			if (nameStr[i].Equals(str))
			{
				return true;
			}
		}
		return false;
	}

	private void SetSpecialEffectLevel()
	{
		SpecialConfig specialConfig = new SpecialConfig();
		specialConfig.Name = "black_hole_grenade";
		specialConfig.Type = "weapon";
		_specailEffects.Add(specialConfig);
		specialConfig = new SpecialConfig();
		specialConfig.Name = "smoke";
		specialConfig.Type = "weapon";
		_specailEffects.Add(specialConfig);
		specialConfig = new SpecialConfig();
		specialConfig.Name = "grenade_thorns";
		specialConfig.Type = "weapon";
		_specailEffects.Add(specialConfig);
	}
}
