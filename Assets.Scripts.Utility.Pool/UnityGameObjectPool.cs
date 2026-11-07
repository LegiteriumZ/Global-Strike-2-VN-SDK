using SSJJAsset.Asset;
using UnityEngine;

namespace Assets.Scripts.Utility.Pool;

public class UnityGameObjectPool : AbstractUnityObjectPool<UnityGameObjectPool, GameObject>, IGameObjectPool, IUnityObjectPool<GameObject>
{
	private GameObject _subNode;

	private void Awake()
	{
		_subNode = new GameObject("Pool");
		_subNode.transform.parent = base.transform;
		_subNode.SetObjectActive(isactive: false);
	}

	private void EditorStorage(AssetInfo key, GameObject go)
	{
		string value = key.AssetName.Info.Replace("Assets/Res/Assets/", "");
		Transform transform = null;
		for (int i = 0; i < _subNode.transform.childCount; i++)
		{
			if (_subNode.transform.GetChild(i).name.Contains(value))
			{
				transform = _subNode.transform.GetChild(i);
				break;
			}
		}
		if (transform == null)
		{
			transform = new GameObject(value).transform;
			transform.SetParent(_subNode.transform, worldPositionStays: false);
		}
		go.transform.SetParent(transform, worldPositionStays: false);
		go.name = value;
		transform.name = go.name + "_" + transform.transform.childCount;
	}

	public override void Add(AssetInfo key, GameObject go)
	{
		base.Add(key, go);
		go.transform.SetParent(_subNode.transform, worldPositionStays: false);
		go.transform.position = Vector3.zero;
	}

	public override GameObject GetOrNull(AssetInfo key)
	{
		GameObject orNull = base.GetOrNull(key);
		if (orNull != null)
		{
			orNull.transform.parent = null;
			orNull.SetActive(value: true);
		}
		return orNull;
	}

	public void Collect(IReusableGameObject reusableGameObject)
	{
		AssetInfo assetInfo = reusableGameObject.GetAssetInfo();
		GameObject go = reusableGameObject.GetGameObject();
		reusableGameObject.OnRecycle();
		if (reusableGameObject.WhenRecycleAddPool())
		{
			Add(assetInfo, go);
		}
	}

	public override void Unload(AssetInfo info)
	{
		GameObject orNull = GetOrNull(info);
		if (orNull != null)
		{
			Object.Destroy(orNull);
		}
	}

	public override void UnloadImmediate(AssetInfo info)
	{
		GameObject orNull = GetOrNull(info);
		if (orNull != null)
		{
			Object.DestroyImmediate(orNull);
		}
	}
}
