using Assets.Sources.Components.Time;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.RpgTanlanBoss;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.RpgTanlanBoss;

[GameUiTest]
public class RpgTanlanBossXuliUIModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ISetWeaponContext
{
	private RpgTanlanBossXuliUIViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _raceType;

	private GameRuleContext _gameRuleContext;

	private WeaponContext _weaponContext;

	private int RemainingTime;

	private int TotalTime;

	private bool IsShow;

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
		_viewModel = new RpgTanlanBossXuliUIViewModel();
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
		NotifyManager.MakeTempNotify(GetVisible, SetVisible, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetTipChange, SetTipChange, null, initinvoke: true);
	}

	private bool GetTipChange()
	{
		return _gameRuleContext.rpgTanlanJinWu.XuliTipChange;
	}

	private void SetTipChange(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_gameRuleContext.rpgTanlanJinWu.XuliTipChange = false;
			RpgTipsEventData xuliTip = _gameRuleContext.rpgTanlanJinWu.XuliTip;
			RemainingTime = xuliTip.Time1;
			TotalTime = xuliTip.Time2;
			IsShow = xuliTip.Show;
		}
	}

	private bool GetVisible()
	{
		return IsShow;
	}

	private void SetVisible(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = arg2;
	}

	private void InitChips()
	{
	}

	private void UpdateChips(TimeComponent time)
	{
		if (RemainingTime > 0)
		{
			RemainingTime -= time.FrameInterval;
			if (RemainingTime < 0)
			{
				RemainingTime = 0;
			}
			_viewModel.imgProgressFillamount = 1f - (float)RemainingTime / (float)TotalTime;
		}
	}
}
