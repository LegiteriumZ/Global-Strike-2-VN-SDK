using System.Collections.Generic;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class RpgSelectMainViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRpgSelectMain;

	private GameObject _opanel;

	private GameObject _obg;

	private GameObject _ocanimg;

	private Image _ocanimgImage;

	private GameObject _oclosebtn;

	private Button _oclosebtnButton;

	private GameObject _omoney;

	private Image _omoneyImage;

	private GameObject _omoneyinfo;

	private Text _omoneyinfoText;

	private GameObject _oContent;

	private GameObject _ocell;

	private GameObject _omoneytxt;

	private Text _omoneytxtText;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	public const string ContentName = "Content";

	public const string cellName = "cell";

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgSelectMain";

	public UiReferences UI => uiRef;

	public GameObject RpgSelectMainObj => _oRpgSelectMain;

	public bool RpgSelectMainShow
	{
		get
		{
			if (_oRpgSelectMain != null)
			{
				return _oRpgSelectMain.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgSelectMainShow != value && _oRpgSelectMain != null)
			{
				_oRpgSelectMain.SetObjectActive(value);
			}
		}
	}

	public bool panelShow
	{
		get
		{
			if (_opanel != null)
			{
				return _opanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (panelShow != value && _opanel != null)
			{
				_opanel.SetObjectActive(value);
			}
		}
	}

	public bool bgShow
	{
		get
		{
			if (_obg != null)
			{
				return _obg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (bgShow != value && _obg != null)
			{
				_obg.SetObjectActive(value);
			}
		}
	}

	public bool canimgShow
	{
		get
		{
			if (_ocanimg != null)
			{
				return _ocanimg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (canimgShow != value && _ocanimg != null)
			{
				_ocanimg.SetObjectActive(value);
			}
		}
	}

	public Image canimgImage
	{
		get
		{
			if (_ocanimgImage != null)
			{
				return _ocanimgImage;
			}
			return null;
		}
		set
		{
			if (canimgImage != value && _ocanimgImage != null)
			{
				_ocanimgImage = value;
			}
		}
	}

	public bool closebtnShow
	{
		get
		{
			if (_oclosebtn != null)
			{
				return _oclosebtn.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (closebtnShow != value && _oclosebtn != null)
			{
				_oclosebtn.SetObjectActive(value);
			}
		}
	}

	public Button.ButtonClickedEvent closebtnClicked
	{
		get
		{
			if (_oclosebtnButton != null)
			{
				return _oclosebtnButton.onClick;
			}
			return null;
		}
		set
		{
			if (closebtnClicked != value && _oclosebtnButton != null)
			{
				_oclosebtnButton.onClick = value;
			}
		}
	}

	public bool moneyShow
	{
		get
		{
			if (_omoney != null)
			{
				return _omoney.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (moneyShow != value && _omoney != null)
			{
				_omoney.SetObjectActive(value);
			}
		}
	}

	public Image moneyImage
	{
		get
		{
			if (_omoneyImage != null)
			{
				return _omoneyImage;
			}
			return null;
		}
		set
		{
			if (moneyImage != value && _omoneyImage != null)
			{
				_omoneyImage = value;
			}
		}
	}

	public string moneyinfoString
	{
		get
		{
			if (_omoneyinfoText != null)
			{
				return _omoneyinfoText.text;
			}
			return null;
		}
		set
		{
			if (moneyinfoString != value && _omoneyinfoText != null)
			{
				_omoneyinfoText.text = value;
			}
		}
	}

	public bool moneytxtShow
	{
		get
		{
			if (_omoneytxt != null)
			{
				return _omoneytxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (moneytxtShow != value && _omoneytxt != null)
			{
				_omoneytxt.SetObjectActive(value);
			}
		}
	}

	public string moneytxtString
	{
		get
		{
			if (_omoneytxtText != null)
			{
				return _omoneytxtText.text;
			}
			return null;
		}
		set
		{
			if (moneytxtString != value && _omoneytxtText != null)
			{
				_omoneytxtText.text = value;
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
		uiRef = instance.TryAddComponent<UiReferences>();
		Transform[] componentsInChildren = instance.GetComponentsInChildren<Transform>(includeInactive: true);
		foreach (Transform transform in componentsInChildren)
		{
			switch (transform.name.Replace("(Clone)", ""))
			{
			case "RpgSelectMain":
				_oRpgSelectMain = transform.gameObject;
				uiRef.Set("RpgSelectMain", _oRpgSelectMain.transform);
				break;
			case "panel":
				_opanel = transform.gameObject;
				uiRef.Set("panel", _opanel.transform);
				break;
			case "bg":
				_obg = transform.gameObject;
				uiRef.Set("bg", _obg.transform);
				break;
			case "canimg":
				_ocanimg = transform.gameObject;
				uiRef.Set("canimg", _ocanimg.transform);
				_ocanimgImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("canimgImage", _ocanimgImage);
				break;
			case "closebtn":
				_oclosebtn = transform.gameObject;
				uiRef.Set("closebtn", _oclosebtn.transform);
				_oclosebtnButton = transform.gameObject.GetComponent<Button>();
				uiRef.Set("closebtnButton", _oclosebtnButton);
				break;
			case "money":
				_omoney = transform.gameObject;
				uiRef.Set("money", _omoney.transform);
				_omoneyImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("moneyImage", _omoneyImage);
				break;
			case "moneyinfo":
				_omoneyinfo = transform.gameObject;
				uiRef.Set("moneyinfo", _omoneyinfo.transform);
				_omoneyinfoText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("moneyinfoText", _omoneyinfoText);
				break;
			case "Content":
				_oContent = transform.gameObject;
				uiRef.Set("Content", _oContent.transform);
				break;
			case "cell":
				_ocell = transform.gameObject;
				uiRef.Set("cell", _ocell.transform);
				break;
			case "moneytxt":
				_omoneytxt = transform.gameObject;
				uiRef.Set("moneytxt", _omoneytxt.transform);
				_omoneytxtText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("moneytxtText", _omoneytxtText);
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
