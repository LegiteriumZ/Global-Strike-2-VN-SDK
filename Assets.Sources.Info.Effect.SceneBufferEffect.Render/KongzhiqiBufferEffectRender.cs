using Assets.Res.Assets.Scripts;
using Assets.Sources.Components.Interface;
using Assets.Sources.Utils.SceneObject;
using UnityEngine;

namespace Assets.Sources.Info.Effect.SceneBufferEffect.Render;

public class KongzhiqiBufferEffectRender : AbstractSceneBuffEffectRender
{
	private PlayerContext _playerContext;

	private Transform _model0;

	private Transform _sprite1;

	private Texture2D[] _textureList;

	private Sprite[] _spriteList;

	private ModelTextureSheetAnimation _sheetAnimation;

	private SpriteAnimation _spriteAnimation;

	private int _currLevel = -1;

	public override void Init(ISceneObjectEntity entity, GameObject effectGameObject)
	{
		base.Init(entity, effectGameObject);
		_playerContext = Contexts.sharedInstance.player;
		if (entity.HasSceneBuff)
		{
			_model0 = effectGameObject.transform.Find("0/model");
			_sprite1 = effectGameObject.transform.Find("1/sprite");
			_textureList = _model0.GetComponent<TextureList>().Textures;
			_spriteList = _sprite1.GetComponent<SpriteList>().Sprites;
			_sheetAnimation = _model0.GetComponent<ModelTextureSheetAnimation>();
			_spriteAnimation = _sprite1.GetComponent<SpriteAnimation>();
		}
	}

	public override void Render(int frameTime, IBattleRoom battleRoom)
	{
		if (Entity.SceneBuff.Data.Lv != _currLevel)
		{
			_currLevel = Entity.SceneBuff.Data.Lv;
			if (Entity.SceneBuff.Data.Lv == 1)
			{
				_sheetAnimation.Textures = new Texture2D[1] { _textureList[1] };
				_spriteAnimation.Sprites = new Sprite[1] { _spriteList[1] };
			}
			else
			{
				_sheetAnimation.Textures = new Texture2D[1] { _textureList[0] };
				_spriteAnimation.Sprites = new Sprite[1] { _spriteList[0] };
			}
		}
	}

	public override bool CanOpenKongzhiqi()
	{
		if (SceneObjectEntityUtility.InSceneBuffRadius(_playerContext.myPlayerEntity, Entity) && Entity.SceneBuff.Data.Lv != 1)
		{
			return true;
		}
		return false;
	}

	public override bool CanCloseKongzhiqi()
	{
		if (SceneObjectEntityUtility.InSceneBuffRadius(_playerContext.myPlayerEntity, Entity) && Entity.SceneBuff.Data.Lv == 1)
		{
			return true;
		}
		return false;
	}
}
