using System.Collections;
using Assets.Sources.Free.Utility;
using SSJJBase.Logger;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Free.Render;

public abstract class UnityAbstractEffectModel3D : IEffectModel3D
{
	protected IEnumerator _modelEnumerator;

	protected readonly FreeEffectLoadModel _modelLoad = new FreeEffectLoadModel();

	protected string _modelName;

	protected IEnumerator _textureEnumerator;

	protected string _textureName;

	protected Material _material;

	protected string _shadername;

	public IObject3D Model3D { get; protected set; }

	public virtual float Alpha { get; set; }

	public virtual int Culling { get; set; }

	public virtual string ResUrl
	{
		get
		{
			return TextureName;
		}
		set
		{
			TextureName = value;
		}
	}

	public int GeometryType { get; set; }

	public virtual string ModelName
	{
		get
		{
			return _modelName;
		}
		set
		{
			if (!(_modelName == value) && value != null)
			{
				_modelName = value;
				if (_modelEnumerator != null)
				{
					BaseAsyncManager.Instance.StopCoroutine(_modelEnumerator);
					_modelEnumerator = null;
				}
				_modelEnumerator = FreeResourceUtility.LoadEffectModel(this, _modelName, ModelDone);
				BaseAsyncManager.Instance.StartCoroutine(_modelEnumerator);
			}
		}
	}

	public virtual string TextureName
	{
		get
		{
			return _textureName;
		}
		set
		{
			if (!(value == _textureName) && value != null)
			{
				_textureName = value;
				if (_textureEnumerator != null)
				{
					BaseAsyncManager.Instance.StopCoroutine(_textureEnumerator);
					_textureEnumerator = null;
				}
				_textureEnumerator = FreeResourceUtility.LoadEffectTexture(this, _textureName, _modelLoad);
				BaseAsyncManager.Instance.StartCoroutine(_textureEnumerator);
			}
		}
	}

	public virtual Renderer MeshRender { get; set; }

	public virtual Material Material
	{
		get
		{
			return _material;
		}
		set
		{
			_material = value;
			if (MeshRender != null)
			{
				MeshRender.material = Material;
			}
		}
	}

	public virtual GameObject GameObject => Model3D.GameObject;

	public virtual int DepthMode { get; set; }

	public string ShaderName
	{
		get
		{
			return _shadername;
		}
		set
		{
			if (!(_shadername != value))
			{
				return;
			}
			_shadername = value;
			if ((bool)_material)
			{
				Shader shader = Shader.Find(value);
				if ((bool)shader)
				{
					_material.shader = shader;
				}
				else
				{
					this.LogErrorFormat("not found shader: {0}", value);
				}
			}
		}
	}

	protected UnityAbstractEffectModel3D(IObject3D obj)
	{
		if (Model3D != null && GameObject != null)
		{
			Object.DestroyImmediate(GameObject);
		}
		Model3D = obj;
	}

	public virtual void Frame(ref FrameParams data)
	{
	}

	protected void ModelDone()
	{
		_modelLoad.IsModelLoadOk = true;
	}

	public void Destory()
	{
		Object.DestroyImmediate(GameObject);
	}
}
