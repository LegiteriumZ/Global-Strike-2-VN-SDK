using System.Collections.Generic;
using UnityEngine;

namespace Assets.Res.Assets.Scripts.Rail;

internal class BowRailEffect : BaseRailEffect
{
	private Vector3 _forward;

	private int endTime;

	public int LeftTime = 1;

	public int RailLength = 256;

	private List<MeshRenderer> _createMeshs = new List<MeshRenderer>();

	public override void Render()
	{
		SpriteRenderer spriteRenderer = GetSpriteRenderer();
		MeshRenderer meshRender = GetMeshRender();
		if (spriteRenderer == null && meshRender == null)
		{
			Enable = false;
		}
		if ((float)endTime < Time.time)
		{
			Enable = false;
		}
		else if (spriteRenderer != null && spriteRenderer.enabled)
		{
			spriteRenderer.color = new Vector4(1f, 1f, 1f, ((float)endTime - Time.time * 1000f) / (float)LeftTime);
		}
		else if (_meshRenderer != null)
		{
			for (int i = 0; i < _createMeshs.Count; i++)
			{
				_createMeshs[i].material.color = new Color(1f, 1f, 1f, ((float)endTime - Time.time * 1000f) / (float)LeftTime);
			}
		}
		base.transform.rotation = Quaternion.LookRotation(_forward, -Camera.main.transform.forward);
	}

	protected override void InitIfDataChanged()
	{
		float magnitude = (_ParamData.End - _ParamData.Start).magnitude;
		if (magnitude < _ParamData.StartOffsetBase)
		{
			Enable = false;
			return;
		}
		_forward = (_ParamData.End - _ParamData.Start).normalized;
		base.transform.position = _ParamData.End;
		base.transform.localScale = new Vector3(1f, 1f, magnitude / (float)RailLength);
		base.transform.rotation = Quaternion.LookRotation(_forward);
		Enable = true;
		endTime = (int)(Time.time * 1000f + (float)LeftTime);
		if (_meshRenderer != null)
		{
			_meshRenderMaterial.mainTexture = Texture2D;
			CreateMesh(RailLength, _ParamData.Start, _ParamData.End, magnitude);
		}
	}

	private void CreateMesh(int length, Vector3 start, Vector3 end, float raillength)
	{
		base.transform.localScale = Vector3.one;
		_meshRenderer.gameObject.SetObjectActive(isactive: false);
		for (int i = 0; i < (int)(raillength / (float)length); i++)
		{
			GameObject gameObject = null;
			if (i < _createMeshs.Count)
			{
				gameObject = _createMeshs[i].gameObject;
			}
			else
			{
				gameObject = Object.Instantiate(_meshRenderer.gameObject);
				_createMeshs.Add(gameObject.GetComponent<MeshRenderer>());
			}
			gameObject.SetObjectActive(isactive: true);
			gameObject.transform.SetParent(_meshRenderer.transform.parent, worldPositionStays: true);
			gameObject.transform.localScale = _meshRenderer.transform.localScale;
			gameObject.transform.localRotation = _meshRenderer.transform.localRotation;
			gameObject.transform.position = (end - start).normalized * length * ((float)i + 0.5f) + start;
		}
		for (int j = (int)(raillength / (float)length); j < _createMeshs.Count; j++)
		{
			_createMeshs[j].gameObject.SetObjectActive(isactive: false);
		}
	}
}
