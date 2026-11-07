using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render.ViewRender;

namespace Assets.Sources.Info.Effect.PlayerEffect.ViewEffectInfo;

public class PlayerHeroGuanZiViewEffectInfo : IPlayerViewShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!string.IsNullOrEmpty(player.GetCareer()))
		{
			return player.GetCareer().Equals("hero_guanzi");
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(PlayerHeroGuanZiViewRender);
	}
}
