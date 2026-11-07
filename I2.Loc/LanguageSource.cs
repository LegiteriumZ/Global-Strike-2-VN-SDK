using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonUtils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace I2.Loc;

[AddComponentMenu("I2/Localization/Source")]
public class LanguageSource : MonoBehaviour
{
	public enum eGoogleUpdateFrequency
	{
		Always,
		Never,
		Daily,
		Weekly,
		Monthly
	}

	public enum eInputSpecialization
	{
		PC,
		Touch,
		Controller
	}

	public string Google_WebServiceURL;

	public string Google_SpreadsheetKey;

	public string Google_SpreadsheetName;

	public string Google_LastUpdatedVersion;

	public eGoogleUpdateFrequency GoogleUpdateFrequency = eGoogleUpdateFrequency.Weekly;

	public float GoogleUpdateDelay = 5f;

	public static string EmptyCategory = "Default";

	public static char[] CategorySeparators = "/\\".ToCharArray();

	public List<TermData> mTerms = new List<TermData>();

	public List<LanguageData> mLanguages = new List<LanguageData>();

	public bool CaseInsensitiveTerms;

	[NonSerialized]
	public Dictionary<string, TermData> mDictionary = new Dictionary<string, TermData>(StringComparer.Ordinal);

	public UnityEngine.Object[] Assets;

	public bool NeverDestroy = true;

	public bool UserAgreesToHaveItOnTheScene;

	public bool UserAgreesToHaveItInsideThePluginsFolder;

	public event Action<LanguageSource> Event_OnSourceUpdateFromGoogle;

