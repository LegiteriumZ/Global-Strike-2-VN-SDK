using System;
using SSJJUniRx;
using UnityEngine;
using UnityEngine.UI;

namespace SSJJ.Utility;

public static class UniRxEx
{
	public static IDisposable SubscribeToSlider(this SSJJUniRx.IObservable<float> source, Slider slider)
	{
		return source.SubscribeWithState(slider, delegate(float x, Slider t)
		{
			t.value = x;
		});
	}

	public static IDisposable SubscribeToFillAmount(this SSJJUniRx.IObservable<float> source, Image image)
	{
		return source.SubscribeWithState(image, delegate(float x, Image t)
		{
			t.fillAmount = x;
		});
	}

	public static IDisposable SubscribeToPosition(this SSJJUniRx.IObservable<Vector3> source, RectTransform transform)
	{
		return source.SubscribeWithState(transform, delegate(Vector3 x, RectTransform t)
		{
			t.localPosition = x;
		});
	}

	public static IDisposable SubscribeToToggle(this SSJJUniRx.IObservable<bool> source, Toggle toggle)
	{
		return source.SubscribeWithState(toggle, delegate(bool x, Toggle t)
		{
			t.isOn = x;
		});
	}
}
