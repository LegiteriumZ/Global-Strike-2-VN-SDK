using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class SniperGuardianBulletModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private SniperGuardianBulletViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private string _urlInfoSuffix = "Assets/Res/Assets/weapon/sniper_guardian/ui/";

	private Sprite[] _sprites;

	private bool _isUse;

	private int _alphaTime = 1500;

	private int _clearTime = 1000;

	private int _showNumber;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		_isUse = RuleUtilty.IsPveModel(raceType) || RuleUtilty.IsBigHeadModel(raceType) || RuleUtilty.IsBioMode(raceType);
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		_sprites = new Sprite[4];
		base.Loader.RetriveSprite("weapon/sniper_guardian", _urlInfoSuffix + "skill1.png", delegate(Sprite sprite)
		{
			_sprites[0] = sprite;
		});
		base.Loader.RetriveSprite("weapon/sniper_guardian", _urlInfoSuffix + "skillBg1.png", delegate(Sprite sprite)
		{
			_sprites[1] = sprite;
		});
		base.Loader.RetriveSprite("weapon/sniper_guardian", _urlInfoSuffix + "skill2.png", delegate(Sprite sprite)
		{
			_sprites[2] = sprite;
		});
		base.Loader.RetriveSprite("weapon/sniper_guardian", _urlInfoSuffix + "skillBg2.png", delegate(Sprite sprite)
		{
			_sprites[3] = sprite;
		});
	}

	public override void CreateViewModel()
	{
		_viewModel = new SniperGuardianBulletViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited || !_isUse)
		{
			return;
		}
		for (int i = 0; i < 5; i++)
		{
			if (i == 4)
			{
				if (GetBulletNumber() == 5)
				{
					_viewModel.SetBulletSprite(i + 1, _sprites[2]);
				}
				else
				{
					_viewModel.SetBulletSprite(i + 1, _sprites[3]);
				}
			}
			else if (i < GetBulletNumber())
			{
				_viewModel.SetBulletSprite(i + 1, _sprites[GetSkill()]);
			}
			else
			{
				_viewModel.SetBulletSprite(i + 1, _sprites[GetSkillBg()]);
			}
		}
		UpdateVisiableAndAlpha();
	}

	private void UpdateVisiableAndAlpha()
	{
		if (IsShowNumber())
		{
			_clearTime = 2000;
			_alphaTime = 0;
			for (int i = 0; i < 5; i++)
			{
				_viewModel.SetBulletColor(i + 1, new Color(1f, 1f, 1f, 1f));
				_viewModel.SetBulletShow(i + 1, value: true);
			}
			return;
		}
		if (_clearTime > 0)
		{
			_clearTime -= _timeComponent.FrameInterval;
			if (_clearTime < 0)
			{
				_alphaTime = 1500;
			}
		}
		if (_alphaTime <= 0)
		{
			return;
		}
		_alphaTime -= _timeComponent.FrameInterval;
		for (int j = 0; j < 5; j++)
		{
			_viewModel.SetBulletColor(j + 1, new Color(1f, 1f, 1f, (float)_alphaTime / 1500f));
		}
		if (_alphaTime < 0)
		{
			for (int k = 0; k < 5; k++)
			{
				_viewModel.SetBulletShow(k + 1, value: false);
			}
		}
	}

	private int GetBulletNumber()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower)
		{
			return currentWeaponEntity.power.Power2;
		}
		return 0;
	}

	private bool IsShowNumber()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasPower && _showNumber != currentWeaponEntity.power.Power2)
		{
			_showNumber = currentWeaponEntity.power.Power2;
			return true;
		}
		return false;
	}

	private int GetSkillBg()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasClip && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.clip.Clip2 != 0 && currentWeaponEntity.clip.Clip2 == currentWeaponEntity.basicInfo.Data.WeaponTimer1)
		{
			return 3;
		}
		return 1;
	}

	private int GetSkill()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasClip && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.clip.Clip2 != 0 && currentWeaponEntity.clip.Clip2 == currentWeaponEntity.basicInfo.Data.WeaponTimer1)
		{
			return 2;
		}
		return 0;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		if (_isUse)
		{
			NotifyManager.MakeTempNotify(GetVisiable, SetVisiable, null, initinvoke: true);
		}
	}

	private bool GetVisiable()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasSpecial && (currentWeaponEntity.special.EffectLevel & 4) > 0)
		{
			return true;
		}
		return false;
	}

	private void SetVisiable(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
