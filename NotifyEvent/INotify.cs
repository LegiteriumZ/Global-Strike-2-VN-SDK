namespace NotifyEvent;

public interface INotify
{
	bool Suspend { get; set; }

	bool TryNotify(int nowFrame);

	void ForceInvoke(int subEvnetId = -1);

	void Release();
}
