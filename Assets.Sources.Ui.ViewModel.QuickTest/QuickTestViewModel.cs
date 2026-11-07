using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.QuickTest;

[GameUiTest]
public class QuickTestViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oSaveButton;

	private Button _oSaveButtonButton;

	private GameObject _oTestButton;

	private Button _oTestButtonButton;

	private GameObject _oHandButton;

	private Button _oHandButtonButton;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/quicktest";

	private string _resourceAssetName = "QuickTest";

	public GameObject ViewGameObject => _viewGameObject;

	public bool ViewGameObjectShow
	{
		get
		{
			if (_viewGameObject != null)
			{
				return _viewGameObject.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ViewGameObjectShow != value && _viewGameObject != null)
			{
				_viewGameObject.SetObjectActive(value);
			}
		}
	}

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent SaveButtonClicked
	{
		get
		{
			if (_oSaveButtonButton != null)
			{
				return _oSaveButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (SaveButtonClicked != value && _oSaveButtonButton != null)
			{
				_oSaveButtonButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent TestButtonClicked
	{
		get
		{
			if (_oTestButtonButton != null)
			{
				return _oTestButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (TestButtonClicked != value && _oTestButtonButton != null)
			{
				_oTestButtonButton.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent HandButtonClicked
	{
		get
		{
			if (_oHandButtonButton != null)
			{
				return _oHandButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (HandButtonClicked != value && _oHandButtonButton != null)
			{
				_oHandButtonButton.onClick = value;
			}
		}
	}

	public string ResourceBundleName
	{
		get
		{
			return _resourceBundleName;
		}
		set
		{
			_resourceBundleName = value;
		}
	}

	public string ResourceAssetName
	{
		get
		{
			return _resourceAssetName;
		}
		set
		{
			_resourceAssetName = value;
		}
	}

	public string ConfigBundleName => "";

	public string ConfigAssetName => "";

	public bool IsInited => _viewGameObject != null;

	public void CreateBinding(GameObject instance)
	{
		_viewGameObject = instance;
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "SaveButton":
				_oSaveButton = transform.gameObject;
				_oSaveButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "TestButton":
				_oTestButton = transform.gameObject;
				_oTestButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "HandButton":
				_oHandButton = transform.gameObject;
				_oHandButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			}
		}
	}

	public bool IsPropertyExist(string name)
	{
		return true;
	}

	public Transform GetParentLinkNode()
	{
		return null;
	}

	public Transform GetChildLinkNode()
	{
		return null;
	}

	public void Destory()
	{
		if (_viewGameObject != null)
		{
			Object.Destroy(_viewGameObject);
		}
	}

	public void Visible(bool isVisible)
	{
		if (_viewGameObject != null)
		{
			_viewGameObject.SetObjectActive(isVisible);
		}
	}

	public EventTrigger.Entry CreateTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId, UnityAction<BaseEventData> callback)
	{
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			callback = new EventTrigger.TriggerEvent(),
			eventID = eventId
		};
		entry.callback.AddListener(callback);
		triggers?.Add(entry);
		return entry;
	}

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
