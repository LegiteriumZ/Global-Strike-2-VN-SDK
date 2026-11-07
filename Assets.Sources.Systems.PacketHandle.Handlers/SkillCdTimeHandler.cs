using System.Collections.Generic;
using Assets.Sources.Utils.Timer;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class SkillCdTimeHandler : ApcPacketHandler<SkillInfoData>
{
	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private TimeContext _timeContext;

	public SkillCdTimeHandler(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_timeContext = contexts.time;
	}

	public override int MethodId()
	{
		return 27;
	}

	public override void Handle(SkillInfoData data)
	{
		if (data.Kind == 9)
		{
			if (_gameRuleContext.acgSkill.AcgCharacterSkill == null)
			{
				_gameRuleContext.acgSkill.AcgCharacterSkill = data;
			}
			else
			{
				_gameRuleContext.acgSkill.AcgCharacterSkill.SkillName = data.SkillName;
				_gameRuleContext.acgSkill.AcgCharacterSkill.CdTime = data.CdTime;
				_gameRuleContext.acgSkill.AcgCharacterSkill.CurrentCdTime = data.CurrentCdTime;
				_gameRuleContext.acgSkill.AcgCharacterSkill.Energy = data.Energy;
				_gameRuleContext.acgSkill.AcgCharacterSkill.IsSilent = data.IsSilent;
			}
			SSJJTimerUtils.RemoveTimer(_timeContext.commonTimer.CommonTimer, "ACG_CHARACTER_SKILL");
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_CHARACTER_SKILL", new SSJJTimer(data.CdTime, data.CurrentCdTime));
			return;
		}
		if (data.Kind == 10)
		{
			if (_gameRuleContext.acgSkill.AcgWeaponSkill == null)
			{
				_gameRuleContext.acgSkill.AcgWeaponSkill = data;
			}
			else
			{
				_gameRuleContext.acgSkill.AcgWeaponSkill.SkillName = data.SkillName;
				_gameRuleContext.acgSkill.AcgWeaponSkill.CdTime = data.CdTime;
				_gameRuleContext.acgSkill.AcgWeaponSkill.CurrentCdTime = data.CurrentCdTime;
				_gameRuleContext.acgSkill.AcgWeaponSkill.Energy = data.Energy;
				_gameRuleContext.acgSkill.AcgWeaponSkill.IsSilent = data.IsSilent;
			}
			SSJJTimerUtils.RemoveTimer(_timeContext.commonTimer.CommonTimer, "ACG_WEAPON_SKILL");
			SSJJTimerUtils.AddTimer(_timeContext.commonTimer.CommonTimer, "ACG_WEAPON_SKILL", new SSJJTimer(data.CdTime, data.CurrentCdTime));
			return;
		}
		Dictionary<int, SkillInfoData> skillMap = _battleRoomContext.playerInfo.GetSkillMap(data.Id);
		if (data.Type == -1)
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, SkillInfoData> item in skillMap)
			{
				if (item.Value.Kind != 6)
				{
					list.Add(item.Key);
				}
			}
			foreach (int item2 in list)
			{
				skillMap.Remove(item2);
			}
		}
		else if (data.Remove)
		{
			skillMap.Remove(data.Type);
		}
		else
		{
			skillMap.TryGetValue(data.Type, out var value);
			if (value != null)
			{
				value.CdTime = data.CdTime;
				value.Type = data.Type;
				value.SkillName = data.SkillName;
				value.CurrentCdTime = data.CurrentCdTime;
				value.NeedMp = data.NeedMp;
				value.Mp = data.Mp;
				value.MaxMp = data.MaxMp;
				if (data.Kind == 11)
				{
					value.Energy = data.Energy;
				}
				if (data.LvSpecified)
				{
					value.Lv = data.Lv;
				}
				if (data.SlvSpecified)
				{
					value.Slv = data.Slv;
				}
			}
			else
			{
				skillMap[data.Type] = data;
			}
		}
		NotifyManager.ForceInvoke(155);
	}
}
