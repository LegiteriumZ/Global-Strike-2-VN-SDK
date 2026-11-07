using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.BattleRoom;
using Entitas;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Modules.SceneObject.LocalEntityEffect;

public class LocalEntityEffectRenderSystem : IRenderSystem
{
	private IGroup<SceneObjectEntity> _effectGroup;

	private TimeContext _timeContext;

	private IBattleRoom _battleRoomAdapter;

	public LocalEntityEffectRenderSystem(Contexts contexts)
	{
		_timeContext = contexts.time;
		_battleRoomAdapter = new DefaultBattleRoom(contexts);
		_effectGroup = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.LocalEntityEffect, SceneObjectMatcher.UnityObjects, SceneObjectMatcher.Position, SceneObjectMatcher.Scale).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnRender()
	{
		foreach (SceneObjectEntity item in _effectGroup)
		{
			if (item.hasLocalEntityEffectRender)
			{
				item.localEntityEffectRender.Render.Render(_timeContext.time.FrameInterval, _battleRoomAdapter);
			}
			Vector3 origin = item.position.Origin;
			Vector3 scale = item.scale.Scale;
			Vector3 eulerAngles = item.rotation.EulerAngles;
			item.unityObjects.LoadResults[0].GameObject.transform.position = origin;
			item.unityObjects.LoadResults[0].GameObject.transform.localEulerAngles = eulerAngles;
			item.unityObjects.LoadResults[0].GameObject.transform.localScale = VectorCoordConverter.SsjjScaleToUnity(scale);
		}
	}
}
