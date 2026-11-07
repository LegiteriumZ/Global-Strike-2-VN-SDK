namespace NotifyEvent;

public interface IMultiNotify : IValueNotify, INotify
{
	int Id { get; }

	void Add(object element);

	void Remove(object element);
}
