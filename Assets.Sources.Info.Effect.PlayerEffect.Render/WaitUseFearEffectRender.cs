using Assets.Sources.Components.Interface;
using SSJJBase.Extensions;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class WaitUseFearEffectRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		EffectObject.transform.SetSsjjRotationZ(targetPlayer.GetViewYaw());
		EffectObject.transform.SetSsjjRotationY(0f - targetPlayer.GetViewPitch());
	}
}
