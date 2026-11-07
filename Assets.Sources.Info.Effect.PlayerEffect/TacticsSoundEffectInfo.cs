using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class TacticsSoundEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (player.GetTacticsSoundTime() > 0 && player.hasThirdPersonUnityObjects)
		{
			return player.thirdPersonUnityObjects.ThirdTran.RootContainer.activeSelf;
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("TacticsSound");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[3] { -1, -2, -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(TacticsSoundEffectRender);
	}
}
