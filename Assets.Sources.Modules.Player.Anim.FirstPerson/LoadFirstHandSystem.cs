using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Scripts.Asset;
using Assets.Scripts.Effect.Level;
using Assets.Scripts.Utility;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.CsvLoader;
using Assets.Sources.Framework;
using Assets.Sources.Info.Camera;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Info.WeaponAnim;
using Assets.Sources.Particle;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Weapon;
using Assets.Sources.XmlAsset;
using Entitas;
using SSJJAnim.AnimState;
using SSJJAnim.Animator;
using SSJJAnim.Parser;
using SSJJAnim.Weapon;
using SSJJAnim.WeaponAnim;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJMath;
using SSJJUIEditor.ParticleEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using share;
using share.constant;

namespace Assets.Sources.Modules.Player.Anim.FirstPerson;

public class LoadFirstHandSystem : LoadAndInitResourceSystem<PlayerEntity>, IRenderSystem
{
	private readonly GameObject _firstHand;

	private Camera eye;

	private readonly IGroup<PlayerEntity> _initGroup;

	private readonly IGroup<PlayerEntity> _loadGroup;

	private readonly IGroup<PlayerEntity> _players;

	private Dictionary<GameObject, KeyValuePair<GameObject, GameObject>> _anchorCache;

	private Dictionary<string, Vector3D[]> _cameraTranCache;

	private Dictionary<GameObject, KeyValuePair<GameObject, GameObject>> _weaponAnchorCache;

	private Dictionary<GameObject, Dictionary<IgnoreCaseString, SkinnedMeshRenderer>> _weaponSkinsCache;

	private Dictionary<GameObject, Dictionary<IParticleKey, IPaticlePrefabInstancecs>> _particlesCache;

	private GameObject cameraObject;

	private FirstHandCameraConfig cameraConfigAsset;

	private bool _findFirstWeaponLight;

	private Vector3 _fistWeaponLightAngle;

	public float _fov;

