using Assets.Sources.Config;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Input;
using UnityEngine;

namespace Assets.Sources.Systems.UserCommand;

public class MouseLockSystem : IExecuteSystem, ISystem
{
	public static IRecord Record;

	private readonly UserCommandContext _userCmdContext;

	private readonly BattleRoomContext _battleRoomContext;

	public MouseLockSystem(Contexts contexts)
	{
		_userCmdContext = contexts.userCommand;
		_battleRoomContext = contexts.battleRoom;
	}

	public void Execute()
	{
		if (!_battleRoomContext.gameState.LoadingFinish)
		{
			return;
		}
		if (Application.isFocused)
		{
			bool flag = false;
			int cursorState = 0;
			int cursorForbidButtons = 0;
			foreach (ICursorControl cursorControl in _userCmdContext.input.CursorControls)
			{
				if (cursorControl.GetCursorState() != 0)
				{
					cursorState = cursorControl.GetCursorState();
					flag = true;
					cursorForbidButtons = cursorControl.GetForbidButtons();
					break;
				}
			}
			_userCmdContext.input.CursorState = cursorState;
			_userCmdContext.input.CursorForbidButtons = cursorForbidButtons;
			if (Record != null && Record.IsServerRecord())
			{
				flag = true;
			}
			bool visible = flag;
			int lockState = ((!flag && GameSetting.Config.RawInput != 0) ? 1 : 0);
			Cursor.visible = visible;
			Cursor.lockState = (CursorLockMode)lockState;
			if (Record != null)
			{
				Record.RecordMouseLock();
				Record.UpdateMouseLock();
			}
		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
