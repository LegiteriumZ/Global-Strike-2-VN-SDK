using System.Collections.Generic;
using Assets.Sources.Info.Weapon.Logic.SelfKillLogic;
using NetData;
using SSJJAsset.Asset;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.XmlAsset;

internal class SelfKillInfoXmlAsset : AbstractXmlAsset, ISelfKillInfoTemplate
{
	private ISelfKillInfoTemplate _self;

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		_self = WeaponSelfKillInfoFactory.Parse(text);
	}

	public int GetSelfKillType()
	{
		return _self.GetSelfKillType();
	}

	public SelfKillTempData GetSelfKillTempData(KillPlayerInfoData killInfoData, int raceType, bool isWet)
	{
		return _self.GetSelfKillTempData(killInfoData, raceType, isWet);
	}

	public List<AssetInfo> GetAllSelfKillAssets(string weapon, int weaponType, int raceType)
	{
		return _self.GetAllSelfKillAssets(weapon, weaponType, raceType);
	}

	public void Init(string weapon)
	{
		_self.Init(weapon);
	}

	public override string ToString()
	{
		return _self.ToString();
	}
}
