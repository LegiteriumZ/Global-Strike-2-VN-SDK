using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerFlySprintEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType != 17003 && player.HasState(256) && player.hasThirdPersonUnityObjects)
		{
			ISjAnimatior animator = player.thirdPersonUnityObjects.Animator;
			if (animator != null)
			{
				return animator.GetBone("flyeffect") != null;
			}
			return false;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerFlySprint");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { 29, 31 };
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerFlySprintRender);
	}
}
