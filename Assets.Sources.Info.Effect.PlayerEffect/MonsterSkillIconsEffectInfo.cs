using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Info.Effect.PlayerEffect.Render;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using Sources.Utils.Ui;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class MonsterSkillIconsEffectInfo : AbstractPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		Dictionary<int, string> config = SingletonInstance<MonsterSkillIconsConfigParser>.Instance.GetConfig();
		if (config == null)
		{
			return false;
		}
		foreach (KeyValuePair<int, string> item in config)
		{
			if (player.skill.Status.ContainsKey(item.Key))
			{
				return true;
			}
		}
		return false;
	}

	public override AssetInfo GetThirdEffectAssetInfo(PlayerEntity player, int ruleModel)
	{
		return AssetBundleNameConstant.GetPlayerEffectPrefabAssetInfo("MonsterSkillIcons");
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { -3 };
	}

	public override Type GetThirdRenderType()
	{
		return typeof(MonsterSkillIconsRender);
	}
}
