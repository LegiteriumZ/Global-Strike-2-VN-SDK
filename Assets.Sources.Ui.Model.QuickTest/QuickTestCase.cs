using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.Sources.Modules.Ui;
using Assets.Sources.Modules.Ui.UiEventCondition;
using UnityEngine;

namespace Assets.Sources.Ui.Model.QuickTest;

public class QuickTestCase
{
	public static List<QuickTestCase> TestList = new List<QuickTestCase>();

	public static List<QuickTestCase> IgnoreList = new List<QuickTestCase>();

	public List<QuickTestAction> Actions = new List<QuickTestAction>();

	protected int Priority = 100;

	public static int ErrorCount;

	public static List<string> AssertList = new List<string>();

	public QuickTestCase(Contexts contexts)
	{
	}

	public void AddAction(int delay, Action action, Func<bool> condition = null)
	{
		QuickTestAction quickTestAction = new QuickTestAction(delay, action, condition, Priority);
		for (int num = Actions.Count - 1; num >= 0; num--)
		{
			if (Actions[num].Priority >= quickTestAction.Priority)
			{
				Actions.Add(quickTestAction);
				return;
			}
		}
		Actions.Add(quickTestAction);
	}

	public PlayerEntity GetEnemyEntity()
	{
		foreach (PlayerEntity item in Contexts.sharedInstance.player)
		{
			if (item.GetId() != UiIEventCondition.Get_cameraOwnerData_PlayerId() && item.GetTeam() != UiIEventCondition.Get_cameraOwnerData_Team())
			{
				return item;
			}
		}
		return null;
	}

	public T GetModel<T>() where T : class
	{
		if (UiModeDelegate.Instance != null)
		{
			return UiModeDelegate.Instance.UiMode.GetModel<T>() as T;
		}
		return null;
	}

	public PT GetProperty<T, PT>(string name) where T : class
	{
		T model = GetModel<T>();
		if (model != null)
		{
			PropertyInfo property = model.GetType().GetProperty("ViewModel", BindingFlags.Instance | BindingFlags.NonPublic);
			if (property != null)
			{
				return (PT)property.GetValue(model, new object[0]);
			}
		}
		return default(PT);
	}

	public FT GetField<T, FT>(string name) where T : class
	{
		T model = GetModel<T>();
		if (model != null)
		{
			FieldInfo field = model.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				return (FT)field.GetValue(model);
			}
		}
		return default(FT);
	}

	public MethodInfo GetMethod<T>(string name) where T : class
	{
		return GetModel<T>()?.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
	}

	public static void Assert(bool condition, string message)
	{
		if (condition)
		{
			string text = $"Succeed : {message}";
			Debug.Log(text);
			AssertList.Add(text);
		}
		else
		{
			string text2 = $"Failed : {message}";
			Debug.LogError(text2);
			ErrorCount++;
			AssertList.Add(text2);
		}
	}

	public static void Assert(bool condition, string message, int checkNum, ref bool result)
	{
		if (condition)
		{
			string text = $"Succeed : {message}";
			Debug.Log(text);
			AssertList.Add(text);
			return;
		}
		result = false;
		if (checkNum <= 0)
		{
			string text2 = $"Failed : {message}";
			Debug.LogError(text2);
			ErrorCount++;
			AssertList.Add(text2);
		}
		else
		{
			string text3 = $"Tried : {message}";
			Debug.Log(text3);
			AssertList.Add(text3);
		}
	}
}
