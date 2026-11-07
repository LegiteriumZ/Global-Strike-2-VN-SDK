using UnityEngine;

namespace Assets.Sources.Utils.Uf3d;

public class ParticleFollow : MonoBehaviour
{
	public Transform Follow;

	private void Start()
	{
	}

	private void Update()
	{
		if (Follow != null)
		{
			base.transform.position = Follow.position;
		}
	}
}
