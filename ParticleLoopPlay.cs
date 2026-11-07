using UnityEngine;

public class ParticleLoopPlay : MonoBehaviour
{
	public float Delay = 5f;

	public float RandomDelay;

	private float startTime;

	private float currDelay;

	private void Start()
	{
		startTime = Time.time;
		currDelay = Delay + Random.value * RandomDelay;
	}

	private void FixedUpdate()
	{
		if (Time.time - startTime >= currDelay)
		{
			startTime = Time.time;
			GetComponent<ParticleSystem>().Play();
			currDelay = Delay + Random.value * RandomDelay;
		}
	}
}
