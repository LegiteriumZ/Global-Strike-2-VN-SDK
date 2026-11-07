using System;
using Assets.Sources.Components.Time;
using NetData;

public class bigHeadKnife2ModelBigHeadKnife2SkillFItemProvider : IbigHeadKnife2ModelBigHeadKnife2SkillFItemProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected TimeContext _timeContext;

	protected MessageContext _message;

	protected PlayerContext _playerContext;

	protected BattleRoomContext _battleRoomContext;

	private int _curMp;

	private int _needMp;

	private int _skillCdTime;

	private int _skillCurrentTime;

	private bool _canUse;

	private float _flashTime;

	private const int totalFlashTime = 400;

	private const int flashTotalFrames = 4;

	public bigHeadKnife2ModelBigHeadKnife2SkillFItemProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
		_message = contexts.message;
		_playerContext = contexts.player;
		_battleRoomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
		RpgTipsEventData tipsData = getTipsData();
		if (tipsData != null)
		{
			_curMp = tipsData.Time1;
			_needMp = tipsData.Time2;
		}
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasSkill && cameraOwnerEntity.skill.Skills != null)
		{
			cameraOwnerEntity.skill.Skills.TryGetValue(106, out var value);
			if (value != null)
			{
				_skillCurrentTime = value.CurrentCdTime;
				_skillCdTime = value.CdTime;
			}
		}
		if (_flashTime > 0f)
		{
			_flashTime -= time.FrameInterval;
		}
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

	public bool spriteShow()
	{
		bool flag = _skillCurrentTime < 0 && _curMp >= _needMp && _needMp > 0;
		if (flag)
		{
			if (_canUse)
			{
				return _flashTime > 0f;
			}
			_flashTime = 400f;
			_canUse = flag;
		}
		_canUse = flag;
		return flag;
	}

	public string changeSpritePic()
	{
		int num = 100;
		int num2 = (int)Math.Floor((400f - _flashTime) / (float)num);
		num2 %= 4;
		num2++;
		return "/ui/GameGUIRes/bigHeadKnife2Model/skill/effect" + num2;
	}

	public float setMaskPercent()
	{
		if (_needMp <= 0)
		{
			return 0f;
		}
		float num = Math.Max(0f, 1f - (float)_curMp / (float)_needMp);
		return 1f - num;
	}

	public bool cdShow()
	{
		return _skillCurrentTime > 0;
	}

	public float updateCd()
	{
		return (int)Math.Ceiling((float)_skillCurrentTime / 1000f);
	}

	public string updateSkillPower()
	{
		return _curMp.ToString();
	}
}
