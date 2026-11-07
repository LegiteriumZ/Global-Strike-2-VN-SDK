using SSJJAsset.Asset;

namespace Assets.Sources.Info.Weapon.Logic.SelfKillLogic;

public class SelfKillTempData
{
	public AssetInfo[] KillImage;

	public int MovieLenth;

	public SelfKillTempData(int movieLenth)
	{
		MovieLenth = movieLenth;
		KillImage = new AssetInfo[MovieLenth];
	}
}
