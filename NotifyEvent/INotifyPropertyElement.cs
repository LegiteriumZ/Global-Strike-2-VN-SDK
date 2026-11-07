namespace NotifyEvent;

public interface INotifyPropertyElement
{
	string Name { get; }

	int Bind { get; }

	int SubEventId { get; set; }

	INotifyPropertyElement CloneNew<T>(T target, int idx, int binder = -1) where T : class;

	void ApplyToOther(INotifyPropertyElement other, int binder = -1);

	bool Invoke<T>(T target, int index, ElementStatus status) where T : class;

	void ForceInvoke<T>(T target, int index) where T : class;
}
