using System;
using System.Collections.Generic;
using Assets.Scripts.Input;
using Assets.Sources.Components.Interface.Info.AnimState;
using Assets.Sources.Components.Player.Anims;
using Assets.Sources.Components.UserComand;
using Assets.Sources.Config;
using Assets.Sources.Constant;
using Assets.Sources.Free.Data;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Weapon;
using Entitas;
using SSJJMath;
using SSJJUserCmd;
using UnityEngine;
using share.constant;

namespace Assets.Sources.Systems.UserCommand;

public class ComputeUserCommandSystem : IExecuteSystem, ISystem
{
	private readonly UserCommandContext _userCommandContext;

	private readonly TimeContext _timeContext;

	private readonly PlayerContext _playerContext;

	private readonly WeaponContext _weaponContext;

	private readonly WorldCameraContext _cameraContext;

	private readonly BattleRoomContext _roomContext;

	private readonly PlayerBagContext _playerBagContext;

	private int _lastJumpFlag;

	public static IRecord Record;

	public ComputeUserCommandSystem(Contexts contexts)
	{
		_userCommandContext = contexts.userCommand;
		_playerBagContext = contexts.playerBag;
		_roomContext = contexts.battleRoom;
		_cameraContext = contexts.worldCamera;
		_timeContext = contexts.time;
		_playerContext = contexts.player;
		_weaponContext = contexts.weapon;
	}

	public void Execute()
	{
		UserCmd currentCmd = _userCommandContext.commands.getCurrentCmd();
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		if (currentCmd != null)
		{
			currentCmd.RenderTime = _timeContext.time.RenderTime;
			currentCmd.AxisX = InputCollector.Instance.GetAxisX();
			currentCmd.AxisY = InputCollector.Instance.GetAxisY();
			currentCmd.FrameInterval = _timeContext.time.FrameInterval;
			MakeCommand(currentCmd, myPlayerEntity);
		}
	}

	private void MakeCommand(UserCmd cmd, PlayerEntity myPlayer)
	{
		GetKeyState(cmd, myPlayer);
		GetScrollWheel(cmd, myPlayer);
		ComputeMove(cmd, myPlayer);
		ProcessUiTouch(cmd, myPlayer);
		ComputeRotate(cmd, myPlayer);
		AutoChangeWeapon(cmd, myPlayer);
		ChangeBag(cmd, myPlayer);
		ChangeWeapon(cmd, myPlayer);
		ChangeObserverMode(cmd, myPlayer);
		PostProcess(cmd, myPlayer);
	}

	private void ChangeObserverMode(UserCmd cmd, PlayerEntity myPlayer)
	{
		int num = cmd.Buttons & 0x20;
		if (!GameModelLocator.GetInstance().GameModel.IsObserver)
		{
			if (RuleUtilty.IsCanSwitchThirdFirstMode(_roomContext))
			{
				if (_lastJumpFlag != num && num > 0)
				{
					Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode = !Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode;
				}
				_lastJumpFlag = cmd.Buttons & 0x20;
			}
			else if (RuleUtilty.MustThirdObserveMode(_roomContext))
			{
				Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode = false;
			}
			else
			{
				Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode = true;
			}
			return;
		}
		if (RuleUtilty.isRpgDuelDianfeng(Contexts.sharedInstance.battleRoom.roomData.Data.RaceType))
		{
			Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode = true;
			return;
		}
		if (Record != null && Record.IsServerRecord())
		{
			Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode = true;
			return;
		}
		if (_lastJumpFlag != num && num > 0)
		{
			if (Contexts.sharedInstance.gameRule.currentRule.Rule.GetObserverView == 3)
			{
				Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode = false;
				return;
			}
			Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode = !Contexts.sharedInstance.battleRoom.gameStateEntity.isObserverFirstMode;
		}
		_lastJumpFlag = cmd.Buttons & 0x20;
	}

	private void PostProcess(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (myPlayer != null)
		{
			if (myPlayer.move.NotMove)
			{
				cmd.NotMove = true;
				cmd.CleanButtonFlag(ButtonConstant.IsActivit);
				cmd.MoveForward = 0f;
				cmd.MoveRight = 0f;
			}
			else
			{
				cmd.NotMove = false;
			}
		}
	}

	private void GetScrollWheel(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (_userCommandContext.input.CursorState <= 0)
		{
			if (InputCollector.Instance.GetScrollWheel() < 0f)
			{
				cmd.Buttons |= 32;
				cmd.Buttons |= 67108864;
			}
			else if (InputCollector.Instance.GetScrollWheel() > 0f)
			{
				cmd.Buttons |= 134217728;
			}
		}
	}

