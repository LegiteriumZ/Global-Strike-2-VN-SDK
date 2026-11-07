using Assets.Sources.Components.Time;
using Entitas;

public class CompeteKingModelTopScoreBoardProvider : ICompeteKingModelTopScoreBoardProvider, IModuleProvider
{
	protected PlayerContext _playerContext;

	protected GameRuleContext _gameRuleContext;

	protected BattleRoomContext _battleRoomContext;

	protected IGroup<PlayerEntity> _players;

	public CompeteKingModelTopScoreBoardProvider(Contexts contexts)
	{
		_playerContext = contexts.player;
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_players = _playerContext.GetGroup(PlayerMatcher.AllOf(PlayerMatcher.BasicInfo));
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool SetTeamNumber(int index)
	{
		if (!_gameRuleContext.hasGunFightData || _gameRuleContext.gunFightData.AlivePlayer == null || _gameRuleContext.gunFightData.AlivePlayer.Count == 0)
		{
			return false;
		}
		int num = index / 2;
		if (num >= _gameRuleContext.gunFightData.AlivePlayer.Count)
		{
			return false;
		}
		return _gameRuleContext.gunFightData.AlivePlayer[num] switch
		{
			2 => true, 
			1 => index % 2 < 1, 
			_ => false, 
		};
	}

	public float SetRoundTime()
	{
		return _battleRoomContext.sectionTime.Seconds + _battleRoomContext.sectionTime.Minutes * 60;
	}

	public float SetProgressBar(int index)
	{
		if (_players == null || _players.count == 0)
		{
			return 0f;
		}
		float num = 0f;
		float num2 = 0f;
		foreach (PlayerEntity player in _players)
		{
			if (player.basicInfo.Current.Team == index + 1)
			{
				num += (float)player.basicInfo.Current.Hp;
				num2 += (float)player.basicInfo.Current.MaxHp;
			}
		}
		return num / num2;
	}
}
