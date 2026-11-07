using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface.Info.Weapon;
using Assets.Sources.Components.Interface.Info.Weapon.Logic;
using Assets.Sources.Constant.Weapon;
using Assets.Sources.Info.ThirdWeaponAnim;
using Assets.Sources.Info.WeaponAnim;
using Assets.Sources.Utils;
using SSJJAnim.Attach;
using SSJJAnim.Parser;
using SSJJAnim.Weapon;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Info.Weapon.WeaponInfo;

public abstract class DefaultWeaponInfo : IWeaponInfo, IEntitsWeaponInfo
{
	private readonly string _name;

	private readonly string _sceneAssetName;

	private readonly string _viewWeaponAssetName;

	private readonly string _firstKnifeAssetName;

	private readonly string _thirdKnifeAssetName;

	private readonly string _viewHandAnimationAssetName;

	private readonly string _viewWeaponAnimationAssetName;

	private readonly string _thirdWeaponAnimationAssetName;

	private readonly string _thirdWeaponAnimationXmlAssetName;

	private readonly string _viewCameraConfigAssetName;

	private readonly string _particleXmlAssetName;

	private readonly string _soundXmlAssetName;

	private readonly string _loigcXmlAssetName;

	private readonly string _effectXmlAssetName;

	private readonly string _eventParticleXmlAssetName;

	private readonly string _weaponConfigtXmlAssetName;

	private readonly string _backWeaponConfigtXmlAssetName;

	private readonly string _cameraEffectConfigAssetName;

	private readonly string _effectPath;

	private readonly string _thirdAssetName;

	private readonly string _iconAssetName;

	private readonly string _viewAnimConfigAssetName;

	private string _assetBundleName;

	private string _splitAssetBundleName;

	private readonly string _weaponLogicAssetName;

	private readonly string _weaponLayoutAssetName;

	private readonly string _icon_2AssetName;

	private readonly string _icon_AssetName;

	public int Damage { get; set; }

	public IAccuracyLogic AccuracyLogic { get; set; }

	public ISpreadLogic SpreadLogic { get; set; }

	public IShotDistanceLogic ShotDistanceLogic { get; set; }

	public IHoleLogic HoleLogic { get; set; }

	public IEventLogic EventLogic { get; set; }

	public ICdTimeLogic CdTimeLogic { get; set; }

	public IMaxSpeedLogic MaxSpeedLogic { get; set; }

	public IWeaponAttachFactory AttachFactory { get; set; }

	public string AssetBundleName => _assetBundleName;

	public string SplitAssetBundleName
	{
		get
		{
			return _splitAssetBundleName;
		}
		set
		{
			_splitAssetBundleName = value;
		}
	}

	public string SceneAssetName => _sceneAssetName;

	public string ViewWeaponAssetName => _viewWeaponAssetName;

	public string ViewHandAnimationAssetName => _viewHandAnimationAssetName;

	public string ViewWeaponAnimationAssetName => _viewWeaponAnimationAssetName;

	public string ThirdWeaponAnimationAssetName => _thirdWeaponAnimationAssetName;

	public string ThirdWeaponAnimationXmlAssetName => _thirdWeaponAnimationXmlAssetName;

	public string ViewCameraConfigAssetName => _viewCameraConfigAssetName;

	public string SoundXmlAssetName => _soundXmlAssetName;

	public string LogicXmlAssetName => _loigcXmlAssetName;

	public string ParticleXmlAssetName => _particleXmlAssetName;

	public string EffectXmlAssetName => _effectXmlAssetName;

	public string EventParticleXmlAssetName => _eventParticleXmlAssetName;

	public string WeaponConfigtXmlAssetName => _weaponConfigtXmlAssetName;

	public string BackWeaponConfigtXmlAssetName => _backWeaponConfigtXmlAssetName;

	public string CameraEffectConfigAssetName => _cameraEffectConfigAssetName;

	public string EffectPath => _effectPath;

	public string ThirdAssetName => _thirdAssetName;

	public string IconAssetName => _iconAssetName;

	public string ViewAnimConfigAssetName => _viewAnimConfigAssetName;

	public string Name => _name;

	public string StringName { get; set; }

	public AttackType AttackType { get; set; }

	public AttackType SpecialAttackType { get; set; }

	public int SecondaryDamage { get; set; }

	public int ThirdAnimationLayerIndex => WeaponConstant.GetThirdWeaponLayerIndex(_name);

	public bool HideViewHand { get; set; }

	public bool HideThirdHand { get; set; }

	public bool IsGold { get; set; }

	public string ThirdKnifeAssetName => _thirdKnifeAssetName;

	public string FirstKnifeAssetName => _firstKnifeAssetName;

	public string AnimConfigBundleName => AssetBundleName;

	public int WeaponType { get; set; }