	private void ChangeWeapon(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (!RuleUtilty.IsAvatarUltimateChallenge() && InputCollector.Instance.GetKeyDown(KeyCode.Q) && _playerContext.myPlayerEntity.hasLastWeapon && !_playerContext.myPlayerEntity.IsObserver() && _playerContext.myPlayerEntity.lastWeapon.BagId != 0 && _playerContext.myPlayerEntity.lastWeapon.WeaponId != 0)
		{
			cmd.Weapon = _playerContext.myPlayerEntity.lastWeapon.WeaponId;
		}
	}

	private void ChangeBag(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (_userCommandContext.input.Bag > 0)
		{
			cmd.BagId = _userCommandContext.input.Bag;
			_userCommandContext.input.Bag = 0;
		}
	}

	private bool RaceTypeEnable()
	{
		int raceType = _roomContext.roomData.Data.RaceType;
		if (raceType != 9)
		{
			return raceType != 10;
		}
		return false;
	}

	private bool IsAnim(IViewAnimStateInfo state)
	{
		if (state.StateId != 23)
		{
			return state.StateId == 137;
		}
		return true;
	}

	private bool IsBowAnimDone(PlayerEntity player)
	{
		if (player.hasViewAnim)
		{
			ViewAnimComponent viewAnim = player.viewAnim;
			if (viewAnim.ViewAnimInfo != null && IsAnim(player.viewAnim.ViewAnimInfo))
			{
				viewAnim.isBowing = true;
			}
			else if (viewAnim.isBowing && !IsAnim(player.viewAnim.ViewAnimInfo))
			{
				viewAnim.isBowing = false;
				return true;
			}
		}
		return false;
	}

	private bool NeedChange2Other(PlayerBagEntity bag, PlayerEntity myPlayer)
	{
		int num = -1;
		if (myPlayer.hasCurrentWeapon)
		{
			num = myPlayer.currentWeapon.Weapon;
		}
		if (num == 4 && bag != null)
		{
			WeaponEntity weaponAtSlot = WeaponUtility.GetWeaponAtSlot(myPlayer, bag, myPlayer.currentWeapon.Weapon, myPlayer.currentWeapon.Index);
			if (weaponAtSlot != null)
			{
				return weaponAtSlot.clip.Clip == 0;
			}
			return false;
		}
		return false;
	}

	private void AutoChangeWeapon(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (_weaponContext.currentWeaponEntity == null || myPlayer == null)
		{
			return;
		}
		if (myPlayer.basicInfo.IsDead)
		{
			cmd.Weapon = 0;
			return;
		}
		int currentBagId = myPlayer.basicInfo.Current.CurrentBagId;
		PlayerBagEntity entityWithBagId = _playerBagContext.GetEntityWithBagId(currentBagId);
		if (entityWithBagId == null || !RaceTypeEnable() || !IsBowAnimDone(myPlayer) || !NeedChange2Other(entityWithBagId, myPlayer))
		{
			return;
		}
		WeaponEntity canUsedWeapon = WeaponUtility.GetCanUsedWeapon(myPlayer, entityWithBagId, myPlayer.currentWeapon.Weapon);
		if (canUsedWeapon != null)
		{
			int slot = canUsedWeapon.slot.Slot;
			cmd.Weapon = slot;
			if (myPlayer.GetCareer() == "shengdianqishi" || myPlayer.GetCareer() == "destroyrider")
			{
				cmd.Weapon = 0;
			}
		}
	}

	private bool GetKeys(KeyCode[] keys)
	{
		foreach (KeyCode key in keys)
		{
			if (InputCollector.Instance.GetKey(key))
			{
				return true;
			}
		}
		return false;
	}

	private bool GetKeysDown(KeyCode[] keys)
	{
		foreach (KeyCode key in keys)
		{
			if (InputCollector.Instance.GetKeyDown(key))
			{
				return true;
			}
		}
		return false;
	}

	private void GetKeyState(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (!_userCommandContext.hasInputRecord)
		{
			_userCommandContext.SetInputRecord(new HashSet<int>());
		}
		else
		{
			_userCommandContext.inputRecord.KeyCodes.Clear();
		}
		foreach (KeyBinding keyBinding in _userCommandContext.input.KeyBindings)
		{
			if (keyBinding.Toggle)
			{
				if (GetKeys(keyBinding.KeyCodes))
				{
					OnKeyDown(keyBinding, cmd);
				}
				else
				{
					OnKeyUp(keyBinding, cmd);
				}
			}
			else if (GetKeysDown(keyBinding.KeyCodes))
			{
				OnKeyDown(keyBinding, cmd);
			}
		}
	}

