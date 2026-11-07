using Assets.Sources.Components.GameRule.Biochemical3;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Utils.Chip;
using NetData;

public class bigheadModelHeroSelectProvider : IbigheadModelHeroSelectProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private SelectZombieComponent _bigHeroSelectData;

	private int _select;

	private TimeComponent time;

	private ActiveChip _gameTipActiveChip = new ActiveChip();

	private bool isShow;

	public bigheadModelHeroSelectProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_bigHeroSelectData = _gameRuleContext.selectZombie;
	}

	public void OnFrame(TimeComponent time)
	{
		_gameTipActiveChip.Update(time);
		if (_bigHeroSelectData.Time > 0 && !isShow)
		{
			isShow = true;
		}
	}

	public bool NoHero(int index)
	{
		if (_bigHeroSelectData.Data == null)
		{
			return true;
		}
		return index switch
		{
			0 => string.IsNullOrEmpty(_bigHeroSelectData.Data.Career1), 
			1 => string.IsNullOrEmpty(_bigHeroSelectData.Data.Career2), 
			2 => string.IsNullOrEmpty(_bigHeroSelectData.Data.Career3), 
			_ => true, 
		};
	}

	public string SetHero(int index)
	{
		if (_bigHeroSelectData.Data == null)
		{
			return "";
		}
		return index switch
		{
			0 => "/ui/GameGUIRes/halfLoadedRes/HeroHead/" + _bigHeroSelectData.Data.Career1, 
			1 => "/ui/GameGUIRes/halfLoadedRes/HeroHead/" + _bigHeroSelectData.Data.Career2, 
			2 => "/ui/GameGUIRes/halfLoadedRes/HeroHead/" + _bigHeroSelectData.Data.Career3, 
			_ => "", 
		};
	}

	public bool SeleHero(int index)
	{
		if (_bigHeroSelectData.Data == null)
		{
			return false;
		}
		return _bigHeroSelectData.Data.CurrentId - 1 == index;
	}

	public bool IsShow()
	{
		if (_gameTipActiveChip.Time < 0)
		{
			isShow = false;
		}
		if (!PlayerCareerConstantUtility.IsHumanity(UiIEventCondition.Get_uiMyPlayer_Career()))
		{
			_gameTipActiveChip.Time = 0;
			return false;
		}
		if (isShow)
		{
			return _gameTipActiveChip.Time > 0;
		}
		return false;
	}

	public float Select1()
	{
		if (_bigHeroSelectData.Data == null)
		{
			return 0f;
		}
		if (!string.IsNullOrEmpty(_bigHeroSelectData.Data.Career1))
		{
			SendCurrentId(1);
		}
		return 0f;
	}

	public float Select2()
	{
		if (_bigHeroSelectData.Data == null)
		{
			return 0f;
		}
		if (!string.IsNullOrEmpty(_bigHeroSelectData.Data.Career2))
		{
			SendCurrentId(2);
		}
		return 0f;
	}

	public float Select3()
	{
		if (_bigHeroSelectData.Data == null)
		{
			return 0f;
		}
		if (!string.IsNullOrEmpty(_bigHeroSelectData.Data.Career3))
		{
			SendCurrentId(3);
		}
		return 0f;
	}

	public float HideUI()
	{
		if (_gameTipActiveChip.Time > 0)
		{
			_gameTipActiveChip.Time = 0;
		}
		else
		{
			_gameTipActiveChip.Time = 10000;
		}
		return 0f;
	}

	public void SendCurrentId(int index)
	{
		if (IsShow())
		{
			IntData intData = new IntData();
			intData.Data = index;
			Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(113, intData);
			_bigHeroSelectData.Data.CurrentId = index;
			_gameTipActiveChip.Time = 0;
		}
	}

	public string GetTimeout()
	{
		return (_gameTipActiveChip.Time / 1000).ToString("f0");
	}
}
