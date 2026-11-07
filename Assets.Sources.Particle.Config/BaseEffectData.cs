using System;
using System.Xml;
using SSJJAsset.Asset;

namespace Assets.Sources.Particle.Config;

public abstract class BaseEffectData : IEquatable<BaseEffectData>
{
	public AssetInfo AssetInfo;

	public AssetInfo ParticleAssetInfo;

	public string EffectName;

	public float EffectScale = 1f;

	public int RemainTime;

	public string Key = "";

	public int LevelState;

	public abstract BaseEffectData Parse(XmlNode node);

	public abstract string GetName();

	public bool Equals(BaseEffectData other)
	{
		if (other == null)
		{
			return false;
		}
		if (this == other)
		{
			return true;
		}
		if (AssetInfo.Equals(other.AssetInfo) && ParticleAssetInfo.Equals(other.ParticleAssetInfo) && string.Equals(EffectName, other.EffectName) && EffectScale.Equals(other.EffectScale) && string.Equals(Key, other.Key))
		{
			return RemainTime == other.RemainTime;
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
		return Equals((BaseEffectData)obj);
	}

	public override int GetHashCode()
	{
		return (((((((((AssetInfo.GetHashCode() * 397) ^ ParticleAssetInfo.GetHashCode()) * 397) ^ ((EffectName != null) ? EffectName.GetHashCode() : 0)) * 397) ^ EffectScale.GetHashCode()) * 397) ^ RemainTime.GetHashCode()) * 397) ^ ((Key != null) ? Key.GetHashCode() : 0);
	}
}
