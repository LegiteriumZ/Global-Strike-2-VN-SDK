using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class Boss1023EffectInfo : IPlayerShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!string.IsNullOrEmpty(player.GetCareer()))
		{
			return player.GetCareer().Equals("boss1023");
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(Boss1023EffectRender);
	}
}
