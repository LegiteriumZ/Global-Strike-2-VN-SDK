using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class IsBeAbyssSetKillEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().IsBeAbyssSetKill;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo("effect/common", "beabyssset_kill");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(DefaultPlayerEffectRender);
	}

	public override bool IsEffectOnPlayerDead()
	{
		return true;
	}
}