	public int AttackInterval { get; set; }

	public int MaxClip { get; set; }

	public int MaxCarryClip { get; set; }

	public int MaxClip2 { get; set; }

	public int MaxCarryClip2 { get; set; }

	public int ShotsLimit { get; set; }

	public int SlashSlashTime { get; set; }

	public int SlashStabTime { get; set; }

	public int StabSlashTime { get; set; }

	public int StabStabTime { get; set; }

	public int DelayAttackSlashTime { get; set; }

	public int DelayAttackSlashTime2 { get; set; }

	public int DelayAttackStabTime { get; set; }

	public float MeleeAttackDistance { get; set; }

	public float AccuracyDivisor { get; set; }

	public float AccuracyOffset { get; set; }

	public float MaxInaccuracy { get; set; }

	public float DefaultAccuracy { get; set; }

	public float SpreadScaleY { get; set; }

	public int ClipCount { get; set; }

	public int ShotsFiredSpreadMin { get; set; }

	public int ShotsFiredSpreadMax { get; set; }

	public int ShotsFiredSpreadTime { get; set; }

	public string ThirdAnimationType { get; set; }

	public List<string> ThirdAnimations { get; set; }

	public string LegsThirdAnimationType { get; set; }

	public Dictionary<int, string> SpecialThirdAnimationTypeDict { get; set; }

	public string AnimationWeaponName { get; set; }

	public string CrossType { get; set; }

	public string ReloadType { get; set; }

	public string RaiseType { get; set; }

	public string[] UiModels { get; set; }

	public string SharedCallBackType { get; set; }

	public string SharedCallBackParas { get; set; }

	public int DelayRaiseAttackTime { get; set; }

	public bool SharedPredication { get; set; }

	public int ClipPerShot { get; set; }

	public bool HasKnifeEffect { get; set; }

	public bool HasDoubleAttack { get; set; }

	public bool HasOtherFire { get; set; }

	public string ThirdAnimationStateName { get; set; }

	public List<IViewWeaponEffectLogic> ViewWeaponEffectLogics { get; set; }

	public List<IThirdWeaponEffectLogic> ThirdWeaponEffectLogics { get; set; }

	public IChangeWeapon ChangeWeaponLogic { get; set; }

	public string WeaponLayoutAssetName => _weaponLayoutAssetName;

	public string WeaponLogicAssetName => _weaponLogicAssetName;

	protected DefaultWeaponInfo(string name, string attackType, string specialAttackType, bool isSharedPredication)
	{
		_name = name;
		UiModels = new string[0];
		if (!isSharedPredication)
		{
			AttackType = (AttackType)Enum.Parse(typeof(AttackType), attackType);
			SpecialAttackType = (AttackType)Enum.Parse(typeof(AttackType), specialAttackType);
		}
		SpecialThirdAnimationTypeDict = new Dictionary<int, string>();
		_assetBundleName = "weapon/" + _name;
		_splitAssetBundleName = _assetBundleName;
		_icon_AssetName = string.Format("Assets/Res/Assets/weapon/{0}/ui/{0}.png", _name);
		_icon_2AssetName = string.Format("Assets/Res/Assets/weapon/{0}/ui/{0}-2.png", _name);
		_firstKnifeAssetName = $"Assets/Res/Assets/weapon/{_name}/knifeeffect/frist.prefab";
		_thirdKnifeAssetName = $"Assets/Res/Assets/weapon/{_name}/knifeeffect/third.prefab";
		_sceneAssetName = $"Assets/Res/Assets/weapon/{_name}/scene/model.prefab";
		_viewWeaponAssetName = $"Assets/Res/Assets/weapon/{_name}/view/gun.prefab";
		_viewHandAnimationAssetName = $"Assets/Res/Assets/weapon/{_name}/view/hand_man.anm.bytes";
		_viewWeaponAnimationAssetName = $"Assets/Res/Assets/weapon/{_name}/view/gun.anm.bytes";
		_thirdWeaponAnimationAssetName = $"Assets/Res/Assets/weapon/{_name}/third/model.anm.bytes";
		_thirdWeaponAnimationXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/third/model.DAE.action.xml";
		_viewCameraConfigAssetName = $"Assets/Res/Assets/weapon/{_name}/view/camera_man.xml";
		_particleXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/effect/particleEffectConfig.xml";
		_soundXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/effect/soundconfig.xml";
		_loigcXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/effect/particle_logic.xml";
		_effectXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/effect/effectConfig.xml";
		_eventParticleXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/effect/eventParticleConfig.xml";
		_weaponConfigtXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/weaponconfig.xml";
		_backWeaponConfigtXmlAssetName = $"Assets/Res/Assets/weapon/{_name}/scene/backweapon.xml";
		_effectPath = $"Assets/Res/Assets/weapon/{_name}/effect";
		_thirdAssetName = $"Assets/Res/Assets/weapon/{_name}/third/model.prefab";
		_iconAssetName = string.Format("Assets/Res/Assets/weapon/{0}/ui/{0}.png", _name);
		_viewAnimConfigAssetName = $"Assets/Res/Assets/weapon/{_name}/view/hand.DAE.action.xml";
		_cameraEffectConfigAssetName = $"Assets/Res/Assets/weapon/{_name}/effect/cameraeffectconfig.xml";
		_weaponLayoutAssetName = $"Assets/Res/Assets/weapon/{_name}/ui/ui_layout.xml";
		_weaponLogicAssetName = $"Assets/Res/Assets/weapon/{_name}/ui/ui_logic.xml";
	}

