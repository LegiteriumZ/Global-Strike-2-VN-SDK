using System;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render.ViewRender;

public class PlayerHeroGuanZiViewRender : AbstractPlayerViewShowEffectRender
{
	protected Func<PlayerEntity, string, string, int> Func;

	public override void Init(PlayerEntity player)
	{
	}

	public override void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (Func == null)
		{
			Func = SetEffectFlag;
		}
		SetParticleActiveBySkinName(targetPlayer, SetEffectFlag);
	}

	private int SetEffectFlag(PlayerEntity player, string skin, string particle)
	{
		if (skin.Equals("player_particle_effect2"))
		{
			if (player.viewAnim.ViewAnimInfo.StateId == 63 || player.viewAnim.ViewAnimInfo.StateId == 65 || player.viewAnim.ViewAnimInfo.StateId == 15)
			{
				return 1;
			}
			return 0;
		}
		return 1;
	}
}
