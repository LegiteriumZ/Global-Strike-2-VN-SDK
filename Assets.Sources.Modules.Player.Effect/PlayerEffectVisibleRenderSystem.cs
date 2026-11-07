using Assets.Sources.Framework;
using Entitas;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

public class PlayerEffectVisibleRenderSystem : IRenderSystem
{
	private readonly IGroup<PlayerEntity> _group;

	public PlayerEffectVisibleRenderSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.LegAnim).NoneOf(PlayerMatcher.Destroy, PlayerMatcher.ThirdPersonGPUAnim));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			bool inLaserAttack = item.GetPlayerInfo().InLaserAttack;
			Transform bone = item.thirdPersonUnityObjects.Animator.GetBone("leishe");
			if (bone != null && bone.gameObject.IsActiveSelf() != inLaserAttack)
			{
				bone.gameObject.SetObjectActive(inLaserAttack);
			}
			if (item.legAnim.LegsAnimInfo != null)
			{
				bool flag = item.legAnim.LegsAnimInfo.StateId == 27 || item.legAnim.LegsAnimInfo.StateId == 50 || item.legAnim.LegsAnimInfo.StateId == 54 || item.legAnim.LegsAnimInfo.StateId == 54 || item.legAnim.LegsAnimInfo.StateId == 68 || item.legAnim.LegsAnimInfo.StateId == 53 || item.legAnim.LegsAnimInfo.StateId == 52 || item.legAnim.LegsAnimInfo.StateId == 51;
				Transform bone2 = item.thirdPersonUnityObjects.Animator.GetBone("Plane01");
				Transform bone3 = item.thirdPersonUnityObjects.Animator.GetBone("Plane02");
				if (bone2 != null && bone2.gameObject.IsActiveSelf() != flag)
				{
					bone2.gameObject.SetObjectActive(flag);
				}
				if (bone3 != null && bone3.gameObject.IsActiveSelf() != flag)
				{
					bone3.gameObject.SetObjectActive(flag);
				}
			}
		}
	}
}
