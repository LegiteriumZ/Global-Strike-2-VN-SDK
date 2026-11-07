using UnityEngine;

namespace Assets.Scripts.Input;

public class UnityInput : IDeviceInput
{
	public bool AnyKey()
	{
		return UnityEngine.Input.anyKey;
	}

	public bool AnyKeyDown()
	{
		return UnityEngine.Input.anyKeyDown;
	}

	public bool GetMouseButtonUp(int button)
	{
		return UnityEngine.Input.GetMouseButtonUp(button);
	}

	public float GetAxis(string axis)
	{
		return UnityEngine.Input.GetAxis(axis);
	}

	public bool GetKey(KeyCode keyCode)
	{
		return UnityEngine.Input.GetKey(keyCode);
	}

	public bool GetKeyDown(KeyCode keyCode)
	{
		return UnityEngine.Input.GetKeyDown(keyCode);
	}

	public bool GetMouseButton(int button)
	{
		return UnityEngine.Input.GetMouseButton(button);
	}

	public bool GetMouseButtonDown(int button)
	{
		return UnityEngine.Input.GetMouseButtonDown(button);
	}
}
