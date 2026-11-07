using UnityEngine;

namespace Assets.Scripts.Utility;

internal class KeepInitTransform : MonoBehaviour
{
	[SerializeField]
	private Vector3 localPosition;

	[SerializeField]
	private Vector3 localEulerAngles;

	[SerializeField]
	private Vector3 localScale;

	private bool isInit;

	public static void KeepInit(GameObject o)
	{
		KeepInitTransform keepInitTransform = o.GetComponent<KeepInitTransform>();
		if (keepInitTransform == null)
		{
			keepInitTransform = o.AddComponent<KeepInitTransform>();
		}
		keepInitTransform.Init();
	}

	private void Init()
	{
		if (!isInit)
		{
			localPosition = base.transform.localPosition;
			localEulerAngles = base.transform.localEulerAngles;
			localScale = base.transform.localScale;
			isInit = true;
		}
	}

	public void Start()
	{
		Init();
	}

	public void OnEnable()
	{
		if (isInit)
		{
			base.transform.localPosition = localPosition;
			base.transform.localEulerAngles = localEulerAngles;
			base.transform.localScale = localScale;
		}
	}
}
