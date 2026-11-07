using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ArabicSupport;
using UnityEngine;

namespace I2.Loc;

public static class LocalizationManager
{
	public delegate void OnLocalizeCallback();

	private static string mCurrentLanguage;

	private static string mLanguageCode;

	public static bool IsRight2Left;

	public static List<LanguageSource> Sources = new List<LanguageSource>();

	public static string[] GlobalSources = new string[1] { "I2Languages" };

	private static string[] LanguagesRTL = new string[20]
	{
		"ar-DZ", "ar", "ar-BH", "ar-EG", "ar-IQ", "ar-JO", "ar-KW", "ar-LB", "ar-LY", "ar-MA",
		"ar-OM", "ar-QA", "ar-SA", "ar-SY", "ar-TN", "ar-AE", "ar-YE", "he", "ur", "ji"
	};

	public static string CurrentLanguage
	{
		get
		{
			InitializeIfNeeded();
			return mCurrentLanguage;
		}
		set
		{
			string supportedLanguage = GetSupportedLanguage(value);
			if (!string.IsNullOrEmpty(supportedLanguage) && mCurrentLanguage != supportedLanguage)
			{
				SetLanguageAndCode(supportedLanguage, GetLanguageCode(supportedLanguage));
			}
		}
	}

	public static string CurrentLanguageCode
	{
		get
		{
			InitializeIfNeeded();
			return mLanguageCode;
		}
		set
		{
			if (mLanguageCode != value)
			{
				string languageFromCode = GetLanguageFromCode(value);
				if (!string.IsNullOrEmpty(languageFromCode))
				{
					SetLanguageAndCode(languageFromCode, value);
				}
			}
		}
	}

	public static string CurrentRegion
	{
		get
		{
			string currentLanguage = CurrentLanguage;
			int num = currentLanguage.IndexOfAny("/\\".ToCharArray());
			if (num > 0)
			{
				return currentLanguage.Substring(num + 1);
			}
			num = currentLanguage.IndexOfAny("[(".ToCharArray());
			int num2 = currentLanguage.LastIndexOfAny("])".ToCharArray());
			if (num > 0 && num != num2)
			{
				return currentLanguage.Substring(num + 1, num2 - num - 1);
			}
			return string.Empty;
		}
		set
		{
			string text = CurrentLanguage;
			int num = text.IndexOfAny("/\\".ToCharArray());
			if (num > 0)
			{
				CurrentLanguage = text.Substring(num + 1) + value;
				return;
			}
			num = text.IndexOfAny("[(".ToCharArray());
			int num2 = text.LastIndexOfAny("])".ToCharArray());
			if (num > 0 && num != num2)
			{
				text = text.Substring(num);
			}
			CurrentLanguage = text + "(" + value + ")";
		}
	}

	public static string CurrentRegionCode
	{
		get
		{
			string currentLanguageCode = CurrentLanguageCode;
			int num = currentLanguageCode.IndexOfAny(" -_/\\".ToCharArray());
			if (num >= 0)
			{
				return currentLanguageCode.Substring(num + 1);
			}
			return string.Empty;
		}
		set
		{
			string text = CurrentLanguageCode;
			int num = text.IndexOfAny(" -_/\\".ToCharArray());
			if (num > 0)
			{
				text = text.Substring(0, num);
			}
			CurrentLanguageCode = text + "-" + value;
		}
	}

	public static event OnLocalizeCallback OnLocalizeEvent;

	private static void InitializeIfNeeded()
	{
		if (string.IsNullOrEmpty(mCurrentLanguage))
		{
			UpdateSources();
			SelectStartupLanguage();
		}
	}

	public static void SetLanguageAndCode(string LanguageName, string languageCode, bool rememberLanguage = true, bool force = false)
	{
		if (mCurrentLanguage != LanguageName || mLanguageCode != languageCode || force)
		{
			if (rememberLanguage)
			{
				PlayerPrefs.SetString("I2 Language", LanguageName);
			}
			mCurrentLanguage = LanguageName;
			mLanguageCode = languageCode;
			IsRight2Left = IsRTL(mLanguageCode);
			LocalizeAll(force);
		}
	}

