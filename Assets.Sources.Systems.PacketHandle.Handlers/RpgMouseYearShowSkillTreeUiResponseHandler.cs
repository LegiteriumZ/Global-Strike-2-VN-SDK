using Assets.Sources.Components.GameRule.Rpg;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgMouseYearShowSkillTreeUiResponseHandler : ApcPacketHandler<ShowSkillTreeUIResponse>
{
	private readonly GameRuleContext _gameRuleContext;

	public RpgMouseYearShowSkillTreeUiResponseHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 258;
	}

	public override void Handle(ShowSkillTreeUIResponse data)
	{
		MouseYearComponent mouseYear = _gameRuleContext.mouseYear;
		mouseYear.IsShowSkillTree = true;
		mouseYear.SkillTreeType = data.SkillTreeType;
		mouseYear.SkillPoint = data.SkillPoint;
		mouseYear.ActiveSkillList = data.ActiveSkillList;
	}
}
