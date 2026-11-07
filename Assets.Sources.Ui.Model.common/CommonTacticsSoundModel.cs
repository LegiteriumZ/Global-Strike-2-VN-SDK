using Assets.Sources.Framework;
using Assets.Sources.Info.Sound;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Common;
using Assets.Sources.Utils.Chip;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Extensions;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Common;

public class CommonTacticsSoundModel : AbstractModel, IPlaybackSystem, IKeyboardResponder, ISetGameRuleContext, ISetMessageContext, ICursorControl, ISetBattleRoomContext
{
	private CommontacticssoundViewModel _viewModel;

	private NotifyGroup _notifyGroup = new NotifyGroup();

	private bool[] _selectedEnter = new bool[9];

	private string _career;

	private static AssetInfo _leftTacticalSoundAsset = new AssetInfo("ui/halfloadedres/playerPersonalized", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerPersonalized/leftTacticalSound.png");

	private static AssetInfo _rightPlayerSoundAsset = new AssetInfo("ui/halfloadedres/playerPersonalized", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerPersonalized/rightPlayerSound.png");

	private static AssetInfo _tacticalSoundTitleAsset = new AssetInfo("ui/halfloadedres/playerPersonalized", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerPersonalized/tacticalSoundTitle.png");

	private static AssetInfo _playerSoundTitleAsset = new AssetInfo("ui/halfloadedres/playerPersonalized", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/playerPersonalized/playerSoundTitle.png");

	private ActiveChip _openGuideActiveChip = new ActiveChip();

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new CommontacticssoundViewModel();
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
		HidePanel();
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_Team, SetTeam, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(GetTacticsType, SetTacticsType, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true));
		_notifyGroup.Add(NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true));
		_notifyGroup.SetSuspend(suspend: true);
		NotifyManager.MakeTempNotify(GetShow, SetShow, null, initinvoke: true);
		_viewModel.CreateTriggerEntry(_viewModel.ShowTriggers, EventTriggerType.PointerClick, OnPointClick);
		for (int j = 0; j < 8; j++)
		{
			_viewModel.SetSelectedShow(j + 1, value: false);
			_selectedEnter[j + 1] = false;
			int i1 = j;
			_viewModel.CreateTriggerEntry(_viewModel.GetSelectTriggers(j + 1), EventTriggerType.PointerEnter, delegate
			{
				_viewModel.SetSelectedShow(i1 + 1, TacticsSoundModel.Instance.HasSound(_gameRuleContext.personalized.PersonalType, i1 + 1));
				_selectedEnter[i1 + 1] = true;
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetSelectTriggers(j + 1), EventTriggerType.PointerExit, delegate
			{
				_viewModel.SetSelectedShow(i1 + 1, value: false);
				_selectedEnter[i1 + 1] = false;
			});
			_viewModel.CreateTriggerEntry(_viewModel.GetSelectTriggers(j + 1), EventTriggerType.PointerClick, OnPointClick);
		}
	}

	private void SetCareer(string arg1, string arg2)
	{
		if (_career != arg2)
		{
			_career = arg2;
			HidePanel();
		}
	}

	private void SetIsDead(bool arg1, bool arg2)
	{
		if (arg2)
		{
			HidePanel();
		}
	}

	private bool GetShow()
	{
		return _gameRuleContext.personalized.PersonalType != 1;
	}

	private void SetShow(bool arg1, bool arg2)
	{
		if (arg2)
		{
			ShowPanel();
		}
		else
		{
			HidePanel();
		}
	}

	private void OnPointClick(BaseEventData v)
	{
		switch (((PointerEventData)v).button)
		{
		case PointerEventData.InputButton.Left:
			if (_gameRuleContext.personalized.PersonalType == 2)
			{
				_gameRuleContext.personalized.PersonalType = 1;
			}
			break;
		case PointerEventData.InputButton.Right:
			if (_gameRuleContext.personalized.PersonalType == 0)
			{
				_gameRuleContext.personalized.PersonalType = 1;
			}
			break;
		}
	}

	private void SetTacticsType(int arg1, int arg2)
	{
		switch (arg2)
		{
		case 0:
			this.GetLoader().RetriveSprite(_tacticalSoundTitleAsset, delegate(Sprite sprite)
			{
				_viewModel.TitleSprite = sprite;
			});
			_viewModel.LeftTipsShow = false;
			_viewModel.RightTipsShow = true;
			this.GetLoader().RetriveSprite(_rightPlayerSoundAsset, delegate(Sprite sprite)
			{
				_viewModel.RightTipsSprite = sprite;
			});
			break;
		case 2:
			this.GetLoader().RetriveSprite(_playerSoundTitleAsset, delegate(Sprite sprite)
			{
				_viewModel.TitleSprite = sprite;
			});
			_viewModel.LeftTipsShow = true;
			_viewModel.RightTipsShow = false;
			this.GetLoader().RetriveSprite(_leftTacticalSoundAsset, delegate(Sprite sprite)
			{
				_viewModel.RightTipsSprite = sprite;
			});
			break;
		}
		for (int i = 0; i < 8; i++)
		{
			_viewModel.SetSelectedShow(i + 1, _selectedEnter[i + 1] && TacticsSoundModel.Instance.HasSound(_gameRuleContext.personalized.PersonalType, i + 1));
		}
		SetUi();
	}

	private int GetTacticsType()
	{
		return _gameRuleContext.personalized.PersonalType;
	}

	private void SetTeam(int arg1, int arg2)
	{
		TacticsSoundModel.Instance.AddSoundList(UiIEventCondition.Get_uiRoomData_RaceType(), UiIEventCondition.Get_gameInfo_IsWoman(), arg2);
		SetUi();
	}

	private void SetUi()
	{
		switch (_gameRuleContext.personalized.PersonalType)
		{
		case 0:
		{
			for (int j = 0; j < 8; j++)
			{
				_viewModel.SetIconShow(j + 1, j < TacticsSoundModel.Instance.TacticsSoundListLength - 3);
				_viewModel.SetTextShow(j + 1, j < TacticsSoundModel.Instance.TacticsSoundListLength - 3);
				_viewModel.SetTextString(j + 1, TacticsSoundModel.Instance.GetTacticsSoundTextByIndex(j + 3));
			}
			break;
		}
		case 2:
		{
			_battleRoomContext.playerInfo.PersonalizedDic.TryGetValue(2, out var value);
			for (int i = 0; i < 8; i++)
			{
				PersonalityData personalityData = ((value != null && i < value.Count) ? value[i] : null);
				_viewModel.SetIconShow(i + 1, personalityData != null);
				_viewModel.SetTextShow(i + 1, personalityData != null);
				_viewModel.SetTextString(i + 1, (personalityData != null) ? personalityData.Name : "");
			}
			break;
		}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	private void HidePanel()
	{
		_viewModel.ShowRootshow = false;
		_gameRuleContext.personalized.PersonalType = 1;
	}

	private void ShowPanel()
	{
		_openGuideActiveChip.Time = 0;
		_viewModel.ShowRootshow = false;
		_viewModel.ShowRootshow = true;
		_notifyGroup.SetSuspend(suspend: false);
		for (int i = 0; i < 8; i++)
		{
			_viewModel.SetSelectedShow(i + 1, value: false);
			_selectedEnter[i + 1] = false;
		}
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.T)
		{
			if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
			{
				return false;
			}
			if (UiIEventCondition.Get_uiMyPlayer_IsDead())
			{
				return false;
			}
		}
		if (_viewModel.ShowRootshow)
		{
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (TacticsSoundModel.Instance.HasSound(_gameRuleContext.personalized.PersonalType, alphaOrKeypadDiff))
			{
				TacticsSoundModel.Instance.SendSound(_gameRuleContext.personalized.PersonalType, alphaOrKeypadDiff - 1);
				HidePanel();
				_notifyGroup.SetSuspend(suspend: true);
			}
			if (alphaOrKeypadDiff >= 1 && alphaOrKeypadDiff <= 8)
			{
				return true;
			}
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		if (key == KeyCode.T)
		{
			if (_viewModel.ShowRootshow)
			{
				for (int i = 0; i < 8; i++)
				{
					if (_viewModel.GetSelectedShow(i + 1))
					{
						TacticsSoundModel.Instance.SendSound(_gameRuleContext.personalized.PersonalType, i);
						break;
					}
				}
				_notifyGroup.SetSuspend(suspend: true);
			}
			HidePanel();
		}
		if (_viewModel.ShowRootshow)
		{
			int alphaOrKeypadDiff = key.GetAlphaOrKeypadDiff();
			if (alphaOrKeypadDiff >= 1 && alphaOrKeypadDiff <= 8)
			{
				return true;
			}
		}
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

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public void SetMessageContext(MessageContext context)
	{
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowRootshow)
		{
			return 0;
		}
		return 1024;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}
}
