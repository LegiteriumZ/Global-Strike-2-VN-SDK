using Assets.Sources.Components.Interface;
using Assets.Sources.Components.Interface.Info.Effect;
using UnityEngine;

namespace Assets.Sources.Info.Effect.FirstPlayerEffect.Render;

public abstract class AbstractFirstPlayerEffectRender : IFirstPlayerEffectRender
{
	protected GameObject EffectObject;

	public virtual void Init(PlayerEntity player, GameObject effectGameObject)
	{
		EffectObject = effectGameObject;
	}

	public virtual Vector3 GetOffset(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return Vector3.zero;
	}

	public virtual Vector3 GetScale(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return Vector3.one;
	}

	public virtual Vector3 GetRotation(PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		return Vector3.zero;
	}

	public abstract void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom);
}
