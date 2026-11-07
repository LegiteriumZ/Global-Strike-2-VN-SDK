using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class ArmamentJxldIconEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.HasStatus(10374);
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerArmamentIcon");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { 15013 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(ArmamentJxldIconRender);
	}
}