	public void OnKeyDown(KeyBinding binding, UserCmd userCmd)
	{
		if (_cameraContext.hasSceneCameraInfo && _cameraContext.sceneCameraInfo.PlayerCameraNotMove)
		{
			KeyCode[] keyCodes = binding.KeyCodes;
			foreach (KeyCode keyCode in keyCodes)
			{
				if (keyCode == KeyCode.A || keyCode == KeyCode.S || keyCode == KeyCode.W || keyCode == KeyCode.D)
				{
					return;
				}
			}
		}
		InputComponent input = _userCommandContext.input;
		if (input.CursorState <= 0 || input.CursorForbidButtons <= 0 || (binding.Button & input.CursorForbidButtons) <= 0)
		{
			userCmd.Buttons |= binding.Button;
			if ((binding.State & 1) == 0)
			{
				binding.State |= 3;
			}
		}
	}

	public void OnKeyUp(KeyBinding binding, UserCmd userCmd)
	{
		if (binding.Toggle)
		{
			userCmd.Buttons &= ~binding.Button;
			if (((uint)binding.State & (true ? 1u : 0u)) != 0)
			{
				binding.State &= -2;
				binding.State |= 4;
			}
		}
	}

	private void ComputeMove(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (Contexts.sharedInstance.worldCamera.hasSceneCameraInfo && Contexts.sharedInstance.worldCamera.sceneCameraInfo.PlayerCameraNotMove)
		{
			return;
		}
		InputComponent input = _userCommandContext.input;
		foreach (KeyBinding keyBinding in input.KeyBindings)
		{
			if (keyBinding.Contais(KeyCode.W))
			{
				cmd.MoveForward += KeyState(keyBinding);
			}
			else if (keyBinding.Contais(KeyCode.S))
			{
				cmd.MoveForward -= KeyState(keyBinding);
			}
			else if (keyBinding.Contais(KeyCode.UpArrow))
			{
				cmd.MoveForward += KeyState(keyBinding);
			}
			else if (keyBinding.Contais(KeyCode.DownArrow))
			{
				cmd.MoveForward -= KeyState(keyBinding);
			}
			if (keyBinding.Contais(KeyCode.D))
			{
				cmd.MoveRight += KeyState(keyBinding);
			}
			else if (keyBinding.Contais(KeyCode.A))
			{
				cmd.MoveRight -= KeyState(keyBinding);
			}
			else if (keyBinding.Contais(KeyCode.RightArrow))
			{
				cmd.MoveRight += KeyState(keyBinding);
			}
			else if (keyBinding.Contais(KeyCode.LeftArrow))
			{
				cmd.MoveRight -= KeyState(keyBinding);
			}
		}
		if (_playerContext.myPlayerEntity.GetPlayerInfo().InChaos)
		{
			cmd.MoveForward *= -1f;
			cmd.MoveRight *= -1f;
		}
		if (cmd.MoveForward > 0f)
		{
			cmd.MoveForward = 100f;
		}
		if (cmd.MoveForward < 0f)
		{
			cmd.MoveForward = -100f;
		}
		if (cmd.MoveRight > 0f)
		{
			cmd.MoveRight = 100f;
		}
		if (cmd.MoveRight < 0f)
		{
			cmd.MoveRight = -100f;
		}
		if (input.CursorState > 0)
		{
			if ((input.CursorForbidButtons & 1) > 0 && cmd.MoveForward > 0f)
			{
				cmd.MoveForward = 0f;
			}
			if ((input.CursorForbidButtons & 2) > 0 && cmd.MoveForward < 0f)
			{
				cmd.MoveForward = 0f;
			}
			if ((input.CursorForbidButtons & 8) > 0 && cmd.MoveRight > 0f)
			{
				cmd.MoveRight = 0f;
			}
			if ((input.CursorForbidButtons & 4) > 0 && cmd.MoveRight < 0f)
			{
				cmd.MoveRight = 0f;
			}
			if ((input.CursorForbidButtons & 0x20) > 0)
			{
				cmd.Buttons &= -33;
			}
			if ((input.CursorForbidButtons & 0x80) > 0)
			{
				cmd.Buttons &= -129;
			}
		}
		if (myPlayer.HasStatus(PlayerInfoStatusConstant.NOWALK.ID))
		{
			cmd.Buttons &= -17;
		}
	}

