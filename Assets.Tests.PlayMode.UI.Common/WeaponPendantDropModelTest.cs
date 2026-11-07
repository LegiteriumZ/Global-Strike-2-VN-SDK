using System.Collections;
using Assets.Sources.Ui.Model.Common;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Common;

public class WeaponPendantDropModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.InitWeaponPendantDrop();
		yield return TestUiModuleUtils.InitUiTest<WeaponPendantDropModel>(() => true);
		TestUiStep.Step("添加道具掉落");
		_contexts.gameRule.weaponPendantDrop.IsStormScore = false;
		_contexts.gameRule.weaponPendantDrop.PendantId = "2001";
		_contexts.gameRule.weaponPendantDrop.Count = 2;
		_contexts.gameRule.weaponPendantDrop.Quality = 1;
		_contexts.gameRule.weaponPendantDrop.Time = 1500;
		yield return new WaitForSeconds(1f);
		TestUiStep.Step("道具顶道具");
		_contexts.gameRule.weaponPendantDrop.IsStormScore = false;
		_contexts.gameRule.weaponPendantDrop.PendantId = "3001";
		_contexts.gameRule.weaponPendantDrop.Count = 3;
		_contexts.gameRule.weaponPendantDrop.Quality = 1;
		_contexts.gameRule.weaponPendantDrop.Time = 1500;
		yield return new WaitForSeconds(2f);
		TestUiStep.Step("添加战绩");
		_contexts.gameRule.weaponPendantDrop.IsStormScore = true;
		_contexts.gameRule.weaponPendantDrop.Count = 150;
		_contexts.gameRule.weaponPendantDrop.Time = 15000;
		_contexts.gameRule.weaponPendantDrop.Quality = 0;
		yield return new WaitForSeconds(1f);
		TestUiStep.Step("道具顶战绩");
		_contexts.gameRule.weaponPendantDrop.IsStormScore = false;
		_contexts.gameRule.weaponPendantDrop.PendantId = "4001";
		_contexts.gameRule.weaponPendantDrop.Count = 4;
		_contexts.gameRule.weaponPendantDrop.Quality = 1;
		_contexts.gameRule.weaponPendantDrop.Time = 1500;
		yield return new WaitForSeconds(3f);
	}
}
