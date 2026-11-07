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

namespace Assets.Sources.Ui.ViewModel.HulaoguanModel;

[GameUiTest]
public class HuLaoGuanTopViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oContainer0;

	private GameObject _oContainer1;

	private GameObject _oContainer2;

	private GameObject _oImage0;

	private GameObject _oImage1;

	private GameObject _oImage2;

	private Image _oImageImage0;

	private Image _oImageImage1;

	private Image _oImageImage2;

	private GameObject _oRotationImage0;

	private GameObject _oRotationImage1;

	private GameObject _oRotationImage2;

	private Image _oRotationImageImage0;

	private Image _oRotationImageImage1;

	private Image _oRotationImageImage2;

	private GameObject _ohp;

	private Image _ohpImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/hulaoguanmodel";

	private string _resourceAssetName = "hulaoguantop";

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

	public bool ContainerShow0
	{
		get
		{
			if (_oContainer0 != null)
			{
				return _oContainer0.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ContainerShow0 != value && _oContainer0 != null)
			{
				_oContainer0.SetObjectActive(value);
			}
		}
	}

	public bool ContainerShow1
	{
		get
		{
			if (_oContainer1 != null)
			{
				return _oContainer1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ContainerShow1 != value && _oContainer1 != null)
			{
				_oContainer1.SetObjectActive(value);
			}
		}
	}

	public bool ContainerShow2
	{
		get
		{
			if (_oContainer2 != null)
			{
				return _oContainer2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ContainerShow2 != value && _oContainer2 != null)
			{
				_oContainer2.SetObjectActive(value);
			}
		}
	}

	public Sprite ImageSprite0
	{
		get
		{
			if (_oImageImage0 != null)
			{
				return _oImageImage0.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite0 != value && _oImageImage0 != null)
			{
				_oImageImage0.sprite = value;
			}
		}
	}

	public Sprite ImageSprite1
	{
		get
		{
			if (_oImageImage1 != null)
			{
				return _oImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite1 != value && _oImageImage1 != null)
			{
				_oImageImage1.sprite = value;
			}
		}
	}

	public Sprite ImageSprite2
	{
		get
		{
			if (_oImageImage2 != null)
			{
				return _oImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (ImageSprite2 != value && _oImageImage2 != null)
			{
				_oImageImage2.sprite = value;
			}
		}
	}

	public Image ImageImage0
	{
		get
		{
			if (_oImageImage0 != null)
			{
				return _oImageImage0;
			}
			return null;
		}
		set
		{
			if (ImageImage0 != value && _oImageImage0 != null)
			{
				_oImageImage0 = value;
			}
		}
	}

	public Image ImageImage1
	{
		get
		{
			if (_oImageImage1 != null)
			{
				return _oImageImage1;
			}
			return null;
		}
		set
		{
			if (ImageImage1 != value && _oImageImage1 != null)
			{
				_oImageImage1 = value;
			}
		}
	}

	public Image ImageImage2
	{
		get
		{
			if (_oImageImage2 != null)
			{
				return _oImageImage2;
			}
			return null;
		}
		set
		{
			if (ImageImage2 != value && _oImageImage2 != null)
			{
				_oImageImage2 = value;
			}
		}
	}

	public float RotationImageFillamount0
	{
		get
		{
			if (_oRotationImageImage0 != null)
			{
				return _oRotationImageImage0.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RotationImageFillamount0 != value && _oRotationImageImage0 != null)
			{
				_oRotationImageImage0.fillAmount = value;
			}
		}
	}

	public float RotationImageFillamount1
	{
		get
		{
			if (_oRotationImageImage1 != null)
			{
				return _oRotationImageImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RotationImageFillamount1 != value && _oRotationImageImage1 != null)
			{
				_oRotationImageImage1.fillAmount = value;
			}
		}
	}

	public float RotationImageFillamount2
	{
		get
		{
			if (_oRotationImageImage2 != null)
			{
				return _oRotationImageImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (RotationImageFillamount2 != value && _oRotationImageImage2 != null)
			{
				_oRotationImageImage2.fillAmount = value;
			}
		}
	}

	public float hpFillamount
	{
		get
		{
			if (_ohpImage != null)
			{
				return _ohpImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (hpFillamount != value && _ohpImage != null)
			{
				_ohpImage.fillAmount = value;
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
			case "Container0":
				_oContainer0 = transform.gameObject;
				break;
			case "Container1":
				_oContainer1 = transform.gameObject;
				break;
			case "Container2":
				_oContainer2 = transform.gameObject;
				break;
			case "Image0":
				_oImage0 = transform.gameObject;
				_oImageImage0 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image1":
				_oImage1 = transform.gameObject;
				_oImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Image2":
				_oImage2 = transform.gameObject;
				_oImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "RotationImage0":
				_oRotationImage0 = transform.gameObject;
				_oRotationImageImage0 = transform.gameObject.GetComponent<Image>();
				break;
			case "RotationImage1":
				_oRotationImage1 = transform.gameObject;
				_oRotationImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "RotationImage2":
				_oRotationImage2 = transform.gameObject;
				_oRotationImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "hp":
				_ohp = transform.gameObject;
				_ohpImage = transform.gameObject.GetComponent<Image>();
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

	public bool GetContainerShow(int index)
	{
		return index switch
		{
			0 => ContainerShow0, 
			1 => ContainerShow1, 
			2 => ContainerShow2, 
			_ => false, 
		};
	}

	public void SetContainerShow(int index, bool value)
	{
		switch (index)
		{
		case 0:
			ContainerShow0 = value;
			break;
		case 1:
			ContainerShow1 = value;
			break;
		case 2:
			ContainerShow2 = value;
			break;
		}
	}

	public int GetContainerCount()
	{
		return 2;
	}

	public Sprite GetImageSprite(int index)
	{
		return index switch
		{
			0 => ImageSprite0, 
			1 => ImageSprite1, 
			2 => ImageSprite2, 
			_ => null, 
		};
	}

	public void SetImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 0:
			ImageSprite0 = value;
			break;
		case 1:
			ImageSprite1 = value;
			break;
		case 2:
			ImageSprite2 = value;
			break;
		}
	}

	public int GetImageCount()
	{
		return 2;
	}

	public Image GetImageImage(int index)
	{
		return index switch
		{
			0 => ImageImage0, 
			1 => ImageImage1, 
			2 => ImageImage2, 
			_ => null, 
		};
	}

	public void SetImageImage(int index, Image value)
	{
		switch (index)
		{
		case 0:
			ImageImage0 = value;
			break;
		case 1:
			ImageImage1 = value;
			break;
		case 2:
			ImageImage2 = value;
			break;
		}
	}

	public float GetRotationImageFillamount(int index)
	{
		return index switch
		{
			0 => RotationImageFillamount0, 
			1 => RotationImageFillamount1, 
			2 => RotationImageFillamount2, 
			_ => 0f, 
		};
	}

	public void SetRotationImageFillamount(int index, float value)
	{
		switch (index)
		{
		case 0:
			RotationImageFillamount0 = value;
			break;
		case 1:
			RotationImageFillamount1 = value;
			break;
		case 2:
			RotationImageFillamount2 = value;
			break;
		}
	}

	public int GetRotationImageCount()
	{
		return 2;
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
