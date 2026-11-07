using UnityEngine;

namespace Assets.Sources.Free.Render.Data;

internal class ThunderShaderParams : DefaultShaderParams
{
	public override void Update(IEffectModel3D model, ref FrameParams data)
	{
		if (model.Material != null)
		{
			float num = data.Constheight / model.Model3D.ScaleX;
			model.Material.SetFloat("_v", num);
			model.Material.SetFloat("_UVScale", 1f / Mathf.Max(0.01f, num));
		}
	}
}
