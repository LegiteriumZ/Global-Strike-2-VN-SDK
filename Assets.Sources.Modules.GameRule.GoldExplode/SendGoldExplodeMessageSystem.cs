using Assets.Sources.Framework;
using NetData;

namespace Assets.Sources.Modules.GameRule.GoldExplode;

public class SendGoldExplodeMessageSystem : IGameRulePlaybackSystem, IPlaybackSystem
{
	private BattleServerContext _battleServerContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	public SendGoldExplodeMessageSystem(Contexts contexts)
	{
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_battleServerContext = contexts.battleServer;
	}

	public void OnPlayback()
	{
		if (_gameRuleContext.buyPanelData.WeaponType >= 0 && _gameRuleContext.buyPanelData.WeaponIndex >= 0)
		{
			BuyIndexData buyIndexData = new BuyIndexData();
			buyIndexData.PackageId = _gameRuleContext.buyPanelData.WeaponType;
			buyIndexData.ItemIndex = _gameRuleContext.buyPanelData.WeaponIndex;
			_battleServerContext.battleServer.Server.SendTcpMessage(17, buyIndexData);
			_gameRuleContext.buyPanelData.WeaponType = -1;
			_gameRuleContext.buyPanelData.WeaponIndex = -1;
			_gameRuleContext.buyPanelData.GiveWeaponIndex = -1;
		}
		else if (_gameRuleContext.buyPanelData.GiveWeaponIndex > 0)
		{
			ProtoIntData protoIntData = new ProtoIntData();
			protoIntData.Data = _gameRuleContext.buyPanelData.GiveWeaponIndex;
			_battleServerContext.battleServer.Server.SendTcpMessage(5, protoIntData);
			_gameRuleContext.buyPanelData.WeaponType = -1;
			_gameRuleContext.buyPanelData.WeaponIndex = -1;
			_gameRuleContext.buyPanelData.GiveWeaponIndex = -1;
		}
	}

	public bool NeedStart(Contexts contexts)
	{
		int raceType = _battleRoomContext.roomData.Data.RaceType;
		if (raceType != 61)
		{
			return raceType == 27;
		}
		return true;
	}
}
