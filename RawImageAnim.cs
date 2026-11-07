using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class RawImageAnim : MonoBehaviour
{
	private RawImage _rawImage;

	[SerializeField]
	public float interval;

	[SerializeField]
	public int from;

	[SerializeField]
	public int to;

	[SerializeField]
	public int hCount;

	[SerializeField]
	public int vCount;

	[SerializeField]
	public bool loop;

	[SerializeField]
	public bool start;

	[SerializeField]
	public int index;

	private float _width;

	private float _height;

	private float _timeElapse;

	private int _step;

	private bool _running;

	private void Awake()
	{
		_rawImage = GetComponent<RawImage>();
		hCount = Mathf.Max(1, hCount);
		vCount = Mathf.Max(1, vCount);
		_width = 1f / (float)hCount;
		_height = 1f / (float)vCount;
		_step = ((from <= to) ? 1 : (-1));
	}

	private void Update()
	{
		if (start && !_running)
		{
			_running = true;
			start = false;
			Reset();
		}
		if (_running)
		{
			_timeElapse += Time.deltaTime;
			if (_timeElapse > interval)
			{
				_timeElapse -= interval;
				if (index != to)
				{
					index += _step;
				}
				else if (loop)
				{
					index = from;
				}
				else
				{
					_running = false;
				}
			}
		}
		_rawImage.uvRect = new Rect((float)(index % hCount) * _width, (float)(index / hCount) * _height, _width, _height);
	}

	private void Reset()
	{
		index = from;
		_rawImage.uvRect = new Rect((float)(index % hCount) * _width, (float)(index / hCount) * _height, _width, _height);
	}
}
