using Assets.Sources.Components.Time;
using Entitas;

public class knifeFightModelScoreBoardProvider : IknifeFightModelScoreBoardProvider, IModuleProvider
{
	protected PlayerContext _playerContext;

	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	protected IGroup<PlayerEntity> _players;

	public knifeFightModelScoreBoardProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
		_players = _playerContext.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo));
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public string GetPrediction()
	{
		if (!_gameRuleContext.hasGunFightData || _playerContext.cameraOwnerEntity == null)
		{
			return "";
		}
		int predictedWinner = _gameRuleContext.gunFightData.PredictedWinner;
		if (predictedWinner == 0)
		{
			return "/ui/GameGUIRes/gunFightModel/scoreboard/draw";
		}
		if (predictedWinner == _playerContext.cameraOwnerEntity.basicInfo.Current.Team)
		{
			return "/ui/GameGUIRes/gunFightModel/scoreboard/victory";
		}
		return "/ui/GameGUIRes/gunFightModel/scoreboard/defeat";
	}

	public bool SetRedTeamNum(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.AlivePlayer == null || _gameRuleContext.gunFightData.AlivePlayer.Count == 0)
		{
			return false;
		}
		return _gameRuleContext.gunFightData.AlivePlayer[0] switch
		{
			2 => true, 
			1 => index < 1, 
			_ => false, 
		};
	}

	public bool SetBlueTeamNum(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.AlivePlayer == null || _gameRuleContext.gunFightData.AlivePlayer.Count == 0)
		{
			return false;
		}
		return _gameRuleContext.gunFightData.AlivePlayer[1] switch
		{
			2 => true, 
			1 => index < 1, 
			_ => false, 
		};
	}

	public float SetProgressBar(int index)
	{
		if (_players == null || _players.count == 0)
		{
			return 0f;
		}
		float num = 0f;
		foreach (PlayerEntity player in _players)
		{
			if (player.basicInfo.Current.Team == index + 1)
			{
				num += (float)player.basicInfo.Current.Hp;
			}
		}
		return num / 200f;
	}

	public float SetHpNum(int index)
	{
		if (_players == null || _players.count == 0)
		{
			return 0f;
		}
		float num = 0f;
		foreach (PlayerEntity player in _players)
		{
			if (player.basicInfo.Current.Team == index + 1)
			{
				num += (float)player.basicInfo.Current.Hp;
			}
		}
		return num;
	}

	public float SetRoundTime()
	{
		return _battleRoomContext.sectionTime.Seconds + _battleRoomContext.sectionTime.Minutes * 60;
	}
}
