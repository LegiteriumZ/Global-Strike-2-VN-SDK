namespace Assets.Sources.Info.Accessory;

public class BackWeaponXmlConfigFactory
{
	public static BackWeaponXmlConfig Default;

	private static string defaultConfig;

	static BackWeaponXmlConfigFactory()
	{
		defaultConfig = "<node><matrix name=\"man\">0.487 -12.16 -1.672 170 0 -486 1 1 1</matrix><matrix name=\"woman\">-1.938 -7.717 -1.802 174 -4 -473 1 1 1</matrix></node>";
		Default = new BackWeaponXmlConfig();
		Default.SyncParse(defaultConfig);
	}
}
