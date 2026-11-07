using System;
using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class GuardianEffectRender : AbstractPlayerShowEffectRender
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
		bool flag = false;
		foreach (string accessory in player.basicInfo.Current.AccessoryList)
		{
			if (accessory.Equals("guardian_head") || accessory.Equals("guardian_head_gold"))
			{
				flag = true;
			}
		}
		if (skin.Equals("player_particle_effect7"))
		{
			if (flag)
			{
				return 0;
			}
			return -1;
		}
		return -1;
	}
}
