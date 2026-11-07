using System.Collections.Generic;
using UnityEngine;

public class YanhuaPlay : MonoBehaviour
{
	[Tooltip("单位秒")]
	public float[] Delays;

	public GameObject Yanhua;

	public string IndexName;

	private static Dictionary<string, int> _indexs = new Dictionary<string, int>();

	private float _time;

	private float _delay;

	private void Start()
	{
		if (string.IsNullOrEmpty(IndexName))
		{
			IndexName = "index";
		}
		if (!_indexs.ContainsKey(IndexName))
		{
			_indexs[IndexName] = 0;
		}
		if (_indexs[IndexName] < Delays.Length - 1)
		{
			_delay = Delays[_indexs[IndexName]++];
		}
		else
		{
			_delay = Delays[Delays.Length - 1];
		}
	}

	private void OnEnable()
	{
		_time = 0f;
	}

	private void Update()
	{
		if (_delay > 0f && Yanhua != null)
		{
			_time += Time.deltaTime;
			if (_time > _delay * 1.1f)
			{
				Yanhua.SetObjectActive(isactive: true);
				_time = 0f;
			}
			else if (_time > _delay * 0.9f && Yanhua.IsActiveSelf())
			{
				Yanhua.SetObjectActive(isactive: false);
				_time = _delay;
			}
		}
	}
}
