using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class AccelerateEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if ((HasPlayerEntityTailEffect(player.GetSkin()) || HasPlayerEntityTailEffect(player.basicInfo.Current.Career)) && player.isThirdView())
		{
			if (!player.hasThirdPersonUnityObjects || !player.thirdPersonUnityObjects.ThirdTran.RootContainer.activeSelf)
			{
				return false;
			}
			return true;
		}
		if (player.HasState(2) || player.GetPlayerInfo().Mp5mrSkillFlag > 0 || player.HasStatus(PlayerInfoStatusConstant.RPG_using_role1002.ID))
		{
			if (!player.hasThirdPersonUnityObjects || !player.thirdPersonUnityObjects.ThirdTran.RootContainer.activeSelf)
			{
				return false;
			}
			return true;
		}
		return false;
	}

	public static bool HasPlayerEntityTailEffect(string careerSkin)
	{
		switch (careerSkin)
		{
		case "longyin_jj":
		case "longyin_yh1_v4":
		case "longyin_yh1_v5":
			return true;
		default:
			return false;
		}
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("Accelerate");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[7] { 6, 11, -1, -2, -3, 24, 25 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(AccelerateEffectRender);
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}
}
