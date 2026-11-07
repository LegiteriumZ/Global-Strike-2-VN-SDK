namespace Assets.Sources.Free.Render.Data;

public interface IParamsShader
{
	string MainTexName { get; set; }

	void Parse(string data);

	void Update(IEffectModel3D model, ref FrameParams data);
}
