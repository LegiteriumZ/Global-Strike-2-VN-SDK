using Assets.Scripts.Asset;
using Assets.Sources.Components.Interface;
using Assets.Sources.Config;
using Assets.Sources.Framework;
using Assets.Sources.Info.Accessory;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Player.UnityObjects;
using Assets.Sources.Utils.Weapon;
using Entitas;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using SSJJBase.Manager;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Modules.Player.Accessory;

public class BackWeaponLoadSystem : LoadAndInitResourceSystem<PlayerEntity>
{
	private IGroup<PlayerEntity> _loadGroup;

	private IGroup<PlayerEntity> _initGroup;

	public BackWeaponLoadSystem(Contexts contexts)
	{
		_loadGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo).NoneOf(PlayerMatcher.PartBasicInfo, PlayerMatcher.LoadBackWeaponResource, PlayerMatcher.BackWeaponResource, PlayerMatcher.BackWeaponUnityObjects));
		_initGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BackWeaponResource, PlayerMatcher.ThirdPersonUnityObjects).NoneOf(PlayerMatcher.BackWeaponUnityObjects));
	}

	protected override IGroup<PlayerEntity> GetLoadGroup()
	{
		return _loadGroup;
	}

	protected override IGroup<PlayerEntity> GetInitGroup()
	{
		return _initGroup;
	}

	protected override void OnLoadEntityResource(PlayerEntity entity)
	{
		if (GameSetting.Config.ShowThirdWeapon == 0 || !PlayerCareerUtil.IsHumanity(entity.GetCareer()) || (entity.hasThirdPersonUnityObjects && entity.thirdPersonUnityObjects.ThirdTran.BackContainerObj == null))
		{
			return;
		}
		string text = entity.basicInfo.Current.BackWeapon;
		if (NeedAttachC4(entity))
		{
			text = "c4";
		}
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		IWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(text);
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(entity.basicInfo.Current.BackWeaponSkinName);
		if (weaponInfo != null)
		{
			LoadRequests loadRequests = new LoadRequests();
			if (NeedAttachC4(entity))
			{
				loadRequests.Add("model", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ThirdAssetName, typeof(GameObject)), typeof(BackWeaponGameObject)));
			}
			else
			{
				SkinUtility.AddBackModelRequest(loadRequests, weaponInfo, skinInfo);
				loadRequests.Add("xml", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.BackWeaponConfigtXmlAssetName, typeof(BackWeaponXmlConfig), optional: true)));
			}
			entity.AddLoadBackWeaponResource(loadRequests, text);
		}
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		return true;
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemoveBackWeaponResource();
	}

	protected override void OnInitEntityResource(PlayerEntity entity)
	{
		if (NeedAttachC4(entity))
		{
			AttachC4(entity);
			return;
		}
		Transform backRoateNode = entity.thirdPersonUnityObjects.ThirdTran.BackRoateNode;
		LoadResults loadResults = entity.backWeaponResource.LoadResults;
		GameObject weaponObj = loadResults["model"].GameObject;
		SkinUtility.InitSkin(ref weaponObj, loadResults, entity.basicInfo.Current.BackWeaponWorn, entity.basicInfo.Current.BackQuenchId);
		BackWeaponXmlConfig backWeaponXmlConfig = (loadResults.ContainsKey("xml") ? (loadResults["xml"].Object as BackWeaponXmlConfig) : BackWeaponXmlConfigFactory.Default);
		if (backRoateNode != null)
		{
			Matrix4x4 matrix = (entity.basicInfo.CareerInfo.IsFemale ? backWeaponXmlConfig.FemaleConfig : backWeaponXmlConfig.MaleConfig);
			backRoateNode.localPosition = matrix.ExtractPosition();
			backRoateNode.localRotation = matrix.ExtractRotation();
			backRoateNode.localScale = matrix.ExtractScale();
		}
		Transform backWeaponNode = entity.thirdPersonUnityObjects.ThirdTran.BackWeaponNode;
		if (backWeaponNode != null)
		{
			backWeaponNode.localEulerAngles = new Vector3(90f, 0f, 0f);
			backWeaponNode.localPosition = Vector3.zero;
			weaponObj.transform.SetParent(backWeaponNode, worldPositionStays: false);
		}
		IPaticlePrefabInstancecs[] skins = null;
		WeaponUtility.GetParticles(weaponObj, ref skins);
		AccessoryRenderComponent accessoryRenderComponent = new AccessoryRenderComponent(entity.basicInfo.Current.BackWeapon, weaponObj, null, null, skins);
		entity.AddBackWeaponUnityObjects(accessoryRenderComponent);
	}

	private void AttachC4(PlayerEntity entity)
	{
		GameObject gameObject = entity.thirdPersonUnityObjects.ThirdTran.BackContainerObj.transform.parent.gameObject.FindForeachByName("bomb");
		if (!(gameObject == null))
		{
			GameObject gameObject2 = entity.backWeaponResource.LoadResults["model"].GameObject;
			gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: false);
			gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			IPaticlePrefabInstancecs[] skins = null;
			WeaponUtility.GetParticles(gameObject2, ref skins);
			AccessoryRenderComponent accessoryRenderComponent = new AccessoryRenderComponent("c4", gameObject2, null, null, skins);
			entity.AddBackWeaponUnityObjects(accessoryRenderComponent);
		}
	}

	private bool NeedAttachC4(PlayerEntity entity)
	{
		if (entity.basicInfo.Current.HasC4)
		{
			return entity.currentWeapon.Name != "c4";
		}
		return false;
	}
}