	public string Export_I2CSV(string Category, char separator = ',')
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("Key[*]Type[*]Desc");
		foreach (LanguageData mLanguage in mLanguages)
		{
			stringBuilder.Append("[*]");
			stringBuilder.Append(GoogleLanguages.GetCodedLanguage(mLanguage.Name, mLanguage.Code));
		}
		stringBuilder.Append("[ln]");
		int count = mLanguages.Count;
		foreach (TermData mTerm in mTerms)
		{
			string term;
			if (string.IsNullOrEmpty(Category) || (Category == EmptyCategory && mTerm.Term.IndexOfAny(CategorySeparators) < 0))
			{
				term = mTerm.Term;
			}
			else
			{
				if (!mTerm.Term.StartsWith(Category + "/") || !(Category != mTerm.Term))
				{
					continue;
				}
				term = mTerm.Term.Substring(Category.Length + 1);
			}
			AppendI2Term(stringBuilder, count, term, mTerm, string.Empty, mTerm.Languages, mTerm.Languages_Touch, separator, 1, 2);
			if (mTerm.HasTouchTranslations())
			{
				AppendI2Term(stringBuilder, count, term, mTerm, "[touch]", mTerm.Languages_Touch, null, separator, 2, 1);
			}
		}
		return stringBuilder.ToString();
	}

	private static void AppendI2Term(StringBuilder Builder, int nLanguages, string term, TermData termData, string postfix, string[] aLanguages, string[] aSecLanguages, char separator, byte flagBitMask, byte secFlagBitMask)
	{
		Builder.Append(term);
		Builder.Append(postfix);
		Builder.Append("[*]");
		Builder.Append(termData.TermType);
		Builder.Append("[*]");
		Builder.Append(termData.Description);
		for (int i = 0; i < Mathf.Min(nLanguages, aLanguages.Length); i++)
		{
			Builder.Append("[*]");
			string value = aLanguages[i];
			bool flag = (termData.Flags[i] & flagBitMask) > 0;
			if (string.IsNullOrEmpty(value) && aSecLanguages != null)
			{
				value = aSecLanguages[i];
				flag = (termData.Flags[i] & secFlagBitMask) > 0;
			}
			if (flag)
			{
				Builder.Append("[i2auto]");
			}
			Builder.Append(value);
		}
		Builder.Append("[ln]");
	}

	public string Export_CSV(string Category, char separator = ',')
	{
		StringBuilder stringBuilder = new StringBuilder();
		int count = mLanguages.Count;
		stringBuilder.AppendFormat("Key{0}Type{0}Desc", separator);
		foreach (LanguageData mLanguage in mLanguages)
		{
			stringBuilder.Append(separator);
			AppendString(stringBuilder, GoogleLanguages.GetCodedLanguage(mLanguage.Name, mLanguage.Code), separator);
		}
		stringBuilder.Append("\n");
		mTerms = mTerms.OrderBy((TermData x) => x.Term).ToList();
		foreach (TermData mTerm in mTerms)
		{
			string term;
			if (string.IsNullOrEmpty(Category) || (Category == EmptyCategory && mTerm.Term.IndexOfAny(CategorySeparators) < 0))
			{
				term = mTerm.Term;
			}
			else
			{
				if (!mTerm.Term.StartsWith(Category + "/") || !(Category != mTerm.Term))
				{
					continue;
				}
				term = mTerm.Term.Substring(Category.Length + 1);
			}
			AppendTerm(stringBuilder, count, term, mTerm, null, mTerm.Languages, mTerm.Languages_Touch, separator, 1, 2);
			if (mTerm.HasTouchTranslations())
			{
				AppendTerm(stringBuilder, count, term, mTerm, "[touch]", mTerm.Languages_Touch, null, separator, 2, 1);
			}
		}
		return stringBuilder.ToString();
	}

	private static void AppendTerm(StringBuilder Builder, int nLanguages, string term, TermData termData, string prefix, string[] aLanguages, string[] aSecLanguages, char separator, byte flagBitMask, byte secFlagBitMask)
	{
		AppendString(Builder, term, separator);
		if (!string.IsNullOrEmpty(prefix))
		{
			Builder.Append(prefix);
		}
		Builder.Append(separator);
		Builder.Append(termData.TermType);
		Builder.Append(separator);
		AppendString(Builder, termData.Description, separator);
		for (int i = 0; i < Mathf.Min(nLanguages, aLanguages.Length); i++)
		{
			Builder.Append(separator);
			string text = aLanguages[i];
			bool flag = (termData.Flags[i] & flagBitMask) > 0;
			if (string.IsNullOrEmpty(text) && aSecLanguages != null)
			{
				text = aSecLanguages[i];
				flag = (termData.Flags[i] & secFlagBitMask) > 0;
			}
			if (flag)
			{
				Builder.Append("[i2auto]");
			}
			AppendString(Builder, text, separator);
		}
		Builder.Append("\n");
	}

	private static void AppendString(StringBuilder Builder, string text, char separator)
	{
		if (!string.IsNullOrEmpty(text))
		{
			text = text.Replace("\\n", "\n");
			if (text.IndexOfAny((separator + "\n\"").ToCharArray()) >= 0)
			{
				text = text.Replace("\"", "\"\"");
				Builder.AppendFormat("\"{0}\"", text);
			}
			else
			{
				Builder.Append(text);
			}
		}
	}

	public WWW Export_Google_CreateWWWcall(eSpreadsheetUpdateMode UpdateMode = eSpreadsheetUpdateMode.Replace)
	{
		string value = Export_Google_CreateData();
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("key", Google_SpreadsheetKey);
		wWWForm.AddField("action", "SetLanguageSource");
		wWWForm.AddField("data", value);
		wWWForm.AddField("updateMode", UpdateMode.ToString());
		return new WWW(Google_WebServiceURL, wWWForm);
	}

	private string Export_Google_CreateData()
	{
		List<string> categories = GetCategories(OnlyMainCategory: true);
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = true;
		foreach (string item in categories)
		{
			if (flag)
			{
				flag = false;
			}
			else
			{
				stringBuilder.Append("<I2Loc>");
			}
			string value = Export_I2CSV(item);
			stringBuilder.Append(item);
			stringBuilder.Append("<I2Loc>");
			stringBuilder.Append(value);
		}
		return stringBuilder.ToString();
	}

	public string Import_CSV(string Category, string csVstring, eSpreadsheetUpdateMode updateMode = eSpreadsheetUpdateMode.Replace, char separator = ',')
	{
		List<string[]> csv = LocalizationReader.ReadCSV(csVstring, separator);
		return Import_CSV(Category, csv, updateMode);
	}

	public string Import_I2CSV(string Category, string i2CsVstring, eSpreadsheetUpdateMode updateMode = eSpreadsheetUpdateMode.Replace)
	{
		List<string[]> csv = LocalizationReader.ReadI2CSV(i2CsVstring);
		return Import_CSV(Category, csv, updateMode);
	}

	public string Import_CSV(string Category, List<string[]> csv, eSpreadsheetUpdateMode updateMode = eSpreadsheetUpdateMode.Replace)
	{
		string[] array = csv[0];
		int num = 1;
		int num2 = -1;
		int num3 = -1;
		string[] texts = new string[1] { "Key" };
		string[] texts2 = new string[1] { "Type" };
		string[] texts3 = new string[2] { "Desc", "Description" };
		if (array.Length > 1 && ArrayContains(array[0], texts))
		{
			if (updateMode == eSpreadsheetUpdateMode.Replace)
			{
				ClearAllData();
			}
			if (array.Length > 2)
			{
				if (ArrayContains(array[1], texts2))
				{
					num2 = 1;
					num = 2;
				}
				if (ArrayContains(array[1], texts3))
				{
					num3 = 1;
					num = 2;
				}
			}
			if (array.Length > 3)
			{
				if (ArrayContains(array[2], texts2))
				{
					num2 = 2;
					num = 3;
				}
				if (ArrayContains(array[2], texts3))
				{
					num3 = 2;
					num = 3;
				}
			}
			int num4 = Mathf.Max(array.Length - num, 0);
			int[] array2 = new int[num4];
			for (int i = 0; i < num4; i++)
			{
				if (string.IsNullOrEmpty(array[i + num]))
				{
					array2[i] = -1;
					continue;
				}
				GoogleLanguages.UnPackCodeFromLanguageName(array[i + num], out var language, out var code);
				int num5 = -1;
				num5 = (string.IsNullOrEmpty(code) ? GetLanguageIndex(language) : GetLanguageIndexFromCode(code));
				if (num5 < 0)
				{
					LanguageData languageData = new LanguageData();
					languageData.Name = language;
					languageData.Code = code;
					mLanguages.Add(languageData);
					num5 = mLanguages.Count - 1;
				}
				array2[i] = num5;
			}
			num4 = mLanguages.Count;
			int j = 0;
			for (int count = mTerms.Count; j < count; j++)
			{
				TermData termData = mTerms[j];
				if (termData.Languages.Length < num4)
				{
					Array.Resize(ref termData.Languages, num4);
					Array.Resize(ref termData.Languages_Touch, num4);
					Array.Resize(ref termData.Flags, num4);
				}
			}
			int k = 1;
			for (int count2 = csv.Count; k < count2; k++)
			{
				array = csv[k];
				string Term = (string.IsNullOrEmpty(Category) ? array[0] : (Category + "/" + array[0]));
				bool flag = false;
				if (Term.EndsWith("[touch]"))
				{
					Term = Term.Remove(Term.Length - "[touch]".Length);
					flag = true;
				}
				ValidateFullTerm(ref Term);
				if (string.IsNullOrEmpty(Term))
				{
					continue;
				}
				TermData termData2 = GetTermData(Term);
				if (termData2 == null)
				{
					termData2 = new TermData();
					termData2.Term = Term;
					termData2.Languages = new string[mLanguages.Count];
					termData2.Languages_Touch = new string[mLanguages.Count];
					termData2.Flags = new byte[mLanguages.Count];
					for (int l = 0; l < mLanguages.Count; l++)
					{
						termData2.Languages[l] = (termData2.Languages_Touch[l] = string.Empty);
					}
					mTerms.Add(termData2);
					mDictionary.Add(Term, termData2);
				}
				else if (updateMode == eSpreadsheetUpdateMode.AddNewTerms)
				{
					continue;
				}
				if (num2 > 0)
				{
					termData2.TermType = GetTermType(array[num2]);
				}
				if (num3 > 0)
				{
					termData2.Description = array[num3];
				}
				for (int m = 0; m < array2.Length && m < array.Length - num; m++)
				{
					if (string.IsNullOrEmpty(array[m + num]))
					{
						continue;
					}
					int num6 = array2[m];
					if (num6 < 0)
					{
						continue;
					}
					string text = array[m + num];
					bool flag2 = text.StartsWith("[i2auto]");
					if (flag2)
					{
						text = text.Substring("[isauto]".Length);
						if (text.StartsWith("\"") && text.EndsWith("\""))
						{
							text = text.Substring(1, text.Length - 2);
						}
					}
					if (flag)
					{
						termData2.Languages_Touch[num6] = text;
						if (flag2)
						{
							termData2.Flags[num6] |= 2;
						}
						else
						{
							termData2.Flags[num6] &= 253;
						}
					}
					else
					{
						termData2.Languages[num6] = text;
						if (flag2)
						{
							termData2.Flags[num6] |= 1;
						}
						else
						{
							termData2.Flags[num6] &= 254;
						}
					}
				}
			}
			return string.Empty;
		}
		return "Bad Spreadsheet Format.\nFirst columns should be 'Key', 'Type' and 'Desc'";
	}

	private bool ArrayContains(string MainText, params string[] texts)
	{
		int i = 0;
		for (int num = texts.Length; i < num; i++)
		{
			if (MainText.IndexOf(texts[i], StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return true;
			}
		}
		return false;
	}

	public static eTermType GetTermType(string type)
	{
		int i = 0;
		for (int num = 7; i <= num; i++)
		{
			eTermType eTermType2 = (eTermType)i;
			if (string.Equals(eTermType2.ToString(), type, StringComparison.OrdinalIgnoreCase))
			{
				return (eTermType)i;
			}
		}
		return eTermType.Text;
	}

	public void Delayed_Import_Google()
	{
		Import_Google();
	}

	public void Import_Google_FromCache()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		string sourcePlayerPrefName = GetSourcePlayerPrefName();
		string @string = PlayerPrefs.GetString("I2Source_" + sourcePlayerPrefName, null);
		if (!string.IsNullOrEmpty(@string))
		{
			bool flag = false;
			string text = Google_LastUpdatedVersion;
			if (PlayerPrefs.HasKey("I2SourceVersion_" + sourcePlayerPrefName))
			{
				text = PlayerPrefs.GetString("I2SourceVersion_" + sourcePlayerPrefName, Google_LastUpdatedVersion);
				flag = text.CompareTo(Google_LastUpdatedVersion) > 0;
			}
			if (!flag)
			{
				PlayerPrefs.DeleteKey("I2Source_" + sourcePlayerPrefName);
				PlayerPrefs.DeleteKey("I2SourceVersion_" + sourcePlayerPrefName);
			}
			else
			{
				Google_LastUpdatedVersion = text;
				DebugLogger.Log("[I2Loc] Using Saved (PlayerPref) data in 'I2Source_" + sourcePlayerPrefName + "'");
				Import_Google_Result(@string, eSpreadsheetUpdateMode.Replace);
			}
		}
	}

	public void Import_Google(bool ForceUpdate = false)
	{
		if (GoogleUpdateFrequency == eGoogleUpdateFrequency.Never)
		{
			return;
		}
		string sourcePlayerPrefName = GetSourcePlayerPrefName();
		if (!ForceUpdate && GoogleUpdateFrequency != 0 && DateTime.TryParse(PlayerPrefs.GetString("LastGoogleUpdate_" + sourcePlayerPrefName, ""), out var result))
		{
			double totalDays = (DateTime.Now - result).TotalDays;
			switch (GoogleUpdateFrequency)
			{
			case eGoogleUpdateFrequency.Daily:
				if (totalDays < 1.0)
				{
					return;
				}
				break;
			case eGoogleUpdateFrequency.Weekly:
				if (totalDays < 8.0)
				{
					return;
				}
				break;
			case eGoogleUpdateFrequency.Monthly:
				if (totalDays < 31.0)
				{
					return;
				}
				break;
			}
		}
		PlayerPrefs.SetString("LastGoogleUpdate_" + sourcePlayerPrefName, DateTime.Now.ToString());
		CoroutineManager.pInstance.StartCoroutine(Import_Google_Coroutine());
	}

	private string GetSourcePlayerPrefName()
	{
		if (Array.IndexOf(LocalizationManager.GlobalSources, base.name) >= 0)
		{
			return base.name;
		}
		return SceneManager.GetActiveScene().name + "_" + base.name;
	}

	private IEnumerator Import_Google_Coroutine()
	{
		WWW www = Import_Google_CreateWWWcall();
		if (www == null)
		{
			yield break;
		}
		while (!www.isDone)
		{
			yield return null;
		}
		if (string.IsNullOrEmpty(www.error) && www.text != "\"\"")
		{
			if (string.IsNullOrEmpty(Import_Google_Result(www.text, eSpreadsheetUpdateMode.Replace, saveInPlayerPrefs: true)))
			{
				if (this.Event_OnSourceUpdateFromGoogle != null)
				{
					this.Event_OnSourceUpdateFromGoogle(this);
				}
				LocalizationManager.LocalizeAll();
				DebugLogger.Log("Done Google Sync");
			}
			else
			{
				DebugLogger.Log("Done Google Sync: source was up-to-date");
			}
		}
		else
		{
			DebugLogger.Log("Language Source was up-to-date with Google Spreadsheet");
		}
	}

	public WWW Import_Google_CreateWWWcall(bool ForceUpdate = false)
	{
		if (!HasGoogleSpreadsheet())
		{
			return null;
		}
		string @string = PlayerPrefs.GetString("I2SourceVersion_" + GetSourcePlayerPrefName(), Google_LastUpdatedVersion);
		if (@string.CompareTo(Google_LastUpdatedVersion) > 0)
		{
			Google_LastUpdatedVersion = @string;
		}
		return new WWW(string.Format("{0}?key={1}&action=GetLanguageSource&version={2}", Google_WebServiceURL, Google_SpreadsheetKey, ForceUpdate ? "0" : Google_LastUpdatedVersion));
	}

	public bool HasGoogleSpreadsheet()
	{
		if (!string.IsNullOrEmpty(Google_WebServiceURL))
		{
			return !string.IsNullOrEmpty(Google_SpreadsheetKey);
		}
		return false;
	}

	public string Import_Google_Result(string JsonString, eSpreadsheetUpdateMode updateMode, bool saveInPlayerPrefs = false)
	{
		string empty = string.Empty;
		if (string.IsNullOrEmpty(JsonString) || JsonString == "\"\"")
		{
			return empty;
		}
		int num = JsonString.IndexOf("version=");
		int num2 = JsonString.IndexOf("script_version=");
		if (num < 0 || num2 < 0)
		{
			return "Invalid Response from Google, Most likely the WebService needs to be updated";
		}
		num += "version=".Length;
		num2 += "script_version=".Length;
		string text = JsonString.Substring(num, JsonString.IndexOf(",", num) - num);
		if (int.Parse(JsonString.Substring(num2, JsonString.IndexOf(",", num2) - num2)) != LocalizationManager.GetRequiredWebServiceVersion())
		{
			return "The current Google WebService is not supported.\nPlease, delete the WebService from the Google Drive and Install the latest version.";
		}
		if (!saveInPlayerPrefs && text.CompareTo(Google_LastUpdatedVersion) <= 0)
		{
			return "LanguageSource is up-to-date";
		}
		if (saveInPlayerPrefs)
		{
			string sourcePlayerPrefName = GetSourcePlayerPrefName();
			PlayerPrefs.SetString("I2Source_" + sourcePlayerPrefName, JsonString);
			PlayerPrefs.SetString("I2SourceVersion_" + sourcePlayerPrefName, text);
			PlayerPrefs.Save();
		}
		Google_LastUpdatedVersion = text;
		if (updateMode == eSpreadsheetUpdateMode.Replace)
		{
			ClearAllData();
		}
		int num3 = JsonString.IndexOf("[i2category]");
		while (num3 > 0)
		{
			num3 += "[i2category]".Length;
			int num4 = JsonString.IndexOf("[/i2category]", num3);
			string category = JsonString.Substring(num3, num4 - num3);
			num4 += "[/i2category]".Length;
			int num5 = JsonString.IndexOf("[/i2csv]", num4);
			string i2CsVstring = JsonString.Substring(num4, num5 - num4);
			num3 = JsonString.IndexOf("[i2category]", num5);
			Import_I2CSV(category, i2CsVstring, updateMode);
			if (updateMode == eSpreadsheetUpdateMode.Replace)
			{
				updateMode = eSpreadsheetUpdateMode.Merge;
			}
		}
		return empty;
	}

	public List<string> GetCategories(bool OnlyMainCategory = false, List<string> categories = null)
	{
		if (categories == null)
		{
			categories = new List<string>();
		}
		foreach (TermData mTerm in mTerms)
		{
			string categoryFromFullTerm = GetCategoryFromFullTerm(mTerm.Term, OnlyMainCategory);
			if (!categories.Contains(categoryFromFullTerm))
			{
				categories.Add(categoryFromFullTerm);
			}
		}
		categories.Sort();
		return categories;
	}

	public static string GetKeyFromFullTerm(string FullTerm, bool onlyMainCategory = false)
	{
		int num = (onlyMainCategory ? FullTerm.IndexOfAny(CategorySeparators) : FullTerm.LastIndexOfAny(CategorySeparators));
		if (num >= 0)
		{
			return FullTerm.Substring(num + 1);
		}
		return FullTerm;
	}

	public static string GetCategoryFromFullTerm(string FullTerm, bool onlyMainCategory = false)
	{
		int num = (onlyMainCategory ? FullTerm.IndexOfAny(CategorySeparators) : FullTerm.LastIndexOfAny(CategorySeparators));
		if (num >= 0)
		{
			return FullTerm.Substring(0, num);
		}
		return EmptyCategory;
	}

	public static void DeserializeFullTerm(string FullTerm, out string key, out string category, bool onlyMainCategory = false)
	{
		int num = (onlyMainCategory ? FullTerm.IndexOfAny(CategorySeparators) : FullTerm.LastIndexOfAny(CategorySeparators));
		if (num < 0)
		{
			category = EmptyCategory;
			key = FullTerm;
		}
		else
		{
			category = FullTerm.Substring(0, num);
			key = FullTerm.Substring(num + 1);
		}
	}

	public static eInputSpecialization GetCurrentInputType()
	{
		if (Input.GetJoystickNames().Length == 0)
		{
			return eInputSpecialization.PC;
		}
		return eInputSpecialization.Controller;
	}

	private void Awake()
	{
		if (NeverDestroy)
		{
			if (ManagerHasASimilarSource())
			{
				UnityEngine.Object.Destroy(this);
				return;
			}
			if (Application.isPlaying)
			{
				UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			}
		}
		LocalizationManager.AddSource(this);
		UpdateDictionary();
	}

	public void UpdateDictionary(bool force = false)
	{
		if (!force && mDictionary != null && mDictionary.Count == mTerms.Count)
		{
			return;
		}
		StringComparer stringComparer = (CaseInsensitiveTerms ? StringComparer.OrdinalIgnoreCase : StringComparer.Ordinal);
		if (mDictionary.Comparer != stringComparer)
		{
			mDictionary = new Dictionary<string, TermData>(stringComparer);
		}
		else
		{
			mDictionary.Clear();
		}
		int i = 0;
		for (int count = mTerms.Count; i < count; i++)
		{
			ValidateFullTerm(ref mTerms[i].Term);
			if (mTerms[i].Languages_Touch == null || mTerms[i].Languages_Touch.Length != mTerms[i].Languages.Length)
			{
				mTerms[i].Languages_Touch = new string[mTerms[i].Languages.Length];
			}
			mDictionary[mTerms[i].Term] = mTerms[i];
			mTerms[i].Validate();
		}
	}

	public string GetSourceName()
	{
		string text = base.gameObject.name;
		Transform parent = base.transform.parent;
		while ((bool)parent)
		{
			text = parent.name + "_" + text;
			parent = parent.parent;
		}
		return text;
	}

	public int GetLanguageIndex(string language, bool AllowDiscartingRegion = true)
	{
		int i = 0;
		for (int count = mLanguages.Count; i < count; i++)
		{
			if (string.Compare(mLanguages[i].Name, language, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return i;
			}
		}
		if (AllowDiscartingRegion)
		{
			int num = -1;
			int num2 = 0;
			int j = 0;
			for (int count2 = mLanguages.Count; j < count2; j++)
			{
				int commonWordInLanguageNames = GetCommonWordInLanguageNames(mLanguages[j].Name, language);
				if (commonWordInLanguageNames > num2)
				{
					num2 = commonWordInLanguageNames;
					num = j;
				}
			}
			if (num >= 0)
			{
				return num;
			}
		}
		return -1;
	}

	public int GetLanguageIndexFromCode(string Code)
	{
		int i = 0;
		for (int count = mLanguages.Count; i < count; i++)
		{
			if (string.Compare(mLanguages[i].Code, Code, StringComparison.OrdinalIgnoreCase) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public static int GetCommonWordInLanguageNames(string Language1, string language2)
	{
		if (string.IsNullOrEmpty(Language1) || string.IsNullOrEmpty(language2))
		{
			return 0;
		}
		string[] array = (from x in Language1.Split("( )-/\\".ToCharArray())
			where !string.IsNullOrEmpty(x)
			select x).ToArray();
		string[] array2 = (from x in language2.Split("( )-/\\".ToCharArray())
			where !string.IsNullOrEmpty(x)
			select x).ToArray();
		int num = 0;
		string[] array3 = array;
		foreach (string value in array3)
		{
			if (array2.Contains(value))
			{
				num++;
			}
		}
		array3 = array2;
		foreach (string value2 in array3)
		{
			if (array.Contains(value2))
			{
				num++;
			}
		}
		return num;
	}

	public static bool AreTheSameLanguage(string Language1, string language2)
	{
		Language1 = GetLanguageWithoutRegion(Language1);
		language2 = GetLanguageWithoutRegion(language2);
		return string.Compare(Language1, language2, StringComparison.OrdinalIgnoreCase) == 0;
	}

	public static string GetLanguageWithoutRegion(string Language)
	{
		int num = Language.IndexOfAny("(/\\[,{".ToCharArray());
		if (num < 0)
		{
			return Language;
		}
		return Language.Substring(0, num).Trim();
	}

	public void AddLanguage(string LanguageName, string languageCode)
	{
		if (GetLanguageIndex(LanguageName, AllowDiscartingRegion: false) < 0)
		{
			LanguageData languageData = new LanguageData();
			languageData.Name = LanguageName;
			languageData.Code = languageCode;
			mLanguages.Add(languageData);
			int count = mLanguages.Count;
			int i = 0;
			for (int count2 = mTerms.Count; i < count2; i++)
			{
				Array.Resize(ref mTerms[i].Languages, count);
				Array.Resize(ref mTerms[i].Languages_Touch, count);
				Array.Resize(ref mTerms[i].Flags, count);
			}
		}
	}

	public void RemoveLanguage(string LanguageName)
	{
		int languageIndex = GetLanguageIndex(LanguageName);
		if (languageIndex < 0)
		{
			return;
		}
		int count = mLanguages.Count;
		int i = 0;
		for (int count2 = mTerms.Count; i < count2; i++)
		{
			for (int j = languageIndex + 1; j < count; j++)
			{
				mTerms[i].Languages[j - 1] = mTerms[i].Languages[j];
				mTerms[i].Languages_Touch[j - 1] = mTerms[i].Languages_Touch[j];
				mTerms[i].Flags[j - 1] = mTerms[i].Flags[j];
			}
			Array.Resize(ref mTerms[i].Languages, count - 1);
			Array.Resize(ref mTerms[i].Languages_Touch, count - 1);
			Array.Resize(ref mTerms[i].Flags, count - 1);
		}
		mLanguages.RemoveAt(languageIndex);
	}

	public List<string> GetLanguages()
	{
		List<string> list = new List<string>();
		int i = 0;
		for (int count = mLanguages.Count; i < count; i++)
		{
			list.Add(mLanguages[i].Name);
		}
		return list;
	}

	public string GetTermTranslation(string term)
	{
		int languageIndex = GetLanguageIndex(LocalizationManager.CurrentLanguage);
		if (languageIndex < 0)
		{
			return string.Empty;
		}
		TermData termData = GetTermData(term);
		if (termData != null)
		{
			return termData.GetTranslation(languageIndex);
		}
		return string.Empty;
	}

	public bool TryGetTermTranslation(string term, out string Translation)
	{
		int languageIndex = GetLanguageIndex(LocalizationManager.CurrentLanguage);
		if (languageIndex >= 0)
		{
			TermData termData = GetTermData(term);
			if (termData != null)
			{
				Translation = termData.GetTranslation(languageIndex);
				return true;
			}
		}
		Translation = string.Empty;
		return false;
	}

	public TermData AddTerm(string term)
	{
		return AddTerm(term, eTermType.Text);
	}

	public TermData GetTermData(string term, bool allowCategoryMistmatch = false)
	{
		if (string.IsNullOrEmpty(term))
		{
			return null;
		}
		if (mDictionary.Count == 0)
		{
			UpdateDictionary();
		}
		if (mDictionary.TryGetValue(term, out var value))
		{
			return value;
		}
		TermData termData = null;
		if (allowCategoryMistmatch)
		{
			string keyFromFullTerm = GetKeyFromFullTerm(term);
			foreach (KeyValuePair<string, TermData> item in mDictionary)
			{
				if (item.Value.IsTerm(keyFromFullTerm, allowCategoryMistmatch: true))
				{
					if (termData != null)
					{
						return null;
					}
					termData = item.Value;
				}
			}
		}
		return termData;
	}

	public bool ContainsTerm(string term)
	{
		return GetTermData(term) != null;
	}

	public List<string> GetTermsList()
	{
		if (mDictionary.Count != mTerms.Count)
		{
			UpdateDictionary();
		}
		return new List<string>(mDictionary.Keys);
	}

	public TermData AddTerm(string NewTerm, eTermType termType, bool saveSource = true)
	{
		ValidateFullTerm(ref NewTerm);
		NewTerm = NewTerm.Trim();
		if (mLanguages.Count == 0)
		{
			AddLanguage("English", "en");
		}
		TermData termData = GetTermData(NewTerm);
		if (termData == null)
		{
			termData = new TermData();
			termData.Term = NewTerm;
			termData.TermType = termType;
			termData.Languages = new string[mLanguages.Count];
			termData.Languages_Touch = new string[mLanguages.Count];
			termData.Flags = new byte[mLanguages.Count];
			mTerms.Add(termData);
			mDictionary.Add(NewTerm, termData);
		}
		return termData;
	}

	public void RemoveTerm(string term)
	{
		int i = 0;
		for (int count = mTerms.Count; i < count; i++)
		{
			if (mTerms[i].Term == term)
			{
				mTerms.RemoveAt(i);
				mDictionary.Remove(term);
				break;
			}
		}
	}

	public static void ValidateFullTerm(ref string Term)
	{
		Term = Term.Replace('\\', '/');
		Term = Term.Trim();
		if (Term.StartsWith(EmptyCategory) && Term.Length > EmptyCategory.Length && Term[EmptyCategory.Length] == '/')
		{
			Term = Term.Substring(EmptyCategory.Length + 1);
		}
	}

	public bool IsEqualTo(LanguageSource Source)
	{
		if (Source.mLanguages.Count != mLanguages.Count)
		{
			return false;
		}
		int i = 0;
		for (int count = mLanguages.Count; i < count; i++)
		{
			if (Source.GetLanguageIndex(mLanguages[i].Name) < 0)
			{
				return false;
			}
		}
		if (Source.mTerms.Count != mTerms.Count)
		{
			return false;
		}
		for (int j = 0; j < mTerms.Count; j++)
		{
			if (Source.GetTermData(mTerms[j].Term) == null)
			{
				return false;
			}
		}
		return true;
	}

	internal bool ManagerHasASimilarSource()
	{
		int i = 0;
		for (int count = LocalizationManager.Sources.Count; i < count; i++)
		{
			LanguageSource languageSource = LocalizationManager.Sources[i];
			if (languageSource != null && languageSource.IsEqualTo(this) && languageSource != this)
			{
				return true;
			}
		}
		return false;
	}

	public void ClearAllData()
	{
		mTerms.Clear();
		mLanguages.Clear();
		mDictionary.Clear();
	}

	public UnityEngine.Object FindAsset(string Name)
	{
		if (Assets != null)
		{
			int i = 0;
			for (int num = Assets.Length; i < num; i++)
			{
				if (Assets[i] != null && Assets[i].name == Name)
				{
					return Assets[i];
				}
			}
		}
		return null;
	}

	public bool HasAsset(UnityEngine.Object Obj)
	{
		return Array.IndexOf(Assets, Obj) >= 0;
	}

	public void AddAsset(UnityEngine.Object Obj)
	{
		Array.Resize(ref Assets, Assets.Length + 1);
		Assets[Assets.Length - 1] = Obj;
	}
}
