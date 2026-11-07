using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Info.Tps;
using Assets.Sources.Modules.Player.Attack.Utils;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Singleton;
using SSJJBase.String;
using SSJJIK;
using SSJJMath;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Utils.Tps;

public class TpsUtility
{
	public class TpsContainer
	{
		public DynamicBoneSsjj[] DynamicBones;

		public InverseKinematics Ikinematics;

		public float Scale = 1f;
	}

	private static string Gun_Fire_Joint = "weapon_particle_fire_effect";

	private static bool _isIkEffect = false;

	public static void InitTpsLoadRequests(ICareerInfo careerInfo, LoadRequests load)
	{
		if (PlayerCareerUtil.IsTPS(careerInfo.Name))
		{
			load.AddAsset("TpsShadow", new AssetInfo("effect/tpsmode", "Assets/Res/Assets/effect/TpsMode/TpsShadow/TpsShadow.prefab", typeof(GameObject), optional: true));
		}
	}

	public static TpsContainer InitTpsRes(LoadResults loadResults, PlayerEntity playerEntity, IEntitsWeaponInfo weaponInfo, GameObject careerGameObject, GameObject weaponCareerGameObject)
	{
		if (!PlayerCareerUtil.IsTPS(playerEntity.GetCareer()))
		{
			return null;
		}
		TpsContainer tpsContainer = new TpsContainer();
		DynamicBoneSsjj[] components = careerGameObject.GetComponents<DynamicBoneSsjj>();
		for (int i = 0; i < components.Length; i++)
		{
			components[i].Reset();
		}
		tpsContainer.DynamicBones = components;
		if (loadResults.ContainsKey("TpsShadow"))
		{
			playerEntity.AddAcgShadow(loadResults["TpsShadow"].GameObject);
		}
		if (_isIkEffect)
		{
			TpsIkInfo ikInfo = MonoBehaviourSingleton<TpsIkInfoLoader>.Instance.GetIkInfo(playerEntity.GetCareer(), weaponInfo.Name);
			if (ikInfo != null)
			{
				InverseKinematics inverseKinematics = careerGameObject.GetComponent<InverseKinematics>();
				if (inverseKinematics == null)
				{
					List<GameObject> list = new List<GameObject>();
					list.Add(careerGameObject.FindForeachByName("Bip01_L_UpperArm"));
					list.Add(careerGameObject.FindForeachByName("Bip01_L_Forearm"));
					GameObject gameObject = careerGameObject.FindForeachByName("Bip01_L_Hand");
					Transform transform = gameObject.transform.Find("Bip01_L_Hand_Center");
					if (transform == null)
					{
						transform = new GameObject("Bip01_L_Hand_Center").transform;
						List<Vector3> list2 = new List<Vector3>();
						for (int j = 0; j < gameObject.transform.childCount; j++)
						{
							list2.Add(gameObject.transform.GetChild(j).localPosition);
						}
						Vector3 zero = Vector3.zero;
						for (int k = 0; k < gameObject.transform.childCount; k++)
						{
							zero += list2[k];
						}
						zero /= (float)list2.Count;
						transform.SetParent(gameObject.transform);
						transform.transform.localPosition = zero;
					}
					list.Add(gameObject);
					list.Add(transform.gameObject);
					inverseKinematics = TpsIkInit(careerGameObject, list);
				}
				GameObject weaponAnchor = weaponCareerGameObject.FindForeachByName("WeaponAnchor");
				TpsIkApply(inverseKinematics, weaponAnchor, ikInfo.WeaponAnchorDiff);
				tpsContainer.Ikinematics = inverseKinematics;
				tpsContainer.Scale = ikInfo.WeaponScale;
			}
		}
		return tpsContainer;
	}

	public static void AdjustGunFireStart(ref HitPlayerArgs args)
	{
		if (!RuleUtilty.IsTpsMode() || !args.player.hasThirdPersonUnityObjects)
		{
			return;
		}
		foreach (KeyValuePair<IgnoreCaseString, Transform> allTransform in args.player.thirdPersonUnityObjects.AllTransforms)
		{
			if (allTransform.Value.name.Equals(Gun_Fire_Joint))
			{
				Vector3 position = allTransform.Value.transform.position;
				position = VectorCoordConverter.UnityToSsjj(position);
				args.startPos.x = position.x;
				args.startPos.y = position.y;
				args.startPos.z = position.z;
				break;
			}
		}
	}

	public static void AdjustGunFireStart(ref HitWorldArgs args)
	{
		if (!RuleUtilty.IsTpsMode() || !args.player.hasThirdPersonUnityObjects)
		{
			return;
		}
		foreach (KeyValuePair<IgnoreCaseString, Transform> allTransform in args.player.thirdPersonUnityObjects.AllTransforms)
		{
			if (allTransform.Value.name.Equals(Gun_Fire_Joint))
			{
				Vector3 position = allTransform.Value.transform.position;
				position = VectorCoordConverter.UnityToSsjj(position);
				args.startPos.x = position.x;
				args.startPos.y = position.y;
				args.startPos.z = position.z;
				break;
			}
		}
	}

	public static InverseKinematics TpsIkInit(GameObject careerGameObject, List<GameObject> leftHands)
	{
		InverseKinematics inverseKinematics = careerGameObject.TryAddComponent<InverseKinematics>();
		SSJJIK.Core.Chain chain = new SSJJIK.Core.Chain();
		chain.iterations = 10;
		chain.weight = 1f;
		chain.joints.Clear();
		for (int i = 0; i < leftHands.Count; i++)
		{
			SSJJIK.Core.Joint joint = new SSJJIK.Core.Joint();
			chain.joints.Add(joint);
			joint.joint = leftHands[i].transform;
			joint.weight = 1f;
		}
		inverseKinematics.lArm = chain;
		inverseKinematics.solver = SSJJIK.Core.Solvers.FastReach;
		return inverseKinematics;
	}

	public static void TpsIkApply(InverseKinematics ik, GameObject weaponAnchor, Vector3 leftHandPos)
	{
		Transform transform = weaponAnchor.transform.Find("LeftIk");
		if (transform == null)
		{
			transform = new GameObject("LeftIk").transform;
			transform.transform.SetParent(weaponAnchor.transform);
		}
		transform.transform.localPosition = leftHandPos;
		ik.lArm.target = transform;
	}
}
