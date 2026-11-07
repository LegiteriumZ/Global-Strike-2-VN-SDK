using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerStealExpertEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (room.GetRuleModel() == 15010 && player.hasBasicInfo && !player.basicInfo.IsDead)
		{
			return true;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerStealExpert");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerStealExpertEffectRender);
	}
}
