using Assets.Sources.Components.Interface;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.Rail;

public abstract class BaseRailEffect : MonoBehaviour, IBaseRailEffect
{
	protected BulletRailParamData _ParamData;

	protected bool Enable;

	public Texture2D Texture2D;

	private SpriteRenderer _sprite;

	protected MeshRenderer _meshRenderer;

	protected Material _meshRenderMaterial;

	protected Mesh _originMesh;

	protected SpriteRenderer GetSpriteRenderer()
	{
		if (_sprite == null)
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				SpriteRenderer component = base.transform.GetChild(i).GetComponent<SpriteRenderer>();
				if (component != null)
				{
					_sprite = component;
					break;
				}
			}
		}
		return _sprite;
	}

	protected MeshRenderer GetMeshRender()
	{
		if (_meshRenderer == null)
		{
			for (int i = 0; i < base.transform.childCount; i++)
			{
				MeshRenderer component = base.transform.GetChild(i).GetComponent<MeshRenderer>();
				if (component != null)
				{
					_meshRenderer = component;
					break;
				}
			}
		}
		if (_meshRenderer != null)
		{
			_meshRenderMaterial = _meshRenderer.material;
			_originMesh = _meshRenderer.GetComponent<MeshFilter>().sharedMesh;
		}
		return _meshRenderer;
	}

	protected void SetLength(float length)
	{
		_sprite = GetSpriteRenderer();
		if (_sprite != null)
		{
			int width = _sprite.sprite.texture.width;
			int height = _sprite.sprite.texture.height;
			_sprite.transform.localScale = new Vector3(_ParamData.RailWidth / (float)width, length / (float)height, 1f);
		}
	}

	public abstract void Render();

	protected abstract void InitIfDataChanged();

	public void SetRailData(ref BulletRailParamData data)
	{
		_ParamData = data;
		GetMeshRender();
		InitIfDataChanged();
	}

	public bool IsEnd()
	{
		return !Enable;
	}

	public void OnDisable()
	{
		base.transform.position = Vector3.zero;
		Enable = false;
	}

	public void OnEnable()
	{
		Enable = true;
	}
}
