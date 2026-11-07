using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class InHanbingtuxiEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().InHanbingtuxi;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo("player/boss1004", "playerinfo_InHanbingtuxi");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(DefaultPlayerEffectRender);
	}
}
