using UnityEngine.UI;

namespace Res.Assets.Scripts.ExImage;

public class ProtectImage : Image
{
	protected override void OnPopulateMesh(VertexHelper toFill)
	{
		if (base.sprite == null && base.overrideSprite == null)
		{
			toFill.Clear();
		}
		else
		{
			base.OnPopulateMesh(toFill);
		}
	}
}
