namespace Assets.Sources.Free.Render.Data;

internal class DefaultShaderParams : IParamsShader
{
	private string _mainTexName = "_MainTex";

	private string _lastData;

	public string MainTexName
	{
		get
		{
			return _mainTexName;
		}
		set
		{
			_mainTexName = value;
		}
	}

	protected bool Changed(string data)
	{
		bool result = _lastData != data;
		_lastData = data;
		return result;
	}

	public virtual void Parse(string data)
	{
		if (Changed(data))
		{
			MainTexName = data;
		}
	}

	public virtual void Update(IEffectModel3D model, ref FrameParams data)
	{
	}
}
