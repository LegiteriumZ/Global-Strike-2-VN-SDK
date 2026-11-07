using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.FirstPlayerEffect.Render;

public class FaceFirstPlayerRender : AbstractFirstPlayerEffectRender
{
	private Transform _tran;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_tran = effectGameObject.transform.Find("carboxylic");
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Vector3 eulerAngles = _tran.eulerAngles;
		eulerAngles.y = 0f - targetPlayer.GetViewYaw();
		eulerAngles.x = 0f - targetPlayer.GetViewPitch();
		_tran.eulerAngles = eulerAngles;
	}
}
