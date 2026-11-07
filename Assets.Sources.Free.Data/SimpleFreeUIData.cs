using System.Collections.Generic;
using NetData;
using SSJJBase.Extensions;

namespace Assets.Sources.Free.Data;

public class SimpleFreeUIData
{
	private class StringKeyComparer : IEqualityComparer<StringKey>
	{
		public bool Equals(StringKey x, StringKey y)
		{
			if (x.method == y.method)
			{
				return x.source == y.source;
			}
			return false;
		}

		public int GetHashCode(StringKey obj)
		{
			return obj.method.GetHashCode();
		}
	}

	private struct StringKey
	{
		public int method;

		public string source;

		public StringKey(int method, string source)
		{
			this.method = method;
			this.source = source;
		}
	}

	public int Key;

	public SimpleProto SimpleData;

	private readonly Dictionary<string, List<SimpleProto>> _dic;

	private readonly Dictionary<string, bool> _changeDic;

	private readonly Dictionary<int, List<string>> _id2SourceDic;

	private static readonly Dictionary<StringKey, string> StringCache = new Dictionary<StringKey, string>(new StringKeyComparer());

	public SimpleFreeUIData(bool sub = false)
	{
		if (!sub)
		{
			_dic = new Dictionary<string, List<SimpleProto>>();
			_changeDic = new Dictionary<string, bool>();
			_id2SourceDic = new Dictionary<int, List<string>>();
		}
	}

	public List<string> GetSourceList(int id)
	{
		return _id2SourceDic[id];
	}

	public bool IsChanged(int method, string source)
	{
		return _changeDic.GetOrDefault(GetKey(method, source));
	}

	private static string GetKey(int method, string source)
	{
		StringKey key = new StringKey(method, source);
		if (!StringCache.TryGetValue(key, out var value))
		{
			value = method + "_" + source;
			StringCache[key] = value;
		}
		if (StringCache.Count > 10000)
		{
			StringCache.Clear();
		}
		return value;
	}

	public List<SimpleProto> GetData(int method, string source)
	{
		return _dic[GetKey(method, source)];
	}

	public void ResetChange(int method, string source)
	{
		_changeDic[GetKey(method, source)] = false;
		_dic[GetKey(method, source)].Clear();
		_id2SourceDic[method].Clear();
	}

	public void SimpleDataChanged(SimpleProto sp)
	{
		int key = sp.Key;
		string text = sp.Ss[0];
		string key2 = GetKey(key, text);
		if (!_dic.ContainsKey(key2))
		{
			_dic[key2] = new List<SimpleProto>();
		}
		if (!_id2SourceDic.ContainsKey(key))
		{
			_id2SourceDic[key] = new List<string>();
		}
		_id2SourceDic[key].Add(text);
		List<SimpleProto> list = _dic[key2];
		if (list.Count < 10000)
		{
			list.Add(sp);
		}
		_changeDic[key2] = true;
	}
}
