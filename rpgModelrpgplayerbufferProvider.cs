using System.Collections.Generic;
using Assets.Sources.Components.GameRule.rpg;
using Assets.Sources.Components.Time;

public class rpgModelrpgplayerbufferProvider : IrpgModelrpgplayerbufferProvider, IModuleProvider
{
	private readonly Dictionary<string, int> _bufferTwinkles = new Dictionary<string, int>
	{
		{ "210231", 3000 },
		{ "210232", 3000 },
		{ "210234", 10000 }
	};

	protected GameRuleContext _gameRuleContext;

	public rpgModelrpgplayerbufferProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.rpgSkillBuffer.SkillBufferDatas == null)
		{
			return;
		}
		foreach (RpgSkillBufferComponent.BufferData skillBufferData in _gameRuleContext.rpgSkillBuffer.SkillBufferDatas)
		{
			if (skillBufferData.LeftTime > 0)
			{
				skillBufferData.LeftTime -= time.FrameInterval;
			}
		}
	}

	public bool IsBufferItemShow(int index)
	{
		if (_gameRuleContext.rpgSkillBuffer.SkillBufferDatas != null)
		{
			return _gameRuleContext.rpgSkillBuffer.SkillBufferDatas.Count > index;
		}
		return false;
	}

	private int GetTwinkleTime(string id)
	{
		int value = 0;
		_bufferTwinkles.TryGetValue(id, out value);
		return value;
	}

	public float RefreshBufferItemAlpha(int index)
	{
		if (_gameRuleContext.rpgSkillBuffer.SkillBufferDatas == null || _gameRuleContext.rpgSkillBuffer.SkillBufferDatas.Count <= index)
		{
			return 1f;
		}
		int twinkleTime = GetTwinkleTime(_gameRuleContext.rpgSkillBuffer.SkillBufferDatas[index].Id);
		if (twinkleTime == 0)
		{
			return 1f;
		}
		if (_gameRuleContext.rpgSkillBuffer.SkillBufferDatas[index].LeftTime > twinkleTime)
		{
			return 1f;
		}
		return (float)((twinkleTime - _gameRuleContext.rpgSkillBuffer.SkillBufferDatas[index].LeftTime) % 500) / 500f;
	}

	public string RefreshBufferIcon(int index)
	{
		if (_gameRuleContext.rpgSkillBuffer.SkillBufferDatas == null || _gameRuleContext.rpgSkillBuffer.SkillBufferDatas.Count <= index)
		{
			return "";
		}
		return $"/ui/GameGUIRes/halfLoadedRes/rpgplayerbuffer/{_gameRuleContext.rpgSkillBuffer.SkillBufferDatas[index].Id}";
	}

	public bool IsRpgBufferShow()
	{
		if (_gameRuleContext.rpgSkillBuffer.SkillBufferDatas != null)
		{
			return _gameRuleContext.rpgSkillBuffer.SkillBufferDatas.Count > 0;
		}
		return false;
	}
}
