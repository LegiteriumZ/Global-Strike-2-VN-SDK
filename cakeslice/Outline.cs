using UnityEngine;

namespace cakeslice;

[ExecuteInEditMode]
[RequireComponent(typeof(Renderer))]
public class Outline : MonoBehaviour
{
	public int color;

	public bool eraseRenderer;

	[HideInInspector]
	public int originalLayer;

	[HideInInspector]
	public Material[] originalMaterials;

	public Renderer Renderer { get; private set; }

	private void Awake()
	{
		Renderer = GetComponent<Renderer>();
	}

	private void OnEnable()
	{
		Camera[] allCameras = Camera.allCameras;
		for (int i = 0; i < allCameras.Length; i++)
		{
			OutlineEffect component = allCameras[i].GetComponent<OutlineEffect>();
			if ((bool)component)
			{
				component.AddOutline(this);
			}
		}
	}

	private void OnDisable()
	{
		Camera[] allCameras = Camera.allCameras;
		for (int i = 0; i < allCameras.Length; i++)
		{
			OutlineEffect component = allCameras[i].GetComponent<OutlineEffect>();
			if ((bool)component)
			{
				component.RemoveOutline(this);
			}
		}
	}
}
