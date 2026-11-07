using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerLodEffectInfo : AbstractPlayerEffectInfo
{
	private bool _isOpenLodEffect;

	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo("playereffectprefab/PlayerLod", "PlayerLod", typeof(GameObject));
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerLodEffectRender);
	}
}
