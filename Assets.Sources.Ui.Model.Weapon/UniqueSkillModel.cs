using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.GameRule.Weapon;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Weapon;

[GameUiTest]
public class UniqueSkillModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetWeaponContext
{
	private UniqueSkillViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private GuoShiWuShuangIconComponent _guoShiWuShuang;

	private int[] _types = new int[8] { 2, 4, 8, 16, 512, 1024, 2048, 4096 };

	private int _startIndex;

	private WeaponContext _weaponContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
		_guoShiWuShuang = _gameRuleContext.guoShiWuShuangIcon;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new UniqueSkillViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel == null || !_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		for (int i = 0; i < _types.Length; i++)
		{
			if (_guoShiWuShuang.Buffs.ContainsKey(_types[i]))
			{
				_guoShiWuShuang.Buffs[_types[i]][1] -= _timeComponent.FrameInterval;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(GetWeaponName, SetWeaponName);
		for (int i = 0; i < 4; i++)
		{
			SimpleNotify.Add(GetBuffType, SetBuffType, i);
			SimpleNotify.Add(GetBuffPercent, SetBuffPercent, i);
		}
	}

	private void SetBuffPercent(float arg1, int arg2)
	{
		_viewModel.SetLightFillamount(arg2 + 1, arg1);
	}

	private float GetBuffPercent(int arg1)
	{
		if (_guoShiWuShuang.Buffs.ContainsKey(_types[_startIndex + arg1]))
		{
			int num = _guoShiWuShuang.Buffs[_types[_startIndex + arg1]][0];
			if (num > 0)
			{
				return (float)_guoShiWuShuang.Buffs[_types[_startIndex + arg1]][1] / (float)num;
			}
		}
		return 0f;
	}

	private void SetBuffType(ComboValue<string, int> arg1, int arg2)
	{
		if (string.IsNullOrEmpty(arg1.Value0))
		{
			return;
		}
		if (arg1.Value1 > 0)
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1.Value0), UiAssetBundleUtils.GetWeaponTexturePath(arg1.Value0, "buffBg_1"), delegate(Sprite sprite)
			{
				_viewModel.SetBuffSprite(arg2 + 1, sprite);
			});
		}
		else if (arg1.Value1 == -1)
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1.Value0), UiAssetBundleUtils.GetWeaponTexturePath(arg1.Value0, "buffBg_2"), delegate(Sprite sprite)
			{
				_viewModel.SetBuffSprite(arg2 + 1, sprite);
			});
		}
		else
		{
			base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1.Value0), UiAssetBundleUtils.GetWeaponTexturePath(arg1.Value0, "buffBg_3"), delegate(Sprite sprite)
			{
				_viewModel.SetBuffSprite(arg2 + 1, sprite);
			});
		}
	}

	private ComboValue<string, int> GetBuffType(int arg1)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		string value = ((currentWeaponEntity != null) ? currentWeaponEntity.basicInfo.Data.WeaponName : "");
		if (_guoShiWuShuang.Buffs.ContainsKey(_types[_startIndex + arg1]))
		{
			return new ComboValue<string, int>(value, _guoShiWuShuang.Buffs[_types[_startIndex + arg1]][0]);
		}
		return new ComboValue<string, int>(value, -1);
	}

	private void SetWeaponName(string arg1, int arg2)
	{
		if (string.IsNullOrEmpty(arg1))
		{
			return;
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1), UiAssetBundleUtils.GetWeaponTexturePath(arg1, "buffWord_1"), delegate(Sprite sprite)
		{
			_viewModel.WordSprite1 = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1), UiAssetBundleUtils.GetWeaponTexturePath(arg1, "buffWord_2"), delegate(Sprite sprite)
		{
			_viewModel.WordSprite2 = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1), UiAssetBundleUtils.GetWeaponTexturePath(arg1, "buffWord_3"), delegate(Sprite sprite)
		{
			_viewModel.WordSprite3 = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1), UiAssetBundleUtils.GetWeaponTexturePath(arg1, "buffWord_4"), delegate(Sprite sprite)
		{
			_viewModel.WordSprite4 = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(arg1), UiAssetBundleUtils.GetWeaponTexturePath(arg1, "buffLight"), delegate(Sprite sprite)
		{
			for (int i = 0; i < 4; i++)
			{
				_viewModel.SetLightSprite(i + 1, sprite);
			}
		});
		_startIndex = ((arg1 == "g18_unique") ? 4 : 0);
	}

	private string GetWeaponName(int arg1)
	{
		WeaponEntity currentWeaponEntity = _weaponContext.currentWeaponEntity;
		if (currentWeaponEntity != null)
		{
			return currentWeaponEntity.basicInfo.Data.WeaponName;
		}
		return "";
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}
}
