using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.common;

public class ObserverPlayerDataModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	private ObserverplayerdataViewModel _viewModel;

	private NotifyGroup _notifyGroup = new NotifyGroup();

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
		_viewModel = new ObserverplayerdataViewModel();
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
		_viewModel.PanelShow = false;
		if (!UiIEventCondition.Get_uiRoomData_IsObserver() && _battleRoomContext.roomData.Data.RaceType != 100)
		{
			NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_observerInfo_ObserverInfo, SetInfoDic, null, initinvoke: true);
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true);
			NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_Observer, SetObserver, null, initinvoke: true);
			_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_observerInfo_ObserverName, SetObserverName, null, initinvoke: true));
		}
	}

	private void SetIsDead(bool arg1, bool arg2)
	{
		AddUpdateHandler(CheckVisible);
	}

	private void CheckVisible(int idx)
	{
		bool flag = UiIEventCondition.Get_observerInfo_ObserverInfo() != null && UiIEventCondition.Get_cameraOwnerData_Observer() > 0;
		_viewModel.PanelShow = flag;
		_notifyGroup.SetSuspend(!flag);
	}

	private void SetObserverName(string arg1, string arg2)
	{
		_viewModel.PlayerNameString = arg2;
	}

	private void SetObserver(int arg1, int arg2)
	{
		AddUpdateHandler(OnObserverInfo);
		AddUpdateHandler(CheckVisible);
	}

	private void SetInfoDic(ObserverInfoData arg1, ObserverInfoData arg2)
	{
		AddUpdateHandler(OnObserverInfo);
		AddUpdateHandler(CheckVisible);
	}

	private void OnObserverInfo(int idx)
	{
		ObserverInfoData observerInfo_ObserverInfo = UiIEventCondition.Get_observerInfo_ObserverInfo();
		if (observerInfo_ObserverInfo != null)
		{
			_viewModel.KdString = observerInfo_ObserverInfo.Kd.ToString("F");
			_viewModel.HeadKillString = StringCache.IntToString((int)observerInfo_ObserverInfo.HeadKillEfficiency);
			_viewModel.RankString = StringCache.IntToString(observerInfo_ObserverInfo.Rank);
			_viewModel.MVPString = StringCache.IntToString(observerInfo_ObserverInfo.MvpCount);
			_viewModel.SkillSoucreString = observerInfo_ObserverInfo.TechScore.ToString("F2");
			_viewModel.SuccessString = StringCache.IntToString((int)observerInfo_ObserverInfo.WinRate);
			_viewModel.RaceRankSectImageShow = false;
			base.Loader.RetriveSprite("ui/halfloadedres/playerRaceRankSect", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerRaceRankSect/{observerInfo_ObserverInfo.RaceRankSect}_back.png", delegate(Sprite v)
			{
				_viewModel.BackImageSprite = v;
			});
			_viewModel.RaceLvTextString = HonorUtility.GetRankLvName(observerInfo_ObserverInfo.RaceRankSect, observerInfo_ObserverInfo.RaceRankLv);
			_viewModel.TeamNameString = observerInfo_ObserverInfo.TeamName;
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
