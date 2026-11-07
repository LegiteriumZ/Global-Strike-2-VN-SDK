using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class UVEffect : MonoBehaviour
{
	public Vector2 Speed;

	public Material Material;

	private void Awake()
	{
		if (Material == null)
		{
			Material = GetComponent<Renderer>().sharedMaterial;
		}
	}

	private void Update()
	{
		Vector2 vector = Speed * Time.deltaTime;
		Material.mainTextureOffset += vector;
	}
}
