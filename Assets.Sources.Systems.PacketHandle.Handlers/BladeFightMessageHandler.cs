using Assets.Sources.Components.GameRule.Blade;
using NetData;
using NotifyEvent;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

internal class BladeFightMessageHandler : ApcPacketHandler<BladeFightMessageData>
{
	private readonly GameRuleContext _gameRuleContext;

	public BladeFightMessageHandler(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
	}

	public override int MethodId()
	{
		return 275;
	}

	public override void Handle(BladeFightMessageData data)
	{
		BladeFightWaitStartDataComponent bladeFightWaitStartData = _gameRuleContext.bladeFightWaitStartData;
		BladeFightFogAreaTimeDataComponent bladeFightFogAreaTimeData = _gameRuleContext.bladeFightFogAreaTimeData;
		BladeFightSurplusPlayerDataComponent bladeFightSurplusPlayerData = _gameRuleContext.bladeFightSurplusPlayerData;
		BladeFightMessageDataComponent bladeFightMessageData = _gameRuleContext.bladeFightMessageData;
		BladeFightReliveDataComponent bladeFightReliveData = _gameRuleContext.bladeFightReliveData;
		BladeFightReliveBagPickingDataComponent bladeFightReliveBagPickingData = _gameRuleContext.bladeFightReliveBagPickingData;
		BladeFightGameOverDataComponent bladeFightGameOverData = _gameRuleContext.bladeFightGameOverData;
		if (data.Type == BladeFightMessageType.WaitStatus)
		{
			bladeFightWaitStartData.isWaitPlayer = true;
			if (data.IntData != null)
			{
				bladeFightWaitStartData.waitTimeState = data.IntData[0];
				bladeFightWaitStartData.maxTime = data.IntData[1];
				bladeFightWaitStartData.currentTime = data.IntData[2];
				bladeFightWaitStartData.currentPlayerCount = data.IntData[3];
				bladeFightWaitStartData.maxPlayerCount = data.IntData[4];
			}
		}
		else if (data.Type == BladeFightMessageType.EndWait)
		{
			bladeFightWaitStartData.isWaitPlayer = false;
		}
		else if (data.Type == BladeFightMessageType.GameStartCountDown)
		{
			bladeFightMessageData.isWaitRealStart = true;
			if (data.IntData != null)
			{
				bladeFightMessageData.topMessageTime = data.IntData[0];
			}
		}
		else if (data.Type == BladeFightMessageType.FogAreaDecreaseCountDown)
		{
			if (data.IntData != null)
			{
				bladeFightFogAreaTimeData.time = ((data.IntData[0] >= 0) ? data.IntData[0] : 0);
			}
		}
		else if (data.Type == BladeFightMessageType.RealStart)
		{
			bladeFightFogAreaTimeData.isGameStart = true;
			bladeFightSurplusPlayerData.isGameStart = true;
			bladeFightMessageData.isWaitRealStart = false;
			bladeFightReliveData.isGameStart = true;
		}
		else if (data.Type == BladeFightMessageType.AlivePlayerNum)
		{
			if (data.IntData != null)
			{
				bladeFightSurplusPlayerData.surplusPlayerCount = data.IntData[0];
			}
		}
		else if (data.Type == BladeFightMessageType.SafeAreaTimeToDecrease)
		{
			bladeFightMessageData.isSafeAreaRefresh = false;
			bladeFightMessageData.isFogAreaRefresh = true;
			bladeFightMessageData.topMessageTime = 3000;
		}
		else if (data.Type == BladeFightMessageType.NewSafeArea)
		{
			bladeFightMessageData.isFogAreaRefresh = false;
			bladeFightMessageData.isSafeAreaRefresh = true;
			bladeFightMessageData.topMessageTime = 3000;
		}
		else if (data.Type == BladeFightMessageType.ReliveBagPickSuccess)
		{
			bladeFightMessageData.isTargetGetEnergyPack = false;
			bladeFightMessageData.isGetEnergyPack = true;
			bladeFightMessageData.bottonMessageTime = 3000;
		}
		else if (data.Type == BladeFightMessageType.OtherPicks)
		{
			bladeFightMessageData.isGetEnergyPack = false;
			bladeFightMessageData.isTargetGetEnergyPack = true;
			bladeFightMessageData.bottonMessageTime = 3000;
		}
		else if (data.Type == BladeFightMessageType.Observe)
		{
			bladeFightMessageData.isObserver = true;
		}
		else if (data.Type == BladeFightMessageType.ReliveTimes)
		{
			if (data.IntData != null)
			{
				bladeFightReliveData.reliveCount = data.IntData[0];
			}
		}
		else if (data.Type == BladeFightMessageType.ReliveBagPicking)
		{
			bladeFightReliveBagPickingData.time = 0;
			if (data.BoolData != null && data.BoolData[0] && data.IntData != null)
			{
				bladeFightReliveBagPickingData.maxTime = data.IntData[0];
			}
			if (data.BoolData != null && !data.BoolData[0])
			{
				bladeFightReliveBagPickingData.time = bladeFightReliveBagPickingData.maxTime;
			}
		}
		else if (data.Type == BladeFightMessageType.PlayerEnd)
		{
			bladeFightGameOverData.ranking = data.IntData[0];
			bladeFightGameOverData.killNum = data.IntData[1];
			bladeFightGameOverData.damage = data.IntData[2];
			bladeFightGameOverData.time = 5000;
		}
		NotifyManager.ForceInvoke(86);
	}
}
