using System;
using Assets.Sources.Framework;
using Assets.Sources.Utils;
using Entitas;

namespace Assets.Sources.Modules.SceneObject.BaseEvent;

internal class BaseEventPackbackSystem : IPlaybackSystem
{
	private readonly IGroup<SceneObjectEntity> _eventObjects;

	public BaseEventPackbackSystem(Contexts contexts)
	{
		_eventObjects = contexts.sceneObject.GetGroup(SceneObjectMatcher.AllOf(SceneObjectMatcher.BaseEvent, SceneObjectMatcher.BaseEventResource, SceneObjectMatcher.LifeTime).NoneOf(SceneObjectMatcher.Destroy));
	}

	public void OnPlayback()
	{
		foreach (SceneObjectEntity eventObject in _eventObjects)
		{
			if (!eventObject.hasAddParticleLod)
			{
				eventObject.AddAddParticleLod(newIsAdd: true);
			}
			if ((DateTime.Now - eventObject.lifeTime.CreateTime).TotalMilliseconds - (double)eventObject.lifeTime.LifeTime > -200.0 && eventObject.hasAddParticleLod && eventObject.addParticleLod.IsAdd)
			{
				if (eventObject.baseEventResource.LoadResults.ContainsKey(0))
				{
					LodUtility.RemoveInstanceLod(eventObject.baseEventResource.LoadResults[0].GameObject);
				}
				eventObject.addParticleLod.IsAdd = false;
			}
		}
	}
}
