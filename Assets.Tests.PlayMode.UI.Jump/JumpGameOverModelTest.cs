using System.Collections;
using Assets.Sources.Ui.Model.Jump;
using NetData;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Jump;

public class JumpGameOverModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		yield return TestUiModuleUtils.InitUiTest<JumpGameOverModel>(delegate
		{
			if (_contexts.battleRoom.hasRoomData)
			{
				_contexts.battleRoom.roomData.Data = new RoomData
				{
					SceneId = 90
				};
				return true;
			}
			return false;
		});
		TestUiStep.Step("显示游戏结束");
		TestUiStep.Step("等待10秒后面板关闭");
		yield return new WaitForSeconds(15f);
	}
}
