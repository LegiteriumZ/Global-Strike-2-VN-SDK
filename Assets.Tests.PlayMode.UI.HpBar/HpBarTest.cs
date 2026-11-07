using System.Collections;
using NetData;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.HpBar;

public class HpBarTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.CreateMyPlayerEntity();
		TestUiDataInitUtils.InitKillPlayerInfo();
		TestUiDataInitUtils.InitAllKillInfo();
		TestUiDataInitUtils.InitGunKingTeamScoreData();
		TestUiDataInitUtils.InitHpProgressData();
		TestUiBaseGameRule testUiBaseGameRule = new TestUiBaseGameRule();
		_contexts.gameRule.SetCurrentRule(testUiBaseGameRule);
		testUiBaseGameRule.Bighead = true;
		yield return TestUiModuleUtils.InitUiTestByModule<TestPlayerHpBarModule>(delegate
		{
			if (!_contexts.battleRoom.hasRoomData)
			{
				return false;
			}
			_contexts.battleRoom.roomData.Data = new RoomData
			{
				RaceType = 19
			};
			return true;
		});
		_contexts.worldCamera.SetUnityObjects(null, GameObject.Find("MainCamera").GetComponent<UnityEngine.Camera>());
		PlayerEntity playerEntity = TestUiDataInitUtils.CreateOtherPlayerEntity();
		playerEntity.basicInfo.Current.Team = 1;
		playerEntity.basicInfo.Current.X = 500f;
		playerEntity.basicInfo.Current.Y = 0f;
		playerEntity.basicInfo.Current.Z = -200f;
		playerEntity.fpos.Sp(new Vector3(playerEntity.basicInfo.Current.X, playerEntity.basicInfo.Current.Y, playerEntity.basicInfo.Current.Z));
		yield return new WaitForSeconds(150f);
	}
}
