using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerSneakEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_qianxing_idle.ID) && !player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_qianxing_chakan.ID))
		{
			return player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_qianxing_faxian.ID);
		}
		return true;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerSneak");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerSneakRender);
	}
}
