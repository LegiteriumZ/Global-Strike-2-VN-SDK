using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class VariationMonsterEffectInfo : IPlayerShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		string career = player.GetCareer();
		if (!string.IsNullOrEmpty(career))
		{
			if (!career.Equals("chicken", StringComparison.OrdinalIgnoreCase) && !career.Equals("pig", StringComparison.OrdinalIgnoreCase))
			{
				return career.Equals("cat", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(VariationMonsterEffectRender);
	}
}
