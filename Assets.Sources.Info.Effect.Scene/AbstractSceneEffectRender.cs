using Assets.Sources.Components.Interface.Info.Effect;
using UnityEngine;

namespace Assets.Sources.Info.Effect.Scene;

public abstract class AbstractSceneEffectRender : ISceneEffectRender
{
	protected SceneEffectData EffectData;

	protected GameObject EffectObject;

	public virtual void Init(SceneObjectEntity entity, GameObject effectGameObject)
	{
		EffectObject = effectGameObject;
	}

	public abstract void Render(int frameTime, SceneObjectEntity entity);
}
