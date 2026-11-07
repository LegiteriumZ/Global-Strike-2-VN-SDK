using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class UseAntidoteEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().UseingAntidote;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("UseAntidote");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[4] { 14, 16, 17, 28 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(UseAntidoteEffectRender);
	}
}
