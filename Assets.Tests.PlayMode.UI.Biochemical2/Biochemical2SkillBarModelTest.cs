using System.Collections;
using Assets.Sources.Components.Player;
using Assets.Sources.Ui.Model.Biochemical2;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Biochemical2;

public class Biochemical2SkillBarModelTest
{
	private Contexts _contexts;

	public void Init()
	{
		_contexts = Contexts.sharedInstance;
	}

	public IEnumerator Test()
	{
		TestUiDataInitUtils.CreateMyPlayerEntity();
		TestUiDataInitUtils.InitBio2SkillLvUpData();
		yield return TestUiModuleUtils.InitUiTest<Biochemical2SkillBarModel>(() => true);
		TestUiStep.Step("显示技能exp");
		_contexts.gameRule.bio2SkillLvUpData.Exp = 50;
		_contexts.gameRule.bio2SkillLvUpData.LvUpExp = 100;
		yield return new WaitForSeconds(3f);
		TestUiStep.Step("增加技能点");
		_contexts.gameRule.bio2SkillLvUpData.Exp = 100;
		_contexts.gameRule.bio2SkillLvUpData.SkillCount = 1;
		yield return new WaitForSeconds(3f);
		TestUiStep.Step("学习技能");
		_contexts.player.myPlayerEntity.passiveSkillGroup.allPassiveSkills.Add("skill", new PassiveSkillComponent
		{
			skillName = "H_AUTOLOAD",
			skillLV = 1
		});
		yield return new WaitForSeconds(3f);
		TestUiStep.Step("玩家死亡");
		_contexts.player.myPlayerEntity.basicInfo.Current.IsDead = true;
		yield return new WaitForSeconds(3f);
	}
}
