using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.GunKing;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.GunKing;

public class GunKingTeamScoreModel : AbstractModel, IPlaybackSystem
{
	private GunKingTeamScoreViewModel _viewModel;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new GunKingTeamScoreViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gunKingTeamScoreData_SelfKillCount, SetSelfKillCount, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gunKingTeamScoreData_SelfPhase, SetSelfPhase, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gunKingTeamScoreData_SelfPhaseKillCount, SetSelfPhaseKillCount, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_gunKingTeamScoreData_GunkingPlayerName, SetGunkingPlayerName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gunKingTeamScoreData_GunkingKillCount, SetGunkingKillCount, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gunKingTeamScoreData_GunkingPhase, SetGunkingPhase, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gunKingTeamScoreData_GunkingPhaseKillCount, SetGunkingPhaseKillCount, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Minutes, SetMinutes, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiSectionTime_Seconds, SetSeconds, null, initinvoke: true);
	}

	private void SetGunkingPhaseKillCount(int arg1, int arg2)
	{
		UpdateGunKing();
	}

	private void SetGunkingPhase(int arg1, int arg2)
	{
		UpdateGunKing();
	}

	private void SetGunkingKillCount(int arg1, int arg2)
	{
		UpdateGunKing();
	}

	private void SetSelfPhaseKillCount(int arg1, int arg2)
	{
		UpdateSelf();
	}

	private void SetSelfPhase(int arg1, int arg2)
	{
		UpdateSelf();
	}

	private void SetSelfKillCount(int arg1, int arg2)
	{
		UpdateSelf();
	}

	private void UpdateGunKing()
	{
		float num = ((UiIEventCondition.Get_gunKingTeamScoreData_GunkingPhaseKillCount() > 0) ? ((float)UiIEventCondition.Get_gunKingTeamScoreData_GunkingPhase() / 8f + (float)UiIEventCondition.Get_gunKingTeamScoreData_GunkingKillCount() / (float)UiIEventCondition.Get_gunKingTeamScoreData_GunkingPhaseKillCount() * 0.125f) : 0f);
		_viewModel.GunKingBackPosition = new Vector3((int)(-272f + 528f * num), -52f);
		_viewModel.SelfIconShow = UiIEventCondition.Get_cameraOwnerData_PlayerName() != UiIEventCondition.Get_gunKingTeamScoreData_GunkingPlayerName() && _viewModel.SelfPhaseFillamount > 0f;
	}

	private void SetGunkingPlayerName(string ov, string name)
	{
		_viewModel.GunKingBackShow = !string.IsNullOrEmpty(name);
		_viewModel.GunKingNameString = name;
	}

	private void SetMinutes(int ov, int value)
	{
		_viewModel.MinutesString = value.ToString("D2");
	}

	private void SetSeconds(int ov, int value)
	{
		_viewModel.SecondsString = value.ToString("D2");
	}

	private void UpdateSelf()
	{
		_viewModel.SelfNeedKillString = UiIEventCondition.Get_gunKingTeamScoreData_SelfKillCount().ToString();
		float num = ((UiIEventCondition.Get_gunKingTeamScoreData_SelfPhaseKillCount() > 0) ? ((float)UiIEventCondition.Get_gunKingTeamScoreData_SelfPhase() / 8f + (float)UiIEventCondition.Get_gunKingTeamScoreData_SelfKillCount() / (float)UiIEventCondition.Get_gunKingTeamScoreData_SelfPhaseKillCount() * 0.125f) : 0f);
		_viewModel.SelfPhaseFillamount = num;
		_viewModel.SelfIconShow = UiIEventCondition.Get_cameraOwnerData_PlayerName() != UiIEventCondition.Get_gunKingTeamScoreData_GunkingPlayerName() && num > 0f;
		_viewModel.SelfIconPosition = new Vector3((int)(-272f + 528f * num), -15f);
		_viewModel.SelfNeedKillString = (UiIEventCondition.Get_gunKingTeamScoreData_SelfPhaseKillCount() - UiIEventCondition.Get_gunKingTeamScoreData_SelfKillCount()).ToString();
		for (int i = 1; i <= 8; i++)
		{
			_viewModel.SetWeaponShow(i, i <= UiIEventCondition.Get_gunKingTeamScoreData_SelfPhase() + 1);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
