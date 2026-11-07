using System.Collections.Generic;
using Assets.Sources.Framework;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Modules.Player.Skill;

public class PlayerCarrierMessageUpdateSystem : IPlaybackSystem
{
	private PlayerContext _playerContext;

	private MessageContext _messageContext;

	public PlayerCarrierMessageUpdateSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_messageContext = contexts.message;
	}

	public void OnPlayback()
	{
		if (!_playerContext.isMyPlayer || !_playerContext.myPlayerEntity.hasSkill)
		{
			return;
		}
		foreach (KeyValuePair<int, SkillInfoData> skill in _playerContext.myPlayerEntity.skill.Skills)
		{
			if (skill.Value.SkillName == 139)
			{
				_messageContext.gameTipsShow.TipsEvent.Add(new RpgTipsEventData
				{
					TypeId = -1501
				});
				NotifyManager.ForceInvoke(14);
				break;
			}
			if (skill.Value.SkillName == 140)
			{
				_messageContext.gameTipsShow.TipsEvent.Add(new RpgTipsEventData
				{
					TypeId = -1501
				});
				NotifyManager.ForceInvoke(14);
				break;
			}
		}
	}
}
