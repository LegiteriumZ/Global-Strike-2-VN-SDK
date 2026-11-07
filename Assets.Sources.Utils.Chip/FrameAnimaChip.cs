using System.Collections.Generic;
using Assets.Sources.Components.Time;

namespace Assets.Sources.Utils.Chip;

public class FrameAnimaChip : AbstractChip<string>
{
	public int Count;

	public int Delay = 100;

	public bool IsLoop;

	public int Index = 1;

	public int RemainTime;

	public string Extension = ".png";

	public bool Changed;

	public int StartIndex = 1;

	public string Format;

	private Dictionary<int, string> _cache = new Dictionary<int, string>();

	private string _path;

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

	public void Init()
	{
		if (string.IsNullOrEmpty(Path))
		{
			return;
		}
		int num = ((Count > 0) ? Count : 10);
		for (int i = StartIndex; i < StartIndex + num + 1; i++)
		{
			int key = i;
			if (!_cache.ContainsKey(key))
			{
				_cache.Add(key, Path + key.ToString(Format) + Extension);
			}
		}
	}

	public string Update(TimeComponent time)
	{
		if (Index < Count + StartIndex)
		{
			base.IsOver = false;
		}
		RemainTime += time.FrameInterval;
		while (RemainTime >= Delay)
		{
			base.IsOver = false;
			RemainTime -= Delay;
			Index++;
			if (Index >= Count + StartIndex)
			{
				if (IsLoop)
				{
					Index = StartIndex;
				}
				else
				{
					base.IsOver = true;
				}
			}
		}
		if (Index >= Count + StartIndex)
		{
			int key = Count + StartIndex - 1;
			if (!_cache.ContainsKey(key))
			{
				_cache.Add(key, Path + key.ToString(Format) + Extension);
			}
			Changed = Cvalue != _cache[key];
			return Cvalue = _cache[key];
		}
		if (!_cache.ContainsKey(Index))
		{
			_cache.Add(Index, Path + Index.ToString(Format) + Extension);
		}
		Changed = Cvalue != _cache[Index];
		return Cvalue = _cache[Index];
	}
}
