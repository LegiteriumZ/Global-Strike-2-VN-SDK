using Assets.Sources.Constant.Career;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.Model.Biochemical;

namespace Assets.Sources.Ui.Model.NewescapeModel;

public class NewBiochemicalSkillIconModel : BiochemicalSkillIconModel
{
	protected override bool ShowSkill(int SkillName)
	{
		if (SkillName == 401)
		{
			return PlayerCareerConstantUtility.IsHumanity(UiIEventCondition.Get_cameraOwnerData_Career());
		}
		return PlayerCareerConstantUtility.IsNoHuMan(UiIEventCondition.Get_cameraOwnerData_Career());
	}
}
