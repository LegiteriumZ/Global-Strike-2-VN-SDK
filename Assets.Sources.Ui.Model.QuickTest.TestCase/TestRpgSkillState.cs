namespace Assets.Sources.Ui.Model.QuickTest.TestCase;

public class TestRpgSkillState : QuickTestCase
{
	public TestRpgSkillState(Contexts contexts)
		: base(contexts)
	{
		if (contexts.gameRule.currentRule.Rule.IsPve())
		{
			QuickTestCase.IgnoreList.Add(this);
		}
	}
}
