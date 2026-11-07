using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class ParasiticSniperEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		long cid = player.basicInfo.Cid;
		if (Contexts.sharedInstance.battleRoom.playerInfo.PlayerInfoExtraDatas.TryGetValue(cid, out var value))
		{
			return value.Numb > 0;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo("playereffectprefab/parasiticsniper", "ParasiticSniper");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(ParasiticSniperRender);
	}
}
