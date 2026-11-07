using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class LeaderSuggestEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (120 == room.GetRaceType())
		{
			return false;
		}
		if (!(player.GetStealthAlpha() < 1f) && player.IsLeader() && room.GetRuleModel() == 16)
		{
			return true;
		}
		if (RuleUtilty.IsBigHeadModel(room.GetRuleModel()) && PlayerCareerConstantUtility.IsHero(player.GetCareer()))
		{
			return true;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("LeaderSuggest");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[3] { 16, 19, 2019 };
	}
}
