using Assets.Sources.Components.Interface;
using SSJJBase.Logger;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayeTailEffectRender : AbstractPlayerEffectRender
{
	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Transform bone = targetPlayer.GetBone("player_particle_effect1");
		if (bone == null)
		{
			this.LogErrorFormat("skin : {0}, career : {1}", targetPlayer.GetSkin(), targetPlayer.GetCareer());
		}
		return ((bone != null) ? VectorCoordConverter.UnityToSsjj(targetPlayer.GetBone("player_particle_effect1").position) : Vector3.zero) - targetPlayer.GetCompenstatePos(targetPlayer.fpos.Change.GetPosIndex());
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}
}
