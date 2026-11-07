using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Modules.SceneObject;
using NetData;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.Logic.HoleLogic;

internal class ExplosionHoleLogic : IHoleLogic, IParamParse
{
	private int _eventId;

	private int _res;

	public void CreateBulletHoleEntity(Vector3 start, Vector3 position, Vector3 normal, int ownerId, bool isKnife, bool isSpecialMode)
	{
		GrenadeExplosionEventEntityData grenadeExplosionEventEntityData = new GrenadeExplosionEventEntityData();
		grenadeExplosionEventEntityData.CollisionNormal = new Vector3DData
		{
			X = position.x,
			Y = position.y,
			Z = position.z
		};
		grenadeExplosionEventEntityData.CollisionNormal = new Vector3DData
		{
			X = normal.x,
			Y = normal.y,
			Z = normal.z
		};
		grenadeExplosionEventEntityData.ResTypeID = _res;
		grenadeExplosionEventEntityData.BaseEventEntity = new BaseEventEntityData
		{
			EType = 1000,
			Id = 0,
			EventId = _eventId
		};
		SceneObjectFactory.Instance.CreateExplosion(grenadeExplosionEventEntityData);
	}

	public void Parse(string param)
	{
		_res = int.Parse(param.Split(',')[0]);
		_eventId = int.Parse(param.Split(',')[1]);
	}
}
