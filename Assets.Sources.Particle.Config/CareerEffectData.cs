using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class CareerEffectData : BaseEffectData, IEquatable<CareerEffectData>
{
	public string CareerSkin;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		CareerSkin = xn.Read("careerSkin");
		return this;
	}

	public override string GetName()
	{
		return "CareerEffect" + EffectName;
	}

	public bool Equals(CareerEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other))
		{
			return string.Equals(CareerSkin, other.CareerSkin);
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (this == obj)
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		return Equals((CareerEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ ((CareerSkin != null) ? CareerSkin.GetHashCode() : 0);
	}
}
