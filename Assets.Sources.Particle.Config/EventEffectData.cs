using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class EventEffectData : BaseEffectData, IEquatable<EventEffectData>
{
	public float Around;

	public float Forward;

	public int PitchTrim;

	public float Up;

	public int YawTrim;

	public int EffectTime;

	public bool viewAttach;

	public float viewAttachX;

	public float viewAttachY;

	public float viewAttachZ;

	public bool viewFollowYaw;

	public bool viewFollowPitch;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("eventId");
		EffectScale = xn.Read("effectScale", 1f);
		YawTrim = xn.Read("yawTrim", 0);
		PitchTrim = xn.Read("pitchTrim", 0);
		Up = xn.Read("up", 0f);
		Forward = xn.Read("forward", 0f);
		Around = xn.Read("around", 0f);
		EffectTime = xn.Read("EffectTime", 0);
		viewAttach = xn.Read("viewAttach", defaultval: false);
		viewAttachX = xn.Read("viewAttachX", 0f);
		viewAttachY = xn.Read("viewAttachY", 0f);
		viewAttachZ = xn.Read("viewAttachZ", 0f);
		viewFollowYaw = xn.Read("viewFollowYaw", defaultval: false);
		viewFollowPitch = xn.Read("viewFollowPitch", defaultval: false);
		return this;
	}

	public override string GetName()
	{
		return "event_" + Key.Replace("/", "_");
	}

	public bool Equals(EventEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && Around.Equals(other.Around) && Forward.Equals(other.Forward) && PitchTrim == other.PitchTrim && Up.Equals(other.Up) && YawTrim == other.YawTrim && EffectTime == other.EffectTime && viewAttach == other.viewAttach && viewAttachX.Equals(other.viewAttachX) && viewAttachY.Equals(other.viewAttachY) && viewAttachZ.Equals(other.viewAttachZ) && viewFollowYaw == other.viewFollowYaw)
		{
			return viewFollowPitch == other.viewFollowPitch;
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
		return Equals((EventEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((((((((((((((((((((((base.GetHashCode() * 397) ^ Around.GetHashCode()) * 397) ^ Forward.GetHashCode()) * 397) ^ PitchTrim) * 397) ^ Up.GetHashCode()) * 397) ^ YawTrim) * 397) ^ EffectTime) * 397) ^ viewAttach.GetHashCode()) * 397) ^ viewAttachX.GetHashCode()) * 397) ^ viewAttachY.GetHashCode()) * 397) ^ viewAttachZ.GetHashCode()) * 397) ^ viewFollowYaw.GetHashCode()) * 397) ^ viewFollowPitch.GetHashCode();
	}
}
