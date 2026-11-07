using Assets.Sources.Free.UI;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.Render;

public class UnityObject3D : IObject3D, IUIUpdater
{
	private readonly GameObject _gameObject;

	private float _rotationX;

	private float _rotationY;

	private float _rotationZ;

	private bool _rotationDirty;

	public float PosX
	{
		get
		{
			return _gameObject.transform.localPosition.z;
		}
		set
		{
			Vector3 localPosition = _gameObject.transform.localPosition;
			localPosition.z = value;
			_gameObject.transform.localPosition = localPosition;
		}
	}

	public float PosY
	{
		get
		{
			return 0f - _gameObject.transform.localPosition.x;
		}
		set
		{
			Vector3 localPosition = _gameObject.transform.localPosition;
			localPosition.x = 0f - value;
			_gameObject.transform.localPosition = localPosition;
		}
	}

	public float PosZ
	{
		get
		{
			return _gameObject.transform.localPosition.y;
		}
		set
		{
			Vector3 localPosition = _gameObject.transform.localPosition;
			localPosition.y = value;
			_gameObject.transform.localPosition = localPosition;
		}
	}

	public float ScaleX
	{
		get
		{
			return _gameObject.transform.localScale.z;
		}
		set
		{
			Vector3 localScale = _gameObject.transform.localScale;
			localScale.z = value;
			_gameObject.transform.localScale = localScale;
		}
	}

	public float ScaleY
	{
		get
		{
			return _gameObject.transform.localScale.x;
		}
		set
		{
			Vector3 localScale = _gameObject.transform.localScale;
			localScale.x = value;
			_gameObject.transform.localScale = localScale;
		}
	}

	public float ScaleZ
	{
		get
		{
			return _gameObject.transform.localScale.y;
		}
		set
		{
			Vector3 localScale = _gameObject.transform.localScale;
			localScale.y = value;
			_gameObject.transform.localScale = localScale;
		}
	}

	public float RotationX
	{
		get
		{
			return _rotationX;
		}
		set
		{
			if (!Mathf.Approximately(_rotationX, value))
			{
				_rotationX = value;
				_rotationDirty = true;
			}
		}
	}

	public float RotationY
	{
		get
		{
			return _rotationY;
		}
		set
		{
			if (!Mathf.Approximately(_rotationY, value))
			{
				_rotationY = value;
				_rotationDirty = true;
			}
		}
	}

	public float RotationZ
	{
		get
		{
			return _rotationZ;
		}
		set
		{
			if (!Mathf.Approximately(_rotationZ, value))
			{
				_rotationZ = value;
				_rotationDirty = true;
			}
		}
	}

	public GameObject GameObject => _gameObject;

	public float Alpha { get; set; }

	public bool Visible
	{
		get
		{
			return _gameObject.IsActiveSelf();
		}
		set
		{
			_gameObject.SetObjectActive(value);
		}
	}

	public bool IsDisabled { get; set; }

	public UnityObject3D(GameObject go)
	{
		_gameObject = go;
		MonoBehaviourSingleton<SimpleUIUpdater>.Instance.AddList(this);
	}

	public void Destory()
	{
		Object.DestroyImmediate(_gameObject);
		MonoBehaviourSingleton<SimpleUIUpdater>.Instance.RemoveList(this);
	}

	public void AddChild(IObject3D child)
	{
		child.GameObject.transform.SetParent(_gameObject.transform, worldPositionStays: false);
	}

	public void UIUpdate(int frameTime)
	{
		if (_rotationDirty)
		{
			_rotationDirty = false;
			_gameObject.transform.localEulerAngles = new Vector3(RotationY, 0f - RotationZ, 0f - RotationX);
		}
	}
}
