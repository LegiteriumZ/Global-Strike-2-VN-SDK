using System;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Assets.Sources.Utils.Accessory;
using Entitas;
using SSJJAnim.AnimData;
using SSJJAnim.Animator;
using SSJJBase.Singleton;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Accessory;

internal class WaistJewelryAccessoryRenderSystem : IRenderSystem
{
	private readonly IGroup<PlayerEntity> _group;

	private readonly TimeComponent _time;

	public WaistJewelryAccessoryRenderSystem(Contexts contexts)
	{
		_time = contexts.time.time;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonUnityObjects, PlayerMatcher.WaistJewelryAccessory));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			for (int i = 0; i < item.waistJewelryAccessory.Renders.Count; i++)
			{
				IAccessoryRenderComponent accessory = item.waistJewelryAccessory.Renders[i];
				accessory.getGameObject().SetActive(value: true);
				if (item.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) || item.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID))
				{
					accessory.getGameObject().SetActive(value: false);
				}
				if (accessory.getGameObject().transform.name == "backaccessory" && item.HasStatus(PlayerInfoStatusConstant.THUNDER_LEGEND_IN_CONTROL.ID) && accessory.getName() != "thunder_legend_back" && accessory.getName() != "thunder_legend_back_break" && accessory.getName() != "thunder_legend_back_sky" && accessory.getName() != "thunder_legend_back_mix" && accessory.getName() != "wind_trans_shortbow_back" && accessory.getName() != "wind_trans_shortbow_back1" && accessory.getName() != "wind_trans_shortbow_back_gold" && accessory.getName() != "wind_trans_shortbow_back_fire")
				{
					accessory.getGameObject().SetActive(value: false);
				}
				if (accessory.getGameObject().IsActiveSelf())
				{
					string animationStr = Update(item, ref accessory);
					UpdateVisiable(item, animationStr, accessory);
					UpdatePosition(item, animationStr, accessory);
					UpdateParticle(item, ref accessory);
					item.waistJewelryAccessory.Renders[i] = accessory;
				}
			}
		}
	}

	private void UpdateParticle(PlayerEntity player, ref IAccessoryRenderComponent backAccessory)
	{
		if (!AccessoryRenderUtlity.IsWingByName(backAccessory.getName()))
		{
			return;
		}
		IPaticlePrefabInstancecs[] patricles = backAccessory.getPatricles();
		for (int i = 0; i < patricles.Length; i++)
		{
			AccessoryParticleInstance accessoryParticleInstance = patricles[i] as AccessoryParticleInstance;
			if ((bool)accessoryParticleInstance)
			{
				_ = accessoryParticleInstance.gameObject;
				string accessoryDyeingColorStr = AccessoryRenderUtlity.getAccessoryDyeingColorStr(player);
				if (accessoryDyeingColorStr != accessoryParticleInstance.AccessoryDyeingColor)
				{
					accessoryParticleInstance.AccessoryDyeingColor = accessoryDyeingColorStr;
					Color particleDyeingColor = AccessoryRenderUtlity.getParticleDyeingColor(accessoryParticleInstance.AccessoryDyeingColor);
					accessoryParticleInstance.updateDyeingColor(particleDyeingColor);
				}
			}
		}
	}

	private string UpdateAnim(PlayerEntity player, ref IAccessoryRenderComponent backAccessory)
	{
		if (backAccessory.getSjAnimator() != null && backAccessory.getAnimList() != null)
		{
			SJAnimator sJAnimator = backAccessory.getSjAnimator() as SJAnimator;
			if (backAccessory.getAnimList() is AccessoryInfoXml accessoryInfoXml && sJAnimator != null)
			{
				string text = AccessoryRenderUtlity.GetAnimation(player, accessoryInfoXml);
				if (backAccessory.getName().Equals("skate_21_01") || backAccessory.getName().Equals("skate_21_02") || backAccessory.getName().Equals("skate_21_03") || backAccessory.getName().Equals("skate_21_04") || backAccessory.getName().Equals("skate_21_05") || backAccessory.getName().Equals("skate_21_06") || backAccessory.getName().Equals("skate_21_08") || backAccessory.getName().Equals("skate_21_09") || backAccessory.getName().Equals("skate_21_10") || backAccessory.getName().Equals("skate_21_07"))
				{
					text = AccessoryRenderUtlity.GetSkateAnimation(player);
				}
				if (backAccessory.getName() == "jijiazhuangjia")
				{
					text = AccessoryRenderUtlity.GetJiJiaZhuangjiaAnimation(player);
				}
				if (backAccessory.getName() == "thunder_legend_back" || backAccessory.getName() == "thunder_legend_back_break" || backAccessory.getName() == "thunder_legend_back_sky" || backAccessory.getName() == "thunder_legend_back_mix" || backAccessory.getName() == "wind_trans_shortbow_back" || backAccessory.getName() == "wind_trans_shortbow_back1" || backAccessory.getName() == "wind_trans_shortbow_back_gold" || backAccessory.getName() == "wind_trans_shortbow_back_fire")
				{
					text = AccessoryRenderUtlity.GetThunderLegnedBackAnimation(player);
				}
				if (backAccessory.getName() == "nezha_01" || backAccessory.getName() == "nezha_02" || backAccessory.getName() == "nezhahj_01" || backAccessory.getName() == "nezhahj_02")
				{
					text = AccessoryRenderUtlity.GetNezhaAnimation(player, backAccessory.getName());
				}
				if (backAccessory.getName() == "ares_02" || backAccessory.getName() == "ares_03" || backAccessory.getName() == "ares_05" || backAccessory.getName() == "ares_06")
				{
					text = AccessoryRenderUtlity.GetAresAnimation(player, backAccessory.getName());
				}
				if (backAccessory.getName() == "julong_wing_juxing_open")
				{
					text = AccessoryRenderUtlity.GetJuxingWingAnimation(player, backAccessory.getName());
				}
				AnimationDesc accessoryAnimation = accessoryInfoXml.GetAccessoryAnimation(text);
				bool isVisiable = !player.hasVisiable || player.visiable.IsVisiable || player.visiable.IsNear;
				if (accessoryAnimation != null)
				{
					if (backAccessory.getAnimationName() != accessoryAnimation.EventName)
					{
						backAccessory.setAnimCurrentTime(0);
					}
					sJAnimator.PlayAtFixedTime(0, accessoryAnimation.EventName, (float)backAccessory.getAnimCurrentTime() / 1000f, 1f, isLoop: true, isReverse: false, 0f, isVisiable);
					backAccessory.setAnimCurrentTime(backAccessory.getAnimCurrentTime() + _time.FrameInterval);
					backAccessory.setAnimationName(accessoryAnimation.EventName);
					return text;
				}
			}
		}
		return "";
	}

	private void UpdateVisiable(PlayerEntity player, string animationStr, IAccessoryRenderComponent accessory)
	{
		IPaticlePrefabInstancecs[] patricles = accessory.getPatricles();
		foreach (IPaticlePrefabInstancecs paticlePrefabInstancecs in patricles)
		{
			if (paticlePrefabInstancecs == null || !(paticlePrefabInstancecs.getInstance() != null))
			{
				continue;
			}
			if (!string.IsNullOrEmpty(paticlePrefabInstancecs.getAccessoryAnimation()))
			{
				paticlePrefabInstancecs.SetInsActive(paticlePrefabInstancecs.getAccessoryAnimation().Equals(animationStr));
				continue;
			}
			if (paticlePrefabInstancecs.getVisibleState() != 0)
			{
				paticlePrefabInstancecs.SetInsActive((player.GetCurrentWeaponEffectLevel() & (1 << (int)(paticlePrefabInstancecs.getVisibleState() - 1))) > 0);
			}
			if (paticlePrefabInstancecs is AccessoryStatusParticleInstance)
			{
				bool flag = player.HasPlayerInfo((paticlePrefabInstancecs as AccessoryStatusParticleInstance).StatusId);
				if ((paticlePrefabInstancecs as AccessoryStatusParticleInstance).isNot)
				{
					flag = !flag;
				}
				paticlePrefabInstancecs.SetInsActive(flag);
			}
		}
	}

	private void UpdatePosition(PlayerEntity player, string animationStr, IAccessoryRenderComponent accessory)
	{
		IPaticlePrefabInstancecs[] patricles = accessory.getPatricles();
		foreach (IPaticlePrefabInstancecs paticlePrefabInstancecs in patricles)
		{
			if (!(paticlePrefabInstancecs.GetIns() == null) && paticlePrefabInstancecs.GetInsActiveState())
			{
				PaticlePrefabInstancecs paticlePrefabInstancecs2 = paticlePrefabInstancecs as PaticlePrefabInstancecs;
				if (paticlePrefabInstancecs2 != null && paticlePrefabInstancecs2.GetOrientationRate() > 0f)
				{
					paticlePrefabInstancecs2.transform.localRotation = Quaternion.Euler(0f, player.GetViewPitch() * paticlePrefabInstancecs2.GetOrientationRate() * 57.3f, 0f);
				}
				AccessoryParticleInstance accessoryParticleInstance = paticlePrefabInstancecs as AccessoryParticleInstance;
				if (accessoryParticleInstance != null && accessoryParticleInstance.isSole)
				{
					accessoryParticleInstance.GetIns().transform.position = VectorCoordConverter.SsjjToUnity(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()));
					accessoryParticleInstance.GetIns().transform.rotation = Quaternion.identity;
				}
			}
		}
	}

	private string Update(PlayerEntity player, ref IAccessoryRenderComponent accessory)
	{
		IPaticlePrefabInstancecs[] patricles = accessory.getPatricles();
		for (int i = 0; i < patricles.Length; i++)
		{
			AccessoryParticleInstance accessoryParticleInstance = patricles[i] as AccessoryParticleInstance;
			if (!accessoryParticleInstance)
			{
				continue;
			}
			bool flag = false;
			AccessoryParticleInstance.MatrixData matrixData = default(AccessoryParticleInstance.MatrixData);
			for (int j = 0; j < accessoryParticleInstance.DataList.Count; j++)
			{
				AccessoryParticleInstance.MatrixData matrixData2 = accessoryParticleInstance.DataList[j];
				if (matrixData2.Name.Equals(player.basicInfo.CareerInfo.Name, StringComparison.OrdinalIgnoreCase))
				{
					flag = true;
					matrixData = matrixData2;
					break;
				}
			}
			if (!flag)
			{
				for (int k = 0; k < accessoryParticleInstance.DataList.Count; k++)
				{
					AccessoryParticleInstance.MatrixData matrixData3 = accessoryParticleInstance.DataList[k];
					flag = true;
					if (matrixData3.Name.Equals("man", StringComparison.OrdinalIgnoreCase) && !player.basicInfo.CareerInfo.IsFemale)
					{
						matrixData = matrixData3;
						break;
					}
					if (matrixData3.Name.Equals("woman", StringComparison.OrdinalIgnoreCase) && player.basicInfo.CareerInfo.IsFemale)
					{
						matrixData = matrixData3;
						break;
					}
					matrixData = matrixData3;
				}
			}
			if (flag)
			{
				float num = 1f;
				if (PlayerCareerUtil.IsHumanity(player.GetCareer()) && SingletonInstance<AccessoryHeadChangeParser>.Instance.GetAccessoryHeadChange(accessory.getName()))
				{
					num = 1f / player.thirdPersonUnityObjects.ThirdTran.HeadSize;
				}
				accessory.getGameObject().transform.localPosition = matrixData.ConfigPosition * num;
				accessory.getGameObject().transform.localRotation = matrixData.ConfigRotation;
				accessory.getGameObject().transform.localScale = matrixData.ConfigScale * num;
			}
		}
		return UpdateAnim(player, ref accessory);
	}
}
