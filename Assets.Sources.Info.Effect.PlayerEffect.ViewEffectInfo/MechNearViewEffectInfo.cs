using System;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.Effect.PlayerEffect.Render.ViewRender;

namespace Assets.Sources.Info.Effect.PlayerEffect.ViewEffectInfo;

public class MechNearViewEffectInfo : IPlayerViewShowEffectInfo
{
	public bool IsEffectOn(PlayerEntity player, IBattleRoom room)
	{
		if (!string.IsNullOrEmpty(player.GetCareer()))
		{
			return player.GetCareer().Equals("mechnear");
		}
		return false;
	}

	public Type GetRenderType()
	{
		return typeof(MechNearViewEffectRender);
	}
}
