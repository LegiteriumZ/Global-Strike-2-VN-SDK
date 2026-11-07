using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerUavEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (player.GetCurrentWeaponName() == "black_crow" || player.GetCurrentWeaponName() == "uav")
		{
			return player.GetCurrentWeaponLevel() == 3;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerUav");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerUavEffectRender);
	}
}
