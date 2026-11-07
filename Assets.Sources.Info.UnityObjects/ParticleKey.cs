using System;
using Assets.Sources.Components.Interface;
using SSJJBase.String;

namespace Assets.Sources.Info.UnityObjects;

public struct ParticleKey : IParticleKey, IEquatable<IParticleKey>
{
	public IgnoreCaseString JointName { get; }

	public IgnoreCaseString PatricleName { get; }

	public IWeaponAnimationEffectConfig Config { get; set; }

	public ParticleKey(string jointname, string patricleName, IWeaponAnimationEffectConfig config = null)
	{
		JointName = jointname;
		PatricleName = patricleName;
		Config = config;
	}

	public bool Equals(IParticleKey other)
	{
		if (Config == null || other.Config == null)
		{
			if (Config == null && other.Config == null)
			{
				if (JointName.Equals(other.JointName))
				{
					return PatricleName.Equals(other.PatricleName);
				}
				return false;
			}
			return false;
		}
		if (JointName.Equals(other.JointName) && PatricleName.Equals(other.PatricleName))
		{
			return Config.Equals(other.Config);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (obj is IParticleKey)
		{
			return Equals((IParticleKey)obj);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (JointName.GetHashCode() * 397) ^ PatricleName.GetHashCode();
	}
}
