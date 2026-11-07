using System.Collections.Generic;

namespace Assets.Libs.NotifyLib.Simplify;

public class SimpleNotifyGroup
{
	private HashSet<int> _notifyList = new HashSet<int>();

	public void SetSuspend(bool suspend)
	{
		ISimpleNotifyInfo notify;
		if (suspend)
		{
			foreach (int notify2 in _notifyList)
			{
				if (SimpleNotify.TryGetNotify(notify2, out notify))
				{
					notify.Suspend = true;
				}
			}
			return;
		}
		foreach (int notify3 in _notifyList)
		{
			if (SimpleNotify.TryGetNotify(notify3, out notify))
			{
				notify.Suspend = false;
			}
		}
	}

	public void Add(int id)
	{
		if (!_notifyList.Contains(id))
		{
			_notifyList.Add(id);
		}
	}

	public void Remove(int id)
	{
		if (_notifyList.Contains(id))
		{
			_notifyList.Remove(id);
		}
	}
}
