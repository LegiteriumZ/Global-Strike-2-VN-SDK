using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class DefaultPlayerNoEffectRender : AbstractPlayerEffectRender
{
	public override Vector3 GetScale(PlayerEntity targetPlayer, SceneObjectEntity effectEntity, IBattleRoom battleRoom)
	{
		return effectEntity.scale.Scale;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}
}
