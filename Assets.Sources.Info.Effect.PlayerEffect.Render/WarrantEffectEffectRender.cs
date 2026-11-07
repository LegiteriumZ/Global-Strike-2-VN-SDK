using Assets.Sources.Components.Interface;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class WarrantEffectEffectRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}

	protected override void Reset(PlayerEntity player)
	{
		player.GetPlayerInfo().Warrant = false;
	}

	protected override int GetLifeTime()
	{
		return 500;
	}
}
