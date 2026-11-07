using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class AttachEventEffectData : BaseEffectData, IEquatable<AttachEventEffectData>
{
	public bool IsOnlyOne;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("eventId");
		IsOnlyOne = xn.Read("isOnlyOne", defaultval: false);
		RemainTime = xn.Read("remainTime", 2000);
		return this;
	}

	public override string GetName()
	{
		return "attach_event_" + Key;
	}

	public bool Equals(AttachEventEffectData other)
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
			return IsOnlyOne == other.IsOnlyOne;
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
		return Equals((AttachEventEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ IsOnlyOne.GetHashCode();
	}
}
