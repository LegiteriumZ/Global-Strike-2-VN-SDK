using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class ThunderDoomEffectRender : AbstractLocalEntityEffectRender
{
	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (((SceneObjectEntity)entity).localEntityEffect.EventData is TowerEventEntityData towerEventEntityData)
		{
			effectGameObject.transform.Find("1/sprite").localScale = new Vector3((float)towerEventEntityData.Range / 500f * 2f, (float)towerEventEntityData.Range / 500f * 2f, 1f);
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
	}
}
