using System.Collections.Generic;
using Assets.Sources.Components.Time;
using SSJJMath;

public class BroadSwordModelPowerProvider : IBroadSwordModelPowerProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private const int LIUGUANG_ALLTIME = 350;

	private const int LIUGUANG_START_X = -426;

	private const int LIUGUANG_END_X = 308;

	private const int RED_SHINE = 500;

	private List<float> _redPercent = new List<float> { 0f, 0.261f, 0.501f, 0.739f, 0.98f };

	public BroadSwordModelPowerProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.broadSword.IsRedBufferPower)
		{
			_gameRuleContext.broadSword.RedShineTime += time.FrameInterval;
		}
		if (_gameRuleContext.broadSword.LevelUpLiuGuangTime > -1)
		{
			_gameRuleContext.broadSword.LevelUpLiuGuangTime += time.FrameInterval;
			if (_gameRuleContext.broadSword.LevelUpLiuGuangTime >= 350)
			{
				_gameRuleContext.broadSword.LevelUpLiuGuangTime = -1;
			}
		}
	}

	public float GetLiuGuangPosX()
	{
		return -426f + (float)_gameRuleContext.broadSword.LevelUpLiuGuangTime * 1f / 350f * 734f;
	}

	public bool IsRedShow()
	{
		return _gameRuleContext.broadSword.IsRedBufferPower;
	}

	public string UpdateRedImage()
	{
		int textureIndex = FlashMaths.GetTextureIndex(1, 5, 100f, _gameRuleContext.broadSword.RedShineTime, repeat: true);
		return $"/ui/GameGUIRes/BroadSwordModel/hongguang/hongguang{textureIndex}";
	}

	public float UpdateRedPercent()
	{
		int powerLevel = _gameRuleContext.broadSword.PowerLevel;
		int powerPercent = _gameRuleContext.broadSword.PowerPercent;
		if (powerLevel < _redPercent.Count - 1)
		{
			return _redPercent[powerLevel] + (float)powerPercent / 100f * (_redPercent[powerLevel + 1] - _redPercent[powerLevel]);
		}
		return 1f;
	}

	public bool IsBottomShow()
	{
		return !_gameRuleContext.broadSword.IsRedBufferPower;
	}

	public float GetPercent()
	{
		return (float)_gameRuleContext.broadSword.PowerLevel * 0.25f + (float)_gameRuleContext.broadSword.PowerPercent / 100f * 0.25f;
	}

	public bool IsYellowShow(int index)
	{
		if (!_gameRuleContext.broadSword.IsRedBufferPower)
		{
			return _gameRuleContext.broadSword.PowerLevel > index;
		}
		return false;
	}

	public bool IsLiuGuangShow()
	{
		return _gameRuleContext.broadSword.LevelUpLiuGuangTime > -1;
	}

	public float GetLevelTxt()
	{
		return 0f;
	}

	public float GetPercentTxt()
	{
		return 0f;
	}
}
