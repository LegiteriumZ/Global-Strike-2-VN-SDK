using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerTailEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (player.GetSkin() == "longyin_jj" || player.GetCareer() == "renzhe")
		{
			if (!(player.GetVelocity() >= 310f))
			{
				return player.HasStatus(PlayerInfoStatusConstant.RPG_using_role1002.ID);
			}
			return true;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo("playereffectprefab/playertail", "PlayerTail", typeof(GameObject));
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayeTailEffectRender);
	}
}
