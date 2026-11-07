using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Scripts.Effect.Level;
using Assets.Sources.Components.Interface;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Assets.Sources.Player.UnityObjects;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Accessory;
using Assets.Sources.Utils.ComponentInit;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.Weapon;
using Entitas;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using SSJJAnim.Player;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Accessory;

public class WaistJewelryAccessoryLoadSystem : LoadAndInitResourceSystem<PlayerEntity>
{
	private readonly IGroup<PlayerEntity> _loadGroup;

	private readonly IGroup<PlayerEntity> _initGroup;

	private List<string> _accessoryList = new List<string>(8);

	public WaistJewelryAccessoryLoadSystem(Contexts contexts)
	{
		_loadGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo).NoneOf(PlayerMatcher.PartBasicInfo, PlayerMatcher.LoadWaistJewelryAccessoryResource, PlayerMatcher.WaistJewelryAccessoryResource));
		_initGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.WaistJewelryAccessoryResource, PlayerMatcher.ThirdPersonUnityObjects));
	}

	protected override IGroup<PlayerEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<PlayerEntity> GetInitGroup()
	{
		return _initGroup;
	}

	private bool CheckInWaistJewelry(List<AccessoryRenderComponent> renders, string accessoryName)
	{
		if (renders != null)
		{
			foreach (AccessoryRenderComponent render in renders)
			{
				if (render.Name.Equals(accessoryName))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool CheckWaistJewelryEqual(List<IAccessoryRenderComponent> renders, List<string> accessorys)
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
		if (RuleUtilty.IsTpsMode() || GameSetting.Config.ShowThirdWeapon == 0)
		{
			return;
		}
		float headSize = 1f;
		_accessoryList.Clear();
		foreach (string accessory in entity.basicInfo.Current.AccessoryList)
		{
			if (!AccessoryConfigLoader.Instance.hasAccessoryIsView(accessory))
			{
				if (SingletonInstance<AccessoryHeadChangeParser>.Instance.GetAccessoryHeadChange(accessory) && entity.hasThirdPersonUnityObjects)
				{
					headSize = 0.001f;
				}
				if (entity.hasThirdPersonUnityObjects)
				{
					entity.thirdPersonUnityObjects.ThirdTran.HeadSize = headSize;
				}
				if (!string.IsNullOrEmpty(accessory))
				{
					_accessoryList.Add(accessory);
				}
			}
		}
		if (!string.IsNullOrEmpty(entity.basicInfo.Current.LegDecoration))
		{
			_accessoryList.Add(entity.basicInfo.Current.LegDecoration);
		}
		if (entity.hasWaistJewelryAccessory && CheckWaistJewelryEqual(entity.waistJewelryAccessory.Renders, _accessoryList))
		{
			return;
		}
		LoadRequests loadRequests = null;
		List<string> list = new List<string>();
		foreach (string accessory2 in _accessoryList)
		{
			string accessoryName = AccessoryNameUtility.GetAccessoryName(accessory2, entity.basicInfo.Current.Team);
			if (!string.IsNullOrEmpty(accessoryName) && (!entity.hasWaistJewelryAccessoryLoadList || !entity.waistJewelryAccessoryLoadList.FailedList.Contains(accessoryName)))
			{
				if (loadRequests == null)
				{
					loadRequests = new LoadRequests();
				}
				if (entity.hasBasicInfo)
				{
					_ = entity.basicInfo.Current.WingsColors;
				}
				AccessoryRenderUtlity.AddRequest(loadRequests, accessoryName);
				list.Add(accessoryName);
			}
		}
		PlayerEntityUtility.CleanupWaistJewelryUnityObjects(entity, isClearLoadedList: false);
		if (!entity.hasWaistJewelryAccessoryLoadList)
		{
			entity.AddWaistJewelryAccessoryLoadList(new List<string>(), new List<string>());
		}
		entity.waistJewelryAccessoryLoadList.LoadedList = list;
		if (loadRequests != null)
		{
			entity.AddLoadWaistJewelryAccessoryResource(loadRequests, entity);
		}
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		return entity.waistJewelryAccessoryResource.Identifier == entity;
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemoveWaistJewelryAccessoryResource();
	}

	protected override void OnInitEntityResource(PlayerEntity entity)
	{
		List<IAccessoryRenderComponent> list = new List<IAccessoryRenderComponent>();
		if (!entity.hasWaistJewelryAccessoryLoadList)
		{
			return;
		}
		foreach (string loaded in entity.waistJewelryAccessoryLoadList.LoadedList)
		{
			if (!string.IsNullOrEmpty(loaded))
			{
				AccessoryRenderComponent? accessoryRenderComponent = AccessoryRenderUtlity.LoadResDone(entity, loaded, "backaccessory", entity.waistJewelryAccessoryResource, LoadComp);
				if (accessoryRenderComponent.HasValue)
				{
					list.Add(accessoryRenderComponent.Value);
				}
				else
				{
					entity.waistJewelryAccessoryLoadList.FailedList.Add(loaded);
				}
			}
		}
		if (entity.hasWaistJewelryAccessory)
		{
			entity.ReplaceWaistJewelryAccessory(list);
		}
		else
		{
			entity.AddWaistJewelryAccessory(list);
		}
	}

	private AccessoryRenderComponent LoadComp(GameObject model, Transform jointGameObject, PlayerEntity entity, string accessoryName, AccessoryInfoXml xml, AccessoryMatrixConfig.AccessoryMatrix matrix)
	{
		model.transform.localPosition = Vector3.zero;
		model.transform.localRotation = Quaternion.identity;
		model.transform.localScale = Vector3.one;
		model.transform.SetParent(jointGameObject.transform, worldPositionStays: false);
		model.name = accessoryName;
		SJAnimator sJAnimator = null;
		AccessoryCache.AccessoryPath accessory = AccessoryCache.GetAccessory(accessoryName);
		LoadResult loadResult = entity.waistJewelryAccessoryResource.LoadResults[accessory.PrefabAnimRequest];
		if (loadResult.Object is SJAnimationAsset)
		{
			sJAnimator = model.TryAddComponent<SJAnimator>();
			sJAnimator.Init();
			if (accessoryName == "julong_wing_juxing_open")
			{
				model.GetComponent<SJAnimationPlayer>().AddMask("Dummy01", recursively: false);
			}
			sJAnimator.AddLayer(0, 1f);
			sJAnimator.AddAnimationClips(0, (loadResult.Object as SJAnimationAsset).Clips);
		}
		IPaticlePrefabInstancecs[] skins = null;
		WeaponUtility.GetParticles(model, ref skins);
		LodUtility.AddParticleLod(skins);
		LodUtility.AddMeshLod(entity, model, isFirstLoad: false);
		ParticleEffectUtility.InitAccessoryParticle(model, accessoryName);
		MeshRenderer[] componentsInChildren = model.GetComponentsInChildren<MeshRenderer>();
		Dictionary<string, TextureConfigItem> dictionary = null;
		AccessoryCache.AccessoryPath accessory2 = AccessoryCache.GetAccessory(accessoryName);
		if (entity.waistJewelryAccessoryResource.LoadResults.ContainsKey(accessory2.TextureConfigRequest))
		{
			dictionary = ((TextureConfigInfo)entity.waistJewelryAccessoryResource.LoadResults[accessory2.TextureConfigRequest].Object).TextureConfigs;
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
		if (AccessoryRenderUtlity.IsWingByName(accessoryName))
		{
			string accessoryDyeingColorStr = AccessoryRenderUtlity.getAccessoryDyeingColorStr(entity);
			Color particleDyeingColor = AccessoryRenderUtlity.getParticleDyeingColor(accessoryDyeingColorStr);
			IPaticlePrefabInstancecs[] array2 = skins;
			foreach (IPaticlePrefabInstancecs paticlePrefabInstancecs in array2)
			{
				if (paticlePrefabInstancecs is AccessoryParticleInstance)
				{
					AccessoryParticleInstance obj = paticlePrefabInstancecs as AccessoryParticleInstance;
					obj.AccessoryDyeingColor = accessoryDyeingColorStr;
					obj.updateDyeingColor(particleDyeingColor);
				}
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
