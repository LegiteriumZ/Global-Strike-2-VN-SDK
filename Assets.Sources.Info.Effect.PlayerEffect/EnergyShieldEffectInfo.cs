using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class EnergyShieldEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		int ruleModel = room.GetRuleModel();
		bool num = player.HasState(64) && ruleModel != 20 && ruleModel != 33 && !PlayerCareerConstantUtility.IsDoun(player.GetCareer()) && player.GetCareer() != "pandoraMonther" && player.GetCareer() != "pandoraMonther_baigu";
		bool flag = player.HasState(1024);
		return num || flag;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("EnergyShield");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[3] { -2, -3, 6 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(EnergyShieldEffectRender);
	}
}
