using Assets.Generated.Table;
using Assets.Sources.Components.GameRule.Common;
using Assets.Sources.Components.Message.DeathMatch;
using Assets.Sources.Utils.Sound;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using SSJJMath;
using UnityEngine;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class DeathMatchMessageHandler : ApcPacketHandler<DeathMatchMessageData>
{
	private GameRuleContext _gameRuleContext;

	private PlayerContext _playerContext;

	private string[] _reliveMessage = new string[4] { "ReliveplayerGoodtoppraisek", "ReliveplayerNicework", "ReliveplayerBattle", "ReliveplayerWin" };

	private string[] _paryMessage = new string[5] { "ReliveMe", "ReliveMeComeback", "ReliveMeThanks", "ReliveMeLookout", "ReliveMeHpmax" };

	private MessageContext _messageContext;

	private ChatContext _chatContext;

	public DeathMatchMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_gameRuleContext = contexts.gameRule;
		_playerContext = contexts.player;
		_chatContext = contexts.chat;
	}

	public override int MethodId()
	{
		return 56;
	}

	public override void Handle(DeathMatchMessageData data)
	{
		if (!_playerContext.isMyPlayer)
		{
			return;
		}
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		switch (data.Type)
		{
		case DeathMatchMessageType.RELIVEPLAYER:
		{
			if (data.Team == myPlayerEntity.GetTeam())
			{
				if (_chatContext.hasChatJobHistroy)
				{
					_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message from=\"{2}\" type=\"{0}\" ><body>{1}</body></message>", "prompt", string.Format(ScriptLocalization.Get(_reliveMessage[data.RandSay]), data.PlayerName, data.TargetPlayerName, data.TargetPlayerName), ""));
				}
				break;
			}
			KillPlayerInfoData killPlayerInfoData = new KillPlayerInfoData();
			killPlayerInfoData.KillPlayerName = data.PlayerName;
			killPlayerInfoData.BeKillPlayerName = data.TargetPlayerName;
			killPlayerInfoData.WeaponName = "relive";
			int killTeam = (killPlayerInfoData.BekillTeam = data.Team);
			killPlayerInfoData.KillTeam = killTeam;
			KillPlayerInfoComponent killPlayerInfo = _gameRuleContext.killPlayerInfo;
			killPlayerInfo.InfoList.Clear();
			killPlayerInfo.InfoList.Enqueue(killPlayerInfoData);
			NotifyManager.ForceInvoke(22);
			killPlayerInfo.Changed = true;
			break;
		}
		case DeathMatchMessageType.SENDHELP:
			_messageContext.deathMatchMessage.ParyMessage.Add(new DeathMatchMessageComponent.ParyReliveData
			{
				PlayerId = data.Id,
				ParyText = string.Format(ScriptLocalization.Get(_paryMessage[Random.Range(0, _paryMessage.Length)]), data.PlayerName)
			});
			NotifyManager.ForceInvoke(60);
			break;
		case DeathMatchMessageType.CANCELHELP:
		{
			for (int i = 0; i < _messageContext.deathMatchMessage.ParyMessage.Count; i++)
			{
				if (_messageContext.deathMatchMessage.ParyMessage[i].PlayerId == data.Id)
				{
					_messageContext.deathMatchMessage.ParyMessage.RemoveAt(i);
					i--;
				}
			}
			_messageContext.deathMatchMessage.CancelPary = data.Id;
			NotifyManager.ForceInvoke(30);
			NotifyManager.ForceInvoke(60);
			break;
		}
		case DeathMatchMessageType.RELIVESOUND:
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play3DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/deathmatch", "Assets/Res/Assets/sound/deathmatch/helprelive.mp3"), VectorCoordConverter.SsjjToUnity(new Vector3(data.X, data.Y, data.Z)), GameSoundManager.Config.AsideVolume, 3000);
			break;
		default:
			_ = data.Type;
			_ = 1;
			_messageContext.deathMatchMessage.MessageType = (int)data.Type;
			NotifyManager.ForceInvoke(29);
			_messageContext.deathMatchMessage.Name = data.PlayerName;
			break;
		}
	}
}
