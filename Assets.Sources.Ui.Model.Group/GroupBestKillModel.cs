using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Group;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Group;

internal class GroupBestKillModel : AbstractModel, IPlaybackSystem
{
	private GroupBestKillViewModel _viewModel;

	private const int ShowTime = 10000;

	private string _suffix = "...";

	private int _suffixLength;

	private Text _text;

	private ActiveChip _showActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		_text = _viewModel.AceNameObj.GetComponent<Text>();
		_suffixLength = TextUtils.CalculateLengthOfText(_suffix, _text);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_bestKillData_GroupBestData, SetGroupBestData, null, initinvoke: true);
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GroupBestKillViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	private void SetGroupBestData(GroupBestKillData ov, GroupBestKillData bestKillData)
	{
		if (UiIEventCondition.Get_uiRoomData_IsObserver())
		{
			return;
		}
		if (bestKillData == null)
		{
			_showActiveChip.Time = 0;
			return;
		}
		_showActiveChip.Time = 10000;
		_viewModel.AceShow = bestKillData.Ace1Specified;
		if (bestKillData.Ace1Specified)
		{
			_viewModel.AceNameString = StripLengthWithSuffix(bestKillData.Ace1);
			_viewModel.AceNumString = bestKillData.AceNum1.ToString();
		}
		_viewModel.SecondShow = bestKillData.Ace2Specified;
		if (bestKillData.Ace2Specified)
		{
			_viewModel.SecondNameString = StripLengthWithSuffix(bestKillData.Ace2);
			_viewModel.SecondNumString = bestKillData.AceNum2.ToString();
		}
		_viewModel.ThirdShow = bestKillData.Ace3Specified;
		if (bestKillData.Ace3Specified)
		{
			_viewModel.ThirdNameString = StripLengthWithSuffix(bestKillData.Ace3);
			_viewModel.ThirdNumString = bestKillData.AceNum3.ToString();
		}
		_viewModel.MVPShow = bestKillData.BestKillSpecified;
		if (bestKillData.BestKillSpecified)
		{
			_viewModel.MvpNameString = StripLengthWithSuffix(bestKillData.BestKill);
			_viewModel.MvpNumString = bestKillData.BestNum.ToString();
		}
	}

	private string StripLengthWithSuffix(string name)
	{
		return TextUtils.StripLengthWithSuffix(name, _text, _suffix, _suffixLength, (int)_text.rectTransform.sizeDelta.x);
	}

	private void InitChips()
	{
		_showActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.ShowShow = _showActiveChip.Update(_timeComponent);
	}
}
