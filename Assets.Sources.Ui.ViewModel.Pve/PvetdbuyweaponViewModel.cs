using System.Collections.Generic;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using SSJJBase.Extensions;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class PvetdbuyweaponViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _opvetdbuyweapon;

	private GameObject _oPanel;

	private RectTransform _oPanelRectTransform;

	private GameObject _omontytxt;

	private Text _omontytxtText;

	private GameObject _ostartxt;

	private Text _ostartxtText;

	private GameObject _oselect1;

	private GameObject _oselect2;

	private GameObject _oselect3;

	private RectTransform _oselectRectTransform1;

	private RectTransform _oselectRectTransform2;

	private RectTransform _oselectRectTransform3;

	private Image _oselectImage1;

	private Image _oselectImage2;

	private Image _oselectImage3;

	private Button _oselectButton1;

	private Button _oselectButton2;

	private Button _oselectButton3;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	public const string montytxtName = "montytxt";

	public const string startxtName = "startxt";

	public const string select1Name = "select1";

	public const string select2Name = "select2";

	public const string select3Name = "select3";

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Pvetdbuyweapon";

	public UiReferences UI => uiRef;

	public GameObject pvetdbuyweaponObj => _opvetdbuyweapon;

	public bool pvetdbuyweaponShow
	{
		get
		{
			if (_opvetdbuyweapon != null)
			{
				return _opvetdbuyweapon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (pvetdbuyweaponShow != value && _opvetdbuyweapon != null)
			{
				_opvetdbuyweapon.SetObjectActive(value);
			}
		}
	}

	public Vector2 PanelAnchoredposition
	{
		get
		{
			if (_oPanelRectTransform != null)
			{
				return _oPanelRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (PanelAnchoredposition != value && _oPanelRectTransform != null)
			{
				_oPanelRectTransform.anchoredPosition = value;
			}
		}
	}

	public bool montytxtShow
	{
		get
		{
			if (_omontytxt != null)
			{
				return _omontytxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (montytxtShow != value && _omontytxt != null)
			{
				_omontytxt.SetObjectActive(value);
			}
		}
	}

	public string montytxtString
	{
		get
		{
			if (_omontytxtText != null)
			{
				return _omontytxtText.text;
			}
			return null;
		}
		set
		{
			if (montytxtString != value && _omontytxtText != null)
			{
				_omontytxtText.text = value;
			}
		}
	}

	public Color montytxtTextcolor
	{
		get
		{
			if (_omontytxtText != null)
			{
				return _omontytxtText.color;
			}
			return Color.white;
		}
		set
		{
			if (montytxtTextcolor != value && _omontytxtText != null)
			{
				_omontytxtText.color = value;
			}
		}
	}

	public bool startxtShow
	{
		get
		{
			if (_ostartxt != null)
			{
				return _ostartxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (startxtShow != value && _ostartxt != null)
			{
				_ostartxt.SetObjectActive(value);
			}
		}
	}

	public string startxtString
	{
		get
		{
			if (_ostartxtText != null)
			{
				return _ostartxtText.text;
			}
			return null;
		}
		set
		{
			if (startxtString != value && _ostartxtText != null)
			{
				_ostartxtText.text = value;
			}
		}
	}

	public Color startxtTextcolor
	{
		get
		{
			if (_ostartxtText != null)
			{
				return _ostartxtText.color;
			}
			return Color.white;
		}
		set
		{
			if (startxtTextcolor != value && _ostartxtText != null)
			{
				_ostartxtText.color = value;
			}
		}
	}

	public bool selectShow1
	{
		get
		{
			if (_oselect1 != null)
			{
				return _oselect1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow1 != value && _oselect1 != null)
			{
				_oselect1.SetObjectActive(value);
			}
		}
	}

	public bool selectShow2
	{
		get
		{
			if (_oselect2 != null)
			{
				return _oselect2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow2 != value && _oselect2 != null)
			{
				_oselect2.SetObjectActive(value);
			}
		}
	}

	public bool selectShow3
	{
		get
		{
			if (_oselect3 != null)
			{
				return _oselect3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (selectShow3 != value && _oselect3 != null)
			{
				_oselect3.SetObjectActive(value);
			}
		}
	}

	public Vector2 selectAnchoredposition1
	{
		get
		{
			if (_oselectRectTransform1 != null)
			{
				return _oselectRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (selectAnchoredposition1 != value && _oselectRectTransform1 != null)
			{
				_oselectRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 selectAnchoredposition2
	{
		get
		{
			if (_oselectRectTransform2 != null)
			{
				return _oselectRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (selectAnchoredposition2 != value && _oselectRectTransform2 != null)
			{
				_oselectRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector2 selectAnchoredposition3
	{
		get
		{
			if (_oselectRectTransform3 != null)
			{
				return _oselectRectTransform3.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (selectAnchoredposition3 != value && _oselectRectTransform3 != null)
			{
				_oselectRectTransform3.anchoredPosition = value;
			}
		}
	}

	public Vector3 selectSize1
	{
		get
		{
			if (_oselectRectTransform1 != null)
			{
				return _oselectRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (selectSize1 != value && _oselectRectTransform1 != null)
			{
				_oselectRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 selectSize2
	{
		get
		{
			if (_oselectRectTransform2 != null)
			{
				return _oselectRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (selectSize2 != value && _oselectRectTransform2 != null)
			{
				_oselectRectTransform2.sizeDelta = value;
			}
		}
	}

	public Vector3 selectSize3
	{
		get
		{
			if (_oselectRectTransform3 != null)
			{
				return _oselectRectTransform3.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (selectSize3 != value && _oselectRectTransform3 != null)
			{
				_oselectRectTransform3.sizeDelta = value;
			}
		}
	}

	public bool selectEnabled1
	{
		get
		{
			if (_oselectImage1 != null)
			{
				return _oselectImage1.enabled;
			}
			return false;
		}
		set
		{
			if (selectEnabled1 != value && _oselectImage1 != null)
			{
				_oselectImage1.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool selectEnabled2
	{
		get
		{
			if (_oselectImage2 != null)
			{
				return _oselectImage2.enabled;
			}
			return false;
		}
		set
		{
			if (selectEnabled2 != value && _oselectImage2 != null)
			{
				_oselectImage2.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public bool selectEnabled3
	{
		get
		{
			if (_oselectImage3 != null)
			{
				return _oselectImage3.enabled;
			}
			return false;
		}
		set
		{
			if (selectEnabled3 != value && _oselectImage3 != null)
			{
				_oselectImage3.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Button.ButtonClickedEvent selectClicked1
	{
		get
		{
			if (_oselectButton1 != null)
			{
				return _oselectButton1.onClick;
			}
			return null;
		}
		set
		{
			if (selectClicked1 != value && _oselectButton1 != null)
			{
				_oselectButton1.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent selectClicked2
	{
		get
		{
			if (_oselectButton2 != null)
			{
				return _oselectButton2.onClick;
			}
			return null;
		}
		set
		{
			if (selectClicked2 != value && _oselectButton2 != null)
			{
				_oselectButton2.onClick = value;
			}
		}
	}

	public Button.ButtonClickedEvent selectClicked3
	{
		get
		{
			if (_oselectButton3 != null)
			{
				return _oselectButton3.onClick;
			}
			return null;
		}
		set
		{
			if (selectClicked3 != value && _oselectButton3 != null)
			{
				_oselectButton3.onClick = value;
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
			case "pvetdbuyweapon":
				_opvetdbuyweapon = transform.gameObject;
				uiRef.Set("pvetdbuyweapon", _opvetdbuyweapon.transform);
				break;
			case "Panel":
				_oPanel = transform.gameObject;
				uiRef.Set("Panel", _oPanel.transform);
				_oPanelRectTransform = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("PanelRectTransform", _oPanelRectTransform);
				break;
			case "montytxt":
				_omontytxt = transform.gameObject;
				uiRef.Set("montytxt", _omontytxt.transform);
				_omontytxtText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("montytxtText", _omontytxtText);
				break;
			case "startxt":
				_ostartxt = transform.gameObject;
				uiRef.Set("startxt", _ostartxt.transform);
				_ostartxtText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("startxtText", _ostartxtText);
				break;
			case "select1":
				_oselect1 = transform.gameObject;
				uiRef.Set("select1", _oselect1.transform);
				_oselectRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("selectRectTransform1", _oselectRectTransform1);
				_oselectImage1 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("selectImage1", _oselectImage1);
				_oselectButton1 = transform.gameObject.GetComponent<Button>();
				uiRef.Set("selectButton1", _oselectButton1);
				break;
			case "select2":
				_oselect2 = transform.gameObject;
				uiRef.Set("select2", _oselect2.transform);
				_oselectRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("selectRectTransform2", _oselectRectTransform2);
				_oselectImage2 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("selectImage2", _oselectImage2);
				_oselectButton2 = transform.gameObject.GetComponent<Button>();
				uiRef.Set("selectButton2", _oselectButton2);
				break;
			case "select3":
				_oselect3 = transform.gameObject;
				uiRef.Set("select3", _oselect3.transform);
				_oselectRectTransform3 = transform.gameObject.GetComponent<RectTransform>();
				uiRef.Set("selectRectTransform3", _oselectRectTransform3);
				_oselectImage3 = transform.gameObject.GetComponent<Image>();
				uiRef.Set("selectImage3", _oselectImage3);
				_oselectButton3 = transform.gameObject.GetComponent<Button>();
				uiRef.Set("selectButton3", _oselectButton3);
				break;
			}
		}
	}

	public string GetselectName(int index)
	{
		return index switch
		{
			1 => "select1", 
			2 => "select2", 
			3 => "select3", 
			_ => null, 
		};
	}

	public bool GetselectShow(int index)
	{
		return index switch
		{
			1 => selectShow1, 
			2 => selectShow2, 
			3 => selectShow3, 
			_ => false, 
		};
	}

	public void SetselectShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			selectShow1 = value;
			break;
		case 2:
			selectShow2 = value;
			break;
		case 3:
			selectShow3 = value;
			break;
		}
	}

	public Vector2 GetselectAnchoredposition(int index)
	{
		return index switch
		{
			1 => selectAnchoredposition1, 
			2 => selectAnchoredposition2, 
			3 => selectAnchoredposition3, 
			_ => Vector2.zero, 
		};
	}

	public void SetselectAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			selectAnchoredposition1 = value;
			break;
		case 2:
			selectAnchoredposition2 = value;
			break;
		case 3:
			selectAnchoredposition3 = value;
			break;
		}
	}

	public Vector3 GetselectSize(int index)
	{
		return index switch
		{
			1 => selectSize1, 
			2 => selectSize2, 
			3 => selectSize3, 
			_ => Vector3.zero, 
		};
	}

	public void SetselectSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			selectSize1 = value;
			break;
		case 2:
			selectSize2 = value;
			break;
		case 3:
			selectSize3 = value;
			break;
		}
	}

	public bool GetselectEnabled(int index)
	{
		return index switch
		{
			1 => selectEnabled1, 
			2 => selectEnabled2, 
			3 => selectEnabled3, 
			_ => false, 
		};
	}

	public void SetselectEnabled(int index, bool value)
	{
		switch (index)
		{
		case 1:
			selectEnabled1 = value;
			break;
		case 2:
			selectEnabled2 = value;
			break;
		case 3:
			selectEnabled3 = value;
			break;
		}
	}

	public Button.ButtonClickedEvent GetselectClicked(int index)
	{
		return index switch
		{
			1 => selectClicked1, 
			2 => selectClicked2, 
			3 => selectClicked3, 
			_ => null, 
		};
	}

	public void SetselectClicked(int index, Button.ButtonClickedEvent value)
	{
		switch (index)
		{
		case 1:
			selectClicked1 = value;
			break;
		case 2:
			selectClicked2 = value;
			break;
		case 3:
			selectClicked3 = value;
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
