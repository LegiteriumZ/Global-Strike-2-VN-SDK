using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class MechHpEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (player.GetMechShowTime() > 0 && PlayerCareerConstantUtility.IsMech(player.GetCareer()) && !player.IsDead())
		{
			return true;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return new AssetInfo("playereffectprefab/mechhpbar", "MechHpBar", typeof(GameObject));
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(MechHpEffectRender);
	}
}
