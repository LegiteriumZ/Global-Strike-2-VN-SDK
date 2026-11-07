using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class VariationbombEndEffectRender : AbstractLocalEntityEffectRender
{
	private int _time;

	private int _attackTime;

	private Transform _bomb;

	private GameObject _explosion;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		if (((SceneObjectEntity)entity).localEntityEffect.EventData is TowerEventEntityData towerEventEntityData)
		{
			Transform transform = effectGameObject.transform.Find("GameObject/1/sprite");
			_bomb = effectGameObject.transform.Find("GameObject/2");
			_explosion = effectGameObject.transform.Find("GameObject/Explosion").gameObject;
			transform.localScale = new Vector3((float)towerEventEntityData.Range / 500f * 2f, (float)towerEventEntityData.Range / 500f * 2f, 1f);
			_attackTime = towerEventEntityData.Time;
			_time = 0;
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		_time += frameTime;
		if (_explosion != null)
		{
			if (_time >= _attackTime - 200 && _time <= _attackTime)
			{
				_bomb.localPosition = new Vector3(0f, 1000 - 5 * (_time + 200 - _attackTime), 0f);
			}
			else
			{
				_bomb.localPosition = new Vector3(0f, -10000f, 0f);
			}
			bool flag = _time > _attackTime;
			if (_explosion.IsActiveSelf() != flag)
			{
				_explosion.SetObjectActive(flag);
			}
		}
	}
}
