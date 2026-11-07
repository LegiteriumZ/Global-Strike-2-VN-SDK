using Assets.Sources.Components.Interface.SceneBuffAttach;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui;
using Assets.UiFramework.Libs;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Info.SceneBuffAttach;

public class MoveEntityEffectHpSceneBuffAttach : ISceneBuffAttach
{
	private Sprite[] _sprites = new Sprite[3];

	public int SpriteIndex;

	private Image _hpImage;

	private UiResourcesLoader _loader;

	private static AssetInfo _greenAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/hp/green.png");

	private static AssetInfo _yellowAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/hp/yellow.png");

	private static AssetInfo _redAsset = new AssetInfo("effect/common", "Assets/Res/Assets/effect/common/hp/red.png");

	public void Init()
	{
		SpriteIndex = -1;
		if (_sprites[0] == null)
		{
			_loader = (UiResourcesLoader)AbstractModel.GetUiResourceLoader();
			_loader.RetriveSprite(_greenAsset, delegate(Sprite sprite)
			{
				_sprites[0] = sprite;
			});
			_loader.RetriveSprite(_yellowAsset, delegate(Sprite sprite)
			{
				_sprites[1] = sprite;
			});
			_loader.RetriveSprite(_redAsset, delegate(Sprite sprite)
			{
				_sprites[2] = sprite;
			});
		}
	}

	public void Render(int frameTime, SceneObjectEntity entity, SceneObjectEntity attachedEntity)
	{
		GameObject gameObject = entity.unityObjects.LoadResults[0].GameObject;
		if (SpriteIndex == -1)
		{
			_hpImage = gameObject.transform.GetChild(0).GetChild(0).GetChild(0)
				.GetComponent<Image>();
		}
		VectorCoordConverter.SsjjToUnity(new Vector3(entity.sceneBuffAttach.MoveEntityData.X, entity.sceneBuffAttach.MoveEntityData.Y, entity.sceneBuffAttach.MoveEntityData.Z), out var dest);
		gameObject.transform.position = dest + new Vector3(0f, 90f, 0f);
		float num = (float)entity.sceneBuffAttach.MoveEntityData.Hp * 1f / (float)entity.sceneBuffAttach.MoveEntityData.MaxHp;
		int num2 = 0;
		num2 = ((!(num > 0.66f)) ? ((num > 0.33f) ? 1 : 2) : 0);
		if (num2 != SpriteIndex && _sprites[num2] != null)
		{
			SpriteIndex = num2;
			_hpImage.sprite = _sprites[num2];
		}
		_hpImage.fillAmount = num;
	}

	public AssetInfo GetEffectAssetInfo()
	{
		return AssetBundleNameConstant.GetSceneEffectPrefabAssetInfo("MoveEntityEffectHp");
	}

	public ISceneBuffAttach Clone()
	{
		return new MoveEntityEffectHpSceneBuffAttach();
	}
}
