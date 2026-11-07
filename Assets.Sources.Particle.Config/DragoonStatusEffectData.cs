using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class DragoonStatusEffectData : BaseEffectData, IEquatable<DragoonStatusEffectData>
{
	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("dragoonStatus");
		EffectScale = xn.Read("effectScale", 1f);
		return this;
	}

	public override string GetName()
	{
		return "dragoon_status_" + Key.Replace("/", "_");
	}

	public bool Equals(DragoonStatusEffectData other)
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
		return Equals((DragoonStatusEffectData)obj);
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}
}
