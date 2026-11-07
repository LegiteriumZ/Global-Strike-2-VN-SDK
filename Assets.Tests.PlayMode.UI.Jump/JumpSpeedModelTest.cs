using System.Collections;
using Assets.Sources.Ui.Model.Jump;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Jump;

public class JumpSpeedModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.CreateMyPlayerEntity();
		yield return TestUiModuleUtils.InitUiTest<JumpSpeedModel>(() => true);
		TestUiStep.Step("X速度增加");
		for (int k = 0; k < 500; k++)
		{
			_contexts.player.myPlayerEntity.basicInfo.Current.Velocity.X += 1f;
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("Y速度增加");
		for (int k = 0; k < 500; k++)
		{
			_contexts.player.myPlayerEntity.basicInfo.Current.Velocity.Y += 1f;
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("X速度减少");
		for (int k = 0; k < 500; k++)
		{
			_contexts.player.myPlayerEntity.basicInfo.Current.Velocity.X -= 1f;
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("Y速度减少");
		for (int k = 0; k < 500; k++)
		{
			_contexts.player.myPlayerEntity.basicInfo.Current.Velocity.Y -= 1f;
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("速度不变");
		yield return new WaitForSeconds(3f);
	}
}
