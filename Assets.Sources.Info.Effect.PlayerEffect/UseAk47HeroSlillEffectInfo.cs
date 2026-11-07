using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class UseAk47HeroSlillEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().Ak47Hero;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("UseAk47HeroSlill");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}
}
