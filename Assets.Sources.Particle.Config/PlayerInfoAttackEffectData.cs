using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class PlayerInfoAttackEffectData : BaseEffectData, IEquatable<PlayerInfoAttackEffectData>
{
	public float Around;

	public string Career = "";

	public int EffectScaleX = 1;

	public float Forward;

	public string JointName = "";

	public int PitchTrim;

	public int RestartTime;

	public float Up;

	public int YawTrim;

	public int ViewHeight;

	public int ViewHeightTop;

	public bool AutoSize;

	public bool HasViewEffect;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		Key = xn.Read("playerStatus");
		if (string.IsNullOrEmpty(Key))
		{
			Key = xn.Read("playerState");
		}
		EffectScale = xn.Read("effectScale", 1f);
		YawTrim = xn.Read("yawTrim", 0);
		PitchTrim = xn.Read("pitchTrim", 0);
		Up = xn.Read("up", 0f);
		Forward = xn.Read("forward", 0f);
		Around = xn.Read("around", 0f);
		JointName = xn.Read("jointName");
		Career = xn.Read("career");
		RestartTime = xn.Read("restartTime", 0);
		EffectScaleX = xn.Read("effectScaleX", 1);
		ViewHeight = xn.Read("viewHeight", 0);
		ViewHeightTop = xn.Read("viewHeightTop", 0);
		AutoSize = xn.Read("autoSize", 0) == 1;
		HasViewEffect = xn.Read("hasViewEffect", defaultval: false);
		return this;
	}

	public override string GetName()
	{
		return "playerInfoAttack_" + Key;
	}

	public bool Equals(PlayerInfoAttackEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && Around.Equals(other.Around) && string.Equals(Career, other.Career) && EffectScaleX == other.EffectScaleX && Forward.Equals(other.Forward) && string.Equals(JointName, other.JointName) && PitchTrim == other.PitchTrim && RestartTime == other.RestartTime && Up.Equals(other.Up) && YawTrim == other.YawTrim && ViewHeight == other.ViewHeight)
		{
			return ViewHeightTop == other.ViewHeightTop;
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
		return Equals((PlayerInfoAttackEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((((((((((((((((((((base.GetHashCode() * 397) ^ Around.GetHashCode()) * 397) ^ ((Career != null) ? Career.GetHashCode() : 0)) * 397) ^ EffectScaleX) * 397) ^ Forward.GetHashCode()) * 397) ^ ((JointName != null) ? JointName.GetHashCode() : 0)) * 397) ^ PitchTrim) * 397) ^ RestartTime) * 397) ^ Up.GetHashCode()) * 397) ^ YawTrim) * 397) ^ ViewHeight) * 397) ^ ViewHeightTop;
	}
}
