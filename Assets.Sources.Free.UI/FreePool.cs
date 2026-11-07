using SSJJBase.Pool;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Free.UI;

public class FreePool : MonoBehaviourSingleton<FreePool>
{
	private readonly StackObjectPool<SimpleFreeUI> _pool = new StackObjectPool<SimpleFreeUI>();

	private Transform _pTransform;

	private Transform PoolParent
	{
		get
		{
			if (_pTransform == null)
			{
				_pTransform = new GameObject("FreePool").transform;
			}
			return _pTransform;
		}
	}

	public SimpleFreeUI GetFreeUi()
	{
		return _pool.GetOrNull();
	}

	public void Collect(SimpleFreeUI freeUi)
	{
		freeUi.gameObject.SetObjectActive(isactive: false);
		freeUi.transform.SetParent(PoolParent);
		freeUi.ResetData(isDestroy: false);
		_pool.Add(freeUi);
	}

	public bool CheckIsRecyclable(string key)
	{
		if (key.Contains("inventory_default_item") || key.Contains("inventory_near_item"))
		{
			return true;
		}
		return false;
	}
}
