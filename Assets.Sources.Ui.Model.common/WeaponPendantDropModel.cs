using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class WeaponPendantDropModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext
{
	private WeaponPendantDropViewModel _viewModel;

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
		_viewModel = new WeaponPendantDropViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (UiIEventCondition.Get_weaponPendantDrop_Time() > 0)
			{
				_gameRuleContext.weaponPendantDrop.Time -= _timeComponent.FrameInterval;
				_viewModel.ShowShow = UiIEventCondition.Get_weaponPendantDrop_Time() > 0;
				_viewModel.ShowAlpha = (float)UiIEventCondition.Get_weaponPendantDrop_Time() / 1000f;
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.ShowShow = false;
		base.DoSubscribe();
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponPendantDrop_IsStormScore, SetIsStormScore, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponPendantDrop_Count, SetCount, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponPendantDrop_PendantId, SetPendantId, null, initinvoke: true, isFrameSeparation: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_weaponPendantDrop_Quality, SetQuality, null, initinvoke: true, isFrameSeparation: true);
	}

	private void SetQuality(int arg1, int arg2)
	{
		if (arg2 > 0)
		{
			base.Loader.RetriveSprite("ui/halfloadedres/weaponPendantDrop", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/weaponPendantDrop/quality_{arg2}.png", delegate(Sprite sprite)
			{
				_viewModel.QualitySprite = sprite;
			});
		}
	}

	private void SetPendantId(string arg1, string arg2)
	{
		if (!string.IsNullOrEmpty(arg2))
		{
			base.Loader.RetriveSprite("ui/halfloadedres/weaponPendantDrop", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/weaponPendantDrop/{arg2}.png", delegate(Sprite sprite)
			{
				_viewModel.IconSprite = sprite;
			});
		}
	}

	private void SetCount(int arg1, int arg2)
	{
		_viewModel.CountString = arg2.ToString();
	}

	private void SetIsStormScore(bool arg1, bool arg2)
	{
		if (arg2)
		{
			_viewModel.ScoreBackShow = true;
			_viewModel.QualityShow = false;
		}
		else
		{
			_viewModel.QualityShow = true;
			_viewModel.ScoreBackShow = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
