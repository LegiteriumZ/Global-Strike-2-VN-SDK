using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Modules.Ui.UiEventCondition;
using NetData;
using share.constant;

public class commonPlayerExpressionProvider : IcommonPlayerExpressionProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	protected PlayerContext _playerContext;

	public commonPlayerExpressionProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool hasSelectItem1()
	{
		return hasSelectItem(1);
	}

	public string getItem1Url()
	{
		return getItemUrl(1);
	}

	public float selectItem1()
	{
		selectItem(1);
		return 0f;
	}

	public float mouseLeftClick()
	{
		if (hasTacticsSound() || _gameRuleContext.personalized.PersonalType > 1)
		{
			_gameRuleContext.personalized.PersonalType--;
		}
		return 0f;
	}

	public float mouseRightClick()
	{
		_gameRuleContext.personalized.PersonalType++;
		return 0f;
	}

	public bool hasSelectItem2()
	{
		return hasSelectItem(2);
	}

	public string getItem2Url()
	{
		return getItemUrl(2);
	}

	public float selectItem2()
	{
		selectItem(2);
		return 0f;
	}

	public bool hasSelectItem3()
	{
		return hasSelectItem(3);
	}

	public string getItem3Url()
	{
		return getItemUrl(3);
	}

	public float selectItem3()
	{
		selectItem(3);
		return 0f;
	}

	public bool hasSelectItem4()
	{
		return hasSelectItem(4);
	}

	public string getItem4Url()
	{
		return getItemUrl(4);
	}

	public float selectItem4()
	{
		selectItem(4);
		return 0f;
	}

	public bool hasSelectItem5()
	{
		return hasSelectItem(5);
	}

	public string getItem5Url()
	{
		return getItemUrl(5);
	}

	public float selectItem5()
	{
		selectItem(5);
		return 0f;
	}

	public float selectItem0()
	{
		selectItem(0);
		return 0f;
	}

	public bool isItem1Selected()
	{
		return isItemSelected(1);
	}

	public bool isItem2Selected()
	{
		return isItemSelected(2);
	}

	public bool isItem3Selected()
	{
		return isItemSelected(3);
	}

	public bool isItem4Selected()
	{
		return isItemSelected(4);
	}

	public bool isItem5Selected()
	{
		return isItemSelected(5);
	}

	public bool getGUIVisible()
	{
		if (_battleRoomContext.roomData.Data.RaceType == 17000)
		{
			return false;
		}
		updateVisiable();
		if (_gameRuleContext.personalized.ExpressionVisiable)
		{
			if (_gameRuleContext.personalized.PersonalType != 1)
			{
				return false;
			}
		}
		else if (!_gameRuleContext.personalized.AutoHideExpression)
		{
			_gameRuleContext.personalized.ExpressionVisiable = true;
			_gameRuleContext.personalized.ShowCareer = UiIEventCondition.Get_uiMyPlayer_Career();
			_gameRuleContext.personalized.PersonalType = 1;
		}
		return _gameRuleContext.personalized.ExpressionVisiable;
	}

	public float hideGUI()
	{
		hideGui(autoHide: false);
		int expressionMouseSelectIndex = _gameRuleContext.personalized.ExpressionMouseSelectIndex;
		selectItem(0);
		if (hasSelectItem(expressionMouseSelectIndex))
		{
			onlyUseItem(expressionMouseSelectIndex);
		}
		return 0f;
	}

	public float useItem1()
	{
		useItem(1);
		return 0f;
	}

	public float useItem2()
	{
		useItem(2);
		return 0f;
	}

	public float useItem3()
	{
		useItem(3);
		return 0f;
	}

	public float useItem4()
	{
		useItem(4);
		return 0f;
	}

	public float useItem5()
	{
		useItem(5);
		return 0f;
	}

	public float useItem6()
	{
		return 0f;
	}

	public float useItem7()
	{
		return 0f;
	}

	public float useItem8()
	{
		return 0f;
	}

	public bool hasTacticsSound()
	{
		if (RuleUtilty.IsPve(_battleRoomContext.roomData.Data.RaceType) || 39 == _battleRoomContext.roomData.Data.RaceType)
		{
			return true;
		}
		return false;
	}

	private void useItem(int index)
	{
		if (hasSelectItem(index) && _gameRuleContext.personalized.ExpressionVisiable)
		{
			hideGui(autoHide: true);
			onlyUseItem(index);
			_gameRuleContext.personalized.ExpressionMouseSelectIndex = 0;
		}
	}

	private void onlyUseItem(int index)
	{
		GameEmojiData gameEmojiData = new GameEmojiData();
		_battleRoomContext.playerInfo.PersonalizedDic.TryGetValue(1, out var value);
		if (value != null)
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] != null && value[i].Id == index - 1)
				{
					gameEmojiData.CodeName = value[i].Name;
					break;
				}
			}
		}
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(38, gameEmojiData);
	}

	private bool isItemSelected(int index)
	{
		return _gameRuleContext.personalized.ExpressionMouseSelectIndex == index;
	}

	private void selectItem(int index)
	{
		_gameRuleContext.personalized.ExpressionMouseSelectIndex = index;
	}

	private string getItemUrl(int index)
	{
		_battleRoomContext.playerInfo.PersonalizedDic.TryGetValue(1, out var value);
		if (value != null)
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] != null && value[i].Id == index - 1)
				{
					return "/ui/GameGUIRes/halfLoadedRes/expression/" + value[i].Name;
				}
			}
		}
		return "";
	}

	private bool hasSelectItem(int index)
	{
		_battleRoomContext.playerInfo.PersonalizedDic.TryGetValue(1, out var value);
		if (value != null)
		{
			for (int i = 0; i < value.Count; i++)
			{
				if (value[i] != null && value[i].Id == index - 1)
				{
					return true;
				}
			}
		}
		return false;
	}

	private void hideGui(bool autoHide)
	{
		_gameRuleContext.personalized.ExpressionVisiable = false;
		_gameRuleContext.personalized.AutoHideExpression = autoHide;
		_gameRuleContext.personalized.ShowCareer = null;
	}

	private void updateVisiable()
	{
		if (_playerContext.myPlayerEntity == null)
		{
			_gameRuleContext.personalized.ExpressionVisiable = false;
		}
		if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0 || UiIEventCondition.Get_uiMyPlayer_IsDead())
		{
			hideGui(autoHide: true);
		}
		else if (!string.IsNullOrEmpty(_gameRuleContext.personalized.ShowCareer) && !_gameRuleContext.personalized.ShowCareer.Equals(UiIEventCondition.Get_uiMyPlayer_Career()))
		{
			hideGui(autoHide: true);
		}
		else if (!PlayerCareerUtil.IsHumanity(UiIEventCondition.Get_uiMyPlayer_Career()))
		{
			hideGui(autoHide: true);
		}
	}
}
