using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.CsvLoader;
using Assets.Sources.Utils.Sound;
using Assets.Sources.Utils.Weapon;
using NetData;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJMath;
using SSJJUIEditor.ParticleEditor;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal abstract class AbstractSceneWeaponInfo : ISceneWeaponRenderInfo
{
	private Dictionary<IgnoreCaseString, SkinnedMeshRenderer> _skins = new Dictionary<IgnoreCaseString, SkinnedMeshRenderer>();

	private Dictionary<IParticleKey, IPaticlePrefabInstancecs> _particles = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();

	protected Func<SceneObjectEntity, string, string, int> Func;

	public void Init(SceneObjectEntity entity)
	{
		InitInternal(entity);
		InitMaterial(entity);
		InitEffect(entity);
		InitSound(entity);
	}

	protected void InitDummySound(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults["WeaponModel"].GameObject;
		if (entity.hasSound)
		{
			entity.RemoveSound();
		}
		SoundPlayer soundPlayer = gameObject.GetComponent<SoundPlayer>();
		if (soundPlayer == null)
		{
			soundPlayer = gameObject.AddComponent<SoundPlayer>();
		}
		soundPlayer.StopSound();
		entity.AddSound(soundPlayer);
	}

	protected void InitEmptySound(SceneObjectEntity entity)
	{
	}

	protected virtual void InitSound(SceneObjectEntity entity)
	{
	}

	protected virtual void InitMaterial(SceneObjectEntity entity)
	{
		GameObject weaponObj = entity.unityObjects.LoadResults["WeaponModel"].GameObject;
		SkinUtility.InitSkin(ref weaponObj, entity.unityObjects.LoadResults, entity.sceneWeapon.Current.WeaponWorn, entity.sceneWeapon.Current.QuenchId);
		if (!string.IsNullOrEmpty(entity.sceneWeapon.Current.DyeingColor))
		{
			SkinUtility.InitDyeingMaterial(ref weaponObj, entity.unityObjects.LoadResults["weapon_body_mask1"].Object as Texture2D, null, entity.sceneWeapon.Current.DyeingColor);
		}
		SkinnedMeshRenderer[] componentsInChildren = weaponObj.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		WeaponColorData weaponColorData = entity.sceneWeapon.Current.WeaponColorData;
		if (weaponColorData != null)
		{
			WeaponUtility.SetWeaponColor(weaponColorData, componentsInChildren);
		}
		else
		{
			WeaponUtility.SetWeaponColor(SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData, componentsInChildren);
		}
	}

	public void InitEffect(SceneObjectEntity entity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults["WeaponModel"].GameObject;
		Dictionary<IParticleKey, IPaticlePrefabInstancecs> dictionary = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();
		WeaponUtility.GetParticles(gameObject, dictionary);
		ParticleEditorLogicAsset newLogicAsset = null;
		if (entity.unityObjects.LoadResults.ContainsKey("WeaponLogicXml"))
		{
			newLogicAsset = entity.unityObjects.LoadResults["WeaponLogicXml"].Object as ParticleEditorLogicAsset;
		}
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> dictionary2 = new Dictionary<IgnoreCaseString, SkinnedMeshRenderer>();
		WeaponUtility.GetSkins(gameObject, dictionary2);
		if (!entity.hasEffectDict)
		{
			entity.AddEffectDict(dictionary2, dictionary, newLogicAsset);
		}
		else
		{
			entity.ReplaceEffectDict(dictionary2, dictionary, newLogicAsset);
		}
	}

	public void Render(SceneObjectEntity entity)
	{
		UpdatePostion(entity);
		UpdateRotate(entity);
		UpdatePaticle(entity);
		UpdateParticleFromEditor(entity);
		UpdateScale(entity);
		UpdateSound(entity);
		UpdateAlpha(entity);
	}

	protected virtual void UpdateParticleFromEditor(SceneObjectEntity entity)
	{
		if (entity.hasEffectDict)
		{
			entity.effectDict.LogicAsset?.SceneWeaponOnFrame(null, null, entity);
		}
	}

	private void UpdateScale(SceneObjectEntity entity)
	{
		if (RuleUtilty.IsFlyingKnife(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var _);
			entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localScale = Vector3.one * entity.sceneWeapon.Current.ShapeScale;
		}
	}

	protected virtual void UpdateAlpha(SceneObjectEntity entity)
	{
		if (!entity.hasEffectDict || !entity.sceneWeapon.Current.WeaponName.Equals("light_edge_grenade"))
		{
			return;
		}
		foreach (KeyValuePair<IgnoreCaseString, SkinnedMeshRenderer> skin in entity.effectDict.Skins)
		{
			Material[] materials = skin.Value.materials;
			foreach (Material obj in materials)
			{
				Color color = obj.color;
				color.a = (float)entity.sceneWeapon.Current.Alpha / 100f;
				obj.color = color;
			}
		}
	}

	protected virtual void UpdateSound(SceneObjectEntity entity)
	{
	}

	protected virtual void UpdatePostion(SceneObjectEntity entity)
	{
		VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.position = dest;
	}

	protected virtual void UpdateRotate(SceneObjectEntity entity)
	{
		Vector3 localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3(entity.orientation.Roll, entity.orientation.Pitch, entity.orientation.Yaw));
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localEulerAngles = localEulerAngles;
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.Rotate(0f, 90f, 0f);
	}

	protected virtual void UpdatePaticle(SceneObjectEntity entity)
	{
	}

	protected virtual void UpdateModelVisible(SceneObjectEntity entity, bool flag = true)
	{
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.SetActive(flag);
	}

	protected abstract void InitInternal(SceneObjectEntity entity);

	protected void SetSkinVisible(Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins, IgnoreCaseString key, bool flag)
	{
		if (skins != null && skins.TryGetValue(key, out var value))
		{
			value.enabled = flag;
		}
	}

	protected void SetParticleActiveBySkinName(SceneObjectEntity entity, Func<SceneObjectEntity, string, string, int> func)
	{
		if (func == null)
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			int num = func(entity, particle.Key.JointName, particle.Key.PatricleName);
			if (num >= 0)
			{
				particle.Value.SetInsActive(num > 0);
			}
		}
	}

	protected IPaticlePrefabInstancecs GetPaticleBySkinName(SceneObjectEntity entity, string name)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			if (particle.Key.JointName.Equals(name))
			{
				return particle.Value;
			}
		}
		return null;
	}

	protected void SetPaticleBySkinName(SceneObjectEntity entity, string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			if (particle.Key.JointName.Equals(name))
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	protected Dictionary<IParticleKey, IPaticlePrefabInstancecs> GetParticles(SceneObjectEntity entity)
	{
		if (entity.hasEffectDict)
		{
			return entity.effectDict.Patricles;
		}
		return _particles;
	}

	protected IPaticlePrefabInstancecs GetPaticleByParticleName(SceneObjectEntity entity, string name)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			if (particle.Key.PatricleName.Equals(name))
			{
				return particle.Value;
			}
		}
		return null;
	}

	protected Dictionary<IgnoreCaseString, SkinnedMeshRenderer> GetSkins(SceneObjectEntity entity)
	{
		if (entity.hasEffectDict)
		{
			return entity.effectDict.Skins;
		}
		return _skins;
	}

	protected void SetParticleVisalbeByName(SceneObjectEntity entity, string name, bool flag)
	{
		GetPaticleByParticleName(entity, name)?.SetInsActive(flag);
	}
}
