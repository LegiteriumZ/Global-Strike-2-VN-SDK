using SSJJUniRx;

namespace Assets.Libs.NotifyLib.Simplify;

internal class SimpleReactive<T> : ReactiveProperty<T>
{
	public void ResetValue(T value)
	{
		SetValue(value);
	}
}
