using System;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Entitas;
using NetData;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.SceneWeapon;

public class SceneWeaponPlaybackSystem : IPlaybackSystem
{
	private TimeComponent _time;

	private readonly IGroup<SceneObjectEntity> _sceneWeapons;

	public SceneWeaponPlaybackSystem(Contexts contexts)
	{
		_sceneWeapons = contexts.sceneObject.GetGroup(SceneObjectMatcher.SceneWeapon);
		_time = contexts.time.time;
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity sceneWeapon in _sceneWeapons)
		{
			SceneWeaponEntityData current2 = sceneWeapon.sceneWeapon.Current;
			SceneWeaponEntityData next = sceneWeapon.sceneWeapon.Next;
			if (current2 != null && next != null && sceneWeapon.hasPosition)
			{
				float frameInterpolation = _time.FrameInterpolation;
				sceneWeapon.position.Origin = Vector3.Lerp(new Vector3(current2.X, current2.Y, current2.Z), new Vector3(next.X, next.Y, next.Z), frameInterpolation);
				sceneWeapon.orientation.Yaw = Mathf.LerpAngle(current2.Yaw, next.Yaw, frameInterpolation) / ((float)Math.PI / 180f);
				sceneWeapon.orientation.Pitch = Mathf.LerpAngle(current2.Pitch, next.Pitch, frameInterpolation) / ((float)Math.PI / 180f);
				sceneWeapon.orientation.Roll = Mathf.LerpAngle(current2.Roll, next.Roll, frameInterpolation) / ((float)Math.PI / 180f);
			}
		}
	}
}
