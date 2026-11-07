using System.Collections.Generic;
using Assets.Scripts;
using Assets.Sources.Config;
using SSJJAsset.AssetBundle;
using SSJJBase.Logger;

internal class AssetBundleManagerUtility
{
	private static LoggerAdapter Logger = new LoggerAdapter(typeof(AssetBundleManagerUtility));

	private static IDictionary<string, string> ResourceURLRedirect = new Dictionary<string, string>
	{
		{ "http://192.168.0.2/client/master/", "http://192.168.0.20/GameClientUnity_Build_master_Job/AssetBundles/" },
		{ "http://192.168.0.2/client/master_test/", "http://192.168.0.20/GameClientUnity_Build_master_test_Job/AssetBundles/" }
	};

	public static string GetResourceBaseURL(string url)
	{
		if (ResourceURLRedirect.TryGetValue(url, out var value))
		{
			Logger.InfoFormat("Asset Bundle  Server URL Redirect from {0} to {1}", url, value);
			return value;
		}
		return url;
	}

	public static void InitResourceUrl()
	{
		if (!GameEnvironment.IsSimulation)
		{
			string resourceBaseURL = GetResourceBaseURL(TplManager.Instance.GetBootConfig().ResourceBase);
			Logger.InfoFormat("Asset Bundle  Server URL {0}", resourceBaseURL);
			AssetBundleManager.SetSourceAssetBundleURL(resourceBaseURL);
		}
	}
}
