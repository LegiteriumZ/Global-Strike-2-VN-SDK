using Assets.Sources.Components.GameRule.Rpg;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgGuoQingRace;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgGuoQingRace;

[GameUiTest]
public class RpgGuoQingGameProgressModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private RpgGuoQingGameProgressViewModel _viewModel;

	private GuoQinRaceUIComponent _guoQinRaceUI;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_guoQinRaceUI = context.guoQinRaceUI;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgGuoQingGameProgressViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(GetMenValue, SetMenValue, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetLaserValue, SetLaserValue, null, initinvoke: true);
	}

	private void SetLaserValue(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount2 = arg2;
	}

	private float GetLaserValue()
	{
		if (_guoQinRaceUI.Data == null)
		{
			return 0f;
		}
		return _guoQinRaceUI.Data.Value2;
	}

	private void SetMenValue(float arg1, float arg2)
	{
		_viewModel.ProgressFillamount1 = arg2;
	}

	private float GetMenValue()
	{
		if (_guoQinRaceUI.Data == null)
		{
			return 0f;
		}
		return _guoQinRaceUI.Data.Value1;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
