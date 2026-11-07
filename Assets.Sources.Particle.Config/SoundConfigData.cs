using System.Xml;
using Assets.Sources.Utils.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Extensions;

namespace Assets.Sources.Particle.Config;

public class SoundConfigData : BaseEffectData
{
	public int EventId;

	public string Url;

	public float Vol;

	public bool Loop;

	public int Scale;

	public bool Point;

	public bool NoStop;

	public float MoveTime;

	public string career;

	public AssetInfo DamageAssetInfo;

	public AssetInfo DeathAssetInfo;

	public override string GetName()
	{
		return "soundconfig";
	}

	public bool hasCareer()
	{
		return career != "";
	}

	public override BaseEffectData Parse(XmlNode node)
	{
		if (node == null)
		{
			return this;
		}
		EventId = node.Read("eventId", 0);
		Url = node.Read("url");
		Vol = node.Read("vol", 0f);
		MoveTime = node.Read("MoveTime", 0f);
		Loop = node.Read("loop", 0) == 1;
		Scale = node.Read("scale", 0);
		Point = node.Read("point", 0) == 1;
		NoStop = node.Read("noStop", 0) == 1;
		career = node.Read("career");
		string bundleName = WeaponUtility.GetAssetMp3BundleName("", Url);
		if (hasCareer())
		{
			bundleName = "sound/player";
		}
		AssetInfo = new AssetInfo(bundleName, $"Assets/Res/Assets/{Url}");
		return this;
	}
}
