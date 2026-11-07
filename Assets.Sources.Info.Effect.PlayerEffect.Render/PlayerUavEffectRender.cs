using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerUavEffectRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return new Vector3(0f, 0f, PlayerCareerConstantUtility.GetHeight(targetPlayer.GetCareer()));
	}
}
