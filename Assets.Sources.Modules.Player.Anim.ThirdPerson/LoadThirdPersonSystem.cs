using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Scripts.Asset;
using Assets.Scripts.Effect.Level;
using Assets.Scripts.Utility;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.CsvLoader;
using Assets.Sources.Extensions;
using Assets.Sources.Framework;
using Assets.Sources.Info.Career;
using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Info.CyberStyle;
using Assets.Sources.Info.ThirdWeaponAnim;
using Assets.Sources.Info.Weapon;
using Assets.Sources.Modules.Player.Anim.ThirdPerson.Utility;
using Assets.Sources.Modules.Player.Sound;
using Assets.Sources.Particle;
using Assets.Sources.Utils;
using Assets.Sources.Utils.ComponentInit;
using Assets.Sources.Utils.PlayerAnim;
using Assets.Sources.Utils.Tps;
using Assets.Sources.Utils.Weapon;
using Assets.Sources.XmlAsset;
using Entitas;
using NetData;
using SSJJAnim.Animator;
using SSJJAnim.CareerAnim;
using SSJJAnim.Parser;
using SSJJAnim.Player;
using SSJJAsset.Asset;
using SSJJAsset.AssetBundle;
using SSJJAvater;
using SSJJBase.Extensions;
using SSJJBase.Logger;
using SSJJBase.Manager;
using SSJJBase.Obscure;
using SSJJBase.Pool;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJBase.Thread;
using SSJJIK;
using SSJJMath;
using SSJJUIEditor.ParticleEditor;
using UnityEngine;

namespace Assets.Sources.Modules.Player.Anim.ThirdPerson;

public class LoadThirdPersonSystem : LoadAndInitResourceSystem<PlayerEntity>
{
	private readonly IGroup<PlayerEntity> _loadGroup;

	private readonly IGroup<PlayerEntity> _initGroup;

	private readonly PlayerContext _playerContext;

	private Transform _thirdPersonResources;

	private Dictionary<string, string> _weaponAnimCache = new Dictionary<string, string>();

	private const string RightAnchor = "rightanchor";

	private const string LeftAnchor = "leftanchor";

