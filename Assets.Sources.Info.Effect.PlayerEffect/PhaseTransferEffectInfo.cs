using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PhaseTransferEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		return player.GetPlayerInfo().Phasetransfer;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PhaseTransfer");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { 6 };
	}

	public override Vector3 GetConfigOffset(PlayerEntity playerEntity)
	{
		return new Vector3(0f, 0f, (float)PlayerCareerConstantUtility.GetHeight(playerEntity.GetCareer()) / 2f);
	}
}
