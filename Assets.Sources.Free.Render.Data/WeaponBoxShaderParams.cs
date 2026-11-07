using UnityEngine;

namespace Assets.Sources.Free.Render.Data;

internal class WeaponBoxShaderParams : DefaultShaderParams
{
	private Color _col;

	public override void Parse(string data)
	{
		if (Changed(data))
		{
			ColorUtility.TryParseHtmlString(data, out _col);
		}
	}

	public override void Update(IEffectModel3D model, ref FrameParams data)
	{
		if (model != null && model.Material != null)
		{
			model.Material.SetColor("_color", _col);
		}
	}
}
