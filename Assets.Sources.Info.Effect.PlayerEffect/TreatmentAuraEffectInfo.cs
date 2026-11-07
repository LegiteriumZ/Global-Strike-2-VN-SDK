using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class TreatmentAuraEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.IsTreatmentAura();
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("TreatmentAura");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { 1002 };
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}
}
