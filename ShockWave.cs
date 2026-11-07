using UnityEngine;

public class ShockWave : MonoBehaviour
{
	private int effectTime;

	private GameObject plane;

	private GameObject model1;

	private GameObject model2;

	private Renderer _render1;

	private Renderer _render2;

	private MaterialPropertyBlock _block1;

	private MaterialPropertyBlock _block2;

	private void Start()
	{
		plane = base.gameObject.FindForeachByName("shockwaveplane");
		if ((bool)plane)
		{
			plane = plane.transform.GetChild(0).gameObject;
		}
		model1 = base.gameObject.FindForeachByName("shockwavemodel1");
		if ((bool)model1)
		{
			model1 = model1.transform.GetChild(0).gameObject;
		}
		model2 = base.gameObject.FindForeachByName("shockwavemodel2");
		if ((bool)model2)
		{
			model2 = model2.transform.GetChild(0).gameObject;
		}
		_render1 = model1.GetComponent<Renderer>();
		_render2 = model1.GetComponent<Renderer>();
		_block1 = new MaterialPropertyBlock();
		_block2 = new MaterialPropertyBlock();
	}

	private void Update()
	{
		UpdateModelAlpha();
		effectTime += (int)Time.deltaTime * 1000;
	}

	private void UpdateModelAlpha()
	{
		int num = effectTime / 500;
		num = ((num <= 1) ? 1 : num);
		_render1.GetPropertyBlock(_block1);
		_render2.GetPropertyBlock(_block2);
		_block1.SetColor("_Color", new Color(255f, 255f, 255f, num * 255));
		_block2.SetColor("_Color", new Color(255f, 255f, 255f, num * 255));
	}
}
