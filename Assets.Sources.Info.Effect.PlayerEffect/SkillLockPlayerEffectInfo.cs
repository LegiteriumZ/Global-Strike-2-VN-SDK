using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class SkillLockPlayerEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().SkillLockPlayerIDType == 2 && Contexts.sharedInstance.gameRule.currentRule.Rule.IsExplode())
		{
			return false;
		}
		return player.GetId() == room.GetMyPlayer().GetPlayerInfo().SkillLockPlayerID;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		if (Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().SkillLockPlayerIDType == 1)
		{
			return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("SkillLockPlayerType");
		}
		if (Contexts.sharedInstance.player.myPlayerEntity.GetPlayerInfo().SkillLockPlayerIDType == 2)
		{
			return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("SkillLockPlayerType2");
		}
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("SkillLockPlayer");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[3] { -2, 6, -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(SkillLockPlayerRender);
	}
}
