using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.BattleRoom;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgZhouNianQing;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;

namespace Assets.Sources.Ui.Model.RpgZhouNianQing;

[GameUiTest]
public class RpgZhouNianQingScoreRankModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	private RpgZhouNianQingScoreRankViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private PlayerInfoComponent _playerInfo;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		_playerInfo = _battleRoomContext.playerInfo;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgZhouNianQingScoreRankViewModel();
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
		for (int i = 0; i < 10; i++)
		{
			SimpleNotify.Add(GetPlayerName, SetPlayerName, i);
			SimpleNotify.Add(GetScore, SetScore, i);
		}
	}

	private void SetScore(long arg1, int arg2)
	{
		_viewModel.SetScoreString(arg2 + 1, arg1.ToString());
	}

	private long GetScore(int arg1)
	{
		if (arg1 < _playerInfo.Team2.Count)
		{
			return _playerInfo.Team2[arg1].Score;
		}
		return 0L;
	}

	private void SetPlayerName(string arg1, int arg2)
	{
		if (string.IsNullOrEmpty(arg1))
		{
			_viewModel.SetPlayerNameShow(arg2 + 1, value: false);
			return;
		}
		_viewModel.SetPlayerNameShow(arg2 + 1, value: true);
		_viewModel.SetPlayerNameString(arg2 + 1, arg1);
	}

	private string GetPlayerName(int arg1)
	{
		if (arg1 < _playerInfo.Team2.Count)
		{
			return _playerInfo.Team2[arg1].PlayerName;
		}
		return string.Empty;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
