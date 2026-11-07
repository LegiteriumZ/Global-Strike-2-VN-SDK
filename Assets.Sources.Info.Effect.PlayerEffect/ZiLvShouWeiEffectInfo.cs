using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class ZiLvShouWeiEffectInfo : IPlayerShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!string.IsNullOrEmpty(player.GetCareer()))
		{
			return player.GetCareer().Equals("rpg_zilvshouwei");
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(ZiLvShouWeiEffectRender);
	}
}
