using System.Collections.Generic;
using NetData;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

internal interface ISelfKillInfoTemplate
{
	int GetSelfKillType();

	SelfKillTempData GetSelfKillTempData(KillPlayerInfoData killInfoData, int raceType, bool isWet);

	List<AssetInfo> GetAllSelfKillAssets(string weapon, int weaponType, int raceType);

	void Init(string weapon);
}
