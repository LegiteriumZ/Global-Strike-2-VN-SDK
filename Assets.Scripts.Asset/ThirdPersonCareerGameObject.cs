using System.Collections.Generic;
using Assets.Libs.SJAnimation.Parser;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Info.UnityObjects;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Player;
using Assets.Sources.Utils.Weapon;
using SSJJAnim.Animator;
using UnityEngine;

namespace Assets.Scripts.Asset;

public class ThirdPersonCareerGameObject : ReusableGameObjectBase
{
	private const string RightAnchor = "RightAnchor";

	private const string LeftAnchor = "LeftAnchor";

	private readonly Dictionary<SkinnedMeshRenderer, Material> _originalMaterials = new Dictionary<SkinnedMeshRenderer, Material>();

	public Dictionary<IParticleKey, IPaticlePrefabInstancecs> EffectsGameObjects = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();

	public Transform RotateNode { get; private set; }

	public Transform BackweaponNode { get; private set; }

	public Transform BackContainerObj { get; private set; }

	public Transform RootBone { get; private set; }

	public List<SkinnedMeshRenderer> Skins { get; private set; }

	public override void OnCreated()
	{
		Skins = new List<SkinnedMeshRenderer>();
		GameObject gameObject = GetGameObject();
		SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in componentsInChildren)
		{
			Skins.Add(skinnedMeshRenderer);
			Material sharedMaterial = skinnedMeshRenderer.sharedMaterial;
			if (sharedMaterial != null)
			{
				_originalMaterials.Add(skinnedMeshRenderer, sharedMaterial);
			}
		}
		DAEUtility.FixImportRotation(gameObject);
		if (Skins.Count == 0)
		{
			gameObject.AddComponent<GPUSkinningPlayerMono>();
			return;
		}
		SJAnimator sJAnimator = gameObject.AddComponent<SJAnimator>();
		sJAnimator.Init();
		sJAnimator.AddLayer(0, 1f);
		sJAnimator.AddLayer(1, 1f);
		sJAnimator.KeepBoneWhenAnimationNotUsed("wuqi1");
		sJAnimator.KeepBoneWhenAnimationNotUsed("wuqi2");
		sJAnimator.KeepBoneWhenAnimationNotUsed("qiang_l");
		sJAnimator.KeepBoneWhenAnimationNotUsed("qiang_r");
		sJAnimator.KeepBoneWhenAnimationNotUsed("other_feet_01");
		sJAnimator.KeepBoneWhenAnimationNotUsed("other_feet_02");
		RootBone = PlayerUtility.GetRootBone(gameObject);
		BackContainerObj = sJAnimator.GetBone("backaccessory");
		if (BackContainerObj != null)
		{
			RotateNode = new GameObject("rotatenode").transform;
			RotateNode.SetParent(BackContainerObj.transform);
			BackweaponNode = new GameObject("backweapon").transform;
			BackweaponNode.SetParent(RotateNode);
		}
		PaticlePrefabInstancecs[] componentsInChildren2 = gameObject.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
		foreach (PaticlePrefabInstancecs paticlePrefabInstancecs in componentsInChildren2)
		{
			if (!(paticlePrefabInstancecs.instance != null))
			{
				continue;
			}
			ParticleKey particleKey = new ParticleKey(paticlePrefabInstancecs.gameObject.name, paticlePrefabInstancecs.instance.name, paticlePrefabInstancecs.AnimationEffectConfig);
			if (!EffectsGameObjects.ContainsKey(particleKey))
			{
				EffectsGameObjects.Add(particleKey, paticlePrefabInstancecs);
				if (paticlePrefabInstancecs.OriginalList != null)
				{
					continue;
				}
				Renderer[] componentsInChildren3 = paticlePrefabInstancecs.gameObject.GetComponentsInChildren<Renderer>(includeInactive: true);
				if (componentsInChildren3.Length != 0)
				{
					paticlePrefabInstancecs.OriginalList = new List<RecordOriginal>(componentsInChildren3.Length);
					Renderer[] array = componentsInChildren3;
					foreach (Renderer render in array)
					{
						paticlePrefabInstancecs.OriginalList.Add(new RecordOriginal(render));
					}
				}
			}
			else
			{
				paticlePrefabInstancecs.SetInsActive(flag: false);
			}
		}
	}

	public void SetLod(PlayerEntity player, GameObject thirdWeaponGameObject, Dictionary<IParticleKey, IPaticlePrefabInstancecs> weaponParticles)
	{
		if (player.hasBasicInfo && player.basicInfo.Current != null)
		{
			LodUtility.AddMeshLod(player, GetGameObject(), isFirstLoad: true);
		}
		LodUtility.AddWeaponMeshLod(player, thirdWeaponGameObject);
		LodUtility.AddParticleLod(weaponParticles);
		LodUtility.AddParticleLod(EffectsGameObjects);
	}

	public override void OnRecycle()
	{
		GameObject gameObject = GetGameObject();
		SJAnimator component = gameObject.GetComponent<SJAnimator>();
		if (component == null)
		{
			return;
		}
		component.Reset();
		WeaponUtility.ResetHandScale(component, 1f);
		GameObject gameObject2 = gameObject.FindForeachByName("RightAnchor");
		if (gameObject2 != null)
		{
			gameObject2.DestroyImmediate();
		}
		GameObject gameObject3 = gameObject.FindForeachByName("LeftAnchor");
		if (gameObject3 != null)
		{
			gameObject3.DestroyImmediate();
		}
		foreach (KeyValuePair<SkinnedMeshRenderer, Material> originalMaterial in _originalMaterials)
		{
			originalMaterial.Key.sharedMaterial = originalMaterial.Value;
		}
	}
}