	public LoadFirstHandSystem(Contexts contexts)
	{
		PlayerContext player = contexts.player;
		_loadGroup = player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonView).NoneOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.LoadFirstPersonViewResource, PlayerMatcher.FirstPersonViewResource));
		_initGroup = player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonViewResource).NoneOf(PlayerMatcher.FirstPersonUnityObjects));
		_players = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.FirstPersonUnityObjects, PlayerMatcher.FirstPersonView));
		_firstHand = new GameObject("FirstHand");
		_firstHand.AddComponent<RotateWithEye>();
		UnityEngine.Object.DontDestroyOnLoad(_firstHand);
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
		if (entity.basicInfo.IsDead)
		{
			return;
		}
		ICareerInfo careerInfo = entity.basicInfo.CareerInfo;
		if (PlayerCareerUtil.IsTPS(careerInfo.Name))
		{
			return;
		}
		IEntitsWeaponInfo weaponInfo = entity.currentWeapon.WeaponInfo;
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(entity.currentWeapon.SkinName);
		PlayerSkinInfo skinInfo2 = PlayerSkinInfoFactory.Instance.GetSkinInfo(entity.basicInfo.SkinName);
		if (weaponInfo == null)
		{
			this.LogErrorFormat("weaponInfo is null {0}", entity.currentWeapon.Name);
			return;
		}
		string currentHandName = entity.basicInfo.Current.CurrentHandName;
		LoadRequests loadRequests = new LoadRequests();
		loadRequests.AddAsset("CameraConfig", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ViewCameraConfigAssetName, typeof(FirstHandCameraConfig)));
		if (careerInfo.Name != weaponInfo.Name)
		{
			SkinUtility.AddViewModelRequest(loadRequests, weaponInfo, skinInfo);
			if (!string.IsNullOrEmpty(entity.GetCurrentWeaponDyeingColors()) && !string.IsNullOrEmpty(entity.GetCurrentWeaponDyeingColors()))
			{
				SkinUtility.AddWeaponBodyMask1Request(loadRequests, weaponInfo, skinInfo);
			}
			if (WeaponUtility.IsSpecialWeapon(currentHandName))
			{
				loadRequests.Add("HandModel", new LoadRequest(new AssetInfo($"weapon/{currentHandName}", GetSpecialWeaponModelPath(currentHandName)), typeof(FirstPersonHand)));
				if (entity.hasThirdPersonUnityObjects)
				{
					string name = entity.thirdPersonUnityObjects.MeshRenders[0].material.mainTexture.name;
					loadRequests.AddAsset("NormalTexture", new AssetInfo($"weapon/{weaponInfo.Name}", $"Assets/Res/Assets/weapon/{weaponInfo.Name}/{name}.png", typeof(Texture2D), optional: true));
				}
			}
			else
			{
				loadRequests.Add("HandModel", new LoadRequest(new AssetInfo($"viewhand/{currentHandName}", GetWeaponModelPath(currentHandName)), typeof(FirstPersonHand)));
				loadRequests.AddAsset("NormalTexture", new AssetInfo($"viewhand/{currentHandName}", $"Assets/Res/Assets/viewhand/{currentHandName}/texture.png"));
			}
		}
		else if (IsAnimation(weaponInfo.Name))
		{
			loadRequests.Add("HandModel", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, GetSpecialWeaponModelPath(currentHandName)), typeof(FirstPersonHand)));
		}
		else
		{
			loadRequests.Add("HandModel", new LoadRequest(new AssetInfo(weaponInfo.SplitAssetBundleName, $"Assets/Res/Assets/weapon/{weaponInfo.Name}/view/hand.DAE"), typeof(FirstPersonHand)));
		}
		SkinUtility.AddViewHandRequest(loadRequests, weaponInfo, skinInfo, skinInfo2);
		loadRequests.Add("HandCamera", new LoadRequest(new AssetInfo("effectprefab/handcamera", "HandCamera", typeof(GameObject)), typeof(FirstPersonCamera)));
		loadRequests.Add("KnifeEffect", new LoadRequest(ResourceUtility.GetKnifeAttackEffectFristRequest(weaponInfo.Name, skinInfo), typeof(FirstPersonKnifeEffect)));
		if (entity.hasDyeingColor)
		{
			entity.dyeingColor.dyeingColors = entity.GetDyeingColors();
		}
		else
		{
			entity.AddDyeingColor(entity.GetDyeingColors(), "");
		}
		if (entity.GetDyeingColors() != "")
		{
			if (skinInfo2 != null && skinInfo2.HasDyeing)
			{
				loadRequests["body_mask1"] = new LoadRequest(skinInfo2.viewHand_bodyMask1Asset, typeof(Texture));
				loadRequests["body_mask2"] = new LoadRequest(skinInfo2.viewHand_bodyMask2Asset, typeof(Texture));
			}
			else
			{
				string bundleName = $"viewhand/{currentHandName}";
				loadRequests["body_mask1"] = new LoadRequest(new AssetInfo(bundleName, GetViewHandMaskPath(currentHandName, "bodymask/body_mask1"), typeof(Texture), optional: true));
				loadRequests["body_mask2"] = new LoadRequest(new AssetInfo(bundleName, GetViewHandMaskPath(currentHandName, "bodymask/body_mask2"), typeof(Texture), optional: true));
			}
		}
		loadRequests.Add("weaponConfig", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, $"Assets/Res/Assets/weapon/{weaponInfo.Name}/weapon.xml", typeof(WeaponConfigXmlAsset), optional: true)));
		ParticleManager.InitWeaponParticleXmlLoadRequests(loadRequests, weaponInfo, skinInfo);
		ParticleManager.InitPlayerParticleXmlLoadRequests(loadRequests, careerInfo, skinInfo2);
		entity.AddLoadFirstPersonViewResource(loadRequests, weaponInfo);
	}

	private bool IsAnimation(string name)
	{
		if (!name.Equals("cat", StringComparison.OrdinalIgnoreCase) && !name.Equals("chicken", StringComparison.OrdinalIgnoreCase) && !name.Equals("pig", StringComparison.OrdinalIgnoreCase) && !name.Equals("herowoman_gun", StringComparison.OrdinalIgnoreCase) && !name.Equals("hero_gun", StringComparison.OrdinalIgnoreCase) && !name.Equals("pandoraMonther", StringComparison.OrdinalIgnoreCase) && !name.Equals("pandoraMonther_baigu", StringComparison.OrdinalIgnoreCase) && !name.Equals("qingshe", StringComparison.OrdinalIgnoreCase) && !name.Equals("hero_guanzi", StringComparison.OrdinalIgnoreCase) && !name.Equals("hero_shark", StringComparison.OrdinalIgnoreCase) && !name.Equals("hero_sangzhong", StringComparison.OrdinalIgnoreCase) && !name.Equals("kunlungongzhu", StringComparison.OrdinalIgnoreCase) && !name.Equals("yuetu", StringComparison.OrdinalIgnoreCase) && !name.Equals("chansi", StringComparison.OrdinalIgnoreCase) && !name.Equals("jiewangzhe", StringComparison.OrdinalIgnoreCase) && !name.Equals("mechfar", StringComparison.OrdinalIgnoreCase) && !name.Equals("mechfar2", StringComparison.OrdinalIgnoreCase) && !name.Equals("mechbomberman", StringComparison.OrdinalIgnoreCase) && !name.Equals("mechbomberman2", StringComparison.OrdinalIgnoreCase) && !name.Equals("qingniujing", StringComparison.OrdinalIgnoreCase))
		{
			return name.Equals("qingniujing_mother", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private string GetWeaponModelPath(string handName)
	{
		return $"Assets/Res/Assets/viewhand/{handName}/model.prefab";
	}

	private string GetViewHandMaskPath(string handName, string maskname)
	{
		return $"Assets/Res/Assets/viewhand/{handName}/{maskname}.png";
	}

	private string GetSpecialWeaponModelPath(string handName)
	{
		return $"Assets/Res/Assets/weapon/{handName}/view/hand_{handName}.prefab";
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		return entity.currentWeapon.WeaponInfo == (IWeaponInfo)entity.firstPersonViewResource.Identifier;
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemoveFirstPersonViewResource();
	}

	protected override void OnInitEntityResource(PlayerEntity entity)
	{
		if (!entity.hasFirstPersonCache)
		{
			entity.AddFirstPersonCache(new Dictionary<GameObject, KeyValuePair<GameObject, GameObject>>(), new Dictionary<string, Vector3D[]>(), new Dictionary<GameObject, KeyValuePair<GameObject, GameObject>>(), new Dictionary<GameObject, Dictionary<IgnoreCaseString, SkinnedMeshRenderer>>(), new Dictionary<GameObject, Dictionary<IParticleKey, IPaticlePrefabInstancecs>>());
		}
		_anchorCache = entity.firstPersonCache.AnchorCache;
		_cameraTranCache = entity.firstPersonCache.CameraTranCache;
		_weaponAnchorCache = entity.firstPersonCache.WeaponAnchorCache;
		_weaponSkinsCache = entity.firstPersonCache.WeaponSkinsCache;
		_particlesCache = entity.firstPersonCache.ParticlesCache;
		IEntitsWeaponInfo weaponInfo = entity.currentWeapon.WeaponInfo;
		ICareerInfo careerInfo = entity.basicInfo.CareerInfo;
		if (PlayerCareerUtil.IsTPS(careerInfo.Name))
		{
			return;
		}
		LoadResults loadResults = entity.firstPersonViewResource.LoadResults;
		ICareerInfo careerInfo2 = entity.basicInfo.CareerInfo;
		GameObject gameobj = loadResults["HandModel"].GameObject;
		WeaponSkinInfo skinInfo = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(entity.currentWeapon.SkinName);
		PlayerSkinInfo skinInfo2 = PlayerSkinInfoFactory.Instance.GetSkinInfo(entity.basicInfo.SkinName);
		UpdateSkinnedMeshRendersWhenOffScreen(gameobj);
		Texture2D texture2D = loadResults["NormalTexture"].Object as Texture2D;
		if (careerInfo.Name != weaponInfo.Name)
		{
			SkinnedMeshRenderer[] componentsInChildren = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
			{
				if (skinnedMeshRenderer != null && texture2D != null)
				{
					skinnedMeshRenderer.material.mainTexture = texture2D;
				}
			}
		}
		else
		{
			SkinnedMeshRenderer[] componentsInChildren = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>();
			foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in componentsInChildren)
			{
				if (skinnedMeshRenderer2.rootBone != null && WeaponJoinConstant.JoinsInfo.TryGetValue(skinnedMeshRenderer2.rootBone.name, out var value) && value.EffectType == JoinEffectType.Particle)
				{
					skinnedMeshRenderer2.gameObject.SetObjectActive(isactive: false);
				}
			}
		}
		SkinUtility.InitDyeingMaterial(ref gameobj, loadResults["body_mask1"].Object as Texture2D, loadResults["body_mask2"].Object as Texture2D, entity.GetDyeingColors());
		SJAnimationAsset sJAnimationAsset = loadResults["HandAnim"].Object as SJAnimationAsset;
		GameObject weaponObj = null;
		if (loadResults.ContainsKey("WeaponModel"))
		{
			weaponObj = loadResults["WeaponModel"].GameObject;
			if ((bool)weaponObj.GetComponent<WeaponDissolutionEffect>())
			{
				weaponObj.GetComponent<WeaponDissolutionEffect>().playerEntity = entity;
			}
		}
		if (weaponObj == null)
		{
			weaponObj = new GameObject("EmptyWaapon");
		}
		ParticleEffectUtility.InitWeaponParticle(weaponObj, weaponInfo.Name);
		SkinUtility.InitSkin(ref weaponObj, loadResults, entity.currentWeapon.Worn, entity.currentWeapon.QuenchId, skinInfo);
		UpdateSkinnedMeshRendersWhenOffScreen(weaponObj);
		ResetWeaponAnchorScale(weaponObj);
		CheckEmptyWeapon(weaponInfo, weaponObj);
		cameraConfigAsset = loadResults["CameraConfig"].Object as FirstHandCameraConfig;
		SJAnimationAsset sJAnimationAsset2 = null;
		if (loadResults.ContainsKey("WeaponAnim"))
		{
			sJAnimationAsset2 = loadResults["WeaponAnim"].Object as SJAnimationAsset;
		}
		if (sJAnimationAsset2 == null)
		{
			sJAnimationAsset2 = sJAnimationAsset;
		}
		WeaponAnimAsset weaponAnimAsset = loadResults["ViewAnimConfig"].Object as WeaponAnimAsset;
		if (!WeaponAnimInfoFactory.Instance.Exists(weaponInfo))
		{
			WeaponAnimInfoFactory.Instance.Add(weaponInfo, weaponAnimAsset.WeaponAnimInfo);
		}
		if (WeaponAnimInfoFactory.Instance.GetWeaponAnimInfo(weaponInfo) is DefaultWeaponAnimInfo defaultWeaponAnimInfo && !AnimStateInfoFactory.Instance.ClearView(defaultWeaponAnimInfo))
		{
			Dictionary<int, SSJJAnim.AnimData.AnimationDesc>.Enumerator animEnumerator = defaultWeaponAnimInfo.AnimationArray.GetAnimEnumerator();
			while (animEnumerator.MoveNext())
			{
				int key = animEnumerator.Current.Key;
				AnimStateInfoFactory.Instance.GetViewAnimInfo(key);
			}
			AnimStateInfoFactory.Instance.SaveViewCache(defaultWeaponAnimInfo);
		}
		SJAnimator newWeaponAnimator = null;
		SJAnimator newHandAnimator = null;
		SJAnimator sJAnimator;
		SJAnimator sJAnimator2;
		if (WeaponUtility.HasLeftAnim(weaponInfo))
		{
			GameObject weaponObj2 = weaponObj;
			GameObject weaponObj3 = gameobj;
			GameObject gameObject = FindChild(weaponObj, "bip01_l_clavicle");
			GameObject gameObject2 = FindChild(gameobj, "bip01_l_clavicle");
			sJAnimator = AddAnimator(weaponObj2, sJAnimationAsset2);
			sJAnimator.AddMask(gameObject.name, recursively: true);
			sJAnimator2 = AddAnimator(weaponObj3, sJAnimationAsset);
			sJAnimator2.AddMask(gameObject2.name, recursively: true);
			newWeaponAnimator = AddAnimator(gameObject, sJAnimationAsset2);
			newHandAnimator = AddAnimator(gameObject2, sJAnimationAsset);
		}
		else
		{
			sJAnimator = AddAnimator(weaponObj, sJAnimationAsset2);
			sJAnimator2 = AddAnimator(gameobj, sJAnimationAsset);
		}
		if (weaponInfo.HideViewHand)
		{
			WeaponUtility.SetHandBoneScale(sJAnimator2, 0.0001f, weaponInfo.Name);
		}
		LayerUtility.SetLayerRecursively(weaponObj, LayerMask.NameToLayer("FPSArmWeapon"));
		LayerUtility.SetLayerRecursively(gameobj, LayerMask.NameToLayer("FPSArmWeapon"));
		cameraObject = loadResults["HandCamera"].GameObject;
		InitCameraObject(cameraObject);
		GameObject gameObject3 = null;
		if (loadResults.ContainsKey("KnifeEffect"))
		{
			gameObject3 = loadResults["KnifeEffect"].GameObject;
			WorldCameraContext worldCamera = Contexts.sharedInstance.worldCamera;
			if (worldCamera != null && worldCamera.hasUnityObjects && worldCamera.unityObjects.mainCamera != null)
			{
				gameObject3.transform.SetParent(Contexts.sharedInstance.worldCamera.unityObjects.mainCamera.transform, worldPositionStays: false);
			}
			ParticleEffectUtility.InitWeaponParticle(gameObject3, weaponInfo.Name);
		}
		ParticleEditorLogicAsset particleEditorLogicAsset = null;
		if (loadResults.ContainsKey("WeaponLogicXml"))
		{
			particleEditorLogicAsset = loadResults["WeaponLogicXml"].Object as ParticleEditorLogicAsset;
		}
		List<IEntitsFireEffectControl> list = new List<IEntitsFireEffectControl>();
		WeaponUtility.GetLeftFireDict(weaponObj, list);
		List<IEntitsFireEffectControl> list2 = new List<IEntitsFireEffectControl>();
		WeaponUtility.GetRightFireDict(weaponObj, list2);
		if (particleEditorLogicAsset != null)
		{
			list.Clear();
			list2.Clear();
		}
		if (!_weaponSkinsCache.TryGetValue(weaponObj, out var value2))
		{
			value2 = new Dictionary<IgnoreCaseString, SkinnedMeshRenderer>();
			WeaponUtility.GetSkins(weaponObj, value2);
			_weaponSkinsCache.Add(weaponObj, value2);
		}
		if (!_particlesCache.TryGetValue(weaponObj, out var value3))
		{
			value3 = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();
			WeaponUtility.GetParticles(weaponObj, value3);
			_particlesCache.Add(weaponObj, value3);
		}
		if (!_particlesCache.TryGetValue(gameobj, out var value4))
		{
			value4 = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();
			WeaponUtility.GetParticles(gameobj, value4);
			_particlesCache.Add(gameobj, value4);
		}
		SkinnedMeshRenderer[] componentsInChildren2 = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>();
		SkinnedMeshRenderer[] componentsInChildren3 = weaponObj.GetComponentsInChildren<SkinnedMeshRenderer>();
		WeaponUtility.SetWeaponColor(SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData, componentsInChildren3);
		entity.AddFirstPersonUnityObjects(weaponInfo.Name, entity.currentWeapon.SkinName, entity.basicInfo.SkinName, entity.basicInfo.Current.CurrentHandName, entity.currentWeapon.Worn, entity.currentWeapon.QuenchId, gameobj, weaponObj, cameraObject, sJAnimator2, sJAnimator, newHandAnimator, newWeaponAnimator, list, list2, value2, value3, value4, componentsInChildren2, componentsInChildren3, gameObject3, new Color(0f, 0f, 0f, 0f), SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData, particleEditorLogicAsset, 0, 0, entity.dyeingColor.dyeingColors, entity.GetCurrentWeaponDyeingColors());
		SetJoinFollowTransform(gameobj, weaponObj, weaponInfo, skinInfo);
		ParticleManager.InitWeaponParticleXmlLoadResults(loadResults, weaponInfo, skinInfo);
		ParticleManager.InitPlayerParticleXmlLoadResults(loadResults, careerInfo2, skinInfo2);
		SkinUtility.InitSkinSpecailWithLight(weaponObj, skinInfo);
		gameobj.transform.SetParent(_firstHand.transform, worldPositionStays: false);
		weaponObj.transform.SetParent(_firstHand.transform, worldPositionStays: false);
		_firstHand.transform.SetParent(null, worldPositionStays: false);
		AdjustCamera(gameobj, cameraObject, cameraConfigAsset);
		AdjustForDontClearOptimize(gameobj, weaponObj, cameraObject);
		ResetFirstWeaponLight(weaponInfo, skinInfo);
		_fov = 0f;
		AddWeaponAlphaShadow(weaponObj.transform, weaponInfo, skinInfo);
		if (!string.IsNullOrEmpty(entity.GetCurrentWeaponDyeingColors()))
		{
			SkinUtility.InitDyeingMaterial(ref weaponObj, loadResults["weapon_body_mask1"].Object as Texture2D, null, entity.GetCurrentWeaponDyeingColors());
		}
	}

	public void AddWeaponAlphaShadow(Transform gun, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo weaponSkinInfo)
	{
		if (weaponInfo.Name == "bone_wild_rifle")
		{
			bool flag = weaponSkinInfo != null && weaponSkinInfo.Name == "skin_bone_wild_rifle_perish";
			Transform transform = gun.Find("gln_gy_H");
			if (transform != null && !transform.GetComponent<WeaponAlphaShadow>())
			{
				WeaponAlphaShadow weaponAlphaShadow = transform.TryAddComponent<WeaponAlphaShadow>();
				weaponAlphaShadow.maxCount = 3;
				weaponAlphaShadow.ShowTime = 99f;
				weaponAlphaShadow.Interval = 0.1f;
				weaponAlphaShadow.Color = (flag ? new Color(0f, 0f, 1f, 0.1f) : new Color(1f, 0f, 0f, 0.1f));
			}
		}
	}

	public void CameraRevise()
	{
		Camera component = cameraObject.GetComponent<Camera>();
		Transform transform = _firstHand.transform;
		eye.nearClipPlane = 0.5f;
		transform.position = Vector3.zero;
		transform.localScale = Vector3.one;
		transform.rotation = Quaternion.identity;
		transform.GetComponent<RotateWithEye>().enabled = false;
		Matrix4x4 matrix = eye.worldToCameraMatrix.inverse * (eye.projectionMatrix.inverse * (component.projectionMatrix * component.worldToCameraMatrix * transform.localToWorldMatrix));
		transform.SetParent(eye.transform, worldPositionStays: false);
		transform.position = matrix.ExtractPosition();
		transform.rotation = matrix.ExtractRotation();
		transform.localScale = matrix.ExtractScale();
		eye.nearClipPlane = 2f;
		component.enabled = false;
		if ((eye.cullingMask & (1 << LayerMask.NameToLayer("FPSArmWeapon"))) < 1)
		{
			eye.cullingMask += 1 << LayerMask.NameToLayer("FPSArmWeapon");
		}
	}

	private void ResetFirstWeaponLight(IEntitsWeaponInfo weaponInfo, WeaponSkinInfo weaponSkinInfo)
	{
		GameObject gameObject = GameObject.Find("FirstWeaponLight");
		if (!(gameObject != null) || gameObject.transform.childCount != 1)
		{
			return;
		}
		Transform child = gameObject.transform.GetChild(0);
		if (child.GetComponent<Light>() != null)
		{
			if (!_findFirstWeaponLight)
			{
				_findFirstWeaponLight = true;
				_fistWeaponLightAngle = child.transform.localEulerAngles;
			}
			if (weaponSkinInfo != null && !string.IsNullOrEmpty(weaponSkinInfo.FirstLightDir))
			{
				child.transform.localEulerAngles = weaponSkinInfo.FirstLightAngle;
			}
			else
			{
				child.transform.localEulerAngles = _fistWeaponLightAngle;
			}
		}
	}

	private static void InitCameraObject(GameObject cameraObject)
	{
		cameraObject.name = "HandCamera";
		Camera component = cameraObject.GetComponent<Camera>();
		component.fieldOfView = FovUtility.SsjjFovToUnityFov(75f, Screen.width, Screen.height);
		component.cullingMask = LayerMask.GetMask("FPSArmWeapon");
		component.clearFlags = CameraClearFlags.Depth;
		component.depth = 1f;
		if (RuleUtilty.IsUltimateChallenge())
		{
			cameraObject.AddComponent<PostProcessLayer>();
		}
	}

	private void AdjustForDontClearOptimize(GameObject handObj, GameObject weaponObj, GameObject cameraObject)
	{
		float num = 0.2f;
		weaponObj.transform.localScale = Vector3.one * num;
		handObj.transform.localScale = Vector3.one * num;
		cameraObject.transform.localScale = Vector3.one;
	}

	private void AdjustCamera(GameObject handObj, GameObject cameraObj, FirstHandCameraConfig config)
	{
		cameraObj.transform.SetParent(handObj.transform, worldPositionStays: false);
		if (config.Model3D != null)
		{
			Transform transform = handObj.transform.Find("PlayerMesh");
			if (transform == null)
			{
				transform = new GameObject("PlayerMesh").transform;
				transform.SetParent(handObj.transform, worldPositionStays: false);
				Transform transform2 = handObj.transform.Find("Bip01");
				if (transform2 != null)
				{
					transform2.transform.SetParent(transform, worldPositionStays: true);
				}
			}
			AdjustCameraTransform(transform, config.Model3D.InnerText);
		}
		float offsetX = 0f;
		string innerText;
		switch (ScreenConstant.GetScreenRation())
		{
		case 2:
			innerText = config.Camera2.InnerText;
			break;
		case 1:
			if (config.Camera3 != null)
			{
				innerText = config.Camera3.InnerText;
				break;
			}
			innerText = config.Camera2.InnerText;
			offsetX = 10f;
			break;
		default:
			innerText = config.Camera1.InnerText;
			break;
		}
		AdjustCameraTransform(cameraObj.transform, innerText, offsetX);
	}

	private void AdjustCameraTransform(Transform cameraTransform, string matrixText, float offsetX = 0f)
	{
		if (!_cameraTranCache.TryGetValue(matrixText, out var value))
		{
			string[] array = matrixText.Split(" ");
			double[] array2 = new double[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (double.TryParse(array[i], out var result))
				{
					array2[i] = result;
				}
				else
				{
					array2[i] = 0.0;
				}
			}
			value = new Matrix3D(array2).Decompose();
			_cameraTranCache.Add(matrixText, value);
		}
		Vector3D vector3D = value[0];
		value[1].ScaleBy(180f / (float)Math.PI);
		cameraTransform.localPosition = new Vector3((float)(0.0 - (vector3D.x + (double)offsetX)), (float)vector3D.z, (float)(0.0 - vector3D.y));
	}

	private void CheckEmptyWeapon(IEntitsWeaponInfo weaponInfo, GameObject obj)
	{
		if (WeaponUtility.IsEmptyWeapon(weaponInfo.Name))
		{
			SkinnedMeshRenderer[] componentsInChildren = obj.GetComponentsInChildren<SkinnedMeshRenderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enabled = false;
			}
		}
	}

	private void UpdateSkinnedMeshRendersWhenOffScreen(GameObject obj)
	{
		SkinnedMeshRenderer[] componentsInChildren = obj.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer obj2 in componentsInChildren)
		{
			obj2.updateWhenOffscreen = true;
			obj2.shadowCastingMode = ShadowCastingMode.Off;
			obj2.receiveShadows = false;
		}
	}

	private GameObject FindChild(GameObject target, IgnoreCaseString name)
	{
		Transform[] componentsInChildren = target.GetComponentsInChildren<Transform>(includeInactive: true);
		for (int num = componentsInChildren.Length - 1; num >= 0; num--)
		{
			Transform transform = componentsInChildren[num];
			if (name.Equals(transform.name))
			{
				return transform.gameObject;
			}
		}
		return null;
	}

	private void FindChild(GameObject target, IgnoreCaseString name1, IgnoreCaseString name2, out GameObject part1, out GameObject part2)
	{
		part1 = null;
		part2 = null;
		Transform[] componentsInChildren = target.GetComponentsInChildren<Transform>(includeInactive: true);
		for (int num = componentsInChildren.Length - 1; num >= 0; num--)
		{
			Transform transform = componentsInChildren[num];
			string name3 = transform.name;
			if (part1 == null && name1.Equals(name3))
			{
				part1 = transform.gameObject;
				if (part1 != null && part2 != null)
				{
					break;
				}
			}
			else if (part2 == null && name2.Equals(name3))
			{
				part2 = transform.gameObject;
				if (part1 != null && part2 != null)
				{
					break;
				}
			}
		}
	}

	private void SetJoinFollowTransform(GameObject handObj, GameObject weaponObj, IEntitsWeaponInfo info, WeaponSkinInfo skinInfo)
	{
		GameObject part;
		GameObject part2;
		if (_anchorCache.TryGetValue(handObj, out var value))
		{
			part = value.Key;
			part2 = value.Value;
		}
		else
		{
			FindChild(handObj, "Bip01_L_Hand", "Bip01_R_Hand", out part, out part2);
			value = new KeyValuePair<GameObject, GameObject>(part, part2);
			_anchorCache.Add(handObj, value);
		}
		GameObject part3;
		GameObject part4;
		if (_anchorCache.TryGetValue(weaponObj, out value))
		{
			part3 = value.Key;
			part4 = value.Value;
		}
		else
		{
			FindChild(weaponObj, "Bip01_L_Hand", "Bip01_R_Hand", out part3, out part4);
			value = new KeyValuePair<GameObject, GameObject>(part3, part4);
			_anchorCache.Add(weaponObj, value);
		}
		if (part != null && part3 != null)
		{
			FollowTransform2.Follow(part3.transform, part.transform);
			SetWeaponSkinLight(part3.transform, weaponObj.transform, skinInfo);
		}
		if (part2 != null && part4 != null)
		{
			FollowTransform2.Follow(part4.transform, part2.transform);
			SetWeaponSkinLight(part4.transform, weaponObj.transform, skinInfo);
		}
	}

	private void SetWeaponSkinLight(Transform anchor, Transform weaponObj, WeaponSkinInfo skinInfo)
	{
		if (skinInfo == null)
		{
			return;
		}
		Transform transform = weaponObj.transform.Find("Light(Clone)");
		if (transform != null)
		{
			transform.SetParent(anchor);
			if (!string.IsNullOrEmpty(skinInfo.FollowLightDiffDir))
			{
				transform.transform.localEulerAngles = skinInfo.FollowLightDiffAngle;
			}
		}
	}

	private void ResetWeaponAnchorScale(GameObject obj)
	{
		GameObject part;
		GameObject part2;
		if (_weaponAnchorCache.TryGetValue(obj, out var value))
		{
			part = value.Key;
			part2 = value.Value;
		}
		else
		{
			FindChild(obj, "WeaponAnchor", "WeaponAnchor2", out part, out part2);
			_weaponAnchorCache.Add(obj, new KeyValuePair<GameObject, GameObject>(part, part2));
		}
		if (part != null)
		{
			part.transform.localScale = Vector3.one;
		}
		if (part2 != null)
		{
			part2.transform.localScale = Vector3.one;
		}
	}

	private static SJAnimator AddAnimator(GameObject weaponObj, SJAnimationAsset weaponAnims)
	{
		SJAnimator sJAnimator = weaponObj.GetComponent<SJAnimator>();
		if (sJAnimator == null)
		{
			sJAnimator = weaponObj.AddComponent<SJAnimator>();
			sJAnimator.AddLayer(0, 1f);
		}
		sJAnimator.Reset();
		sJAnimator.AddAnimationClips(0, weaponAnims.Clips);
		sJAnimator.SetMultiThreadSupport(multi: false);
		return sJAnimator;
	}

	public void OnRender()
	{
		if (RuleUtilty.IsUltimateChallenge() || RuleUtilty.IsTpsMode() || FreeErrorMap() || RuleUtilty.IsBioMode(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			return;
		}
		if (eye == null)
		{
			eye = Camera.main;
		}
		if (eye == null)
		{
			return;
		}
		if (Mathf.Abs(eye.fieldOfView - _fov) > 0.1f)
		{
			foreach (PlayerEntity player in _players)
			{
				SetCamera(player);
				_fov = eye.fieldOfView;
			}
		}
		if (!(cameraObject == null) && !(_firstHand == null) && cameraObject.activeSelf != _firstHand.activeSelf)
		{
			_firstHand.SetActive(cameraObject.activeSelf);
		}
	}

	public bool FreeErrorMap()
	{
		if (Contexts.sharedInstance.battleRoom.roomData.Data.SceneId == 1500)
		{
			return true;
		}
		return false;
	}

	public void SetCamera(PlayerEntity entity)
	{
		_firstHand.transform.SetParent(null, worldPositionStays: false);
		AdjustCamera(entity.firstPersonUnityObjects.HandGameObject, cameraObject, cameraConfigAsset);
		CameraRevise();
	}
}
