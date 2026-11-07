using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.UiFramework.Libs;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.ViewModels;
using Loxodon.Framework.Views;
using UnityEngine;

namespace Assets.UiFramework.Example.Scripts;

public class ExampleViewModel : ViewModelBase, IUiViewModel
{
	private class ExampleView : UIView
	{
		public Animator PlayFlyAnim;

		public Animator StopFlyAnim;

		public GameObject SubRoot;

		public void FillField()
		{
			Animator[] componentsInChildren = base.gameObject.GetComponentsInChildren<Animator>();
			foreach (Animator animator in componentsInChildren)
			{
				string text = animator.gameObject.name;
				if (text == "ImgAnim")
				{
					PlayFlyAnim = animator;
					StopFlyAnim = animator;
				}
			}
			RectTransform[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<RectTransform>();
			foreach (RectTransform rectTransform in componentsInChildren2)
			{
				string text = rectTransform.gameObject.name;
				if (text == "SubRoot")
				{
					SubRoot = rectTransform.gameObject;
				}
			}
		}
	}

	private Action<int> _playFlyAnim;

	private Action<int> _stopFlyAnim;

	public GameObject SubRoot;

	private GameObject _viewGameObject;

	private int _playFlyAnimHash = Animator.StringToHash("Fly");

	private int _stopFlyAnimHash = Animator.StringToHash("Stop");

	private static readonly Dictionary<string, PropertyInfo> PropertySetter;

	private static readonly Dictionary<string, MethodInfo> MethodSetter;

	public string ResourceBundleName => "uiprefabs";

	public string ResourceAssetName => "Prefabs/ExampleUi";

	public string ConfigBundleName => "";

	public string ConfigAssetName => "";

	public void Destory()
	{
		if (_viewGameObject != null)
		{
			UnityEngine.Object.Destroy(_viewGameObject);
		}
	}

	public void Visible(bool isVisible)
	{
		if (_viewGameObject != null)
		{
			_viewGameObject.SetActive(isVisible);
		}
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		throw new NotImplementedException();
	}

	public void CreateBinding(GameObject obj)
	{
		_viewGameObject = obj;
		ExampleView exampleView = obj.AddComponent<ExampleView>();
		exampleView.FillField();
		exampleView.BindingContext().DataContext = this;
		BindingSet<ExampleView, ExampleViewModel> bindingSet = exampleView.CreateBindingSet<ExampleView, ExampleViewModel>();
		_playFlyAnim = exampleView.PlayFlyAnim.SetTrigger;
		_stopFlyAnim = exampleView.StopFlyAnim.SetTrigger;
		SubRoot = exampleView.SubRoot;
		bindingSet.Build();
	}

	public void PlayFlyAnim()
	{
		if (_playFlyAnim != null)
		{
			_playFlyAnim(_playFlyAnimHash);
		}
	}

	public void StopFlyAnim()
	{
		if (_stopFlyAnim != null)
		{
			_stopFlyAnim(_stopFlyAnimHash);
		}
	}

	static ExampleViewModel()
	{
		PropertySetter = new Dictionary<string, PropertyInfo>();
		MethodSetter = new Dictionary<string, MethodInfo>();
		Type typeFromHandle = typeof(ExampleViewModel);
		PropertyInfo[] properties = typeFromHandle.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (propertyInfo.CanWrite)
			{
				PropertySetter.Add(propertyInfo.Name, propertyInfo);
			}
		}
		MethodInfo[] methods = typeFromHandle.GetMethods();
		foreach (MethodInfo methodInfo in methods)
		{
			if (methodInfo.IsPublic)
			{
				MethodSetter.Add(methodInfo.Name, methodInfo);
			}
		}
	}

	public void SetProperty(string propertyId, object value)
	{
		if (PropertySetter.ContainsKey(propertyId))
		{
			PropertySetter[propertyId].SetValue(this, value, null);
		}
	}

	public void CallFunction(string functionName)
	{
		if (MethodSetter.ContainsKey(functionName))
		{
			MethodSetter[functionName].Invoke(this, null);
		}
	}

	public bool IsPropertyExist(string propertyId)
	{
		return PropertySetter.ContainsKey(propertyId);
	}

	public Transform GetParentLinkNode()
	{
		if (!(SubRoot == null))
		{
			return SubRoot.transform;
		}
		return null;
	}

	public Transform GetChildLinkNode()
	{
		return null;
	}
}
