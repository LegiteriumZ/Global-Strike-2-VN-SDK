using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class PlayerTitleEffectData : BaseEffectData, IEquatable<PlayerTitleEffectData>
{
	public int TitleId;

	public bool viewHeightTop;

	public override BaseEffectData Parse(XmlNode xn)
	{
		TitleId = xn.Read("titleId", 0);
		EffectName = xn.Read("effectName");
		viewHeightTop = xn.Read("viewHeightTop", defaultval: false);
		return this;
	}

	public override string GetName()
	{
		return "playertitle_" + TitleId;
	}

	public bool Equals(PlayerTitleEffectData other)
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
			return TitleId.Equals(other.TitleId);
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
		return Equals((PlayerTitleEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (base.GetHashCode() * 397) ^ TitleId.GetHashCode();
	}
}
