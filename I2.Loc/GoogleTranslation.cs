using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using CommonUtils;
using UnityEngine;

namespace I2.Loc;

public static class GoogleTranslation
{
	public static bool CanTranslate()
	{
		if (LocalizationManager.Sources.Count > 0)
		{
			return !string.IsNullOrEmpty(LocalizationManager.Sources[0].Google_WebServiceURL);
		}
		return false;
	}

	public static void Translate(string text, string LanguageCodeFrom, string languageCodeTo, Action<string> onTranslationReady)
	{
		WWW translationWWW = GetTranslationWWW(text, LanguageCodeFrom, languageCodeTo);
		CoroutineManager.pInstance.StartCoroutine(WaitForTranslation(translationWWW, onTranslationReady, text));
	}

	private static IEnumerator WaitForTranslation(WWW www, Action<string> OnTranslationReady, string originalText)
	{
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			DebugLogger.LogError(www.error);
			OnTranslationReady(string.Empty);
		}
		else
		{
			string obj = ParseTranslationResult(www.text, originalText);
			OnTranslationReady(obj);
		}
	}

	public static string ForceTranslate(string text, string LanguageCodeFrom, string languageCodeTo)
	{
		WWW translationWWW = GetTranslationWWW(text, LanguageCodeFrom, languageCodeTo);
		while (!translationWWW.isDone)
		{
		}
		if (!string.IsNullOrEmpty(translationWWW.error))
		{
			DebugLogger.LogError("-- " + translationWWW.error);
			foreach (KeyValuePair<string, string> responseHeader in translationWWW.responseHeaders)
			{
				DebugLogger.Log(responseHeader.Value + "=" + responseHeader.Key);
			}
			return string.Empty;
		}
		return ParseTranslationResult(translationWWW.text, text);
	}

	public static WWW GetTranslationWWW(string text, string languageCodeFrom, string languageCodeTo)
	{
		languageCodeFrom = GoogleLanguages.GetGoogleLanguageCode(languageCodeFrom);
		languageCodeTo = GoogleLanguages.GetGoogleLanguageCode(languageCodeTo);
		if (TitleCase(text) == text)
		{
			text = text.ToLower();
		}
		return new WWW($"{LocalizationManager.Sources[0].Google_WebServiceURL}?action=Translate&list={languageCodeFrom}:{languageCodeTo}={Uri.EscapeUriString(text)}");
	}

	public static string ParseTranslationResult(string html, string OriginalText)
	{
		try
		{
			string text = html;
			if (TitleCase(OriginalText) == OriginalText)
			{
				text = TitleCase(text);
			}
			return text;
		}
		catch (Exception ex)
		{
			DebugLogger.LogError(ex.Message);
			return string.Empty;
		}
	}

	public static void Translate(List<TranslationRequest> requests, Action<List<TranslationRequest>> OnTranslationReady)
	{
		WWW translationWWW = GetTranslationWWW(requests);
		CoroutineManager.pInstance.StartCoroutine(WaitForTranslation(translationWWW, OnTranslationReady, requests));
	}

	public static WWW GetTranslationWWW(List<TranslationRequest> requests)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(LocalizationManager.Sources[0].Google_WebServiceURL);
		stringBuilder.Append("?action=Translate&list=");
		bool flag = true;
		foreach (TranslationRequest request in requests)
		{
			if (!flag)
			{
				stringBuilder.Append("<I2Loc>");
			}
			stringBuilder.Append(request.LanguageCode);
			stringBuilder.Append(":");
			for (int i = 0; i < request.TargetLanguagesCode.Length; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append(",");
				}
				stringBuilder.Append(request.TargetLanguagesCode[i]);
			}
			stringBuilder.Append("=");
			string stringToEscape = ((TitleCase(request.Text) == request.Text) ? request.Text.ToLowerInvariant() : request.Text);
			stringBuilder.Append(Uri.EscapeUriString(stringToEscape));
			flag = false;
		}
		string text = stringBuilder.ToString();
		DebugLogger.Log(text);
		return new WWW(text);
	}

	private static IEnumerator WaitForTranslation(WWW www, Action<List<TranslationRequest>> OnTranslationReady, List<TranslationRequest> requests)
	{
		yield return www;
		if (!string.IsNullOrEmpty(www.error))
		{
			DebugLogger.LogError(www.error);
			OnTranslationReady(requests);
		}
		else
		{
			ParseTranslationResult(www.text, requests);
			OnTranslationReady(requests);
		}
	}

	public static string ParseTranslationResult(string html, List<TranslationRequest> requests)
	{
		DebugLogger.Log(html);
		if (html.StartsWith("<!DOCTYPE html>") || html.StartsWith("<HTML>"))
		{
			return "There was a problem contacting the WebService. Please try again later";
		}
		string[] array = html.Split(new string[1] { "<I2Loc>" }, StringSplitOptions.None);
		string[] separator = new string[1] { "<i2>" };
		for (int i = 0; i < Mathf.Min(requests.Count, array.Length); i++)
		{
			TranslationRequest value = requests[i];
			value.Results = array[i].Split(separator, StringSplitOptions.None);
			if (TitleCase(value.Text) == value.Text)
			{
				for (int j = 0; j < value.Results.Length; j++)
				{
					value.Results[j] = TitleCase(value.Results[j]);
				}
			}
			requests[i] = value;
		}
		return "";
	}

	public static string UppercaseFirst(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return string.Empty;
		}
		char[] array = s.ToLower().ToCharArray();
		array[0] = char.ToUpper(array[0]);
		return new string(array);
	}

	public static string TitleCase(string s)
	{
		if (string.IsNullOrEmpty(s))
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder(s);
		stringBuilder[0] = char.ToUpper(stringBuilder[0]);
		int i = 1;
		for (int length = s.Length; i < length; i++)
		{
			if (char.IsWhiteSpace(stringBuilder[i - 1]))
			{
				stringBuilder[i] = char.ToUpper(stringBuilder[i]);
			}
			else
			{
				stringBuilder[i] = char.ToLower(stringBuilder[i]);
			}
		}
		return stringBuilder.ToString();
	}
}