	public int KeyState(KeyBinding keyBinding)
	{
		int result = 0;
		int num = keyBinding.State & 2;
		int num2 = keyBinding.State & 4;
		int num3 = keyBinding.State & 1;
		if (num != 0 && num2 == 0)
		{
			result = ((num3 != 0) ? 2 : 0);
		}
		if (num2 != 0 && num == 0)
		{
			result = 0;
		}
		if (num == 0 && num2 == 0)
		{
			result = ((num3 != 0) ? 4 : 0);
		}
		if (num != 0 && num2 != 0)
		{
			result = ((num3 == 0) ? 1 : 3);
		}
		keyBinding.State &= 1;
		return result;
	}

	public void ComputeRotate(UserCmd cmd, PlayerEntity myPlayer)
	{
		PlayerEntity myPlayerEntity = _playerContext.myPlayerEntity;
		InputComponent input = _userCommandContext.input;
		UserCommandEntity commandsEntity = _userCommandContext.commandsEntity;
		if (myPlayerEntity == null || (Contexts.sharedInstance.worldCamera.hasSceneCameraInfo && Contexts.sharedInstance.worldCamera.sceneCameraInfo.PlayerCameraNotMove))
		{
			return;
		}
		if (commandsEntity.hasResetYaw || commandsEntity.hasResetPitch)
		{
			if (commandsEntity.hasResetYaw)
			{
				myPlayerEntity.orientation.Yaw = commandsEntity.resetYaw.Yaw;
				commandsEntity.RemoveResetYaw();
			}
			if (commandsEntity.hasResetPitch)
			{
				myPlayerEntity.orientation.Pitch = commandsEntity.resetPitch.Pitch;
				commandsEntity.RemoveResetPitch();
			}
			input.setFirstInited(value: false);
		}
		if (!input.getFirstInited())
		{
			input.setFirstInited(value: true);
			input.Yaw = myPlayerEntity.orientation.Yaw;
			input.Pitch = myPlayerEntity.orientation.Pitch;
		}
		if (input.CursorState > 0)
		{
			UserCmd userCmd = null;
			LinkedList<UserCmd> commandList = _userCommandContext.commands.CommandList;
			if (commandList.Last != null)
			{
				userCmd = commandList.Last.Value;
			}
			if (userCmd != null)
			{
				cmd.CameraYaw = userCmd.CameraYaw;
				cmd.CameraPitch = userCmd.CameraPitch;
				return;
			}
		}
		int mouseSensitivity = GameSetting.Config.MouseSensitivity;
		int mouseSmooth = GameSetting.Config.MouseSmooth;
		int fov = myPlayerEntity.fov.Fov;
		float yaw = input.Yaw;
		float pitch = input.Pitch;
		float axisX = cmd.AxisX;
		float num = cmd.AxisY;
		if (GameSetting.Config.MouseReversal == 1)
		{
			num *= -1f;
		}
		float num2 = (float)fov / 90f;
		float num3 = 0.01f + 0.1f * (float)mouseSensitivity / 100f;
		float num4 = (0f - axisX) * num3 * num2;
		float num5 = num * num3 * num2;
		if (num4 != 0f && myPlayerEntity.move.keepFly)
		{
			num4 = ((!(num4 > 0f)) ? ((float)(-1 * cmd.FrameInterval * myPlayerEntity.move.wingSteeringSpeed) * 0.001f) : ((float)(cmd.FrameInterval * myPlayerEntity.move.wingSteeringSpeed) * 0.001f));
		}
		if (commandsEntity.hasLimitYawSpeed)
		{
			float yaw2 = commandsEntity.limitYawSpeed.Yaw;
			if (Math.Abs(yaw2) > 0f)
			{
				num4 = ((!(num4 > 0f)) ? ((num4 < 0f - yaw2) ? (0f - yaw2) : num4) : ((num4 > yaw2) ? yaw2 : num4));
			}
		}
		float num6 = AngleUtility.MakeAngleInRange(yaw + num4);
		float num7 = AngleUtility.MakePitchInRange(pitch + num5);
		if (commandsEntity.hasLockCamera)
		{
			float num8 = commandsEntity.lockCamera.CmdYaw;
			float cmdPitch = commandsEntity.lockCamera.CmdPitch;
			if ((num6 > 0f && num8 < 0f) || (num6 < 0f && num8 > 0f))
			{
				if (Math.Abs(num8 - num6) > 180f)
				{
					num6 = ((num6 < 0f) ? (num6 + 360f) : num6);
					num8 = ((num8 < 0f) ? (num8 + 360f) : num8);
				}
				else
				{
					num6 += 360f;
					num8 += 360f;
				}
			}
			num8 -= num6;
			cmdPitch -= num7;
			if (Math.Abs(num8) > commandsEntity.lockCamera.Yaw)
			{
				num6 = ((!(num8 < 0f)) ? (commandsEntity.lockCamera.CmdYaw - commandsEntity.lockCamera.Yaw) : (commandsEntity.lockCamera.CmdYaw + commandsEntity.lockCamera.Yaw));
			}
			if (Math.Abs(cmdPitch) > commandsEntity.lockCamera.Pitch)
			{
				num7 = ((!(cmdPitch < 0f)) ? (commandsEntity.lockCamera.CmdPitch - commandsEntity.lockCamera.Pitch) : (commandsEntity.lockCamera.CmdPitch + commandsEntity.lockCamera.Pitch));
			}
			num6 = AngleUtility.MakeAngleInRange(num6);
			if (num7 < -90f)
			{
				num7 = -90f;
			}
			if (num7 > 90f)
			{
				num7 = 90f;
			}
		}
		input.Yaw = num6;
		input.Pitch = num7;
		float num9 = 0f;
		List<float> yawList = input.getYawList();
		for (int i = 0; i < yawList.Count; i++)
		{
			num9 = ((!(Mathf.Abs(input.Yaw - yawList[i]) > 300f)) ? (num9 + yawList[i]) : ((!(yawList[i] > 0f)) ? (num9 + (360f + yawList[i])) : (num9 + (yawList[i] - 360f))));
		}
		float num10 = 0f;
		List<float> pitchList = input.getPitchList();
		for (int j = 0; j < pitchList.Count; j++)
		{
			num10 += pitchList[j];
		}
		int num11 = ((mouseSmooth != 0) ? (mouseSmooth / 26 + 1) : 0);
		float num12 = AngleUtility.MakeAngleInRange((num6 + num9) / (float)(yawList.Count + 1));
		float num13 = (num7 + num10) / (float)(pitchList.Count + 1);
		yawList.Add(num6);
		pitchList.Add(num7);
		while (yawList.Count > num11)
		{
			yawList.RemoveAt(0);
		}
		while (pitchList.Count > num11)
		{
			pitchList.RemoveAt(0);
		}
		cmd.CameraYaw = (short)(num12 * 100f);
		cmd.CameraPitch = (short)(num13 * 100f);
		ProcessTpsCmd(cmd, myPlayerEntity);
	}

