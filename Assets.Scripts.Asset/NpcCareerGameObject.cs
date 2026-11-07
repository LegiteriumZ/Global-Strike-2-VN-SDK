using System.Collections.Generic;
using Assets.Libs.SJAnimation.Parser;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.AnimData;
using Assets.Sources.Info.UnityObjects;
using SSJJAnim.Animator;
using UnityEngine;

namespace Assets.Scripts.Asset;

public class NpcCareerGameObject : ReusableGameObjectBase
{
	public ISjAnimatior Animator;

	public Dictionary<IParticleKey, IPaticlePrefabInstancecs> EffectsGameObjects = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();

	public override void OnRecycle()
	{
		Animator.Reset();
	}

	public override void OnCreated()
	{
		GameObject gameObject = GetGameObject();
		DAEUtility.FixImportRotation(gameObject);
		Animator = gameObject.AddComponent<SJAnimator>();
		Animator.AddLayer(0, 1f);
		PaticlePrefabInstancecs[] componentsInChildren = gameObject.GetComponentsInChildren<PaticlePrefabInstancecs>(includeInactive: true);
		foreach (PaticlePrefabInstancecs paticlePrefabInstancecs in componentsInChildren)
		{
			if (paticlePrefabInstancecs.instance != null)
			{
				EffectsGameObjects[new ParticleKey(paticlePrefabInstancecs.gameObject.name, paticlePrefabInstancecs.instance.name)] = paticlePrefabInstancecs;
			}
		}
	}
}
