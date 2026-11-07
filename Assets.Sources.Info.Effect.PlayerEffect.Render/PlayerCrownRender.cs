using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class PlayerCrownRender : AbstractPlayerShowEffectRender
{
	private PaticlePrefabInstancecs _jointrender;

	public override void Init(PlayerEntity targetPlayer)
	{
		if (targetPlayer != null && _jointrender == null && targetPlayer.hasThirdPersonUnityObjects)
		{
			Transform bone = targetPlayer.thirdPersonUnityObjects.Animator.GetBone("bip01_head");
			if (bone != null)
			{
				_jointrender = bone.GetComponentInChildren<PaticlePrefabInstancecs>(includeInactive: true);
			}
		}
	}

	public override void Render(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		if (_jointrender == null)
		{
			Init(targetPlayer);
		}
		if (_jointrender != null && targetPlayer != null)
		{
			bool flag = targetPlayer.HasStatus(PlayerInfoStatusConstant.WANGGUAN_ON.ID);
			if (flag != _jointrender.gameObject.IsActiveSelf())
			{
				_jointrender.gameObject.SetObjectActive(flag);
			}
		}
	}
}
