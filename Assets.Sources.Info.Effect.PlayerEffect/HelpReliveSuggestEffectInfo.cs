using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class HelpReliveSuggestEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		int ruleModel = room.GetRuleModel();
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (player.IsDead() && player.basicInfo.Cid != myPlayerEntity.basicInfo.Cid && player.HasState(524288))
		{
			if (!RuleUtilty.ShowRpgHelpRelive(ruleModel))
			{
				return false;
			}
			if (player.GetTeam() != Contexts.sharedInstance.player.cameraOwnerEntity.GetTeam())
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("HelpRelive");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { 12, 100 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(HelpReliveSuggestRender);
	}

	public override bool IsEffectOnPlayerDead()
	{
		return true;
	}
}