	public LoadThirdPersonSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_loadGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo).NoneOf(PlayerMatcher.DontLoadThirdPerson, PlayerMatcher.PartBasicInfo, PlayerMatcher.LoadThirdPersonResource, PlayerMatcher.ThirdPersonResource));
		_initGroup = contexts.player.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.ThirdPersonResource));
		_thirdPersonResources = new GameObject("thirdPersonResources").transform;
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
		ICareerInfo careerInfo = entity.basicInfo.CareerInfo;
		IEntitsWeaponInfo entitsWeaponInfo;
		if (GameSetting.Config.ShowThirdWeapon <= 0)
		{
			IEntitsWeaponInfo weaponInfo = WeaponInfoFactory.Instance.GetWeaponInfo(WeaponConstant.GetDefaultWeaponName(entity.currentWeapon.Name));
			entitsWeaponInfo = weaponInfo;
		}
		else
		{
			entitsWeaponInfo = entity.currentWeapon.WeaponInfo;
		}
		IEntitsWeaponInfo entitsWeaponInfo2 = entitsWeaponInfo;
		if (entitsWeaponInfo2 == null)
		{
			return;
		}
		WeaponSkinInfo skinInfo = ((GameSetting.Config.ShowThirdWeapon > 0) ? BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(entity.currentWeapon.SkinName) : null);
		PlayerSkinInfo skinInfo2 = PlayerSkinInfoFactory.Instance.GetSkinInfo(entity.basicInfo.SkinName);
		IgnoreCaseString assetBundleName = new IgnoreCaseString(careerInfo.PrefabBundleName);
		if (!entity.hasThirdPersonUnityObjects && !AssetBundleManager.IsAssetBundleDownloaded(ref assetBundleName))
		{
			AssetBundleManager.LoadAssetBundle(ref assetBundleName);
		}
		IgnoreCaseString assetBundleName2 = new IgnoreCaseString(entitsWeaponInfo2.AssetBundleName);
		if (!entity.hasThirdPersonUnityObjects)
		{
			if (!AssetBundleManager.IsAssetBundleDownloaded(ref assetBundleName2))
			{
				AssetBundleManager.LoadAssetBundle(ref assetBundleName2);
			}
		}
		else
		{
			AssetBundleManager.LoadAssetBundle(ref assetBundleName2);
		}
		if (!AssetBundleManager.IsAssetBundleDownloaded(ref assetBundleName2) || (entity.hasThirdPersonUnityObjects && entity.thirdPersonUnityObjects.WeaponInfo == entitsWeaponInfo2 && entity.thirdPersonUnityObjects.CareerInfo == careerInfo && entity.thirdPersonUnityObjects.WeaponSkinName == entity.currentWeapon.SkinName && entity.thirdPersonUnityObjects.PlayerSkinName == entity.basicInfo.SkinName && Math.Abs(entity.thirdPersonUnityObjects.Worn - entity.currentWeapon.Worn) < 0.01f))
		{
			return;
		}
		LoadSpecificCareerAndWeapon(entity, careerInfo, entitsWeaponInfo2, skinInfo, skinInfo2);
		List<IEntitsWeaponInfo> weaponInfoList = entity.qianglingWeapon.WeaponInfoList;
		if (weaponInfoList == null || weaponInfoList.Count <= 0)
		{
			return;
		}
		foreach (IEntitsWeaponInfo item in weaponInfoList)
		{
			IgnoreCaseString assetBundleName3 = new IgnoreCaseString(item.AssetBundleName);
			if (!AssetBundleManager.IsAssetBundleDownloaded(ref assetBundleName3))
			{
				AssetBundleManager.LoadAssetBundle(ref assetBundleName3);
			}
		}
	}

	private void LoadSpecificCareerAndWeapon(PlayerEntity entity, ICareerInfo career, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo skinInfo, PlayerSkinInfo playerSkinInfo)
	{
		if (SpecailDebug.Instance.RecordWeaponPlayerMsg)
		{
			MonoBehaviourSingleton<RecordWeaponPlayerManager>.Instance.Record(entity.basicInfo.Cid, weaponInfo.Name);
		}
		LoadRequests loadRequests = new LoadRequests(42);
		if (PlayerAnimationUtility.isGPUAnim(career.Name))
		{
			loadRequests.Add("CareerModel", new LoadRequest(new AssetInfo(career.PrefabBundleName, "model_mesh", typeof(GameObject)), typeof(ThirdPersonCareerGameObject)));
			loadRequests.AddAsset("anim_anim", new AssetInfo(career.PrefabBundleName, "GPUSKinning_Anim", typeof(GPUSkinningAnimation), optional: true));
			loadRequests.AddAsset("anim_mat", new AssetInfo(career.PrefabBundleName, "GPUSKinning_Material", typeof(Material), optional: true));
			loadRequests.AddAsset("anim_mesh", new AssetInfo(career.PrefabBundleName, "GPUSKinning_Mesh", typeof(Mesh), optional: true));
			loadRequests.AddAsset("anim_tex", new AssetInfo(career.PrefabBundleName, "GPUSKinning_Texture", typeof(TextAsset), optional: true));
		}
		else
		{
			loadRequests.AddAsset("TorseAnim", new AssetInfo(career.AnimBundleName, career.TorseAnimAssetName, typeof(SJAnimationAsset), optional: true));
			if (!RuleUtilty.EnableAvater() && (career.AnimBundleName.Equals("playeranim/manct", StringComparison.OrdinalIgnoreCase) || career.AnimBundleName.Equals("playeranim/woman", StringComparison.OrdinalIgnoreCase)))
			{
				List<string> careerAnimations = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimations(CareerData.GetCareerAnimationType(career.Name));
				if (careerAnimations != null)
				{
					foreach (string item in careerAnimations)
					{
						loadRequests.AddAsset(item, new AssetInfo(career.AnimBundleName, item + ".anm.bytes", typeof(SJAnimationAsset), optional: true));
					}
				}
			}
			loadRequests.AddAsset("LegAnim", new AssetInfo(career.AnimBundleName, career.LegAnimAssetName, typeof(SJAnimationAsset), optional: true));
		}
		SkinUtility.AddCareerModelRequest(loadRequests, career, playerSkinInfo, entity);
		loadRequests.AddAsset("WeaponLegAnim", new AssetInfo(career.AnimBundleName, career.GetWeaponLegAnimName(weaponInfo), typeof(SJAnimationAsset), optional: true));
		loadRequests.AddAsset("WeaponBodyAnim", new AssetInfo(career.AnimBundleName, career.GetWeaponBodyAnimName(weaponInfo), typeof(SJAnimationAsset), optional: true));
		if (career.Name != weaponInfo.Name && !career.Name.StartsWith("rpg"))
		{
			SkinUtility.AddThirdModelRequest(loadRequests, weaponInfo, skinInfo);
		}
		if (!string.IsNullOrEmpty(entity.GetCurrentWeaponDyeingColors()))
		{
			SkinUtility.AddWeaponBodyMask1Request(loadRequests, weaponInfo, skinInfo);
		}
		foreach (string weaponAnimAssetName in career.GetWeaponAnimAssetNames(weaponInfo))
		{
			string value = null;
			if (!_weaponAnimCache.TryGetValue(weaponAnimAssetName, out value))
			{
				value = $"WeaponAnim_{weaponAnimAssetName}";
				_weaponAnimCache[weaponAnimAssetName] = value;
			}
			loadRequests.AddAsset(value, new AssetInfo(career.DynAnimBundleName, weaponAnimAssetName, typeof(SJAnimationAsset), optional: true));
		}
		if (!RuleUtilty.EnableAvater())
		{
			loadRequests.AddAsset("ThirdWeaponAnim", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ThirdWeaponAnimationAssetName, typeof(SJAnimationAsset), optional: true));
		}
		else
		{
			loadRequests.AddAsset("ThirdWeaponAnim", new AssetInfo("playeranim/unitymanct", "Assets/Res/Assets/playeAnim/unityManCT/" + weaponInfo.ThirdWeaponAnimationAssetName + ".anm.bytes", typeof(SJAnimationAsset), optional: true));
		}
		loadRequests.AddAsset("ThirdWeaponAnimXml", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.ThirdWeaponAnimationXmlAssetName, typeof(ThirdWeaponAnimInfo), optional: true));
		loadRequests.AddAsset("WeaponCameraEffectConfig", new AssetInfo(weaponInfo.AssetBundleName, weaponInfo.CameraEffectConfigAssetName, typeof(CameraEffectConfig), optional: true));
		loadRequests.AddAsset("CareerAnimConfig", new AssetInfo(career.AnimBundleName, career.AnimConfigAssetName, typeof(DefaultCareerAnimInfo)));
		loadRequests.AddAsset("CameraEffectConfig", new AssetInfo(career.PrefabBundleName, career.CameraEffectConfigAssetName, typeof(CameraEffectConfig), optional: true));
		loadRequests.Add("KnifeEffect", new LoadRequest(ResourceUtility.GetKnifeAttackEffectThirdRequest(weaponInfo.Name, skinInfo), typeof(ThirdPersonKnifeEffect)));
		loadRequests.Add("weaponConfig", new LoadRequest(new AssetInfo(weaponInfo.AssetBundleName, $"Assets/Res/Assets/weapon/{weaponInfo.Name}/weapon.xml", typeof(WeaponConfigXmlAsset), optional: true)));
		ParticleManager.InitWeaponParticleXmlLoadRequests(loadRequests, weaponInfo, skinInfo);
		ParticleManager.InitPlayerParticleXmlLoadRequests(loadRequests, career, playerSkinInfo);
		List<IEntitsWeaponInfo> weaponInfoList = entity.qianglingWeapon.WeaponInfoList;
		List<QianglingWeaponData> weaponList = entity.qianglingWeapon.weaponList;
		if (weaponInfoList != null && weaponInfoList.Count > 0)
		{
			QianglingSkinUtility.KeyBaseSkinTextureList.Clear();
			QianglingSkinUtility.KeySkinTextureList.Clear();
			for (int i = 0; i < weaponInfoList.Count; i++)
			{
				IEntitsWeaponInfo entitsWeaponInfo = weaponInfoList[i];
				QianglingWeaponData qianglingWeaponData = weaponList[i];
				new IgnoreCaseString(entitsWeaponInfo.AssetBundleName);
				WeaponSkinInfo skinInfo2 = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(qianglingWeaponData.SkinName);
				loadRequests.Add("QianglingWeaponModel" + i, new LoadRequest(new AssetInfo(entitsWeaponInfo.AssetBundleName, entitsWeaponInfo.ThirdAssetName, typeof(GameObject), optional: true), typeof(ThirdPersonWeaponGameObject)));
				loadRequests.AddAsset("QianglingThirdWeaponAnim" + i, new AssetInfo(entitsWeaponInfo.AssetBundleName, entitsWeaponInfo.ThirdWeaponAnimationAssetName, typeof(SJAnimationAsset), optional: true));
				loadRequests.AddAsset("QianiglingThirdWeaponAnimXml" + i, new AssetInfo(entitsWeaponInfo.AssetBundleName, entitsWeaponInfo.ThirdWeaponAnimationXmlAssetName, typeof(ThirdWeaponAnimInfo), optional: true));
				loadRequests.AddAsset("QianiglingThirdWeaponLogicXml" + i, new AssetInfo(entitsWeaponInfo.AssetBundleName, entitsWeaponInfo.LogicXmlAssetName, typeof(ParticleEditorLogicAsset), optional: true));
				QianglingSkinUtility.AddQianglingTextureRequests(loadRequests, entitsWeaponInfo, skinInfo2, i);
			}
		}
		entity.AddLoadThirdPersonResource(loadRequests, GetResourceKey(career, weaponInfo));
		entity.ReplacePlayerDisaplay(career, weaponInfo);
	}

	private KeyValuePair<ICareerInfo, IEntitsWeaponInfo> GetResourceKey(ICareerInfo career, IEntitsWeaponInfo weapon)
	{
		return new KeyValuePair<ICareerInfo, IEntitsWeaponInfo>(career, weapon);
	}

	protected override bool IsResourceMatch(PlayerEntity entity)
	{
		KeyValuePair<ICareerInfo, IEntitsWeaponInfo> keyValuePair = (KeyValuePair<ICareerInfo, IEntitsWeaponInfo>)entity.thirdPersonResource.Identifier;
		ICareerInfo career = entity.playerDisaplay.Career;
		IEntitsWeaponInfo weapon = entity.playerDisaplay.Weapon;
		if (keyValuePair.Key == career)
		{
			return keyValuePair.Value == weapon;
		}
		return false;
	}

	protected override void CleanResouceComponent(PlayerEntity entity)
	{
		entity.RemoveThirdPersonResource();
	}

	private static void AddAnimation(ISjAnimatior animator, LoadResults loadResults, string resourceKey)
	{
		if (loadResults.ContainsKey(resourceKey))
		{
			if (resourceKey == "p3anim")
			{
				SJAnimationAsset sJAnimationAsset = loadResults[resourceKey].Object as SJAnimationAsset;
				animator.AddAnimationClips(0, sJAnimationAsset.Clips);
			}
			else
			{
				SJAnimationAsset sJAnimationAsset2 = loadResults[resourceKey].Object as SJAnimationAsset;
				animator.AddAnimationClips(1, sJAnimationAsset2.Clips);
			}
		}
	}

	protected override void OnInitEntityResource(PlayerEntity player)
	{
		LoadDone(player);
	}

	private void LoadDone(PlayerEntity player)
	{
		if (player.hasThirdPersonUnityObjects)
		{
			PlayerEntityUtility.CleanupThirdPersonUnityObjects(player);
		}
		ICareerInfo career = player.playerDisaplay.Career;
		IEntitsWeaponInfo weapon = player.playerDisaplay.Weapon;
		LoadResults loadResults = player.thirdPersonResource.LoadResults;
		WeaponSkinInfo skinInfo = ((GameSetting.Config.ShowThirdWeapon > 0) ? BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(player.currentWeapon.SkinName) : null);
		PlayerSkinInfo skinInfo2 = PlayerSkinInfoFactory.Instance.GetSkinInfo(player.basicInfo.SkinName);
		TotalMemoryUtility.LoadWeapon(weapon.Name);
		TotalMemoryUtility.LoadPlayer(career.Name);
		ThirdResUnloadUtility.LoadThirdRes(player, weapon, career, skinInfo2, skinInfo);
		GameObject gameObject = new GameObject(player.basicInfo.PlayerName);
		gameObject.transform.SetParent(_thirdPersonResources, worldPositionStays: false);
		GameObject gameObject2 = new GameObject("wrapper");
		gameObject2.transform.localScale = Vector3.one * (1f + player.basicInfo.Current.Scale);
		gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: false);
		gameObject2.transform.localEulerAngles = VectorCoordConverter.CareerModellToUnityEularAngle;
		GameObject gameobj = loadResults["CareerModel"].GameObject;
		gameobj.name = career.Name;
		gameobj.transform.SetParent(gameObject2.transform, worldPositionStays: false);
		gameobj.transform.localPosition = Vector3.zero;
		gameobj.transform.localEulerAngles = Vector3.zero;
		ParticleEffectUtility.InitPlayerParticle(gameobj, career.Name);
		SkinnedMeshRenderer[] array = null;
		GameUnityAvaterJob gameUnityAvaterJob = null;
		if (loadResults.ContainsKey("anim_anim"))
		{
			LoadGPUAnim(gameobj, loadResults, player, gameObject, gameObject2, career, weapon, skinInfo, skinInfo2);
			return;
		}
		SkinUtility.InitDyeingMaterial(ref gameobj, loadResults["body_mask1"].Object as Texture2D, loadResults["body_mask2"].Object as Texture2D, player.GetDyeingColors());
		if (RuleUtilty.EnableAvater())
		{
			gameUnityAvaterJob = new GameUnityAvaterJob();
			gameUnityAvaterJob.playerName = career.Name;
			UnityAvaterInitData data = default(UnityAvaterInitData);
			data.InitedGameObject = gameobj;
			data.EquipmentDict = new Dictionary<string, string[]>();
			string moduleNames = player.basicInfo.Current.ModuleNames;
			if (!string.IsNullOrEmpty(moduleNames))
			{
				string[] array2 = moduleNames.Split(':');
				data.EquipmentDict["head"] = new string[1] { array2[0] };
				data.EquipmentDict["body"] = new string[1] { array2[1] };
				data.EquipmentDict["feet"] = new string[1] { array2[2] };
				gameUnityAvaterJob.Init(ref data);
				UnityAvaterJobData data2 = default(UnityAvaterJobData);
				data2.UpdateRotation = Quaternion.Euler(270f, 0f, 0f);
				data2.CombineMesh = false;
				data2.CombineMaterial = false;
				data2.Args.Add(new UnityAvaterJobArg
				{
					Src = "head",
					Dst = array2[0]
				});
				data2.Args.Add(new UnityAvaterJobArg
				{
					Src = "body",
					Dst = array2[1]
				});
				data2.Args.Add(new UnityAvaterJobArg
				{
					Src = "feet",
					Dst = array2[2]
				});
				gameUnityAvaterJob.Excute(ref data2);
			}
			else
			{
				this.LogError("player modulesname is Null");
			}
			array = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>();
		}
		else
		{
			array = gameobj.GetComponentsInChildren<SkinnedMeshRenderer>();
			Dictionary<string, TextureConfigItem> dictionary = null;
			if (loadResults.ContainsKey("TextureConfig"))
			{
				dictionary = ((TextureConfigInfo)loadResults["TextureConfig"].Object).TextureConfigs;
			}
			SkinnedMeshRenderer skinnedMeshRenderer = null;
			SkinnedMeshRenderer[] array3 = array;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer2 in array3)
			{
				if (skinnedMeshRenderer2.enabled)
				{
					skinnedMeshRenderer = skinnedMeshRenderer2;
					break;
				}
			}
			if (skinnedMeshRenderer == null)
			{
				skinnedMeshRenderer = array[0];
			}
			Material material = skinnedMeshRenderer.material;
			if (dictionary != null && skinnedMeshRenderer.sharedMaterial != null && skinnedMeshRenderer.sharedMaterial.mainTexture != null)
			{
				foreach (KeyValuePair<string, TextureConfigItem> item in dictionary)
				{
					if (item.Value.AlphaKill > 0)
					{
						material.SetInt("_CullAlphaEnable", 1);
						if (career.Name != null && career.Name == "rpg_by_parasitism")
						{
							material.SetFloat("_CullAlpha", 0.4f);
						}
						else
						{
							material.SetFloat("_CullAlpha", item.Value.AlphaKillValue);
						}
					}
					if (item.Value.Translucet > 0)
					{
						material.SetInt("_ZWrite", 0);
					}
					if (!player.hasTextureConfig)
					{
						player.AddTextureConfig(item.Value.AlphaKill, item.Value.Translucet);
					}
				}
			}
		}
		SJAnimator component = gameobj.GetComponent<SJAnimator>();
		component.CullMode = AnimatorCullingMode.CullCompletely;
		component.SetCareer(career.Name);
		DefaultCareerAnimInfo careerAnimInfo = loadResults["CareerAnimConfig"].Object as DefaultCareerAnimInfo;
		BattleSingletonInstance<CareerAnimInfoFactory>.Instance.AddCareerAnimInfo(career, careerAnimInfo);
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		InitAudioSource(audioSource);
		Transform bone = component.GetBone("bip01_head");
		AddAnimation(component, loadResults, "TorseAnim");
		List<string> careerAnimations = BattleSingletonInstance<CareerAnimInfoFactory>.Instance.GetCareerAnimations(CareerData.GetCareerAnimationType(career.Name));
		if (careerAnimations != null)
		{
			foreach (string item2 in careerAnimations)
			{
				AddAnimation(component, loadResults, item2);
			}
		}
		bool flag = false;
		bool flag2 = false;
		if (loadResults.ContainsKey("LegAnim"))
		{
			SJAnimationAsset sJAnimationAsset = loadResults["LegAnim"].Object as SJAnimationAsset;
			component.AddAnimationClips(0, sJAnimationAsset.Clips);
			flag = CheckCopyAnim(component, sJAnimationAsset, 0, "run_blend3", "runb_blend0");
			flag2 = CheckCopyAnim(component, sJAnimationAsset, 0, "walk_blend3", "walkb_blend0");
		}
		if (loadResults.ContainsKey("WeaponLegAnim"))
		{
			SJAnimationAsset sJAnimationAsset2 = loadResults["WeaponLegAnim"].Object as SJAnimationAsset;
			component.AddAnimationClips(0, sJAnimationAsset2.Clips);
		}
		if (loadResults.ContainsKey("WeaponBodyAnim"))
		{
			SJAnimationAsset sJAnimationAsset3 = loadResults["WeaponBodyAnim"].Object as SJAnimationAsset;
			component.AddAnimationClips(0, sJAnimationAsset3.Clips);
		}
		ParticleEditorLogicAsset particleEditorLogicAsset = null;
		if (loadResults.ContainsKey("WeaponLogicXml"))
		{
			particleEditorLogicAsset = loadResults["WeaponLogicXml"].Object as ParticleEditorLogicAsset;
		}
		if (player.hasHitBox)
		{
			player.RemoveHitBox();
		}
		if (loadResults.ContainsKey("HitBox"))
		{
			PlayerEntityUtility.AddHitBox(player);
			HitHelpInfo hitHelpInfo = loadResults["HitBox"].Object as HitHelpInfo;
			player.hitBox.HitBoxList = hitHelpInfo.HitBoxList;
			player.hitBox.HitPreliminaryGeo = hitHelpInfo.HitPreliminaryGeo;
			player.hitBox.BonetTransform = component.GetBones();
		}
		SkinnedMeshRenderer[] array4 = null;
		GameObject weaponObj;
		if (loadResults.ContainsKey("WeaponModel"))
		{
			weaponObj = loadResults["WeaponModel"].GameObject;
			if ((bool)weaponObj.GetComponent<WeaponDissolutionEffect>())
			{
				weaponObj.GetComponent<WeaponDissolutionEffect>().playerEntity = player;
			}
		}
		else
		{
			weaponObj = new GameObject("EmptyThirdWeapon");
		}
		ParticleEffectUtility.InitWeaponParticle(weaponObj, weapon.Name);
		array4 = weaponObj.GetComponentsInChildren<SkinnedMeshRenderer>();
		WeaponUtility.SetWeaponColor(SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData, array4);
		SkinUtility.InitSkin(ref weaponObj, loadResults, player.currentWeapon.Worn, player.currentWeapon.QuenchId, skinInfo);
		weaponObj.transform.SetParent(gameObject2.transform, worldPositionStays: false);
		weaponObj.transform.localPosition = Vector3.zero;
		SJAnimator sJAnimator = null;
		if (loadResults["ThirdWeaponAnim"].Object is SJAnimationAsset)
		{
			sJAnimator = AddThirdWeaponAnimator(weaponObj, loadResults["ThirdWeaponAnim"].Object as SJAnimationAsset);
		}
		if (loadResults["ThirdWeaponAnimXml"].Object != null)
		{
			ThirdWeaponAnimInfoFactory.Instance.AddCareerAnimInfo(weapon.Name, loadResults["ThirdWeaponAnimXml"].Object as IThirdWeaponAnimInfo);
		}
		GameObject gameObject3 = null;
		if (loadResults.ContainsKey("KnifeEffect"))
		{
			gameObject3 = loadResults["KnifeEffect"].GameObject;
			gameObject3.transform.parent = gameObject.transform;
			ParticleEffectUtility.InitWeaponParticle(gameObject3, weapon.Name);
		}
		foreach (string weaponAnimAssetName in career.GetWeaponAnimAssetNames(weapon))
		{
			string value = null;
			if (!_weaponAnimCache.TryGetValue(weaponAnimAssetName, out value))
			{
				value = $"WeaponAnim_{weaponAnimAssetName}";
				_weaponAnimCache[weaponAnimAssetName] = value;
			}
			if (loadResults.ContainsKey(value))
			{
				SJAnimationAsset animAsset = loadResults[value].Object as SJAnimationAsset;
				AddWeaponAnimation(component, animAsset);
			}
		}
		AddWeaponModel(gameobj, weaponObj, weapon, component, player);
		List<IEntitsFireEffectControl> list = new List<IEntitsFireEffectControl>();
		WeaponUtility.GetRightFireDict(weaponObj, list);
		List<IEntitsFireEffectControl> list2 = new List<IEntitsFireEffectControl>();
		WeaponUtility.GetLeftFireDict(weaponObj, list2);
		if (particleEditorLogicAsset != null)
		{
			list2.Clear();
			list.Clear();
		}
		Dictionary<IgnoreCaseString, SkinnedMeshRenderer> dictionary2 = new Dictionary<IgnoreCaseString, SkinnedMeshRenderer>();
		WeaponUtility.GetSkins(weaponObj, dictionary2);
		Dictionary<IParticleKey, IPaticlePrefabInstancecs> dictionary3 = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();
		WeaponUtility.GetParticles(weaponObj, dictionary3);
		ThirdPersonCareerGameObject component2 = gameobj.GetComponent<ThirdPersonCareerGameObject>();
		component2.SetLod(player, weaponObj, dictionary3);
		if (RuleUtilty.EnableAvater())
		{
			SkinnedMeshRenderer[] array3 = array;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer3 in array3)
			{
				if (skinnedMeshRenderer3 != null)
				{
					skinnedMeshRenderer3.updateWhenOffscreen = true;
				}
			}
		}
		ThirdTran newThirdTran = new ThirdTran
		{
			HeadTransform = bone,
			RootContainer = gameObject,
			BodyTransform = gameobj.transform,
			WeaponObj = weaponObj,
			BackRoateNode = component2.RotateNode,
			BackWeaponNode = component2.BackweaponNode,
			BackContainerObj = component2.BackContainerObj
		};
		TpsUtility.TpsContainer tpsContainer = TpsUtility.InitTpsRes(loadResults, player, weapon, gameobj, weaponObj);
		DynamicBoneSsjj[] array5 = tpsContainer?.DynamicBones;
		InverseKinematics newIkinematics = tpsContainer?.Ikinematics;
		Vector3 vector = ((tpsContainer != null) ? (tpsContainer.Scale * Vector3.one) : Vector3.one);
		weaponObj.transform.localScale = vector;
		foreach (SkinnedMeshRenderer skin in component2.Skins)
		{
			CyberMonster component3 = skin.GetComponent<CyberMonster>();
			if (component3 != null)
			{
				component3.playerEntity = player;
			}
		}
		string skinName = player.currentWeapon.SkinName;
		string skinName2 = player.basicInfo.SkinName;
		float worn = player.currentWeapon.Worn;
		int quenchId = player.currentWeapon.QuenchId;
		List<SkinnedMeshRenderer> skins = component2.Skins;
		SJAnimator newWeaponAnimator = sJAnimator;
		GameUnityAvaterJob newAvater = gameUnityAvaterJob;
		Renderer[] newMeshRenders = array;
		GameObject newKnifeEffectGameObject = gameObject3;
		SkinnedMeshRenderer[] newWeaponSkinnedMeshRenders = array4;
		Color newRenderColor = new Color(0f, 0f, 0f, 0f);
		Dictionary<IParticleKey, IPaticlePrefabInstancecs> effectsGameObjects = component2.EffectsGameObjects;
		Transform rootBone = component2.RootBone;
		bool newRunReverse = flag;
		bool newWalkReverse = flag2;
		WeaponColorData defaultWeaponColorData = SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData;
		ParticleEditorLogicAsset newParticleLogicAsset = particleEditorLogicAsset;
		IDynamicBoneSsjj[] newDynamicBones = array5;
		player.AddThirdPersonUnityObjects(career, weapon, skinName, skinName2, worn, quenchId, skins, component, newWeaponAnimator, audioSource, newAvater, newMeshRenders, newKnifeEffectGameObject, newWeaponSkinnedMeshRenders, newRenderColor, newThirdTran, list2, list, dictionary2, effectsGameObjects, dictionary3, rootBone, newRunReverse, newWalkReverse, newOutLineAdded: false, defaultWeaponColorData, newParticleLogicAsset, 0, 0, newDynamicBones, newIkinematics, vector, player.dyeingColor.thirdDyeingColors, player.GetCurrentWeaponDyeingColors());
		player.thirdPersonUnityObjects.Reset();
		if (player.qianglingWeapon.WeaponInfoList != null && player.qianglingWeapon.WeaponInfoList.Count > 0)
		{
			Dictionary<IParticleKey, IPaticlePrefabInstancecs> dictionary4 = null;
			ParticleEditorLogicAsset particleEditorLogicAsset2 = null;
			for (int j = 0; j < player.qianglingWeapon.WeaponInfoList.Count; j++)
			{
				IEntitsWeaponInfo entitsWeaponInfo = player.qianglingWeapon.WeaponInfoList[j];
				QianglingWeaponData qianglingWeaponData = player.qianglingWeapon.weaponList[j];
				SkinnedMeshRenderer[] array6 = null;
				GameObject weaponObj2 = ((!loadResults.ContainsKey("QianglingWeaponModel" + j)) ? new GameObject("EmptyThirdWeapon") : loadResults["QianglingWeaponModel" + j].GameObject);
				ParticleEffectUtility.InitWeaponParticle(weaponObj2, weapon.Name);
				array6 = weaponObj2.GetComponentsInChildren<SkinnedMeshRenderer>();
				WeaponUtility.SetWeaponColor(SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData, array6);
				weaponObj2.transform.SetParent(gameObject2.transform, worldPositionStays: false);
				weaponObj2.transform.localPosition = Vector3.zero;
				if (loadResults["QianglingThirdWeaponAnim" + j].Object is SJAnimationAsset)
				{
					AddThirdWeaponAnimator(weaponObj2, loadResults["QianglingThirdWeaponAnim" + j].Object as SJAnimationAsset);
				}
				if (loadResults["QianglingThirdWeaponAnimXml" + j].Object != null)
				{
					ThirdWeaponAnimInfoFactory.Instance.AddCareerAnimInfo(entitsWeaponInfo.Name, loadResults["QianglingThirdWeaponAnimXml" + j].Object as IThirdWeaponAnimInfo);
				}
				if (loadResults["QianiglingThirdWeaponLogicXml" + j].Object != null)
				{
					dictionary4 = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();
					WeaponUtility.GetParticles(weaponObj2, dictionary4);
					player.thirdPersonUnityObjects.WeaponParticles = dictionary4;
					particleEditorLogicAsset2 = loadResults["QianiglingThirdWeaponLogicXml" + j].Object as ParticleEditorLogicAsset;
					particleEditorLogicAsset2.ThirdWeaponOnFrame(player, null, null);
				}
				QianglingWeaponModelUtility.qianglingWeaponModelShow(entitsWeaponInfo.Name, weaponObj2);
				AddQianglingWeaponModel(gameobj, weaponObj2, entitsWeaponInfo, component, player, j, player.qianglingWeapon.WeaponInfoList.Count);
				WeaponUtility.GetRightFireDict(weaponObj2, list, setGameObjectActive: true);
				WeaponUtility.GetLeftFireDict(weaponObj2, list2, setGameObjectActive: true);
				WeaponSkinInfo skinInfo3 = BattleSingletonInstance<WeaponSkinInfoFactory>.Instance.GetSkinInfo(qianglingWeaponData.SkinName);
				QianglingSkinUtility.InitSkin(ref weaponObj2, loadResults, qianglingWeaponData.Worn, qianglingWeaponData.QuenchId, j, skinInfo3);
			}
			player.thirdPersonUnityObjects.WeaponParticles = dictionary3;
			if (dictionary4 != null)
			{
				dictionary4.Clear();
				dictionary4 = null;
			}
			if (particleEditorLogicAsset2 != null)
			{
				particleEditorLogicAsset2 = null;
			}
		}
		ParticleManager.InitWeaponParticleXmlLoadResults(loadResults, weapon, skinInfo);
		ParticleManager.InitPlayerParticleXmlLoadResults(loadResults, career, skinInfo2);
		if (!string.IsNullOrEmpty(player.GetCurrentWeaponDyeingColors()))
		{
			SkinUtility.InitDyeingMaterial(ref weaponObj, loadResults["weapon_body_mask1"].Object as Texture2D, null, player.GetCurrentWeaponDyeingColors());
		}
	}

	private void LoadGPUAnim(GameObject careerGameObject, LoadResults loadResults, PlayerEntity player, GameObject container, GameObject wrapper, ICareerInfo career, IEntitsWeaponInfo weaponInfo, WeaponSkinInfo skinInfo, PlayerSkinInfo careerSkinInfo)
	{
		GPUSkinningPlayerMono component = careerGameObject.GetComponent<GPUSkinningPlayerMono>();
		component.anim = (GPUSkinningAnimation)loadResults["anim_anim"].Object;
		component.mesh = (Mesh)loadResults["anim_mesh"].Object;
		component.mtrl = (Material)loadResults["anim_mat"].Object;
		component.textureRawData = (TextAsset)loadResults["anim_tex"].Object;
		player.ReplaceThirdPersonGPUAnim(component);
		ThirdPersonCareerGameObject component2 = careerGameObject.GetComponent<ThirdPersonCareerGameObject>();
		AudioSource audioSource = container.AddComponent<AudioSource>();
		InitAudioSource(audioSource);
		GameObject gameObject;
		if (loadResults.ContainsKey("WeaponModel"))
		{
			gameObject = loadResults["WeaponModel"].GameObject;
			if ((bool)gameObject.GetComponent<WeaponDissolutionEffect>())
			{
				gameObject.GetComponent<WeaponDissolutionEffect>().playerEntity = player;
			}
		}
		else
		{
			gameObject = new GameObject("EmptyThirdWeapon");
		}
		gameObject.transform.SetParent(wrapper.transform, worldPositionStays: false);
		gameObject.transform.localPosition = Vector3.zero;
		ThirdTran newThirdTran = new ThirdTran
		{
			HeadTransform = careerGameObject.transform,
			RootContainer = container,
			BodyTransform = careerGameObject.transform,
			WeaponObj = gameObject,
			BackRoateNode = component2.RotateNode,
			BackWeaponNode = component2.BackweaponNode,
			BackContainerObj = component2.BackContainerObj
		};
		if (player.hasHitBox)
		{
			player.RemoveHitBox();
		}
		if (loadResults.ContainsKey("HitBox"))
		{
			PlayerEntityUtility.AddHitBox(player);
			HitHelpInfo hitHelpInfo = loadResults["HitBox"].Object as HitHelpInfo;
			player.hitBox.HitBoxList = hitHelpInfo.HitBoxList;
			player.hitBox.HitPreliminaryGeo = hitHelpInfo.HitPreliminaryGeo;
		}
		string skinName = player.currentWeapon.SkinName;
		string skinName2 = player.basicInfo.SkinName;
		float worn = player.currentWeapon.Worn;
		int quenchId = player.currentWeapon.QuenchId;
		List<SkinnedMeshRenderer> skins = component2.Skins;
		Renderer[] componentsInChildren = careerGameObject.GetComponentsInChildren<MeshRenderer>();
		player.AddThirdPersonUnityObjects(career, weaponInfo, skinName, skinName2, worn, quenchId, skins, null, null, audioSource, null, componentsInChildren, null, null, new Color(0f, 0f, 0f, 0f), newThirdTran, new List<IEntitsFireEffectControl>(), new List<IEntitsFireEffectControl>(), null, component2.EffectsGameObjects, new Dictionary<IParticleKey, IPaticlePrefabInstancecs>(), component2.RootBone, newRunReverse: true, newWalkReverse: true, newOutLineAdded: false, SingletonInstance<WeaponSkinColorLoader>.Instance.DefaultWeaponColorData, null, 0, 0, null, null, Vector3.one, player.dyeingColor.thirdDyeingColors, player.GetCurrentWeaponDyeingColors());
		player.thirdPersonUnityObjects.Reset();
		ParticleManager.InitWeaponParticleXmlLoadResults(loadResults, weaponInfo, skinInfo);
		ParticleManager.InitPlayerParticleXmlLoadResults(loadResults, career, careerSkinInfo);
	}

	private bool CheckCopyAnim(SJAnimator animator, SJAnimationAsset legClips, int layerIndex, string srcClipName, string dstClipName)
	{
		if (legClips.GetClip(dstClipName) != null)
		{
			return false;
		}
		SJAnimationClip clip = legClips.GetClip(srcClipName);
		if (clip == null)
		{
			return false;
		}
		SJAnimationClip sJAnimationClip = new SJAnimationClip(clip);
		sJAnimationClip.Name = dstClipName;
		animator.AddAnimationClip(layerIndex, sJAnimationClip);
		return true;
	}

	private static SJAnimator AddThirdWeaponAnimator(GameObject weaponObj, SJAnimationAsset weaponAnims)
	{
		if (weaponAnims == null)
		{
			return null;
		}
		SJAnimator sJAnimator = weaponObj.GetComponent<SJAnimator>();
		if (sJAnimator == null)
		{
			sJAnimator = weaponObj.AddComponent<SJAnimator>();
			sJAnimator.AddLayer(0, 1f);
		}
		sJAnimator.Reset();
		sJAnimator.AddAnimationClips(0, weaponAnims.Clips);
		return sJAnimator;
	}

	private static void AddWeaponAnimation(ISjAnimatior animator, SJAnimationAsset animAsset)
	{
		animator.AddAnimationClips(1, animAsset.Clips);
	}

	private static void InitAudioSource(AudioSource audioSource)
	{
		audioSource.maxDistance = 10000f;
		audioSource.dopplerLevel = 0.01f;
		audioSource.minDistance = 1f;
		audioSource.spatialBlend = 1f;
		audioSource.rolloffMode = AudioRolloffMode.Linear;
		audioSource.gameObject.AddComponent<FootstepControl>();
	}

	private static Transform GetInParentWithRoot(Transform node, Transform root)
	{
		Transform transform = node;
		while (transform.parent != null && transform != root)
		{
			if (transform.parent == root)
			{
				return transform;
			}
			transform = transform.parent;
		}
		return null;
	}

	private void AddWeaponModel(GameObject body, GameObject weaponModel, IEntitsWeaponInfo info, SJAnimator animator, PlayerEntity player)
	{
		FindChild(body, "weaponanchor", "weaponanchor2", out var part, out var part2);
		weaponModel.transform.position = Vector3.zero;
		weaponModel.transform.eulerAngles = Vector3.zero;
		CheckEmptyWeapon(info, weaponModel);
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		if (part != null)
		{
			gameObject = FindChild(part, "rightanchor");
			if (gameObject != null)
			{
				gameObject.Destroy();
			}
			gameObject = new GameObject("rightanchor");
			gameObject.transform.SetParent(part.transform, worldPositionStays: false);
			if (info.Name.Equals("horror_claw", StringComparison.OrdinalIgnoreCase))
			{
				gameObject.transform.localPosition = new Vector3(-40000f, -10000f, -41400f);
			}
			else
			{
				gameObject.transform.localPosition = Vector3.zero;
			}
			gameObject.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		}
		if (part2 != null)
		{
			gameObject2 = FindChild(part2, "leftanchor");
			if (gameObject2 != null)
			{
				gameObject2.Destroy();
			}
			gameObject2 = new GameObject("leftanchor");
			gameObject2.transform.SetParent(part2.transform, worldPositionStays: false);
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
		}
		if (player != _playerContext.myPlayerEntity)
		{
			if (WeaponUtility.IsSpecial(info.Name) && info.HideThirdHand)
			{
				SetBones(gameObject2, gameObject, weaponModel);
				BaseAsyncManager.Instance.StartCoRoutine(UpdateNextFrame(gameObject2, gameObject, info, animator, player));
			}
			else if (info.HideThirdHand)
			{
				WeaponUtility.SetHandBoneScale(animator, 0.0001f, info.Name);
				SetBones(gameObject2, gameObject, weaponModel, 0.0001f);
			}
			else
			{
				SetBones(gameObject2, gameObject, weaponModel);
			}
		}
		else
		{
			SetBones(gameObject2, gameObject, weaponModel);
		}
	}

	private void AddQianglingWeaponModel(GameObject body, GameObject weaponModel, IEntitsWeaponInfo info, SJAnimator animator, PlayerEntity player, int index, int weaponCount)
	{
		string text = "wuqi1";
		switch (weaponCount)
		{
		case 1:
			text = "wuqi3";
			break;
		case 2:
			if (index == 0)
			{
				text = "wuqi2";
			}
			if (index == 1)
			{
				text = "wuqi4";
			}
			break;
		case 3:
			if (index == 0)
			{
				text = "wuqi2";
			}
			if (index == 1)
			{
				text = "wuqi3";
			}
			if (index == 2)
			{
				text = "wuqi4";
			}
			break;
		case 4:
			if (index == 0)
			{
				text = "wuqi1";
			}
			if (index == 1)
			{
				text = "wuqi2";
			}
			if (index == 2)
			{
				text = "wuqi4";
			}
			if (index == 3)
			{
				text = "wuqi5";
			}
			break;
		case 5:
			text = "wuqi" + (index + 1);
			break;
		}
		FindChild(body, text, out var part);
		FindChild(body, text, out var part2);
		weaponModel.transform.position = Vector3.zero;
		weaponModel.transform.eulerAngles = Vector3.zero;
		CheckEmptyWeapon(info, weaponModel);
		GameObject gameObject = null;
		GameObject gameObject2 = null;
		if (part != null)
		{
			gameObject = FindChild(part, "rightanchor");
			if (gameObject != null)
			{
				gameObject.Destroy();
			}
			gameObject = new GameObject("rightanchor");
			gameObject.transform.SetParent(part.transform, worldPositionStays: false);
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = getQianglingWuqiRotation(info.Name);
		}
		if (part2 != null)
		{
			gameObject2 = FindChild(part2, "leftanchor");
			if (gameObject2 != null)
			{
				gameObject2.Destroy();
			}
			gameObject2 = new GameObject("leftanchor");
			gameObject2.transform.SetParent(part2.transform, worldPositionStays: false);
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject2.transform.localEulerAngles = getQianglingWuqiRotation(info.Name);
		}
		if (player != _playerContext.myPlayerEntity)
		{
			if (WeaponUtility.IsSpecial(info.Name) && info.HideThirdHand)
			{
				SetBones(gameObject2, gameObject, weaponModel);
			}
			else if (info.HideThirdHand)
			{
				WeaponUtility.SetHandBoneScale(animator, 0.0001f, info.Name);
				SetBones(gameObject2, gameObject, weaponModel, 0.0001f);
			}
			else
			{
				SetBones(gameObject2, gameObject, weaponModel);
			}
		}
	}

	private Vector3 getQianglingWuqiRotation(string weaponName)
	{
		if (weaponName == "crystal_spear")
		{
			return new Vector3(0f, 0f, 90f);
		}
		return new Vector3(90f, 0f, 0f);
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

	private int GetLevel(Transform child, Transform parent)
	{
		if (parent == child)
		{
			return 0;
		}
		int num = 10;
		int num2 = 0;
		while (child != parent)
		{
			num2++;
			child = child.parent;
			if (num2 == num)
			{
				break;
			}
		}
		return num2;
	}

	private void SetBones(GameObject leftGameObject, GameObject rightGameObject, GameObject weaponModel, float scale = 1f)
	{
		SkinnedMeshRenderer[] componentsInChildren = weaponModel.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true);
		FollowTransform2Sum followTransform2Sum = weaponModel.TryAddComponent<FollowTransform2Sum>();
		followTransform2Sum.Clear();
		for (int num = componentsInChildren.Length - 1; num >= 0; num--)
		{
			Transform[] bones = componentsInChildren[num].bones;
			foreach (Transform transform in bones)
			{
				Transform parent = transform.parent;
				if (!(parent != null))
				{
					continue;
				}
				Transform transform2 = parent;
				Transform transform3 = null;
				if (transform.parent == weaponModel.transform)
				{
					transform3 = transform;
				}
				else if (transform2.parent == weaponModel.transform)
				{
					transform3 = transform2;
				}
				if (!(transform3 != null))
				{
					continue;
				}
				transform3.SetParent(weaponModel.transform, worldPositionStays: false);
				KeepInitTransform.KeepInit(transform3.gameObject);
				if (transform3.childCount <= 0)
				{
					continue;
				}
				foreach (Transform item in transform3)
				{
					KeepInitTransform.KeepInit(item.gameObject);
				}
			}
		}
		Dictionary<Transform, Transform> dictionary = new Dictionary<Transform, Transform>();
		for (int num2 = componentsInChildren.Length - 1; num2 >= 0; num2--)
		{
			Transform transform4 = null;
			Transform[] bones = componentsInChildren[num2].bones;
			foreach (Transform transform5 in bones)
			{
				string text = transform5.name.ToLower().Split(' ')[0];
				if ((bool)rightGameObject && WeaponJoinConstant.RightWeaponJoins.Contains(text))
				{
					transform4 = rightGameObject.transform;
				}
				else if ((bool)leftGameObject && WeaponJoinConstant.LeftWeaponJoins.Contains(text))
				{
					transform4 = leftGameObject.transform;
				}
				if (transform4 != null)
				{
					Transform inParentWithRoot = GetInParentWithRoot(transform5, weaponModel.transform);
					if (inParentWithRoot != null && !dictionary.ContainsKey(inParentWithRoot))
					{
						GameObject gameObject = new GameObject(text);
						Vector3 position = transform5.position;
						Vector3 eulerAngles = transform5.eulerAngles;
						gameObject.transform.SetParent(transform4);
						gameObject.transform.localPosition = position * 1f / scale;
						gameObject.transform.localEulerAngles = eulerAngles;
						dictionary.Add(transform5, gameObject.transform);
					}
				}
			}
			foreach (KeyValuePair<Transform, Transform> item2 in dictionary)
			{
				followTransform2Sum.Follow(item2.Key, item2.Value, GetLevel(item2.Key, weaponModel.transform), componentsInChildren[num2].enabled);
			}
		}
		followTransform2Sum.Sort();
	}

	private IEnumerator UpdateNextFrame(GameObject leftGameObject, GameObject rightGameObject, IEntitsWeaponInfo info, SJAnimator animator, PlayerEntity player)
	{
		for (int i = 0; i < 5; i++)
		{
			yield return null;
		}
		if (!player.hasThirdBoneCache)
		{
			Dictionary<GameObject, Vector3> newCache = DictionaryPool<GameObject, Vector3>.Get();
			Dictionary<GameObject, Vector3> newLocalCache = DictionaryPool<GameObject, Vector3>.Get();
			player.AddThirdBoneCache(newCache, newLocalCache, null, null);
		}
		else if (player.thirdBoneCache.Cache == null)
		{
			Dictionary<GameObject, Vector3> newCache = DictionaryPool<GameObject, Vector3>.Get();
			player.thirdBoneCache.Cache = newCache;
			newCache = DictionaryPool<GameObject, Vector3>.Get();
			player.thirdBoneCache.LocalCache = newCache;
		}
		player.thirdBoneCache.LeftGameObject = leftGameObject;
		player.thirdBoneCache.RighGameObject = rightGameObject;
		player.thirdBoneCache.StoreLocalPosition();
		player.thirdBoneCache.Store();
		if (info.HideThirdHand)
		{
			WeaponUtility.SetHandBoneScale(animator, 0.01f, info.Name, player.GetCurrentWeaponEffectLevel());
		}
		player.thirdBoneCache.Revert();
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

	private void FindChild(GameObject target, IgnoreCaseString name1, out GameObject part1)
	{
		part1 = null;
		Transform[] componentsInChildren = target.GetComponentsInChildren<Transform>(includeInactive: true);
		for (int num = componentsInChildren.Length - 1; num >= 0; num--)
		{
			Transform transform = componentsInChildren[num];
			string name2 = transform.name;
			if (part1 == null && name1.Equals(name2))
			{
				part1 = transform.gameObject;
				if (part1 != null)
				{
					break;
				}
			}
		}
	}
}
