using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgGroup;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgGroup;

public class RpgGroupWaitPlayerModel : AbstractModel, IPlaybackSystem
{
	private RpgGroupWaitPlayerViewModel _viewModel;

	private int _playerNum;

	private int _time;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgGroupWaitPlayerViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.PanelShow)
			{
				_time += _timeComponent.FrameInterval;
				_viewModel.TimeString = (_time / 1000).ToString();
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.PanelShow = false;
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameTipsShow_RpgGroupWaitPlayer, SetRpgGroupWaitPlayer, null, initinvoke: true);
	}

	private void SetRpgGroupWaitPlayer(RpgTipsEventData ov, RpgTipsEventData msg)
	{
		if (msg != null && msg.TypeId == 15000001)
		{
			_viewModel.PanelShow = msg.Show;
			if (msg.Show)
			{
				_playerNum = msg.Time4 - msg.Time1;
				_time = msg.Time3 - msg.Time2;
				_viewModel.TotalPlayerString = msg.Time4.ToString();
				_viewModel.TotalTimeString = (msg.Time3 / 1000).ToString();
				_viewModel.TimeString = (_time / 1000).ToString();
				_viewModel.PlayerString = _playerNum.ToString();
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
