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

namespace Assets.Sources.Ui.ViewModel.Pve;

[GameUiTest]
public class Td5spidereggnumViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _otd5spidereggnum;

	private GameObject _ospidereggbackImg;

	private Image _ospidereggbackImgImage;

	private GameObject _oeggnumtxt;

	private Text _oeggnumtxtText;

	private GameObject _oeggdeadnumtxt;

	private Text _oeggdeadnumtxtText;

	private GameObject _viewGameObject;

	private UiReferences uiRef;

	private string _resourceBundleName = "uiprefabs/pve";

	private string _resourceAssetName = "Td5spidereggnum";

	public UiReferences UI => uiRef;

	public GameObject td5spidereggnumObj => _otd5spidereggnum;

	public bool td5spidereggnumShow
	{
		get
		{
			if (_otd5spidereggnum != null)
			{
				return _otd5spidereggnum.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (td5spidereggnumShow != value && _otd5spidereggnum != null)
			{
				_otd5spidereggnum.SetObjectActive(value);
			}
		}
	}

	public bool spidereggbackImgShow
	{
		get
		{
			if (_ospidereggbackImg != null)
			{
				return _ospidereggbackImg.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (spidereggbackImgShow != value && _ospidereggbackImg != null)
			{
				_ospidereggbackImg.SetObjectActive(value);
			}
		}
	}

	public Sprite spidereggbackImgSprite
	{
		get
		{
			if (_ospidereggbackImgImage != null)
			{
				return _ospidereggbackImgImage.sprite;
			}
			return null;
		}
		set
		{
			if (spidereggbackImgSprite != value && _ospidereggbackImgImage != null)
			{
				_ospidereggbackImgImage.sprite = value;
			}
		}
	}

	public bool eggnumtxtShow
	{
		get
		{
			if (_oeggnumtxt != null)
			{
				return _oeggnumtxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (eggnumtxtShow != value && _oeggnumtxt != null)
			{
				_oeggnumtxt.SetObjectActive(value);
			}
		}
	}

	public string eggnumtxtString
	{
		get
		{
			if (_oeggnumtxtText != null)
			{
				return _oeggnumtxtText.text;
			}
			return null;
		}
		set
		{
			if (eggnumtxtString != value && _oeggnumtxtText != null)
			{
				_oeggnumtxtText.text = value;
			}
		}
	}

	public bool eggdeadnumtxtShow
	{
		get
		{
			if (_oeggdeadnumtxt != null)
			{
				return _oeggdeadnumtxt.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (eggdeadnumtxtShow != value && _oeggdeadnumtxt != null)
			{
				_oeggdeadnumtxt.SetObjectActive(value);
			}
		}
	}

	public string eggdeadnumtxtString
	{
		get
		{
			if (_oeggdeadnumtxtText != null)
			{
				return _oeggdeadnumtxtText.text;
			}
			return null;
		}
		set
		{
			if (eggdeadnumtxtString != value && _oeggdeadnumtxtText != null)
			{
				_oeggdeadnumtxtText.text = value;
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
			case "td5spidereggnum":
				_otd5spidereggnum = transform.gameObject;
				uiRef.Set("td5spidereggnum", _otd5spidereggnum.transform);
				break;
			case "spidereggbackImg":
				_ospidereggbackImg = transform.gameObject;
				uiRef.Set("spidereggbackImg", _ospidereggbackImg.transform);
				_ospidereggbackImgImage = transform.gameObject.GetComponent<Image>();
				uiRef.Set("spidereggbackImgImage", _ospidereggbackImgImage);
				break;
			case "eggnumtxt":
				_oeggnumtxt = transform.gameObject;
				uiRef.Set("eggnumtxt", _oeggnumtxt.transform);
				_oeggnumtxtText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("eggnumtxtText", _oeggnumtxtText);
				break;
			case "eggdeadnumtxt":
				_oeggdeadnumtxt = transform.gameObject;
				uiRef.Set("eggdeadnumtxt", _oeggdeadnumtxt.transform);
				_oeggdeadnumtxtText = transform.gameObject.GetComponent<Text>();
				uiRef.Set("eggdeadnumtxtText", _oeggdeadnumtxtText);
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
