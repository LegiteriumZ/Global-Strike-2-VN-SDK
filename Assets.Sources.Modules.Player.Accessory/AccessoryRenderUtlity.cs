using System;
using System.Collections.Generic;
using Assets.Scripts.Asset;
using Assets.Sources.Components.Common;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.CsvLoader;
using Assets.Sources.Info.Career;
using Assets.Sources.Particle;
using Assets.Sources.Player.UnityObjects;
using Assets.Sources.Utils.Weapon;
using SSJJAnim.Parser;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Accessory;

public static class AccessoryRenderUtlity
{
	public delegate AccessoryRenderComponent AccessoryRenderLoadCallback(GameObject g, Transform t, PlayerEntity p, string s, AccessoryInfoXml r, AccessoryMatrixConfig.AccessoryMatrix matrix);

	public static string LoadAccessoryError;

	public static bool IsWingByName(string accessoryName)
	{
		if (accessoryName.EndsWith("close"))
		{
			return true;
		}
		return accessoryName.EndsWith("open");
	}

	public static string getAccessoryDyeingColorStr(PlayerEntity player)
	{
		string result = "";
		if (player.hasBasicInfo)
		{
			string[] array = player.basicInfo.Current.RoleColors.Split(',');
			if (array.Length >= 9)
			{
				result = array[8];
			}
		}
		return result;
	}

	public static Color getParticleDyeingColor(string wingColor)
	{
		if (wingColor.Length < 7)
		{
			return new Color(1f, 1f, 1f, 1f);
		}
		return SkinUtility.getColor(wingColor, 1f);
	}

	public static void AddRequest(LoadRequests loadRequests, string accessoryName)
	{
		AccessoryCache.AccessoryPath accessory = AccessoryCache.GetAccessory(accessoryName);
		string bundlePath = accessory.BundlePath;
		string matrixXmlPath = accessory.MatrixXmlPath;
		string prefabPath = accessory.PrefabPath;
		string prefabAnimPath = accessory.PrefabAnimPath;
		string animXmlPath = accessory.AnimXmlPath;
		string textureConfigPath = accessory.TextureConfigPath;
		string configureXmlpath = accessory.ConfigureXmlpath;
		loadRequests.Add(accessory.MatrixXmlRequest, new LoadRequest(new AssetInfo(bundlePath, matrixXmlPath, typeof(AccessoryMatrixConfig))));
		loadRequests.Add(accessory.PrefabRequest, new LoadRequest(new AssetInfo(bundlePath, prefabPath, typeof(GameObject)), typeof(BackAccessoryGameObject)));
		loadRequests.Add(accessory.AnimXmlRequest, new LoadRequest(new AssetInfo(bundlePath, animXmlPath, typeof(AccessoryInfoXml), optional: true)));
		loadRequests.Add(accessory.PrefabAnimRequest, new LoadRequest(new AssetInfo(bundlePath, prefabAnimPath, typeof(SJAnimationAsset), optional: true)));
		loadRequests.Add(accessory.TextureConfigRequest, new LoadRequest(new AssetInfo(bundlePath, textureConfigPath, typeof(TextureConfigInfo), optional: true)));
		loadRequests.Add(accessory.ConfigureXmlRequest, new LoadRequest(new AssetInfo(bundlePath, configureXmlpath, typeof(AsccessoryConfigure), optional: true)));
		ParticleManager.InitAccessoryParticleXmlLoadRequests(loadRequests, accessoryName);
	}

