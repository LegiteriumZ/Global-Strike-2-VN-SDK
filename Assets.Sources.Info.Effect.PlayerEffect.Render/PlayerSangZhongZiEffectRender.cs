using System;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerSangZhongZiEffectRender : AbstractPlayerShowEffectRender
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
		if (skin.Equals("player_particle_effect1"))
		{
			if (player.torseAnim.TorsoAnimInfo.StateId == 65)
			{
				return 1;
			}
			return 0;
		}
		return 0;
	}
}
