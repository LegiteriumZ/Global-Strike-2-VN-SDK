using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Info.Res;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Common;

[GameUiTest]
public class HowToPlayModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext, ICursorControl, IKeyboardResponder
{
	private HowToPlayViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new HowToPlayViewModel();
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
		_viewModel.CreateTriggerEntry(_viewModel.OkTriggers, EventTriggerType.PointerClick, HowToPlayClick);
		NotifyManager.MakeNotify(69, UiIEventCondition.Get_menu_HowToPlay, SetShowHowToPlay);
		_viewModel.ShowShow = false;
		if (RuleUtilty.IsHowToPlayerShow(_battleRoomContext.roomData.Data.RaceType, _battleRoomContext.roomData.Data.FreeType))
		{
			LoadXml();
		}
		else
		{
			Destory();
		}
	}

	private void LoadXml()
	{
		base.Loader.Load("ui/howtoplayer", "Assets/Res/Assets/ui/GameGUIRes/howToPlayer/howToPlayerConfig.xml", delegate(Object res)
		{
			HowToPlayerConfig howToPlayerConfig = new HowToPlayerConfig();
			howToPlayerConfig.SyncParse(res.ToString());
			string text = howToPlayerConfig.TryGetValue(_battleRoomContext.roomData.Data.FreeType);
			if (text != "")
			{
				base.Loader.RetriveSprite("ui/howtoplayer", "Assets/Res/Assets/ui/GameGUIRes/howToPlayer/" + text, delegate(Sprite sprite)
				{
					_viewModel.mechWarriorSprite2 = sprite;
				});
			}
		});
	}

	private void SetShowHowToPlay(bool ov, bool show)
	{
		_viewModel.ShowShow = show;
	}

	private void HowToPlayClick(BaseEventData obj)
	{
		NotifyManager.ForceInvoke(70);
		_viewModel.ShowShow = false;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow && CloseDelay <= 0)
		{
			return 0;
		}
		return 128;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.Escape)
		{
			_viewModel.ShowShow = false;
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
}
