using System.Collections;
using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Biochemical2;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Biochemical2;

public class Biochemical2IndividualScoreModelTest
{
	public class TestMode : AbstractMode
	{
		public TestMode(Contexts contexts)
			: base(contexts, flag: false)
		{
			AddPlaybackSystem(new Biochemical2IndividualScoreInfoModel());
		}
	}

	public void Init()
	{
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.InitGameMessageData();
		TestUiDataInitUtils.InitAllKillInfo();
		yield return TestUiModuleUtils.InitUiTestByMode<TestMode>(() => true);
		TestUiStep.Step("Tab键打开界面");
		for (int i = 0; i < 1000; i++)
		{
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("抬起Tab键关闭界面");
		yield return new WaitForSeconds(1f);
	}
}
