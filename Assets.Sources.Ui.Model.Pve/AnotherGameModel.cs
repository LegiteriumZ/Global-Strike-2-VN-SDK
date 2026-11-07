using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Pve;

public class AnotherGameModel : AbstractModel, IPlaybackSystem
{
	private AnotherGameViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new AnotherGameViewModel();
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
		_viewModel.AnotherGameShow = false;
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gameMessageData_MessageData, SetMessageData, null, initinvoke: true);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void SetMessageData(GameMessageData ov, GameMessageData data)
	{
		if (data != null)
		{
			_ = data.Type;
			_ = 10;
		}
	}
}
