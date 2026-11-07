using System;
using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

public class peekabooModelPeekAbooMessageGUIProvider : IpeekabooModelPeekAbooMessageGUIProvider, IModuleProvider
{
	protected MessageContext _context;

	private PlayerContext _playerContext;

	private int messageTime;

	private int selfMessageShowTimer;

	private string playeringSound;

	private float scale;

	private int addScale;

	public peekabooModelPeekAbooMessageGUIProvider(Contexts contexts)
	{
		_context = contexts.message;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		if (messageTime > 0)
		{
			messageTime -= time.FrameInterval;
		}
		if (selfMessageShowTimer > 0)
		{
			selfMessageShowTimer -= time.FrameInterval;
		}
		if (_context.peekabooMessageData.changed)
		{
			messageTime = _context.peekabooMessageData.data.Time;
			_context.peekabooMessageData.changed = false;
			if (_context.peekabooMessageData.data.Type == PeekAbooMessageType.ITEMBEKILL)
			{
				selfMessageShowTimer = 3000;
			}
			playChangeMessageTypeSnd();
		}
		if (_context.peekabooMessageData.data != null && _context.peekabooMessageData.data.Special)
		{
			scale += (float)(addScale * time.FrameInterval) * 0.0008f;
			if (scale > 1f)
			{
				addScale = -1;
				scale = 1f;
			}
			else if (scale < 0.75f)
			{
				addScale = 1;
				scale = 0.75f;
			}
		}
		updateSound();
	}

	private void playChangeMessageTypeSnd()
	{
		PeekAbooMessageType type = _context.peekabooMessageData.data.Type;
		string text = "";
		if (PeekAbooMessageType.ZHUANPANSELECTSUCCESS == type)
		{
			text = "selectitemok";
		}
		else if (PeekAbooMessageType.STARTGAME == type)
		{
			AssetInfo info = SoundResourceUtility.GetSoundUrl(25, "lasttime");
			MonoBehaviourSingleton<GameSoundManager>.Instance.StopSound(ref info);
			text = "startgame";
		}
		else if (PeekAbooMessageType.LASTTIEM == type)
		{
			text = "lasttime";
		}
		if (text != "")
		{
			AssetInfo soundUrl = SoundResourceUtility.GetSoundUrl(25, text);
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, soundUrl, GameSoundManager.Config.AsideVolume);
		}
	}

	private void updateSound()
	{
		if (_context.peekabooMessageData.data == null)
		{
			return;
		}
		PeekAbooMessageType type = _context.peekabooMessageData.data.Type;
		string text = "";
		if (type != 0)
		{
			if (messageTime < 1000)
			{
				playeringSound = "";
			}
			else if (PeekAbooMessageType.LASTTIEM == type || PeekAbooMessageType.CHANGEITEM == type)
			{
				if (messageTime < 2000)
				{
					text = "1";
				}
				else if (messageTime < 3000)
				{
					text = "2";
				}
				else if (messageTime < 4000)
				{
					text = "3";
				}
				else if (messageTime < 5000)
				{
					text = "4";
				}
				else if (messageTime < 6000)
				{
					text = "5";
				}
				else if (messageTime < 7000)
				{
					text = "6";
				}
				else if (messageTime < 8000)
				{
					text = "7";
				}
				else if (messageTime < 9000)
				{
					text = "8";
				}
				else if (messageTime < 10000)
				{
					text = "9";
				}
			}
		}
		if (text != playeringSound)
		{
			playeringSound = text;
			AssetInfo soundUrl = SoundResourceUtility.GetSoundUrl(25, text);
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, soundUrl, GameSoundManager.Config.AsideVolume);
		}
	}

	public bool updateImgSpecialVisible()
	{
		if (_context.peekabooMessageData.data == null)
		{
			return false;
		}
		if (_context.peekabooMessageData.data.Special)
		{
			return messageTime > 0;
		}
		return false;
	}

	public bool updateImgStartGameVisile()
	{
		if (_context.peekabooMessageData.data == null)
		{
			return false;
		}
		return _context.peekabooMessageData.data.Type switch
		{
			PeekAbooMessageType.WAITPLAYER => true, 
			PeekAbooMessageType.ITEMBEKILL => false, 
			_ => messageTime > 0, 
		};
	}

	public string updateImgStartGame()
	{
		switch (_context.peekabooMessageData.data.Type)
		{
		case PeekAbooMessageType.STARTGAME:
		{
			PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
			if (1 == myPlayerEntity.GetTeam())
			{
				return "/ui/GameGUIRes/peekabooModel/message/startgamet";
			}
			return "/ui/GameGUIRes/peekabooModel/message/startgamect";
		}
		case PeekAbooMessageType.WAITPLAYER:
			return "/ui/GameGUIRes/peekabooModel/message/waitplayer";
		case PeekAbooMessageType.CHANGEITEM:
			return "/ui/GameGUIRes/peekabooModel/message/changeitem";
		case PeekAbooMessageType.LASTTIEM:
			return "/ui/GameGUIRes/peekabooModel/message/lasttime";
		case PeekAbooMessageType.ITEMBEKILL:
			return "/ui/GameGUIRes/peekabooModel/message/bekill";
		default:
			return "";
		}
	}

	public bool updateTxtTimeRedVisible()
	{
		if (_context.peekabooMessageData.data == null)
		{
			return false;
		}
		PeekAbooMessageType type = _context.peekabooMessageData.data.Type;
		if (type == PeekAbooMessageType.CHANGEITEM || type == PeekAbooMessageType.LASTTIEM)
		{
			return messageTime > 0;
		}
		return false;
	}

	public bool updateTxtTimeVisible()
	{
		if (_context.peekabooMessageData.data == null)
		{
			return false;
		}
		if (_context.peekabooMessageData.data.Type == PeekAbooMessageType.STARTGAME)
		{
			return messageTime > 0;
		}
		return false;
	}

	public float updateTxtTimeX()
	{
		return _context.peekabooMessageData.data.Type switch
		{
			PeekAbooMessageType.LASTTIEM => 990f, 
			PeekAbooMessageType.CHANGEITEM => 1070f, 
			_ => 0f, 
		};
	}

	public float updateTxtTimeY()
	{
		return 165f;
	}

	public bool updateTxtPlayerCountVisible()
	{
		if (_context.peekabooMessageData.data == null)
		{
			return false;
		}
		if (_context.peekabooMessageData.data.Type == PeekAbooMessageType.WAITPLAYER)
		{
			return true;
		}
		return false;
	}

	public float updateTxtWaitPlayer()
	{
		return _context.peekabooMessageData.data.WaitingPlayerNum;
	}

	public bool updateSelfMessageVisible()
	{
		return selfMessageShowTimer > 0;
	}

	public float updateTime()
	{
		return Math.Max(messageTime / 1000, 0);
	}

	public float updateImgSpecialY()
	{
		return (-113f + (scale - 1f) * 37f * 0.5f) * -1f;
	}

	public float updateImgSpecialX()
	{
		return 882f - (scale - 1f) * 156f * 0.5f;
	}

	public string updateSpecialSize()
	{
		return 256f * scale + "," + 64f * scale;
	}
}
