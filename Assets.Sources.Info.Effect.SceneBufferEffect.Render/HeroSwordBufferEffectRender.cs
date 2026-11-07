using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class HeroSwordBufferEffectRender : AbstractSceneBuffEffectRender
{
	private Transform _point;

	private SpriteList _spriteList;

	private PlayerEntity _myPlayerEntity;

	private Sprite _currSprite;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		if (entity.HasSceneBuff && Contexts.sharedInstance.player.isMyPlayer)
		{
			_myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
			if (_myPlayerEntity.basicInfo.Current.Team == entity.SceneBuff.Data.Team)
			{
				Transform transform = effectGameObject.transform.Find("GameObject/0/model");
				Transform transform2 = effectGameObject.transform.Find("GameObject/1/sprite");
				Transform transform3 = effectGameObject.transform.Find("GameObject/2/model");
				Transform transform4 = effectGameObject.transform.Find("GameObject/2/3/model");
				Transform transform5 = effectGameObject.transform.Find("GameObject/2/4/model");
				Transform transform6 = effectGameObject.transform.Find("GameObject/2/5/model");
				_point = effectGameObject.transform.Find("GameObject/Point");
				_spriteList = _point.GetComponent<SpriteList>();
				transform.GetComponent<ModelTextureSheetAnimation>().Textures = transform.GetComponent<TextureList>().Textures;
				transform2.GetComponent<SpriteAnimation>().Sprites = transform2.GetComponent<SpriteList>().Sprites;
				transform3.GetComponent<ModelTextureSheetAnimation>().Textures = transform3.GetComponent<TextureList>().Textures;
				transform4.GetComponent<ModelTextureSheetAnimation>().Textures = transform3.GetComponent<TextureList>().Textures;
				transform5.GetComponent<ModelTextureSheetAnimation>().Textures = transform3.GetComponent<TextureList>().Textures;
				transform6.GetComponent<ModelTextureSheetAnimation>().Textures = transform6.GetComponent<TextureList>().Textures;
			}
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (_spriteList != null && _spriteList.Sprites != null && _myPlayerEntity != null)
		{
			if (_myPlayerEntity.GetTeam() == Entity.SceneBuff.Data.Team)
			{
				_currSprite = _spriteList.Sprites[Entity.SceneBuff.Data.Lv + 1];
			}
			else
			{
				_currSprite = _spriteList.Sprites[Entity.SceneBuff.Data.Lv + 4];
			}
			if (_point.GetComponent<SpriteRenderer>().sprite != _currSprite)
			{
				_point.GetComponent<SpriteRenderer>().sprite = _currSprite;
			}
		}
	}
}
