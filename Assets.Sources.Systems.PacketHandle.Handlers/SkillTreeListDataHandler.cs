using Assets.Sources.Components.Player;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SkillTreeListDataHandler : ApcPacketHandler<SkillTreeListData>
{
	private PlayerContext _player;

	private MessageContext _messageContext;

	public SkillTreeListDataHandler(Contexts contexts)
	{
		_player = contexts.player;
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 69;
	}

	public override void Handle(SkillTreeListData skill)
	{
		if (_player.myPlayerEntity != null && _player.myPlayerEntity.hasPassiveSkillGroup)
		{
			StudioSkillConditionGroupComponent studioSkillConditionGroup = _player.myPlayerEntity.studioSkillConditionGroup;
			PassiveSkillGroupComponent passiveSkillGroup = _player.myPlayerEntity.passiveSkillGroup;
			for (int i = 0; i < skill.List.Count; i++)
			{
				UpdateStudioSkillCondition(studioSkillConditionGroup, skill.List[i]);
			}
			UpdatePassiveSkillTree(passiveSkillGroup, skill, skill.Type);
		}
	}

	private void UpdatePassiveSkillTree(PassiveSkillGroupComponent passiveSkillManager, SkillTreeListData skill, int specializationType)
	{
		passiveSkillManager.allPassiveSkills.Clear();
		for (int i = 0; i < skill.List.Count; i++)
		{
			SkillTreeData skillTreeData = skill.List[i];
			PassiveSkillComponent passiveSkillComponent = new PassiveSkillComponent();
			passiveSkillComponent.skillLV = skillTreeData.SkillLv;
			passiveSkillComponent.skillName = skillTreeData.SkillName;
			passiveSkillManager.allPassiveSkills[skillTreeData.SkillName] = passiveSkillComponent;
			passiveSkillManager.PassiveSkillDirty = true;
		}
		_messageContext.pveUIMessage.SkillTreeMsgId = specializationType;
		_messageContext.pveUIMessage.SkillTreeChanged = true;
	}

	private void UpdateStudioSkillCondition(StudioSkillConditionGroupComponent studioSkillConditionManager, SkillTreeData skill)
	{
		StudioSkillConditionComponent value = null;
		string skillName = skill.SkillName;
		for (int i = 0; i < skill.PlayerLv.Count; i++)
		{
			string key = $"{skillName}/{i}";
			if (!studioSkillConditionManager.StudioSkillConditions.TryGetValue(key, out value))
			{
				value = new StudioSkillConditionComponent();
				studioSkillConditionManager.StudioSkillConditions.Add(key, value);
			}
			value.studioLv = skill.PlayerLv[i];
			value.studioMoney = skill.Gold;
			value.studioSkillName1 = ((skill.Parent.Count > 0) ? skill.Parent[0] : "");
			value.studioSkillLv1 = 3;
			value.studioSkillName2 = ((skill.Parent.Count > 1) ? skill.Parent[1] : "");
			value.studioSkillLv2 = 3;
			value.isMaxSkillLv = false;
		}
		string key2 = $"{skillName}/{skill.PlayerLv.Count}";
		if (!studioSkillConditionManager.StudioSkillConditions.TryGetValue(key2, out value))
		{
			value = new StudioSkillConditionComponent();
			studioSkillConditionManager.StudioSkillConditions.Add(key2, value);
		}
		value.studioLv = 0;
		value.studioMoney = 0;
		value.isMaxSkillLv = true;
		studioSkillConditionManager.StudioSkillDirty = true;
	}
}
