using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Cybermodel;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Cybermodel;

[GameUiTest]
public class Cybermodel_itemModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	protected Cybermodel_itemViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private string[] colorlist = new string[3] { "50ACF6FF", "CC91D7FF", "FBC847FF" };

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
		if (context.hasRoomData)
		{
			_raceType = context.roomData.Data.RaceType;
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Cybermodel_itemViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips(_timeComponent);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotify(154, Get_EnergyData, Set_EnergyData);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_allKillInfo_IndividualVisible, SetIndividualVisible, null, initinvoke: true);
	}

	private void SetIndividualVisible(bool ov, bool flag)
	{
		_viewModel.ShowShow = flag;
	}

	public int Get_EnergyData()
	{
		if (Contexts.sharedInstance.message.cyberRpg.dropItems == null)
		{
			return 0;
		}
		return Contexts.sharedInstance.message.cyberRpg.dropItems.GetHashCode();
	}

	public void Set_EnergyData(int v1, int v2)
	{
		int num = Mathf.Min(Contexts.sharedInstance.message.cyberRpg.dropItems.Count, 19);
		for (int i = 0; i < num; i++)
		{
			_viewModel.SetitemShow(i + 1, value: true);
			_viewModel.SetitemString(i + 1, string.Format("<color=#{2}>{0}x{1}</color>", Contexts.sharedInstance.message.cyberRpg.dropItems[i].Name, Contexts.sharedInstance.message.cyberRpg.dropItems[i].Num, colorlist[Contexts.sharedInstance.message.cyberRpg.dropItems[i].Lv - 1]));
		}
		if (num == 19)
		{
			_viewModel.SetitemShow(20, value: true);
			return;
		}
		for (int j = num; j < 20; j++)
		{
			_viewModel.SetitemShow(j + 1, value: false);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
	}
}
