using Assets.Sources.Utils;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class UvLive2DCameraEffect : MonoBehaviour
{
	private int spineLayer = -1;

	private Vector3 tmpScale;

	private void Awake()
	{
	}

	private void Start()
	{
		spineLayer = LayerMask.NameToLayer("spine");
		tmpScale.Set(1f / base.transform.lossyScale.x, 1f / base.transform.lossyScale.y, 1f / base.transform.lossyScale.z);
		base.transform.localScale = tmpScale;
	}

	private void Update()
	{
		base.transform.localScale = tmpScale;
		if (base.transform.gameObject.layer != spineLayer)
		{
			LayerUtility.SetLayerRecursively(base.transform.gameObject, spineLayer);
		}
	}
}
