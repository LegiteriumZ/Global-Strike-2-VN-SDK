using System;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Entitas;
using SSJJAnim.AnimData;
using SSJJAnim.Animator;

namespace Assets.Sources.Modules.Player.Accessory;

internal class ViewAccessoryRenderSystem : IRenderSystem
{
	private readonly IGroup<PlayerEntity> _group;

	private readonly TimeComponent _time;

	public ViewAccessoryRenderSystem(Contexts contexts)
	{
		_time = contexts.time.time;
		_group = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.ViewAccessory));
	}

	public void OnRender()
	{
		foreach (PlayerEntity item in _group)
		{
			for (int i = 0; i < item.viewAccessory.Renders.Count; i++)
			{
				IAccessoryRenderComponent accessory = item.viewAccessory.Renders[i];
				if (accessory.getGameObject().IsActiveSelf())
				{
					string animationStr = Update(item, ref accessory);
					UpdateVisiable(item, animationStr, accessory);
					item.viewAccessory.Renders[i] = accessory;
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
				string animation = AccessoryRenderUtlity.GetAnimation(player);
				AnimationDesc accessoryAnimation = accessoryInfoXml.GetAccessoryAnimation(animation);
				bool isVisiable = !player.hasVisiable || player.visiable.IsVisiable || player.visiable.IsNear;
				if (accessoryAnimation != null)
				{
					sJAnimator.PlayAtFixedTime(0, accessoryAnimation.EventName, (float)backAccessory.getAnimCurrentTime() / 1000f, 1f, isLoop: true, isReverse: false, 0f, isVisiable);
					backAccessory.setAnimCurrentTime(backAccessory.getAnimCurrentTime() + _time.FrameInterval);
					return animation;
				}
			}
		}
		return "";
	}

	private void UpdateVisiable(PlayerEntity player, string animationStr, IAccessoryRenderComponent accessory)
	{
		IPaticlePrefabInstancecs[] patricles = accessory.getPatricles();
		for (int i = 0; i < patricles.Length; i++)
		{
			PaticlePrefabInstancecs paticlePrefabInstancecs = patricles[i] as PaticlePrefabInstancecs;
			if (paticlePrefabInstancecs.PlayerInfoEffect.StatusId > 0)
			{
				paticlePrefabInstancecs.SetInsActive(player.HasStatus(paticlePrefabInstancecs.PlayerInfoEffect.StatusId));
			}
		}
	}

	private string Update(PlayerEntity player, ref IAccessoryRenderComponent accessory)
	{
		string result = "";
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
				accessory.getGameObject().transform.localPosition = matrixData.ConfigPosition;
				accessory.getGameObject().transform.localRotation = matrixData.ConfigRotation;
				accessory.getGameObject().transform.localScale = matrixData.ConfigScale;
				result = UpdateAnim(player, ref accessory);
			}
		}
		return result;
	}
}
