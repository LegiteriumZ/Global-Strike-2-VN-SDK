using Assets.Sources.Framework;
using Assets.Sources.Info.SkillProgress;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Weapon;

public class SkillProgressModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetWeaponContext, ISetPlayerContext
{
	private SkillprogressViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private WeaponContext _weaponContext;

	private WeaponEntity _weaponEntity;

	private ISkillProgressInfo _currentInfo;

	private Vector3 _originBottomPos;

	private bool _inSpecial;

	private int _level;

	private int _specialStart;

	private float _rate;

	private int _raceType;

	private string _currentWeaponName = "";

	private string[] _backImage = new string[2] { "", "" };

	private string[] _iconImage = new string[2] { "", "" };

	private string[] _progressImage = new string[2] { "", "" };

	private readonly string[] backImage = new string[2] { "", "" };

	private readonly string[] _iconName = new string[2] { "", "" };

	private HorizontalLayoutGroup _group;

	private readonly AlphaChip _iconImageAlphaChip = new AlphaChip();

	private readonly FrameAnimaChip _effectImageFrameAnimaChip = new FrameAnimaChip();

	private readonly ScaleChip _iconImageScaleChip = new ScaleChip();

	private readonly RotationChip _effectImageRotationChip = new RotationChip();

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		_raceType = context.roomData.Data.RaceType;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new SkillprogressViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (_currentInfo == null || currentWeaponEntity == null)
		{
			return;
		}
		if (_viewModel.RightBottomShow)
		{
			if (_viewModel.IconImageShow || _viewModel.EffectImageShow)
			{
				UpdateChips();
			}
			SetProgress(currentWeaponEntity);
			SetUi(currentWeaponEntity);
		}
		int num = _currentInfo.Visiable.Visiable(_weaponContext, _playerContext.myPlayerEntity, _currentInfo.Config, _timeComponent, _raceType);
		if (num > -1)
		{
			_viewModel.RightBottomShow = num != 0;
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.RightBottomShow = false;
		_originBottomPos = _viewModel.RightBottomPosition;
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		_currentInfo = null;
		if (!string.IsNullOrEmpty(weaponName))
		{
			_weaponEntity = _weaponContext.currentWeaponEntity;
			_currentWeaponName = weaponName;
			_currentInfo = BattleSingletonInstance<SkillProgressFactory>.Instance.GetInfo(_currentWeaponName, _battleRoomContext.roomDataEntity);
			_viewModel.RightBottomShow = _currentInfo != null;
			if (_currentInfo != null)
			{
				if (_currentInfo.Config.FillMethod == Image.FillMethod.Radial360)
				{
					_viewModel.RightBottomPosition = _originBottomPos + new Vector3(50f, 0f);
				}
				else
				{
					_viewModel.RightBottomPosition = _originBottomPos;
				}
				int num = _currentInfo.Visiable.Visiable(_weaponContext, _playerContext.myPlayerEntity, _currentInfo.Config, _timeComponent, _raceType);
				if (num > -1)
				{
					_viewModel.RightBottomShow = num != 0;
				}
			}
		}
		else
		{
			_viewModel.RightBottomShow = false;
		}
	}

	private void SetProgress(WeaponEntity currentWeapon)
	{
		_rate = Progress(currentWeapon, _raceType);
		if (_currentInfo.Config.ProgressCount > 0)
		{
			for (int i = 0; i < 10; i++)
			{
				_viewModel.SetProgressItemShow(i + 1, i < _level && i < _currentInfo.Config.ProgressCount);
			}
		}
		else
		{
			_viewModel.ProgressImageFillamount = (1f - _currentInfo.Config.Total) * 0.5f + _rate * _currentInfo.Config.Total;
			for (int j = 0; j < 10; j++)
			{
				_viewModel.SetProgressItemShow(j + 1, value: false);
			}
		}
		_viewModel.ProgressImageShow = _currentInfo.ProgressVisiable.IsProgressVisiable(currentWeapon, _currentInfo.Config, _timeComponent, _raceType, ref _inSpecial, ref _specialStart);
	}

