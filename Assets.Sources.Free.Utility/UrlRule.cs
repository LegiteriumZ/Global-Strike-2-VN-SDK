namespace Assets.Sources.Free.Utility;

public class UrlRule
{
	public static string GetEffectUrl(string url)
	{
		url = url.Replace(".atf", ".png");
		url = url.Replace(".wmdl", ".DAE");
		return url;
	}
}
