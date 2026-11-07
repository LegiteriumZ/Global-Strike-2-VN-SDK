using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class HeroSuggestEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (120 == room.GetRaceType())
		{
			return false;
		}
		if (RuleUtilty.IsBioMode(room.GetRuleModel()) && ((PlayerCareerConstantUtility.IsHero(player.GetCareer()) && !PlayerCareerConstantUtility.IsMech(player.GetCareer())) || player.GetCareer() == "death"))
		{
			return true;
		}
		if (player.GetPlayerInfo().BioHero)
		{
			return true;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("HeroSuggest");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { 6, 38 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(HeroSuggestEffectRender);
	}
}
