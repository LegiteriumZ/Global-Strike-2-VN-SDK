using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerGoldWeaponRailEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity == null || player == null)
		{
			return false;
		}
		if (player.GetTeam() == myPlayerEntity.GetTeam())
		{
			return player.GetPlayerInfo().BagGoldWeaponNum >= 4;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("GoldWeaponRail");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerGoldWeaponRailEffectRender);
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}
}
