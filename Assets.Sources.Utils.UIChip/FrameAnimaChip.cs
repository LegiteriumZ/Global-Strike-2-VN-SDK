using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sources.Utils.UIChip;

public class FrameAnimaChip : AbstractChip<int, string>
{
	public bool IsLoop;

	public bool Flag;

	public string Extension = ".png";

	public string Format;

	private Dictionary<int, string> _cache = new Dictionary<int, string>();

	private string _path;

	private int _count;

	private int _start = 1;

	private float _delta = 1f;

	public bool Changed { get; private set; }

	public int Count
	{
		get
		{
			return _count;
		}
		set
		{
			_count = value;
			CalculateTotalTime();
		}
	}

	public int Start
	{
		get
		{
			return _start;
		}
		set
		{
			_start = value;
			CalculateTotalTime();
		}
	}

	public float Delta
	{
		get
		{
			return _delta;
		}
		set
		{
			_delta = value;
			CalculateTotalTime();
		}
	}

	public string Path
	{
		get
		{
			return _path;
		}
		set
		{
			if (value != _path)
			{
				_cache.Clear();
				_path = value;
			}
		}
	}

	public FrameAnimaChip()
	{
		Step = 100f;
	}

	protected float CalculateTotalTime()
	{
		if (Mathf.Abs(Delta - 1E-05f) < float.Epsilon)
		{
			return 0f;
		}
		return (float)Count / Delta;
	}

	public string GetCurrentResult()
	{
		return GetPath(base.Value);
	}

	protected override string JumpTo(float percent)
	{
		if (!IsLoop)
		{
			base.IsOver = DetermineIsOver(percent);
			percent = Mathf.Clamp01(percent);
			int num = Start + Mathf.RoundToInt((float)Count * percent);
			Changed = num != base.Value;
			base.Value = num;
			return GetPath(base.Value);
		}
		base.IsOver = DetermineIsOver(percent);
		percent %= 1f;
		int num2 = Start + Mathf.RoundToInt((float)Count * percent);
		Changed = num2 != base.Value;
		base.Value = num2;
		return GetPath(base.Value);
	}

	private string GetPath(int idx)
	{
		if (!_cache.ContainsKey(idx))
		{
			string result = Path + idx.ToString(Format) + Extension;
			_cache.Add(idx, Path + idx.ToString(Format) + Extension);
			return result;
		}
		return _cache[idx];
	}
}
