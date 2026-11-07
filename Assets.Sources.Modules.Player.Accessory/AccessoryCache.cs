using System.Collections.Generic;

namespace Assets.Sources.Modules.Player.Accessory;

public class AccessoryCache
{
	public struct AccessoryPath
	{
		public string BundlePath;

		public string MatrixXmlPath;

		public string MatrixXmlRequest;

		public string PrefabPath;

		public string PrefabRequest;

		public string PrefabAnimPath;

		public string PrefabAnimRequest;

		public string AnimXmlPath;

		public string AnimXmlRequest;

		public string TextureConfigPath;

		public string TextureConfigRequest;

		public string EffectXmlPath;

		public string ParticleXmlPath;

		public string EffectXmlRequest;

		public string ParticleXmlRequest;

		public string EffectDirPath;

		public string ConfigureXmlRequest;

		public string ConfigureXmlpath;
	}

	private static Dictionary<string, AccessoryPath> _cache = new Dictionary<string, AccessoryPath>();

	public static AccessoryPath GetAccessory(string accessoryName)
	{
		if (!_cache.TryGetValue(accessoryName, out var value))
		{
			value = default(AccessoryPath);
			value.BundlePath = "accessory/" + accessoryName;
			value.MatrixXmlPath = "Assets/Res/Assets/accessory/" + accessoryName + "/matrix.xml";
			value.PrefabPath = "Assets/Res/Assets/accessory/" + accessoryName + "/model.prefab";
			value.PrefabAnimPath = "Assets/Res/Assets/accessory/" + accessoryName + "/model.anm.bytes";
			value.AnimXmlPath = "Assets/Res/Assets/accessory/" + accessoryName + "/model.DAE.action.xml";
			value.TextureConfigPath = "Assets/Res/Assets/accessory/" + accessoryName + "/textureconfig.xml";
			value.ConfigureXmlpath = "Assets/Res/Assets/accessory/" + accessoryName + "/Configure.xml";
			value.MatrixXmlRequest = "config_" + accessoryName;
			value.PrefabRequest = "model_" + accessoryName;
			value.PrefabAnimRequest = "modelAnim_" + accessoryName;
			value.AnimXmlRequest = "xml_" + accessoryName;
			value.TextureConfigRequest = "textureConfig_" + accessoryName;
			value.ConfigureXmlRequest = "configure_" + accessoryName;
			value.EffectXmlPath = $"Assets/Res/Assets/accessory/{accessoryName}/effect/effectConfig.xml";
			value.EffectXmlRequest = accessoryName + "_EffectXml";
			value.ParticleXmlPath = $"Assets/Res/Assets/accessory/{accessoryName}/effect/particleEffectConfig.xml";
			value.ParticleXmlRequest = accessoryName + "_ParticleXml";
			value.EffectDirPath = $"Assets/Res/Assets/accessory/{accessoryName}/effect";
			_cache[accessoryName] = value;
		}
		return value;
	}
}
