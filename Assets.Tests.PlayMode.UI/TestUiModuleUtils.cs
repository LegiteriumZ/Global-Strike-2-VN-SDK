using System;
using System.Collections;
using System.Reflection;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.Mode;
using Assets.UiFramework.Libs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Tests.PlayMode.UI;

public static class TestUiModuleUtils
{
	internal static Text _text;

	public static IEnumerator InitUiTest<T>(Func<bool> initCheck) where T : AbstractModel, IPlaybackSystem, new()
	{
		yield return Init<TestUiModule>(initCheck);
		Contexts sharedInstance = Contexts.sharedInstance;
		GameObject.Find("GameController").GetComponent<TestGameController>().CreateFpsSystems(sharedInstance, new TestUiModeModule<TestUiMode<T>>(sharedInstance));
		yield return ViewModelInited(typeof(TestUiMode<T>));
	}

	public static IEnumerator ViewModelInited(Type modeType)
	{
		if (modeType.GetField("CurrModel") != null)
		{
			while (modeType.GetField("CurrModel").GetValue(null) == null)
			{
				yield return new WaitForSeconds(0.001f);
			}
			object currModel = modeType.GetField("CurrModel").GetValue(null);
			Type type = currModel.GetType();
			FieldInfo viewModelField = type.GetField("_viewModel", BindingFlags.Instance | BindingFlags.NonPublic);
			while (viewModelField == null && modeType != typeof(AbstractModel))
			{
				type = type.BaseType;
				viewModelField = type.GetField("_viewModel", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			if (viewModelField != null)
			{
				while (viewModelField.GetValue(currModel) == null)
				{
					yield return new WaitForSeconds(0.001f);
				}
				object viewModel = viewModelField.GetValue(currModel);
				FieldInfo gameObjField = viewModel.GetType().GetField("_viewGameObject", BindingFlags.Instance | BindingFlags.NonPublic);
				if (gameObjField != null)
				{
					while (gameObjField.GetValue(viewModel) == null)
					{
						yield return new WaitForSeconds(0.001f);
					}
				}
			}
		}
		yield return new WaitForSeconds(0.1f);
	}

	public static IEnumerator InitUiTestByMode<T>(Func<bool> initCheck) where T : AbstractMode
	{
		yield return Init<TestUiModule>(initCheck);
		Contexts sharedInstance = Contexts.sharedInstance;
		GameObject.Find("GameController").GetComponent<TestGameController>().CreateFpsSystems(sharedInstance, new TestUiModeModule<T>(sharedInstance));
		yield return ViewModelInited(typeof(T));
	}

	public static IEnumerator InitUiTestByModule<T>(Func<bool> initCheck) where T : CompositeGameModule
	{
		yield return Init<T>(initCheck);
		yield return new WaitForSeconds(1f);
	}

	private static IEnumerator Init<T>(Func<bool> initCheck) where T : CompositeGameModule
	{
		new GameObject("MainCamera").AddComponent<UnityEngine.Camera>().clearFlags = CameraClearFlags.Color;
		Canvas canvas = new GameObject("Canvas", typeof(RectTransform)).AddComponent<Canvas>();
		canvas.renderMode = RenderMode.ScreenSpaceOverlay;
		canvas.sortingOrder = 1000;
		GameObject gameObject = new GameObject("EventSystem");
		gameObject.AddComponent<EventSystem>();
		gameObject.AddComponent<StandaloneInputModule>();
		canvas.gameObject.AddComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
		_text = new GameObject("Tips", typeof(RectTransform)).AddComponent<Text>();
		_text.transform.parent = canvas.transform;
		_text.rectTransform.anchorMin = new Vector2(0.5f, 1f);
		_text.rectTransform.anchorMax = new Vector2(0.5f, 1f);
		_text.rectTransform.sizeDelta = new Vector2(1024f, 30f);
		_text.rectTransform.anchoredPosition = new Vector3(0f, -150f, 0f);
		_text.alignment = TextAnchor.MiddleCenter;
		_text.verticalOverflow = VerticalWrapMode.Overflow;
		_text.color = Color.white;
		_text.fontSize = 24;
		Contexts sharedInstance = Contexts.sharedInstance;
		yield return GameTestHelper.InitTestGameController(sharedInstance, (T)Activator.CreateInstance(typeof(T), sharedInstance));
		AbstractModel.BestScaleMode = CanvasScaler.ScaleMode.ConstantPixelSize;
		AbstractModel.BestScreenSize = new Vector2(1920f, 1080f);
		yield return new WaitForSeconds(1f);
		while (initCheck != null && !initCheck())
		{
			yield return new WaitForSeconds(0.01f);
		}
	}
}
