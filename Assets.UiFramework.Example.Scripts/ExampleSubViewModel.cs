using System;
using System.Collections.Generic;
using System.Reflection;
using Assets.UiFramework.Libs;
using Loxodon.Framework.Binding;
using Loxodon.Framework.Binding.Builder;
using Loxodon.Framework.ViewModels;
using Loxodon.Framework.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.UiFramework.Example.Scripts;

public class ExampleSubViewModel : ViewModelBase, IUiViewModel
{
	private class ExampleSubView : UIView
	{
		public Action<BaseEventData> OnMyButtonHover;

		public Action<BaseEventData> OnMyButtonClick;

		public Action<BaseEventData> OnMyButtonMouseDown;

		public Action<BaseEventData> OnMyButtonMouseUp;

		public Action<BaseEventData> OnMyButtonHoverExit;

		public Image ShowMyImage;

		public Image MyImage;

		public Image ResizeMyImage;

		public Text ShowMyText;

		public Text CurrentTime;

		public Slider Progress;

		public EventTrigger MyButton;

		public GameObject Root;

		public void GenerateTrigger()
		{
			EventTrigger.Entry entry = new EventTrigger.Entry
			{
				callback = new EventTrigger.TriggerEvent(),
				eventID = EventTriggerType.PointerEnter
			};
			entry.callback.AddListener(delegate(BaseEventData data)
			{
				if (OnMyButtonHover != null)
				{
					OnMyButtonHover(data);
				}
			});
			MyButton.triggers.Add(entry);
			entry = new EventTrigger.Entry
			{
				callback = new EventTrigger.TriggerEvent(),
				eventID = EventTriggerType.PointerClick
			};
			entry.callback.AddListener(delegate(BaseEventData data)
			{
				if (OnMyButtonClick != null)
				{
					OnMyButtonClick(data);
				}
			});
			MyButton.triggers.Add(entry);
			entry = new EventTrigger.Entry
			{
				callback = new EventTrigger.TriggerEvent(),
				eventID = EventTriggerType.PointerDown
			};
			entry.callback.AddListener(delegate(BaseEventData data)
			{
				if (OnMyButtonMouseDown != null)
				{
					OnMyButtonMouseDown(data);
				}
			});
			MyButton.triggers.Add(entry);
			entry = new EventTrigger.Entry
			{
				callback = new EventTrigger.TriggerEvent(),
				eventID = EventTriggerType.PointerUp
			};
			entry.callback.AddListener(delegate(BaseEventData data)
			{
				if (OnMyButtonMouseUp != null)
				{
					OnMyButtonMouseUp(data);
				}
			});
			MyButton.triggers.Add(entry);
			entry = new EventTrigger.Entry
			{
				callback = new EventTrigger.TriggerEvent(),
				eventID = EventTriggerType.PointerExit
			};
			entry.callback.AddListener(delegate(BaseEventData data)
			{
				if (OnMyButtonHoverExit != null)
				{
					OnMyButtonHoverExit(data);
				}
			});
			MyButton.triggers.Add(entry);
		}

		public void FillField()
		{
			Image[] componentsInChildren = base.gameObject.GetComponentsInChildren<Image>();
			foreach (Image image in componentsInChildren)
			{
				string text = image.gameObject.name;
				if (text == "MyImage")
				{
					ShowMyImage = image;
					MyImage = image;
					ResizeMyImage = image;
				}
			}
			Text[] componentsInChildren2 = base.gameObject.GetComponentsInChildren<Text>();
			foreach (Text text2 in componentsInChildren2)
			{
				string text = text2.gameObject.name;
				if (text == "MyText")
				{
					ShowMyText = text2;
					CurrentTime = text2;
				}
			}
			Slider[] componentsInChildren3 = base.gameObject.GetComponentsInChildren<Slider>();
			foreach (Slider slider in componentsInChildren3)
			{
				string text = slider.gameObject.name;
				if (text == "MySlider")
				{
					Progress = slider;
				}
			}
			EventTrigger[] componentsInChildren4 = base.gameObject.GetComponentsInChildren<EventTrigger>();
			foreach (EventTrigger eventTrigger in componentsInChildren4)
			{
				string text = eventTrigger.gameObject.name;
				if (text == "MyButton")
				{
					MyButton = eventTrigger;
				}
			}
			RectTransform[] componentsInChildren5 = base.gameObject.GetComponentsInChildren<RectTransform>();
			foreach (RectTransform rectTransform in componentsInChildren5)
			{
				string text = rectTransform.gameObject.name;
				if (text == "Root")
				{
					Root = rectTransform.gameObject;
				}
			}
		}
	}

