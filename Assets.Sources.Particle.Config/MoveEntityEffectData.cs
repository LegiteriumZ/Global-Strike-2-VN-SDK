using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class MoveEntityEffectData : BaseEffectData, IEquatable<MoveEntityEffectData>
{
	public float EffectScaleX = 1f;

	public float EffectScaleY = 1f;

	public float EffectScaleZ = 1f;

	public int PitchTrim;

	public int YawTrim;

	public bool viewAttach;

	public float viewAttachX;

	public float viewAttachY;

	public float viewAttachZ;

	public bool viewFollowYaw;

	public bool viewFollowPitch;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("moveEntityName");
		EffectScale = xn.Read("effectScale", 1f);
		YawTrim = xn.Read("yawTrim", 0);
		PitchTrim = xn.Read("pitchTrim", 0);
		EffectScaleX = xn.Read("effectScaleX", 1f);
		EffectScaleY = xn.Read("effectScaleY", 1f);
		EffectScaleZ = xn.Read("effectScaleZ", 1f);
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
		return "move_" + Key.Replace("/", "_");
	}

	public override bool Equals(object o)
	{
		if (o == null)
		{
			return false;
		}
		if (this == o)
		{
			return true;
		}
		if (o.GetType() != GetType())
		{
			return false;
		}
		return Equals((MoveEntityEffectData)o);
	}

	public bool Equals(MoveEntityEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && EffectScaleX.Equals(other.EffectScaleX) && EffectScaleY.Equals(other.EffectScaleY) && EffectScaleZ.Equals(other.EffectScaleZ) && PitchTrim == other.PitchTrim && YawTrim == other.YawTrim && viewAttach == other.viewAttach && viewAttachX.Equals(other.viewAttachX) && viewAttachY.Equals(other.viewAttachY) && viewAttachZ.Equals(other.viewAttachZ) && viewFollowYaw == other.viewFollowYaw)
		{
			return viewFollowPitch == other.viewFollowPitch;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((((((((((((((((((((base.GetHashCode() * 397) ^ EffectScaleX.GetHashCode()) * 397) ^ EffectScaleY.GetHashCode()) * 397) ^ EffectScaleZ.GetHashCode()) * 397) ^ PitchTrim) * 397) ^ YawTrim) * 397) ^ viewAttach.GetHashCode()) * 397) ^ viewAttachX.GetHashCode()) * 397) ^ viewAttachY.GetHashCode()) * 397) ^ viewAttachZ.GetHashCode()) * 397) ^ viewFollowYaw.GetHashCode()) * 397) ^ viewFollowPitch.GetHashCode();
	}
}
