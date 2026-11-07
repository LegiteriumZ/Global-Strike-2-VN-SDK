using System.Threading;

namespace Core.Utils;

public struct SpinWait
{
	internal const int YieldThreshold = 10;

	private int _count;

	public void SpinOnce()
	{
		if (_count++ > 10)
		{
			Thread.Sleep(0);
		}
		else
		{
			Thread.SpinWait(4 << _count);
		}
	}
}
