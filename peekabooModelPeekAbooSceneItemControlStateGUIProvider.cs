using Assets.Generated.Table;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Sound;
using NetData;
using SSJJAsset.Asset;
using SSJJBase.Singleton;

public class peekabooModelPeekAbooSceneItemControlStateGUIProvider : IpeekabooModelPeekAbooSceneItemControlStateGUIProvider, IModuleProvider
{
	protected BattleRoomContext _roomContext;

	private MessageContext _msgContext;

	private PlayerContext _playerContext;

	private int stateImageShowTime;

	private int lastControlState;

	private int MAX_SHOW_TIME = 3000;

	private string tipPngNames = "";

	public peekabooModelPeekAbooSceneItemControlStateGUIProvider(Contexts contexts)
	{
		_roomContext = contexts.battleRoom;
		_msgContext = contexts.message;
		_playerContext = contexts.player;
	}

	public void OnFrame(TimeComponent time)
	{
		if (stateImageShowTime > 0)
		{
			stateImageShowTime -= time.FrameInterval;
		}
		PeekAbooMessageData data = _msgContext.peekabooMessageData.data;
		if (_msgContext.peekabooMessageData.sceneItemControlStateChanged)
		{
			_msgContext.peekabooMessageData.sceneItemControlStateChanged = false;
			if (data.Type == PeekAbooMessageType.STARTGAME)
			{
				lastControlState = SceneItemControlStateConstant.CONTROL_NULL;
			}
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity == null || _roomContext.playerInfo.PlayerInfoDatas == null)
		{
			return;
		}
		_roomContext.playerInfo.PlayerInfoDatas.TryGetValue(myPlayerEntity.GetCharacterId(), out var value);
		int num = -1;
		if (value != null)
		{
			num = value.ControlState;
		}
		if (num != lastControlState)
		{
			if (SceneItemControlStateConstant.CONTROL_THIRD == lastControlState && SceneItemControlStateConstant.CONTROL_CAMERA == num)
			{
				playModeSnd("unlock");
				tipPngNames = "incamera";
				stateImageShowTime = MAX_SHOW_TIME;
			}
			else if (SceneItemControlStateConstant.CONTROL_CAMERA == lastControlState && SceneItemControlStateConstant.CONTROL_THIRD == num)
			{
				playModeSnd("unlock");
				tipPngNames = "outcamera";
				stateImageShowTime = MAX_SHOW_TIME;
			}
			else if (SceneItemControlStateConstant.CONTROL_ITEM == lastControlState && SceneItemControlStateConstant.CONTROL_THIRD == num)
			{
				playModeSnd("lock");
				tipPngNames = "lockitem";
				stateImageShowTime = MAX_SHOW_TIME;
			}
			else if (SceneItemControlStateConstant.CONTROL_THIRD == lastControlState && SceneItemControlStateConstant.CONTROL_ITEM == num)
			{
				playModeSnd("lock");
				tipPngNames = "unlockitem";
				stateImageShowTime = MAX_SHOW_TIME;
			}
			lastControlState = num;
		}
	}

	private void playModeSnd(string soundUrl)
	{
		if (soundUrl != "")
		{
			AssetInfo soundUrl2 = SoundResourceUtility.GetSoundUrl(25, soundUrl);
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, soundUrl2, GameSoundManager.Config.AsideVolume);
		}
	}

	public bool updateTipShow()
	{
		if (2 == _playerContext.myPlayerEntity.GetTeam() || _playerContext.myPlayerEntity.IsDead())
		{
			return false;
		}
		return stateImageShowTime > 0;
	}

	public string updateTipSrc()
	{
		return "/ui/GameGUIRes/peekabooModel/sceneItemControlState/" + tipPngNames;
	}

	public string updateEStarCountInfo()
	{
		return string.Concat(_msgContext.peekabooMessageData.peekabooSkillUseStars);
	}

	public bool updateConEVisible()
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		PeekAbooMessageData data = _msgContext.peekabooMessageData.data;
		if (myPlayerEntity != null && data != null && myPlayerEntity.GetTeam() == 1 && data.Type != 0)
		{
			return true;
		}
		return false;
	}
}
