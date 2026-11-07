using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RoleSkill1018ProgressModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private RoleSkill1018ProgressViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private bool _isShow;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

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
		_viewModel = new RoleSkill1018ProgressViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			UpdateProgress();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowRootshow = false;
		NotifyManager.MakeTempNotify(GetVisiable, SetVisiable);
	}

	private void UpdateProgress()
	{
		if (_isShow)
		{
			_viewModel.ProgressFillamount = (float)_gameRuleContext.gameProgressData.CurrentProgressTime * 1f / (float)_gameRuleContext.gameProgressData.ProgressTotalTime;
		}
	}

	private bool GetVisiable()
	{
		if (_gameRuleContext.gameProgressData.ProgressType == ProgressType.ROLESKILL1018)
		{
			return _gameRuleContext.gameProgressData.CurrentProgressTime < _gameRuleContext.gameProgressData.ProgressTotalTime;
		}
		return false;
	}

	private void SetVisiable(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_viewModel.ShowRootshow = false;
			_viewModel.ShowRootshow = true;
			_isShow = true;
		}
		else
		{
			_viewModel.ShowRootshow = false;
			_isShow = false;
		}
		_viewModel.ProgressFillamount = 0f;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
