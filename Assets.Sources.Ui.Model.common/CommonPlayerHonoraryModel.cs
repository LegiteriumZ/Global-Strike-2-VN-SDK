using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class CommonPlayerHonoraryModel : AbstractModel, IPlaybackSystem
{
	private CommonplayerhonoraryViewModel _viewModel;

	private static AssetInfo _aceAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/ace.png");

	private static AssetInfo _mechwarriorModelAceAsset = new AssetInfo("ui/mechwarriorModel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/hononary/ace.png");

	private static AssetInfo _2NdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/2nd.png");

	private static AssetInfo _3NdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/3nd.png");

	private static AssetInfo _mvpAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/mvp.png");

	private static AssetInfo _mechwarriorModelmvpAsset = new AssetInfo("ui/mechwarriorModel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/hononary/mvp.png");

	private static AssetInfo _kdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/kd.png");

	private static AssetInfo _mechwarriorModelkdAsset = new AssetInfo("ui/mechwarriorModel", "Assets/Res/Assets/ui/GameGUIRes/mechwarriorModel/hononary/kd.png");

	private static AssetInfo _wetAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/wet.png");

	private static AssetInfo _bountyhunterAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/bountyhunter.png");

	private static AssetInfo _blasterAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/blaster.png");

	private static AssetInfo _specialistsAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/specialists.png");

	private static AssetInfo _competeKingAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/competeKing.png");

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CommonplayerhonoraryViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_CameraOwner_KillInfoData, SetKillInfoData, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_PlayerId, SetPlayerId, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_observerInfo_ObserverInfo, SetInfoDic, null, initinvoke: true);
	}

	private void SetIsDead(bool arg1, bool arg2)
	{
		AddUpdateHandler(CheckVisible);
	}

	private void CheckVisible(int idx)
	{
		bool gloryShow = UiIEventCondition.Get_observerInfo_ObserverInfo() != null && UiIEventCondition.Get_cameraOwnerData_Observer() > 0;
		_viewModel.GloryShow = gloryShow;
		ObserverInfoData observerInfo_ObserverInfo = UiIEventCondition.Get_observerInfo_ObserverInfo();
		if (observerInfo_ObserverInfo != null)
		{
			base.Loader.RetriveSprite("ui/halfloadedres/playerRaceRankSect", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerRaceRankSect/raceranksect{observerInfo_ObserverInfo.RaceRankSect}.png", delegate(Sprite v)
			{
				_viewModel.IconSprite = v;
			});
			_viewModel.NameString = HonorUtility.GetRankLvName(observerInfo_ObserverInfo.RaceRankSect, observerInfo_ObserverInfo.RaceRankLv);
		}
	}

	private void SetInfoDic(ObserverInfoData arg1, ObserverInfoData arg2)
	{
		AddUpdateHandler(CheckVisible);
	}

	private void SetPlayerId(int ov, int id)
	{
		if (id > 0)
		{
			SetKillInfoData(null, UiIEventCondition.Get_CameraOwner_KillInfoData());
		}
	}

	private void SetKillInfoData(OneKillInfoData ov, OneKillInfoData data)
	{
		for (int i = ((data == null) ? 1 : UpdateHonoraryImage(data)); i <= 5; i++)
		{
			_viewModel.SetHonorShow(i, value: false);
		}
	}

	protected virtual int UpdateHonoraryImage(OneKillInfoData killInfo)
	{
		bool num = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType == 29;
		AssetInfo asset = (num ? _mechwarriorModelAceAsset : _aceAsset);
		AssetInfo asset2 = (num ? _mechwarriorModelmvpAsset : _kdAsset);
		AssetInfo asset3 = (num ? _mechwarriorModelmvpAsset : _mvpAsset);
		int index = 1;
		index = SetHonoraryImage(killInfo.Ace, index, ref asset);
		index = SetHonoraryImage(killInfo.Ace2, index, ref _2NdAsset);
		index = SetHonoraryImage(killInfo.Ace3, index, ref _3NdAsset);
		index = SetHonoraryImage(killInfo.Mvp, index, ref asset3);
		index = SetHonoraryImage(killInfo.KdKing, index, ref asset2);
		index = SetHonoraryImage(killInfo.Nurse, index, ref _wetAsset);
		index = SetHonoraryImage(killInfo.GoldHunter, index, ref _bountyhunterAsset);
		index = SetHonoraryImage(killInfo.MaxHidePack, index, ref _blasterAsset);
		index = SetHonoraryImage(killInfo.MaxOpenPack, index, ref _specialistsAsset);
		return SetHonoraryImage(killInfo.CompeteKing, index, ref _competeKingAsset);
	}

	protected int SetHonoraryImage(bool flag, int index, ref AssetInfo asset)
	{
		if (flag && index <= 5)
		{
			_viewModel.SetHonorShow(index, value: true);
			int index2 = index;
			this.GetLoader().RetriveSprite(asset, delegate(Sprite sprite)
			{
				_viewModel.SetHonorImageSprite(index2, sprite);
				_viewModel.CallHonorImageNtvsize(index2);
			});
			index++;
		}
		return index;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
