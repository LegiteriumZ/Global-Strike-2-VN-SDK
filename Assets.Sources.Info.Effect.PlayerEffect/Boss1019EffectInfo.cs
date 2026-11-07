using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class Boss1019EffectInfo : IPlayerShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!string.IsNullOrEmpty(player.GetCareer()))
		{
			return player.GetCareer().Equals("boss1019");
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(Boss1019EffectRender);
	}
}
