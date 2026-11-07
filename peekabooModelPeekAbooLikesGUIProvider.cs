using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using NetData;

public class peekabooModelPeekAbooLikesGUIProvider : IpeekabooModelPeekAbooLikesGUIProvider, IModuleProvider
{
	protected PlayerContext _playerContext;

	private BattleRoomContext _roomContext;

	public peekabooModelPeekAbooLikesGUIProvider(Contexts contexts)
	{
		_playerContext = contexts.player;
		_roomContext = contexts.battleRoom;
	}

	public void OnFrame(TimeComponent time)
	{
	}

	public bool checkLikesShow()
	{
		PlayerInfoData playerInfoData = _roomContext.playerInfo.GetPlayerInfoData(_playerContext.myPlayerEntity.GetCharacterId());
		if (playerInfoData != null && playerInfoData.ControlState == SceneItemControlStateConstant.CONTROL_FOLLOW)
		{
			return true;
		}
		return false;
	}
}
