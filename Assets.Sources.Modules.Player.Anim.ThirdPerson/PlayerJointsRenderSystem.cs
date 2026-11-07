using System;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class PlayerJointsRenderSystem : FrameExecuteSystem, IRenderSystem
{
	private IGroup<PlayerEntity> _group;

	public PlayerJointsRenderSystem(Contexts contexts)
	{
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects).NoneOf(PlayerMatcher.Destroy));
	}

	public void OnRender()
	{
		if (!Frame())
		{
			return;
		}
		foreach (PlayerEntity item in _group)
		{
			foreach (ContorlJointsData contorlJoint in item.basicInfo.Current.ContorlJoints)
			{
				Transform bone = item.thirdPersonUnityObjects.Animator.GetBone(contorlJoint.JointName);
				if (!(bone != null) || (Mathf.Approximately(contorlJoint.RotationX, 0f) && Mathf.Approximately(contorlJoint.RotationY, 0f) && Mathf.Approximately(contorlJoint.RotationZ, 0f) && Mathf.Approximately(contorlJoint.Scale, 1f)))
				{
					continue;
				}
				float x = bone.localRotation.eulerAngles.x;
				float y = bone.localRotation.eulerAngles.y;
				float z = bone.localRotation.eulerAngles.z;
				Vector3 vector = new Vector3((0f - contorlJoint.RotationX) * 180f / (float)Math.PI, (0f - contorlJoint.RotationY) * 180f / (float)Math.PI, (0f - contorlJoint.RotationZ) * 180f / (float)Math.PI);
				if (item.thirdPersonUnityObjects.ThirdTran.BodyTransform.name.Equals("rpg_10004401"))
				{
					if (contorlJoint.RotationXSpecified)
					{
						x = vector.x;
					}
					if (contorlJoint.RotationYSpecified)
					{
						y = 0f - vector.z;
					}
					if (contorlJoint.RotationZSpecified)
					{
						z = vector.y;
					}
				}
				else
				{
					if (contorlJoint.RotationXSpecified)
					{
						x = vector.x;
					}
					if (contorlJoint.RotationYSpecified)
					{
						y = vector.y;
					}
					if (contorlJoint.RotationZSpecified)
					{
						z = vector.z;
					}
				}
				bone.localRotation = Quaternion.Euler(new Vector3(x, y, z));
				Vector3 one = Vector3.one;
				if (contorlJoint.ScaleSpecified)
				{
					bone.localScale = one * contorlJoint.Scale;
				}
				else
				{
					bone.localScale = one;
				}
			}
		}
	}
}
