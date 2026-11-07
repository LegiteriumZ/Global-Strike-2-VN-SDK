using System.Collections;
using Assets.Sources.Ui.Model.Jump;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Jump;

public class JumpSaveProgressBarModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.InitgameProgressData();
		yield return TestUiModuleUtils.InitUiTest<JumpSaveProgressBarModel>(() => true);
		TestUiStep.Step("查看进度条变化");
		_contexts.gameRule.gameProgressData.ProgressTotalTime = 5000;
		while (_contexts.gameRule.gameProgressData.CurrentProgressTime < _contexts.gameRule.gameProgressData.ProgressTotalTime)
		{
			_contexts.gameRule.gameProgressData.CurrentProgressTime += 10;
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("进度条总时间为0");
		_contexts.gameRule.gameProgressData.ProgressTotalTime = 0;
		yield return new WaitForSeconds(1f);
	}
}
