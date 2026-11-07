using Assets.Sources.Components.Player;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class PlayerSkillListHandler : ApcPacketHandler<SkillListData>
{
	private PlayerContext _player;

	private MessageContext _messageContext;

	public PlayerSkillListHandler(Contexts contexts)
	{
		_player = contexts.player;
		_messageContext = contexts.message;
	}

	public override int MethodId()
	{
		return 52;
	}

	public override void Handle(SkillListData data)
	{
		if (_player.myPlayerEntity != null && _player.myPlayerEntity.hasPassiveSkillGroup)
		{
			PassiveSkillGroupComponent passiveSkillGroup = _player.myPlayerEntity.passiveSkillGroup;
			UpdatePassiveSkillTree(passiveSkillGroup, data);
		}
	}

	private void UpdatePassiveSkillTree(PassiveSkillGroupComponent passiveSkillManager, SkillListData skill)
	{
		passiveSkillManager.allPassiveSkills.Clear();
		for (int i = 0; i < skill.Skill.Count; i++)
		{
			SkillData skillData = skill.Skill[i];
			PassiveSkillComponent passiveSkillComponent = new PassiveSkillComponent();
			passiveSkillComponent.skillLV = skillData.Lv;
			passiveSkillComponent.skillName = skillData.SkillName;
			passiveSkillManager.allPassiveSkills[skillData.SkillName] = passiveSkillComponent;
			passiveSkillManager.PassiveSkillDirty = true;
		}
		_messageContext.pveUIMessage.SkillTreeMsgId = 0;
	}
}
