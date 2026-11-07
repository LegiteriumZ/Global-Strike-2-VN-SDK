using System.Collections.Generic;
using SSJJBase.Extensions;
using UnityEngine;

namespace Assets.Sources.Free.Render;

public class UnityUiObject : IUiObject
{
	private readonly RectTransform _rectTransform;

	private readonly CanvasGroup _group;

	private GameObject _gameObject;

	private List<IUiObject> _brothers;

	public Vector2 Anchor
	{
		get
		{
			return _rectTransform.anchorMin;
		}
		set
		{
			RectTransform rectTransform = _rectTransform;
			Vector2 anchorMin = (_rectTransform.anchorMax = value);
			rectTransform.anchorMin = anchorMin;
		}
	}

	public Transform Parent
	{
		get
		{
			return GameObject.transform.parent;
		}
		set
		{
			GameObject.transform.SetParent(value);
		}
	}

	public List<IUiObject> Brothers => _brothers;

	public int Width
	{
		get
		{
			return (int)_rectTransform.sizeDelta.x;
		}
		set
		{
			Vector2 sizeDelta = _rectTransform.sizeDelta;
			sizeDelta.x = value;
			_rectTransform.sizeDelta = sizeDelta;
		}
	}

	public int Height
	{
		get
		{
			return (int)_rectTransform.sizeDelta.y;
		}
		set
		{
			Vector2 sizeDelta = _rectTransform.sizeDelta;
			sizeDelta.y = value;
			_rectTransform.sizeDelta = sizeDelta;
		}
	}

	public bool InHierarchyVisible => GameObject.IsInHierarchyActiveSelf();

	public bool ActiveVisible
	{
		get
		{
			return GameObject.IsActiveSelf();
		}
		set
		{
			GameObject.SetObjectActive(value);
		}
	}

	public float PosX
	{
		get
		{
			return _rectTransform.localPosition.x;
		}
		set
		{
			Vector3 localPosition = _rectTransform.localPosition;
			localPosition.x = value;
			_rectTransform.localPosition = localPosition;
		}
	}

	public float PosY
	{
		get
		{
			return 0f - _rectTransform.localPosition.y;
		}
		set
		{
			Vector3 localPosition = _rectTransform.localPosition;
			localPosition.y = 0f - value;
			_rectTransform.localPosition = localPosition;
		}
	}

	public float Alpha
	{
		get
		{
			return _group.alpha;
		}
		set
		{
			_group.alpha = value;
		}
	}

	public float ScaleX
	{
		get
		{
			return _rectTransform.localScale.x;
		}
		set
		{
			Vector3 localScale = _rectTransform.localScale;
			localScale.x = value;
			_rectTransform.localScale = localScale;
		}
	}

	public float ScaleY
	{
		get
		{
			return _rectTransform.localScale.y;
		}
		set
		{
			Vector3 localScale = _rectTransform.localScale;
			localScale.y = value;
			_rectTransform.localScale = localScale;
		}
	}

	public float Rotation
	{
		get
		{
			return _rectTransform.localEulerAngles.z;
		}
		set
		{
			Vector3 localEulerAngles = _rectTransform.localEulerAngles;
			localEulerAngles.z = value;
			_rectTransform.localEulerAngles = localEulerAngles;
		}
	}

	public GameObject GameObject
	{
		get
		{
			return _gameObject;
		}
		set
		{
			_gameObject = value;
		}
	}

	public UnityUiObject(GameObject engineObj, bool isSetPivot = true)
	{
		_gameObject = engineObj;
		_rectTransform = _gameObject.TryAddComponent<RectTransform>();
		_group = _gameObject.TryAddComponent<CanvasGroup>();
		if (isSetPivot)
		{
			_rectTransform.pivot = new Vector2(0f, 1f);
		}
	}

	public void ResetData()
	{
		int width = (Height = 0);
		Width = width;
	}

	public string GetParentPath()
	{
		string text = "_";
		if (GameObject == null)
		{
			return text;
		}
		Transform transform = GameObject.transform;
		while (transform != null)
		{
			text = text + transform.name + "_";
			transform = transform.parent;
		}
		return text;
	}

	public void SetBrother(IUiObject child)
	{
		if (_brothers == null)
		{
			_brothers = new List<IUiObject>();
		}
		if (!_brothers.Contains(child))
		{
			_brothers.Add(child);
		}
	}

	public void AddChild(IUiObject child)
	{
		Vector3 localPosition = child.GameObject.transform.localPosition;
		child.GameObject.transform.SetParent(GameObject.transform);
		child.GameObject.transform.localScale = GameObject.transform.localScale;
		child.GameObject.transform.localRotation = Quaternion.identity;
		child.GameObject.transform.localPosition = localPosition;
		child.GameObject.layer = GameObject.layer;
	}

	public T FindComponentInChildren<T>() where T : MonoBehaviour
	{
		return GameObject.GetComponentInChildren<T>();
	}

	public T GetComponent<T>() where T : MonoBehaviour
	{
		return GameObject.GetComponent<T>();
	}
}
