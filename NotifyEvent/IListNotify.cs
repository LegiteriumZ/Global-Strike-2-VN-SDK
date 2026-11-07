using System;

namespace NotifyEvent;

public interface IListNotify : INotify
{
	int Id { get; }

	void AddEvent<T, TF>(string propertyname, ListGetDelegate<T, TF> getfunc, ListSetDelegate<T, TF> setfunc, int bindIndex = -1, int subEventId = -1);

	void AddCountChange(Action<int, int> handler);

	void RemoveCountChange(Action<int, int> handler);

	void RemoveEvent(string propertyname);
}
