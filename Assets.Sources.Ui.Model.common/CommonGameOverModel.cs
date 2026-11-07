using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Chip;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

public class CommonGameOverModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	private CommongameoverViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private static AssetInfo _winAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/gameover/gamewin.png");

	private static AssetInfo _loseAsset = new AssetInfo("ui/common", "Assets/Res/Assets/ui/GameGUIRes/common/gameover/gamelose.png");

	private static AssetInfo _winAssetRpgDuelModel = new AssetInfo("ui/rpgDuelModel", "Assets/Res/Assets/ui/GameGUIRes/rpgDuelModel/message/win.png");

	private static AssetInfo _loseAssetRpgDuelModel = new AssetInfo("ui/rpgDuelModel", "Assets/Res/Assets/ui/GameGUIRes/rpgDuelModel/message/defeat.png");

	protected long GameOverTime;

	private ActiveChip _panelActiveChip = new ActiveChip();

	private AlphaChip _panelAlphaChip = new AlphaChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CommongameoverViewModel();
	}

	public virtual void OnPlayback()
	{
		UpdateChips();
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_gameOverData_IsGameOver, SetIsGameOver, null, initinvoke: true);
	}

	private void SetIsGameOver(bool ov, bool visible)
	{
		if (visible)
		{
			UpdateGameOver();
		}
	}

	protected virtual void UpdateGameOver()
	{
		_viewModel.PanelShow = true;
		_viewModel.WinnerNameShow = false;
		if (TimeUtility.UnixTimeNow() - GameOverTime < 1000)
		{
			return;
		}
		if (_gameRuleContext.currentRule.Rule.IsRpgDuel())
		{
			if (UiIEventCondition.Get_gameOverData_IsWin())
			{
				_viewModel.GameOverImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_winAssetRpgDuelModel, delegate(Sprite sprite)
				{
					_viewModel.GameOverImageSprite = sprite;
				});
			}
			else
			{
				_viewModel.GameOverImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_loseAssetRpgDuelModel, delegate(Sprite sprite)
				{
					_viewModel.GameOverImageSprite = sprite;
				});
			}
		}
		else if (UiIEventCondition.Get_gameOverData_IsWin())
		{
			_viewModel.GameOverImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_winAsset, delegate(Sprite sprite)
			{
				_viewModel.GameOverImageSprite = sprite;
			});
		}
		else
		{
			_viewModel.GameOverImageSprite = ((UiResourcesLoader)base.Loader).RetriveSprite(_loseAsset, delegate(Sprite sprite)
			{
				_viewModel.GameOverImageSprite = sprite;
			});
		}
		SetChips();
	}

	protected void SetChips()
	{
		_panelActiveChip.Time = 3000;
		_panelAlphaChip.Alpha = 1f;
		_panelAlphaChip.Delay = 1000f;
		_panelAlphaChip.Speed = -0.5f;
	}

	private void InitChips()
	{
		_panelActiveChip.Time = 0;
		_panelAlphaChip.Alpha = 0f;
		_panelAlphaChip.Speed = 0f;
	}

	private void UpdateChips()
	{
		_viewModel.PanelShow = _panelActiveChip.Update(_timeComponent);
		_viewModel.PanelAlpha = _panelAlphaChip.Update(_timeComponent);
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
	}
}
