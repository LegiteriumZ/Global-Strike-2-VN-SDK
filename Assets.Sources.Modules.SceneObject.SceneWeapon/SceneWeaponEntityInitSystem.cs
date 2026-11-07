using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.Framework;
using Assets.Sources.Info.Res;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Particle;
using Assets.Sources.Particle.Config;
using Assets.Sources.Utils.Weapon;
using Entitas;
using NetData;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Manager;
using SSJJUIEditor.ParticleEditor;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon;

public class SceneWeaponEntityInitSystem : IPlaybackInitSystem
{
	private readonly SnapshotContext _snapshotContext;

	private readonly SceneObjectContext _sceneWeaponContext;

	private readonly IGroup<SceneObjectEntity> _sceneWeapons;

	private readonly GameRuleContext _gameRuleContext;

	public SceneWeaponEntityInitSystem(Contexts contexts)
	{
		_snapshotContext = contexts.snapshot;
		_sceneWeaponContext = contexts.sceneObject;
		_gameRuleContext = contexts.gameRule;
		_sceneWeapons = contexts.sceneObject.GetGroup(SceneObjectMatcher.SceneWeapon);
	}

	public void OnPlaybackInit()
	{
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		ISnapshot nextSnapshot = _snapshotContext.snapshots.NextSnapshot;
		if (nowSnapshot == null || nextSnapshot == null)
		{
			return;
		}
		foreach (KeyValuePair<int, SceneWeaponEntityData> item in nowSnapshot.SceneWeaponEntityDataDict)
		{
			SceneWeaponEntityData value = item.Value;
			nextSnapshot.SceneWeaponEntityDataDict.TryGetValue(value.Id, out var value2);
			SceneObjectEntity sceneObjectEntity = _sceneWeaponContext.GetEntityWithEntityId(value.Id);
			if (sceneObjectEntity == null)
			{
				sceneObjectEntity = _sceneWeaponContext.CreateEntity();
				sceneObjectEntity.AddEntityId(value.Id);
				IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(value.WeaponName);
				WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(value.WeaponSkinName);
				LoadRequests loadRequests = new LoadRequests();
				SkinUtility.AddSceneModelRequest(loadRequests, weaponInfo, skinInfo);
				LoadWeaponLogic(loadRequests, sceneObjectEntity, weaponInfo, skinInfo);
				if (!string.IsNullOrEmpty(value.DyeingColor))
				{
					SkinUtility.AddWeaponBodyMask1Request(loadRequests, weaponInfo, skinInfo);
				}
				sceneObjectEntity.AddLoadUnityObjects(loadRequests, weaponInfo);
				LoadWeaponEffect(sceneObjectEntity, weaponInfo);
				sceneObjectEntity.AddPosition(new Vector3(value.X, value.Y, value.Z));
				sceneObjectEntity.AddOrientation(value.Yaw, value.Pitch, value.Roll, value.Yaw, 0f, 0f, 0f);
				if (!(value.WeaponName == "lover2025_grenade") || (value.Level != 4 && value.Level != 5 && value.Level != 6))
				{
					TailEffectData tailEffectData = ParticleManager.Instance().GetTailEffectData(value.WeaponSkinName);
					if (tailEffectData == null)
					{
						tailEffectData = ParticleManager.Instance().GetTailEffectData(weaponInfo.Name);
					}
					if (tailEffectData != null)
					{
						if (tailEffectData.LevelState != 0 && (tailEffectData.LevelState & value.Level) == 0)
						{
							SceneObjectFactory.Instance.CreateTrail(sceneObjectEntity, 200, 4, weaponInfo.Name.Equals("flashgrenade") ? 2 : 0, BattleSingletonInstance<ResConfigFactory>.Instance.GetDefaultGrenadeTailInfo(), 1f, 0.15f);
						}
						else
						{
							SceneObjectFactory.Instance.CreateTrail(sceneObjectEntity, 200, 4, 0, tailEffectData.AssetInfo, 1f, 0.15f);
						}
					}
					else if (weaponInfo.WeaponType == 3 && FreeWeaponConstant.HasTailGrenadeWeapon(weaponInfo.Name))
					{
						SceneObjectFactory.Instance.CreateTrail(sceneObjectEntity, 200, 4, weaponInfo.Name.Equals("flashgrenade") ? 2 : 0, BattleSingletonInstance<ResConfigFactory>.Instance.GetDefaultGrenadeTailInfo(), 1f, 0.15f);
					}
					else if (weaponInfo.WeaponType == 14 && FreeWeaponConstant.hasTypeTacticalWeapon(weaponInfo.Name))
					{
						SceneObjectFactory.Instance.CreateTrail(sceneObjectEntity, 200, 4, weaponInfo.Name.Equals("flashgrenade") ? 2 : 0, BattleSingletonInstance<ResConfigFactory>.Instance.GetDefaultGrenadeTailInfo(), 1f, 0.15f);
					}
					else if (RuleUtilty.IsFlyingKnife(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
					{
						SceneObjectFactory.Instance.CreateTrail(sceneObjectEntity, 100, 4, 0, BattleSingletonInstance<ResConfigFactory>.Instance.GetDefaultGrenadeTailInfo(), 0.8f, 0.1f);
					}
				}
			}
			sceneObjectEntity.ReplaceSceneWeapon(value, value2);
		}
		foreach (SceneObjectEntity sceneWeapon in _sceneWeapons)
		{
			if (!_snapshotContext.snapshots.NowSnapshot.SceneWeaponEntityDataDict.ContainsKey(sceneWeapon.sceneWeapon.Current.Id))
			{
				sceneWeapon.isDestroy = true;
			}
		}
	}

	private void LoadWeaponLogic(LoadRequests loadRequests, SceneObjectEntity entity, IWeaponInfo info, WeaponSkinInfo skinInfo)
	{
		if (skinInfo != null && skinInfo.HasParticleLogic)
		{
			loadRequests.AddAsset("WeaponLogicXml", skinInfo.GetParticleLogicAssetInfo(info.Name));
		}
		else
		{
			loadRequests.AddAsset("WeaponLogicXml", new AssetInfo(info.AssetBundleName, info.LogicXmlAssetName, typeof(ParticleEditorLogicAsset), optional: true));
		}
	}

	private void LoadWeaponEffect(SceneObjectEntity entity, IWeaponInfo weaponInfo)
	{
		if (weaponInfo.Name == "c4")
		{
			string assetname = "Idle";
			if (_gameRuleContext.hasC4State && _gameRuleContext.c4State.Active)
			{
				assetname = "Active";
			}
			entity.AddLoadWeaponEffectResource(new LoadRequests("effectprefab/c4weapon", assetname), weaponInfo.Name);
		}
	}
}
