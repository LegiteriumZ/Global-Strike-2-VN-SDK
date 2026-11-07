using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTeamRace;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;

namespace Assets.Sources.Ui.Model.RpgTeamRace;

[GameUiTest]
public class RpgTeamRaceScoreRankModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetPlayerContext
{
	private RpgTeamRaceScoreRankViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private SimpleNotifyGroup[] _groups = new SimpleNotifyGroup[3]
	{
		new SimpleNotifyGroup(),
		new SimpleNotifyGroup(),
		new SimpleNotifyGroup()
	};

	private static readonly int[] TeamId = new int[3] { 6, 8, 7 };

	private PlayerContext _playerContext;

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
		_viewModel = new RpgTeamRaceScoreRankViewModel();
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
		for (int i = 0; i < 3; i++)
		{
			SimpleNotify.Add(GetVisible, SetVisible, i);
			_groups[i].Add(SimpleNotify.Add(GetProgress, SetProgress, i));
			_groups[i].Add(SimpleNotify.Add(GetScore, SetScore, i));
			_groups[i].Add(SimpleNotify.Add(GetFont, SetFont, i));
			_groups[i].Add(SimpleNotify.Add(GetNeedKill, SetNeedKill, i));
			_groups[i].Add(SimpleNotify.Add(GetBannerType, SetBannerType, i));
		}
	}

	private void SetFont(int arg1, int index)
	{
		base.Loader.Load("number", $"Assets/Res/Assets/number/{arg1}.fontsettings", delegate(Object v)
		{
			_viewModel.SetScoreTextfont(index, (Font)v);
			_viewModel.SetNeedKillTextfont(index, (Font)v);
		});
	}

	private int GetFont(int index)
	{
		if (TeamId[index] == 7)
		{
			return 680;
		}
		if (_playerContext.isMyPlayer && _playerContext.myPlayerEntity.GetTeam() == TeamId[index])
		{
			return 680;
		}
		return 360;
	}

	private void SetBannerType(int arg1, int index)
	{
		base.Loader.RetriveSprite("ui/rpgteammodel", $"Assets/Res/Assets/ui/GameGUIRes/rpgTeamModel/battleSorce/zhanqi{arg1}Icon.png", delegate(Sprite sprite)
		{
			_viewModel.SetBattleFlagSprite(index + 1, sprite);
		});
	}

	private int GetBannerType(int index)
	{
		if (_gameRuleContext.teamRaceUi.Data.TryGetValue(TeamId[index], out var value))
		{
			return value.BannerType;
		}
		return 0;
	}

	private void SetNeedKill(int arg1, int index)
	{
		_viewModel.SetNeedKillString(index + 1, arg1.ToString());
	}

	private int GetNeedKill(int index)
	{
		if (_gameRuleContext.teamRaceUi.Data.TryGetValue(TeamId[index], out var value))
		{
			return value.LeftNum;
		}
		return 0;
	}

	private void SetScore(long arg1, int index)
	{
		_viewModel.SetScoreString(index + 1, arg1.ToString());
	}

	private long GetScore(int index)
	{
		if (_gameRuleContext.teamRaceUi.Data.TryGetValue(TeamId[index], out var value))
		{
			return value.Value;
		}
		return 0L;
	}

	private void SetProgress(float arg1, int index)
	{
		_viewModel.SetProgressFillamount(index + 1, arg1);
		_viewModel.SetBattleFlagPosition(index + 1, new Vector3(0f, -114f + 230f * arg1));
	}

	private float GetProgress(int index)
	{
		if (_gameRuleContext.teamRaceUi.Data.TryGetValue(TeamId[index], out var value))
		{
			if (value.Max <= 0)
			{
				return 0f;
			}
			return (float)value.Value / (float)value.Max;
		}
		return 0f;
	}

	private void SetVisible(bool arg1, int index)
	{
		_viewModel.SetProgressBarShow(index + 1, arg1);
		_groups[index].SetSuspend(!arg1);
	}

	private bool GetVisible(int index)
	{
		return _gameRuleContext.teamRaceUi.Data.ContainsKey(TeamId[index]);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
