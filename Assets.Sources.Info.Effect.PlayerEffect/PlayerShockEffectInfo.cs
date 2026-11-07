using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerShockEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().ShockSkillUsing;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerShock");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { -2, -3 };
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}
}
