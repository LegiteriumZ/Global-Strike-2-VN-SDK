using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class WarrantEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().Warrant;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("Warrant");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { -2, 6 };
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}

	public override Type GetThirdRenderType()
	{
		return typeof(WarrantEffectEffectRender);
	}
}
