using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class FacePlayerRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Vector3 eulerAngles = EffectObject.transform.eulerAngles;
		eulerAngles.y = 0f - targetPlayer.GetViewYaw();
		EffectObject.transform.eulerAngles = eulerAngles;
	}
}
