using UnityEngine;

namespace Assets.Scripts.Input;

public interface IDeviceInput
{
	bool AnyKey();

	bool AnyKeyDown();

	bool GetKeyDown(KeyCode keyCode);

	bool GetKey(KeyCode keyCode);

	bool GetMouseButton(int button);

	bool GetMouseButtonDown(int button);

	bool GetMouseButtonUp(int button);

	float GetAxis(string axis);
}