	public static AccessoryRenderComponent? LoadResDone(PlayerEntity entity, string accessoryName, string targetJoint, CommonUnityResourceComponent resourceComponent, AccessoryRenderLoadCallback callback)
	{
		if (string.IsNullOrEmpty(accessoryName))
		{
			LoadAccessoryError = "AccessoryName Is Null";
			return null;
		}
		AccessoryCache.AccessoryPath accessory = AccessoryCache.GetAccessory(accessoryName);
		AccessoryMatrixConfig accessoryMatrixConfig = null;
		GameObject gameObject = null;
		AccessoryInfoXml r = null;
		AsccessoryConfigure asccessoryConfigure = null;
		if (resourceComponent.LoadResults.ContainsKey(accessory.MatrixXmlRequest))
		{
			accessoryMatrixConfig = resourceComponent.LoadResults[accessory.MatrixXmlRequest].Object as AccessoryMatrixConfig;
		}
		if (resourceComponent.LoadResults.ContainsKey(accessory.PrefabRequest))
		{
			gameObject = resourceComponent.LoadResults[accessory.PrefabRequest].GameObject;
		}
		if (resourceComponent.LoadResults.ContainsKey(accessory.AnimXmlRequest))
		{
			r = resourceComponent.LoadResults[accessory.AnimXmlRequest].Object as AccessoryInfoXml;
		}
		if (resourceComponent.LoadResults.ContainsKey(accessory.ConfigureXmlRequest))
		{
			asccessoryConfigure = resourceComponent.LoadResults[accessory.ConfigureXmlRequest].Object as AsccessoryConfigure;
		}
		AccessoryConfigLoader.Instance.Add_AsccessoryConfigures(accessoryName, asccessoryConfigure);
		ParticleManager.InitAccessoryParticleXmlLoadResults(resourceComponent.LoadResults, accessoryName);
		if (accessoryMatrixConfig == null || gameObject == null)
		{
			LoadAccessoryError = string.Concat("Config : [", accessoryMatrixConfig, "] Model : [", gameObject, "]");
			return null;
		}
		AccessoryMatrixConfig.AccessoryMatrix accessoryMatrix = null;
		string name = entity.basicInfo.CareerInfo.Name;
		if (accessoryMatrixConfig.AccessoryMatrixDictionary.ContainsKey(name))
		{
			accessoryMatrix = accessoryMatrixConfig.AccessoryMatrixDictionary[name];
		}
		else if (entity.basicInfo.CareerInfo.AnimBundleName.Equals("playeranim/woman", StringComparison.OrdinalIgnoreCase))
		{
			if (accessoryMatrixConfig.AccessoryMatrixDictionary.ContainsKey("woman"))
			{
				accessoryMatrix = accessoryMatrixConfig.AccessoryMatrixDictionary["woman"];
			}
		}
		else if (accessoryMatrixConfig.AccessoryMatrixDictionary.ContainsKey("man"))
		{
			accessoryMatrix = accessoryMatrixConfig.AccessoryMatrixDictionary["man"];
		}
		if (accessoryMatrix == null)
		{
			string key = "";
			foreach (KeyValuePair<string, AccessoryMatrixConfig.AccessoryMatrix> item in accessoryMatrixConfig.AccessoryMatrixDictionary)
			{
				key = item.Key;
			}
			accessoryMatrix = accessoryMatrixConfig.AccessoryMatrixDictionary[key];
		}
		Transform bone = entity.thirdPersonUnityObjects.Animator.GetBone(accessoryMatrix.Joint);
		if (bone == null)
		{
			bone = entity.thirdPersonUnityObjects.Animator.GetBone("backaccessory");
		}
		if (bone != null && callback != null)
		{
			return callback(gameObject, bone, entity, accessoryName, r, accessoryMatrix);
		}
		LoadAccessoryError = string.Concat("jointGameObject : [", bone, "] Joint : [", accessoryMatrix.Joint, "]");
		return null;
	}

	public static string GetSkateAnimation(PlayerEntity player)
	{
		string result = "idle";
		if (player.HasStatus(100041))
		{
			result = "jump";
		}
		else if (player.move.Moving)
		{
			float num = YawPitchUtility.MakeAngleLinear(player.orientation.MoveYaw);
			float num2 = YawPitchUtility.MakeAngleLinear(player.orientation.Yaw);
			float num3 = YawPitchUtility.MakeAngleLinear(num - num2);
			result = (((num3 >= 0f && num3 < 45f) || (num3 > 315f && num3 <= 360f)) ? "moveForward" : ((num3 >= 45f && num3 < 135f) ? "moveLeft" : ((!(num3 >= 135f) || !(num3 <= 225f)) ? "moveRight" : "moveBack")));
		}
		return result;
	}

	public static string GetJiJiaZhuangjiaAnimation(PlayerEntity player)
	{
		string result = "idle";
		if (player.basicInfo.Current.AccessoryAnim == 45)
		{
			result = "legs_attack";
		}
		else if (player.basicInfo.Current.AccessoryAnim == 27)
		{
			result = "skill";
		}
		return result;
	}

	public static string GetNezhaAnimation(PlayerEntity player, string accessoryName)
	{
		string result = "idle";
		int num = player.basicInfo.Current.AccessoryAnim;
		if (accessoryName == "nezha_02" || accessoryName == "nezhahj_02")
		{
			num = player.basicInfo.Current.AccessoryAnimWaist;
		}
		switch (num)
		{
		case 51:
			result = "skill_start";
			break;
		case 52:
			result = "skill_loop";
			break;
		case 53:
			result = "skill_end";
			break;
		case 27:
			result = "skill";
			break;
		case 50:
			result = "skill2";
			break;
		}
		return result;
	}

