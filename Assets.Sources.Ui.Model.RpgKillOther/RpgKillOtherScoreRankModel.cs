using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgKillOther;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgKillOther;

[GameUiTest]
public class RpgKillOtherScoreRankModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private RpgKillOtherScoreRankViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgKillOtherScoreRankViewModel();
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
		NotifyManager.MakeTempNotify(GetSort, SetSort, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetTime, SetTime, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetTimeVisible, SetTimeVisible, null, initinvoke: true);
	}

	private void SetTimeVisible(bool arg1, bool arg2)
	{
		_viewModel.TimeShow = arg2;
	}

	private bool GetTimeVisible()
	{
		RightUIData data = _gameRuleContext.rightUi.Data;
		if (data != null)
		{
			return data.PortalLeftTime >= 0;
		}
		return false;
	}

	private void SetTime(int arg1, int arg2)
	{
		_viewModel.TimeString = arg2.ToString();
	}

	private int GetTime()
	{
		RightUIData data = _gameRuleContext.rightUi.Data;
		if (data != null)
		{
			return data.PortalLeftTime / 1000;
		}
		return 0;
	}

	private void SetSort(int arg1, int arg2)
	{
		_viewModel.RankString = arg2.ToString();
	}

	private int GetSort()
	{
		return _gameRuleContext.rightUi.Data?.Sort ?? 0;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