	private void SetUi(WeaponEntity currentWeapon)
	{
		if (!string.IsNullOrEmpty(_currentInfo.Config.Progress) && (_progressImage[0] != _currentWeaponName || _progressImage[1] != _currentInfo.Config.Progress))
		{
			string weaponTexturePath = UiAssetBundleUtils.GetWeaponTexturePath(_currentWeaponName, _currentInfo.Config.Progress);
			_viewModel.ProgressImageShow = true;
			_progressImage[0] = _currentWeaponName;
			_progressImage[1] = _currentInfo.Config.Progress;
			if (_currentInfo.Config.ProgressCount > 0)
			{
				_viewModel.ProgressImageSprite = UiResourcesLoader.DefaultSprite;
				if (_group == null)
				{
					_group = _viewModel.GridObj.GetComponent<HorizontalLayoutGroup>();
				}
				_group.spacing = _currentInfo.Config.ProgressSpace;
				_viewModel.GridPosition = _currentInfo.Config.ProgressPos;
				_viewModel.GridRotation = Quaternion.Euler(Vector3.zero);
				for (int i = 0; i < _currentInfo.Config.ProgressCount; i++)
				{
					base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_currentWeaponName), weaponTexturePath, _viewModel.GetProgressItemImage(i + 1), autosetnative: true, autodefault: true);
				}
			}
			else
			{
				for (int j = 0; j < 10; j++)
				{
					_viewModel.SetProgressItemSprite(j + 1, UiResourcesLoader.DefaultSprite);
				}
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_currentWeaponName), weaponTexturePath, _viewModel.ProgressImageImage, autosetnative: true, autodefault: true);
				_viewModel.ProgressImageFillmethod = _currentInfo.Config.FillMethod;
				_viewModel.ProgressImageClockwise = _currentInfo.Config.FillClockwise;
				_viewModel.ProgressImageFillorigin = (int)_currentInfo.Config.FillOrigin;
				_viewModel.ProgressImagePosition = _currentInfo.Config.ProgressPos;
				_viewModel.ProgressImageRotation = _currentInfo.Config.ProgressRot;
			}
		}
		else if (string.IsNullOrEmpty(_currentInfo.Config.Progress))
		{
			_progressImage[0] = "";
			_progressImage[1] = "";
			_viewModel.ProgressImageShow = false;
			for (int k = 0; k < 10; k++)
			{
				_viewModel.SetProgressItemSprite(k + 1, UiResourcesLoader.DefaultSprite);
			}
		}
		backImage[0] = (backImage[1] = (_iconName[0] = (_iconName[1] = "")));
		bool num = _currentInfo.CanUse.CanUse(currentWeapon, _currentInfo.Config, _timeComponent, _rate, _level);
		bool flag = _currentInfo.Cd.CdOver(currentWeapon, _timeComponent, _raceType);
		bool special = _currentInfo.Special.GetSpecial(currentWeapon);
		if (num && flag)
		{
			_currentInfo.Special.GetBackImage(backImage, _currentInfo.Config, currentWeapon, special, _raceType, _level, isOver: true);
			_currentInfo.Special.GetIcon(_iconName, _currentInfo.Config, currentWeapon, special, _level, isOver: true);
			_currentInfo.Effect.Effect(base.Loader, _currentInfo.Config, _inSpecial, _viewModel, _iconImageAlphaChip, _effectImageFrameAnimaChip, _iconImageScaleChip, _effectImageRotationChip);
		}
		else
		{
			_currentInfo.Special.GetBackImage(backImage, _currentInfo.Config, currentWeapon, special, _raceType, _level, isOver: false);
			_currentInfo.Special.GetIcon(_iconName, _currentInfo.Config, currentWeapon, special, _level, isOver: false);
			_viewModel.EffectImageShow = false;
		}
		if (_backImage[0] != backImage[0] || _backImage[1] != backImage[1])
		{
			string image2 = (_backImage[0] = backImage[0]);
			string image4 = (_backImage[1] = backImage[1]);
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_currentWeaponName), UiAssetBundleUtils.GetWeaponTexturePath(backImage[0], backImage[1]), delegate(Sprite sprite)
			{
				if (image2 == _backImage[0] && image4 == _backImage[1])
				{
					_viewModel.BackImageSprite = sprite;
					_viewModel.BackImageNtvsize();
				}
			});
		}
		if (!string.IsNullOrEmpty(_iconName[1]))
		{
			if (_iconImage[0] != _iconName[0] || _iconImage[1] != _iconName[1])
			{
				string image1 = (_iconImage[0] = _iconName[0]);
				string image3 = (_iconImage[1] = _iconName[1]);
				base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_currentWeaponName), UiAssetBundleUtils.GetWeaponTexturePath(_iconName[0], _iconName[1]), delegate(Sprite sprite)
				{
					if (image1 == _iconImage[0] && image3 == _iconImage[1])
					{
						_viewModel.IconImageSprite = sprite;
						_viewModel.IconImageNtvsize();
						if (_currentInfo != null && _currentInfo.Config != null)
						{
							_viewModel.IconImagePosition = _currentInfo.Config.IconPos;
						}
					}
				});
			}
			_viewModel.IconImageShow = true;
		}
		else
		{
			_viewModel.IconImageShow = false;
		}
	}

	public float Progress(WeaponEntity currentWeapon, int rule)
	{
		float num = _currentInfo.Progress.GetProgress(currentWeapon, _currentInfo.Config, _timeComponent, rule, ref _inSpecial, ref _specialStart);
		if (Mathf.Approximately(num, 0f))
		{
			_level = 0;
			return 0f;
		}
		if (_inSpecial)
		{
			_level = _currentInfo.Config.MaxLevel;
		}
		else
		{
			_level = 0;
			for (float num2 = num; num2 >= 1f; num2 -= 1f)
			{
				_level++;
			}
		}
		int num3 = 0;
		while (num > 1f)
		{
			num3++;
			if (num3 >= _currentInfo.Config.MaxLevel)
			{
				num = 1f;
				break;
			}
			num -= 1f;
		}
		return num;
	}

	private void InitChips()
	{
		_iconImageAlphaChip.Alpha = 1f;
		_iconImageAlphaChip.Speed = 0f;
		_iconImageScaleChip.Scale = new Vector3(1f, 1f, 1f);
		_iconImageScaleChip.TargetScale = new Vector3(1f, 1f, 1f);
		_iconImageScaleChip.Speed = new Vector3(0f, 0f, 0f);
		_effectImageRotationChip.Rotation = new Vector3(0f, 0f, 0f);
		_effectImageRotationChip.TargetRotation = new Vector3(0f, 0f, 360f);
		_effectImageRotationChip.Speed = new Vector3(0f, 0f, 0f);
		_effectImageRotationChip.Loop = true;
	}

	private void UpdateChips()
	{
		_viewModel.IconImageAlpha = _iconImageAlphaChip.Update(_timeComponent);
		_effectImageFrameAnimaChip.Update(_timeComponent);
		_viewModel.IconImageScale = _iconImageScaleChip.Update(_timeComponent);
		_viewModel.EffectImageRotation = _effectImageRotationChip.Update(_timeComponent);
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
