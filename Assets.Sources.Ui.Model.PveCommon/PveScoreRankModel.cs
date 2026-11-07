using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveScoreRankModel : AbstractModel, IPlaybackSystem
{
	private PveScoreRankViewModel _viewModel;

	private string _myName;

	private const int MaxNum = 6;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveScoreRankViewModel();
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
		IListNotify listNotify = NotifyManager.MakeTempNotifyList(UiIEventCondition.Get_allKillInfo_Team2);
		for (int i = 0; i < 6; i++)
		{
			_viewModel.SetItemShow(i + 1, value: false);
			listNotify.AddEvent<OneKillInfoData, string>("PlayerName", UiIEventCondition.Get_OneKillInfoData_PlayerName, SetPlayerName, i);
			listNotify.AddEvent<OneKillInfoData, bool>("IsDead", UiIEventCondition.Get_OneKillInfoData_IsDead, SetIsDead, i);
			listNotify.AddEvent<OneKillInfoData, long>("Score", UiIEventCondition.Get_OneKillInfoData_Score, SetScore, i);
			listNotify.AddEvent<OneKillInfoData, float>("RelivePercent", UiIEventCondition.Get_pveScoreRank_RelivePercent, SetRelivePercent, i);
		}
		listNotify.ForceInvoke();
		_myName = UiIEventCondition.Get_uiMyPlayer_PlayerName();
	}

	private void SetRelivePercent(OneKillInfoData val, int idx, float oldfs, float newfs, ElementStatus status)
	{
		_viewModel.SetReleiveProgressFillamount(idx + 1, newfs);
	}

	private void SetScore(OneKillInfoData val, int idx, long oldfs, long newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			SetScore(idx, val);
		}
	}

	private void SetIsDead(OneKillInfoData val, int idx, bool oldfs, bool newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.SetRelieveBgShow(idx + 1, newfs);
			SetScore(idx, val);
			SetColor(idx, val);
			if (newfs && UiIEventCondition.Get_pveMessage_PveMessageData() != null && UiIEventCondition.Get_pveMessage_PveMessageData().PlayerId == val.Id)
			{
				_viewModel.SetWetShow(idx + 1, value: true);
			}
			else
			{
				_viewModel.SetWetShow(idx + 1, value: false);
			}
		}
	}

	private void SetPlayerName(OneKillInfoData val, int idx, string oldfs, string newfs, ElementStatus status)
	{
		if (status == ElementStatus.InList || status == ElementStatus.NewInList)
		{
			_viewModel.SetPlayerNameString(idx + 1, newfs);
			_viewModel.SetItemShow(idx + 1, value: true);
			SetColor(idx, val);
		}
		else
		{
			_viewModel.SetItemShow(idx + 1, value: false);
		}
	}

	private void SetScore(int idx, OneKillInfoData data)
	{
		bool[] shows = new bool[6];
		ConvertLargeNummber(data.Score, ref shows, out var wholeStr, out var decimalStr);
		LargeNumberPosition(shows[0], data.Score >= 10000, wholeStr, decimalStr, out var positions, Vector2.zero);
		if (data.IsDead)
		{
			shows = new bool[6];
			wholeStr = "";
			decimalStr = "";
		}
		switch (idx)
		{
		case 0:
			_viewModel.SetScore1ShowLargenumber(shows);
			_viewModel.SetScore1PosiLargenumber(positions);
			_viewModel.SetScore1TextLargenumber(wholeStr, decimalStr);
			break;
		case 1:
			_viewModel.SetScore2ShowLargenumber(shows);
			_viewModel.SetScore2PosiLargenumber(positions);
			_viewModel.SetScore2TextLargenumber(wholeStr, decimalStr);
			break;
		case 2:
			_viewModel.SetScore3ShowLargenumber(shows);
			_viewModel.SetScore3PosiLargenumber(positions);
			_viewModel.SetScore3TextLargenumber(wholeStr, decimalStr);
			break;
		case 3:
			_viewModel.SetScore4ShowLargenumber(shows);
			_viewModel.SetScore4PosiLargenumber(positions);
			_viewModel.SetScore4TextLargenumber(wholeStr, decimalStr);
			break;
		case 4:
			_viewModel.SetScore5ShowLargenumber(shows);
			_viewModel.SetScore5PosiLargenumber(positions);
			_viewModel.SetScore5TextLargenumber(wholeStr, decimalStr);
			break;
		case 5:
			_viewModel.SetScore6ShowLargenumber(shows);
			_viewModel.SetScore6PosiLargenumber(positions);
			_viewModel.SetScore6TextLargenumber(wholeStr, decimalStr);
			break;
		}
	}

	protected override void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		float num = 7f;
		float num2 = (usingDot ? 6f : (usingSuffix ? 16f : 25f));
		float num3 = (usingDot ? 36f : 18f);
		int num4 = wholeStr.Length - 1;
		positions = new Vector3[7]
		{
			new Vector3(num2 + offset.x, -13f + offset.y),
			new Vector3(8.5f + (float)num4 * num, -1.5f),
			new Vector3(18f + (float)num4 * num, 0f),
			new Vector3(num3 + (float)num4 * num, 3f),
			new Vector3(num3 + (float)num4 * num, 3f),
			new Vector3(num3 + (float)num4 * num, 3f),
			new Vector3(num3 + (float)num4 * num, 3f)
		};
	}

	private void SetColor(int idx, OneKillInfoData data)
	{
		if (data.IsDead)
		{
			_viewModel.SetPlayerNameTextcolor(idx + 1, new Color(0.598f, 0.598f, 0.598f));
		}
		else if (data.PlayerName == _myName)
		{
			_viewModel.SetPlayerNameTextcolor(idx + 1, new Color(0f, 1f, 0f));
		}
		else
		{
			_viewModel.SetPlayerNameTextcolor(idx + 1, new Color(0.266f, 0.805f, 0.961f));
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
