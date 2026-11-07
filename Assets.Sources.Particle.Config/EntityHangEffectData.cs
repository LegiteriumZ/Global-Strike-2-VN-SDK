using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class EntityHangEffectData : BaseEffectData, IEquatable<EntityHangEffectData>
{
	public float Around;

	public float Forward;

	public int PitchTrim;

	public float Up;

	public int YawTrim;

	public override BaseEffectData Parse(XmlNode xn)
	{
		Key = xn.Read("entityName");
		EffectName = xn.Read("effectName");
		EffectScale = xn.Read("effectScale", 1f);
		YawTrim = xn.Read("yawTrim", 0);
		PitchTrim = xn.Read("pitchTrim", 0);
		Up = xn.Read("up", 0f);
		Forward = xn.Read("forward", 0f);
		Around = xn.Read("around", 0f);
		return this;
	}

	public override string GetName()
	{
		return "entity_";
	}

	public bool Equals(EntityHangEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && Around.Equals(other.Around) && Forward.Equals(other.Forward) && PitchTrim == other.PitchTrim && Up.Equals(other.Up))
		{
			return YawTrim == other.YawTrim;
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
		return Equals((EntityHangEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((((((((base.GetHashCode() * 397) ^ Around.GetHashCode()) * 397) ^ Forward.GetHashCode()) * 397) ^ PitchTrim) * 397) ^ Up.GetHashCode()) * 397) ^ YawTrim;
	}
}
