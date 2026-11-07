using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Career;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Constant;
using Assets.Sources.Constant.Career;
using Assets.Sources.Info.CareerAnim;
using Assets.Sources.Utils.Weapon;
using SSJJAsset.Asset;
using SSJJMath;
using UnityEngine;
using config;
using share;

namespace Assets.Sources.Info.Career;

internal class DefaultCareerInfo : ICareerInfo
{
	public static string CharacterPrefix = "character_";

	public static string ShaderBundleNameC = "weapon_shader";

	private readonly string _name;

	private readonly string _prefabBundleName;

	private readonly string _prefabAssetName;

	private readonly string _preGeometryName;

	private readonly string _textureConfigAssetName;

	private readonly string _cameraEffectConfigAssetName;

	private readonly string _particleXmlAssetName;

	private readonly string _effectXmlAssetName;

	private readonly string _soundEffectXmlAssetName;

	private readonly string _effectPath;

	private readonly string _hitboxAssetName;

	private readonly bool _isFemale;

	private readonly string _animBundleName;

	private readonly string _dynAnimBundleName;

	private readonly string _animConfigAssetName;

	private readonly string _bodyMask1AssetName;

	private readonly string _bodyMask2AssetName;

	public string PrefabAvaterRootBundleName { get; private set; }

	public string PrefabAvaterRootAssetName { get; private set; }

	public bool IsHumanity => PlayerCareerConstantUtility.IsHumanity(_name);

	public string Name => _name;

	public string PrefabBundleName => _prefabBundleName;

	public string PrefabAssetName => _prefabAssetName;

	public string PreGeometryName => _preGeometryName;

	public string TextureConfigAssetName => _textureConfigAssetName;

	public string CameraEffectConfigAssetName => _cameraEffectConfigAssetName;

	public string ParticleXmlAssetName => _particleXmlAssetName;

	public string EffectXmlAssetName => _effectXmlAssetName;

	public string SoundEffectXmlAssetName => _soundEffectXmlAssetName;

	public string EffectPath => _effectPath;

	public string HitboxAssetName => _hitboxAssetName;

	public bool IsFemale => _isFemale;

	public string AnimBundleName => _animBundleName;

	public string DynAnimBundleName => _dynAnimBundleName;

	public string bodyMask1AssetName => _bodyMask1AssetName;

	public string bodyMask2AssetName => _bodyMask2AssetName;

	public string AnimConfigAssetName => _animConfigAssetName;

	public string TorseAnimAssetName => "torso.anm.bytes";

	public string LegAnimAssetName => "leg.anm.bytes";

	public double NormalViewHeight => ViewHeight.GetNormalViewHeight(Name);

	public double DuckViewHeight => ViewHeight.GetDuckViewHeight(Name);

	public Vector3D NormalMin { get; private set; }

	public Vector3D NormalMax { get; private set; }

	public Vector3D DuckMin { get; private set; }

	public Vector3D DuckMax { get; private set; }

	public Vector3D DuckJumpMin { get; private set; }

	public Vector3D DuckJumpMax { get; private set; }

	public Vector3D DetectorMin { get; private set; }

	public Vector3D DetectorMax { get; private set; }

