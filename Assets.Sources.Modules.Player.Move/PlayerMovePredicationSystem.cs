using Assets.Sources.Components.Interface;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Utils.PlayerAnim;
using NetData;
using SSJJPhysics;
using SSJJUserCmd;
using config;
using physics;
using physics.data;
using physics.trace;
using share.constant;

namespace Assets.Sources.Modules.Player.Move;

public class PlayerMovePredicationSystem : IPredicateSystem
{
	private readonly BattleRoomContext _sceneMapContext;

	private readonly SnapshotContext _snapshotContext;

	private readonly BattleRoomContext _battleRoomContext;

	private readonly Contexts _contexts;

	private WorldBase _worldBase;

	private IPyUserCmd _pyCmd;

	public PlayerMovePredicationSystem(Contexts contexts)
	{
		_sceneMapContext = contexts.battleRoom;
		_snapshotContext = contexts.snapshot;
		_battleRoomContext = contexts.battleRoom;
		_contexts = contexts;
	}

	public void OnPredicate(PlayerEntity player, IUserCmd cmd)
	{
		if (player.basicInfo.IsDead)
		{
			return;
		}
		ISnapshot nowSnapshot = _snapshotContext.snapshots.NowSnapshot;
		if (_snapshotContext.hasSnapshots && nowSnapshot.ControlId != 0 && player.entityId.Value != _snapshotContext.snapshots.NowSnapshot.ControlId)
		{
			return;
		}
		string name = player.basicInfo.CareerInfo.Name;
		if (name.Equals("mechnear2") || name.Equals("mechpredator"))
		{
			Mech2Determine(player, cmd);
		}
		else if (name.Equals("mechbomberman2"))
		{
			if (player.move.ActThirdMove)
			{
				Mech2Determine(player, cmd);
			}
			else
			{
				DefaultDetermine(player, cmd);
			}
		}
		else if (player.HasStatus(PlayerInfoStatusConstant.ON_AIR_JUMP.ID))
		{
			PlayerGlidingThirdAnimControl.processAnimLogic(player, cmd);
		}
		else
		{
			DefaultDetermine(player, cmd);
		}
		MovePredication(player, cmd);
		AfterMove(player, cmd);
	}

	private void AfterMove(PlayerEntity player, IUserCmd cmd)
	{
		if (RuleUtilty.IsUltimateChallenge())
		{
			UltimateChallengeClientHandler.handle(player, cmd, _contexts);
		}
	}

	private IPyPlayerMove GetAdapter(PlayerEntity player, IUserCmd cmd)
	{
		IPyPlayerMove pyPlayerMove = player.move.PyPlayerMove;
		if (_pyCmd == null)
		{
			_pyCmd = new PyUserCmdAdapter(cmd);
		}
		else if (_pyCmd is PyUserCmdAdapter pyUserCmdAdapter)
		{
			pyUserCmdAdapter.Reset(cmd);
		}
		if (player.move.AnimPosition)
		{
			_sceneMapContext.pyEngine.PyEngine.GetPmove().RootMotionMove(_battleRoomContext.pyEngine.PyEngine.GetWorld(), pyPlayerMove, _pyCmd.FrameInterval);
		}
		else
		{
			int speed = PlayerSpeedUtil.GetPlayerSpeed(pyPlayerMove, _pyCmd);
			if (MoveButtonsNeedToBeClear(player))
			{
				cmd.Clear(ButtonConstant.ClearMove);
				cmd.MoveForward = 0f;
				cmd.MoveRight = 0f;
			}
			if (player.HasStatus(PlayerInfoStatusConstant.ON_AIR_JUMP.ID))
			{
				cmd.Clear(-33);
			}
			if (player.HasStatus(PlayerInfoStatusConstant.FAKE_DEAD.ID))
			{
				cmd.Clear(0);
			}
			if (PlayerAnimationUtility.IsTorseAnimEqual(player, 314) || PlayerAnimationUtility.IsTorseAnimEqual(player, 315))
			{
				cmd.Clear(0);
			}
			FixSpeed(player, ref speed);
			IPyMove pmove = _sceneMapContext.pyEngine.PyEngine.GetPmove();
			if (OfflineGameController.isOffline)
			{
				OfflineGameController.GetPlayerOffes(cmd, speed, pyPlayerMove, pmove, _pyCmd);
			}
			else
			{
				pmove.SetMove(pyPlayerMove, _pyCmd, speed);
			}
		}
		return pyPlayerMove;
	}

	private bool MoveButtonsNeedToBeClear(PlayerEntity player)
	{
		if (player.HasStatus(PlayerInfoStatusConstant.HERO_SPRINT.ID))
		{
			return true;
		}
		if (player.hasBasicInfo && player.basicInfo.Current.Gliding && player.basicInfo.CareerInfo.Name.Equals("chicken"))
		{
			return true;
		}
		if (player.HasPlayerInfo(142001))
		{
			return true;
		}
		WeaponEntity currentWeaponEntity = _contexts.weapon.currentWeaponEntity;
		if (currentWeaponEntity != null && currentWeaponEntity.hasBasicInfo && currentWeaponEntity.basicInfo.Info.Name.Equals("hero_weapon_base") && isHeroWeaponBaseAttackAnim(player))
		{
			return true;
		}
		return false;
	}

