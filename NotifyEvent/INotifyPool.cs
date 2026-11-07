namespace NotifyEvent;

internal interface INotifyPool
{
	void Add<T>(T val) where T : class;

	T Get<T>() where T : class, new();

	void Clear();
}
