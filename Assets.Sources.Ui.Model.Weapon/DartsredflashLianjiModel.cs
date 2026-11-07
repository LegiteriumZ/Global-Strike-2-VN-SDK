using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

public class DartsredflashLianjiModel : AbstractModel, IPlaybackSystem, ISetWeaponContext
{
	private DartsredflashLianjiViewModel _viewModel;

	private int _showTime;

	private int _lastLevel;

	private int _power;

	private FrameAnimaChip _effectFrameAnimaChip = new FrameAnimaChip();

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new DartsredflashLianjiViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (!_viewModel.ShowShow)
		{
			return;
		}
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity == null)
		{
			return;
		}
		_showTime -= _timeComponent.FrameInterval;
		int level = currentWeaponEntity.basicInfo.Data.Level;
		int num = (currentWeaponEntity.hasPower ? currentWeaponEntity.power.MaxPower2 : 0);
		if (level > 0 || _showTime > 0)
		{
			_power += _timeComponent.FrameInterval;
			_viewModel.ProgessFillamount = ((num > 0) ? ((float)_power / (float)num) : 0f);
			if (_power > num + 100 && level < 20 && _lastLevel < 20 && num > 0)
			{
				_viewModel.FailShow = true;
				_viewModel.SuccessShow = false;
			}
			else
			{
				_viewModel.FailShow = false;
				_viewModel.SuccessShow = true;
			}
			_viewModel.ShowHere = true;
			if (_lastLevel != level)
			{
				_showTime = 1000;
				if (level > 0)
				{
					_viewModel.NumberString = level.ToString();
					_power = 0;
					if (!_viewModel.EffectShow)
					{
						_viewModel.EffectShow = true;
						_effectFrameAnimaChip.Index = 0;
					}
					for (int i = 0; i < 20; i++)
					{
						_viewModel.SetCountShow(i + 1, i < level);
					}
				}
			}
			_lastLevel = level;
			float num2 = ((_showTime > 700) ? ((float)(_showTime - 700) / 300f) : 0f);
			num2 = num2 * 0.5f + 1f;
			_viewModel.NumberScale = new Vector3(num2, num2, num2);
			if (!_viewModel.EffectShow)
			{
				return;
			}
			_effectFrameAnimaChip.Update(_timeComponent);
			if (_effectFrameAnimaChip.Changed)
			{
				base.Loader.RetriveSprite("weapon/" + currentWeaponEntity.basicInfo.Data.WeaponName, _effectFrameAnimaChip.Value, delegate(Sprite v)
				{
					_viewModel.EffectSprite = v;
				});
			}
			else if (_effectFrameAnimaChip.IsOver)
			{
				_viewModel.EffectShow = false;
			}
		}
		else
		{
			_lastLevel = 0;
			_viewModel.ShowHere = false;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
	}

	private void SetWeaponName(string arg1, string weaponName)
	{
		if (string.IsNullOrEmpty(weaponName))
		{
			return;
		}
		_effectFrameAnimaChip.Path = "Assets/Res/Assets/weapon/" + weaponName + "/ui/doubleHitSuccess";
		_effectFrameAnimaChip.Delay = 100;
		_effectFrameAnimaChip.Count = 6;
		_effectFrameAnimaChip.StartIndex = 0;
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "doubleHitProgressback"), delegate(Sprite sprite)
		{
			_viewModel.ProgessBackSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "doubleHitProgress"), delegate(Sprite sprite)
		{
			_viewModel.ProgessSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "doubleHitFail"), delegate(Sprite sprite)
		{
			_viewModel.FailSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "doubleHitSuccess"), delegate(Sprite sprite)
		{
			_viewModel.SuccessSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "doubleHitCountBack"), delegate(Sprite sprite)
		{
			for (int j = 0; j < 20; j++)
			{
				_viewModel.SetCountItemSprite(j + 1, sprite);
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(weaponName), UiAssetBundleUtils.GetWeaponTexturePath(weaponName, "doubleHitCount"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 20; i++)
			{
				_viewModel.SetCountSprite(i + 1, sprite);
			}
		});
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		_effectFrameAnimaChip.Update(_timeComponent);
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
