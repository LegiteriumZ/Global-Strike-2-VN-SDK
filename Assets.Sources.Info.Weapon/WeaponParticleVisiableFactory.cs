using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;

namespace Assets.Sources.Info.Weapon;

public class WeaponParticleVisiableFactory
{
	private class ParticleVisiable
	{
		public readonly string WeaponName;

		public readonly string ParticleString;

		public ParticleVisiable(string weaponName, string particleString)
		{
			WeaponName = weaponName;
			ParticleString = particleString;
		}
	}

	public static WeaponParticleVisiableFactory Instance = new WeaponParticleVisiableFactory();

	private readonly List<ParticleVisiable> _particleVisiableConfigs = new List<ParticleVisiable>();

	public void AddParticle(string weaponName, string particleName)
	{
		ParticleVisiable item = new ParticleVisiable(weaponName, particleName);
		_particleVisiableConfigs.Add(item);
	}

	public int CheckVisiable(string weaponName, PlayerEntity playerEntity, PaticlePrefabInstancecs instance)
	{
		bool flag = false;
		for (int i = 0; i < _particleVisiableConfigs.Count; i++)
		{
			if (_particleVisiableConfigs[i].WeaponName.Equals(weaponName))
			{
				flag = true;
				if (instance.instance != null && instance.instance.name.Equals(_particleVisiableConfigs[i].ParticleString) && playerEntity.hasVisiable && playerEntity.visiable.IsWeaponParticleUnSee)
				{
					return -1;
				}
			}
		}
		if (!flag)
		{
			return 1;
		}
		return 0;
	}

	public int CheckVisiable(string weaponName, PlayerEntity playerEntity, string particleName)
	{
		bool flag = false;
		for (int i = 0; i < _particleVisiableConfigs.Count; i++)
		{
			if (_particleVisiableConfigs[i].WeaponName.Equals(weaponName))
			{
				flag = true;
				if (particleName.Equals(_particleVisiableConfigs[i].ParticleString) && playerEntity.hasVisiable && playerEntity.visiable.IsWeaponParticleUnSee)
				{
					return -1;
				}
			}
		}
		if (!flag)
		{
			return 1;
		}
		return 0;
	}
}
