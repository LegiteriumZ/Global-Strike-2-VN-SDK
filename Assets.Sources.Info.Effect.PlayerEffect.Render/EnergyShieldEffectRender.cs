using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using UnityEngine;
using config;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class EnergyShieldEffectRender : AbstractPlayerEffectRender
{
	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}

	public override Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		Vector3 zero = Vector3.zero;
		if (PlayerCareerConstantUtility.IsEmpress(targetPlayer.GetCareer()))
		{
			zero.z = (float)BoundBoxConfig.GetBoundsMaxForNormalPlayer(targetPlayer.GetCareer()).z;
		}
		else
		{
			zero.z = (float)BoundBoxConfig.GetBoundsMaxForNormalPlayer(targetPlayer.GetCareer()).z * 0.5f;
		}
		return zero;
	}

	public override Vector3 GetScale(PlayerEntity targetPlayer, SceneObjectEntity effectEntity, IBattleRoom battleRoom)
	{
		Vector3 one = Vector3.one;
		if (!PlayerCareerConstantUtility.IsEmpress(targetPlayer.GetCareer()))
		{
			return one * 0.7f;
		}
		return one;
	}
}