	private bool isHeroWeaponBaseAttackAnim(PlayerEntity player)
	{
		if (player.viewAnim.ViewAnimInfo.StateId != 31 && player.viewAnim.ViewAnimInfo.StateId != 30 && player.viewAnim.ViewAnimInfo.StateId != 29 && player.viewAnim.ViewAnimInfo.StateId != 122 && player.viewAnim.ViewAnimInfo.StateId != 123 && player.viewAnim.ViewAnimInfo.StateId != 124 && player.viewAnim.ViewAnimInfo.StateId != 125)
		{
			return player.viewAnim.ViewAnimInfo.StateId == 126;
		}
		return true;
	}

	private void DefaultDetermine(PlayerEntity player, IUserCmd cmd)
	{
		bool playerStateType = player.state.GetPlayerStateType(268435456);
		if (!(player.move.ActThirdMove && playerStateType))
		{
			if (player.state.GetPlayerStateType(1073741824))
			{
				player.move.Moving = false;
			}
			else
			{
				CommonDetermine(player, cmd);
			}
		}
	}

	private void Mech2Determine(PlayerEntity player, IUserCmd cmd)
	{
		if (player.state.GetPlayerStateType(1073741824))
		{
			player.move.Moving = false;
			return;
		}
		if (player.move.AnimPosition)
		{
			if (!player.move.AnimPositionChangeYaw)
			{
				return;
			}
			player.move.AnimPositionChangeYaw = false;
		}
		bool playerStateType = player.state.GetPlayerStateType(268435456);
		if (!(player.move.ActThirdMove && playerStateType))
		{
			CommonDetermine(player, cmd);
		}
	}

	private void CommonDetermine(PlayerEntity player, IUserCmd cmd)
	{
		IPyPlayerMove pyPlayerMove = player.move.PyPlayerMove;
		if (cmd.IsForward || cmd.IsBackward || cmd.IsLeft || cmd.IsRight)
		{
			player.move.Moving = true;
		}
		double num = ((!(pyPlayerMove is BasePyPlayerAdapter)) ? pyPlayerMove.GetVelocity().GetLength() : ((double)(pyPlayerMove as BasePyPlayerAdapter).GetUnityVelocity().magnitude));
		if (player.move.Moving)
		{
			if (num < 0.10000000149011612)
			{
				player.move.Moving = false;
			}
			else if (DecalsProxy.IsTexIce(Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld().GetDecalsId(), pyPlayerMove.GetPml().groundTrace.surfaceFlags))
			{
				player.move.Moving = false;
			}
		}
	}

	private void PeekabooMovePredication(PlayerEntity player, IUserCmd cmd, SceneItemEntityData item)
	{
		item.RotationZ = (float)cmd.CameraYaw / 100f;
	}

	private void MovePredication(PlayerEntity player, IUserCmd cmd)
	{
		IPyPlayerMove adapter = GetAdapter(player, cmd);
		if (player.CanDuck())
		{
			_sceneMapContext.pyEngine.PyEngine.GetDuckManager().Duck(adapter.GetEntity(), adapter, _pyCmd);
		}
		player.move.IsSwitchWalk = cmd.IsSwitchWalkOn;
	}

	private void FixSpeed(PlayerEntity player, ref int speed)
	{
		BattleRoomContext battleRoom = Contexts.sharedInstance.battleRoom;
		if (!battleRoom.hasRoomData)
		{
			return;
		}
		if (_worldBase == null)
		{
			_worldBase = Contexts.sharedInstance.battleRoom.pyEngine.PyEngine.GetWorld() as WorldBase;
		}
		if (_worldBase != null)
		{
			SceneSpecialArea sceneSpecialArea = _worldBase.GetSceneSpecialArea(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x, player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y, player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z, SpecialAreaEnum.QUICK_SPEED);
			if (sceneSpecialArea != null)
			{
				speed = (int)((float)speed * sceneSpecialArea.GetSpeedScale());
			}
			SceneIrregularitySpecialArea sceneIrregularitySpecialArea = _worldBase.GetSceneIrregularitySpecialArea(player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).x, player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).y, player.GetCompenstatePos(player.fpos.Change.GetPosIndex()).z, SpecialAreaEnum.QUICK_SPEED);
			if (sceneIrregularitySpecialArea != null)
			{
				speed = (int)((float)speed * sceneIrregularitySpecialArea.GetSpeedScale());
			}
		}
		switch (battleRoom.roomData.Data.RaceType)
		{
		case 24:
			if (player.HasState(536870912))
			{
				speed = 1500;
			}
			break;
		case 23:
			if (player.GetTeam() == 1)
			{
				_ = player.basicInfo.Current.HasC4;
			}
			break;
		case 6:
		case 117:
			if (player.basicInfo.CareerInfo.Name == "doun" || player.GetCareer() == "snake_doun" || player.GetCareer() == "doun_master")
			{
				PlayerEntityData current = player.basicInfo.Current;
				if (current.MaxHp > 0)
				{
					speed = (int)((float)speed * (1.2f - 0.2f * (float)current.Hp / (float)current.MaxHp));
				}
			}
			break;
		case 29:
			if (player.HasState(256))
			{
				speed = 1500;
			}
			break;
		case 31:
			if (player.HasState(256))
			{
				speed = 1500;
			}
			break;
		}
	}
}
