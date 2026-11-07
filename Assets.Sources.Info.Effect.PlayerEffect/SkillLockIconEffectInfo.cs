using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class SkillLockIconEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.skill.Status.ContainsKey(PlayerInfoStatusConstant.SKY_DEAGLE_SKILL_LOCKED.ID);
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("SkillLockIcon");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(SkillLockIconRender);
	}
}
