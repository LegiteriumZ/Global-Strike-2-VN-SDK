using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class TestCrossViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oInputField;

	private InputField _oInputFieldInputField;

	private GameObject _oChangeBtn;

	private Button _oChangeBtnButton;

	private GameObject _oNextBtn;

	private Button _oNextBtnButton;

	private GameObject _oLastBtn;

	private Button _oLastBtnButton;

	private GameObject _oStartBtn;

	private Button _oStartBtnButton;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "TestCross";

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.activeSelf;
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetActive(value);
			}
		}
	}

	public string InputFieldText
	{
		get
		{
			if (_oInputFieldInputField != null)
			{
				return _oInputFieldInputField.text;
			}
			return "";
		}
		set
		{
			if (InputFieldText != value && _oInputFieldInputField != null)
			{
				_oInputFieldInputField.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent ChangeBtnClicked
	{
		get
		{
			if (_oChangeBtnButton != null)
			{
				return _oChangeBtnButton.onClick;
			}
			return null;
		}
		set
		{
			if (ChangeBtnClicked != value && _oChangeBtnButton != null)
			{
				_oChangeBtnButton.onClick = value;
			}
		}
	}

	public bool ChangeBtnButtonable
	{
		get
		{
			if (_oChangeBtnButton != null)
			{
				return _oChangeBtnButton.interactable;
			}
			return true;
		}
		set
		{
			if (ChangeBtnButtonable != value && _oChangeBtnButton != null)
			{
				_oChangeBtnButton.interactable = value;
			}
		}
	}

	public Button.ButtonClickedEvent NextBtnClicked
	{
		get
		{
			if (_oNextBtnButton != null)
			{
				return _oNextBtnButton.onClick;
			}
			return null;
		}
		set
		{
			if (NextBtnClicked != value && _oNextBtnButton != null)
			{
				_oNextBtnButton.onClick = value;
			}
		}
	}

	public bool NextBtnButtonable
	{
		get
		{
			if (_oNextBtnButton != null)
			{
				return _oNextBtnButton.interactable;
			}
			return true;
		}
		set
		{
			if (NextBtnButtonable != value && _oNextBtnButton != null)
			{
				_oNextBtnButton.interactable = value;
			}
		}
	}

	public Button.ButtonClickedEvent LastBtnClicked
	{
		get
		{
			if (_oLastBtnButton != null)
			{
				return _oLastBtnButton.onClick;
			}
			return null;
		}
		set
		{
			if (LastBtnClicked != value && _oLastBtnButton != null)
			{
				_oLastBtnButton.onClick = value;
			}
		}
	}

	public bool LastBtnButtonable
	{
		get
		{
			if (_oLastBtnButton != null)
			{
				return _oLastBtnButton.interactable;
			}
			return true;
		}
		set
		{
			if (LastBtnButtonable != value && _oLastBtnButton != null)
			{
				_oLastBtnButton.interactable = value;
			}
		}
	}

	public Button.ButtonClickedEvent StartBtnClicked
	{
		get
		{
			if (_oStartBtnButton != null)
			{
				return _oStartBtnButton.onClick;
			}
			return null;
		}
		set
		{
			if (StartBtnClicked != value && _oStartBtnButton != null)
			{
				_oStartBtnButton.onClick = value;
			}
		}
	}

	public bool StartBtnButtonable
	{
		get
		{
			if (_oStartBtnButton != null)
			{
				return _oStartBtnButton.interactable;
			}
			return true;
		}
		set
		{
			if (StartBtnButtonable != value && _oStartBtnButton != null)
			{
				_oStartBtnButton.interactable = value;
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
			case "InputField":
				_oInputField = transform.gameObject;
				_oInputFieldInputField = transform.gameObject.GetComponent<InputField>();
				break;
			case "ChangeBtn":
				_oChangeBtn = transform.gameObject;
				_oChangeBtnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "NextBtn":
				_oNextBtn = transform.gameObject;
				_oNextBtnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "LastBtn":
				_oLastBtn = transform.gameObject;
				_oLastBtnButton = transform.gameObject.GetComponent<Button>();
				break;
			case "StartBtn":
				_oStartBtn = transform.gameObject;
				_oStartBtnButton = transform.gameObject.GetComponent<Button>();
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
			_viewGameObject.SetActive(isVisible);
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
