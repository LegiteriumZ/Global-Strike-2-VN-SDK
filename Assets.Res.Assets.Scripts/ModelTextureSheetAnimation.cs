using System;
using UnityEngine;

namespace Assets.Res.Assets.Scripts;

public class ModelTextureSheetAnimation : MonoBehaviour
{
	private float _lastTime;

	private Material[] _materials;

	private int _textureIdx;

	public bool IsLoop = true;

	public int MinMap = 1;

	public int Speed = 50;

	public Texture2D[] Textures;

	public bool ShareMaterial;

	private const int Capacity = 2;

	public void UpdateTex(int index, Texture2D tex)
	{
		if (Textures == null)
		{
			Textures = new Texture2D[Mathf.Max(index + 1, 2)];
		}
		EnsureGrowCapacity(index);
		Textures[index] = tex;
	}

	private void EnsureGrowCapacity(int index)
	{
		if (index >= Textures.Length)
		{
			Texture2D[] array = new Texture2D[Textures.Length * 2];
			Buffer.BlockCopy(Textures, 0, array, 0, Textures.Length);
			Textures = array;
		}
	}

	private void Start()
	{
		SkinnedMeshRenderer component = GetComponent<SkinnedMeshRenderer>();
		_textureIdx = 0;
		_lastTime = 0f;
		if (Textures.Length == 0)
		{
			return;
		}
		if (component != null)
		{
			if (ShareMaterial)
			{
				_materials = new Material[component.sharedMaterials.Length];
				for (int i = 0; i < component.sharedMaterials.Length; i++)
				{
					_materials[i] = component.sharedMaterials[i];
				}
				if (_materials.Length > 1)
				{
					for (int j = 1; j < component.sharedMaterials.Length; j++)
					{
						component.sharedMaterials[j] = component.sharedMaterials[0];
					}
				}
			}
			else
			{
				_materials = new Material[component.materials.Length];
				for (int k = 0; k < component.materials.Length; k++)
				{
					_materials[k] = component.materials[k];
				}
				if (_materials.Length > 1)
				{
					for (int l = 1; l < component.materials.Length; l++)
					{
						component.materials[l] = component.materials[0];
					}
				}
			}
		}
		else
		{
			MeshRenderer component2 = GetComponent<MeshRenderer>();
			if (component2 != null)
			{
				if (ShareMaterial)
				{
					_materials = new Material[component2.sharedMaterials.Length];
					for (int m = 0; m < component2.sharedMaterials.Length; m++)
					{
						_materials[m] = component2.sharedMaterials[m];
					}
				}
				else
				{
					_materials = new Material[component2.materials.Length];
					for (int n = 0; n < component2.materials.Length; n++)
					{
						_materials[n] = component2.materials[n];
					}
				}
			}
		}
		for (int num = 0; num < _materials.Length; num++)
		{
			_materials[num].mainTexture = Textures[0];
		}
	}

	private void OnEnable()
	{
		if (Textures != null)
		{
			Start();
		}
		_lastTime = 0f;
		_textureIdx = 0;
		if (_materials != null && Textures.Length != 0)
		{
			for (int i = 0; i < _materials.Length; i++)
			{
				_materials[i].mainTexture = Textures[0];
			}
		}
	}

	private void Update()
	{
		if (_materials == null)
		{
			return;
		}
		_lastTime += Time.deltaTime * 1000f;
		if (!(_lastTime > (float)Speed))
		{
			return;
		}
		_lastTime -= Speed;
		_textureIdx++;
		if (IsLoop || _textureIdx < Textures.Length)
		{
			_textureIdx %= Textures.Length;
			for (int i = 0; i < _materials.Length; i++)
			{
				_materials[i].mainTexture = Textures[_textureIdx];
			}
		}
	}
}
