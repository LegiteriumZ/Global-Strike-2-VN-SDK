using System.Collections;
using System.Linq;
using Assets.Sources.Components.Player;
using Assets.Sources.Ui.Model.Biochemical2;
using UnityEngine;

namespace Assets.Tests.PlayMode.UI.Biochemical2;

public class Biochemical2SkillBoardModelTest
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
		yield return TestUiModuleUtils.InitUiTest<Biochemical2SkillBoardModel>(() => true);
		TestUiMode<Biochemical2SkillBoardModel>.CurrModel.OnKeyDown(KeyCode.P);
		for (int j = 0; j < 5; j++)
		{
			TestUiStep.Step("添加 Human Skill " + j);
			string key = Biochemical2SkillBoardModel.HumanSkills.ToArray()[j].Key;
			_contexts.player.myPlayerEntity.passiveSkillGroup.allPassiveSkills.Add(key, new PassiveSkillComponent
			{
				skillName = key,
				skillLV = j + 1
			});
			yield return new WaitForSeconds(2f);
		}
		for (int j = 0; j < 5; j++)
		{
			TestUiStep.Step("添加 Nature Skill " + j);
			string key2 = Biochemical2SkillBoardModel.NatureSkills.ToArray()[j].Key;
			_contexts.player.myPlayerEntity.passiveSkillGroup.allPassiveSkills.Add(key2, new PassiveSkillComponent
			{
				skillName = key2,
				skillLV = j + 1
			});
			yield return new WaitForSeconds(2f);
		}
		for (int j = 0; j < 5; j++)
		{
			TestUiStep.Step("添加 Variant Skill " + j);
			string key3 = Biochemical2SkillBoardModel.VariantSkills.ToArray()[j].Key;
			_contexts.player.myPlayerEntity.passiveSkillGroup.allPassiveSkills.Add(key3, new PassiveSkillComponent
			{
				skillName = key3,
				skillLV = j + 1
			});
			yield return new WaitForSeconds(2f);
		}
		TestUiStep.Step("查看技能鼠标事件");
		yield return new WaitForSeconds(5000f);
		TestUiMode<Biochemical2SkillBoardModel>.CurrModel.OnKeyDown(KeyCode.P);
	}
}
