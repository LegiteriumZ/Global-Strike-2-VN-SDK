using System.Collections;
using Assets.Sources.Ui.Model.Jump;
using NetData;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Jump;

public class JumpTeamScoreModelTest
{
	public void Init()
	{
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.InitAllKillInfo();
		TestUiDataInitUtils.CreateMyPlayerEntity();
		yield return TestUiModuleUtils.InitUiTest<JumpTeamScoreModel>(() => true);
		OneKillInfoData player = new OneKillInfoData
		{
			Id = 1000,
			Ace = true,
			AdditionalTime = 10,
			LoginUnity = true,
			PlayerName = "忘记名字",
			FastWeapon = "awp",
			HasHeroWeapon = true
		};
		for (int i = 0; i < 1000; i++)
		{
			if (i > 500)
			{
				TestUiStep.Step("开始游戏，jumptime 增加");
				player.JumpTime += 10;
			}
			else
			{
				TestUiStep.Step("未开始游戏，jumptime 为0");
			}
			yield return new WaitForSeconds(0.01f);
		}
		TestUiStep.Step("jumptime时间不再变化");
		yield return new WaitForSeconds(1f);
	}
}
