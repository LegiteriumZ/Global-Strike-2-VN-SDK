using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class BiochemicalShellEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom roomData)
	{
		int ruleModel = roomData.GetRuleModel();
		if (player.HasState(64) && player.GetCareer() != "pandoraMonther" && player.GetCareer() != "pandoraMonther_baigu")
		{
			if (roomData.GetPlayer(player.GetId()).GetStealthAlpha() < 1f)
			{
				return false;
			}
			if (ruleModel == 20 || ruleModel == 33)
			{
				return true;
			}
			if (PlayerCareerConstantUtility.IsDoun(player.GetCareer()))
			{
				return true;
			}
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("BiochemicalShell");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { 6 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(BiochemicalShellRender);
	}
}
