using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.common;

public class ObserverShadowModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	private ObservershadowViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private ActiveChip _helpActiveChip = new ActiveChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ObservershadowViewModel();
	}

	public void OnPlayback()
	{
		bool isObserver = _battleRoomContext.roomData.IsObserver;
		if (_viewModel.PanelRootshow && isObserver)
		{
			UpdateChips();
			_viewModel.TextShow = _helpActiveChip.Time < 0;
		}
	}

	protected override void DoSubscribe()
	{
		_helpActiveChip.Time = 15000;
		if (RuleUtilty.isRpgDuelDianfeng(_battleRoomContext.roomData.Data.RaceType))
		{
			_helpActiveChip.Time = 0;
		}
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Observer, SetObserver, null, initinvoke: true);
	}

	private void SetObserver(int ov, int cid)
	{
		if (cid > 0)
		{
			_viewModel.PanelRootshow = false;
			_viewModel.PanelRootshow = true;
			bool isObserver = _battleRoomContext.roomData.IsObserver;
			if (isObserver)
			{
				if (_helpActiveChip.Time > 0)
				{
					_viewModel.TextShow = false;
					_viewModel.BottomShadowShow = false;
					_viewModel.TopShadowShow = false;
					_viewModel.HelpShow = true;
				}
				else
				{
					_viewModel.HelpShow = false;
					_viewModel.BottomShadowShow = false;
					_viewModel.TopShadowShow = false;
					_viewModel.TextShow = true;
				}
			}
			else
			{
				_viewModel.HelpShow = false;
				_viewModel.BottomShadowShow = true;
				_viewModel.TopShadowShow = true;
				_viewModel.TextShow = true;
			}
			_viewModel.TextString = (isObserver ? ScriptLocalization.Get("Observerplayer2") : ScriptLocalization.Get("Observerplayer"));
		}
		else
		{
			_viewModel.PanelRootshow = false;
		}
	}

	private void InitChips()
	{
		_helpActiveChip.Time = 0;
	}

	private void UpdateChips()
	{
		_viewModel.HelpShow = _helpActiveChip.Update(_timeComponent);
	}
}
