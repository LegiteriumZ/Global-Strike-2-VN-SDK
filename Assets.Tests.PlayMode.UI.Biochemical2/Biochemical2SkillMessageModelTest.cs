using System.Collections;
using Assets.Sources.Ui.Model.Biochemical2;

namespace Assets.Tests.PlayMode.UI.Biochemical2;

public class Biochemical2SkillMessageModelTest
{
	public void Init()
	{
	}

	public IEnumerator Test()
	{
		yield return TestUiModuleUtils.InitUiTest<Biochemical2SkillMessageModel>(() => true);
	}
}
