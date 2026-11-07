using UnityEngine;

namespace Assets.Res.Assets.Scripts;

[ExecuteInEditMode]
public class SpriteAnimation : MonoBehaviour
{
	private float _delayTime;

	private int _index;

	private float _lastChangeTime;

	private SpriteRenderer _spriteRenderer;

	public int DelayMs;

	public int FrameRate = 30;

	public bool IsLoop = true;

	public Sprite[] Sprites;

	public bool ShowLastSprite;

	public int Duration => (int)((float)Sprites.Length / (float)FrameRate * 1000f);

	private void Awake()
	{
		_spriteRenderer = GetComponent<SpriteRenderer>();
		if (_spriteRenderer == null)
		{
			_spriteRenderer = base.gameObject.AddComponent<SpriteRenderer>();
		}
	}

	private void OnEnable()
	{
		_index = 0;
		_lastChangeTime = Time.realtimeSinceStartup;
		_delayTime = _lastChangeTime + (float)DelayMs;
		SetSprite(0);
	}

	public void SetImageSprite(Sprite sprite)
	{
		_spriteRenderer.sprite = sprite;
	}

	private void SetSprite(int index)
	{
		if (Sprites != null && Sprites.Length != 0)
		{
			Sprite sprite = Sprites[index % Sprites.Length];
			_spriteRenderer.sprite = sprite;
		}
	}

	private void Update()
	{
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (_delayTime > realtimeSinceStartup)
		{
			_delayTime = realtimeSinceStartup;
			_lastChangeTime = realtimeSinceStartup;
		}
		else
		{
			if (!(realtimeSinceStartup - _lastChangeTime >= 1f / (float)FrameRate))
			{
				return;
			}
			if (!IsLoop && _index == Sprites.Length - 1)
			{
				if (!ShowLastSprite)
				{
					_spriteRenderer.sprite = null;
				}
			}
			else
			{
				SetSprite(++_index);
				_lastChangeTime = realtimeSinceStartup;
			}
		}
	}
}
