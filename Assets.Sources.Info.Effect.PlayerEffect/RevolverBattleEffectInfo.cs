using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class RevolverBattleEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (Contexts.sharedInstance.player.myPlayerEntity.GetCurrentWeaponSkinName() == "" && player.hasDeadEye)
		{
			return player.deadEye.ShowFlag > 0;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("RevolverBattle");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[0];
	}

	public override Type GetThirdRenderType()
	{
		return typeof(RevolverBattleRender);
	}
}
