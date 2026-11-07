using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class UseDartsEffectRender : AbstractPlayerEffectRender
{
	private Transform _diAnimation;

	private Transform _planeAnimation;

	private Transform _quanAnimation;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_diAnimation = effectGameObject.transform.Find("UseDarts/di/sprite");
		_quanAnimation = effectGameObject.transform.Find("UseDarts/quan/model");
		_planeAnimation = effectGameObject.transform.Find("UseDarts/plane/model");
		if (player.GetCareer() == "doun")
		{
			_diAnimation.GetComponent<SpriteAnimation>().Sprites = _diAnimation.GetComponent<SpriteList>().Sprites;
			_quanAnimation.GetComponent<ModelTextureSheetAnimation>().Textures = _diAnimation.GetComponent<TextureList>().Textures;
			_planeAnimation.GetComponent<ModelTextureSheetAnimation>().Textures = _diAnimation.GetComponent<TextureList>().Textures;
		}
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
	}
}
