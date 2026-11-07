using Assets.Sources.Components.Time;
using NetData;

public class protectBigHeadModelProtectBigHeadCareerUIProvider : IprotectBigHeadModelProtectBigHeadCareerUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	public protectBigHeadModelProtectBigHeadCareerUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	private BigHeadManData getCareerData(int myTeam, int index)
	{
		if (!_gameRuleContext.protectBigHeadCareer.hasData)
		{
			return null;
		}
		BigHeadManData team1Data = _gameRuleContext.protectBigHeadCareer.team1Data;
		BigHeadManData team2Data = _gameRuleContext.protectBigHeadCareer.team2Data;
		if (team1Data.Team == myTeam)
		{
			if (index != 0)
			{
				return team2Data;
			}
			return team1Data;
		}
		if (index != 1)
		{
			return team2Data;
		}
		return team1Data;
	}

	public float updateBarByIndex(int index)
	{
		int team = _playerContext.myPlayerEntity.GetTeam();
		BigHeadManData careerData = getCareerData(team, index);
		if (careerData != null)
		{
			return (float)careerData.Hp / (float)careerData.MaxHp;
		}
		return 0f;
	}

	public string updateHpByIndex(int index)
	{
		int team = _playerContext.myPlayerEntity.GetTeam();
		BigHeadManData careerData = getCareerData(team, index);
		if (careerData != null)
		{
			return "<color=#FFD270>" + careerData.Hp + "</color>";
		}
		return "";
	}

	public string updateMaxHpByIndex(int index)
	{
		int team = _playerContext.myPlayerEntity.GetTeam();
		BigHeadManData careerData = getCareerData(team, index);
		if (careerData != null)
		{
			return "/ " + careerData.MaxHp;
		}
		return "/ 0";
	}

	public string updateCareerIconByIndex(int index)
	{
		int team = _playerContext.myPlayerEntity.GetTeam();
		BigHeadManData careerData = getCareerData(team, index);
		if (careerData != null)
		{
			return "/ui/GameGUIRes/halfLoadedRes/pvpplayerstate/" + careerData.Career;
		}
		return "";
	}

	public bool rootShow()
	{
		return _gameRuleContext.protectBigHeadCareer.hasData;
	}

	public string updateNameByIndex(int index)
	{
		int team = _playerContext.myPlayerEntity.GetTeam();
		BigHeadManData careerData = getCareerData(team, index);
		if (careerData != null)
		{
			return careerData.Name;
		}
		return "";
	}
}
