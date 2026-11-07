using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class LeibaohongzhaEndEffectRender : AbstractLocalEntityEffectRender
{
	private int _time;

	private int _attackTime;

	private Transform _bomb;

	private GameObject _explosion;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (((SceneObjectEntity)entity).localEntityEffect.EventData is TowerEventEntityData towerEventEntityData)
		{
			Transform transform = effectGameObject.transform.Find("1/sprite");
			Transform transform2 = effectGameObject.transform.Find("3");
			Vector3 localScale = (transform2.localScale = new Vector3((float)towerEventEntityData.Range / 512f * 2f, (float)towerEventEntityData.Range / 512f * 2f, 1f));
			transform.localScale = localScale;
			_bomb = effectGameObject.transform.Find("2");
			_explosion = effectGameObject.transform.Find("3").gameObject;
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
			_explosion.SetObjectActive(_time > _attackTime);
		}
	}
}
