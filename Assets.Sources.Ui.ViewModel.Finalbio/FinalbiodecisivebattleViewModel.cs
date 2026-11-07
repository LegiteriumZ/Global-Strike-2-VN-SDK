using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Finalbio;

[GameUiTest]
public class FinalbiodecisivebattleViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oTop;

	private GameObject _oHeroText;

	private Text _oHeroTextText;

	private GameObject _oEmpressText;

	private Text _oEmpressTextText;

	private GameObject _oUltimateTimeText;

	private Text _oUltimateTimeTextText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/finalbio";

	private string _resourceAssetName = "Finalbiodecisivebattle";

	public bool TopShow
	{
		get
		{
			if (_oTop != null)
			{
				return _oTop.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TopShow != value && _oTop != null)
			{
				_oTop.SetObjectActive(value);
			}
		}
	}

	public string HeroTextString
	{
		get
		{
			if (_oHeroTextText != null)
			{
				return _oHeroTextText.text;
			}
			return null;
		}
		set
		{
			if (HeroTextString != value && _oHeroTextText != null)
			{
				_oHeroTextText.text = value;
			}
		}
	}

	public string EmpressTextString
	{
		get
		{
			if (_oEmpressTextText != null)
			{
				return _oEmpressTextText.text;
			}
			return null;
		}
		set
		{
			if (EmpressTextString != value && _oEmpressTextText != null)
			{
				_oEmpressTextText.text = value;
			}
		}
	}

	public string UltimateTimeTextString
	{
		get
		{
			if (_oUltimateTimeTextText != null)
			{
				return _oUltimateTimeTextText.text;
			}
			return null;
		}
		set
		{
			if (UltimateTimeTextString != value && _oUltimateTimeTextText != null)
			{
				_oUltimateTimeTextText.text = value;
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
			case "Top":
				_oTop = transform.gameObject;
				break;
			case "HeroText":
				_oHeroText = transform.gameObject;
				_oHeroTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "EmpressText":
				_oEmpressText = transform.gameObject;
				_oEmpressTextText = transform.gameObject.GetComponent<Text>();
				break;
			case "UltimateTimeText":
				_oUltimateTimeText = transform.gameObject;
				_oUltimateTimeTextText = transform.gameObject.GetComponent<Text>();
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
