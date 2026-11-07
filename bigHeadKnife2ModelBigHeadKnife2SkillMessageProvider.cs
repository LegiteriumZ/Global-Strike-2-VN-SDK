using Assets.Sources.Components.Time;
using NetData;

public class bigHeadKnife2ModelBigHeadKnife2SkillMessageProvider : IbigHeadKnife2ModelBigHeadKnife2SkillMessageProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected MessageContext _message;

	protected PlayerContext _playerContext;

	protected BattleRoomContext _battleRoomContext;

	protected TimeContext _timeContext;

	private int _curMp;

	private int _needMp;

	public bigHeadKnife2ModelBigHeadKnife2SkillMessageProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
		_message = contexts.message;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool tipsShow()
	{
		RpgTipsEventData tipsData = getTipsData();
		if (tipsData != null)
		{
			_curMp = tipsData.Time1;
			_needMp = tipsData.Time2;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		int num = 0;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasSkill && cameraOwnerEntity.skill.Skills != null)
		{
			cameraOwnerEntity.skill.Skills.TryGetValue(106, out var value);
			if (value == null)
			{
				return false;
			}
			num = value.CurrentCdTime;
			_ = value.CdTime;
		}
		if (num < 0)
		{
			if (_curMp >= _needMp)
			{
				return _needMp > 0;
			}
			return false;
		}
		return false;
	}

	private RpgTipsEventData getTipsData()
	{
		for (int num = _message.gameTipsShow.TipsEvent.Count - 1; num >= 0; num--)
		{
			RpgTipsEventData rpgTipsEventData = _message.gameTipsShow.TipsEvent[num];
			if (rpgTipsEventData.TypeId == -13400)
			{
				return rpgTipsEventData;
			}
		}
		return null;
	}
}
