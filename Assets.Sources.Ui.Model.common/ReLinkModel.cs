using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using SSJJBase.String;

namespace Assets.Sources.Ui.Model.Common;

public class ReLinkModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	private ReLinkViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new ReLinkViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		if (_viewModel.ShowShow)
		{
			_viewModel.ReLinkTimeTextString = ScriptLocalization.Get("Relinktime") + StringCache.IntToString((int)(10 - (TimeUtility.UnixTimeNow() - UiIEventCondition.Get_serverConnection_ReConnectStartTime()) / 1000));
		}
	}

	protected override void DoSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_serverConnection_IsConnected, SetIsConnected, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_serverConnection_ReConnectCount, SetReConnectCount, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetReConnectCount(int arg1, int arg2)
	{
		_viewModel.ReLinkCountTextString = ScriptLocalization.Get("Relinkcount") + arg2;
	}

	private bool CheckIsAceClose()
	{
		if (_battleRoomContext.ace.IsRefresh)
		{
			return true;
		}
		return false;
	}

	private void SetIsConnected(bool arg1, bool arg2)
	{
		_viewModel.ShowShow = !arg2;
		_viewModel.DisconnectTextString = ScriptLocalization.Get("Relink");
		if (CheckIsAceClose())
		{
			_viewModel.ShowShow = false;
		}
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
}
