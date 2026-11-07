using System;
using Assets.Scripts.Effect;
using NetData;

namespace Assets.Sources.Modules.SceneObject.BaseEvent.Creator;

internal class Vertogo : IBaseEventCreator
{
	public void Create(BaseEventEntityData eventEntity, PlayerContext playerContext, SceneObjectContext sceneObjectContext)
	{
		SceneObjectEntity sceneObjectEntity = sceneObjectContext.CreateEntity();
		sceneObjectEntity.AddEntityId(eventEntity.Id);
		sceneObjectEntity.AddLifeTime(DateTime.Now, eventEntity.Data);
		ExplosionBlurEffect.CreateOnce();
	}
}
