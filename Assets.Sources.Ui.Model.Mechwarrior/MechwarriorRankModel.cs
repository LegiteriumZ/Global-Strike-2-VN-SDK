using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Mechwarrior;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Mechwarrior;

public class MechwarriorRankModel : AbstractModel, IPlaybackSystem
{
	private MechwarriorRankViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MechwarriorRankViewModel();
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
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(20, UiIEventCondition.Get_mechwarrionRankDate_NameList, SetNameList, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Observer, SetCameraOwnerObserver, null, initinvoke: true);
	}

	private void SetCameraOwnerObserver(int ov, int flag)
	{
	}

	private void SetNameList(List<string> ov, List<string> nameList)
	{
		int i;
		for (i = 0; i < nameList.Count && !string.IsNullOrEmpty(nameList[i]); i++)
		{
			int index = i + 1;
			_viewModel.SetPlayerShow(index, value: true);
			_viewModel.SetPlayerString(index, nameList[i]);
			_viewModel.SetScoreString(index, UiIEventCondition.Get_mechwarrionRankDate_ScoreList()[i].ToString());
		}
		for (; i < 2; i++)
		{
			_viewModel.SetPlayerShow(i + 1, value: false);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
