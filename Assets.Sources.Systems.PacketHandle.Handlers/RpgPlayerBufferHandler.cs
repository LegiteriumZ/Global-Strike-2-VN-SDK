using System.Collections.Generic;
using Assets.Sources.Components.GameRule.rpg;
using NetData;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class RpgPlayerBufferHandler : ApcPacketHandler<SkillBuffData>
{
	private GameRuleContext _gameRuleContext;

	public RpgPlayerBufferHandler(Contexts context)
	{
		_gameRuleContext = context.gameRule;
	}

	public override int MethodId()
	{
		return 276;
	}

	public override void Handle(SkillBuffData data)
	{
		if (_gameRuleContext.rpgSkillBuffer.SkillBufferDatas == null)
		{
			_gameRuleContext.rpgSkillBuffer.SkillBufferDatas = new List<RpgSkillBufferComponent.BufferData>();
		}
		if (data.Active == 1)
		{
			foreach (RpgSkillBufferComponent.BufferData skillBufferData in _gameRuleContext.rpgSkillBuffer.SkillBufferDatas)
			{
				if (skillBufferData.Id.Equals(data.Skillid))
				{
					skillBufferData.LeftTime = data.Duration;
					return;
				}
			}
			_gameRuleContext.rpgSkillBuffer.SkillBufferDatas.Add(new RpgSkillBufferComponent.BufferData
			{
				Id = data.Skillid,
				LeftTime = data.Duration
			});
			return;
		}
		foreach (RpgSkillBufferComponent.BufferData skillBufferData2 in _gameRuleContext.rpgSkillBuffer.SkillBufferDatas)
		{
			if (skillBufferData2.Id.Equals(data.Skillid))
			{
				_gameRuleContext.rpgSkillBuffer.SkillBufferDatas.Remove(skillBufferData2);
				break;
			}
		}
	}
}
