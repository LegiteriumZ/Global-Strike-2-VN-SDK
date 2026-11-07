using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class PlayerAnimEffectData : BaseEffectData, IEquatable<PlayerAnimEffectData>
{
	public int DelayTime = -1;

	public int LegsAnim = -1;

	public int Up;

	public string PlayerCareer = "";

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		EffectScale = xn.Read("effectScale", 1f);
		PlayerCareer = xn.Read("playerCareer");
		LegsAnim = xn.Read("legsAnim", -1);
		DelayTime = xn.Read("delayTime", -1);
		Key = $"{PlayerCareer}_{LegsAnim}";
		Up = xn.Read("up", 0);
		return this;
	}

	public override string GetName()
	{
		return "playeranim_" + Key;
	}

	public bool Equals(PlayerAnimEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && DelayTime == other.DelayTime && LegsAnim == other.LegsAnim)
		{
			return string.Equals(PlayerCareer, other.PlayerCareer);
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
		return Equals((PlayerAnimEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((((base.GetHashCode() * 397) ^ DelayTime) * 397) ^ LegsAnim) * 397) ^ ((PlayerCareer != null) ? PlayerCareer.GetHashCode() : 0);
	}
}
