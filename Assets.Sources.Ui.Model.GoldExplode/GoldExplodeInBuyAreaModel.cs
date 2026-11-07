using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GoldExplode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.GoldExplode;

public class GoldExplodeInBuyAreaModel : AbstractModel, IPlaybackSystem
{
	private GoldexplodeinbuyareaViewModel _viewModel = new GoldexplodeinbuyareaViewModel();

	private bool _inBuyTime;

	private bool _inArea;

	protected override IUiViewModel ViewModel => _viewModel;

	protected override void DoSubscribe()
	{
		_viewModel.PanelShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_goldExplodeBuyAreaData_InBuyArea, SetInBuyArea, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Passed, SetPassed, null, initinvoke: true);
	}

	private void SetPassed(int ov, int passed)
	{
		if (passed > 0 && UiIEventCondition.Get_goldExplodeBuyAreaData_BuyTime() > 0)
		{
			int num = (UiIEventCondition.Get_goldExplodeBuyAreaData_BuyTime() - passed) / 1000;
			_inBuyTime = num > 0;
			if (_inBuyTime)
			{
				_viewModel.TimeTextString = StringCache.IntToStringD2(num);
			}
			CheckVisible();
		}
	}

	private void SetInBuyArea(bool ov, bool value)
	{
		_inArea = value;
		CheckVisible();
	}

	private void CheckVisible()
	{
		_viewModel.PanelShow = _inArea && _inBuyTime;
	}

	public void OnPlayback()
	{
	}
}
