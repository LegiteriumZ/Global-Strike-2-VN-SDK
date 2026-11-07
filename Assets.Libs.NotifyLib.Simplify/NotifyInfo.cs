using System;

namespace Assets.Libs.NotifyLib.Simplify;

internal class NotifyInfo<T> : ISimpleNotifyInfo
{
	public int Id;

	public SimpleReactive<T> Reactive;

	public Func<int, T> GetFunc;

	public Action<T, int> SetFunc;

	public int Index;

	public Func<int, T> ClearFunc;

	public IDisposable Disposeable;

	public bool Suspend { get; set; }

	public void Update()
	{
		if (Reactive != null && !Suspend)
		{
			Reactive.Value = GetFunc(Index);
		}
	}

	public void Clear()
	{
		if (ClearFunc != null && !Suspend && Reactive != null)
		{
			Reactive.ResetValue(ClearFunc(Index));
		}
	}

	public void Dispose()
	{
		if (Disposeable != null)
		{
			Disposeable.Dispose();
		}
	}
}