	private static void SelectStartupLanguage()
	{
		string @string = PlayerPrefs.GetString("I2 Language", string.Empty);
		string text = Application.systemLanguage.ToString();
		if (text == "ChineseSimplified")
		{
			text = "Chinese (Simplified)";
		}
		if (text == "ChineseTraditional")
		{
			text = "Chinese (Traditional)";
		}
		if (HasLanguage(@string, allowDiscartingRegion: true, initialize: false))
		{
			CurrentLanguage = @string;
			return;
		}
		string supportedLanguage = GetSupportedLanguage(text);
		if (!string.IsNullOrEmpty(supportedLanguage))
		{
			SetLanguageAndCode(supportedLanguage, GetLanguageCode(supportedLanguage), rememberLanguage: false);
			return;
		}
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			if (Sources[i].mLanguages.Count > 0)
			{
				SetLanguageAndCode(Sources[i].mLanguages[0].Name, Sources[i].mLanguages[0].Code, rememberLanguage: false);
				break;
			}
		}
	}

	public static string GetTermTranslation(string Term)
	{
		return GetTermTranslation(Term, fixForRtl: false, 0);
	}

	public static string GetTermTranslation(string Term, bool fixForRtl)
	{
		return GetTermTranslation(Term, fixForRtl, 0);
	}

	public static string GetTermTranslation(string Term, bool fixForRtl, int maxLineLengthForRtl)
	{
		if (TryGetTermTranslation(Term, out var translation, fixForRtl, maxLineLengthForRtl))
		{
			return translation;
		}
		return string.Empty;
	}

	public static bool TryGetTermTranslation(string Term, out string translation)
	{
		return TryGetTermTranslation(Term, out translation, fixForRtl: false, 0);
	}

	public static bool TryGetTermTranslation(string Term, out string translation, bool fixForRtl)
	{
		return TryGetTermTranslation(Term, out translation, fixForRtl, 0);
	}

	public static bool TryGetTermTranslation(string Term, out string translation, bool fixForRtl, int maxLineLengthForRtl)
	{
		translation = string.Empty;
		if (string.IsNullOrEmpty(Term))
		{
			return false;
		}
		InitializeIfNeeded();
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			if (Sources[i].TryGetTermTranslation(Term, out translation))
			{
				if (IsRight2Left && fixForRtl)
				{
					translation = ApplyRTLfix(translation, maxLineLengthForRtl);
				}
				return true;
			}
		}
		return false;
	}

	public static string ApplyRTLfix(string line)
	{
		return ApplyRTLfix(line, 0);
	}

	public static string ApplyRTLfix(string line, int maxCharacters)
	{
		if (maxCharacters <= 0)
		{
			return ArabicFixer.Fix(line);
		}
		line = new Regex(".{0," + maxCharacters + "}(\\s+|$)", RegexOptions.Multiline).Replace(line, "$0\n");
		if (line.EndsWith("\n\n"))
		{
			line = line.Substring(0, line.Length - 2);
		}
		string[] array = line.Split('\n');
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			array[i] = ArabicFixer.Fix(array[i]);
		}
		line = string.Join("\n", array);
		return line;
	}

	public static string FixRTL_IfNeeded(string text, int maxCharacters = 0)
	{
		if (IsRight2Left)
		{
			return ApplyRTLfix(text, maxCharacters);
		}
		return text;
	}

	internal static void LocalizeAll(bool Force = false)
	{
		Localize[] array = (Localize[])Resources.FindObjectsOfTypeAll(typeof(Localize));
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			array[i].OnLocalize(Force);
		}
		if (LocalizationManager.OnLocalizeEvent != null)
		{
			LocalizationManager.OnLocalizeEvent();
		}
		ResourceManager.pInstance.CleanResourceCache();
	}

	public static bool UpdateSources()
	{
		UnregisterDeletededSources();
		RegisterSourceInResources();
		RegisterSceneSources();
		return Sources.Count > 0;
	}

	private static void UnregisterDeletededSources()
	{
		for (int num = Sources.Count - 1; num >= 0; num--)
		{
			if (Sources[num] == null)
			{
				RemoveSource(Sources[num]);
			}
		}
	}

	private static void RegisterSceneSources()
	{
		LanguageSource[] array = (LanguageSource[])Resources.FindObjectsOfTypeAll(typeof(LanguageSource));
		int i = 0;
		for (int num = array.Length; i < num; i++)
		{
			if (!Sources.Contains(array[i]))
			{
				AddSource(array[i]);
			}
		}
	}

	private static void RegisterSourceInResources()
	{
		string[] globalSources = GlobalSources;
		foreach (string name in globalSources)
		{
			GameObject asset = ResourceManager.pInstance.GetAsset<GameObject>(name);
			LanguageSource languageSource = (asset ? asset.GetComponent<LanguageSource>() : null);
			if ((bool)languageSource && !Sources.Contains(languageSource))
			{
				AddSource(languageSource);
			}
		}
	}

	internal static void AddSource(LanguageSource Source)
	{
		if (!Sources.Contains(Source))
		{
			Sources.Add(Source);
			Source.Import_Google_FromCache();
			if (Source.GoogleUpdateDelay > 0f)
			{
				Source.Invoke("Delayed_Import_Google", Source.GoogleUpdateDelay);
			}
			else
			{
				Source.Import_Google();
			}
			if (Source.mDictionary.Count == 0)
			{
				Source.UpdateDictionary(force: true);
			}
		}
	}

	internal static void RemoveSource(LanguageSource Source)
	{
		Sources.Remove(Source);
	}

	public static bool IsGlobalSource(string SourceName)
	{
		return Array.IndexOf(GlobalSources, SourceName) >= 0;
	}

	public static bool HasLanguage(string Language, bool allowDiscartingRegion = true, bool initialize = true)
	{
		if (initialize)
		{
			InitializeIfNeeded();
		}
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			if (Sources[i].GetLanguageIndex(Language, AllowDiscartingRegion: false) >= 0)
			{
				return true;
			}
		}
		if (allowDiscartingRegion)
		{
			int j = 0;
			for (int count2 = Sources.Count; j < count2; j++)
			{
				if (Sources[j].GetLanguageIndex(Language) >= 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public static string GetSupportedLanguage(string Language)
	{
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			int languageIndex = Sources[i].GetLanguageIndex(Language, AllowDiscartingRegion: false);
			if (languageIndex >= 0)
			{
				return Sources[i].mLanguages[languageIndex].Name;
			}
		}
		int j = 0;
		for (int count2 = Sources.Count; j < count2; j++)
		{
			int languageIndex2 = Sources[j].GetLanguageIndex(Language);
			if (languageIndex2 >= 0)
			{
				return Sources[j].mLanguages[languageIndex2].Name;
			}
		}
		return string.Empty;
	}

	public static string GetLanguageCode(string Language)
	{
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			int languageIndex = Sources[i].GetLanguageIndex(Language);
			if (languageIndex >= 0)
			{
				return Sources[i].mLanguages[languageIndex].Code;
			}
		}
		return string.Empty;
	}

	public static string GetLanguageFromCode(string Code)
	{
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			int languageIndexFromCode = Sources[i].GetLanguageIndexFromCode(Code);
			if (languageIndexFromCode >= 0)
			{
				return Sources[i].mLanguages[languageIndexFromCode].Name;
			}
		}
		return string.Empty;
	}

	public static List<string> GetAllLanguages()
	{
		List<string> list = new List<string>();
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			int j = 0;
			for (int count2 = Sources[i].mLanguages.Count; j < count2; j++)
			{
				if (!list.Contains(Sources[i].mLanguages[j].Name))
				{
					list.Add(Sources[i].mLanguages[j].Name);
				}
			}
		}
		return list;
	}

	public static List<string> GetCategories()
	{
		List<string> list = new List<string>();
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			Sources[i].GetCategories(OnlyMainCategory: false, list);
		}
		return list;
	}

	public static List<string> GetTermsList()
	{
		if (Sources.Count == 0)
		{
			UpdateSources();
		}
		if (Sources.Count == 1)
		{
			return Sources[0].GetTermsList();
		}
		HashSet<string> hashSet = new HashSet<string>();
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			hashSet.UnionWith(Sources[i].GetTermsList());
		}
		return new List<string>(hashSet);
	}

	public static TermData GetTermData(string term)
	{
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			TermData termData = Sources[i].GetTermData(term);
			if (termData != null)
			{
				return termData;
			}
		}
		return null;
	}

	public static LanguageSource GetSourceContaining(string term, bool fallbackToFirst = true)
	{
		if (!string.IsNullOrEmpty(term))
		{
			int i = 0;
			for (int count = Sources.Count; i < count; i++)
			{
				if (Sources[i].GetTermData(term) != null)
				{
					return Sources[i];
				}
			}
		}
		if (!fallbackToFirst || Sources.Count <= 0)
		{
			return null;
		}
		return Sources[0];
	}

	public static UnityEngine.Object FindAsset(string value)
	{
		int i = 0;
		for (int count = Sources.Count; i < count; i++)
		{
			UnityEngine.Object @object = Sources[i].FindAsset(value);
			if ((bool)@object)
			{
				return @object;
			}
		}
		return null;
	}

	public static string GetVersion()
	{
		return "2.6.6 b1";
	}

	public static int GetRequiredWebServiceVersion()
	{
		return 4;
	}

	private static bool IsRTL(string code)
	{
		return Array.IndexOf(LanguagesRTL, code) >= 0;
	}
}
