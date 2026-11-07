using Assets.Sources.Config;
using Assets.Sources.CsvLoader;
using Assets.Sources.Free.Data;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Ui;
using NetData;
using SSJJ.BattleLoading;
using SSJJBase.Logger;
using SSJJBase.Singleton;

namespace Assets.Sources.Systems.PacketHandle.Handlers;

public class OnGameinitDataHandler : ApcPacketHandler<OnGameinitData>
{
	private readonly GameRuleContext _gameRuleContext;

	private readonly BattleRoomContext _battleRoomContext;

	private readonly BattleServerContext _battleServerContext;

	private readonly MessageContext _msgContext;

	public OnGameinitDataHandler(Contexts contexts)
	{
		_msgContext = contexts.message;
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_battleServerContext = contexts.battleServer;
	}

	private void GoToBattleLoading(OnGameinitData data)
	{
		MonoBehaviourSingleton<BattleLoadingManager>.Instance.LoadResourceAndWaitBattleBegin(data);
	}

	public override int MethodId()
	{
		return 3;
	}

	public void ClearPreloadingRey(OnGameinitData data)
	{
		data.PlayerList.Clear();
		data.WeaponSkinList.Clear();
		data.WeaponList.Clear();
		data.SceneWeaponList.Clear();
		data.SceneBufferList.Clear();
	}

	public override void Handle(OnGameinitData data)
	{
		this.Info("Receive Data,Loading.....");
		if (data.ObfuscatorSeed != null)
		{
			_battleRoomContext.roomData.ObfuscatorSeed = new float[3]
			{
				data.ObfuscatorSeed.X,
				data.ObfuscatorSeed.Y,
				data.ObfuscatorSeed.Z
			};
		}
		_battleRoomContext.roomData.IsObserver = data.IsObserver;
		_battleRoomContext.roomData.IsWoman = data.IsWoman;
		_battleRoomContext.roomData.EngineId = data.EngineID;
		GlobalProperties.Instance.Properties["SceneId"] = data.SceneId;
		if (data.DefaultUseTcp || SpecailDebug.Instance.UseTcp)
		{
			_battleServerContext.battleServer.Server.ForceUseTcp();
		}
		GoToBattleLoading(data);
		_gameRuleContext.newbieGuideData.NewbieGuideModel.NewbieGuideFlag = data.NewbieGuide;
		_gameRuleContext.newbieGuideData.NewbieGuideModel.NewbieGuideBag = data.NewbieGuideBag;
		GameModelLocator.GetInstance().GameModel.IsObserver = data.IsObserver;
		if (_battleRoomContext.roomData.Data.RaceType == 25)
		{
			_msgContext.peekabooMessageData.itemIds = data.SceneItemIconList;
		}
		GameSettingLoader.Instance.Table.UpdateRowList();
		GameSetting.SendServer();
		SingletonInstance<BossDescribeData>.Instance.BossTipsHpRage = data.BossTipsHpRage;
		SingletonInstance<BossDescribeData>.Instance.ExtraInfoBool = data.ExtraInfoBool;
	}
}
