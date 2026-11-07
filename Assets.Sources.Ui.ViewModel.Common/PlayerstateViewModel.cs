using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class PlayerstateViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oHealthProgress;

	private Image _oHealthProgressImage;

	private GameObject _oCareer;

	private Image _oCareerImage;

	private GameObject _oHelmet;

	private Image _oHelmetImage;

	private GameObject _oBulletProof;

	private Image _oBulletProofImage;

	private GameObject _oHealthNumber;

	private Text _oHealthNumberText;

	private GameObject _oTitle;

	private Image _oTitleImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Playerstate";

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

	public float HealthProgressFillamount
	{
		get
		{
			if (_oHealthProgressImage != null)
			{
				return _oHealthProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (HealthProgressFillamount != value && _oHealthProgressImage != null)
			{
				_oHealthProgressImage.fillAmount = value;
			}
		}
	}

	public Sprite CareerSprite
	{
		get
		{
			if (_oCareerImage != null)
			{
				return _oCareerImage.sprite;
			}
			return null;
		}
		set
		{
			if (CareerSprite != value && _oCareerImage != null)
			{
				_oCareerImage.sprite = value;
			}
		}
	}

	public Sprite HelmetSprite
	{
		get
		{
			if (_oHelmetImage != null)
			{
				return _oHelmetImage.sprite;
			}
			return null;
		}
		set
		{
			if (HelmetSprite != value && _oHelmetImage != null)
			{
				_oHelmetImage.sprite = value;
			}
		}
	}

	public Sprite BulletProofSprite
	{
		get
		{
			if (_oBulletProofImage != null)
			{
				return _oBulletProofImage.sprite;
			}
			return null;
		}
		set
		{
			if (BulletProofSprite != value && _oBulletProofImage != null)
			{
				_oBulletProofImage.sprite = value;
			}
		}
	}

	public string HealthNumberString
	{
		get
		{
			if (_oHealthNumberText != null)
			{
				return _oHealthNumberText.text;
			}
			return null;
		}
		set
		{
			if (HealthNumberString != value && _oHealthNumberText != null)
			{
				_oHealthNumberText.text = value;
			}
		}
	}

	public bool TitleShow
	{
		get
		{
			if (_oTitle != null)
			{
				return _oTitle.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TitleShow != value && _oTitle != null)
			{
				_oTitle.SetObjectActive(value);
			}
		}
	}

	public Sprite TitleSprite
	{
		get
		{
			if (_oTitleImage != null)
			{
				return _oTitleImage.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite != value && _oTitleImage != null)
			{
				_oTitleImage.sprite = value;
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
			case "HealthProgress":
				_oHealthProgress = transform.gameObject;
				_oHealthProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Career":
				_oCareer = transform.gameObject;
				_oCareerImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Helmet":
				_oHelmet = transform.gameObject;
				_oHelmetImage = transform.gameObject.GetComponent<Image>();
				break;
			case "BulletProof":
				_oBulletProof = transform.gameObject;
				_oBulletProofImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HealthNumber":
				_oHealthNumber = transform.gameObject;
				_oHealthNumberText = transform.gameObject.GetComponent<Text>();
				break;
			case "Title":
				_oTitle = transform.gameObject;
				_oTitleImage = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
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

	public void CareerNtvsize()
	{
		if (_oCareerImage != null)
		{
			_oCareerImage.SetNativeSize();
		}
	}

	public void TitleNtvsize()
	{
		if (_oTitleImage != null)
		{
			_oTitleImage.SetNativeSize();
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
