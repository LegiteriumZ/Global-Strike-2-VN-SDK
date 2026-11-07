using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public abstract class AbstractLocalEntityEffectRender : ILocalEntityEffectRender
{
	protected ISceneObjectEntity Entity;

	protected GameObject EffectObject;

	public virtual void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		Entity = entity;
		EffectObject = effectGameObject;
	}

	public virtual Vector3 GetOffset(IBattleRoom battleRoom)
	{
		return Vector3.zero;
	}

	public virtual Vector3 GetScale(IBattleRoom battleRoom)
	{
		return Vector3.one;
	}

	public virtual void Render(int frameTime, IBattleRoom battleRoom)
	{
	}
}