	public AssetInfo GetWeaponIcon_2AssetInfo(string skinName)
	{
		if (!string.IsNullOrEmpty(skinName))
		{
			return new AssetInfo(GetSkinAssetBundle(skinName), string.Format("Assets/Res/Assets/weaponskin/{0}/ui/{0}-2.png", skinName));
		}
		return new AssetInfo(AssetBundleName, _icon_2AssetName);
	}

	public AssetInfo GetWeaponIconAssetInfo(string skinName)
	{
		if (!string.IsNullOrEmpty(skinName))
		{
			return new AssetInfo(GetSkinAssetBundle(skinName), string.Format("Assets/Res/Assets/weaponskin/{0}/ui/{0}.png", skinName));
		}
		return new AssetInfo(AssetBundleName, _icon_AssetName);
	}

	public AssetInfo GetWeaponSkinJyIconAssetInfo(string skinName)
	{
		return new AssetInfo(GetSkinAssetBundle(skinName), string.Format("Assets/Res/Assets/weaponskin/{0}/ui/ui_jy_{0}.png", skinName));
	}

	public AssetInfo GetWeaponColorIconAssetInfo(string skinName)
	{
		return new AssetInfo(GetSkinAssetBundle(skinName), $"Assets/Res/Assets/weaponskin/{skinName}/ui/ui_jy_backcolor.png");
	}

	public AssetInfo GetWeaponNameIconAssetInfo(string skinName)
	{
		return new AssetInfo(GetSkinAssetBundle(skinName), $"Assets/Res/Assets/weaponskin/{skinName}/ui/ui_jy_{_name}_name.png");
	}

	public List<AssetInfo> GetUnloadUiAssetInfos()
	{
		return new List<AssetInfo>
		{
			GetWeaponIconAssetInfo(null),
			GetWeaponIcon_2AssetInfo(null),
			GetWeaponSkinJyIconAssetInfo(null),
			GetWeaponColorIconAssetInfo(null),
			GetWeaponNameIconAssetInfo(null)
		};
	}

	public List<AssetInfo> GetUnloadAudioAssetInfos()
	{
		return new List<AssetInfo>
		{
			SoundResourceUtility.GetWeaponSoundFireAssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundSecFireAssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundFire3AssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundFire4AssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundSkillAssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundSkill2AssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundRaiseAssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundRaise2AssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundChangeAssetInfo(Name),
			SoundResourceUtility.GetWeaponSoundChange2AssetInfo(Name)
		};
	}

	public List<AssetInfo> GetUnloadAssetInfos()
	{
		return new List<AssetInfo>
		{
			new AssetInfo(AssetBundleName, ViewWeaponAssetName, typeof(GameObject), optional: true),
			new AssetInfo(AssetBundleName, ThirdAssetName, typeof(GameObject), optional: true),
			new AssetInfo(AssetBundleName, SceneAssetName, typeof(GameObject)),
			new AssetInfo(AssetBundleName, ViewWeaponAnimationAssetName, typeof(SJAnimationAsset)),
			new AssetInfo(AssetBundleName, ViewHandAnimationAssetName, typeof(SJAnimationAsset)),
			new AssetInfo(AnimConfigBundleName, ViewAnimConfigAssetName, typeof(WeaponAnimAsset)),
			new AssetInfo(AssetBundleName, ThirdWeaponAnimationXmlAssetName, typeof(ThirdWeaponAnimInfo)),
			new AssetInfo(AssetBundleName, ThirdWeaponAnimationAssetName, typeof(SJAnimationAsset), optional: true),
			new AssetInfo(AssetBundleName, CameraEffectConfigAssetName, typeof(SJAnimationAsset), optional: true),
			ResourceUtility.GetKnifeAttackEffectFristRequest(Name, null),
			ResourceUtility.GetKnifeAttackEffectThirdRequest(Name, null)
		};
	}

	public string GetSkinAssetBundle(string skinName)
	{
		return "weaponskin/" + skinName;
	}
}
