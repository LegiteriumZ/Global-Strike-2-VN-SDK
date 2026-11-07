using System.Collections.Generic;

namespace NotifyEvent;

public class NotifyGroup
{
	public static HashSet<int> SuspendList = new HashSet<int>();

	private static HashSet<int> _inGroupList = new HashSet<int>();

	private HashSet<int> _notifyList = new HashSet<int>();

	public void SetSuspend(bool suspend, bool forceInvoke = true)
	{
		INotify notify;
		if (suspend)
		{
			foreach (int notify2 in _notifyList)
			{
				SuspendList.Add(notify2);
				if (NotifyManager.TryGetNotify(notify2, out notify))
				{
					notify.Suspend = true;
				}
			}
			return;
		}
		foreach (int notify3 in _notifyList)
		{
			SuspendList.Remove(notify3);
			if (NotifyManager.TryGetNotify(notify3, out notify))
			{
				notify.Suspend = false;
			}
			if (forceInvoke)
			{
				NotifyManager.ForceInvoke(notify3);
			}
		}
	}

	public void Add(int id)
	{
		if (!_notifyList.Contains(id) && !_inGroupList.Contains(id))
		{
			_notifyList.Add(id);
			_inGroupList.Add(id);
		}
	}

	public void Remove(int id)
	{
		if (_notifyList.Contains(id))
		{
			_notifyList.Remove(id);
			_inGroupList.Remove(id);
		}
	}

	public static void Clear()
	{
		SuspendList.Clear();
		_inGroupList.Clear();
	}
}
