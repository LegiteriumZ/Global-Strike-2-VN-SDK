using System.Collections.Generic;
using Assets.Sources.Components.Message.Bochemical;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Utility;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BioMessageHandler : ApcPacketHandler<BioMessageData>
{
	private readonly MessageContext _messageContext;

	private readonly ChatContext _chatContext;

	private readonly PlayerContext _playerContext;

	private readonly GameRuleContext _ruleContext;

	public BioMessageHandler(Contexts contexts)
	{
		_messageContext = contexts.message;
		_chatContext = contexts.chat;
		_ruleContext = contexts.gameRule;
		_playerContext = contexts.player;
	}

	public override int MethodId()
	{
		return 25;
	}

	public override void Handle(BioMessageData data)
	{
		if (data.ShowChatUI && _chatContext.hasChatJobHistroy)
		{
			switch (data.Type)
			{
			case BioMessageType.DROPITEM:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("GET_TARGETPLAYER_ITEM") + "</body></message>", "hononary1", ScriptLocalization.Get("itemname" + data.ItemId), data.Num));
				break;
			case BioMessageType.DEATHITEMCANUSE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("GET_DEATH_ITEM_CAN_USE") + "</body></message>", "hononary1", data.Num));
				break;
			case BioMessageType.DEATHITEMSELFUSE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("GET_DEATH_ITEM_SELF_USE") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.DEATHITEMBROADCASTUSE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("GET_DEATH_ITEM_BROADCAST_USE") + "</body></message>", "hononary1", data.PlayerName));
				break;
			case BioMessageType.DEATHITEMMAXDEATH:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("GET_DEATH_ITEM_MAX_DEATH") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.DEATHITEMTIMEOUT:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("GET_DEATH_ITEM_TIMEOUT") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.SUPERBIOCHEMICALSERUMUSE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("SUPERBIOCHEMICALSERUM_USE") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.SUPERBIOCHEMICALSERUMUSE2:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("SUPERBIOCHEMICALSERUM_USE2") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.ANTIDOTESELF:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("ANTIDOTE_SELF") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.ANTIDOTEBROADCAST:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("ANTIDOTE_BROADCAST") + "</body></message>", "hononary1", data.PlayerName));
				break;
			case BioMessageType.KNIFEKILLRELIVEUSE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("KNIFEKILLRELIVE_USE") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.KNIFEKILLRELIVEACTIVE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("KNIFEKILLRELIVE_ACTIVE") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.BIOADDBLOODUSE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("BIOADDBLOOD_USE") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.BIOTUMULTUOUSDRUGUSE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("BIO_TUMULTUOUS_DRUG_USE") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.MYSTERYSTARTFIRE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("MYSTERY_STARTFIRE") + "</body></message>", "hononary1", data.PlayerName));
				break;
			case BioMessageType.GETBIOITEM:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("GET_BIO_ITEM") + "</body></message>", "hononary1", ScriptLocalization.Get("itemname" + data.ItemId), data.Num));
				break;
			case BioMessageType.USEBIOSKILLUPGRADE:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("USE_BIO_SKILL_UPGRADE") + "</body></message>", "hononary1"));
				break;
			case BioMessageType.DROPBIOITEM:
				_chatContext.chatJobHistroy.ContentReceived.Enqueue(string.Format("<message type=\"{0}\" ><body>" + ScriptLocalization.Get("DROP_BIO_ITEM") + "</body></message>", "hononary1", ScriptLocalization.Get("itemname" + data.ItemId), data.PlayerName));
				break;
			case BioMessageType.HELPKILL:
			case BioMessageType.KNIFEKILLLEVELDOWN:
			case BioMessageType.LEVELDOWN:
			case (BioMessageType)116:
			case (BioMessageType)117:
				break;
			}
			return;
		}
		switch (data.Type)
		{
		case BioMessageType.BERESISTINFECTIONF:
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("ATTACK_BLOCKED"));
			NotifyManager.ForceInvoke(38);
			break;
		case BioMessageType.RESISTINFECTION:
			if (data.Num == 2)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("RESIST_INFECTION_ONE"));
				NotifyManager.ForceInvoke(38);
			}
			else if (data.Num == 1)
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("RESIST_INFECTION_TWO"));
				NotifyManager.ForceInvoke(38);
			}
			else
			{
				_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("RESIST_INFECTION_THIRD"));
				NotifyManager.ForceInvoke(38);
			}
			break;
		case BioMessageType.RESISTVARIATION:
			_messageContext.messageRemindData.SetMessage(PrintfUtility.Printf(ScriptLocalization.Get("RESIST_VARIATION_STR"), new string[2]
			{
				data.Num.ToString(),
				data.MaxNum.ToString()
			}));
			NotifyManager.ForceInvoke(38);
			break;
		case BioMessageType.RESISTVARIATIONWITHREMAIN:
			_messageContext.messageRemindData.SetMessage(string.Format(ScriptLocalization.Get("RESIST_VARIATION_WITH_REMAIN"), data.Num));
			NotifyManager.ForceInvoke(38);
			break;
		case BioMessageType.GETENCOURAGESUCCESS:
			NotifyManager.ForceInvoke(79);
			break;
		case BioMessageType.RESISTZOMBIEDAMAGESUCCESS:
			_messageContext.messageRemindData.SetMessage(ScriptLocalization.Get("RESISTZOMBIEDAMAGESUCCESS"));
			NotifyManager.ForceInvoke(38);
			break;
		case BioMessageType.TOTALDAMAGELEVEL:
			_ruleContext.bioEvolutionDamage.VisiableTime = 3000;
			_ruleContext.bioEvolutionDamage.Lv = data.Num;
			break;
		case BioMessageType.EXTRASKILLLV:
		{
			if (_ruleContext.bioEvolutionChallenge.LevelList == null || _ruleContext.bioEvolutionChallenge.LevelList.Count != 3)
			{
				_ruleContext.bioEvolutionChallenge.LevelList = new List<int> { 0, 0, 0 };
			}
			List<int> levelList = _ruleContext.bioEvolutionChallenge.LevelList;
			if (data.SkillName == 1)
			{
				levelList[0] = data.Level;
			}
			if (data.SkillName == 2)
			{
				levelList[1] = data.Level;
			}
			if (data.SkillName == 4)
			{
				levelList[2] = data.Level;
			}
			break;
		}
		case BioMessageType.AURASKILLNUM:
			_ruleContext.bioEvolutionChallenge.AuraLevel = data.Level;
			break;
		case BioMessageType.HUMANCAREERCHOOSE:
			_ruleContext.bioEvolutionChallenge.SelectHumanSelectId = data.Num;
			_ruleContext.bioEvolutionChallenge.SelectHumanVisibleTime = 5000;
			break;
		case BioMessageType.PLAYERBATTLECAREERDATA:
		{
			if (_ruleContext.bioEvolutionChallenge.BioCareerLevels == null)
			{
				_ruleContext.bioEvolutionChallenge.BioCareerLevels = new Dictionary<int, int>();
			}
			Dictionary<int, int> bioCareerLevels = _ruleContext.bioEvolutionChallenge.BioCareerLevels;
			if (bioCareerLevels.ContainsKey(data.SkillName))
			{
				bioCareerLevels[data.SkillName] = data.Level;
			}
			else
			{
				bioCareerLevels.Add(data.SkillName, data.Level);
			}
			break;
		}
		}
		DealBioMessageData(data);
	}

	public void DealBioMessageData(BioMessageData data)
	{
		BioMessageDataComponent bioMessageData = _messageContext.bioMessageData;
		MessageDataInfo messageDataInfo = new MessageDataInfo();
		messageDataInfo.Type = data.Type;
		messageDataInfo.PlayerName = data.PlayerName;
		messageDataInfo.KillCount = data.Num;
		bioMessageData.Message = messageDataInfo;
		bioMessageData.Bio2SKillName = data.Bio2SkillName;
		bioMessageData.Level = data.Level;
		bioMessageData.Time = data.Time;
		switch (data.Type)
		{
		case BioMessageType.SUPERHUMANITY:
			bioMessageData.SkillName = data.SkillName;
			break;
		case BioMessageType.DEATHMAX:
			bioMessageData.IsDeathMax = true;
			bioMessageData.IsChangedDeath = false;
			break;
		case BioMessageType.CHANGEDEATH:
			bioMessageData.IsChangedDeath = true;
			break;
		case BioMessageType.HERODEBUT:
			bioMessageData.IsHeroChanged = true;
			break;
		case BioMessageType.NOHERODEBUT:
			bioMessageData.IsChangedQueen = false;
			bioMessageData.IsChangedDeath = false;
			bioMessageData.IsHeroChanged = false;
			bioMessageData.IsUltimateTime = false;
			bioMessageData.IsTidevariationTime = false;
			bioMessageData.IsWaitEultimateTime = false;
			bioMessageData.IsUltimateStartTime = false;
			bioMessageData.IsChangeMesh = false;
			bioMessageData.IsMeshMax = false;
			break;
		case BioMessageType.CHANGEHEROOVER:
			bioMessageData.IsHeroChanged = false;
			break;
		case BioMessageType.ULTIMATETIMESTART:
			bioMessageData.IsUltimateTime = true;
			bioMessageData.IsUltimateStartTime = true;
			bioMessageData.IsTidevariationTime = false;
			break;
		case BioMessageType.TIDEVARIATIONSTART:
			bioMessageData.IsTidevariationTime = true;
			break;
		case BioMessageType.WAITEULTIMATETIMESTART:
			bioMessageData.IsWaitEultimateTime = true;
			break;
		case BioMessageType.CHANGEMESHWARRIOR:
			bioMessageData.IsChangeMesh = true;
			break;
		case BioMessageType.CHANGEMESHMAX:
			bioMessageData.IsMeshMax = true;
			break;
		case BioMessageType.CHANGEQUEEN:
			bioMessageData.IsChangedQueen = true;
			break;
		case BioMessageType.GETSKILL:
			bioMessageData.IsBio2SKillChanged = true;
			break;
		case BioMessageType.WAITPLAYER:
			bioMessageData.IsBio2WaitingPlayerNumChanged = true;
			bioMessageData.WaitingPlayerNum = data.Num;
			break;
		case BioMessageType.ENCOURAGE:
			bioMessageData.Encourage = data.Num == 1;
			break;
		case BioMessageType.COPYSTATUS:
			bioMessageData.CopyStatus = data.Num == 1;
			break;
		case BioMessageType.PICKSTATUS:
			bioMessageData.PickTime = data.Num;
			bioMessageData.MaxTime = data.Num;
			break;
		}
	}
}
