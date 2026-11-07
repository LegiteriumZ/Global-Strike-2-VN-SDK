using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.Model;
using Assets.Sources.Ui.Model.Common;
using Assets.Sources.Ui.Model.Pve;
using Assets.Sources.Ui.Model.PveCommon;
using Assets.Sources.Ui.Model.Rpg;
using Assets.Sources.Ui.Model.Weapon;
using Assets.Sources.Ui.Model.common;
using Assets.Sources.Utils;
using Assets.UiFramework.Libs;
using SSJJBase.Input;

namespace Assets.Sources.Modules.Ui.Mode;

public abstract class AbstractMode : IPlaybackSystem
{
	private readonly Contexts _contexts;

	private readonly List<IPlaybackSystem> _playbackSystems;

	private readonly List<AbstractModel> _models;

	protected AbstractMode(Contexts contexts)
	{
		_contexts = contexts;
		_playbackSystems = new List<IPlaybackSystem>();
		_models = new List<AbstractModel>();
		AddPlaybackSystem(new AceReportModel());
		AddPlaybackSystem(new MenuModel());
		AddPlaybackSystem(new ReportModel());
		AddPlaybackSystem(new ReportAlertModel());
		AddPlaybackSystem(new HowToPlayModel());
		AddPlaybackSystem(new CommonMessageModel());
		AddPlaybackSystem(new CommonCrossModel());
		AddPlaybackSystem(new SniperCrossModel());
		AddPlaybackSystem(new HitCrossModel());
		AddPlaybackSystem(new AntiAddictionModel());
		if (!RuleUtilty.IsUltimateChallenge())
		{
			AddPlaybackSystem(new ChattingBigHornModel());
			AddPlaybackSystem(new ChattingLiveModel());
			AddPlaybackSystem(new ChatPanelModel());
			AddPlaybackSystem(new CommonTacticsSoundModel());
		}
		AddPlaybackSystem(new SkillProgressModel());
		AddPlaybackSystem(new McGameSettingModel());
		AddPlaybackSystem(new MessageRemindModel());
		AddPlaybackSystem(new ReLinkModel());
		AddPlaybackSystem(new ObtainSuppliesModel());
		AddPlaybackSystem(new BeingHitModel());
		if (_contexts.battleRoom.roomData.Data.RaceType != 100 || _contexts.battleRoom.roomData.Data.FreeType != "titForTat")
		{
			AddPlaybackSystem(new ObserverPlayerDataModel());
			AddPlaybackSystem(new ObserverAllKillInfoModel());
		}
		AddPlaybackSystem(new ObserverShadowModel());
		AddPlaybackSystem(new FlashExplosionModel());
		if (contexts.battleRoom.roomData.Data.IsPromise || contexts.battleRoom.roomData.Data.IsMatch)
		{
			AddPlaybackSystem(new PromiseMessageModel());
		}
		if (_contexts.battleRoom.roomData.Data.RaceType != 100)
		{
			AddPlaybackSystem(new ModeTitleModel());
		}
		int raceType = contexts.battleRoom.roomData.Data.RaceType;
		if (raceType != 17003)
		{
			AddPlaybackSystem(new PlayerShowTimeModel());
			AddPlaybackSystem(new CrystalModel());
			AddPlaybackSystem(new KillStateModel());
		}
		AddPlaybackSystem(new GunGloryModel());
		AddPlaybackSystem(new WeaponPendantDropModel());
		AddPlaybackSystem(new SceneBuffMessageModel());
		DoAddVoiceMode(raceType);
	}

	private void DoAddVoiceMode(int raceType)
	{
		if (!VoiceUtility.CheckVoiceIsForbidenForCreateMode(raceType))
		{
			AddPlaybackSystem(new VoiceModel());
			AddPlaybackSystem(new VoiceShieldModel());
		}
	}

	protected AbstractMode(Contexts contexts, bool flag)
	{
		_contexts = contexts;
		_playbackSystems = new List<IPlaybackSystem>();
		_models = new List<AbstractModel>();
	}

	public void Initialize()
	{
		foreach (IPlaybackSystem playbackSystem in _playbackSystems)
		{
			if (playbackSystem is AbstractModel)
			{
				Initialize(playbackSystem as AbstractModel);
			}
			else
			{
				InitializeSetter(playbackSystem);
			}
		}
	}

	private void Initialize(AbstractModel model)
	{
		InitializeSetter(model);
		model.Initialize();
	}

