using SSJJAnim.WeaponAnim;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.WeaponAnim;

public class WeaponAnimAsset : AbstractXmlAsset
{
	public IWeaponAnimInfo WeaponAnimInfo;

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		WeaponAnimInfo = new DefaultWeaponAnimInfo
		{
			AnimationArray = WeaponAnimationData.ReadWeaponActionData(text)
		};
	}
}
