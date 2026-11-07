using System;
using System.Collections.Generic;
using Assets.Scripts.Input;
using Assets.Sources.Components.UserComand;
using Assets.Sources.Utils;
using Entitas;
using SSJJBase.Extensions;
using SSJJBase.Input;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Sources.Systems.UserCommand;

public class KeyboardEventSystem : IExecuteSystem, ISystem
{
	public static IRecord Record;

	private readonly List<int> _removelist = new List<int>();

	private static int[] _checkKeys = new int[62]
	{
		27, 9, 32, 98, 96, 49, 50, 51, 52, 53,
		54, 55, 56, 57, 48, 257, 258, 259, 260, 261,
		262, 263, 264, 265, 256, 113, 101, 109, 110, 112,
		122, 120, 99, 121, 13, 61, 277, 271, 91, 93,
		119, 115, 97, 100, 273, 274, 276, 275, 116, 118,
		104, 106, 107, 290, 291, 292, 293, 301, 108, 114,
		44, 46
	};

	private InputComponent _input;

	private bool _isMyPlayer;

	private bool _isStatus1075;

	private bool _isStatus1076;

	private bool _isStatus1086;

	private bool _isStatus1065;

	private bool _isStatus1066;

	private bool _isStatus30052;

	private bool _isAcg;

	public KeyboardEventSystem(Contexts contexts)
	{
		_input = contexts.userCommand.input;
	}

	public void Execute()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		if (myPlayerEntity != null)
		{
			_isMyPlayer = true;
			_isStatus1075 = myPlayerEntity.HasStatus(1075);
			_isStatus1076 = myPlayerEntity.HasStatus(1076);
			_isStatus1086 = myPlayerEntity.HasStatus(1086);
			_isStatus1065 = myPlayerEntity.HasStatus(1065);
			_isStatus1066 = myPlayerEntity.HasStatus(1066);
			_isStatus1066 = myPlayerEntity.HasStatus(1066);
			_isStatus30052 = myPlayerEntity.HasStatus(30052);
			_isAcg = Contexts.sharedInstance.gameRule.currentRule.Rule.IsAcg();
		}
		else
		{
			_isMyPlayer = false;
			_isStatus1075 = false;
			_isStatus1076 = false;
			_isStatus1086 = false;
			_isStatus1065 = false;
			_isStatus1066 = false;
			_isStatus30052 = false;
			_isAcg = false;
		}
		Dictionary<int, bool> keyDowns = null;
		if (Record != null)
		{
			Record.UpdateKeyDowns(ref keyDowns);
		}
		Dictionary<int, bool> keyStates = _input.KeyStates;
		int[] checkKeys = _checkKeys;
		foreach (int num in checkKeys)
		{
			if (!IsValidKey(num))
			{
				InputCollector.Instance.RemoveKeyDown(num);
				InputCollector.Instance.RemoveKey(num);
				continue;
			}
			bool down = Input.GetKey((KeyCode)num);
			if (Record != null)
			{
				Record.GetKeyDown(keyDowns, ref down, num);
			}
			keyStates.TryGetValue(num, out var value);
			if (down && !value)
			{
				OnKeyDown(num);
			}
			if (!down && value)
			{
				OnKeyUp(num);
			}
			keyStates[num] = down;
		}
		if (Record != null)
		{
			Record.RecordKeyDowns(keyDowns);
		}
		Forbid();
	}

	private void Forbid()
	{
		Dictionary<int, bool>.Enumerator keyDownEnumerator = InputCollector.Instance.GetKeyDownEnumerator();
		while (keyDownEnumerator.MoveNext())
		{
			int key = keyDownEnumerator.Current.Key;
			if (ForbidKeyDown(key))
			{
				_removelist.Add(key);
			}
		}
		foreach (int item in _removelist)
		{
			InputCollector.Instance.RemoveKeyDown(item);
		}
		_removelist.Clear();
		keyDownEnumerator = InputCollector.Instance.GetKeyEnumerator();
		while (keyDownEnumerator.MoveNext())
		{
			int key2 = keyDownEnumerator.Current.Key;
			if (ForbidKeyUp(key2))
			{
				_removelist.Add(key2);
			}
		}
		foreach (int item2 in _removelist)
		{
			InputCollector.Instance.RemoveKey(item2);
		}
		_removelist.Clear();
	}

	private bool ForbidKeyDown(int code)
	{
		InputComponent input = _input;
		for (int i = 0; i < input.KeyboardResponders.Count; i++)
		{
			if (input.KeyboardResponders[i].ForbidKeyDown((KeyCode)code))
			{
				return true;
			}
		}
		return false;
	}

	private bool ForbidKeyUp(int code)
	{
		InputComponent input = _input;
		for (int i = 0; i < input.KeyboardResponders.Count; i++)
		{
			if (input.KeyboardResponders[i].ForbidKeyUp((KeyCode)code))
			{
				return true;
			}
		}
		return false;
	}

	private void OnKeyDown(int code)
	{
		InputComponent input = _input;
		for (int i = 0; i < input.KeyboardResponders.Count; i++)
		{
			IKeyboardResponder keyboardResponder = input.KeyboardResponders[i];
			try
			{
				if (keyboardResponder.OnKeyDown((KeyCode)code))
				{
					InputCollector.Instance.RemoveKeyDown(code);
					if (i > 0)
					{
						input.KeyboardResponders.RemoveAt(i);
						input.KeyboardResponders.Insert(0, keyboardResponder);
					}
					break;
				}
			}
			catch (Exception args)
			{
				this.LogErrorFormat("OnKeyDown Error : {0}", args);
			}
		}
	}

	private void OnKeyUp(int code)
	{
		InputComponent input = _input;
		for (int i = 0; i < input.KeyboardResponders.Count; i++)
		{
			IKeyboardResponder keyboardResponder = input.KeyboardResponders[i];
			try
			{
				if (keyboardResponder.OnKeyUp((KeyCode)code))
				{
					InputCollector.Instance.RemoveKey(code);
					if (i > 0)
					{
						input.KeyboardResponders.RemoveAt(i);
						input.KeyboardResponders.Insert(0, keyboardResponder);
					}
					break;
				}
			}
			catch (Exception args)
			{
				this.LogErrorFormat("OnKeyUp Error : {0}", args);
			}
		}
	}

	private bool IsValidKey(int key)
	{
		if (!_isMyPlayer)
		{
			return false;
		}
		if ((_isStatus1075 || _isStatus1076 || _isStatus1086) && (key == 113 || ((KeyCode)key).IsInAlphaOrKeypad()))
		{
			return false;
		}
		if ((_isStatus1065 || _isStatus1066) && (key == 32 || key == 113 || ((KeyCode)key).IsInAlphaOrKeypad()))
		{
			return false;
		}
		if (_isAcg)
		{
			if (key == 304)
			{
				return false;
			}
			if (_isStatus30052)
			{
				if (key == 27 || key == 119 || key == 115 || key == 97 || key == 100)
				{
					return true;
				}
				return false;
			}
		}
		return true;
	}
}
