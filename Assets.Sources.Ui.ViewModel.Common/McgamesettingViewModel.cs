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
public class McgamesettingViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oCenter;

	private GameObject _oContent;

	private GameObject _oScrollbarVertical;

	private Scrollbar _oScrollbarVerticalScrollbar;

	private GameObject _oTipsBack;

	private RectTransform _oTipsBackRectTransform;

	private GameObject _oTips;

	private Text _oTipsText;

	private GameObject _oToggle1;

	private GameObject _oToggle2;

	private GameObject _oToggle3;

	private Toggle _oToggleToggle1;

	private Toggle _oToggleToggle2;

	private Toggle _oToggleToggle3;

	private GameObject _oToggleLabel1;

	private GameObject _oToggleLabel2;

	private GameObject _oToggleLabel3;

	private Text _oToggleLabelText1;

	private Text _oToggleLabelText2;

	private Text _oToggleLabelText3;

	private GameObject _oExitButton;

	private Button _oExitButtonButton;

	private GameObject _oExitText;

	private Text _oExitTextText;

	private GameObject _oResetButton;

	private Button _oResetButtonButton;

	private GameObject _oResetText;

	private Text _oResetTextText;

	private GameObject _oSaveButton;

	private Button _oSaveButtonButton;

	private GameObject _oSaveText;

	private Text _oSaveTextText;

	private GameObject _oCheckButton;

	private Button _oCheckButtonButton;

	private GameObject _oCheckText;

	private Text _oCheckTextText;

	private GameObject _oAlert;

	private GameObject _oAlertText;

	private Text _oAlertTextText;

	private GameObject _oAlertOk;

	private Button _oAlertOkButton;

	private GameObject _oAlertOkText;

	private Text _oAlertOkTextText;

	private GameObject _oAlertCancel;

	private Button _oAlertCancelButton;

	private GameObject _oAlertCancelText;

	private Text _oAlertCancelTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Mcgamesetting";

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

	public bool CenterShow
	{
		get
		{
			if (_oCenter != null)
			{
				return _oCenter.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (CenterShow != value && _oCenter != null)
			{
				_oCenter.SetObjectActive(value);
			}
		}
	}

	public GameObject ContentObj => _oContent;

	public float ScrollbarVerticalScrollvalue
	{
		get
		{
			if (_oScrollbarVerticalScrollbar != null)
			{
				return _oScrollbarVerticalScrollbar.value;
			}
			return 0f;
		}
		set
		{
			if (ScrollbarVerticalScrollvalue != value && _oScrollbarVerticalScrollbar != null)
			{
				_oScrollbarVerticalScrollbar.value = value;
			}
		}
	}

	public bool TipsBackShow
	{
		get
		{
			if (_oTipsBack != null)
			{
				return _oTipsBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TipsBackShow != value && _oTipsBack != null)
			{
				_oTipsBack.SetObjectActive(value);
			}
		}
	}

	public Vector3 TipsBackGposition
	{
		get
		{
			if (_oTipsBackRectTransform != null)
			{
				return _oTipsBackRectTransform.position;
			}
			return Vector3.zero;
		}
		set
		{
			if (TipsBackGposition != value && _oTipsBackRectTransform != null)
			{
				_oTipsBackRectTransform.position = value;
			}
		}
	}

	public string TipsString
	{
		get
		{
			if (_oTipsText != null)
			{
				return _oTipsText.text;
			}
			return null;
		}
		set
		{
			if (TipsString != value && _oTipsText != null)
			{
				_oTipsText.text = value;
			}
		}
	}

	public Toggle.ToggleEvent ToggleTogglechanged1
	{
		get
		{
			if (_oToggleToggle1 != null)
			{
				return _oToggleToggle1.onValueChanged;
			}
			return null;
		}
		set
		{
			if (ToggleTogglechanged1 != value && _oToggleToggle1 != null)
			{
				_oToggleToggle1.onValueChanged = value;
			}
		}
	}

	public Toggle.ToggleEvent ToggleTogglechanged2
	{
		get
		{
			if (_oToggleToggle2 != null)
			{
				return _oToggleToggle2.onValueChanged;
			}
			return null;
		}
		set
		{
			if (ToggleTogglechanged2 != value && _oToggleToggle2 != null)
			{
				_oToggleToggle2.onValueChanged = value;
			}
		}
	}

	public Toggle.ToggleEvent ToggleTogglechanged3
	{
		get
		{
			if (_oToggleToggle3 != null)
			{
				return _oToggleToggle3.onValueChanged;
			}
			return null;
		}
		set
		{
			if (ToggleTogglechanged3 != value && _oToggleToggle3 != null)
			{
				_oToggleToggle3.onValueChanged = value;
			}
		}
	}

	public bool ToggleOn1
	{
		get
		{
			if (_oToggleToggle1 != null)
			{
				return _oToggleToggle1.isOn;
			}
			return false;
		}
		set
		{
			if (ToggleOn1 != value && _oToggleToggle1 != null)
			{
				_oToggleToggle1.isOn = value;
			}
		}
	}

	public bool ToggleOn2
	{
		get
		{
			if (_oToggleToggle2 != null)
			{
				return _oToggleToggle2.isOn;
			}
			return false;
		}
		set
		{
			if (ToggleOn2 != value && _oToggleToggle2 != null)
			{
				_oToggleToggle2.isOn = value;
			}
		}
	}

	public bool ToggleOn3
	{
		get
		{
			if (_oToggleToggle3 != null)
			{
				return _oToggleToggle3.isOn;
			}
			return false;
		}
		set
		{
			if (ToggleOn3 != value && _oToggleToggle3 != null)
			{
				_oToggleToggle3.isOn = value;
			}
		}
	}

	public string ToggleLabelString1
	{
		get
		{
			if (_oToggleLabelText1 != null)
			{
				return _oToggleLabelText1.text;
			}
			return null;
		}
		set
		{
			if (ToggleLabelString1 != value && _oToggleLabelText1 != null)
			{
				_oToggleLabelText1.text = value;
			}
		}
	}

	public string ToggleLabelString2
	{
		get
		{
			if (_oToggleLabelText2 != null)
			{
				return _oToggleLabelText2.text;
			}
			return null;
		}
		set
		{
			if (ToggleLabelString2 != value && _oToggleLabelText2 != null)
			{
				_oToggleLabelText2.text = value;
			}
		}
	}

	public string ToggleLabelString3
	{
		get
		{
			if (_oToggleLabelText3 != null)
			{
				return _oToggleLabelText3.text;
			}
			return null;
		}
		set
		{
			if (ToggleLabelString3 != value && _oToggleLabelText3 != null)
			{
				_oToggleLabelText3.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent ExitButtonClicked
	{
		get
		{
			if (_oExitButtonButton != null)
			{
				return _oExitButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (ExitButtonClicked != value && _oExitButtonButton != null)
			{
				_oExitButtonButton.onClick = value;
			}
		}
	}

	public string ExitTextString
	{
		get
		{
			if (_oExitTextText != null)
			{
				return _oExitTextText.text;
			}
			return null;
		}
		set
		{
			if (ExitTextString != value && _oExitTextText != null)
			{
				_oExitTextText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent ResetButtonClicked
	{
		get
		{
			if (_oResetButtonButton != null)
			{
				return _oResetButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (ResetButtonClicked != value && _oResetButtonButton != null)
			{
				_oResetButtonButton.onClick = value;
			}
		}
	}

	public string ResetTextString
	{
		get
		{
			if (_oResetTextText != null)
			{
				return _oResetTextText.text;
			}
			return null;
		}
		set
		{
			if (ResetTextString != value && _oResetTextText != null)
			{
				_oResetTextText.text = value;
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

	public string SaveTextString
	{
		get
		{
			if (_oSaveTextText != null)
			{
				return _oSaveTextText.text;
			}
			return null;
		}
		set
		{
			if (SaveTextString != value && _oSaveTextText != null)
			{
				_oSaveTextText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent CheckButtonClicked
	{
		get
		{
			if (_oCheckButtonButton != null)
			{
				return _oCheckButtonButton.onClick;
			}
			return null;
		}
		set
		{
			if (CheckButtonClicked != value && _oCheckButtonButton != null)
			{
				_oCheckButtonButton.onClick = value;
			}
		}
	}

	public string CheckTextString
	{
		get
		{
			if (_oCheckTextText != null)
			{
				return _oCheckTextText.text;
			}
			return null;
		}
		set
		{
			if (CheckTextString != value && _oCheckTextText != null)
			{
				_oCheckTextText.text = value;
			}
		}
	}

	public bool AlertShow
	{
		get
		{
			if (_oAlert != null)
			{
				return _oAlert.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AlertShow != value && _oAlert != null)
			{
				_oAlert.SetObjectActive(value);
			}
		}
	}

	public string AlertTextString
	{
		get
		{
			if (_oAlertTextText != null)
			{
				return _oAlertTextText.text;
			}
			return null;
		}
		set
		{
			if (AlertTextString != value && _oAlertTextText != null)
			{
				_oAlertTextText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent AlertOkClicked
	{
		get
		{
			if (_oAlertOkButton != null)
			{
				return _oAlertOkButton.onClick;
			}
			return null;
		}
		set
		{
			if (AlertOkClicked != value && _oAlertOkButton != null)
			{
				_oAlertOkButton.onClick = value;
			}
		}
	}

	public string AlertOkTextString
	{
		get
		{
			if (_oAlertOkTextText != null)
			{
				return _oAlertOkTextText.text;
			}
			return null;
		}
		set
		{
			if (AlertOkTextString != value && _oAlertOkTextText != null)
			{
				_oAlertOkTextText.text = value;
			}
		}
	}

	public Button.ButtonClickedEvent AlertCancelClicked
	{
		get
		{
			if (_oAlertCancelButton != null)
			{
				return _oAlertCancelButton.onClick;
			}
			return null;
		}
		set
		{
			if (AlertCancelClicked != value && _oAlertCancelButton != null)
			{
				_oAlertCancelButton.onClick = value;
			}
		}
	}

	public string AlertCancelTextString
	{
		get
		{
			if (_oAlertCancelTextText != null)
			{
				return _oAlertCancelTextText.text;
			}
			return null;
		}
		set
		{
			if (AlertCancelTextString != value && _oAlertCancelTextText != null)
			{
				_oAlertCancelTextText.text = value;
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
			case "Center":
				_oCenter = transform.gameObject;
				break;
			case "Content":
				_oContent = transform.gameObject;
				break;
			case "ScrollbarVertical":
				_oScrollbarVertical = transform.gameObject;
				_oScrollbarVerticalScrollbar = transform.gameObject.GetComponent<Scrollbar>();
				break;
			case "TipsBack":
				_oTipsBack = transform.gameObject;
				_oTipsBackRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Tips":
				_oTips = transform.gameObject;
				_oTipsText = transform.gameObject.GetComponent<Text>();
				break;
			case "Toggle1":
				_oToggle1 = transform.gameObject;
				_oToggleToggle1 = transform.gameObject.GetComponent<Toggle>();
				break;
			case "Toggle2":
				_oToggle2 = transform.gameObject;
				_oToggleToggle2 = transform.gameObject.GetComponent<Toggle>();
				break;
			case "Toggle3":
				_oToggle3 = transform.gameObject;
				_oToggleToggle3 = transform.gameObject.GetComponent<Toggle>();
				break;
			case "ToggleLabel1":
				_oToggleLabel1 = transform.gameObject;
				_oToggleLabelText1 = transform.gameObject.GetComponent<Text>();
				break;
			case "ToggleLabel2":
				_oToggleLabel2 = transform.gameObject;
				_oToggleLabelText2 = transform.gameObject.GetComponent<Text>();
				break;
			case "ToggleLabel3":
				_oToggleLabel3 = transform.gameObject;
				_oToggleLabelText3 = transform.gameObject.GetComponent<Text>();
				break;
			case "ExitButton":
				_oExitButton = transform.gameObject;
				_oExitButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ExitText":
				_oExitText = transform.gameObject;
				_oExitTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "ResetButton":
				_oResetButton = transform.gameObject;
				_oResetButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "ResetText":
				_oResetText = transform.gameObject;
				_oResetTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "SaveButton":
				_oSaveButton = transform.gameObject;
				_oSaveButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "SaveText":
				_oSaveText = transform.gameObject;
				_oSaveTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "CheckButton":
				_oCheckButton = transform.gameObject;
				_oCheckButtonButton = transform.gameObject.GetComponent<Button>();
				break;
			case "CheckText":
				_oCheckText = transform.gameObject;
				_oCheckTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "Alert":
				_oAlert = transform.gameObject;
				break;
			case "AlertText":
				_oAlertText = transform.gameObject;
				_oAlertTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "AlertOk":
				_oAlertOk = transform.gameObject;
				_oAlertOkButton = transform.gameObject.GetComponent<Button>();
				break;
			case "AlertOkText":
				_oAlertOkText = transform.gameObject;
				_oAlertOkTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "AlertCancel":
				_oAlertCancel = transform.gameObject;
				_oAlertCancelButton = transform.gameObject.GetComponent<Button>();
				break;
			case "AlertCancelText":
				_oAlertCancelText = transform.gameObject;
				_oAlertCancelTextText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public Toggle.ToggleEvent GetToggleTogglechanged(int index)
	{
		return index switch
		{
			1 => ToggleTogglechanged1, 
			2 => ToggleTogglechanged2, 
			3 => ToggleTogglechanged3, 
			_ => null, 
		};
	}

	public void SetToggleTogglechanged(int index, Toggle.ToggleEvent value)
	{
		switch (index)
		{
		case 1:
			ToggleTogglechanged1 = value;
			break;
		case 2:
			ToggleTogglechanged2 = value;
			break;
		case 3:
			ToggleTogglechanged3 = value;
			break;
		}
	}

	public bool GetToggleOn(int index)
	{
		return index switch
		{
			1 => ToggleOn1, 
			2 => ToggleOn2, 
			3 => ToggleOn3, 
			_ => false, 
		};
	}

	public void SetToggleOn(int index, bool value)
	{
		switch (index)
		{
		case 1:
			ToggleOn1 = value;
			break;
		case 2:
			ToggleOn2 = value;
			break;
		case 3:
			ToggleOn3 = value;
			break;
		}
	}

	public string GetToggleLabelString(int index)
	{
		return index switch
		{
			1 => ToggleLabelString1, 
			2 => ToggleLabelString2, 
			3 => ToggleLabelString3, 
			_ => null, 
		};
	}

	public void SetToggleLabelString(int index, string value)
	{
		switch (index)
		{
		case 1:
			ToggleLabelString1 = value;
			break;
		case 2:
			ToggleLabelString2 = value;
			break;
		case 3:
			ToggleLabelString3 = value;
			break;
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
