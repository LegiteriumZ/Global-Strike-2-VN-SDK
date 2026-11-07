using Assets.Sources.Components.Interface;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class QuickMovementEffectRender : AbstractLocalEntityEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (((SceneObjectEntity)entity).localEntityEffect.EventData is BulletRailEventEntityData bulletRailEventEntityData)
		{
			effectGameObject.transform.Find("1").localPosition = VectorCoordConverter.SsjjToUnity(new Vector3(bulletRailEventEntityData.StartPos.X - bulletRailEventEntityData.BaseEventEntity.X, bulletRailEventEntityData.StartPos.Y - bulletRailEventEntityData.BaseEventEntity.Y, bulletRailEventEntityData.StartPos.Z - bulletRailEventEntityData.BaseEventEntity.Z));
			effectGameObject.transform.Find("2").localPosition = VectorCoordConverter.SsjjToUnity(new Vector3(bulletRailEventEntityData.EndPos.X - bulletRailEventEntityData.BaseEventEntity.X, bulletRailEventEntityData.EndPos.Y - bulletRailEventEntityData.BaseEventEntity.Y, bulletRailEventEntityData.EndPos.Z - bulletRailEventEntityData.BaseEventEntity.Z - 50f));
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}
}
