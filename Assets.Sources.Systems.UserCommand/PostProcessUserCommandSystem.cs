using Entitas;
using SSJJUserCmd;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Systems.UserCommand;

public class PostProcessUserCommandSystem : IExecuteSystem, ISystem
{
	private readonly UserCommandContext _userCommandContext;

	private readonly PlayerContext _playerContext;

	public const int Resume = 0;

	public const int Fix = 1;

	private bool _start;

	private short _yaw;

	private short _pitch;

	private int _lastChangeTime;

	private int _buttons;

	private int _moveRight;

	private int _moveForward;

	private int _forwardnum;

	private int _rightnum;

	public PostProcessUserCommandSystem(Contexts contexts)
	{
		_userCommandContext = contexts.userCommand;
		_playerContext = contexts.player;
	}

	public void Execute()
	{
		UserCmd currentCmd = _userCommandContext.commands.getCurrentCmd();
		if (currentCmd != null)
		{
			InterceptNew(currentCmd);
			FreeIntercept(currentCmd);
		}
	}

	private void FreeIntercept(UserCmd cmd)
	{
		switch (_userCommandContext.commands.State)
		{
		case 0:
			_start = false;
			break;
		case 1:
			NoMove(cmd);
			break;
		}
	}

	private void InterceptNew(UserCmd userCmd)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.THUNDER_SHOTGUN_THUNDER_STATE.ID) || myPlayerEntity.HasStatus(10160098) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID))
		{
			showNightOwl(userCmd);
		}
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.SLIDE_STATUS.ID))
		{
			NoMoveSlide(userCmd);
		}
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.PLAYER_NOT_DUCK_FLAG.ID) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.THUNDER_SHOTGUN_THUNDER_STATE.ID) || myPlayerEntity.HasStatus(10160098) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID))
		{
			preNoDuck(userCmd);
		}
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.PLAYER_NOT_JUMP_FLAG.ID) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3.ID) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.THUNDER_SHOTGUN_THUNDER_STATE.ID) || myPlayerEntity.HasStatus(10160098) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NIGHT_OWL_SUBMACHINEGUN_CIRCLE_P3_THUNDER.ID))
		{
			preNoJump(userCmd);
		}
		if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.inFear.ID) || myPlayerEntity.HasStatus(PlayerInfoStatusConstant.BE_FEARED.ID))
		{
			PreInFear(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.CAN_NOT_CONTROL_KEYBOARD.ID))
		{
			preClose(userCmd);
		}
		else if (myPlayerEntity.GetPlayerInfo().InChaos2)
		{
			PreChaos2(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.inChaos.ID))
		{
			PreChaos(userCmd);
		}
		else if (myPlayerEntity.legAnim.LegsAnimInfo != null && myPlayerEntity.legAnim.LegsAnimInfo.StateId == 82)
		{
			PreXpSkillFilter(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.HERO_COLD_DEATH_SKILL.ID))
		{
			PreXpSkillFilter(userCmd, lockYawPitch: true);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.RPG_XP1002_SKILL.ID))
		{
			PreXpSkillFilter(userCmd, lockYawPitch: true);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.RPG_XP1003_SKILL.ID))
		{
			PreXpSkillFilterLockView(userCmd, lockYawPitch: true);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.RPG_THUNDER_HAMMER_STORM.ID))
		{
			PreThunderHammerSkillFilter(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.RPG_NO_CHANGE_WEAPON_NO_MOVE.ID))
		{
			PreNoChangeNoMoveFilter(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.NO_CHANGE_WEAPON.ID))
		{
			PreNoChangeNoMoveFilter(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.RPG_NO_MOVE.ID))
		{
			PreNoMoveFilter(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.HOILDAY_EFFECT_HUNLUANGUANGBO_VALUE.ID))
		{
			PreHunLuanGuangBo(userCmd);
		}
		else if (myPlayerEntity.HasStatus(PlayerInfoStatusConstant.ACG_SERIOUS_INJURY_FLAG.ID))
		{
			RemoveMOuseButton(userCmd);
		}
	}

	private void RemoveMOuseButton(UserCmd userCmd)
	{
		userCmd.Buttons &= 64;
		userCmd.Buttons &= 512;
	}

	private void PreNoChangeNoMoveFilter(UserCmd userCmd)
	{
		userCmd.Weapon = 0;
		userCmd.QButton = false;
	}

	private void PreNoMoveFilter(UserCmd userCmd)
	{
		userCmd.Buttons &= ~ButtonConstant.IsActivit;
		userCmd.MoveRight = 0f;
		userCmd.MoveForward = 0f;
	}

	private void PreThunderHammerSkillFilter(UserCmd userCmd)
	{
		userCmd.Buttons &= 15;
		userCmd.Weapon = 0;
		userCmd.BagId = 0;
		userCmd.QButton = false;
	}

	private void PreInFear(UserCmd userCmd)
	{
		int num = (int)(UnityEngine.Time.realtimeSinceStartup * 1000f);
		if (_lastChangeTime <= 0 || num - _lastChangeTime >= 500)
		{
			_lastChangeTime = num;
			int num2 = Random.Range(0, 4);
			_buttons = 0;
			_moveRight = 0;
			_moveForward = 0;
			switch (num2)
			{
			case 0:
				_buttons |= 4;
				_moveRight = -4;
				break;
			case 1:
				_buttons |= 8;
				_moveRight = 4;
				break;
			case 2:
				_buttons |= 1;
				_moveForward = 2;
				break;
			case 3:
				_buttons |= 2;
				_moveForward = -4;
				break;
			}
		}
		userCmd.Buttons = _buttons;
		userCmd.MoveRight = _moveRight;
		userCmd.MoveForward = _moveForward;
		if (_moveForward == 2)
		{
			_moveForward = 4;
		}
	}

	private void PreXpSkillFilter(UserCmd userCmd, bool lockYawPitch = false)
	{
		userCmd.Buttons = 0;
		userCmd.MoveRight = 0f;
		userCmd.MoveForward = 0f;
		userCmd.Weapon = 0;
		userCmd.BagId = 0;
		userCmd.QButton = false;
		if (lockYawPitch)
		{
			userCmd.CameraYaw = (short)(_playerContext.cameraOwnerEntity.orientation.Yaw * 100f);
			userCmd.CameraPitch = (short)(_playerContext.cameraOwnerEntity.orientation.Pitch * 100f);
		}
	}

	private void PreXpSkillFilterLockView(UserCmd userCmd, bool lockYawPitch = false)
	{
		userCmd.Buttons = 0;
		userCmd.MoveRight = 0f;
		userCmd.MoveForward = 0f;
		userCmd.Weapon = 0;
		userCmd.BagId = 0;
		userCmd.QButton = false;
		if (lockYawPitch)
		{
			userCmd.CameraYaw = (short)(_playerContext.cameraOwnerEntity.orientation.Yaw * 100f);
			userCmd.CameraPitch = (short)(_playerContext.cameraOwnerEntity.orientation.Pitch * 100f);
		}
	}

	private void PreHunLuanGuangBo(UserCmd userCmd)
	{
		int buttons;
		int num = (buttons = userCmd.Buttons);
		buttons &= -5;
		buttons &= -9;
		buttons &= -2;
		buttons &= -3;
		buttons &= -65;
		buttons &= -513;
		if ((num & 4) > 0)
		{
			buttons |= 8;
		}
		if ((num & 8) > 0)
		{
			buttons |= 4;
		}
		if ((num & 1) > 0)
		{
			buttons |= 2;
		}
		if ((num & 2) > 0)
		{
			buttons |= 1;
		}
		if ((num & 0x40) > 0)
		{
			buttons |= 0x200;
		}
		if ((num & 0x200) > 0)
		{
			buttons |= 0x40;
		}
		userCmd.Buttons = buttons;
		userCmd.MoveRight *= -1f;
		userCmd.MoveForward *= -1f;
		if (_moveForward == 2)
		{
			_moveForward = 4;
		}
	}

	private void PreChaos(UserCmd userCmd)
	{
		int num = 0;
		if ((_buttons | 4) > 0)
		{
			num |= 8;
		}
		if ((_buttons | 8) > 0)
		{
			num |= 4;
		}
		if ((_buttons | 1) > 0)
		{
			num |= 2;
		}
		if ((_buttons | 2) > 0)
		{
			num |= 1;
		}
		_buttons |= num;
		userCmd.Buttons = _buttons;
		userCmd.MoveRight *= -1f;
		userCmd.MoveForward *= -1f;
		if (_moveForward == 2)
		{
			_moveForward = 4;
		}
	}

	private void PreChaos2(UserCmd userCmd)
	{
		int buttons;
		int num = (buttons = userCmd.Buttons);
		buttons &= -5;
		buttons &= -9;
		buttons &= -2;
		buttons &= -3;
		buttons &= -33;
		buttons &= -129;
		if ((num & 4) > 0)
		{
			buttons |= 8;
		}
		if ((num & 8) > 0)
		{
			buttons |= 4;
		}
		if ((num & 1) > 0)
		{
			buttons |= 2;
		}
		if ((num & 2) > 0)
		{
			buttons |= 1;
		}
		if ((num & 0x20) > 0)
		{
			buttons |= 0x80;
		}
		if ((num & 0x80) > 0)
		{
			buttons |= 0x20;
		}
		userCmd.Buttons = buttons;
		userCmd.MoveRight *= -1f;
		userCmd.MoveForward *= -1f;
		if (_moveForward == 2)
		{
			_moveForward = 4;
		}
	}

	private void preClose(UserCmd userCmd)
	{
		userCmd.MoveForward = 3f;
		userCmd.MoveRight = 3f;
		int num = Random.Range(0, 10);
		_moveForward = 0;
		_moveRight = 0;
		userCmd.CleanButtonFlag(1);
		userCmd.CleanButtonFlag(2);
		userCmd.CleanButtonFlag(4);
		userCmd.CleanButtonFlag(8);
		switch (num)
		{
		case 0:
			if (_forwardnum == 0 || _forwardnum < -25)
			{
				_forwardnum = 0;
				CleanButtonFlag(2);
				SetButtonFlag(1);
			}
			else if ((_buttons & 2) > 0)
			{
				_forwardnum--;
				_moveForward = -1;
			}
			if ((_buttons & 1) > 0)
			{
				_moveForward = 1;
				_forwardnum++;
			}
			break;
		case 1:
			if (_forwardnum == 0 || _forwardnum > 25)
			{
				_forwardnum = 0;
				CleanButtonFlag(1);
				SetButtonFlag(2);
			}
			else if ((_buttons & 1) > 0)
			{
				_forwardnum++;
				_moveForward = 1;
			}
			if ((_buttons & 2) > 0)
			{
				_moveForward = -1;
				_forwardnum--;
			}
			break;
		case 2:
			if (_rightnum == 0 || _rightnum < -25)
			{
				_rightnum = 0;
				CleanButtonFlag(4);
				SetButtonFlag(8);
			}
			else if ((_buttons & 4) > 0)
			{
				_rightnum--;
				_moveRight = -1;
			}
			if ((_buttons & 2) > 0)
			{
				_moveRight = 1;
				_rightnum++;
			}
			break;
		case 3:
			if (_rightnum == 0 || _rightnum > 25)
			{
				_rightnum = 0;
				CleanButtonFlag(8);
				SetButtonFlag(4);
			}
			else if ((_buttons & 8) > 0)
			{
				_rightnum++;
				_moveRight = 1;
			}
			if ((_buttons & 4) > 0)
			{
				_moveRight = -1;
				_rightnum--;
			}
			break;
		default:
			ComposeButton();
			break;
		}
		userCmd.SetButtonFlag(_buttons);
		userCmd.MoveForward *= _moveForward;
		userCmd.MoveRight *= _moveRight;
	}

	private void NoMoveSlide(UserCmd userCmd)
	{
		if ((userCmd.Buttons & 0x80) > 0)
		{
			userCmd.CleanButtonFlag(128);
		}
		if ((userCmd.Buttons & 0x20) > 0)
		{
			userCmd.CleanButtonFlag(32);
		}
		if ((userCmd.Buttons & 1) > 0)
		{
			userCmd.CleanButtonFlag(1);
		}
		if ((userCmd.Buttons & 2) > 0)
		{
			userCmd.CleanButtonFlag(2);
		}
		if ((userCmd.Buttons & 4) > 0)
		{
			userCmd.CleanButtonFlag(4);
		}
		if ((userCmd.Buttons & 8) > 0)
		{
			userCmd.CleanButtonFlag(8);
		}
		userCmd.MoveForward = 0f;
		userCmd.MoveRight = 0f;
	}

	private void showNightOwl(UserCmd userCmd)
	{
		int num = 0;
		if ((_buttons | 4) > 0)
		{
			num |= 8;
		}
		if ((_buttons | 8) > 0)
		{
			num |= 4;
		}
		if ((_buttons | 1) > 0)
		{
			num |= 2;
		}
		if ((_buttons | 2) > 0)
		{
			num |= 1;
		}
		if ((_buttons | 0x10000) > 0)
		{
			num |= 0x10000;
		}
		if ((_buttons | 0x800) > 0)
		{
			num |= 0x800;
		}
		_buttons = 0;
		_buttons |= num;
	}

	private void preNoJump(UserCmd userCmd)
	{
		if ((userCmd.Buttons & 0x20) > 0)
		{
			userCmd.CleanButtonFlag(32);
		}
	}

	private void preNoDuck(UserCmd userCmd)
	{
		if ((userCmd.Buttons & 0x80) > 0)
		{
			userCmd.CleanButtonFlag(128);
		}
	}

	private void SetButtonFlag(int flag)
	{
		_buttons |= flag;
	}

	private void CleanButtonFlag(int flag)
	{
		_buttons &= ~flag;
	}

	private void ComposeButton()
	{
		if ((_buttons & 1) > 0)
		{
			_forwardnum++;
			_moveForward = 1;
		}
		if ((_buttons & 2) > 0)
		{
			_forwardnum--;
			_moveForward = -1;
		}
		if ((_buttons & 8) > 0)
		{
			_rightnum++;
			_moveRight = 1;
		}
		if ((_buttons & 4) > 0)
		{
			_rightnum--;
			_moveRight = -1;
		}
	}

	private void NoMove(UserCmd cmd)
	{
		if (!_start)
		{
			_yaw = cmd.CameraYaw;
			_pitch = cmd.CameraPitch;
			_start = true;
		}
		if (_start)
		{
			cmd.CameraPitch = _pitch;
			cmd.CameraYaw = _yaw;
		}
		cmd.Buttons = 0;
		cmd.Weapon = 0;
		cmd.MoveRight = 0f;
		cmd.MoveForward = 0f;
	}
}
