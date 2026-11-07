using System.Collections;
using Assets.Sources.Ui.Model.Biochemical2;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Biochemical2;

public class Blochemical2StartGameModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		yield return TestUiModuleUtils.InitUiTest<Biochemical2StartGameModel>(() => _contexts.battleRoom.hasRoomData ? true : false);
		TestUiStep.Step("游戏开始");
		for (int i = 0; i < 2500; i++)
		{
			_contexts.battleRoom.sectionTime.Passed += 10;
			yield return new WaitForSeconds(0.01f);
		}
		yield return new WaitForSeconds(1f);
	}
}
