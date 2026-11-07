using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerCoverEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().MechWarriorCoverSkillUsing;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerCover");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { 29, 31 };
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}
}
