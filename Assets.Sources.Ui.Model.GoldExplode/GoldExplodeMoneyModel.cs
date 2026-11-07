using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GoldExplode;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GoldExplode;

public class GoldExplodeMoneyModel : AbstractModel, IPlaybackSystem
{
	private GoldexplodemoneyViewModel _viewModel;

	private int _lastMoney;

	private int _lastCid;

	private int _addIndex;

	private int _loseIndex;

	private bool _updateMoney;

	private AlphaChip[] _addMoneyAlphaChips = new AlphaChip[3]
	{
		new AlphaChip(),
		new AlphaChip(),
		new AlphaChip()
	};

	private PositionChip[] _addMoneyPositonChips = new PositionChip[3]
	{
		new PositionChip(),
		new PositionChip(),
		new PositionChip()
	};

	private AlphaChip[] _loseMoneyAlphaChips = new AlphaChip[3]
	{
		new AlphaChip(),
		new AlphaChip(),
		new AlphaChip()
	};

	private PositionChip[] _loseMoneyPositionChips = new PositionChip[3]
	{
		new PositionChip(),
		new PositionChip(),
		new PositionChip()
	};

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GoldexplodemoneyViewModel();
	}

	protected override void DoSubscribe()
	{
		for (int i = 0; i < 3; i++)
		{
			_viewModel.SetAddTextShow(i + 1, value: false);
			_viewModel.SetLoseTextShow(i + 1, value: false);
		}
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_PlayerId, SetPlayerId, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Money, SetMoney, null, initinvoke: true);
	}

	private void SetMoney(int arg1, int arg2)
	{
		_updateMoney = true;
	}

	private void SetPlayerId(int arg1, int arg2)
	{
		_updateMoney = true;
	}

	private void UpdateMoney()
	{
		int cameraOwnerData_Money = UiIEventCondition.Get_cameraOwnerData_Money();
		int cameraOwnerData_PlayerId = UiIEventCondition.Get_cameraOwnerData_PlayerId();
		if (_lastMoney != cameraOwnerData_Money && _lastCid == cameraOwnerData_PlayerId)
		{
			_viewModel.MoneyTextString = cameraOwnerData_Money.ToString();
			if (cameraOwnerData_Money > _lastMoney)
			{
				_viewModel.SetAddTextString(_addIndex + 1, (cameraOwnerData_Money - _lastMoney).ToString());
				_viewModel.SetAddTextShow(_addIndex + 1, value: true);
				_addMoneyPositonChips[_addIndex].Position = new Vector3(6f, 10f);
				_addMoneyAlphaChips[_addIndex].Alpha = 1f;
				_addMoneyAlphaChips[_addIndex].Delay = 1000f;
				_addIndex++;
				if (_addIndex >= 3)
				{
					_addIndex = 0;
				}
			}
			else if (cameraOwnerData_Money < _lastMoney)
			{
				_viewModel.SetLoseTextString(_loseIndex + 1, (_lastMoney - cameraOwnerData_Money).ToString());
				_viewModel.SetLoseTextShow(_loseIndex + 1, value: true);
				_loseMoneyPositionChips[_loseIndex].Position = new Vector3(6f, 10f);
				_loseMoneyAlphaChips[_loseIndex].Alpha = 1f;
				_loseMoneyAlphaChips[_loseIndex].Delay = 1000f;
				_loseIndex++;
				if (_loseIndex >= 3)
				{
					_loseIndex = 0;
				}
			}
		}
		else
		{
			_viewModel.MoneyTextString = cameraOwnerData_Money.ToString();
		}
		_lastMoney = cameraOwnerData_Money;
		_lastCid = cameraOwnerData_PlayerId;
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_updateMoney)
			{
				_updateMoney = false;
				UpdateMoney();
			}
		}
	}

	private void InitChips()
	{
		for (int i = 0; i < 3; i++)
		{
			_addMoneyAlphaChips[i].Alpha = (_loseMoneyAlphaChips[i].Alpha = 1f);
			_addMoneyAlphaChips[i].Delay = (_loseMoneyAlphaChips[i].Delay = 1000f);
			_addMoneyAlphaChips[i].Speed = (_loseMoneyAlphaChips[i].Speed = -2f);
			_addMoneyPositonChips[i].Position = (_loseMoneyPositionChips[i].Position = new Vector3(6f, 10f));
			_addMoneyPositonChips[i].TargetPosition = (_loseMoneyPositionChips[i].TargetPosition = new Vector3(6f, 80f));
			_addMoneyPositonChips[i].Speed = (_loseMoneyPositionChips[i].Speed = new Vector3(0f, 70f));
		}
	}

	private void UpdateChips()
	{
		for (int i = 0; i < 3; i++)
		{
			_viewModel.SetAddTextAlpha(i + 1, _addMoneyAlphaChips[i].Update(_timeComponent));
			_viewModel.SetAddTextPosition(i + 1, _addMoneyPositonChips[i].Update(_timeComponent));
			_viewModel.SetLoseTextAlpha(i + 1, _loseMoneyAlphaChips[i].Update(_timeComponent));
			_viewModel.SetLoseTextPosition(i + 1, _loseMoneyPositionChips[i].Update(_timeComponent));
		}
	}
}
