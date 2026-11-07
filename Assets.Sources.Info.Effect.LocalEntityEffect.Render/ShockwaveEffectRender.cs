using Assets.Sources.Components.Interface;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class ShockwaveEffectRender : AbstractLocalEntityEffectRender
{
	private float _speed;

	private int _time;

	private Transform _wave;

	private int _attackTime;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		if (((SceneObjectEntity)entity).localEntityEffect.EventData is TitanEventEntityData titanEventEntityData)
		{
			Transform transform = effectGameObject.transform.Find("GameObject/1");
			transform.localScale = new Vector3(7.8125f, 1f, (float)titanEventEntityData.Distances / 128f);
			transform.localPosition = new Vector3(0f, 1f, (float)titanEventEntityData.Distances / 2f);
			effectGameObject.transform.Find("GameObject").localEulerAngles = new Vector3(0f, 0f - titanEventEntityData.BaseEventEntity.Yaw, 0f);
			_speed = (float)titanEventEntityData.Distances / 500f;
			_attackTime = titanEventEntityData.Time;
			_wave = effectGameObject.transform.Find("GameObject/Wave");
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		_time += frameTime;
		if (_time > _attackTime - 500)
		{
			_wave.localPosition = new Vector3(0f, 0f, (float)(_time + 500 - _attackTime) * _speed);
		}
		else
		{
			_wave.localPosition = new Vector3(0f, 0f, 0f);
		}
	}
}
