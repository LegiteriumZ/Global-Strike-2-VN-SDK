using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class ArmamentJxldIconRender : AbstractPlayerEffectRender
{
	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		EffectObject = effectGameObject;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, GetHeight(targetPlayer));
	}
}
