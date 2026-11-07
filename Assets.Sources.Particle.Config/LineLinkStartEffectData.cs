using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class LineLinkStartEffectData : BaseEffectData, IEquatable<LineLinkStartEffectData>
{
	public int WeaponSkin;

	public override BaseEffectData Parse(XmlNode xn)
	{
		WeaponSkin = xn.Read("weaponSkin", 0);
		EffectName = xn.Read("effectName");
		Key = xn.Read("lineLinkType");
		EffectScale = xn.Read("effectScale", 1f);
		return this;
	}

	public override string GetName()
	{
		return "linelink_" + Key;
	}

	public bool Equals(LineLinkStartEffectData other)
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
			return WeaponSkin == other.WeaponSkin;
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
		return Equals((LineLinkStartEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ WeaponSkin;
	}
}
