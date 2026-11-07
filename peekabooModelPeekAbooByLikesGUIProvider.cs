using Assets.Sources.Components.Time;

public class peekabooModelPeekAbooByLikesGUIProvider : IpeekabooModelPeekAbooByLikesGUIProvider, IModuleProvider
{
	protected GameRuleContext _gameRuleContext;

	private int effectTime;

	private int EFFECT_TIME = 300;

	private int LIKESIMAGE_COUNT = 10;

	private float EFFECT_SPEED = 0.0016666667f;

	private int timeScaler = 1;

	private int showCount;

	private float scale;

	private float itemWidth = 60f;

	private float itemHeight = 60f;

	private float itemGap = 50f;

	public peekabooModelPeekAbooByLikesGUIProvider(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public void OnFrame(TimeComponent time)
	{
		if (_gameRuleContext.peekabooLikes.LikesCount > 0)
		{
			effectTime += time.FrameInterval * timeScaler;
			if (effectTime > EFFECT_TIME)
			{
				effectTime = EFFECT_TIME;
				timeScaler = -1;
			}
			else if (effectTime < 0)
			{
				effectTime = 0;
				timeScaler = 1;
			}
			scale = 1.5f - (float)effectTime * EFFECT_SPEED;
		}
		if (_gameRuleContext.peekabooLikes.likesCountChange)
		{
			_gameRuleContext.peekabooLikes.likesCountChange = false;
			effectTime = 0;
			timeScaler = 1;
			int likesCount = _gameRuleContext.peekabooLikes.LikesCount;
			showCount = likesCount / 100;
			int num = likesCount % 100;
			showCount += num / 50;
			num %= 50;
			showCount += num / 10;
			num %= 10;
			showCount += num / 5;
			num %= 5;
			showCount += num;
		}
	}

	public bool updateImgVisibleByIndex(int index)
	{
		return index < showCount;
	}

	public string updateImgSrc(int index)
	{
		int likesCount = _gameRuleContext.peekabooLikes.LikesCount;
		int num = likesCount / 100;
		if (index < num)
		{
			return "/ui/GameGUIRes/peekabooModel/bylikes/100";
		}
		int num2 = num;
		int num3 = likesCount % 100;
		num = num3 / 50;
		num2 += num;
		if (index < num2)
		{
			return "/ui/GameGUIRes/peekabooModel/bylikes/50";
		}
		num3 %= 50;
		num = num3 / 10;
		num2 += num;
		if (index < num2)
		{
			return "/ui/GameGUIRes/peekabooModel/bylikes/10";
		}
		num3 %= 10;
		num = num3 / 5;
		num2 += num;
		if (index < num2)
		{
			return "/ui/GameGUIRes/peekabooModel/bylikes/5";
		}
		return "/ui/GameGUIRes/peekabooModel/bylikes/1";
	}

	public float updateImgX(int index)
	{
		float num = 1850f;
		if (index != showCount - 1)
		{
			return num;
		}
		return num - (scale - 1f) * itemWidth * 0.5f;
	}

	public float updateImgY(int index)
	{
		float num = -290f - (float)index * itemGap;
		if (index != showCount - 1)
		{
			return 0f - num;
		}
		return (num + (scale - 1f) * itemHeight * 0.5f) * -1f;
	}

	public string updateImgSize(int index)
	{
		if (index != showCount - 1)
		{
			return "60,60";
		}
		return scale * itemWidth + "," + scale * itemHeight;
	}
}
