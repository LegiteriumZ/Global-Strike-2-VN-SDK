using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class TailEffectData : BaseEffectData, IEquatable<TailEffectData>
{
	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("entityName");
		EffectScale = xn.Read("effectScale", 1f);
		LevelState = xn.Read("levelstate", 0);
		return this;
	}

	public override string GetName()
	{
		return "tailEffect_" + Key.Replace("/", "_");
	}

	public bool Equals(TailEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		return Equals((BaseEffectData)other);
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
		return Equals((TailEffectData)obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
