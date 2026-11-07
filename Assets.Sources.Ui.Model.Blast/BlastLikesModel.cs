using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Blast;
using Assets.UiFramework.Libs;
using NotifyEvent;

namespace Assets.Sources.Ui.Model.Blast;

public class BlastLikesModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private BlastlikesViewModel _viewModel = new BlastlikesViewModel();

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.PanelRootshow = false;
		if ((_battleRoomContext.roomData.Data.RaceType == 2 || _battleRoomContext.roomData.Data.RaceType == 66) && !_battleRoomContext.roomData.IsObserver)
		{
			NotifyManager.MakeTempNotify(GetShowBlastLikes, SetShowBlastLikes, null, initinvoke: true, isFrameSeparation: true);
		}
	}

	private bool GetShowBlastLikes()
	{
		if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
		{
			return !_gameRuleContext.peekabooLikes.ShowBlastLikes;
		}
		return false;
	}

	private void SetShowBlastLikes(bool ov, bool show)
	{
		_viewModel.PanelRootshow = false;
		_viewModel.PanelRootshow = show;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
