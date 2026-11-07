using Assets.Sources.Components.Time;

public class bigHeadP3ModelBigHeadP3SkillProvider : IbigHeadP3ModelBigHeadP3SkillProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	protected PlayerContext _playerContext;

	private int _skillName;

	private int _skillCurrentTime;

	private int _skillCdTime;

	public bigHeadP3ModelBigHeadP3SkillProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasSkill && cameraOwnerEntity.skill.Skills != null)
		{
			cameraOwnerEntity.skill.Skills.TryGetValue(106, out var value);
			if (value != null)
			{
				_skillName = value.SkillName;
				_skillCurrentTime = value.CurrentCdTime;
				_skillCdTime = value.CdTime;
			}
		}
	}

	public string changeImage()
	{
		if (_skillName > 0)
		{
			string arg = ((_skillCurrentTime < 0) ? ("activeBg_" + _skillName) : ("unactiveBg_" + _skillName));
			return $"/ui/GameGUIRes/bigHeadP3Model/skill/{arg}";
		}
		return "";
	}

	public bool isShow()
	{
		PlayerEntity cameraOwnerEntity = _playerContext.cameraOwnerEntity;
		if (cameraOwnerEntity != null && cameraOwnerEntity.hasBasicInfo && cameraOwnerEntity.basicInfo.CareerInfo != null)
		{
			return cameraOwnerEntity.basicInfo.CareerInfo.Name == "p3hero";
		}
		return false;
	}

	public float setProgress()
	{
		if (_skillName > 0 && _skillCdTime > 0)
		{
			return (float)(_skillCdTime - _skillCurrentTime) / (float)_skillCdTime;
		}
		return 0f;
	}
}
