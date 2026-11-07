using System.Collections.Generic;

namespace NotifyEvent;

internal class NotifyListElement
{
	protected List<INotifyPropertyElement> Properties;

	public virtual void Add(INotifyPropertyElement newelement)
	{
		if (Properties == null)
		{
			Properties = new List<INotifyPropertyElement>();
		}
		bool flag = true;
		for (int i = 0; i < Properties.Count; i++)
		{
			if (Properties[i].Name.Equals(newelement.Name))
			{
				flag = false;
				Properties[i] = newelement;
				break;
			}
		}
		if (flag)
		{
			Properties.Add(newelement);
		}
	}

	public virtual void Remove(string name)
	{
		if (Properties == null)
		{
			return;
		}
		for (int i = 0; i < Properties.Count; i++)
		{
			INotifyPropertyElement notifyPropertyElement = Properties[i];
			if (notifyPropertyElement != null && notifyPropertyElement.Name.Equals(name))
			{
				Properties.RemoveAt(i);
				break;
			}
		}
	}

	public void CloneTo<T>(NotifyListElement other, T target, int index, int binder = -1) where T : class
	{
		if (Properties == null)
		{
			return;
		}
		if (other.Properties == null)
		{
			other.Properties = new List<INotifyPropertyElement>();
		}
		for (int i = 0; i < Properties.Count; i++)
		{
			INotifyPropertyElement notifyPropertyElement = Properties[i];
			INotifyPropertyElement notifyPropertyElement2 = null;
			for (int num = other.Properties.Count - 1; num >= 0; num--)
			{
				INotifyPropertyElement notifyPropertyElement3 = other.Properties[num];
				if (notifyPropertyElement3 == null)
				{
					other.Properties.RemoveAt(num);
				}
				else if (notifyPropertyElement3.Name.Equals(notifyPropertyElement.Name))
				{
					notifyPropertyElement2 = notifyPropertyElement3;
					break;
				}
			}
			if (notifyPropertyElement2 != null)
			{
				if (binder >= 0)
				{
					if (index == binder)
					{
						notifyPropertyElement.ApplyToOther(notifyPropertyElement2);
					}
				}
				else
				{
					notifyPropertyElement.ApplyToOther(notifyPropertyElement2);
				}
			}
			else
			{
				other.Properties.Add(Properties[i].CloneNew(target, index, binder));
			}
		}
	}

	public bool TryNotify<T>(T target, int idx, ElementStatus status) where T : class
	{
		bool result = false;
		if (Properties != null)
		{
			for (int i = 0; i < Properties.Count; i++)
			{
				if (Properties[i].Invoke(target, idx, status))
				{
					result = true;
				}
			}
		}
		return result;
	}

	public void ForceInvoke<T>(T target, int idx) where T : class
	{
		if (Properties != null)
		{
			for (int i = 0; i < Properties.Count; i++)
			{
				Properties[i].ForceInvoke(target, idx);
			}
		}
	}

	public void ForceInvokeByEventId<T>(T target, int idx, int subEventId) where T : class
	{
		if (Properties == null)
		{
			return;
		}
		for (int i = 0; i < Properties.Count; i++)
		{
			if (Properties[i].SubEventId == subEventId)
			{
				Properties[i].ForceInvoke(target, idx);
			}
		}
	}
}
