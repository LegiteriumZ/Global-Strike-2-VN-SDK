using UnityEngine;

namespace Assets.Sources.Utils.Uf3d;

public class StrentchPivot : MonoBehaviour
{
	public float OriginPivot;

	private float _scale = 1f;

	private ParticleSystemRenderer _renderer;

	public ParticleSystemRenderer Renderer
	{
		get
		{
			if (_renderer == null)
			{
				_renderer = GetComponent<ParticleSystemRenderer>();
			}
			return _renderer;
		}
	}

	private void OnEnable()
	{
		UpdatePivot();
	}

	private void Update()
	{
		UpdatePivot();
	}

	private void UpdatePivot()
	{
		float y = base.transform.lossyScale.y;
		SetNewPivot(y);
	}

	public void SetNewPivot(float scale)
	{
		if (!Mathf.Approximately(_scale, scale))
		{
			Renderer.pivot = new Vector3(0f, OriginPivot * scale * 0.75f, 0f);
			_scale = scale;
		}
	}
}
