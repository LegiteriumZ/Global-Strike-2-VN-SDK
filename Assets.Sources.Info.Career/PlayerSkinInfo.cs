using System.Collections.Generic;
using Assets.Sources.XmlAsset;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Career;

public class PlayerSkinInfo
{
	public string Name;

	public bool HasSkinTexture;

	public bool HasThirdModel;

	public bool HasViewHandModel;

	public bool HasEffect;

	public bool HasEffectConfig;

	public string PlayerName;

	public bool HasTextureConfig;

	public bool HasHitBox;

	public bool HasDyeing;

	private string _prefabBundleName;

	private string _effectPath;

	private AssetInfo _thirdModelAsset;

	private AssetInfo _viewHandModelAsset;

	private AssetInfo _hitBoxAsset;

	private AssetInfo _textureConfigAsset;

	private AssetInfo _particleEffectAsset;

	private AssetInfo _effectConfigAsset;

	private AssetInfo _bodyMask1Asset;

	private AssetInfo _bodyMask2Asset;

	private AssetInfo _bodyMask1Asset_viewHand;

	private AssetInfo _bodyMask2Asset_viewHand;

	public string PrefabBundleName => _prefabBundleName;

	public string EffectPath => _effectPath;

	public AssetInfo ThirdModelAsset => _thirdModelAsset;

	public AssetInfo ViewHandModelAsset => _viewHandModelAsset;

	public AssetInfo HitBoxAsset => _hitBoxAsset;

	public AssetInfo TextureConfigAsset => _textureConfigAsset;

	public AssetInfo ParticleEffectAsset => _particleEffectAsset;

	public AssetInfo EffectConfigAsset => _effectConfigAsset;

	public AssetInfo bodyMask1Asset => _bodyMask1Asset;

	public AssetInfo bodyMask2Asset => _bodyMask2Asset;

	public AssetInfo viewHand_bodyMask1Asset => _bodyMask1Asset_viewHand;

	public AssetInfo viewHand_bodyMask2Asset => _bodyMask2Asset_viewHand;

	public PlayerSkinInfo(string name)
	{
		Name = name;
		_prefabBundleName = $"playerskin/{name}";
		_effectPath = $"Assets/Res/Assets/playerskin/{name}/effect";
		_thirdModelAsset = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/model.prefab");
		_hitBoxAsset = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/hitbox.xml", typeof(HitHelpInfo), optional: true);
		_textureConfigAsset = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/textureconfig.xml", typeof(TextureConfigInfo), optional: true);
		_viewHandModelAsset = new AssetInfo($"playerskin/{Name}", $"Assets/Res/Assets/playerskin/{Name}/viewhand/model.prefab", typeof(GameObject));
		_effectConfigAsset = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/effect/effectConfig.xml", typeof(EffectXmlAsset), optional: true);
		_particleEffectAsset = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/effect/particleEffectConfig.xml", typeof(ParticleXmlAsset), optional: true);
		_bodyMask1Asset = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/bodymask/body_mask1.png", typeof(Texture), optional: true);
		_bodyMask2Asset = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/bodymask/body_mask2.png", typeof(Texture), optional: true);
		_bodyMask1Asset_viewHand = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/viewhand/bodymask/body_mask1.png", typeof(Texture), optional: true);
		_bodyMask2Asset_viewHand = new AssetInfo("playerskin/" + Name, $"Assets/Res/Assets/playerskin/{Name}/viewhand/bodymask/body_mask2.png", typeof(Texture), optional: true);
	}

	public List<AssetInfo> GetUnloadAssetInfos()
	{
		return new List<AssetInfo> { TextureConfigAsset, ViewHandModelAsset, HitBoxAsset, ThirdModelAsset };
	}
}
