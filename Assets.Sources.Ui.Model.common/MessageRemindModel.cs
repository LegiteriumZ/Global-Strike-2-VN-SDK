using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Common;

public class MessageRemindModel : AbstractModel, IPlaybackSystem
{
	private MessageremindViewModel _viewModel;

	private ActiveChip _centerActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new MessageremindViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeNotify(38, UiIEventCondition.Get_messageRemindData_Changed, SetChanged, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_messageRemindData_Ak47Message, SetAk47Message, null, initinvoke: true);
	}

	private void SetAk47Message(string ov, string msg)
	{
		_viewModel.BottomShow = !string.IsNullOrEmpty(msg);
		if (_viewModel.BottomShow)
		{
			_viewModel.BottomTextString = msg;
		}
	}

	private void SetChanged(bool ov, bool changed)
	{
		if (changed)
		{
			_viewModel.MessageTextString = UiIEventCondition.Get_messageRemindData_MessageText();
			_centerActiveChip.Time = UiIEventCondition.Get_messageRemindData_MessageShowTime();
		}
	}

	private void InitChips()
	{
		_centerActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.CenterShow = _centerActiveChip.Update(_timeComponent);
	}
}
