using UnityEngine;

public class RandomRotation : MonoBehaviour
{
	private Vector3 initLocalRotation;

	public Vector3 RandomLocalVector3;

	private float startTime;

	public float RepeatDelay;

	public bool IsLoop;

	private void Awake()
	{
		initLocalRotation = new Vector3(base.transform.localRotation.x, base.transform.localRotation.y, base.transform.localRotation.z);
	}

	private void Start()
	{
		startTime = Time.time;
	}

	private void FixedUpdate()
	{
		if (RepeatDelay > 0f && Time.time - startTime >= RepeatDelay)
		{
			base.gameObject.SetObjectActive(isactive: true);
			RepeatDelay = (IsLoop ? (startTime + RepeatDelay) : 0f);
		}
	}

	private void OnEnable()
	{
		base.transform.localRotation = Quaternion.Euler(initLocalRotation + new Vector3(Random.value * RandomLocalVector3.x, Random.value * RandomLocalVector3.y, Random.value * RandomLocalVector3.z));
	}

	private void Update()
	{
	}
}
