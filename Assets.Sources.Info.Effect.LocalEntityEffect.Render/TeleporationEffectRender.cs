using Assets.Sources.Components.Interface;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class TeleporationEffectRender : AbstractLocalEntityEffectRender
{
	private int _createTime;

	private Transform _sprite;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_createTime = 0;
		_sprite = effectGameObject.transform.Find("GameObject/1");
		_sprite.localPosition = Vector3.zero;
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		_createTime += frameTime;
		if (_createTime > 500 && ((SceneObjectEntity)Entity).localEntityEffect.EventData is FlashEventEntityData flashEventEntityData)
		{
			_sprite.localPosition = VectorCoordConverter.SsjjToUnity(new Vector3(flashEventEntityData.TargetX - flashEventEntityData.BaseEventEntity.X, flashEventEntityData.TargetY - flashEventEntityData.BaseEventEntity.Y, flashEventEntityData.TargetZ - flashEventEntityData.BaseEventEntity.Z));
		}
	}
}
