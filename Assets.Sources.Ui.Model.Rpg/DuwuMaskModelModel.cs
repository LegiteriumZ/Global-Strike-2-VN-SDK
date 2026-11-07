using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class DuwuMaskModelModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetPlayerContext
{
	private DuwuMaskModelViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private float _flag;

	private bool _changeAlpha = true;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new DuwuMaskModelViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			if (UiIEventCondition.Get_status_ExplodeDuwu())
			{
				PlayerAplha();
			}
			else
			{
				_changeAlpha = false;
			}
		}
	}

	private void PlayerAplha()
	{
		_viewModel.DuwuMaskShow = true;
		UpdateAlpha(_timeComponent.FrameInterval);
	}

	private void UpdateAlpha(int frameTime)
	{
		if (!_changeAlpha && _viewModel.DuwuMaskModelAlpha != 0f)
		{
			_viewModel.DuwuMaskModelAlpha = 0f;
			_viewModel.DuwuMaskShow = false;
			return;
		}
		float num = _viewModel.DuwuMaskModelAlpha + (float)frameTime / 1000f * 0.5f * _flag;
		if (num >= 1f)
		{
			_flag = -1f;
			num = 1f;
		}
		else if ((double)num <= 0.5)
		{
			_flag = 1f;
			num = 0.5f;
		}
		_viewModel.DuwuMaskModelAlpha = num;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.DuwuMaskShow = false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
