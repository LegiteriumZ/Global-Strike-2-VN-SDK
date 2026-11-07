using System.Collections.Generic;
using SSJJBase.String;

namespace Assets.Sources.Utils;

public class CaseInSensitiveDictionary<TV>
{
	private Dictionary<IgnoreCaseString, TV> _innerDictionary;

	public TV this[string key]
	{
		get
		{
			IgnoreCaseString key2 = new IgnoreCaseString(key);
			return _innerDictionary[key2];
		}
		set
		{
			IgnoreCaseString key2 = new IgnoreCaseString(key);
			_innerDictionary[key2] = value;
		}
	}

	public CaseInSensitiveDictionary()
	{
		_innerDictionary = new Dictionary<IgnoreCaseString, TV>();
	}

	public bool TryGetValue(string key, out TV value)
	{
		IgnoreCaseString key2 = new IgnoreCaseString(key);
		return _innerDictionary.TryGetValue(key2, out value);
	}

	public bool ContainsKey(string eventIdStr)
	{
		IgnoreCaseString key = new IgnoreCaseString(eventIdStr);
		return _innerDictionary.ContainsKey(key);
	}
}
