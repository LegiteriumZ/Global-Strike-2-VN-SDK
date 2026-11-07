using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class RemoteVariantGunFireEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return PlayerCareerConstantUtility.IsRemoteVariant(player.GetCareer());
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("RemoteVariantGunFire");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(RemoteVariantGunFireRender);
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}
}
