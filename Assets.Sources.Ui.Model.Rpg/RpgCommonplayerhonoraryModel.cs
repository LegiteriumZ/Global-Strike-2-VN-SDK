using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RpgCommonplayerhonoraryModel : AbstractModel, IPlaybackSystem
{
	private RpgCommonplayerhonoraryViewModel _viewModel;

	private static AssetInfo _aceAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/ace.png");

	private static AssetInfo _2NdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/2nd.png");

	private static AssetInfo _3NdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/3nd.png");

	private static AssetInfo _mvpAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/mvp.png");

	private static AssetInfo _kdAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/kd.png");

	private static AssetInfo _wetAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/wet.png");

	private static AssetInfo _bountyhunterAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/bountyhunter.png");

	private static AssetInfo _blasterAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/blaster.png");

	private static AssetInfo _specialistsAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/hononary/specialists.png");

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgCommonplayerhonoraryViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_CameraOwner_KillInfoData, SetKillInfoData, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_cameraOwnerData_PlayerId, SetPlayerId, null, initinvoke: true);
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
		int index = 1;
		index = SetHonoraryImage(killInfo.Ace, index, ref _aceAsset);
		index = SetHonoraryImage(killInfo.Ace2, index, ref _2NdAsset);
		index = SetHonoraryImage(killInfo.Ace3, index, ref _3NdAsset);
		index = SetHonoraryImage(killInfo.Mvp, index, ref _mvpAsset);
		index = SetHonoraryImage(killInfo.KdKing, index, ref _kdAsset);
		index = SetHonoraryImage(killInfo.Nurse, index, ref _wetAsset);
		index = SetHonoraryImage(killInfo.GoldHunter, index, ref _bountyhunterAsset);
		index = SetHonoraryImage(killInfo.MaxHidePack, index, ref _blasterAsset);
		return SetHonoraryImage(killInfo.MaxOpenPack, index, ref _specialistsAsset);
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
