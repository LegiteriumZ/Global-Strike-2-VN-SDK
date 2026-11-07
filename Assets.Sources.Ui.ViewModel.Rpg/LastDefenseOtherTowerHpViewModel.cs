using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Rpg;

[GameUiTest]
public class LastDefenseOtherTowerHpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oLastDefenseOtherTowerHp;

	private GameObject _oPanel;

	private GameObject _otips1;

	private GameObject _otips2;

	private RectTransform _otipsRectTransform1;

	private RectTransform _otipsRectTransform2;

	private Image _otipsImage1;

	private Image _otipsImage2;

	private GameObject _oinfo;

	private Text _oinfoText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "LastDefenseOtherTowerHp";

	public GameObject LastDefenseOtherTowerHpObj => _oLastDefenseOtherTowerHp;

	public bool LastDefenseOtherTowerHpShow
	{
		get
		{
			if (_oLastDefenseOtherTowerHp != null)
			{
				return _oLastDefenseOtherTowerHp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (LastDefenseOtherTowerHpShow != value && _oLastDefenseOtherTowerHp != null)
			{
				_oLastDefenseOtherTowerHp.SetObjectActive(value);
			}
		}
	}

	public bool PanelShow
	{
		get
		{
			if (_oPanel != null)
			{
				return _oPanel.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PanelShow != value && _oPanel != null)
			{
				_oPanel.SetObjectActive(value);
			}
		}
	}

	public bool tipsShow1
	{
		get
		{
			if (_otips1 != null)
			{
				return _otips1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (tipsShow1 != value && _otips1 != null)
			{
				_otips1.SetObjectActive(value);
			}
		}
	}

	public bool tipsShow2
	{
		get
		{
			if (_otips2 != null)
			{
				return _otips2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (tipsShow2 != value && _otips2 != null)
			{
				_otips2.SetObjectActive(value);
			}
		}
	}

	public Vector2 tipsAnchoredposition1
	{
		get
		{
			if (_otipsRectTransform1 != null)
			{
				return _otipsRectTransform1.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (tipsAnchoredposition1 != value && _otipsRectTransform1 != null)
			{
				_otipsRectTransform1.anchoredPosition = value;
			}
		}
	}

	public Vector2 tipsAnchoredposition2
	{
		get
		{
			if (_otipsRectTransform2 != null)
			{
				return _otipsRectTransform2.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (tipsAnchoredposition2 != value && _otipsRectTransform2 != null)
			{
				_otipsRectTransform2.anchoredPosition = value;
			}
		}
	}

	public Vector3 tipsSize1
	{
		get
		{
			if (_otipsRectTransform1 != null)
			{
				return _otipsRectTransform1.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (tipsSize1 != value && _otipsRectTransform1 != null)
			{
				_otipsRectTransform1.sizeDelta = value;
			}
		}
	}

	public Vector3 tipsSize2
	{
		get
		{
			if (_otipsRectTransform2 != null)
			{
				return _otipsRectTransform2.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (tipsSize2 != value && _otipsRectTransform2 != null)
			{
				_otipsRectTransform2.sizeDelta = value;
			}
		}
	}

	public Image tipsImage1
	{
		get
		{
			if (_otipsImage1 != null)
			{
				return _otipsImage1;
			}
			return null;
		}
		set
		{
			if (tipsImage1 != value && _otipsImage1 != null)
			{
				_otipsImage1 = value;
			}
		}
	}

	public Image tipsImage2
	{
		get
		{
			if (_otipsImage2 != null)
			{
				return _otipsImage2;
			}
			return null;
		}
		set
		{
			if (tipsImage2 != value && _otipsImage2 != null)
			{
				_otipsImage2 = value;
			}
		}
	}

	public bool infoShow
	{
		get
		{
			if (_oinfo != null)
			{
				return _oinfo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (infoShow != value && _oinfo != null)
			{
				_oinfo.SetObjectActive(value);
			}
		}
	}

	public string infoString
	{
		get
		{
			if (_oinfoText != null)
			{
				return _oinfoText.text;
			}
			return null;
		}
		set
		{
			if (infoString != value && _oinfoText != null)
			{
				_oinfoText.text = value;
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
			case "LastDefenseOtherTowerHp":
				_oLastDefenseOtherTowerHp = transform.gameObject;
				break;
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "tips1":
				_otips1 = transform.gameObject;
				_otipsRectTransform1 = transform.gameObject.GetComponent<RectTransform>();
				_otipsImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "tips2":
				_otips2 = transform.gameObject;
				_otipsRectTransform2 = transform.gameObject.GetComponent<RectTransform>();
				_otipsImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "info":
				_oinfo = transform.gameObject;
				_oinfoText = transform.gameObject.GetComponent<Text>();
				break;
			}
		}
	}

	public bool GettipsShow(int index)
	{
		return index switch
		{
			1 => tipsShow1, 
			2 => tipsShow2, 
			_ => false, 
		};
	}

	public void SettipsShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			tipsShow1 = value;
			break;
		case 2:
			tipsShow2 = value;
			break;
		}
	}

	public Vector2 GettipsAnchoredposition(int index)
	{
		return index switch
		{
			1 => tipsAnchoredposition1, 
			2 => tipsAnchoredposition2, 
			_ => Vector2.zero, 
		};
	}

	public void SettipsAnchoredposition(int index, Vector2 value)
	{
		switch (index)
		{
		case 1:
			tipsAnchoredposition1 = value;
			break;
		case 2:
			tipsAnchoredposition2 = value;
			break;
		}
	}

	public Vector3 GettipsSize(int index)
	{
		return index switch
		{
			1 => tipsSize1, 
			2 => tipsSize2, 
			_ => Vector3.zero, 
		};
	}

	public void SettipsSize(int index, Vector3 value)
	{
		switch (index)
		{
		case 1:
			tipsSize1 = value;
			break;
		case 2:
			tipsSize2 = value;
			break;
		}
	}

	public Image GettipsImage(int index)
	{
		return index switch
		{
			1 => tipsImage1, 
			2 => tipsImage2, 
			_ => null, 
		};
	}

	public void SettipsImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			tipsImage1 = value;
			break;
		case 2:
			tipsImage2 = value;
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
