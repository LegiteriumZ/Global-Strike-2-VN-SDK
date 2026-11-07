namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class ClearForNewSectionHandler : ApcPacketHandler<object>
{
	private MessageContext _messageContext;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	public ClearForNewSectionHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_battleRoomContext = contexts.battleRoom;
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 62;
	}

	public override void Handle(object data)
	{
		if (_messageContext.hasFinalBioMessageData)
		{
			_messageContext.finalBioMessageData.AntidoteNum = 0;
			_messageContext.finalBioMessageData.SuperbioVariantsChanged = true;
		}
		if (_battleRoomContext.playerInfo.CurrKillNums != null)
		{
			_battleRoomContext.playerInfo.CurrKillNums.Clear();
		}
		if (_playerContext.cameraOwnerEntity != null && _playerContext.cameraOwnerEntity.hasCurrKill)
		{
			_playerContext.cameraOwnerEntity.currKill.Count = 0;
		}
		_messageContext.bioMessageData.IsDeathMax = false;
		_messageContext.bioMessageData.IsChangedDeath = false;
		_messageContext.bioMessageData.IsHeroChanged = false;
		_messageContext.bioMessageData.IsChangedQueen = false;
		_messageContext.bigHeadMessage.CanChangeHero = false;
		_messageContext.bigHeadMessage.WateHeroDebut = false;
		_messageContext.bigHeadMessage.LastTime = false;
		_messageContext.gameMessageData.MessageData = null;
		_battleRoomContext.gameOver.IsGameOver = false;
		_battleRoomContext.gameOver.IsGameOverDataChange = false;
		_gameRuleContext.selectZombie.Time = 0;
	}
}
