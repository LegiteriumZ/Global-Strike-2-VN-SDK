using System;
using System.Collections.Generic;
using Assets.Sources.Config;
using Assets.Sources.Utils;
using Assets.Sources.Utils.Optimize;
using UnityEngine;

namespace Assets.Scripts.Input;

public class InputCollector : MonoBehaviour
{
	public static InputCollector Instance;

	public static IRecord Record;

	private float _axisX;

	private float _axisY;

	private CircularBuffer<Vector2> _cachedList;

	private readonly Dictionary<int, bool> _keys = new Dictionary<int, bool>();

	private readonly Dictionary<int, bool> _keyDowns = new Dictionary<int, bool>();

	private readonly Queue<int> _clientkey = new Queue<int>();

	private bool _leftMouse;

	private bool _rightMouse;

	private bool _middleMouse;

	private float _scrollWheel;

	private float _deltaTime;

	private float _diff;

	private IDeviceInput _input;

	public float LastRespondTime { get; private set; }

	public void ResetRespondTime()
	{
		LastRespondTime = Time.realtimeSinceStartup;
	}

	private void Awake()
	{
		Instance = this;
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void Start()
	{
		if (_input == null)
		{
			_input = new UnityInput();
		}
		MouseMove.Init();
		LastRespondTime = Time.realtimeSinceStartup;
	}

	public void SetDeviceInput(IDeviceInput input)
	{
		_input = input;
	}

	public void Collect(float dt)
	{
		if (Record != null)
		{
			if (Record.IsServerRecord())
			{
				_deltaTime += dt;
			}
			if (Record.UpdateInput(ref _axisX, ref _axisY, _keys, _keyDowns, ref _leftMouse, ref _rightMouse, ref _middleMouse, ref _scrollWheel, ref _deltaTime, ref _diff))
			{
				return;
			}
		}
		bool flag = false;
		bool flag2 = _input.AnyKey();
		bool flag3 = _input.AnyKeyDown();
		if (flag3 || flag2)
		{
			for (int i = 0; i < 323; i++)
			{
				if (flag3 && _input.GetKeyDown((KeyCode)i))
				{
					flag = (_keyDowns[i] = true);
				}
				if (flag2 && _input.GetKey((KeyCode)i))
				{
					flag = (_keys[i] = true);
				}
			}
			if (_input.GetMouseButton(0))
			{
				_leftMouse = true;
			}
			if (_input.GetMouseButton(1))
			{
				_rightMouse = true;
			}
			if (_input.GetMouseButtonDown(2))
			{
				_middleMouse = true;
			}
		}
		while (_clientkey.Count > 0)
		{
			int key = _clientkey.Dequeue();
			_keys[key] = true;
			_keyDowns[key] = true;
		}
		_scrollWheel += _input.GetAxis("Mouse ScrollWheel");
		int num = GameSetting.Config.MouseSmooth / 26 + 1;
		if (_cachedList == null || _cachedList.Capacity != num)
		{
			_cachedList = new CircularBuffer<Vector2>(num);
		}
		if (GameSetting.Config.RawInput == 0)
		{
			if (!Cursor.visible && Application.isFocused)
			{
				int movement = MouseMove.GetMovement();
				_axisX += (short)(movement & 0xFFFF);
				_axisY += -(short)(movement >> 16);
			}
		}
		else
		{
			_axisX += _input.GetAxis("Mouse X") * 2f;
			_axisY += _input.GetAxis("Mouse Y") * 2f;
		}
		if (flag || _leftMouse || _rightMouse || _middleMouse || Math.Abs(_axisX) > 0.01f || Math.Abs(_axisY) > 0.01f)
		{
			LastRespondTime = Time.realtimeSinceStartup;
		}
		_cachedList.PushBack(new Vector2(_axisX, _axisY));
		Vector2 zero = Vector2.zero;
		foreach (Vector2 cached in _cachedList)
		{
			zero += cached;
		}
		_deltaTime += dt;
		if (Record != null)
		{
			Record.RecordInput(_axisX, _axisY, _keys, _keyDowns, _leftMouse, _rightMouse, _middleMouse, _scrollWheel, _deltaTime, _diff);
		}
	}

	public void Reset()
	{
		_axisX = (_axisY = 0f);
		_keyDowns.Clear();
		_keys.Clear();
		_leftMouse = false;
		_rightMouse = false;
		_middleMouse = false;
		_scrollWheel = 0f;
		float deltaTime = GetDeltaTime();
		_diff = deltaTime - (float)(int)(deltaTime * 1000f) / 1000f;
		_deltaTime = 0f;
	}

	public float GetAxisX()
	{
		return _axisX;
	}

	public float GetAxisY()
	{
		return _axisY;
	}

	public void RemoveKeyDown(int key)
	{
		if (_keyDowns.ContainsKey(key))
		{
			_keyDowns.Remove(key);
		}
	}

	public Dictionary<int, bool>.Enumerator GetKeyDownEnumerator()
	{
		return _keyDowns.GetEnumerator();
	}

	public bool GetKeyDown(KeyCode key)
	{
		return _keyDowns.ContainsKey((int)key);
	}

	public void AddKey(KeyCode key)
	{
		_clientkey.Enqueue((int)key);
	}

	public void RemoveKey(int key)
	{
		_keys.Remove(key);
	}

	public Dictionary<int, bool>.Enumerator GetKeyEnumerator()
	{
		return _keys.GetEnumerator();
	}

	public bool GetKey(KeyCode key)
	{
		return _keys.ContainsKey((int)key);
	}

	public bool GetLeftMouse()
	{
		return _leftMouse;
	}

	public bool GetRightMouse()
	{
		return _rightMouse;
	}

	public bool GetMiddleMouse()
	{
		return _middleMouse;
	}

	public float GetScrollWheel()
	{
		return _scrollWheel;
	}

	public float GetDeltaTime()
	{
		return _deltaTime + _diff;
	}
}
