using System.Collections.Generic;
using Assets.Res.Assets.Scripts;
using Assets.Res.Assets.Scripts.PrefabInstance;
using Assets.Scripts.Utility.ParticleSize;
using Assets.Sources.Components.Interface;
using Assets.Sources.Components.SceneObject;
using Assets.Sources.Constant.Career;
using UnityEngine;

namespace Assets.Sources.Utils;

public class LodUtility
{
	public static void AddMeshLod(PlayerEntity entity, GameObject playerGameObject, bool isFirstLoad)
	{
		if (entity != null && !(playerGameObject == null) && !entity.isMyPlayer)
		{
			int num = PlayerCareerConstantUtility.GetHeight(entity.GetCareer());
			if (!isFirstLoad)
			{
				num = 120;
			}
			if (!entity.hasLod)
			{
				entity.AddLod(new List<ILODSwitcher>());
			}
			if (isFirstLoad)
			{
				entity.lod.Switcher.Clear();
			}
			LODSwitcher[] componentsInChildren = playerGameObject.GetComponentsInChildren<LODSwitcher>();
			foreach (LODSwitcher lODSwitcher in componentsInChildren)
			{
				lODSwitcher.ObjectSize = ((num > 80) ? num : 1000);
				entity.lod.Switcher.Add(lODSwitcher);
			}
		}
	}

	public static void AddWeaponMeshLod(PlayerEntity entity, GameObject weaponGameObject)
	{
		if (entity != null && !(weaponGameObject == null) && !entity.isMyPlayer)
		{
			if (!entity.hasLod)
			{
				entity.AddLod(new List<ILODSwitcher>());
			}
			LODSwitcher[] componentsInChildren = weaponGameObject.GetComponentsInChildren<LODSwitcher>();
			foreach (LODSwitcher item in componentsInChildren)
			{
				entity.lod.Switcher.Add(item);
			}
		}
	}

	public static void AddMeshLod(SceneObjectEntity entity, GameObject sceneGameObject)
	{
		if (entity != null && !(sceneGameObject == null))
		{
			LODSwitcher[] componentsInChildren = sceneGameObject.GetComponentsInChildren<LODSwitcher>();
			if (!entity.hasLod)
			{
				entity.AddLod(new List<ILODSwitcher>());
			}
			entity.lod.Switcher.Clear();
			LODSwitcher[] array = componentsInChildren;
			foreach (LODSwitcher item in array)
			{
				entity.lod.Switcher.Add(item);
			}
		}
	}

	public static void AddParticleLod(Dictionary<IParticleKey, IPaticlePrefabInstancecs> particles)
	{
		if (particles == null)
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in particles)
		{
			if (particle.Value.getInstance() != null)
			{
				AddParticleLod(particle.Value.GetIns());
			}
		}
	}

	public static void AddParticleLod(IPaticlePrefabInstancecs[] particles)
	{
		if (particles == null)
		{
			return;
		}
		foreach (IPaticlePrefabInstancecs paticlePrefabInstancecs in particles)
		{
			if (paticlePrefabInstancecs.getInstance() != null)
			{
				AddParticleLod(paticlePrefabInstancecs.GetIns());
			}
		}
	}

	public static void AddInstanceLod(GameObject instance)
	{
		if (!(instance == null))
		{
			PaticlePrefabInstancecs component = instance.GetComponent<PaticlePrefabInstancecs>();
			if (component != null && component.instance != null)
			{
				AddParticleLod(component.GetIns());
			}
		}
	}

	public static void AddParticleLod(GameObject particle)
	{
		if (!GameController.Instance.IsOpenLod || particle == null)
		{
			return;
		}
		ParticleSizeUnit component = particle.GetComponent<ParticleSizeUnit>();
		if (!(component != null))
		{
			return;
		}
		ParticleLodComponent particleLod = Contexts.sharedInstance.sceneObject.particleLod;
		if (!particleLod.SizeUnits.Contains(component))
		{
			if (component.FireEffect == null)
			{
				component.FireEffect = particle.GetComponent<IFireEffectControl>();
			}
			particleLod.SizeUnits.Add(component);
			component.ResetSee();
		}
	}

	public static void RemoveParticleLod(Dictionary<IParticleKey, IPaticlePrefabInstancecs> particles)
	{
		if (particles == null)
		{
			return;
		}
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in particles)
		{
			if (particle.Value != null && particle.Value.getInstance() != null)
			{
				RemoveParticleLod(particle.Value.GetIns());
			}
		}
	}

	public static void RemoveParticleLod(IPaticlePrefabInstancecs[] particles)
	{
		if (particles == null)
		{
			return;
		}
		foreach (IPaticlePrefabInstancecs paticlePrefabInstancecs in particles)
		{
			if (paticlePrefabInstancecs != null && paticlePrefabInstancecs.getInstance() != null)
			{
				RemoveParticleLod(paticlePrefabInstancecs.GetIns());
			}
		}
	}

	public static void RemoveInstanceLod(GameObject instance)
	{
		if (instance != null)
		{
			PaticlePrefabInstancecs component = instance.GetComponent<PaticlePrefabInstancecs>();
			if (component != null && component.instance != null)
			{
				RemoveParticleLod(component.GetIns());
			}
		}
	}

	private static void RemoveParticleLod(GameObject particle)
	{
		if (GameController.Instance.IsOpenLod && !(particle == null))
		{
			ParticleSizeUnit component = particle.GetComponent<ParticleSizeUnit>();
			if (component != null)
			{
				Contexts.sharedInstance.sceneObject.particleLod.SizeUnits.Remove(component);
			}
		}
	}
}
