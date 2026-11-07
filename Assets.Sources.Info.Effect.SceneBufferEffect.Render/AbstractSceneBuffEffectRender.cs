using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public abstract class AbstractSceneBuffEffectRender : ISceneBuffEffectRender
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

	public virtual Vector3 GetRotation(SceneObjectEntity target)
	{
		return new Vector3(0f, 0f - target.sceneBuff.Data.Yaw, target.sceneBuff.Data.Pitch);
	}

	public virtual void Render(int frameTime, IBattleRoom battleRoom)
	{
	}

	public virtual bool InBreakPoint()
	{
		return false;
	}

	public virtual bool CanPickWeapon()
	{
		return false;
	}

	public virtual bool CanOpenKongzhiqi()
	{
		return false;
	}

	public virtual bool CanCloseKongzhiqi()
	{
		return false;
	}

	public virtual bool JumpStart()
	{
		return false;
	}

	public virtual bool JumpStop()
	{
		return false;
	}
}
