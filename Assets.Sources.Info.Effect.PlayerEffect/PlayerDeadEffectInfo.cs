using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using SSJJAsset.Asset;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerDeadEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		bool num = player.HasState(32) || player.GetPlayerInfo().BeDeathCall;
		int ruleModel = room.GetRuleModel();
		bool flag = player.IsDead() && player.HasState(524288) && RuleUtilty.IsPve(ruleModel) && ruleModel != 15001 && !RuleUtilty.IsMultipleRpg(ruleModel) && ruleModel != 15006;
		return num || flag;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("PlayerDead");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[2] { -2, -3 };
	}

	public override bool IsThirdEffectAlwaysDisplay()
	{
		return true;
	}

	public override bool IsEffectOnPlayerDead()
	{
		return true;
	}
}
