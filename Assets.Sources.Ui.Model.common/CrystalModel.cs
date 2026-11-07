using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Common;

public class CrystalModel : AbstractModel, IPlaybackSystem
{
	private CrystalViewModel _viewModel;

	private int _crystalTime;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CrystalViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_viewModel.CrystalBackShow)
		{
			_crystalTime -= _timeComponent.FrameInterval;
			if (_crystalTime <= 0)
			{
				_viewModel.CrystalBackShow = false;
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(33, UiIEventCondition.Get_crystalDropData_CrystalNum, SetCrystalNum, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_crystalDropData_FirstDrop, SetFirstDrop, null, initinvoke: true);
	}

	private void SetCrystalNum(int arg1, int arg2)
	{
		if (arg2 > 0)
		{
			_viewModel.CrystalNumString = arg2.ToString();
			_viewModel.CrystalBackShow = true;
			_crystalTime = 3000;
		}
		else
		{
			_viewModel.CrystalBackShow = false;
		}
	}

	private void SetFirstDrop(bool arg1, bool arg2)
	{
		_viewModel.FirstDropShow = arg2;
		_viewModel.NormalDropShow = !arg2;
	}
}
