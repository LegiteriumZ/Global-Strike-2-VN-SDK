using Assets.Sources.Components.Time;
using NetData;

public class peekabooModelPeekAbooHumanityBackGUIProvider : IpeekabooModelPeekAbooHumanityBackGUIProvider, IModuleProvider
{
	private MessageContext _msgContext;

	private PlayerContext _playerContext;

	private int hideTime;

	public peekabooModelPeekAbooHumanityBackGUIProvider(Contexts contexts)
	{
		_msgContext = contexts.message;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		if (hideTime > 0)
		{
			hideTime -= time.FrameInterval;
		}
		if (_msgContext.peekabooMessageData.humanityBackChanged)
		{
			_msgContext.peekabooMessageData.humanityBackChanged = false;
			if (_msgContext.peekabooMessageData.data.Type == PeekAbooMessageType.STARTGAME)
			{
				hideTime = _msgContext.peekabooMessageData.data.Time;
			}
		}
	}

	public bool updateRootShow()
	{
		if (2 == _playerContext.myPlayerEntity.GetTeam())
		{
			return hideTime > 0;
		}
		return false;
	}
}
