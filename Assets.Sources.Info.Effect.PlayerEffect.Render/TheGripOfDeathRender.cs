using Assets.Sources.Components.Interface;
using SSJJBase.Extensions;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class TheGripOfDeathRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		EffectObject.transform.SetSsjjRotationZ(targetPlayer.GetViewRoll());
	}
}
