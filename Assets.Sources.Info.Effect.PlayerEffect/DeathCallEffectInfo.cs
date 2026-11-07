using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class DeathCallEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!player.HasState(32))
		{
			return player.GetPlayerInfo().BeDeathCall;
		}
		return true;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("DeathCall");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { 7, 16 };
	}
}