	public void ProcessTpsCmd(UserCmd cmd, PlayerEntity myPlayerEntity)
	{
		if (PlayerCareerUtil.IsTPS(myPlayerEntity.GetCareer()))
		{
			cmd.CameraPitch = (short)Mathf.Clamp(cmd.CameraPitch, -4500, 4500);
		}
	}

	public void ProcessUiTouch(UserCmd cmd, PlayerEntity myPlayer)
	{
		if (_userCommandContext.input.CursorState <= 0 && _playerContext.myPlayerEntity != null)
		{
			if (InputCollector.Instance.GetLeftMouse())
			{
				cmd.Buttons |= 64;
			}
			if (InputCollector.Instance.GetRightMouse())
			{
				cmd.Buttons |= 512;
			}
			if (InputCollector.Instance.GetMiddleMouse())
			{
				cmd.Buttons |= 268435456;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha1) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad1))
			{
				cmd.Weapon = 1;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha2) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad2))
			{
				cmd.Weapon = 2;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha3) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad3))
			{
				cmd.Weapon = 3;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha4) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad4))
			{
				cmd.Weapon = 4;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha5) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad5))
			{
				cmd.Weapon = 5;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha6) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad6))
			{
				cmd.Weapon = 6;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha7) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad7))
			{
				cmd.Weapon = 7;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha8) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad8))
			{
				cmd.Weapon = 8;
			}
			if (InputCollector.Instance.GetKeyDown(KeyCode.Alpha9) || InputCollector.Instance.GetKeyDown(KeyCode.Keypad9))
			{
				cmd.Weapon = 9;
			}
		}
	}
}
