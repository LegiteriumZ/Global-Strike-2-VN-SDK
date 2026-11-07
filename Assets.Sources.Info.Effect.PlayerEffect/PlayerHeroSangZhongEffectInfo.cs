using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render;

namespace Assets.Sources.Info.Effect.PlayerEffect;

public class PlayerHeroSangZhongEffectInfo : IPlayerShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!string.IsNullOrEmpty(player.GetCareer()))
		{
			return player.GetCareer().Equals("hero_sangzhong");
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(PlayerSangZhongZiEffectRender);
	}
}
