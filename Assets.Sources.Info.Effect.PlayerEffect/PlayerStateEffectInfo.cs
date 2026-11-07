using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using NetData;
using SSJJAsset.Asset;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerStateEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		PlayerInfoData playerInfo = player.GetPlayerInfo();
		if (!playerInfo.InMark && !playerInfo.InFear && !playerInfo.InChaos && !playerInfo.InHuoYanXianJi && !player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_BOSS10_SHANDIANHUAN.ID) && !player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_INCHAOS.ID) && !player.skill.Status.ContainsKey(PlayerInfoStatusConstant.SYBIL_1019_SKILL_BADSTATE.ID))
		{
			return player.skill.Status.ContainsKey(PlayerInfoStatusConstant.RPG_INRAGE.ID);
		}
		return true;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerState");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { -2, -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerStateRender);
	}
}
