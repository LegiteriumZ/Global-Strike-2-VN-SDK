using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerYingyagnHuanyinEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (player.isMyPlayer)
		{
			return false;
		}
		return player.HasPlayerInfo(PlayerInfoStatusConstant.YINYANG_GRENADE_STAY_IN_BIG_MIRROR.ID);
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		ICareerInfo careerInfo = player.basicInfo.CareerInfo;
		return new AssetInfo(careerInfo.PrefabBundleName, careerInfo.PrefabAssetName);
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -1 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(PlayerYingyangHuanyinEffectRender);
	}
}
