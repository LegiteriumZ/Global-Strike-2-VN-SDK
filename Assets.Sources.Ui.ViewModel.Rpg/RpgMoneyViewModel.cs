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
public class RpgMoneyViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRpgMoney;

	private GameObject _oPanel;

	private GameObject _omoneyicon;

	private Image _omoneyiconImage;

	private GameObject _oprice;

	private Text _opriceText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/rpg";

	private string _resourceAssetName = "RpgMoney";

	public GameObject RpgMoneyObj => _oRpgMoney;

	public bool RpgMoneyShow
	{
		get
		{
			if (_oRpgMoney != null)
			{
				return _oRpgMoney.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgMoneyShow != value && _oRpgMoney != null)
			{
				_oRpgMoney.SetObjectActive(value);
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

	public bool moneyiconShow
	{
		get
		{
			if (_omoneyicon != null)
			{
				return _omoneyicon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (moneyiconShow != value && _omoneyicon != null)
			{
				_omoneyicon.SetObjectActive(value);
			}
		}
	}

	public Image moneyiconImage
	{
		get
		{
			if (_omoneyiconImage != null)
			{
				return _omoneyiconImage;
			}
			return null;
		}
		set
		{
			if (moneyiconImage != value && _omoneyiconImage != null)
			{
				_omoneyiconImage = value;
			}
		}
	}

	public bool priceShow
	{
		get
		{
			if (_oprice != null)
			{
				return _oprice.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (priceShow != value && _oprice != null)
			{
				_oprice.SetObjectActive(value);
			}
		}
	}

	public string priceString
	{
		get
		{
			if (_opriceText != null)
			{
				return _opriceText.text;
			}
			return null;
		}
		set
		{
			if (priceString != value && _opriceText != null)
			{
				_opriceText.text = value;
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
			case "RpgMoney":
				_oRpgMoney = transform.gameObject;
				break;
			case "Panel":
				_oPanel = transform.gameObject;
				break;
			case "moneyicon":
				_omoneyicon = transform.gameObject;
				_omoneyiconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "price":
				_oprice = transform.gameObject;
				_opriceText = transform.gameObject.GetComponent<Text>();
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
