using System;
using Assets.Sources.Components.Interface;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class VariationMonsterEffectRender : AbstractPlayerShowEffectRender
{
	protected Func<PlayerEntity, string, string, int> Func;

	public override void Init(PlayerEntity player)
	{
	}

	public override void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		SetParticleActiveParticleNameGenIndexOf(targetPlayer, "wangguan", targetPlayer.HasStatus(PlayerInfoStatusConstant.WANGGUAN_ON.ID));
	}
}
