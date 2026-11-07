using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class ChangedHumanEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().ChangeHumanEffect;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("ChangedHuman");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { 28 };
	}
}
