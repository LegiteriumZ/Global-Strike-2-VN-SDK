using System.Collections;
using Assets.Sources.Modules.Ui.Mode;
using Assets.Sources.Ui.Model.Jump;
using NetData;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Jump;

public class JumpIndividualScoreModelTest
{
	public class TestMode : AbstractMode
	{
		public TestMode(Contexts contexts)
			: base(contexts, flag: false)
		{
			AddPlaybackSystem(new JumpIndividualScoreInfoModel());
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
		OneKillInfoData player = new OneKillInfoData
		{
			Ace = true,
			AdditionalTime = 10,
			LoginUnity = true,
			PlayerName = "忘记名字",
			FastWeapon = "awp",
			HasHeroWeapon = true
		};
		TestUiStep.Step("查看自己的jumptime");
		for (int i = 0; i < 2000; i++)
		{
			player.JumpTime += 10;
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("抬起Tab键");
		yield return new WaitForSeconds(1f);
	}
}
