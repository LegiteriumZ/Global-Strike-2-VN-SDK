using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Modules.Ui.UiEventCondition;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon.SceneWeaponRenderInfo;

internal class ClaymoreTacticalRenderinfo : AbstractSceneWeaponInfo
{
	protected override void InitInternal(SceneObjectEntity entity)
	{
	}

	protected override void UpdateRotate(SceneObjectEntity entity)
	{
		entity.unityObjects.LoadResults["WeaponModel"].GameObject.transform.localEulerAngles = VectorCoordConverter.SsjjRotationToUnity(new Vector3(0f, 0f, entity.sceneWeapon.Current.Yaw));
	}

	protected override void UpdatePaticle(SceneObjectEntity entity)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in GetParticles(entity))
		{
			if (particle.Key.PatricleName.Equals("jiguang_180") || (particle.Key.PatricleName.Equals("jiguang_360") && (entity.sceneWeapon.Current.Level & 1) > 0))
			{
				particle.Value.SetInsActive(flag: true);
			}
			if (particle.Key.PatricleName.Equals("biaoji") && (entity.sceneWeapon.Current.Level & 1) > 0 && UiIEventCondition.Get_uiMyPlayer_PlayerId() == entity.sceneWeapon.Current.OwnerId)
			{
				particle.Value.SetInsActive(flag: true);
			}
		}
	}
}
