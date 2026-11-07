using UnityEngine;

namespace Assets.Sources.Utils.Uf3d;

public class ParticleOrbitEffector : MonoBehaviour, IParticleEffector
{
	public float Radiu;

	public float Speed;

	public Axiz Ax = Axiz.z;

	public void SetScaler(float scale)
	{
		Radiu *= scale;
		Transform child = base.transform.GetChild(0);
		if (child != null)
		{
			child.localPosition = new Vector3(Radiu, 0f, 0f);
		}
	}

	private void Update()
	{
		if (Ax == Axiz.z)
		{
			base.transform.Rotate(new Vector3(0f, 0f, Speed * Time.deltaTime));
		}
		else if (Ax == Axiz.y)
		{
			base.transform.Rotate(new Vector3(0f, Speed * Time.deltaTime, 0f));
		}
		else
		{
			base.transform.Rotate(new Vector3(Speed * Time.deltaTime, 0f, 0f));
		}
	}
}