	internal DefaultCareerInfo(string name)
	{
		_name = name;
		_prefabBundleName = "player/" + _name;
		PrefabAvaterRootBundleName = "player/unity" + _name;
		PrefabAvaterRootAssetName = $"Assets/Res/Assets/player/unity{_name}/Prefabs/root.prefab";
		string careerAnimationType = CareerData.GetCareerAnimationType(_name);
		_prefabAssetName = $"Assets/Res/Assets/player/{_name}/model.prefab";
		_preGeometryName = $"Assets/Res/Assets/player/{_name}/model.preGeo.bytes";
		_textureConfigAssetName = $"Assets/Res/Assets/player/{_name}/textureconfig.xml";
		_cameraEffectConfigAssetName = $"Assets/Res/Assets/player/{_name}/effect/cameraeffectconfig.xml";
		_particleXmlAssetName = $"Assets/Res/Assets/player/{_name}/effect/particleEffectConfig.xml";
		_effectXmlAssetName = $"Assets/Res/Assets/player/{_name}/effect/effectConfig.xml";
		_soundEffectXmlAssetName = $"Assets/Res/Assets/player/{_name}/effect/soundconfig.xml";
		_effectPath = $"Assets/Res/Assets/player/{_name}/effect";
		_hitboxAssetName = $"Assets/Res/Assets/player/{_name}/hitbox.xml";
		_isFemale = CareerData.GetCareerAnimationType(_name).Equals("woman");
		_animBundleName = $"playeranim/{careerAnimationType}";
		_bodyMask1AssetName = $"Assets/Res/Assets/player/{_name}/bodymask/body_mask1.png";
		_bodyMask2AssetName = $"Assets/Res/Assets/player/{_name}/bodymask/body_mask2.png";
		if (careerAnimationType.Equals("manct", StringComparison.OrdinalIgnoreCase) || careerAnimationType.Equals("woman", StringComparison.OrdinalIgnoreCase))
		{
			_dynAnimBundleName = $"playerAnimDynamic/{careerAnimationType}";
		}
		else
		{
			_dynAnimBundleName = $"playerAnim/{careerAnimationType}";
		}
		_animConfigAssetName = $"Assets/Res/Assets/playerAnim/{careerAnimationType}/model.DAE.action.xml";
		NormalMin = BoundBoxConfig.GetBoundsMinForPlayer(name, 3);
		NormalMax = BoundBoxConfig.GetBoundsMaxForPlayer(name, 3);
		DuckMin = BoundBoxConfig.GetBoundsMinForPlayer(name, 0);
		DuckMax = BoundBoxConfig.GetBoundsMaxForPlayer(name, 0);
		DuckJumpMin = BoundBoxConfig.GetBoundsMinForPlayer(name, 2);
		DuckJumpMax = BoundBoxConfig.GetBoundsMaxForPlayer(name, 2);
		DetectorMin = BoundBoxConfig.GetDetectorBoundsMinForNormalPlayer(name);
		DetectorMax = BoundBoxConfig.GetDetectorBoundsMaxForNormalPlayer(name);
	}

	public Vector3 GetCurrentMax(int moveDuckState)
	{
		return VectorTypeConverter.Ssjj2Unity(BoundBoxConfig.GetBoundsMaxForPlayer(Name, moveDuckState));
	}

	public Vector3 GetCurrentMin(int moveDuckState)
	{
		return VectorTypeConverter.Ssjj2Unity(BoundBoxConfig.GetBoundsMinForPlayer(Name, moveDuckState));
	}

	private string GetWeaponAnimAssetName(string weapon)
	{
		return $"{weapon}.anm.bytes";
	}

	public HashSet<string> GetWeaponAnimAssetNames(IEntitsWeaponInfo weaponInfo)
	{
		HashSet<string> hashSet = new HashSet<string>();
		hashSet.Add(GetWeaponAnimAssetName(WeaponUtility.GetWeaponAnimConvertHelper(weaponInfo, weaponInfo.ThirdAnimations[0])));
		foreach (KeyValuePair<int, string> item in weaponInfo.SpecialThirdAnimationTypeDict)
		{
			string value = item.Value;
			if (!hashSet.Contains(value))
			{
				hashSet.Add(GetWeaponAnimAssetName(value));
			}
		}
		return hashSet;
	}

	public string GetWeaponLegAnimName(IEntitsWeaponInfo weaponInfo)
	{
		return weaponInfo.LegsThirdAnimationType + "_leg.anm.bytes";
	}

	public string GetWeaponBodyAnimName(IEntitsWeaponInfo weaponInfo)
	{
		return weaponInfo.LegsThirdAnimationType + "_body.anm.bytes";
	}

	public List<AssetInfo> GetUnloadAssetInfos()
	{
		return new List<AssetInfo>
		{
			new AssetInfo(PrefabBundleName, TextureConfigAssetName, typeof(TextureConfigInfo)),
			new AssetInfo(PrefabBundleName, HitboxAssetName, typeof(HitHelpInfo)),
			new AssetInfo(PrefabBundleName, PrefabAssetName, typeof(GameObject))
		};
	}
}
