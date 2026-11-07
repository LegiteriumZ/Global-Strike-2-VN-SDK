using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Effect;

internal class ThirdKnifeEffectPlayBackSystem : IPlaybackSystem
{
	private readonly IGroup<PlayerEntity> _thirdGroup;

	public ThirdKnifeEffectPlayBackSystem(Contexts contexts)
	{
		_thirdGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.Fpos, PlayerMatcher.Orientation, PlayerMatcher.PunchSmooth, PlayerMatcher.TorseAnim, PlayerMatcher.CurrentWeapon, PlayerMatcher.ThirdPersonUnityObjects));
	}

	private void GetAnimPara(PlayerEntity entity, ref int animId, ref int currentTime, ref int during)
	{
		string career = entity.GetCareer();
		if (career.Equals("shadow_demon") || career.Equals("shadow_demon_scar"))
		{
			animId = entity.legAnim.LegsAnimInfo.StateId;
			currentTime = entity.legAnim.ScaledEclipsedTime;
			during = PlayerAnimationUtility.GetLegAnimDuration(entity, animId);
		}
		else
		{
			animId = entity.torseAnim.TorsoAnimInfo.StateId;
			currentTime = entity.torseAnim.EclipsedTime;
			during = PlayerAnimationUtility.GetTorseAnimDuration(entity, animId);
		}
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _thirdGroup)
		{
			if (item.torseAnim.TorsoAnimInfo == null)
			{
				continue;
			}
			int animId = 0;
			int currentTime = 0;
			int during = 0;
			GetAnimPara(item, ref animId, ref currentTime, ref during);
			if (during != 0)
			{
				currentTime %= during;
			}
			if (!item.hasThirdPersonUnityObjects || !(item.thirdPersonUnityObjects.KnifeEffectGameObject != null))
			{
				continue;
			}
			List<IKnifeAttackEffectControl> allKnifeEffectMbs = item.thirdPersonUnityObjects.AllKnifeEffectMbs;
			if (allKnifeEffectMbs == null)
			{
				continue;
			}
			foreach (IKnifeAttackEffectControl item2 in allKnifeEffectMbs)
			{
				KnifeAttackConfig config = (item2 as AbstractKnifeEffectMb).config;
				if (config == null)
				{
					continue;
				}
				if (config.Enable(animId, item.GetCurrentWeaponLevel(), currentTime, item.GetCurrentWeaponEffectLevel()))
				{
					GameObject knifeEffectGameObject = item.thirdPersonUnityObjects.KnifeEffectGameObject;
					VectorCoordConverter.SsjjToUnity(new Vector3
					{
						x = item.GetCompenstatePos(item.fpos.Change.GetPosIndex()).x,
						y = item.GetCompenstatePos(item.fpos.Change.GetPosIndex()).y,
						z = item.GetCompenstatePos(item.fpos.Change.GetPosIndex()).z + item.move.ViewHeightBase + item.viewHeight.ViewHeightSmoothRemain
					}, out var dest);
					knifeEffectGameObject.transform.position = dest;
					knifeEffectGameObject.transform.eulerAngles = YawPitchUtility.SsjjYawToUnityEularAngle(item.orientation.Yaw + item.punchSmooth.TempPunchYaw) + YawPitchUtility.SsjjPitchToUnityEularAngle(item.orientation.Pitch + item.punchSmooth.TempPunchPitch);
					if (item2 is KnifeAttackModelEffect)
					{
						item2.Play();
					}
					if (item2 is KnifeAttackParticleEffect)
					{
						item2.Play();
					}
				}
				else if (!config.CheckAnimEnable(animId))
				{
					if (item2 is KnifeAttackModelEffect)
					{
						item2.Stop();
					}
					if (item2 is KnifeAttackParticleEffect)
					{
						item2.Stop();
					}
				}
			}
		}
	}
}
