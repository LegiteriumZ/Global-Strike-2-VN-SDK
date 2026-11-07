using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.PveCommon;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.PveCommon;

public class PveTeamScoreModel : AbstractModel, IPlaybackSystem
{
	private PveTeamScoreViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PveTeamScoreViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveTeamScore_AllRound, SetAllRound, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveTeamScore_BotNum, SetBotNum, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveTeamScore_CurRound, SetCurRound, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveTeamScore_Score, SetScore, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetSeconds(int arg1, int arg2)
	{
		_viewModel.SecondCounterString = StringCache.IntToStringD2(arg2);
	}

	private void SetMinutes(int arg1, int arg2)
	{
		_viewModel.MinuteCounterString = StringCache.IntToStringD2(arg2);
	}

	private void SetScore(long arg1, long arg2)
	{
		bool[] shows = new bool[6];
		ConvertLargeNummber(arg2, ref shows, out var wholeStr, out var decimalStr);
		LargeNumberPosition(shows[0], arg2 >= 10000, wholeStr, decimalStr, out var positions, Vector2.zero);
		_viewModel.SetScoreCounterShowLargenumber(shows);
		_viewModel.SetScoreCounterPosiLargenumber(positions);
		_viewModel.SetScoreCounterTextLargenumber(wholeStr, decimalStr);
	}

	protected override void LargeNumberPosition(bool usingDot, bool usingSuffix, string wholeStr, string decimalStr, out Vector3[] positions, Vector2 offset)
	{
		float num = 7f;
		float num2 = (usingDot ? (-133f) : (usingSuffix ? (-122f) : (-122f)));
		float num3 = (usingDot ? 38f : 18f);
		int num4 = wholeStr.Length - 1;
		positions = new Vector3[7]
		{
			new Vector3(num2 + offset.x, -15f + offset.y),
			new Vector3(9.5f + (float)num4 * num, 3.5f),
			new Vector3(20f + (float)num4 * num, 0f),
			new Vector3(num3 + (float)num4 * num, 8f),
			new Vector3(num3 + (float)num4 * num, 8f),
			new Vector3(num3 + (float)num4 * num, 8f),
			new Vector3(num3 + (float)num4 * num, 8f)
		};
	}

	private void SetCurRound(int arg1, int arg2)
	{
		_viewModel.CurRoundCounterString = StringCache.IntToString(arg2);
	}

	private void SetBotNum(long arg1, long arg2)
	{
		_viewModel.BotCounterString = StringCache.LongToString(arg2);
	}

	private void SetAllRound(int arg1, int arg2)
	{
		_viewModel.AllRoundCounterString = StringCache.IntToString(arg2);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
