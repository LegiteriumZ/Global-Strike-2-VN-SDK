using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Rpg;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Rpg;

[GameUiTest]
public class RPGNanjiMarkModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private RPGNanjiMarkViewModel _viewModel;

	private float _showTime;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RPGNanjiMarkViewModel();
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
		_viewModel.RPGNanjiMarkShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_ninjiMark_NinjiHhurt, NinjiHurtChange);
	}

	[GameUiTestMethod]
	private void NinjiHurtChange(bool old, bool newval)
	{
		if (newval)
		{
			_gameRuleContext.ninjiMark.NinjiHhurt = false;
			_viewModel.RPGNanjiMarkShow = true;
			_viewModel.blockSize = new Vector2(900f, 900f);
			_showTime = 500f;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
		if (_viewModel.RPGNanjiMarkShow)
		{
			_showTime -= _timeComponent.FrameInterval;
			_viewModel.blockSize = new Vector2(_viewModel.blockSize.x - 5f, _viewModel.blockSize.y - 5f);
			if (_showTime < 0f)
			{
				_viewModel.RPGNanjiMarkShow = false;
			}
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
