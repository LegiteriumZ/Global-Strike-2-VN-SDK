using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class SceneBuffEffectData : BaseEffectData, IEquatable<SceneBuffEffectData>
{
	public float Up;

	public bool CanChangeRotation;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("sceneBuffName");
		EffectScale = xn.Read("effectScale", 1f);
		Up = xn.Read("up", 0f);
		CanChangeRotation = xn.Read("CanChangeRotation", defaultval: false);
		return this;
	}

	public override string GetName()
	{
		return "scenebuff_" + Key;
	}

	public bool Equals(SceneBuffEffectData other)
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
			return Up.Equals(other.Up);
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
		return Equals((SceneBuffEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ Up.GetHashCode();
	}
}
