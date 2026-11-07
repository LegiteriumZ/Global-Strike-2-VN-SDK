using System.Collections.Generic;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Assets.Sources.Player.UnityObjects;
using Assets.Sources.Utils.ComponentInit;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.Weapon;
using Entitas;
using PigeonCoopToolkit.Effects.Trails;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Accessory;

public class BackAccessoryLoadSystem : LoadAndInitResourceSystem<PlayerEntity>, IPlaybackSystem
{
	private IGroup<PlayerEntity> _loadGroup;

	private IGroup<PlayerEntity> _initGroup;

	private PlayerContext _playerContext;

	private LoadRequests loadRequests;

	private HashSet<string> failedlist = new HashSet<string>();

	private LoggerAdapter _logger = new LoggerAdapter(typeof(BackAccessoryLoadSystem));

	public BackAccessoryLoadSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_loadGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo, PlayerMatcher.LoadThirdPersonResource).NoneOf(PlayerMatcher.PartBasicInfo, PlayerMatcher.LoadAccessoryResource, PlayerMatcher.AccessoryResource));
		_initGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.AccessoryResource, PlayerMatcher.ThirdPersonUnityObjects).NoneOf(PlayerMatcher.BackAccessoryUnityObjects));
	}

	protected override IGroup<PlayerEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<PlayerEntity> GetInitGroup()
	{
		return _initGroup;
	}

	public void OnPlayback()
	{
		foreach (PlayerEntity item in _playerContext)
		{
			OnLoadEntityResource(item);
		}
	}

	protected override void OnLoadEntityResource(PlayerEntity entity)
	{
		if (RuleUtilty.IsTpsMode() || GameSetting.Config.ShowThirdWeapon == 0 || !PlayerCareerUtil.IsHumanity(entity.GetCareer()))
		{
			return;
		}
		string accessoryName = AccessoryNameUtility.GetAccessoryName(entity.basicInfo.Current.BackAccessory, entity.basicInfo.Current.Team);
		if (string.IsNullOrEmpty(accessoryName))
		{
			if (entity.hasBackAccessoryUnityObjects)
			{
				PlayerEntityUtility.CleanupBackAccessoryUnityObjects(entity);
			}
			return;
		}
		string text = null;
		if (entity.hasBackAccessory)
		{
			text = entity.backAccessory.Name;
		}
		if (text != accessoryName || (!failedlist.Contains(accessoryName) && !entity.hasBackAccessoryUnityObjects && !entity.hasLoadAccessoryResource))
		{
			entity.ReplaceBackAccessory(accessoryName);
			if (loadRequests == null)
			{
				loadRequests = new LoadRequests();
			}
			AccessoryRenderUtlity.AddRequest(loadRequests, accessoryName);
			entity.AddLoadAccessoryResource(loadRequests, accessoryName);
		}
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		return (string)entity.accessoryResource.Identifier == entity.basicInfo.Current.BackAccessory;
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemoveAccessoryResource();
	}

	private AccessoryRenderComponent LoadComp(GameObject model, Transform jointGameObject, PlayerEntity entity, string accessoryName, AccessoryInfoXml xml, AccessoryMatrixConfig.AccessoryMatrix matrix)
	{
		model.transform.localPosition = Vector3.zero;
		model.transform.localRotation = Quaternion.identity;
		model.transform.localScale = Vector3.one;
		model.transform.SetParent(jointGameObject.transform, worldPositionStays: false);
		SJAnimator sJAnimator = null;
		AccessoryCache.AccessoryPath accessory = AccessoryCache.GetAccessory(accessoryName);
		LoadResult loadResult = entity.accessoryResource.LoadResults[accessory.PrefabAnimRequest];
		if (loadResult.Object is SJAnimationAsset)
		{
			sJAnimator = model.TryAddComponent<SJAnimator>();
			sJAnimator.Init();
			sJAnimator.AddLayer(0, 1f);
			sJAnimator.AddLayer(1, 1f);
			sJAnimator.AddAnimationClips(1, (loadResult.Object as SJAnimationAsset).Clips);
		}
		IPaticlePrefabInstancecs[] skins = null;
		WeaponUtility.GetParticles(model, ref skins);
		AccessoryRenderComponent accessoryRenderComponent = new AccessoryRenderComponent(entity.basicInfo.Current.BackAccessory, model, sJAnimator, xml, skins, model.GetComponentsInChildren<TrailRenderer_Base>(includeInactive: true));
		if (AccessoryRenderUtlity.IsWingByName(accessoryName))
		{
			string accessoryDyeingColorStr = AccessoryRenderUtlity.getAccessoryDyeingColorStr(entity);
			Color particleDyeingColor = AccessoryRenderUtlity.getParticleDyeingColor(accessoryDyeingColorStr);
			IPaticlePrefabInstancecs[] array = skins;
			foreach (IPaticlePrefabInstancecs paticlePrefabInstancecs in array)
			{
				if (paticlePrefabInstancecs is AccessoryParticleInstance)
				{
					AccessoryParticleInstance obj = paticlePrefabInstancecs as AccessoryParticleInstance;
					obj.AccessoryDyeingColor = accessoryDyeingColorStr;
					obj.updateDyeingColor(particleDyeingColor);
				}
			}
		}
		entity.AddBackAccessoryUnityObjects(accessoryRenderComponent);
		return accessoryRenderComponent;
	}

	protected override void OnInitEntityResource(PlayerEntity entity)
	{
		string accessoryName = AccessoryNameUtility.GetAccessoryName(entity.basicInfo.Current.BackAccessory, entity.basicInfo.Current.Team);
		if (!AccessoryRenderUtlity.LoadResDone(entity, accessoryName, "backaccessory", entity.accessoryResource, LoadComp).HasValue)
		{
			this.LogErrorFormat("BackAccessroy load  {0} Failed , Career {1} ,Error {2}", accessoryName, entity.GetCareer(), AccessoryRenderUtlity.LoadAccessoryError);
			failedlist.Add(accessoryName);
		}
	}
}