	private void InitializeSetter(object model)
	{
		if (model is ISetPlayerContext)
		{
			((ISetPlayerContext)model).SetPlayerContext(_contexts.player);
		}
		if (model is ISetBattleRoomContext)
		{
			((ISetBattleRoomContext)model).SetBattleRoomContext(_contexts.battleRoom);
		}
		if (model is ISetBattleServerContext)
		{
			((ISetBattleServerContext)model).SetBattleServerContext(_contexts.battleServer);
		}
		if (model is ISetPlayerBagContext)
		{
			((ISetPlayerBagContext)model).SetPlayerBagContext(_contexts.playerBag);
		}
		if (model is ISetWeaponContext)
		{
			((ISetWeaponContext)model).SetWeaponContext(_contexts.weapon);
		}
		if (model is ISetUserCommmandContext)
		{
			((ISetUserCommmandContext)model).SetUserCommandContext(_contexts.userCommand);
		}
		if (model is ISetGameRuleContext)
		{
			((ISetGameRuleContext)model).SetGameRuleContext(_contexts.gameRule);
		}
		if (model is ICursorControl)
		{
			Contexts.sharedInstance.userCommand.input.CursorControls.Add((ICursorControl)model);
		}
		if (model is IKeyboardResponder)
		{
			_contexts.userCommand.input.KeyboardResponders.Add((IKeyboardResponder)model);
		}
		if (model is ISetCameraContext)
		{
			((ISetCameraContext)model).SetCameraContext(_contexts.worldCamera);
		}
		if (model is ISetCrossContext)
		{
			((ISetCrossContext)model).SetCrossContext(_contexts.cross);
		}
		if (model is ISetSceneObjectContext setSceneObjectContext)
		{
			setSceneObjectContext.SetSceneObjectContext(_contexts.sceneObject);
		}
		if (model is ISetSnapShotContext setSnapShotContext)
		{
			setSnapShotContext.SetSnapShotContext(_contexts.snapshot);
		}
		if (model is ISetMessageContext)
		{
			((ISetMessageContext)model).SetMessageContext(_contexts.message);
		}
	}

	protected void RemovePlayerbackSystem<T>()
	{
		for (int num = _playbackSystems.Count - 1; num >= 0; num--)
		{
			if (_playbackSystems[num].GetType() == typeof(T))
			{
				_playbackSystems.RemoveAt(num);
			}
		}
		for (int num2 = _models.Count - 1; num2 >= 0; num2--)
		{
			if (_models[num2].GetType() == typeof(T))
			{
				_models.RemoveAt(num2);
			}
		}
	}

	protected void AddPlaybackSystem<T>(T system) where T : AbstractModel, IPlaybackSystem
	{
		if (0 == 0)
		{
			_playbackSystems.Add(system);
			_models.Add(system);
		}
	}

	public void OnPlayback()
	{
		foreach (IPlaybackSystem playbackSystem in _playbackSystems)
		{
			playbackSystem.OnPlayback();
		}
	}

	public static void AddCommonRpg(AbstractMode md)
	{
		md.AddPlaybackSystem(new PveTeamScoreModel());
		md.AddPlaybackSystem(new PveFirstWinModel());
		md.AddPlaybackSystem(new RpgTableTaskModel());
		md.AddPlaybackSystem(new RpgMessageModel());
		md.AddPlaybackSystem(new PveAllKillInfoModel());
	}

	public static void AddWujin(AbstractMode md)
	{
		AddCommonRpg(md);
		md.AddPlaybackSystem(new RpgTaskTargetModel());
		md.AddPlaybackSystem(new RpgEndlessStatisticsModel());
	}

	public static void AddTowerDefenseGui(AbstractMode md)
	{
		md.AddPlaybackSystem(new PveAllKillInfoModel());
		md.AddPlaybackSystem(new MiniMapModel());
		md.AddPlaybackSystem(new RadarMapModel());
		md.AddPlaybackSystem(new PlayerRebornModel());
		md.AddPlaybackSystem(new StrokeAnalysisModel());
		md.AddPlaybackSystem(new CommonGameOverModel());
		md.AddPlaybackSystem(new CommonKillBroadModel());
		md.AddPlaybackSystem(new CommonMessageModel());
		md.AddPlaybackSystem(new PvetdmessageModel());
		md.AddPlaybackSystem(new PveBotHitModel());
		md.AddPlaybackSystem(new WeaponStateModel());
		md.AddPlaybackSystem(new PveplayerstateModel());
		md.AddPlaybackSystem(new PveTeamScoreModel());
		md.AddPlaybackSystem(new PveScoreRankModel());
		md.AddPlaybackSystem(new PveskillstateModel());
		md.AddPlaybackSystem(new PveTDGetMoneyExpModel());
		md.AddPlaybackSystem(new PvetdbothpModel());
		md.AddPlaybackSystem(new PveBossHpModel());
		md.AddPlaybackSystem(new PveHomeHpModel());
		md.AddPlaybackSystem(new PveTDChemicalSerumModel());
		md.AddPlaybackSystem(new PvetdbuyweaponModel());
		md.AddPlaybackSystem(new PvetdskilltreeModel());
		md.AddPlaybackSystem(new PveStarsModel());
		md.AddPlaybackSystem(new PveFirstWinModel());
		md.AddPlaybackSystem(new PlayerBagModel());
		md.AddPlaybackSystem(new KillMessageModel());
		md.AddPlaybackSystem(new AchievementModel());
		md.AddPlaybackSystem(new PlayerScoreInfoModel());
		md.AddPlaybackSystem(new CommonPlayerHonoraryModel());
	}
}
