using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.Sound;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Blast;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Blast;

[GameUiTest]
public class BlastTacticsSoundModel : AbstractModel, IPlaybackSystem, IKeyboardResponder
{
	private BlastTacticsSoundViewModel _viewModel;

	private int _startIndex;

	private int _distanceNum;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BlastTacticsSoundViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetView, null, initinvoke: false, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_Team, SetTeam, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetTeam(int arg1, int arg2)
	{
		TacticsSoundModel.Instance.AddSoundList(UiIEventCondition.Get_uiRoomData_RaceType(), UiIEventCondition.Get_gameInfo_IsWoman(), arg2);
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetView(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_viewModel.ShowShow = false;
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_distanceNum == 0)
		{
			if (RuleUtilty.IsAvatarUltimateChallenge())
			{
				_distanceNum = 7;
			}
			else
			{
				_distanceNum = 6;
			}
		}
		if (key == KeyCode.Z || key == KeyCode.X || key == KeyCode.C)
		{
			if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
			{
				return false;
			}
			if (UiIEventCondition.Get_uiMyPlayer_IsDead())
			{
				return false;
			}
			if (key == KeyCode.Z && UiIEventCondition.Get_uiMyPlayer_IsFakeDead() && RuleUtilty.IsAvatarUltimateChallenge())
			{
				TacticsSoundModel.Instance.SendSound(0, 21);
				return false;
			}
			switch (key)
			{
			case KeyCode.C:
				_viewModel.ShowShow = _startIndex != TacticsSoundModel.Instance.TacticsStartIndex || !_viewModel.ShowShow;
				_startIndex = TacticsSoundModel.Instance.TacticsStartIndex;
				_viewModel.TitleString = ScriptLocalization.Get("TacticssoundType1");
				break;
			case KeyCode.X:
				_viewModel.ShowShow = _startIndex != TacticsSoundModel.Instance.TacticsStartIndex + _distanceNum || !_viewModel.ShowShow;
				_startIndex = TacticsSoundModel.Instance.TacticsStartIndex + _distanceNum;
				_viewModel.TitleString = ScriptLocalization.Get("TacticssoundType2");
				break;
			case KeyCode.Z:
				_viewModel.ShowShow = _startIndex != TacticsSoundModel.Instance.TacticsStartIndex + 2 * _distanceNum || !_viewModel.ShowShow;
				_startIndex = TacticsSoundModel.Instance.TacticsStartIndex + 2 * _distanceNum;
				_viewModel.TitleString = ScriptLocalization.Get("TacticssoundType3");
				break;
			}
			for (int i = 0; i < _distanceNum; i++)
			{
				_viewModel.SetSoundShow(i + 1, value: true);
				_viewModel.SetSoundString(i + 1, TacticsSoundModel.Instance.GetTacticsSoundTextByIndex(_startIndex + i));
			}
		}
		if (_viewModel.ShowShow)
		{
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (alphaOrKeypadDiff >= 1 && alphaOrKeypadDiff <= _distanceNum)
			{
				TacticsSoundModel.Instance.SendSound(0, _startIndex + alphaOrKeypadDiff - 1 - TacticsSoundModel.Instance.TacticsStartIndex);
				_viewModel.ShowShow = false;
				return true;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}
}
