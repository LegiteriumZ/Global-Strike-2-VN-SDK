using SSJJAsset.Asset;
using SSJJBase.Logger;
using UnityEngine;

namespace Assets.Scripts.Asset;

public abstract class ReusableGameObjectBase : MonoBehaviour, IReusableGameObject
{
	private AssetInfo _assetInfo;

	private GameObject _gameObject;

	private bool _initCalled;

	public void Init(AssetInfo assetInfo, GameObject obj)
	{
		if (!_initCalled)
		{
			_initCalled = true;
			_assetInfo = assetInfo;
			_gameObject = obj;
			OnCreated();
		}
	}

	public AssetInfo GetAssetInfo()
	{
		return _assetInfo;
	}

	public GameObject GetGameObject()
	{
		return _gameObject;
	}

	public abstract void OnRecycle();

	public virtual bool WhenRecycleAddPool()
	{
		return true;
	}

	public abstract void OnCreated();

	protected void DestroyComponent<CT>() where CT : MonoBehaviour
	{
		CT component = GetGameObject().GetComponent<CT>();
		if (component != null)
		{
			this.InfoFormat("DestoryCOmponent {0} ", component);
			Object.Destroy(component);
		}
	}
}
