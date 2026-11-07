using System.Collections;
using Assets.Sources.Snapshots;
using Assets.Sources.Ui.Model.Jump;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Jump;

public class JumpShortcutKeyDescriptionModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.CreateMyPlayerEntity();
		yield return TestUiModuleUtils.InitUiTest<JumpShortcutKeyDescriptionModel>(delegate
		{
			if (!_contexts.snapshot.hasSnapshots)
			{
				return false;
			}
			_contexts.snapshot.snapshots.NowSnapshot = new Snapshot();
			return true;
		});
		TestUiStep.Step("提示连续按键两次关闭空格键");
		yield return new WaitForSeconds(5f);
		TestUiStep.Step("提示开启空格键");
		_contexts.player.myPlayerEntity.state.AddPlayerStateType(524288);
		yield return new WaitForSeconds(5f);
		TestUiStep.Step("提示Y键退出观察模式");
		_contexts.snapshot.snapshots.NowSnapshot.ControlId = 1;
		yield return new WaitForSeconds(5f);
	}
}
