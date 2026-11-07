using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class UseDartsEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().UseDarts;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("UseDarts");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { 1001 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(UseDartsEffectRender);
	}
}
