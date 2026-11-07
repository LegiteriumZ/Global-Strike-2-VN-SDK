using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RpgSelectViewModel : AbstractModel, IPlaybackSystem
{
	private RpgSelectViewViewModel _viewModel;

	private float _currentPercent = 0.5f;

	private float _targetPercent;

	private const int BLUE_TEAM = 12;

	private const int RED_TEAM = 10;

	private FrameAnimaChip _effectChip = new FrameAnimaChip();

	private FrameAnimaChip _blueChip = new FrameAnimaChip();

	private FrameAnimaChip _redChip = new FrameAnimaChip();

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgSelectViewViewModel();
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
		_targetPercent = _currentPercent;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_SelectNodeData_SelectItemList_Visible, UpdateSelectVisible, _viewModel.RpgSelectViewObj, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_otherProgress_ProgressVal, UpdateProgress, _viewModel.RpgSelectViewObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_Player_HasSelectCanBuy, UpdateCanBuy, _viewModel.RpgSelectViewObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_Team, UpdateTeam, _viewModel.RpgSelectViewObj, initinvoke: true);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.Remove(_viewModel.RpgSelectViewObj);
	}

	private void InitChips()
	{
		_effectChip.IsLoop = true;
		_effectChip.Path = "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_pro/effect_pro";
		_effectChip.StartIndex = 0;
		_effectChip.Count = 15;
		_effectChip.Init();
		_blueChip.IsLoop = true;
		_blueChip.Path = "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_head_blue/effect_head_blue";
		_blueChip.StartIndex = 0;
		_blueChip.Count = 11;
		_blueChip.Init();
		_redChip.IsLoop = true;
		_redChip.Path = "Assets/Res/Assets/ui/GameGUIRes/freeRpg_110000Model/effect_head_red/effect_head_red";
		_redChip.StartIndex = 0;
		_redChip.Count = 11;
		_redChip.Init();
	}

	private void UpdateChips()
	{
		float num = _targetPercent - _currentPercent;
		num = num * (float)_timeComponent.FrameInterval * 0.001f;
		_currentPercent += num;
		_viewModel.red_proFillamount = _currentPercent;
		_effectChip.Update(_timeComponent);
		_redChip.Update(_timeComponent);
		_blueChip.Update(_timeComponent);
		base.Loader.RetriveSprite("ui/freerpg_110000model", _redChip.Value, _viewModel.red_frameImage);
		base.Loader.RetriveSprite("ui/freerpg_110000model", _blueChip.Value, _viewModel.blue_frameImage);
		base.Loader.RetriveSprite("ui/freerpg_110000model", _effectChip.Value, _viewModel.effect_proImage);
		_viewModel.effect_proAnchoredposition = new Vector2(_viewModel.red_proSize.x * (_currentPercent - 0.5f) + 104f, -60f);
	}

	private void UpdateProgress(float old, float newval)
	{
		_targetPercent = newval / 1000f;
	}

	private void UpdateTeam(int old, int newval)
	{
		_viewModel.red_frameShow = newval == 10;
		_viewModel.blue_frameShow = newval == 12;
	}

	private void UpdateCanBuy(bool old, bool newval)
	{
		if (!UiIEventCondition.Get_SelectNodeData_SelectItemList_Visible())
		{
			BuyTipVisible(newval);
		}
	}

	private void UpdateSelectVisible(bool old, bool newval)
	{
		if (newval)
		{
			BuyTipVisible(show: false);
		}
		else
		{
			BuyTipVisible(UiIEventCondition.Get_Player_HasSelectCanBuy());
		}
	}

	[GameUiTestMethod]
	private void BuyTipVisible(bool show)
	{
		_viewModel.canbuytipShow = show;
	}
}
