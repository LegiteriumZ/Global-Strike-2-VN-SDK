using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.LocalEntityEffect.Render;

public class Ak47LegendSkillEffectRender : AbstractLocalEntityEffectRender
{
	private SpriteRenderer _spriteRender;

	private MaterialPropertyBlock _block;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_spriteRender = effectGameObject.transform.Find("1/sprite").GetComponent<SpriteRenderer>();
		_block = new MaterialPropertyBlock();
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		_spriteRender.GetPropertyBlock(_block);
		_block.SetColor("_Color", Color.white);
	}
}
