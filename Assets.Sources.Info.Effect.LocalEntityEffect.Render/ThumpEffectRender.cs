using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class ThumpEffectRender : AbstractLocalEntityEffectRender
{
	private int _attackTime;

	private GameObject _effect;

	private int _time;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (((SceneObjectEntity)entity).localEntityEffect.EventData is TowerEventEntityData towerEventEntityData)
		{
			effectGameObject.transform.Find("1/sprite").localScale = new Vector3((float)towerEventEntityData.Range / 512f * 2f, (float)towerEventEntityData.Range / 512f * 2f, 1f);
			_attackTime = towerEventEntityData.Time;
			_effect = effectGameObject.transform.Find("2").gameObject;
			_time = 0;
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		_time += frameTime;
		bool flag = _time > _attackTime;
		if (_effect.IsActiveSelf() != flag)
		{
			_effect.SetObjectActive(flag);
		}
	}
}
