using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.FirstPlayerEffect.Render;

namespace Assets.Sources.Info.Effect.FirstPlayerEffect;

public class CarboxylicEffectInfo : AbstractFirstPlayerEffectInfo
{
	public override bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (Contexts.sharedInstance.gameRule.hasMetalmanSkillData)
		{
			return Contexts.sharedInstance.gameRule.metalmanSkillData.AddMp < 0f;
		}
		return false;
	}

	protected override int[] GetSupportedRules()
	{
		return new int[1] { 6 };
	}

	protected override string GetPrefabName()
	{
		return "Carboxylic";
	}

	public override Type GetFirstRenderType()
	{
		return typeof(FaceFirstPlayerRender);
	}
}