	private bool _showMyImage;

	private Sprite _myImage;

	private Action _resizeMyImage;

	private bool _showMyText;

	private string _currentTime;

	private float _progress;

	private List<EventTrigger.Entry> _myButton;

	public GameObject Root;

	private Action<Action<BaseEventData>> _onOnMyButtonHoverChanged;

	private Action<BaseEventData> _onMyButtonHoverListener;

	private Action<Action<BaseEventData>> _onOnMyButtonClickChanged;

	private Action<BaseEventData> _onMyButtonClickListener;

	private Action<Action<BaseEventData>> _onOnMyButtonMouseDownChanged;

	private Action<BaseEventData> _onMyButtonMouseDownListener;

	private Action<Action<BaseEventData>> _onOnMyButtonMouseUpChanged;

	private Action<BaseEventData> _onMyButtonMouseUpListener;

	private Action<Action<BaseEventData>> _onOnMyButtonHoverExitChanged;

	private Action<BaseEventData> _onMyButtonHoverExitListener;

	private GameObject _viewGameObject;

	private ExampleSubView _view;

	private static Sprite _emptySprite;

	private static readonly Dictionary<string, PropertyInfo> PropertySetter;

	private static readonly Dictionary<string, MethodInfo> MethodSetter;

	public bool ShowMyImage
	{
		get
		{
			return _showMyImage;
		}
		set
		{
			Set(ref _showMyImage, value, "ShowMyImage");
		}
	}

	public Sprite MyImage
	{
		get
		{
			return _myImage;
		}
		set
		{
			Set(ref _myImage, value, "MyImage");
			if (null != _view && null != _view.MyImage && null == value)
			{
				_view.MyImage.sprite = EmptySprite;
			}
		}
	}

	public bool ShowMyText
	{
		get
		{
			return _showMyText;
		}
		set
		{
			Set(ref _showMyText, value, "ShowMyText");
		}
	}

	public string CurrentTime
	{
		get
		{
			return _currentTime;
		}
		set
		{
			Set(ref _currentTime, value, "CurrentTime");
		}
	}

	public float Progress
	{
		get
		{
			return _progress;
		}
		set
		{
			Set(ref _progress, value, "Progress");
		}
	}

	public List<EventTrigger.Entry> MyButton
	{
		get
		{
			return _myButton;
		}
		set
		{
			Set(ref _myButton, value, "MyButton");
		}
	}

	public Action<BaseEventData> OnMyButtonHoverListener
	{
		get
		{
			return _onMyButtonHoverListener;
		}
		set
		{
			if (_onOnMyButtonHoverChanged != null)
			{
				_onOnMyButtonHoverChanged(value);
			}
			_onMyButtonHoverListener = value;
		}
	}

	public Action<BaseEventData> OnMyButtonClickListener
	{
		get
		{
			return _onMyButtonClickListener;
		}
		set
		{
			if (_onOnMyButtonClickChanged != null)
			{
				_onOnMyButtonClickChanged(value);
			}
			_onMyButtonClickListener = value;
		}
	}

