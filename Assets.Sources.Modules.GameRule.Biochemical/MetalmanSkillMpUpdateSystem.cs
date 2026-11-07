using Assets.Sources.Components.GameRule.Biochemical;
using Assets.Sources.Components.Time;
using Assets.Sources.Framework;

namespace Assets.Sources.Modules.GameRule.Biochemical;

public class MetalmanSkillMpUpdateSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private GameRuleContext _gameRuleContext;

	private TimeComponent _timeComponent;

	public MetalmanSkillMpUpdateSystem(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_timeComponent = contexts.time.time;
	}

	public void OnPlayback()
	{
		MetalmanSkillDataComponent metalmanSkillData = _gameRuleContext.metalmanSkillData;
		metalmanSkillData.Mp += metalmanSkillData.AddMp * (float)_timeComponent.FrameInterval * 0.001f;
		if (metalmanSkillData.Mp > 100f)
		{
			metalmanSkillData.Mp = 100f;
		}
		else if (metalmanSkillData.Mp < 0f)
		{
			metalmanSkillData.Mp = 0f;
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return _gameRuleContext.currentRule.Rule.IsBio();
	}
}
