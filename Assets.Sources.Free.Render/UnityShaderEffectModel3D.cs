using Assets.Sources.Free.Render.Data;
using Assets.Sources.Free.Utility;
using SSJJBase.Thread;
using UnityEngine;

namespace Assets.Sources.Free.Render;

public class UnityShaderEffectModel3D : UnityAbstractEffectModel3D
{
	public override string ModelName
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
				_modelEnumerator = FreeResourceUtility.LoadEffectModel(this, _modelName, base.ModelDone, createmat: false);
				BaseAsyncManager.Instance.StartCoroutine(_modelEnumerator);
			}
		}
	}

	public override string TextureName
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
				_textureEnumerator = FreeResourceUtility.LoadEffectTexture(this, _textureName, _modelLoad, ShaderPorperty.MainTexName);
				BaseAsyncManager.Instance.StartCoroutine(_textureEnumerator);
			}
		}
	}

	public override Material Material
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
				MeshRender.material = _material;
				base.ShaderName = _shadername;
			}
		}
	}

	public IParamsShader ShaderPorperty { get; set; }

	public UnityShaderEffectModel3D(IObject3D obj)
		: base(obj)
	{
		base.Model3D = obj;
	}

	public override void Frame(ref FrameParams data)
	{
		if (!string.IsNullOrEmpty(data.ModelName))
		{
			ModelName = data.ModelName;
		}
		if (_modelLoad == null || !_modelLoad.IsModelLoadOk)
		{
			return;
		}
		if (!string.IsNullOrEmpty(data.ShaderName))
		{
			base.ShaderName = data.ShaderName;
		}
		if (base.ShaderName == "Shader Forge/electricity_dianwang")
		{
			if (!string.IsNullOrEmpty(data.ShaderParams))
			{
				if (!(ShaderPorperty is ThunderShaderParams))
				{
					ShaderPorperty = new ThunderShaderParams();
				}
				ShaderPorperty.Parse(data.ShaderParams);
			}
			if (!string.IsNullOrEmpty(data.TextureParams))
			{
				TextureName = data.TextureParams;
			}
		}
		else if (base.ShaderName == "Shader Forge/wutibiankuang_1")
		{
			if (!string.IsNullOrEmpty(data.ShaderParams))
			{
				if (!(ShaderPorperty is WeaponBoxShaderParams))
				{
					ShaderPorperty = new WeaponBoxShaderParams();
				}
				ShaderPorperty.Parse(data.ShaderParams);
			}
			if (!string.IsNullOrEmpty(data.TextureParams))
			{
				TextureName = data.TextureParams;
			}
		}
		else if (!string.IsNullOrEmpty(data.TextureParams))
		{
			TextureName = data.TextureParams;
		}
		if (ShaderPorperty != null)
		{
			ShaderPorperty.Update(this, ref data);
		}
	}
}
