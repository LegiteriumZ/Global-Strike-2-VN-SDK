using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class IncentivetaskEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!(player.GetStealthAlpha() < 1f) && player.IsLeader() && room.GetRuleModel() != 16)
		{
			return true;
		}
		if (player.GetPlayerInfo().Incentivetask)
		{
			return true;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("Incentivetask");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[3] { -2, -3, 28 };
	}
}
