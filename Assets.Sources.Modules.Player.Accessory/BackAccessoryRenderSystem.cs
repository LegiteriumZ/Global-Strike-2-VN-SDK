using System;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Assets.Sources.Utils.ComponentInit;
using Entitas;
using PigeonCoopToolkit.Effects.Trails;
using SSJJAnim.AnimData;
using SSJJAnim.Animator;
using SSJJBase.Logger;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Accessory;

public class BackAccessoryRenderSystem : IRenderSystem
{
	private IGroup<PlayerEntity> _group;

	private TimeContext _timeContext;

	private TimeComponent _time;

	private LoggerAdapter _logger = new LoggerAdapter(typeof(BackAccessoryRenderSystem));

	public BackAccessoryRenderSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_time = _timeContext.time;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects).NoneOf(PlayerMatcher.LoadThirdPersonResource, PlayerMatcher.LoadAccessoryResource, PlayerMatcher.LoadBackWeaponResource));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			if (item.hasBackWeaponUnityObjects)
			{
				string value = item.basicInfo.Current.BackWeapon;
				if (item.basicInfo.Current.HasC4 && item.currentWeapon.Name != "c4")
				{
					value = "c4";
				}
				IAccessoryRenderComponent render = item.backWeaponUnityObjects.Render;
				render.getGameObject().SetActive(value: true);
				if (item.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_IN_CONTROL.ID))
				{
					render.getGameObject().SetActive(value: false);
				}
				if (item.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) || item.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID))
				{
					render.getGameObject().SetActive(value: false);
				}
				if (!render.getName().Equals(value))
				{
					PlayerEntityUtility.CleanupBackWeaponUnityObjects(item);
				}
				else
				{
					Update(item, ref item.backWeaponUnityObjects.Render);
				}
			}
			if (item.hasBackAccessoryUnityObjects)
			{
				IAccessoryRenderComponent render2 = item.backAccessoryUnityObjects.Render;
				bool flag = !item.hasBackWeaponUnityObjects;
				if (render2.getGameObject().IsActiveSelf() != flag)
				{
					render2.getGameObject().SetObjectActive(flag);
				}
				render2.getGameObject().SetActive(value: true);
				if (item.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) || item.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID))
				{
					render2.getGameObject().SetActive(value: false);
				}
				if (flag)
				{
					Update(item, ref item.backAccessoryUnityObjects.Render);
				}
			}
		}
	}

	private void UpdateTrail(PlayerEntity player, ref IAccessoryRenderComponent backAccessory)
	{
		if (backAccessory.getCustomRender() == null || !(backAccessory.getCustomRender() is TrailRenderer_Base[] array))
		{
			return;
		}
		TrailRenderer_Base[] array2 = array;
		foreach (TrailRenderer_Base trailRenderer_Base in array2)
		{
			if ((bool)trailRenderer_Base)
			{
				if (!player.hasTorseAnim)
				{
					trailRenderer_Base.Emit = false;
				}
				else
				{
					trailRenderer_Base.Emit = player.torseAnim.Equals(206);
				}
			}
		}
	}

	private void UpdateAnim(PlayerEntity player, ref IAccessoryRenderComponent backAccessory)
	{
		if (backAccessory.getSjAnimator() == null || backAccessory.getAnimList() == null)
		{
			return;
		}
		SJAnimator sJAnimator = backAccessory.getSjAnimator() as SJAnimator;
		if (backAccessory.getAnimList() is AccessoryInfoXml accessoryInfoXml && sJAnimator != null)
		{
			string animation = AccessoryRenderUtlity.GetAnimation(player, accessoryInfoXml);
			bool isVisiable = !player.hasVisiable || player.visiable.IsVisiable || player.visiable.IsNear;
			AnimationDesc accessoryAnimation = accessoryInfoXml.GetAccessoryAnimation(animation);
			if (accessoryAnimation != null)
			{
				sJAnimator.PlayAtFixedTime(0, accessoryAnimation.EventName, (float)backAccessory.getAnimCurrentTime() / 1000f, 1f, accessoryAnimation.IsLoop, isReverse: false, 0f, isVisiable);
				backAccessory.setAnimCurrentTime(backAccessory.getAnimCurrentTime() + _time.FrameInterval);
			}
		}
	}

	private void UpdateParticle(PlayerEntity player, ref IAccessoryRenderComponent backAccessory)
	{
		IPaticlePrefabInstancecs[] patricles = backAccessory.getPatricles();
		for (int i = 0; i < patricles.Length; i++)
		{
			AccessoryParticleInstance accessoryParticleInstance = patricles[i] as AccessoryParticleInstance;
			if (!accessoryParticleInstance)
			{
				continue;
			}
			GameObject gameObject = accessoryParticleInstance.gameObject;
			bool flag = false;
			if (AccessoryRenderUtlity.IsWingByName(backAccessory.getName()))
			{
				string accessoryDyeingColorStr = AccessoryRenderUtlity.getAccessoryDyeingColorStr(player);
				if (accessoryDyeingColorStr != accessoryParticleInstance.AccessoryDyeingColor)
				{
					accessoryParticleInstance.AccessoryDyeingColor = accessoryDyeingColorStr;
					Color particleDyeingColor = AccessoryRenderUtlity.getParticleDyeingColor(accessoryParticleInstance.AccessoryDyeingColor);
					accessoryParticleInstance.updateDyeingColor(particleDyeingColor);
				}
			}
			AccessoryParticleInstance.MatrixData matrixData = default(AccessoryParticleInstance.MatrixData);
			for (int j = 0; j < accessoryParticleInstance.DataList.Count; j++)
			{
				AccessoryParticleInstance.MatrixData matrixData2 = accessoryParticleInstance.DataList[j];
				flag = true;
				if ((matrixData2.Name.Equals("man", StringComparison.OrdinalIgnoreCase) && !player.basicInfo.CareerInfo.IsFemale) || matrixData2.Name.Equals(player.basicInfo.CareerInfo.Name, StringComparison.OrdinalIgnoreCase))
				{
					matrixData = matrixData2;
					break;
				}
				if ((matrixData2.Name.Equals("woman", StringComparison.OrdinalIgnoreCase) && player.basicInfo.CareerInfo.IsFemale) || matrixData2.Name.Equals(player.basicInfo.CareerInfo.Name, StringComparison.OrdinalIgnoreCase))
				{
					matrixData = matrixData2;
					break;
				}
				matrixData = matrixData2;
			}
			if (flag)
			{
				gameObject.transform.localPosition = matrixData.ConfigPosition;
				if (RuleUtilty.IsAvatarUltimateChallenge())
				{
					gameObject.transform.localRotation = matrixData.ConfigRotation * Quaternion.Euler(new Vector3(0f, -90f, -90f));
				}
				else
				{
					gameObject.transform.localRotation = matrixData.ConfigRotation;
				}
				gameObject.transform.localScale = matrixData.ConfigScale;
			}
		}
	}

	private void Update(PlayerEntity player, ref IAccessoryRenderComponent backAccessory)
	{
		UpdateTrail(player, ref backAccessory);
		UpdateAnim(player, ref backAccessory);
		UpdateParticle(player, ref backAccessory);
	}
}
