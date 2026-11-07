using UnityEngine;

namespace Assets.Sources.Utils.Ui;

[ExecuteInEditMode]
[RequireComponent(typeof(RectTransform))]
public class UiScale : MonoBehaviour
{
	private bool _inited;

	private Vector2 _Scale = Vector2.one;

	private Vector2 _initSize;

	private Vector2 _position;

	private RectTransform _rectTransform;

	public Vector2 Scale
	{
		get
		{
			return _Scale;
		}
		set
		{
			if (_Scale != value)
			{
				SetScale(value.x, value.y);
			}
		}
	}

	public void Reset()
	{
		_inited = false;
	}

	private void Init()
	{
		_rectTransform = base.transform as RectTransform;
		_initSize = _rectTransform.rect.size;
		_position = _rectTransform.anchoredPosition;
		_inited = true;
	}

	private void SetScale(float scalex, float scaley)
	{
		if (!_inited)
		{
			Init();
		}
		float num = _rectTransform.pivot.x - 0.5f;
		float num2 = _rectTransform.pivot.y - 0.5f;
		float num3 = (scalex - 1f) * num * _initSize.x;
		float num4 = (scaley - 1f) * num2 * _initSize.y;
		float x = _position.x + num3;
		float y = _position.y + num4;
		_rectTransform.anchoredPosition = new Vector2(x, y);
		_rectTransform.localScale = new Vector3(scalex, scaley, 1f);
		_Scale = new Vector2(scalex, scaley);
	}
}
