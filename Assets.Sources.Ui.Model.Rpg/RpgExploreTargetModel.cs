using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

public class RpgExploreTargetModel : AbstractModel, IPlaybackSystem
{
	private RpgExploreTargetViewModel _viewModel;

	private static AssetInfo[] _assets = new AssetInfo[9]
	{
		default(AssetInfo),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips1.png"),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips2.png"),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips3.png"),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips4.png"),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips5.png"),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips6.png"),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips7.png"),
		new AssetInfo("ui/rpgmodel", "Assets/Res/Assets/ui/GameGUIRes/rpgModel/explore/exploreTips8.png")
	};

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgExploreTargetViewModel();
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
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_kingTreasuryData_Coin, SetCoin, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_kingTreasuryData_Wave, SetWave, null, initinvoke: true);
	}

	private void SetCoin(int ov, int coin)
	{
		_viewModel.RewardTextString = coin.ToString();
	}

	private void SetWave(int ov, int wave)
	{
		_viewModel.TipsSprite = this.GetLoader().RetriveSprite(_assets[wave], delegate(Sprite sprite)
		{
			_viewModel.TipsSprite = sprite;
		});
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
