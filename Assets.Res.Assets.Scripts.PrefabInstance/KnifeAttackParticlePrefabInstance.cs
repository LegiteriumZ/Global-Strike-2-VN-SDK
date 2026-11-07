using UnityEngine;

namespace Assets.Res.Assets.Scripts.PrefabInstance;

public class KnifeAttackParticlePrefabInstance : PaticlePrefabInstancecs
{
	public int AnimId;

	public int EffectTime;

	public bool isFrist;

	public int WaitTime;

	public int DoubleLv;

	public int WeaponLv = -1;

	public int EffectLevel;

	private KnifeAttackParticleEffect knifeAttack;

	public override void Awake()
	{
		base.Awake();
		if (instance != null)
		{
			ins.AddComponent<ScaleParticles>();
			knifeAttack = ins.AddComponent<KnifeAttackParticleEffect>();
			knifeAttack.config.AnimId = AnimId;
			knifeAttack.config.EffectTime = EffectTime;
			knifeAttack.config.WaitTime = WaitTime;
			knifeAttack.config.isFrist = isFrist;
			knifeAttack.config.DoubleLv = DoubleLv;
			knifeAttack.config.level = WeaponLv;
			knifeAttack.config.EffectLevel = EffectLevel;
			ParticleSystem[] componentsInChildren = base.cacheSystem.GetComponentsInChildren<ParticleSystem>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				ParticleSystem.MainModule main = componentsInChildren[i].main;
				main.playOnAwake = false;
			}
			base.cacheSystem.Stop();
		}
	}
}
