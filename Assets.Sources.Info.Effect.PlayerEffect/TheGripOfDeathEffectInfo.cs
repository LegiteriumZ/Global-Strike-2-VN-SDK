using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class TheGripOfDeathEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().TheGripOfDeath;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("TheGripOfDeath");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { -3, 1001 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(TheGripOfDeathRender);
	}
}
