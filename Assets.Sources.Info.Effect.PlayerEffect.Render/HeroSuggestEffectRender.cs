using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Constant.Career;
using UnityEngine;

namespace Assets.Sources.Info.Effect.PlayerEffect.Render;

public class HeroSuggestEffectRender : AbstractPlayerEffectRender
{
	private Texture2D[] _textures;

	private MeshRenderer[] _animations;

	private int _index = -1;

	public override void Init(PlayerEntity player, GameObject effectGameObject)
	{
		base.Init(player, effectGameObject);
		_textures = effectGameObject.transform.Find("HeroSuggest").GetComponent<TextureList>().Textures;
		_animations = effectGameObject.transform.Find("HeroSuggest").GetComponentsInChildren<MeshRenderer>();
		MeshRenderer[] animations = _animations;
		foreach (MeshRenderer obj in animations)
		{
			obj.sharedMaterial = new Material(obj.sharedMaterial);
		}
		_index = -1;
	}

	public override void Render(int frameTime, PlayerEntity targetPlayer, IBattleRoom battleRoom)
	{
		int num = 0;
		if (PlayerCareerConstantUtility.IsHero(targetPlayer.GetCareer()))
		{
			num = 0;
		}
		else if (targetPlayer.GetCareer() == "death")
		{
			num = 1;
		}
		if (num != _index)
		{
			_index = num;
			MeshRenderer[] animations = _animations;
			for (int i = 0; i < animations.Length; i++)
			{
				animations[i].sharedMaterial.mainTexture = _textures[_index];
			}
		}
	}
}
