using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render.ViewRender;

namespace Assets.Sources.Info.Effect.PlayerEffect.ViewEffectInfo;

public class PlayerHeroSangZhongViewEffectInfo : IPlayerViewShowEffectInfo
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
		return typeof(PlayerHeroSangZhongViewRender);
	}
}