	public Action<BaseEventData> OnMyButtonMouseDownListener
	{
		get
		{
			return _onMyButtonMouseDownListener;
		}
		set
		{
			if (_onOnMyButtonMouseDownChanged != null)
			{
				_onOnMyButtonMouseDownChanged(value);
			}
			_onMyButtonMouseDownListener = value;
		}
	}

	public Action<BaseEventData> OnMyButtonMouseUpListener
	{
		get
		{
			return _onMyButtonMouseUpListener;
		}
		set
		{
			if (_onOnMyButtonMouseUpChanged != null)
			{
				_onOnMyButtonMouseUpChanged(value);
			}
			_onMyButtonMouseUpListener = value;
		}
	}

	public Action<BaseEventData> OnMyButtonHoverExitListener
	{
		get
		{
			return _onMyButtonHoverExitListener;
		}
		set
		{
			if (_onOnMyButtonHoverExitChanged != null)
			{
				_onOnMyButtonHoverExitChanged(value);
			}
			_onMyButtonHoverExitListener = value;
		}
	}

	private static Sprite EmptySprite
	{
		get
		{
			if (null == _emptySprite)
			{
				_emptySprite = Sprite.Create(new Texture2D(1, 1), new Rect(0f, 0f, 1f, 1f), Vector2.zero);
			}
			return _emptySprite;
		}
	}

	public string ResourceBundleName => "uiprefabs";

	public string ResourceAssetName => "Prefabs/ExampleSubUi";

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
		ExampleSubView view = (_view = obj.AddComponent<ExampleSubView>());
		view.FillField();
		view.BindingContext().DataContext = this;
		BindingSet<ExampleSubView, ExampleSubViewModel> bindingSet = view.CreateBindingSet<ExampleSubView, ExampleSubViewModel>();
		bindingSet.Bind(view.ShowMyImage).For((Image v) => v.enabled).To((ExampleSubViewModel vm) => vm.ShowMyImage)
			.OneWay();
		bindingSet.Bind(view.MyImage).For((Image v) => v.sprite).To((ExampleSubViewModel vm) => vm.MyImage)
			.OneWay();
		_resizeMyImage = view.ResizeMyImage.SetNativeSize;
		bindingSet.Bind(view.ShowMyText).For((Text v) => v.enabled).To((ExampleSubViewModel vm) => vm.ShowMyText)
			.OneWay();
		bindingSet.Bind(view.CurrentTime).For((Text v) => v.text).To((ExampleSubViewModel vm) => vm.CurrentTime)
			.OneWay();
		bindingSet.Bind(view.Progress).For((Slider v) => v.value).To((ExampleSubViewModel vm) => vm.Progress)
			.OneWay();
		Root = view.Root;
		view.GenerateTrigger();
		_onOnMyButtonHoverChanged = delegate(Action<BaseEventData> val)
		{
			view.OnMyButtonHover = val;
		};
		_onOnMyButtonClickChanged = delegate(Action<BaseEventData> val)
		{
			view.OnMyButtonClick = val;
		};
		_onOnMyButtonMouseDownChanged = delegate(Action<BaseEventData> val)
		{
			view.OnMyButtonMouseDown = val;
		};
		_onOnMyButtonMouseUpChanged = delegate(Action<BaseEventData> val)
		{
			view.OnMyButtonMouseUp = val;
		};
		_onOnMyButtonHoverExitChanged = delegate(Action<BaseEventData> val)
		{
			view.OnMyButtonHoverExit = val;
		};
		bindingSet.Build();
	}

	public void ResizeMyImage()
	{
		if (_resizeMyImage != null)
		{
			_resizeMyImage();
		}
	}

	static ExampleSubViewModel()
	{
		PropertySetter = new Dictionary<string, PropertyInfo>();
		MethodSetter = new Dictionary<string, MethodInfo>();
		Type typeFromHandle = typeof(ExampleSubViewModel);
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
		return null;
	}

	public Transform GetChildLinkNode()
	{
		if (!(Root == null))
		{
			return Root.transform;
		}
		return null;
	}
}
