using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Framework.System;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;
using SSJJBase.Logger;
using SSJJMath;
using share.constant;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson.TPS;

public class TpsLegAnimSystem : FrameExecuteSystem, IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _players;

	private bool _isCanFrame;

	private const int RunMixTime = 500;

	public TpsLegAnimSystem(Contexts contexts)
	{
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.LegAnim));
		int raceType = contexts.battleRoom.roomData.Data.RaceType;
		_isCanFrame = !RuleUtilty.IsGroupModel(raceType) && !RuleUtilty.IsExplode(raceType);
	}

	public void OnPlayback()
	{
		OnRender();
	}

	public void OnRender()
	{
		foreach (PlayerEntity player in _players)
		{
			if (PlayerAnimationUtility.CheckIsTPSAnimSystem(player))
			{
				SetPlayerLegsAnim(player);
			}
		}
	}

	private void SetPlayerLegsAnim(PlayerEntity entity)
	{
		if (!entity.hasThirdPersonUnityObjects)
		{
			return;
		}
		ISjAnimatior animator = entity.thirdPersonUnityObjects.Animator;
		ILegAnimStateInfo legsAnimInfo = entity.legAnim.LegsAnimInfo;
		if (legsAnimInfo == null)
		{
			return;
		}
		float animSpeed = legsAnimInfo.GetAnimSpeed(entity.move.Velocity2D);
		int scaledEclipsedTime = entity.legAnim.ScaledEclipsedTime;
		string name = entity.currentWeapon.WeaponInfo.Name;
		string tPSLegAnimNameByWeapon = AnimationConstantUtility.GetTPSLegAnimNameByWeapon(animator.GetAnimations(), legsAnimInfo.StateId, name);
		animator.SetParameter("TPS", 1f);
		animator.SetParameter("PreInterval", 0f);
		if (entity.hasOrientation)
		{
			animator.SetParameter("ViewYaw", entity.orientation.Yaw);
			float num = YawPitchUtility.GetTpsMovedirAdjustment(entity.orientation.Yaw, entity.orientation.MoveYaw);
			animator.SetParameter("MoveDir", num);
			float parameter = animator.GetParameter("PreMoveDir");
			if (legsAnimInfo.StateId != 1)
			{
				animator.SetParameter("PreWeight0", 0f);
				animator.SetParameter("PreWeight1", 0f);
				animator.SetParameter("PreWeight2", 0f);
				animator.SetParameter("PreWeight3", 0f);
				animator.SetParameter("PreWeight4", 0f);
				animator.SetParameter("PreWeight5", 0f);
				animator.SetParameter("PreWeight6", 0f);
				animator.SetParameter("PreWeight7", 0f);
				animator.SetParameter("PreMoveDir", -1f);
				animator.SetParameter("PreInterval", 0f);
				animator.SetParameter("InRunMix", 0f);
				animator.SetParameter("InRunMixMoveDir", 0f);
			}
			else if (parameter == -1f)
			{
				animator.SetParameter("PreMoveDir", num);
				animator.SetParameter("PreInterval", 0f);
			}
			else if (animator.GetParameter("InRunMix") == 0f)
			{
				if (!YawPitchUtility.IsTpsMoveDirEqual(parameter, num))
				{
					animator.SetParameter("CurrentDirStartTime", entity.GetClientTime());
					animator.SetParameter("PreMoveDir", parameter);
					animator.SetParameter("InRunMix", 1f);
					animator.SetParameter("InRunMixMoveDir", num);
					animator.SetParameter("PreWeight0", animator.GetParameter("CurrentWeight0"));
					animator.SetParameter("PreWeight1", animator.GetParameter("CurrentWeight1"));
					animator.SetParameter("PreWeight2", animator.GetParameter("CurrentWeight2"));
					animator.SetParameter("PreWeight3", animator.GetParameter("CurrentWeight3"));
					animator.SetParameter("PreWeight4", animator.GetParameter("CurrentWeight4"));
					animator.SetParameter("PreWeight5", animator.GetParameter("CurrentWeight5"));
					animator.SetParameter("PreWeight6", animator.GetParameter("CurrentWeight6"));
					animator.SetParameter("PreWeight7", animator.GetParameter("CurrentWeight7"));
					animator.SetParameter("PreInterval", 1f);
				}
			}
			else
			{
				float parameter2 = animator.GetParameter("InRunMixMoveDir");
				if (YawPitchUtility.IsTpsMoveDirEqual(parameter2, num))
				{
					float parameter3 = animator.GetParameter("CurrentDirStartTime");
					float num2 = (float)entity.GetClientTime() - parameter3;
					if (num2 >= 500f)
					{
						animator.SetParameter("PreMoveDir", num);
						animator.SetParameter("InRunMix", 0f);
						animator.SetParameter("InRunMixMoveDir", 0f);
						animator.SetParameter("PreWeight0", animator.GetParameter("CurrentWeight0"));
						animator.SetParameter("PreWeight1", animator.GetParameter("CurrentWeight1"));
						animator.SetParameter("PreWeight2", animator.GetParameter("CurrentWeight2"));
						animator.SetParameter("PreWeight3", animator.GetParameter("CurrentWeight3"));
						animator.SetParameter("PreWeight4", animator.GetParameter("CurrentWeight4"));
						animator.SetParameter("PreWeight5", animator.GetParameter("CurrentWeight5"));
						animator.SetParameter("PreWeight6", animator.GetParameter("CurrentWeight6"));
						animator.SetParameter("PreWeight7", animator.GetParameter("CurrentWeight7"));
						animator.SetParameter("PreInterval", 1f);
					}
					else
					{
						float value = 1f - num2 / 500f;
						animator.SetParameter("PreInterval", value);
					}
				}
				else
				{
					animator.SetParameter("CurrentDirStartTime", entity.GetClientTime());
					animator.SetParameter("PreMoveDir", parameter2);
					animator.SetParameter("InRunMix", 1f);
					animator.SetParameter("InRunMixMoveDir", num);
					animator.SetParameter("PreWeight0", animator.GetParameter("CurrentWeight0"));
					animator.SetParameter("PreWeight1", animator.GetParameter("CurrentWeight1"));
					animator.SetParameter("PreWeight2", animator.GetParameter("CurrentWeight2"));
					animator.SetParameter("PreWeight3", animator.GetParameter("CurrentWeight3"));
					animator.SetParameter("PreWeight4", animator.GetParameter("CurrentWeight4"));
					animator.SetParameter("PreWeight5", animator.GetParameter("CurrentWeight5"));
					animator.SetParameter("PreWeight6", animator.GetParameter("CurrentWeight6"));
					animator.SetParameter("PreWeight7", animator.GetParameter("CurrentWeight7"));
					animator.SetParameter("PreInterval", 1f);
				}
			}
		}
		else
		{
			animator.SetParameter("MoveDir", 0f);
		}
		bool visiable = !entity.hasVisiable || entity.visiable.IsVisiable || entity.visiable.IsNear;
		if (!string.IsNullOrEmpty(tPSLegAnimNameByWeapon))
		{
			CheckSetAnimPos(entity, legsAnimInfo, entity.currentWeapon.WeaponInfo, entity.basicInfo.CareerInfo);
			animator.PlayAtFixedTime(0, tPSLegAnimNameByWeapon, (float)scaledEclipsedTime / 1000f, animSpeed, legsAnimInfo.IsLoop, isReverse: false, 0.1f, visiable);
		}
		else
		{
			this.LogErrorFormat("not found leg animation :{0}", legsAnimInfo.StateId);
		}
	}

	private void CheckSetAnimPos(PlayerEntity entity, ILegAnimStateInfo stateInfo, IEntitsWeaponInfo info, ICareerInfo careerInfo)
	{
		if (entity.hasMove && entity.isCameraOwner)
		{
			entity.move.AnimPosition = stateInfo.GetAnimPosition(info, careerInfo);
		}
	}
}
