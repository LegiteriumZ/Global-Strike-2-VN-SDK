using Assets.Sources.Components.Time;
using NetData;

public class highSpeedGroupModelHighSpeedGroupSkillProvider : IhighSpeedGroupModelHighSpeedGroupSkillProvider, IModuleProvider
{
	private PlayerContext _playerContext;

	public highSpeedGroupModelHighSpeedGroupSkillProvider(Contexts contexts)
	{
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public string getSkillUrl()
	{
		SkillInfoData skillInfoData = _playerContext.myPlayerEntity.skill.Skills[106];
		if (skillInfoData != null && skillInfoData.CurrentCdTime > 0)
		{
			return "/ui/GameGUIRes/highSpeedGroupModel/skillUnActive";
		}
		return "/ui/GameGUIRes/highSpeedGroupModel/skillActive";
	}
}
