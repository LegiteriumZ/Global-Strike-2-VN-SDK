using UnityEngine;

namespace Assets.UnityMaps.Lighting;

public class BakeData : MonoBehaviour
{
	public int i;

	public Vector4 s;

	public Renderer r;

	public Terrain t;

	private void Start()
	{
		if (r != null)
		{
			r.lightmapIndex = i;
			r.lightmapScaleOffset = s;
		}
		if (t != null)
		{
			t.lightmapIndex = i;
			t.lightmapScaleOffset = s;
		}
	}
}
