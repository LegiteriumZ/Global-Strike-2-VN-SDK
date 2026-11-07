using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Info.MoveObject;
using Entitas;
using NetData;
using SSJJParticle;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.MoveObject;

internal class MoveObjectPlaybackSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private readonly IGroup<SceneObjectEntity> _group;

	public MoveObjectPlaybackSystem(Contexts contexts)
	{
		_group = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.MoveObject).NoneOf(SceneObjectMatcher.Destroy));
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity item in _group)
		{
			MoveEntityData current2 = item.moveObject.Current;
			MoveEntityData next = item.moveObject.Next;
			if (next == null || current2 == null)
			{
				break;
			}
			LinearInterpolate(item, _time.FrameInterpolation);
			LinearRotation(item, current2, next);
			updateMaterialsAlpha(item, current2, next);
		}
	}

	private void updateMaterialsAlpha(SceneObjectEntity entity, MoveEntityData current, MoveEntityData next)
	{
		if (!entity.hasMoveObjectAddEffect)
		{
			return;
		}
		global::SSJJParticle.SSJJParticle[] componentsInChildren = entity.unityObjects.LoadResults[0].GameObject.GetComponentsInChildren<global::SSJJParticle.SSJJParticle>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			Material mater = componentsInChildren[i].mater;
			if ((bool)mater)
			{
				Color color = mater.GetColor("_TintColor");
				if (current.AlphaSpecified)
				{
					color.a = (float)current.Alpha * 0.5f * 0.01f;
				}
				mater.SetColor("_TintColor", color);
			}
		}
	}

	private void LinearRotation(SceneObjectEntity entity, MoveEntityData current, MoveEntityData next)
	{
		if (entity.moveObject.Info != null)
		{
			((AbstractMoveObjectInfo)entity.moveObject.Info).IsHide = current.Hide;
		}
		entity.moveObject.PitchYawRoll = Quaternion.Lerp(Quaternion.Euler(new Vector3(current.Roll, current.Pitch, current.Yaw)), Quaternion.Euler(new Vector3(next.Roll, next.Pitch, next.Yaw)), _time.FrameInterpolation).eulerAngles;
		if (entity.moveObject.PitchYawRoll.x > 180f)
		{
			entity.moveObject.PitchYawRoll.x -= 360f;
		}
		if (entity.moveObject.PitchYawRoll.y > 180f)
		{
			entity.moveObject.PitchYawRoll.y -= 360f;
		}
		if (entity.moveObject.PitchYawRoll.z > 180f)
		{
			entity.moveObject.PitchYawRoll.z -= 360f;
		}
		if (Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 100 && Contexts.sharedInstance.battleRoom.roomData.Data.FreeType == "BulletStorm")
		{
			entity.moveObject.PitchYawRoll.y = 0f - entity.moveObject.PitchYawRoll.y;
		}
	}

	private void LinearInterpolate(SceneObjectEntity entity, float interpolation)
	{
		MoveEntityData current = entity.moveObject.Current;
		MoveEntityData next = entity.moveObject.Next;
		if (next != null && current != null)
		{
			Vector3 vector = new Vector3(current.X, current.Y, current.Z);
			entity.position.Origin = Vector3.Lerp(new Vector3(vector.x, vector.y, vector.z), new Vector3(next.X, next.Y, next.Z), interpolation);
			if (current.Scale > 0f)
			{
				entity.scale.Scale = new Vector3(current.Scale, current.Scale, current.Scale);
			}
			else
			{
				entity.scale.Scale = new Vector3(1f, 1f, 1f);
			}
			if (current.ScaleX > 0f)
			{
				entity.scale.Scale.x *= current.ScaleX;
			}
			if (current.ScaleY > 0f)
			{
				entity.scale.Scale.z *= current.ScaleY;
			}
			if (current.ScaleZ > 0f)
			{
				entity.scale.Scale.y *= current.ScaleZ;
			}
		}
	}
}
