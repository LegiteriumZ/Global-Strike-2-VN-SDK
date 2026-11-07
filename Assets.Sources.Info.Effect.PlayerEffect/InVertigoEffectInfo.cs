using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class InVertigoEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().InVertigo;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo("effect/rpgcommon", "Assets/Res/Assets/effect/rpgcommon/bossvertigo/bossvertigo.prefab");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override int GetLifeTimeWhenTargetDead()
	{
		return 1000;
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerInVertigorEffectRender);
	}
}
