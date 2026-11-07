using System;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Weapon;
using NetData;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Info.MoveObject;

public class MoveEntityEffectRenderObjectInfo : AbstractMoveObjectInfo
{
	private Vector3 _lastPos;

	private Vector3 _distance;

	public override void RenderEntity(SceneObjectEntity entity)
	{
		UpdateRotationX(entity);
		UpdateRotationY(entity);
		UpdateRotationZ(entity);
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 1005)
		{
			if (entity.moveObject.Current.Name == "PVE_ZHIZHULUAN")
			{
				SpiderRender(entity);
			}
			else
			{
				base.RenderEntity(entity);
			}
		}
		else
		{
			base.RenderEntity(entity);
		}
	}

	protected void SpiderRender(SceneObjectEntity entity)
	{
		if (!IsHide)
		{
			GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
			if (gameObject.IsActiveSelf() == IsHide)
			{
				gameObject.SetObjectActive(!IsHide);
			}
			VectorCoordConverter.SsjjToUnity(entity.position.Origin, out var dest);
			Vector3 vector = VectorCoordConverter.SsjjRotationToUnity(entity.rotation.EulerAngles);
			if (dest.x < -10000f && dest.x > -16000f && dest.z > 7000f && dest.z < 12000f)
			{
				float num = 0f;
				num = ((Mathf.Abs(vector.y + 90f) > 0f) ? ((!(dest.x > -13000f)) ? (-1f) : 1f) : ((!(dest.z > 9000f)) ? (-1f) : 1f));
				dest += Quaternion.Euler(vector) * new Vector3(70f * num, 0f, 0f);
			}
			gameObject.transform.position = dest;
			gameObject.transform.localEulerAngles = vector;
			gameObject.transform.localScale = entity.scale.Scale;
		}
	}

	protected virtual void UpdateRotationX(SceneObjectEntity entity)
	{
		MoveEntityData current = entity.moveObject.Current;
		if (WeaponConstant.IsHowitzerWeapon(current.Name))
		{
			_distance.x = _lastPos.x - current.X;
			_distance.y = _lastPos.y - current.Y;
			_distance.z = _lastPos.z - current.Z;
			entity.rotation.EulerAngles.x += (float)((double)(_distance.magnitude / 90f * 2f) * Math.PI);
			_lastPos.x = current.X;
			_lastPos.y = current.Y;
			_lastPos.z = current.Z;
		}
	}

	protected virtual void UpdateRotationY(SceneObjectEntity entity)
	{
		MoveEntityData current = entity.moveObject.Current;
		TimeComponent time = Contexts.sharedInstance.time.time;
		if (current.Name == "PVE_DARTS_D" || current.Name == "PVE_DARTS_M")
		{
			entity.rotation.EulerAngles.y += (float)time.FrameInterval * 0.05f;
		}
		else if (current.Name == "PVE_VACUMBLADE" || current.Name == "M249_ROCKET_MISSILE" || current.Name == "M249_ROCKET_MISSILE_LEVELUP" || current.Name == "RPG_BOSS4_BINGRENXUANFENG_DAOGUANG")
		{
			entity.rotation.EulerAngles.y = (float)((double)(0f - entity.moveObject.PitchYawRoll.y) * Math.PI / 180.0);
		}
		else if (current.Name == "RAGE_BULLET1" || current.Name == "RAGE_BULLET2")
		{
			entity.rotation.EulerAngles.y = (float)((double)(0f - entity.moveObject.PitchYawRoll.y) * Math.PI / 180.0);
		}
	}

	protected virtual void UpdateRotationZ(SceneObjectEntity entity)
	{
		MoveEntityData current = entity.moveObject.Current;
		TimeComponent time = Contexts.sharedInstance.time.time;
		if (current.Name == "virusmissile" || current.Name == "PVE_VACUMBLADE" || current.Name == "RAGE_BULLET1" || current.Name == "RAGE_BULLET2" || current.Name == "RPG_BOSS4_BINGRENXUANFENG_DAOGUANG")
		{
			entity.rotation.EulerAngles.z = (float)((double)entity.moveObject.PitchYawRoll.z * Math.PI / 180.0);
		}
		else if (current.Name == "PEEKABOO_STARS" || current.Name == "PEEKABOO_ITEM")
		{
			entity.rotation.EulerAngles.z += (float)time.FrameInterval * 0.001f;
		}
		else if (current.Name == "PVE_SCYTHE" || current.Name == "DOUBLE_SCYTHE_HELL")
		{
			entity.rotation.EulerAngles.z += (float)time.FrameInterval * 0.02f;
		}
		else if (current.Name == "M249_ROCKET_MISSILE" || current.Name == "M249_ROCKET_MISSILE_LEVELUP")
		{
			entity.rotation.EulerAngles.z = (float)((double)(entity.moveObject.PitchYawRoll.z - 90f) * Math.PI / 180.0);
		}
	}
}
