using Assets.Sources.Components.Interface;
using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class WidlFireEffectRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		float viewYaw = battleRoom.GetMyPlayer().GetViewYaw();
		EffectObject.transform.SetSsjjRotationZ(viewYaw);
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		float z = EffectObject.transform.GetSsjjScaleY() * 0.5f + 70f;
		return new Vector3(0f, 0f, z);
	}
}
