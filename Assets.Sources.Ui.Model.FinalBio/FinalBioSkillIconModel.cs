using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Biochemical;

namespace Assets.Sources.Ui.Model.FinalBio;

public class FinalBioSkillIconModel : BiochemicalSkillIconModel, ISetBattleRoomContext
{
	private BattleRoomContext _battleRoomContext;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	protected override bool ShowSkill(int SkillName)
	{
		if (_battleRoomContext.sectionTime.SectionTime <= FinalBioDecisiveBattleModel.UltimateTime && PlayerCareerConstantUtility.IsEmpress(UiIEventCondition.Get_cameraOwnerData_Career()))
		{
			return false;
		}
		return true;
	}
}
