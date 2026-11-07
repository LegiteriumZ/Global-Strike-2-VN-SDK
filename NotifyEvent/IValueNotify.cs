using System;

namespace NotifyEvent;

public interface IValueNotify : INotify
{
	void AddEvent<T>(Func<T> getfunc, Action<T, T> setfunc);

	void RemoveEvent<T>(Func<T> eventFunc, Action<T, T> setfunc);

	bool ContainsEvent<T>(Func<T> getfunc);

	bool ContainsEvent<T>(Action<T, T> setfunc);
}
