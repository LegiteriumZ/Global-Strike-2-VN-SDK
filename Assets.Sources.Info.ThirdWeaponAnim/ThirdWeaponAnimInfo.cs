using SSJJAnim.AnimData;
using SSJJAnim.WeaponAnim;
using SSJJAsset.AssetLoader.Xml;

namespace Assets.Sources.Info.ThirdWeaponAnim;

internal class ThirdWeaponAnimInfo : AbstractXmlAsset, IThirdWeaponAnimInfo
{
	public AnimationArray AnimationArray;

	protected override void ParseXml(string text)
	{
		base.ParseXml(text);
		AnimationArray = WeaponAnimationData.ReadWeaponActionData(text);
	}
}
