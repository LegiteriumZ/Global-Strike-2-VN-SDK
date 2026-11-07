using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Components.GameRule.Biochemical3;
using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical3;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical3;

[GameUiTest]
public class Biochemical3SelectVariantModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, IKeyboardResponder, ISetPlayerContext
{
	private Biochemical3SelectVariantViewModel _viewModel;

	private GameRuleContext _gameRuleContext;

	private SelectZombieComponent _selectZombie;

	private PlayerContext _playerContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
		_selectZombie = _gameRuleContext.selectZombie;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical3SelectVariantViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
			if (_selectZombie.Time > 0)
			{
				_selectZombie.Time -= _timeComponent.FrameInterval;
			}
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		SimpleNotify.Add(GetCareer, SetCareer, 1);
		SimpleNotify.Add(GetCareer, SetCareer, 2);
		SimpleNotify.Add(GetCareer, SetCareer, 3);
		SimpleNotify.Add(GetCareer, SetCareer, 4);
		SimpleNotify.Add(GetCareer, SetCareer, 5);
		SimpleNotify.Add(GetCareer, SetCareer, 6);
		SimpleNotify.Add(GetCurrentSelected, SetCurrentSelected);
		SimpleNotify.Add(GetTime, SetTime);
		SimpleNotify.Add(GetVisible, SetVisible);
	}

	private void SetVisible(bool arg1, int arg2)
	{
		_viewModel.ShowShow = arg1;
	}

	private bool GetVisible(int arg1)
	{
		if (_playerContext.isMyPlayer && PlayerCareerConstantUtility.IsDoun(_playerContext.myPlayerEntity.GetCareer()))
		{
			return _selectZombie.Time > 0;
		}
		return false;
	}

	private void SetTime(int arg1, int arg2)
	{
		_viewModel.TimeString = StringCache.IntToString(arg1);
	}

	private int GetTime(int arg1)
	{
		return _selectZombie.Time / 1000;
	}

	private void SetCurrentSelected(int selected, int index)
	{
		_viewModel.SetSelectShow(1, selected == 1);
		_viewModel.SetNumberSelectShow(1, selected == 1);
		_viewModel.SetSelectShow(2, selected == 2);
		_viewModel.SetNumberSelectShow(2, selected == 2);
		_viewModel.SetSelectShow(3, selected == 3);
		_viewModel.SetNumberSelectShow(3, selected == 3);
		_viewModel.SetSelectShow(4, selected == 4);
		_viewModel.SetNumberSelectShow(4, selected == 4);
		_viewModel.SetSelectShow(5, selected == 5);
		_viewModel.SetNumberSelectShow(5, selected == 5);
		_viewModel.SetSelectShow(6, selected == 6);
		_viewModel.SetNumberSelectShow(6, selected == 6);
	}

	private int GetCurrentSelected(int index)
	{
		return _selectZombie.Data?.CurrentId ?? 0;
	}

	private void SetCareer(string career, int index)
	{
		if (string.IsNullOrEmpty(career))
		{
			_viewModel.SetNohasShow(index, value: true);
			_viewModel.SetSelectImageShow(index, value: false);
			return;
		}
		_viewModel.SetNohasShow(index, value: false);
		_viewModel.SetSelectImageShow(index, value: true);
		_viewModel.SetSelectImageSprite(index, base.Loader.RetriveSprite("ui/halfloadedres/bio3SelectVariant", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/bio3SelectVariant/{career}.png", delegate(Sprite sprite)
		{
			_viewModel.SetSelectImageSprite(index, sprite);
		}));
	}

	private string GetCareer(int index)
	{
		SelectZombieData data = _selectZombie.Data;
		if (data != null)
		{
			switch (index)
			{
			case 1:
				return data.Career1;
			case 2:
				return data.Career2;
			case 3:
				return data.Career3;
			case 4:
				return data.Career4;
			case 5:
				return data.Career5;
			case 6:
				return data.Career6;
			}
		}
		return "";
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_viewModel.ShowShow)
		{
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (alphaOrKeypadDiff >= 1 && alphaOrKeypadDiff <= 6 && !_viewModel.GetNohasShow(alphaOrKeypadDiff))
			{
				_selectZombie.Time = 0;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}
}
