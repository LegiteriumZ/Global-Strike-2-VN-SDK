namespace I2.Loc;

public static class ScriptLocalization
{
	public static string Get(string Term)
	{
		return Get(Term, fixForRtl: false, 0);
	}

	public static string Get(string Term, bool fixForRtl)
	{
		return Get(Term, fixForRtl, 0);
	}

	public static string Get(string Term, bool fixForRtl, int maxLineLengthForRtl)
	{
		return LocalizationManager.GetTermTranslation(Term, fixForRtl, maxLineLengthForRtl);
	}
}
