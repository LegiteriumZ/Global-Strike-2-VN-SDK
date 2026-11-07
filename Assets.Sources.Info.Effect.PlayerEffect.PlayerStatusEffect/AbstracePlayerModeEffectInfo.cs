using Assets.Sources.Components.Interface;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect.PlayerStatusEffect;

public abstract class AbstracePlayerModeEffectInfo : CommonPlayerStatusEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (StatusInfoData != null)
		{
			return player.basicInfo.CareerInfo.Name == StatusInfoData.Career;
		}
		return false;
	}

	protected override int[] GetSupportedRules()
	{
		return new int[6] { 6, 11, -2, -3, 24, 25 };
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo(string.Format("{0}{1}", "player/", player.GetCareer()), PrefabName);
	}

	public AbstracePlayerModeEffectInfo(int statusId)
		: base(statusId)
	{
	}
}
