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

namespace Assets.Sources.Ui.ViewModel.Guofengmodel;

[GameUiTest]
public class Guofengmodel_timeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oboxhp;

	private GameObject _onum;

	private Text _onumText;

	private GameObject _oboxhp_p;

	private Image _oboxhp_pImage;

	private GameObject _oboxNum;

	private GameObject _oboxNm_p;

	private Image _oboxNm_pImage;

	private GameObject _olockIcon;

	private GameObject _obox1;

	private GameObject _obox2;

	private GameObject _obox3;

	private Image _oboxImage1;

	private Image _oboxImage2;

	private Image _oboxImage3;

	private GameObject _of_key;

	private GameObject _of_key_p;

	private Image _of_key_pImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/guofengmodel";

	private string _resourceAssetName = "guofengmodel_time";

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

	public bool boxhpShow
	{
		get
		{
			if (_oboxhp != null)
			{
				return _oboxhp.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boxhpShow != value && _oboxhp != null)
			{
				_oboxhp.SetObjectActive(value);
			}
		}
	}

	public string numString
	{
		get
		{
			if (_onumText != null)
			{
				return _onumText.text;
			}
			return null;
		}
		set
		{
			if (numString != value && _onumText != null)
			{
				_onumText.text = value;
			}
		}
	}

	public float boxhp_pFillamount
	{
		get
		{
			if (_oboxhp_pImage != null)
			{
				return _oboxhp_pImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (boxhp_pFillamount != value && _oboxhp_pImage != null)
			{
				_oboxhp_pImage.fillAmount = value;
			}
		}
	}

	public bool boxNumShow
	{
		get
		{
			if (_oboxNum != null)
			{
				return _oboxNum.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (boxNumShow != value && _oboxNum != null)
			{
				_oboxNum.SetObjectActive(value);
			}
		}
	}

	public Sprite boxNm_pSprite
	{
		get
		{
			if (_oboxNm_pImage != null)
			{
				return _oboxNm_pImage.sprite;
			}
			return null;
		}
		set
		{
			if (boxNm_pSprite != value && _oboxNm_pImage != null)
			{
				_oboxNm_pImage.sprite = value;
			}
		}
	}

	public float boxNm_pFillamount
	{
		get
		{
			if (_oboxNm_pImage != null)
			{
				return _oboxNm_pImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (boxNm_pFillamount != value && _oboxNm_pImage != null)
			{
				_oboxNm_pImage.fillAmount = value;
			}
		}
	}

	public bool lockIconShow
	{
		get
		{
			if (_olockIcon != null)
			{
				return _olockIcon.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (lockIconShow != value && _olockIcon != null)
			{
				_olockIcon.SetObjectActive(value);
			}
		}
	}

	public Sprite boxSprite1
	{
		get
		{
			if (_oboxImage1 != null)
			{
				return _oboxImage1.sprite;
			}
			return null;
		}
		set
		{
			if (boxSprite1 != value && _oboxImage1 != null)
			{
				_oboxImage1.sprite = value;
			}
		}
	}

	public Sprite boxSprite2
	{
		get
		{
			if (_oboxImage2 != null)
			{
				return _oboxImage2.sprite;
			}
			return null;
		}
		set
		{
			if (boxSprite2 != value && _oboxImage2 != null)
			{
				_oboxImage2.sprite = value;
			}
		}
	}

	public Sprite boxSprite3
	{
		get
		{
			if (_oboxImage3 != null)
			{
				return _oboxImage3.sprite;
			}
			return null;
		}
		set
		{
			if (boxSprite3 != value && _oboxImage3 != null)
			{
				_oboxImage3.sprite = value;
			}
		}
	}

	public bool f_keyShow
	{
		get
		{
			if (_of_key != null)
			{
				return _of_key.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (f_keyShow != value && _of_key != null)
			{
				_of_key.SetObjectActive(value);
			}
		}
	}

	public float f_key_pFillamount
	{
		get
		{
			if (_of_key_pImage != null)
			{
				return _of_key_pImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (f_key_pFillamount != value && _of_key_pImage != null)
			{
				_of_key_pImage.fillAmount = value;
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
			case "boxhp":
				_oboxhp = transform.gameObject;
				break;
			case "num":
				_onum = transform.gameObject;
				_onumText = transform.gameObject.GetComponent<Text>();
				break;
			case "boxhp_p":
				_oboxhp_p = transform.gameObject;
				_oboxhp_pImage = transform.gameObject.GetComponent<Image>();
				break;
			case "boxNum":
				_oboxNum = transform.gameObject;
				break;
			case "boxNm_p":
				_oboxNm_p = transform.gameObject;
				_oboxNm_pImage = transform.gameObject.GetComponent<Image>();
				break;
			case "lockIcon":
				_olockIcon = transform.gameObject;
				break;
			case "box1":
				_obox1 = transform.gameObject;
				_oboxImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "box2":
				_obox2 = transform.gameObject;
				_oboxImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "box3":
				_obox3 = transform.gameObject;
				_oboxImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "f_key":
				_of_key = transform.gameObject;
				break;
			case "f_key_p":
				_of_key_p = transform.gameObject;
				_of_key_pImage = transform.gameObject.GetComponent<Image>();
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

	public Sprite GetboxSprite(int index)
	{
		return index switch
		{
			1 => boxSprite1, 
			2 => boxSprite2, 
			3 => boxSprite3, 
			_ => null, 
		};
	}

	public void SetboxSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			boxSprite1 = value;
			break;
		case 2:
			boxSprite2 = value;
			break;
		case 3:
			boxSprite3 = value;
			break;
		}
	}

	public int GetboxCount()
	{
		return 3;
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
