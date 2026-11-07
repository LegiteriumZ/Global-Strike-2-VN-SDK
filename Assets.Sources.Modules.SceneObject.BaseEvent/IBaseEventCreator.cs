using NetData;

namespace Assets.Sources.Modules.SceneObject.BaseEvent;

internal interface IBaseEventCreator
{
	void Create(BaseEventEntityData eventEntity, PlayerContext PlayerContext, SceneObjectContext sceneObjectContext);
}
