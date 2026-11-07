using System.Collections.Generic;
using NetData;

namespace Assets.Sources.Free.Utility;

public static class SimpleProtoExtension
{
	public static void Reset(this SimpleProto proto)
	{
		proto.Key = 0;
		proto.Bs.Clear();
		proto.ComponentName.Clear();
		proto.Ds.Clear();
		proto.Fs.Clear();
		proto.Ins.Clear();
		proto.Ks.Clear();
		proto.Ls.Clear();
		proto.Ps.Clear();
		proto.Ss.Clear();
	}

	public static void CopyTo(this SimpleProto source, SimpleProto target)
	{
		target.Reset();
		target.Key = source.Key;
		CopyList(source.Bs, target.Bs);
		CopyList(source.ComponentName, target.ComponentName);
		CopyList(source.Ds, target.Ds);
		CopyList(source.Fs, target.Fs);
		CopyList(source.Ins, target.Ins);
		CopyList(source.Ks, target.Ks);
		CopyList(source.Ls, target.Ls);
		CopyList(source.Ps, target.Ps);
		CopyList(source.Ss, target.Ss);
	}

	private static void CopyList<T>(List<T> source, List<T> target)
	{
		foreach (T item in source)
		{
			target.Add(item);
		}
	}
}
