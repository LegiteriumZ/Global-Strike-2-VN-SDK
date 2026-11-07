using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.GunFight;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.GunFight;

[GameUiTest]
public class GunFightTextMessageModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private GunFightTextMessageViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private TimeContext _timeContext;

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
		_timeContext = Contexts.sharedInstance.time;
	}

	public override void CreateViewModel()
	{
		_viewModel = new GunFightTextMessageViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null)
		{
			_ = _viewModel.IsInited;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		NotifyManager.MakeTempNotifyClass(GetWeaponPoolName, SetWeaponPoolName);
		NotifyManager.MakeTempNotify(GetShow, SetShow);
	}

	private void SetShow(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private bool GetShow()
	{
		return _timeContext.commonTimer.CommonTimer.ContainsKey("GUNFIGHTTEXTMESSAGE");
	}

	private void SetWeaponPoolName(string arg1, string arg2)
	{
		if (string.IsNullOrEmpty(arg2))
		{
			_viewModel.TextString = "";
		}
		else if (arg2 == "none")
		{
			_viewModel.TextString = "Hiện đang là chế độ All In, hãy dùng vũ khí trong ba lô của mình để chiến đấu!";
		}
		else
		{
			_viewModel.TextString = $"Kho vũ khí trận này là <color=#FFFF00FF>[{arg2}]</color>, vui lòng chuẩn bị vào trận!";
		}
	}

	private string GetWeaponPoolName()
	{
		if (_gameRuleContext.gunFightData != null)
		{
			return _gameRuleContext.gunFightData.WeaponPoolName;
		}
		return "";
	}
}