	public static string GetAresAnimation(PlayerEntity player, string accessoryName)
	{
		string result = "idle";
		int accessoryAnim = player.basicInfo.Current.AccessoryAnim;
		switch (player.basicInfo.Current.AccessoryAnimWaist)
		{
		case 51:
			result = "skill_start";
			break;
		case 52:
			result = "skill_loop";
			break;
		case 53:
			result = "skill_end";
			break;
		case 27:
			result = "skill";
			break;
		case 50:
			result = "skill2";
			break;
		}
		return result;
	}

	public static string GetThunderLegnedBackAnimation(PlayerEntity player)
	{
		string result = "idle";
		if (player.basicInfo.Current.AccessoryAnim == 45)
		{
			result = "legs_attack";
		}
		else if (player.basicInfo.Current.AccessoryAnim == 51)
		{
			result = "skill";
		}
		else if (player.basicInfo.Current.AccessoryAnim == 53)
		{
			result = "aclose";
		}
		else if (player.basicInfo.Current.AccessoryAnim == 7)
		{
			result = "idle";
		}
		return result;
	}

	public static string GetAnimation(PlayerEntity player, AccessoryInfoXml xml)
	{
		string result = "idle";
		ILegAnimStateInfo legsAnimInfo = player.legAnim.LegsAnimInfo;
		ITorseAnimStateInfo torsoAnimInfo = player.torseAnim.TorsoAnimInfo;
		if (legsAnimInfo == null || torsoAnimInfo == null)
		{
			return result;
		}
		if (xml.AccessoryAnimations.GetAnimDescStr("head") != null && IsDeadAnim(legsAnimInfo))
		{
			return "head";
		}
		if (xml.AccessoryAnimations.GetAnimDescStr("careerIdle") != null && IsCareerIdle(legsAnimInfo))
		{
			return "careerIdle";
		}
		if (xml.AccessoryAnimations.GetAnimDescStr("skill") != null && IsSkillAnim(legsAnimInfo))
		{
			return "skill";
		}
		if (xml.AccessoryAnimations.GetAnimDescStr("attack") != null && !IsTorsoNotAttack(torsoAnimInfo))
		{
			return "attack";
		}
		if (IsTorsoNotAttack(torsoAnimInfo) && (legsAnimInfo.StateId == 7 || legsAnimInfo.StateId == 8))
		{
			return "idle";
		}
		return "run";
	}

	public static string GetJuxingWingAnimation(PlayerEntity player, string accessoryName)
	{
		string result = "idle";
		if (player.basicInfo.Current.LegsAnim == 505)
		{
			result = "legs_julong_wing_chuchang";
		}
		return result;
	}

	public static string GetAnimation(PlayerEntity player)
	{
		int accessoryAnim = player.basicInfo.Current.AccessoryAnim;
		string result = "accessory_idle";
		switch (accessoryAnim)
		{
		case 45:
			result = "accessory_attack";
			break;
		case 53:
			result = "skill_end";
			break;
		}
		return result;
	}

	private static bool IsCareerIdle(ILegAnimStateInfo legInfo)
	{
		if (151 == legInfo.StateId)
		{
			return true;
		}
		return false;
	}

	private static bool IsSkillAnim(ILegAnimStateInfo legInfo)
	{
		if (323 == legInfo.StateId)
		{
			return true;
		}
		if (27 == legInfo.StateId)
		{
			return true;
		}
		return false;
	}

	private static bool IsDeadAnim(ILegAnimStateInfo legInfo)
	{
		if (11 == legInfo.StateId)
		{
			return true;
		}
		if (42 == legInfo.StateId)
		{
			return true;
		}
		if (43 == legInfo.StateId)
		{
			return true;
		}
		return false;
	}

	private static bool IsTorsoNotAttack(ITorseAnimStateInfo torseInfo)
	{
		if (torseInfo.StateId != 15 && torseInfo.StateId != 40 && torseInfo.StateId != 91 && torseInfo.StateId != 32 && torseInfo.StateId != 122 && torseInfo.StateId != 23 && torseInfo.StateId != 137 && torseInfo.StateId != 41 && torseInfo.StateId != 31 && torseInfo.StateId != 20 && torseInfo.StateId != 29)
		{
			return true;
		}
		return false;
	}
}
