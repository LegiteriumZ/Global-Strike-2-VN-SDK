using System.Collections.Generic;

namespace Sources.Modules.Player.Chain;

public struct WeaponChain<T> where T : struct
{
	private readonly Dictionary<int, IWeaponGenericChain<T>> _chains;

	private readonly int _size;

	private int _nextpoint;

	public Dictionary<int, IWeaponGenericChain<T>> GetChain()
	{
		return _chains;
	}

	public WeaponChain(int capacity)
	{
		_chains = new Dictionary<int, IWeaponGenericChain<T>>(capacity);
		_size = capacity;
		_nextpoint = -1;
	}

	public int Size()
	{
		return _chains.Count;
	}

	public void Reset()
	{
		_nextpoint = -1;
		_chains.Clear();
	}

	public void Step(ref T args)
	{
		int num = 0;
		IWeaponGenericChain<T> value;
		while (_chains.TryGetValue(num, out value))
		{
			if (value != null)
			{
				int num2 = value.Action(ref args);
				if (num2 < 0)
				{
					break;
				}
				num = num * 2 + 1 + num2;
			}
		}
	}

	public void AddChain(IWeaponGenericChain<T> right)
	{
		int num = ((_nextpoint >= 0) ? (_nextpoint * 2 + 1) : 0);
		_chains[num] = right;
		_nextpoint = num;
	}

	public WeaponChain<T> AddChain(int nodeindex, IWeaponGenericChain<T> right)
	{
		int num = ((_nextpoint >= 0) ? (_nextpoint * 2 + 1 + nodeindex) : 0);
		_chains[num] = right;
		WeaponChain<T> result = this;
		result._nextpoint = num;
		return result;
	}
}
