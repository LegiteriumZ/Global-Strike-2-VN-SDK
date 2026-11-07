using System.Collections.Generic;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Components.Interface;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Assets.Sources.Player.UnityObjects;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.Weapon;
using Entitas;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Accessory;

public class ViewAccessoryLoadSystem : LoadAndInitResourceSystem<PlayerEntity>
{
	private readonly IGroup<PlayerEntity> _loadGroup;

	private readonly IGroup<PlayerEntity> _initGroup;

	private List<string> _accessoryList = new List<string>(8);

	public ViewAccessoryLoadSystem(Contexts contexts)
	{
		_loadGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.FirstPersonView).NoneOf(PlayerMatcher.PartBasicInfo, PlayerMatcher.LoadViewAccessoryResource, PlayerMatcher.ViewAccessoryResource));
		_initGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ViewAccessoryResource));
	}

	protected override IGroup<PlayerEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<PlayerEntity> GetInitGroup()
	{
		return _initGroup;
	}

	private bool CheckViewEqual(List<IAccessoryRenderComponent> renders, List<string> accessorys)
	{
		if (renders == null || accessorys == null)
		{
			return false;
		}
		if (renders.Count != accessorys.Count)
		{
			return false;
		}
		if (renders.Count == accessorys.Count)
		{
			for (int i = 0; i < renders.Count; i++)
			{
				if (renders[i].getName() == null || !renders[i].getName().Equals(accessorys[i]))
				{
					return false;
				}
			}
		}
		return true;
	}

	protected override void OnLoadEntityResource(PlayerEntity entity)
	{
		_accessoryList.Clear();
		foreach (string accessory in entity.basicInfo.Current.AccessoryList)
		{
			if (AccessoryConfigLoader.Instance.hasAccessoryIsView(accessory))
			{
				_accessoryList.Add(accessory);
			}
		}
		if (entity.hasViewAccessory && CheckViewEqual(entity.viewAccessory.Renders, _accessoryList))
		{
			return;
		}
		LoadRequests loadRequests = null;
		List<string> list = new List<string>();
		foreach (string accessory2 in _accessoryList)
		{
			string accessoryName = AccessoryNameUtility.GetAccessoryName(accessory2, entity.basicInfo.Current.Team);
			if (!string.IsNullOrEmpty(accessoryName))
			{
				if (loadRequests == null)
				{
					loadRequests = new LoadRequests();
				}
				if (!list.Contains(accessoryName))
				{
					AccessoryRenderUtlity.AddRequest(loadRequests, accessoryName);
					list.Add(accessoryName);
				}
			}
		}
		if (entity.hasFirstPersonUnityObjects && loadRequests != null && !entity.hasLoadViewAccessoryResource && !entity.hasViewAccessory && entity.firstPersonUnityObjects.WeaponGameObject != null)
		{
			entity.AddLoadViewAccessoryResource(loadRequests, entity);
		}
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		return entity.viewAccessoryResource.Identifier == entity;
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemoveViewAccessoryResource();
	}

	protected override void OnInitEntityResource(PlayerEntity entity)
	{
		if (!entity.isMyPlayer || entity.hasViewAccessory)
		{
			return;
		}
		foreach (string accessory in entity.basicInfo.Current.AccessoryList)
		{
			if (AccessoryConfigLoader.Instance.hasAccessoryIsView(accessory))
			{
				List<IAccessoryRenderComponent> list = new List<IAccessoryRenderComponent>();
				AccessoryRenderComponent? accessoryRenderComponent = AccessoryRenderUtlity.LoadResDone(entity, accessory, null, entity.viewAccessoryResource, LoadComp);
				if (accessoryRenderComponent.HasValue)
				{
					list.Add(accessoryRenderComponent.Value);
				}
				if (entity.hasViewAccessory)
				{
					entity.ReplaceViewAccessory(list);
				}
				else
				{
					entity.AddViewAccessory(list);
				}
			}
		}
	}

	private AccessoryRenderComponent LoadComp(GameObject model, Transform jointGameObject, PlayerEntity entity, string accessoryName, AccessoryInfoXml xml, AccessoryMatrixConfig.AccessoryMatrix matrix)
	{
		model.transform.SetParent(entity.firstPersonUnityObjects.HandCameraObject.transform, worldPositionStays: false);
		model.name = accessoryName;
		LayerUtility.SetLayerRecursively(model, LayerMask.NameToLayer("FPSArmWeapon"));
		SJAnimator sJAnimator = null;
		LoadResult loadResult = entity.viewAccessoryResource.LoadResults["modelAnim_" + accessoryName];
		if (loadResult.Object is SJAnimationAsset)
		{
			sJAnimator = model.TryAddComponent<SJAnimator>();
			sJAnimator.Init();
			sJAnimator.AddLayer(0, 1f);
			sJAnimator.AddAnimationClips(0, (loadResult.Object as SJAnimationAsset).Clips);
			sJAnimator.SetMultiThreadSupport(multi: false);
		}
		IPaticlePrefabInstancecs[] skins = null;
		WeaponUtility.GetParticles(model, ref skins);
		ParticleEffectUtility.InitAccessoryParticle(model, accessoryName);
		MeshRenderer[] componentsInChildren = model.GetComponentsInChildren<MeshRenderer>();
		Dictionary<string, TextureConfigItem> dictionary = null;
		if (entity.viewAccessoryResource.LoadResults.ContainsKey("textureConfig_" + accessoryName))
		{
			dictionary = ((TextureConfigInfo)entity.viewAccessoryResource.LoadResults["textureConfig_" + accessoryName].Object).TextureConfigs;
		}
		MeshRenderer meshRenderer = null;
		MeshRenderer[] array = componentsInChildren;
		foreach (MeshRenderer meshRenderer2 in array)
		{
			if (meshRenderer2 != null && meshRenderer2.enabled)
			{
				meshRenderer = meshRenderer2;
				break;
			}
		}
		if (dictionary != null && meshRenderer != null && meshRenderer.sharedMaterial != null && meshRenderer.sharedMaterial.mainTexture != null)
		{
			foreach (KeyValuePair<string, TextureConfigItem> item in dictionary)
			{
				if (item.Value.AlphaKill > 0)
				{
					meshRenderer.sharedMaterial.renderQueue = 2500;
				}
			}
		}
		return new AccessoryRenderComponent(accessoryName, model, sJAnimator, xml, skins);
	}
}
