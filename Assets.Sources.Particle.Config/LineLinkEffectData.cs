using System;
using System.Xml;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class LineLinkEffectData : BaseEffectData, IEquatable<LineLinkEffectData>
{
	public float UnitLengthScale;

	public float UnitLength;

	public int WeaponSkin;

	public bool isForecast;

	public int forecastType;

	public bool serverSize;

	public bool isReplace;

	public string jointName;

	public bool onlyView;

	public int LerpStartz;

	public int LerpEndz;

	public int traceLength;

	public int StartBackLen;

	public override BaseEffectData Parse(XmlNode xn)
	{
		EffectName = xn.Read("effectName");
		WeaponSkin = xn.Read("weaponSkin", 0);
		Key = xn.Read("lineLinkType");
		EffectScale = xn.Read("effectScale", 1f);
		UnitLengthScale = xn.Read("unitLengthScale", 1f);
		UnitLength = xn.Read("unitLength", 1f);
		isForecast = xn.Read("isForecast", defaultval: false);
		forecastType = xn.Read("forecastType", 0);
		serverSize = xn.Read("serverSize", defaultval: false);
		isReplace = xn.Read("isReplace", defaultval: false);
		jointName = xn.Read("jointName");
		onlyView = xn.Read("onlyView", defaultval: false);
		LerpStartz = xn.Read("LerpStartz", 0);
		LerpEndz = xn.Read("LerpEndz", 0);
		traceLength = xn.Read("traceLength", 1000);
		StartBackLen = xn.Read("startBackLength", 0);
		return this;
	}

	public override string GetName()
	{
		return "linelink_" + Key;
	}

	public bool Equals(LineLinkEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (Equals((BaseEffectData)other) && UnitLengthScale.Equals(other.UnitLengthScale))
		{
			return WeaponSkin == other.WeaponSkin;
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
		return Equals((LineLinkEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((base.GetHashCode() * 397) ^ UnitLengthScale.GetHashCode()) * 397) ^ WeaponSkin;
	}
}
