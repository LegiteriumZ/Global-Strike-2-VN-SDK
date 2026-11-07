using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class InfiniteHandWeaponModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetWeaponContext
{
	private InfiniteHandWeaponViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private string _bundlecache;

	private Vector3 _originPosition;

	private FrameAnimaChip[] WeakUseChips;

	private FrameAnimaChip[] WeakReadyChips;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new InfiniteHandWeaponViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_originPosition = _viewModel.ShowPosition;
		base.DoSubscribe();
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (!string.IsNullOrEmpty(text))
		{
			SetWeaponImage(text, "bg1", _viewModel.bgImage1);
			SetWeaponImage(text, "bg2", _viewModel.bgImage2);
			SetWeaponImage(text, "bg3", _viewModel.bgImage3);
			SetWeaponImage(text, "v", _viewModel.vImgImage);
			SetWeaponImage(text, "skill1", _viewModel.SkillProgressImage1);
			SetWeaponImage(text, "skill2", _viewModel.SkillProgressImage2);
			SetWeaponImage(text, "skill3", _viewModel.SkillProgressImage3);
			SetWeaponImage(text, "select", _viewModel.SelectedImage1);
			SetWeaponImage(text, "select", _viewModel.SelectedImage2);
			SetWeaponImage(text, "select", _viewModel.SelectedImage3);
			SetWeaponImage(text, "weakuse5", _viewModel.WeakUseImage1);
			SetWeaponImage(text, "weakuse5", _viewModel.WeakUseImage2);
			SetWeaponImage(text, "weakuse5", _viewModel.WeakUseImage3);
			SetWeaponImage(text, "weakready0", _viewModel.WeakReadyImage1);
			SetWeaponImage(text, "weakready0", _viewModel.WeakReadyImage2);
			SetWeaponImage(text, "weakready0", _viewModel.WeakReadyImage3);
			SetWeaponImage(text, "weak", _viewModel.TipsImage1);
			SetWeaponImage(text, "weak", _viewModel.TipsImage2);
			SetWeaponImage(text, "weak", _viewModel.TipsImage3);
		}
		NotifyManager.MakeTempNotify(GetSelected, SetSelected, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress1, SetProgress1, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress2, SetProgress2, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetProgress3, SetProgress3, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetPosition, SetPosition, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(GetTips1, SetTips1, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(GetTips2, SetTips2, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(GetTips3, SetTips3, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(GetProgressSprite3, SetProgressSprite3, null, initinvoke: true);
	}

	private void SetPosition(Vector3 arg1, Vector3 arg2)
	{
		_viewModel.ShowPosition = arg2;
	}

	private Vector3 GetPosition()
	{
		switch (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "")
		{
		case "infinite_hand1_change_2":
		case "infinite_hand2_change_2":
		case "infinite_hand3_change_2":
			return _originPosition + new Vector3(-110f, 0f, 0f);
		default:
			return _originPosition;
		}
	}

	private void SetProgressSprite3(string arg1, string arg2)
	{
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (!string.IsNullOrEmpty(text))
		{
			SetWeaponImage(text, arg2, _viewModel.SkillProgressImage3);
		}
	}

	private string GetProgressSprite3()
	{
		if (!_gameRuleContext.currentRule.Rule.IsPve())
		{
			return "noagree";
		}
		if (GetLevel() == 0)
		{
			return "forbid";
		}
		return "skill3";
	}

	private void SetTips3(string arg1, string arg2)
	{
		if (string.IsNullOrEmpty(arg2))
		{
			_viewModel.TipsShow3 = false;
			_viewModel.WeakUseShow3 = false;
			_viewModel.WeakReadyShow3 = false;
			return;
		}
		_viewModel.TipsShow3 = true;
		_viewModel.WeakUseShow3 = arg2 == "quit";
		_viewModel.WeakReadyShow3 = arg2 == "weak";
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (!string.IsNullOrEmpty(text))
		{
			SetWeaponImage(text, arg2, _viewModel.TipsImage3);
		}
	}

	private void SetTips2(string arg1, string arg2)
	{
		if (string.IsNullOrEmpty(arg2))
		{
			_viewModel.TipsShow2 = false;
			_viewModel.WeakUseShow2 = false;
			_viewModel.WeakReadyShow2 = false;
			return;
		}
		_viewModel.TipsShow2 = true;
		_viewModel.WeakUseShow2 = arg2 == "quit";
		_viewModel.WeakReadyShow2 = arg2 == "weak";
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (!string.IsNullOrEmpty(text))
		{
			SetWeaponImage(text, arg2, _viewModel.TipsImage2);
		}
	}

	private void SetTips1(string arg1, string arg2)
	{
		if (string.IsNullOrEmpty(arg2))
		{
			_viewModel.TipsShow1 = false;
			_viewModel.WeakUseShow1 = false;
			_viewModel.WeakReadyShow1 = false;
			return;
		}
		_viewModel.TipsShow1 = true;
		_viewModel.WeakUseShow1 = arg2 == "quit";
		_viewModel.WeakReadyShow1 = arg2 == "weak";
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (!string.IsNullOrEmpty(text))
		{
			SetWeaponImage(text, arg2, _viewModel.TipsImage1);
		}
	}

	private string GetTips1()
	{
		if (GetSelected() != 1)
		{
			return string.Empty;
		}
		return GetTips();
	}

	private string GetTips2()
	{
		if (GetSelected() != 2)
		{
			return string.Empty;
		}
		return GetTips();
	}

	private string GetTips3()
	{
		if (GetSelected() != 3)
		{
			return string.Empty;
		}
		return GetTips();
	}

	private string GetTips()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity.basicInfo.Data.SpecialMode)
		{
			return "quit";
		}
		if (GetNextSkillRemainTime(currentWeaponEntity) <= 0 && GetProgress() >= 1f)
		{
			return "weak";
		}
		return string.Empty;
	}

	private void SetProgress3(float arg1, float arg2)
	{
		_viewModel.SkillProgressFillamount3 = arg2;
	}

	private void SetProgress2(float arg1, float arg2)
	{
		_viewModel.SkillProgressFillamount2 = arg2;
	}

	private void SetProgress1(float arg1, float arg2)
	{
		_viewModel.SkillProgressFillamount1 = arg2;
	}

	private float GetProgress3()
	{
		if (!_gameRuleContext.currentRule.Rule.IsPve())
		{
			return 1f;
		}
		if (GetLevel() == 0)
		{
			return 1f;
		}
		if (GetSelected() != 3)
		{
			return 0f;
		}
		return GetProgress();
	}

	private float GetProgress2()
	{
		if (GetSelected() != 2)
		{
			return 0f;
		}
		return GetProgress();
	}

	private float GetProgress1()
	{
		if (GetSelected() != 1)
		{
			return 0f;
		}
		return GetProgress();
	}

	private float GetProgress()
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity.basicInfo.Data.SpecialMode)
		{
			return 1f;
		}
		TdSkillStateDataComponent tdSkillStateData = _gameRuleContext.tdSkillStateData;
		if (_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.RpgMaxPower <= 0)
			{
				return 0f;
			}
			return (float)tdSkillStateData.CurrentMp / (float)currentWeaponEntity.power.RpgMaxPower;
		}
		if (_gameRuleContext.currentRule.Rule.IsPve())
		{
			if (!currentWeaponEntity.hasPower || currentWeaponEntity.power.RpgMaxPower <= 0)
			{
				return 0f;
			}
			return (float)currentWeaponEntity.power.Power / (float)currentWeaponEntity.power.RpgMaxPower;
		}
		switch (currentWeaponEntity.basicInfo.Data.WeaponName)
		{
		case "infinite_hand1":
		case "infinite_hand1_change_1":
		case "infinite_hand2_change_1":
		case "infinite_hand3_change_1":
			return 0f;
		default:
			if (_timeComponent == null)
			{
				return 0f;
			}
			return 1f - (float)GetNextSkillRemainTime(currentWeaponEntity) / 10000f;
		}
	}

	private long GetNextSkillRemainTime(WeaponEntity weapon)
	{
		return weapon.basicInfo.Data.NextSkillTimer - _timeComponent.ClientRealTime;
	}

	private void SetSelected(int arg1, int arg2)
	{
		_viewModel.SetSelectedShow(1, arg2 == 1);
		_viewModel.SetSelectedShow(2, arg2 == 2);
		_viewModel.SetSelectedShow(3, arg2 == 3);
	}

	private int GetSelected()
	{
		string text = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		int result = 0;
		switch (text)
		{
		case "infinite_hand1":
		case "infinite_hand2":
		case "infinite_hand3":
			result = 1;
			break;
		case "infinite_hand1_change_1":
		case "infinite_hand2_change_1":
		case "infinite_hand3_change_1":
			result = 2;
			break;
		case "infinite_hand1_change_2":
		case "infinite_hand2_change_2":
		case "infinite_hand3_change_2":
			result = 3;
			break;
		}
		return result;
	}

	private int GetLevel()
	{
		switch (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "")
		{
		case "infinite_hand1":
		case "infinite_hand1_change_1":
		case "infinite_hand1_change_2":
			return 0;
		case "infinite_hand2":
		case "infinite_hand2_change_1":
		case "infinite_hand2_change_2":
			return 1;
		case "infinite_hand3":
		case "infinite_hand3_change_1":
		case "infinite_hand3_change_2":
			return 2;
		default:
			return 0;
		}
	}

	private void InitChips()
	{
		WeakUseChips = new FrameAnimaChip[3];
		WeakReadyChips = new FrameAnimaChip[3];
		string arg = (_weaponContext.isCurrentWeapon ? _weaponContext.currentWeaponEntity.basicInfo.Data.WeaponName : "");
		string path = $"Assets/Res/Assets/weapon/{arg}/ui/weakuse";
		_bundlecache = $"weapon/{arg}";
		for (int i = 0; i < 3; i++)
		{
			WeakUseChips[i] = new FrameAnimaChip
			{
				Path = path,
				Delay = 80,
				StartIndex = 0,
				Count = 12,
				IsLoop = true
			};
			WeakUseChips[i].Init();
		}
		for (int j = 0; j < 3; j++)
		{
			WeakReadyChips[j] = new FrameAnimaChip
			{
				Path = path,
				Delay = 80,
				StartIndex = 0,
				Count = 12,
				IsLoop = true
			};
		}
	}

	private void UpdateChips()
	{
		for (int j = 0; j < 3; j++)
		{
			if (_viewModel.GetWeakUseShow(j + 1))
			{
				WeakUseChips[j].Update(_timeComponent);
				if (WeakUseChips[j].Changed)
				{
					int i1 = j;
					base.Loader.RetriveSprite(_bundlecache, WeakUseChips[j].Value, delegate(Sprite sprite)
					{
						_viewModel.SetWeakUseSprite(i1 + 1, sprite);
					});
				}
			}
			if (!_viewModel.GetWeakReadyShow(j + 1))
			{
				continue;
			}
			WeakReadyChips[j].Update(_timeComponent);
			if (WeakReadyChips[j].Changed)
			{
				int i2 = j;
				base.Loader.RetriveSprite(_bundlecache, WeakReadyChips[j].Value, delegate(Sprite sprite)
				{
					_viewModel.SetWeakReadySprite(i2 + 1, sprite);
				});
			}
		}
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
