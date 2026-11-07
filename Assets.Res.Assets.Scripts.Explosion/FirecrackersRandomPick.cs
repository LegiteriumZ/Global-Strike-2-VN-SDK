using UnityEngine;

namespace Assets.Res.Assets.Scripts.Explosion;

internal class FirecrackersRandomPick : MonoBehaviour
{
	public void OnEnable()
	{
		bool flag = Random.value > 0.5f;
		foreach (Transform componentInChild in base.transform.GetComponentInChildren<Transform>())
		{
			if (componentInChild.name.Equals("eexplo"))
			{
				componentInChild.gameObject.SetObjectActive(flag);
			}
			if (componentInChild.name.Equals("eexplo2"))
			{
				componentInChild.gameObject.SetObjectActive(!flag);
			}
		}
	}
}
