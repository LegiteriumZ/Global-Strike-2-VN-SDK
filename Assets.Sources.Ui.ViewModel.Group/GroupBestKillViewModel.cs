using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Group;

[GameUiTest]
public class GroupBestKillViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oAce;

	private GameObject _oAceName;

	private Text _oAceNameText;

	private GameObject _oAceNum;

	private Text _oAceNumText;

	private GameObject _oSecond;

	private GameObject _oSecondName;

	private Text _oSecondNameText;

	private GameObject _oSecondNum;

	private Text _oSecondNumText;

	private GameObject _oThird;

	private GameObject _oThirdName;

	private Text _oThirdNameText;

	private GameObject _oThirdNum;

	private Text _oThirdNumText;

	private GameObject _oMVP;

	private GameObject _oMvpName;

	private Text _oMvpNameText;

	private GameObject _oMvpNum;

	private Text _oMvpNumText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/group";

	private string _resourceAssetName = "GroupBestKill";

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

	public bool AceShow
	{
		get
		{
			if (_oAce != null)
			{
				return _oAce.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (AceShow != value && _oAce != null)
			{
				_oAce.SetObjectActive(value);
			}
		}
	}

	public GameObject AceNameObj => _oAceName;

	public string AceNameString
	{
		get
		{
			if (_oAceNameText != null)
			{
				return _oAceNameText.text;
			}
			return null;
		}
		set
		{
			if (AceNameString != value && _oAceNameText != null)
			{
				_oAceNameText.text = value;
			}
		}
	}

	public string AceNumString
	{
		get
		{
			if (_oAceNumText != null)
			{
				return _oAceNumText.text;
			}
			return null;
		}
		set
		{
			if (AceNumString != value && _oAceNumText != null)
			{
				_oAceNumText.text = value;
			}
		}
	}

	public bool SecondShow
	{
		get
		{
			if (_oSecond != null)
			{
				return _oSecond.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SecondShow != value && _oSecond != null)
			{
				_oSecond.SetObjectActive(value);
			}
		}
	}

	public GameObject SecondNameObj => _oSecondName;

	public string SecondNameString
	{
		get
		{
			if (_oSecondNameText != null)
			{
				return _oSecondNameText.text;
			}
			return null;
		}
		set
		{
			if (SecondNameString != value && _oSecondNameText != null)
			{
				_oSecondNameText.text = value;
			}
		}
	}

	public string SecondNumString
	{
		get
		{
			if (_oSecondNumText != null)
			{
				return _oSecondNumText.text;
			}
			return null;
		}
		set
		{
			if (SecondNumString != value && _oSecondNumText != null)
			{
				_oSecondNumText.text = value;
			}
		}
	}

	public bool ThirdShow
	{
		get
		{
			if (_oThird != null)
			{
				return _oThird.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ThirdShow != value && _oThird != null)
			{
				_oThird.SetObjectActive(value);
			}
		}
	}

	public GameObject ThirdNameObj => _oThirdName;

	public string ThirdNameString
	{
		get
		{
			if (_oThirdNameText != null)
			{
				return _oThirdNameText.text;
			}
			return null;
		}
		set
		{
			if (ThirdNameString != value && _oThirdNameText != null)
			{
				_oThirdNameText.text = value;
			}
		}
	}

	public string ThirdNumString
	{
		get
		{
			if (_oThirdNumText != null)
			{
				return _oThirdNumText.text;
			}
			return null;
		}
		set
		{
			if (ThirdNumString != value && _oThirdNumText != null)
			{
				_oThirdNumText.text = value;
			}
		}
	}

	public bool MVPShow
	{
		get
		{
			if (_oMVP != null)
			{
				return _oMVP.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MVPShow != value && _oMVP != null)
			{
				_oMVP.SetObjectActive(value);
			}
		}
	}

	public GameObject MvpNameObj => _oMvpName;

	public string MvpNameString
	{
		get
		{
			if (_oMvpNameText != null)
			{
				return _oMvpNameText.text;
			}
			return null;
		}
		set
		{
			if (MvpNameString != value && _oMvpNameText != null)
			{
				_oMvpNameText.text = value;
			}
		}
	}

	public string MvpNumString
	{
		get
		{
			if (_oMvpNumText != null)
			{
				return _oMvpNumText.text;
			}
			return null;
		}
		set
		{
			if (MvpNumString != value && _oMvpNumText != null)
			{
				_oMvpNumText.text = value;
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
			case "Ace":
				_oAce = transform.gameObject;
				break;
			case "AceName":
				_oAceName = transform.gameObject;
				_oAceNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "AceNum":
				_oAceNum = transform.gameObject;
				_oAceNumText = transform.gameObject.GetComponent<Text>();
				break;
			case "Second":
				_oSecond = transform.gameObject;
				break;
			case "SecondName":
				_oSecondName = transform.gameObject;
				_oSecondNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "SecondNum":
				_oSecondNum = transform.gameObject;
				_oSecondNumText = transform.gameObject.GetComponent<Text>();
				break;
			case "Third":
				_oThird = transform.gameObject;
				break;
			case "ThirdName":
				_oThirdName = transform.gameObject;
				_oThirdNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "ThirdNum":
				_oThirdNum = transform.gameObject;
				_oThirdNumText = transform.gameObject.GetComponent<Text>();
				break;
			case "MVP":
				_oMVP = transform.gameObject;
				break;
			case "MvpName":
				_oMvpName = transform.gameObject;
				_oMvpNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "MvpNum":
				_oMvpNum = transform.gameObject;
				_oMvpNumText = transform.gameObject.GetComponent<Text>();
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
