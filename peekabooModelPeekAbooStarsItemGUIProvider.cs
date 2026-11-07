using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.Message.Peekaboo;
using Assets.Sources.Components.Time;
using NetData;

public class peekabooModelPeekAbooStarsItemGUIProvider : IpeekabooModelPeekAbooStarsItemGUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private MessageContext _msgContext;

	private readonly int MOVE_TIME = 300;

	private readonly int LIVE_STARS_COUNT = 8;

	private readonly float STARS_MOVE_SPEED = 0.02f;

	private readonly float STARS_ALPHA_SPEED = 0.002f;

	private readonly float ITEM_EFFECT_TIME = 300f;

	private readonly float ITEM_EFFECT_ALPHA_TIME = 200f;

	private bool imgStarShow;

	private bool isInStarMove;

	private int startMoveTime;

	private bool isInItemEffect;

	private int itemEffectTime;

	private float itemEffectAlpha = 1f;

	private float imgItemEffectScale;

	public peekabooModelPeekAbooStarsItemGUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_msgContext = contexts.message;
	}

	public void OnFrame(TimeComponent time)
	{
		imgStarShow = true;
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity == null || myPlayerEntity.IsDead() || myPlayerEntity.GetTeam() == 1)
		{
			imgStarShow = false;
		}
		else
		{
			GameProgressDataComponent gameProgressData = _gameRuleContext.gameProgressData;
			if (gameProgressData.ProgressType != ProgressType.ADDSTARS || gameProgressData.ProgressTotalTime <= 0)
			{
				imgStarShow = false;
			}
			else
			{
				gameProgressData.CurrentProgressTime += time.FrameInterval;
			}
		}
		PeekabooMessageDataComponent peekabooMessageData = _msgContext.peekabooMessageData;
		if (peekabooMessageData.starsCountChanged)
		{
			peekabooMessageData.starsCountChanged = false;
			isInStarMove = true;
			startMoveTime = 0;
		}
		if (isInStarMove)
		{
			startMoveTime += time.FrameInterval;
			if ((float)startMoveTime > (float)MOVE_TIME + 1f / STARS_ALPHA_SPEED)
			{
				isInStarMove = false;
			}
		}
		if (peekabooMessageData.pickItemChanged)
		{
			peekabooMessageData.pickItemChanged = false;
			if (peekabooMessageData.pickItemData.ItemId > 0)
			{
				isInItemEffect = true;
				itemEffectTime = 0;
				itemEffectAlpha = 1f;
			}
		}
		if (!isInItemEffect)
		{
			return;
		}
		itemEffectTime += time.FrameInterval;
		if ((float)itemEffectTime > ITEM_EFFECT_TIME)
		{
			itemEffectAlpha -= (float)time.FrameInterval / ITEM_EFFECT_ALPHA_TIME;
			if (itemEffectAlpha < 0f)
			{
				isInItemEffect = false;
			}
		}
		float num = 0f;
		num = ((!((float)itemEffectTime < ITEM_EFFECT_TIME)) ? (1f - ((float)itemEffectTime - ITEM_EFFECT_TIME) / ITEM_EFFECT_ALPHA_TIME) : ((float)itemEffectTime / ITEM_EFFECT_TIME));
		if (num < 0f)
		{
			num = 0f;
		}
		imgItemEffectScale = num;
	}

	public bool updateImgItemVisible()
	{
		PeekabooPickItemData pickItemData = _msgContext.peekabooMessageData.pickItemData;
		if (pickItemData != null && pickItemData.ItemId > 0)
		{
			return true;
		}
		return false;
	}

	public string updateImgItem()
	{
		PeekabooPickItemData pickItemData = _msgContext.peekabooMessageData.pickItemData;
		return "/ui/GameGUIRes/peekabooModel/item/" + pickItemData.ItemId;
	}

	public float updateStarCount()
	{
		PeekabooStarData starData = _msgContext.peekabooMessageData.starData;
		if (starData == null)
		{
			return 0f;
		}
		return starData.Result;
	}

	public float updateStarProgress()
	{
		GameProgressDataComponent gameProgressData = _gameRuleContext.gameProgressData;
		if (gameProgressData == null || gameProgressData.ProgressTotalTime == 0)
		{
			return 0f;
		}
		if (_playerContext.myPlayerEntity.GetTeam() == 2)
		{
			return 0f;
		}
		return (float)gameProgressData.CurrentProgressTime / (float)gameProgressData.ProgressTotalTime;
	}

	public bool updateConAddVisible()
	{
		if (isInStarMove)
		{
			return startMoveTime / MOVE_TIME >= 1;
		}
		return false;
	}

	public float updateConAddY()
	{
		return (-863f + (float)(startMoveTime - MOVE_TIME) * STARS_MOVE_SPEED) * -1f;
	}

	public bool updateImgLiveVisible()
	{
		PeekabooStarData starData = _msgContext.peekabooMessageData.starData;
		if (starData == null)
		{
			return false;
		}
		return starData.AddValue == LIVE_STARS_COUNT;
	}

	public float updateAddStarCount()
	{
		PeekabooStarData starData = _msgContext.peekabooMessageData.starData;
		if (starData == null)
		{
			return 0f;
		}
		return starData.AddValue;
	}

	public bool updateImgItemMoveVisible()
	{
		if (isInStarMove)
		{
			return startMoveTime / MOVE_TIME < 1;
		}
		return false;
	}

	public float updateMoveX()
	{
		float num = (float)startMoveTime / (float)MOVE_TIME;
		float num2 = 960f;
		float num3 = 1804f;
		return num2 + (num3 - num2) * num;
	}

	public float updateMoveY()
	{
		float num = (float)startMoveTime / (float)MOVE_TIME;
		float num2 = -481f;
		float num3 = -867f;
		return (num2 + (num3 - num2) * num) * -1f;
	}

	public bool updateItemEffectVisible()
	{
		return isInItemEffect;
	}

	public string updateItemEffectSize()
	{
		float num = 128f;
		return 128f * imgItemEffectScale + "," + num * imgItemEffectScale;
	}

	public float updateItemEffectX()
	{
		return 1794f - (imgItemEffectScale - 1f) * 66f * 0.5f;
	}

	public float updateItemEffectY()
	{
		return (-791f + (imgItemEffectScale - 1f) * 66f * 0.5f) * -1f;
	}
}
