using Assets.Sources.Framework;
using Assets.Sources.Utils;
using I2.Loc;
using NotifyEvent;

namespace Assets.Sources.Modules.Message.Common;

public class MessageRemindDataSystem : IMessagePlaybackSystem, IPlaybackSystem
{
	private PlayerContext _playerContext;

	private MessageContext _messageContext;

	public MessageRemindDataSystem(Contexts contexts)
	{
		_playerContext = contexts.player;
		_messageContext = contexts.message;
	}

	public void OnPlayback()
	{
		if (_playerContext.isMyPlayer)
		{
			if (ScreenShotManager.ScreenshotFlag)
			{
				ScreenShotManager.ScreenshotFlag = false;
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("screenshottips"));
				NotifyManager.ForceInvoke(38);
			}
			PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
			if (string.IsNullOrEmpty(myPlayerEntity.GetPlayerInfo().Ak47HeroSkillUser))
			{
				_messageContext.messageRemindData.Ak47Message = "";
			}
			else
			{
				_messageContext.messageRemindData.Ak47Message = string.Format(ScriptLocalization.Get("UseAk47HeroSkill"), myPlayerEntity.GetPlayerInfo().Ak47HeroSkillUser);
			}
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		return true;
	}
}
