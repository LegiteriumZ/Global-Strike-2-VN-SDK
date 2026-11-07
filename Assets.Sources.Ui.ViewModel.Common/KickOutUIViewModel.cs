using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Sources.Ui.DynamicLoader;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Manager;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class KickOutUIViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _obtnClose;

	private Button _obtnCloseButton;

	private GameObject _otContentPlayer;

	private GameObject _octContentPlayer;

	private GameObject _omsg1;

	private GameObject _omsg2;

	private GameObject _omsg3;

	private GameObject _omsg4;

	private Button _omsgButton1;

	private Button _omsgButton2;

	private Button _omsgButton3;

	private Button _omsgButton4;

	private GameObject _om1;

	private GameObject _om2;

	private GameObject _om3;

	private GameObject _om4;

	private GameObject _oConfirm;

	private Button _oConfirmButton;

	private GameObject _okickmsg;

	private Text _okickmsgText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "kickoutui";

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

	public bool ShowRootshow
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
			if (ShowRootshow == value || !(_oShow != null))
			{
				return;
			}
			if (value)
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oShow.SetObjectActive(!value);
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.Register(_resourceAssetName, delegate
				{
					_oShow.SetObjectActive(value);
				});
			}
			else
			{
				BattleSingletonInstance<UiDynamicLoadManager>.Instance.UnRegister(_resourceAssetName);
				_oShow.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent btnCloseClicked
	{
		get
		{
			if (_obtnCloseButton != null)
			{
				return _obtnCloseButton.onClick;
			}
			return null;
		}
		set
		{
			if (btnCloseClicked != value && _obtnCloseButton != null)
			{
				_obtnCloseButton.onClick = value;
			}
		}
	}

	public GameObject tContentPlayerObj => _otContentPlayer;

	public GameObject ctContentPlayerObj => _octContentPlayer;

	public Button.ButtonClickedEvent msgClicked1
	{
		get
		{
			if (_omsgButton1 != null)
			{
				return _omsgButton1.onClick;
			}
			return null;
		}
		set
		{
			if (msgClicked1 != value && _omsgButton1 != null)
			{
				_omsgButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent msgClicked2
	{
		get
		{
			if (_omsgButton2 != null)
			{
				return _omsgButton2.onClick;
			}
			return null;
		}
		set
		{
			if (msgClicked2 != value && _omsgButton2 != null)
			{
				_omsgButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent msgClicked3
	{
		get
		{
			if (_omsgButton3 != null)
			{
				return _omsgButton3.onClick;
			}
			return null;
		}
		set
		{
			if (msgClicked3 != value && _omsgButton3 != null)
			{
				_omsgButton3.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent msgClicked4
	{
		get
		{
			if (_omsgButton4 != null)
			{
				return _omsgButton4.onClick;
			}
			return null;
		}
		set
		{
			if (msgClicked4 != value && _omsgButton4 != null)
			{
				_omsgButton4.onClick = value;
			}
		}
	}

	public bool mShow1
	{
		get
		{
			if (_om1 != null)
			{
				return _om1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (mShow1 != value && _om1 != null)
			{
				_om1.SetObjectActive(value);
			}
		}
	}

	public bool mShow2
	{
		get
		{
			if (_om2 != null)
			{
				return _om2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (mShow2 != value && _om2 != null)
			{
				_om2.SetObjectActive(value);
			}
		}
	}

	public bool mShow3
	{
		get
		{
			if (_om3 != null)
			{
				return _om3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (mShow3 != value && _om3 != null)
			{
				_om3.SetObjectActive(value);
			}
		}
	}

	public bool mShow4
	{
		get
		{
			if (_om4 != null)
			{
				return _om4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (mShow4 != value && _om4 != null)
			{
				_om4.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent ConfirmClicked
	{
		get
		{
			if (_oConfirmButton != null)
			{
				return _oConfirmButton.onClick;
			}
			return null;
		}
		set
		{
			if (ConfirmClicked != value && _oConfirmButton != null)
			{
				_oConfirmButton.onClick = value;
			}
		}
	}

	public bool ConfirmButtonable
	{
		get
		{
			if (_oConfirmButton != null)
			{
				return _oConfirmButton.interactable;
			}
			return true;
		}
		set
		{
			if (ConfirmButtonable != value && _oConfirmButton != null)
			{
				_oConfirmButton.interactable = value;
			}
		}
	}

	public string kickmsgString
	{
		get
		{
			if (_okickmsgText != null)
			{
				return _okickmsgText.text;
			}
			return null;
		}
		set
		{
			if (kickmsgString != value && _okickmsgText != null)
			{
				_okickmsgText.text = value;
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
			case "btnClose":
				_obtnClose = transform.gameObject;
				_obtnCloseButton = transform.gameObject.GetComponent<Button>();
				break;
			case "tContentPlayer":
				_otContentPlayer = transform.gameObject;
				break;
			case "ctContentPlayer":
				_octContentPlayer = transform.gameObject;
				break;
			case "msg1":
				_omsg1 = transform.gameObject;
				_omsgButton1 = transform.gameObject.GetComponent<Button>();
				break;
			case "msg2":
				_omsg2 = transform.gameObject;
				_omsgButton2 = transform.gameObject.GetComponent<Button>();
				break;
			case "msg3":
				_omsg3 = transform.gameObject;
				_omsgButton3 = transform.gameObject.GetComponent<Button>();
				break;
			case "msg4":
				_omsg4 = transform.gameObject;
				_omsgButton4 = transform.gameObject.GetComponent<Button>();
				break;
			case "m1":
				_om1 = transform.gameObject;
				break;
			case "m2":
				_om2 = transform.gameObject;
				break;
			case "m3":
				_om3 = transform.gameObject;
				break;
			case "m4":
				_om4 = transform.gameObject;
				break;
			case "Confirm":
				_oConfirm = transform.gameObject;
				_oConfirmButton = transform.gameObject.GetComponent<Button>();
				break;
			case "kickmsg":
				_okickmsg = transform.gameObject;
				_okickmsgText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
		BattleSingletonInstance<UiDynamicLoadManager>.Instance.InitDynLoader(_resourceAssetName, instance.transform);
	}

	public void LoadRefrenceless(IUiResourcesLoader loader)
	{
		if (_refrencelessLoaded)
		{
			return;
		}
		_refrencelessLoaded = true;
		RefrencelessHelper component = _viewGameObject.GetComponent<RefrencelessHelper>();
		if (!(component != null))
		{
			return;
		}
		for (int i = 0; i < component.SpritePaths.Count; i++)
		{
			try
			{
				if (i < component.AutoLoad.Count && !component.AutoLoad[i])
				{
					continue;
				}
				string[] array = component.SpritePaths[i].Split(':');
				Image image = component.transform.Find(component.Images[i]).GetComponent<Image>();
				if (!string.IsNullOrEmpty(array[0]))
				{
					loader.RetriveSprite(array[0], array[1], delegate(Sprite sprite)
					{
						image.sprite = sprite;
					});
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
			}
		}
	}

	public Button.ButtonClickedEvent GetmsgClicked(int index)
	{
		return index switch
		{
			1 => msgClicked1, 
			2 => msgClicked2, 
			3 => msgClicked3, 
			4 => msgClicked4, 
			_ => null, 
		};
	}

	public void SetmsgClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			msgClicked1 = value;
			break;
		case 2:
			msgClicked2 = value;
			break;
		case 3:
			msgClicked3 = value;
			break;
		case 4:
			msgClicked4 = value;
			break;
		}
	}

	public int GetmsgCount()
	{
		return 4;
	}

	public bool GetmShow(int index)
	{
		return index switch
		{
			1 => mShow1, 
			2 => mShow2, 
			3 => mShow3, 
			4 => mShow4, 
			_ => false, 
		};
	}

	public void SetmShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			mShow1 = value;
			break;
		case 2:
			mShow2 = value;
			break;
		case 3:
			mShow3 = value;
			break;
		case 4:
			mShow4 = value;
			break;
		}
	}

	public int GetmCount()
	{
		return 4;
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
			UnityEngine.Object.Destroy(_viewGameObject);
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

	public void RemoveTriggerEntry(List<EventTrigger.Entry> triggers, EventTriggerType eventId)
	{
		foreach (EventTrigger.Entry trigger in triggers)
		{
			if (trigger.eventID == eventId)
			{
				triggers.Remove(trigger);
				break;
			}
		}
	}
}
