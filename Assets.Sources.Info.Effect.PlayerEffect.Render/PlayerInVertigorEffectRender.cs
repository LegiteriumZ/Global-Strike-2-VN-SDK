using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerInVertigorEffectRender : AbstractPlayerEffectRender
{
	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, PlayerCareerConstantUtility.GetHeight(targetPlayer.GetCareer()));
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		EffectObject.transform.Rotate(new Vector3(0f, frameTime, 0f));
	}
}
