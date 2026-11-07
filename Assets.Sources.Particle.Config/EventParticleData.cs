using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class EventParticleData : BaseEffectData, IEquatable<EventParticleData>
{
	public int EventType;

	public int Time;

	public string Name;

	public int Level;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EventType = xn.Read("eventType", 0);
		Time = xn.Read("time", 0);
		Name = xn.Read("pname");
		Level = xn.Read("level", 0);
		return this;
	}

	public override string GetName()
	{
		return "eventParticle_" + EventType;
	}

	public bool Equals(EventParticleData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && EventType.Equals(other.EventType) && Time.Equals(other.Time) && Name == other.Name)
		{
			return Level.Equals(other.Level);
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
		return Equals((EventParticleData)obj);
	}

	public override int GetHashCode()
	{
		return (((((base.GetHashCode() * 397) ^ EventType) * 397) ^ Time) * 397) ^ Level;
	}
}
