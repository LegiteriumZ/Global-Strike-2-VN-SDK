using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GroupGunKing;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GroupGunKing;

public class GroupGunKingTeamScoreModel : AbstractModel, IPlaybackSystem
{
	private GroupGunKingTeamScoreViewModel _viewModel;

	private PositionChip _ctLightPositionChip = new PositionChip();

	private FrameAnimaChip _ctEffectFrameAnimaChip = new FrameAnimaChip();

	private PositionChip _tLightPositionChip = new PositionChip();

	private FrameAnimaChip _tEffectFrameAnimaChip = new FrameAnimaChip();

	private PositionChip _weaponEffectPositionChip = new PositionChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GroupGunKingTeamScoreViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		if (_weaponEffectPositionChip.IsOver)
		{
			_weaponEffectPositionChip.Position = new Vector3(-100f, -10f, 0f);
		}
		_viewModel.CtEffectShow = !_ctEffectFrameAnimaChip.IsOver;
		_viewModel.TEffectShow = !_tEffectFrameAnimaChip.IsOver;
		if (_ctEffectFrameAnimaChip.Changed)
		{
			base.Loader.RetriveSprite("ui/groupgunkingmodel", _ctEffectFrameAnimaChip.Value, delegate(Sprite sprite)
			{
				_viewModel.CtEffectSprite = sprite;
			});
		}
		if (_tEffectFrameAnimaChip.Changed)
		{
			base.Loader.RetriveSprite("ui/groupgunkingmodel", _tEffectFrameAnimaChip.Value, delegate(Sprite sprite)
			{
				_viewModel.TEffectSprite = sprite;
			});
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_ctEffectFrameAnimaChip.Delay = 200;
		_ctEffectFrameAnimaChip.Count = 10;
		_ctEffectFrameAnimaChip.StartIndex = 0;
		_ctEffectFrameAnimaChip.Path = "Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/teamScore/cteffect_0";
		_tEffectFrameAnimaChip.Delay = 200;
		_tEffectFrameAnimaChip.Count = 10;
		_tEffectFrameAnimaChip.StartIndex = 0;
		_tEffectFrameAnimaChip.Path = "Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/teamScore/teffect_0";
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingTeamScoreData_Phase, SetPhase, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingTeamScoreData_PhaseScore, SetPhaseScore, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingTeamScoreData_Team1KillNum, SetTeam1KillNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingTeamScoreData_Team2KillNum, SetTeam2KillNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_groupGunKingTeamScoreData_MaxKillNum, SetMaxKillNum, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team1Score, SetTeam1Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_broadcastScore_Team2Score, SetTeam2Score, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true);
	}

	private void SetMaxKillNum(int arg1, int arg2)
	{
		SetTeam1KillNum(0, UiIEventCondition.Get_groupGunKingTeamScoreData_Team1KillNum());
		SetTeam2KillNum(0, UiIEventCondition.Get_groupGunKingTeamScoreData_Team2KillNum());
	}

	private void SetMinutes(int ov, int value)
	{
		_viewModel.MinutesString = value.ToString("D2");
	}

	private void SetSeconds(int ov, int value)
	{
		_viewModel.SecondsString = value.ToString("D2");
	}

	private void SetTeam2KillNum(int ov, int value)
	{
		int groupGunKingTeamScoreData_MaxKillNum = UiIEventCondition.Get_groupGunKingTeamScoreData_MaxKillNum();
		_ctEffectFrameAnimaChip.Index = 0;
		_ctLightPositionChip.Position = new Vector3(-200f, 0f);
		float num = ((groupGunKingTeamScoreData_MaxKillNum > 0) ? ((float)value / (float)groupGunKingTeamScoreData_MaxKillNum) : 0f);
		_viewModel.CtBarFillamount = num;
		_viewModel.CtBarEndPosition = new Vector3(-240f + 200f * num, _viewModel.CtBarEndPosition.y);
		_viewModel.CtKillString = (groupGunKingTeamScoreData_MaxKillNum - value).ToString();
	}

	private void SetTeam1KillNum(int ov, int value)
	{
		int groupGunKingTeamScoreData_MaxKillNum = UiIEventCondition.Get_groupGunKingTeamScoreData_MaxKillNum();
		_tEffectFrameAnimaChip.Index = 0;
		_tLightPositionChip.Position = new Vector3(200f, 0f);
		float num = ((groupGunKingTeamScoreData_MaxKillNum > 0) ? ((float)value / (float)groupGunKingTeamScoreData_MaxKillNum) : 0f);
		_viewModel.TBarFillamount = num;
		_viewModel.TBarEndPosition = new Vector3(240f - 200f * num, _viewModel.TBarEndPosition.y);
		_viewModel.TKillString = (groupGunKingTeamScoreData_MaxKillNum - value).ToString();
	}

	private void SetPhaseScore(int ov, int value)
	{
		_viewModel.PhaseScoreString = value.ToString();
	}

	private void SetPhase(int ov, int value)
	{
		base.Loader.RetriveSprite("ui/groupgunkingmodel", "Assets/Res/Assets/ui/GameGUIRes/groupGunkingModel/teamScore/phase" + value + ".png", delegate(Sprite sprite)
		{
			_viewModel.WeaponSprite = sprite;
			_viewModel.WeaponNtvsize();
		});
	}

	private void SetTeam1Score(long ov, long value)
	{
		_viewModel.TScoreString = value.ToString();
	}

	private void SetTeam2Score(long ov, long value)
	{
		_viewModel.CtScoreString = value.ToString();
	}

	private void InitChips()
	{
		_ctLightPositionChip.Position = new Vector3(-200f, 0f, 0f);
		_ctLightPositionChip.TargetPosition = new Vector3(200f, 0f, 0f);
		_ctLightPositionChip.Speed = new Vector3(200f, 0f, 0f);
		_tLightPositionChip.Position = new Vector3(200f, 0f, 0f);
		_tLightPositionChip.TargetPosition = new Vector3(-200f, 0f, 0f);
		_tLightPositionChip.Speed = new Vector3(-200f, 0f, 0f);
		_weaponEffectPositionChip.Position = new Vector3(-100f, -10f, 0f);
		_weaponEffectPositionChip.TargetPosition = new Vector3(100f, -10f, 0f);
		_weaponEffectPositionChip.Speed = new Vector3(100f, 0f, 0f);
	}

	private void UpdateChips()
	{
		_viewModel.CtLightPosition = _ctLightPositionChip.Update(_timeComponent);
		_ctEffectFrameAnimaChip.Update(_timeComponent);
		_viewModel.TLightPosition = _tLightPositionChip.Update(_timeComponent);
		_tEffectFrameAnimaChip.Update(_timeComponent);
		_viewModel.WeaponEffectPosition = _weaponEffectPositionChip.Update(_timeComponent);
	}
}
