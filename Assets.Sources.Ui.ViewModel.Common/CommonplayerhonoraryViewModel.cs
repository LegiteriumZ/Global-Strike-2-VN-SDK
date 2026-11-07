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
public class CommonplayerhonoraryViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oHonor1;

	private GameObject _oHonor2;

	private GameObject _oHonor3;

	private GameObject _oHonor4;

	private GameObject _oHonor5;

	private GameObject _oHonorImage1;

	private GameObject _oHonorImage2;

	private GameObject _oHonorImage3;

	private GameObject _oHonorImage4;

	private GameObject _oHonorImage5;

	private Image _oHonorImageImage1;

	private Image _oHonorImageImage2;

	private Image _oHonorImageImage3;

	private Image _oHonorImageImage4;

	private Image _oHonorImageImage5;

	private GameObject _oGlory;

	private GameObject _oIcon;

	private Image _oIconImage;

	private GameObject _oName;

	private Text _oNameText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "commonplayerhonorary";

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

	public bool HonorShow1
	{
		get
		{
			if (_oHonor1 != null)
			{
				return _oHonor1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonorShow1 != value && _oHonor1 != null)
			{
				_oHonor1.SetObjectActive(value);
			}
		}
	}

	public bool HonorShow2
	{
		get
		{
			if (_oHonor2 != null)
			{
				return _oHonor2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonorShow2 != value && _oHonor2 != null)
			{
				_oHonor2.SetObjectActive(value);
			}
		}
	}

	public bool HonorShow3
	{
		get
		{
			if (_oHonor3 != null)
			{
				return _oHonor3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonorShow3 != value && _oHonor3 != null)
			{
				_oHonor3.SetObjectActive(value);
			}
		}
	}

	public bool HonorShow4
	{
		get
		{
			if (_oHonor4 != null)
			{
				return _oHonor4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonorShow4 != value && _oHonor4 != null)
			{
				_oHonor4.SetObjectActive(value);
			}
		}
	}

	public bool HonorShow5
	{
		get
		{
			if (_oHonor5 != null)
			{
				return _oHonor5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (HonorShow5 != value && _oHonor5 != null)
			{
				_oHonor5.SetObjectActive(value);
			}
		}
	}

	public Sprite HonorImageSprite1
	{
		get
		{
			if (_oHonorImageImage1 != null)
			{
				return _oHonorImageImage1.sprite;
			}
			return null;
		}
		set
		{
			if (HonorImageSprite1 != value && _oHonorImageImage1 != null)
			{
				_oHonorImageImage1.sprite = value;
			}
		}
	}

	public Sprite HonorImageSprite2
	{
		get
		{
			if (_oHonorImageImage2 != null)
			{
				return _oHonorImageImage2.sprite;
			}
			return null;
		}
		set
		{
			if (HonorImageSprite2 != value && _oHonorImageImage2 != null)
			{
				_oHonorImageImage2.sprite = value;
			}
		}
	}

	public Sprite HonorImageSprite3
	{
		get
		{
			if (_oHonorImageImage3 != null)
			{
				return _oHonorImageImage3.sprite;
			}
			return null;
		}
		set
		{
			if (HonorImageSprite3 != value && _oHonorImageImage3 != null)
			{
				_oHonorImageImage3.sprite = value;
			}
		}
	}

	public Sprite HonorImageSprite4
	{
		get
		{
			if (_oHonorImageImage4 != null)
			{
				return _oHonorImageImage4.sprite;
			}
			return null;
		}
		set
		{
			if (HonorImageSprite4 != value && _oHonorImageImage4 != null)
			{
				_oHonorImageImage4.sprite = value;
			}
		}
	}

	public Sprite HonorImageSprite5
	{
		get
		{
			if (_oHonorImageImage5 != null)
			{
				return _oHonorImageImage5.sprite;
			}
			return null;
		}
		set
		{
			if (HonorImageSprite5 != value && _oHonorImageImage5 != null)
			{
				_oHonorImageImage5.sprite = value;
			}
		}
	}

	public bool GloryShow
	{
		get
		{
			if (_oGlory != null)
			{
				return _oGlory.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GloryShow != value && _oGlory != null)
			{
				_oGlory.SetObjectActive(value);
			}
		}
	}

	public Sprite IconSprite
	{
		get
		{
			if (_oIconImage != null)
			{
				return _oIconImage.sprite;
			}
			return null;
		}
		set
		{
			if (IconSprite != value && _oIconImage != null)
			{
				_oIconImage.sprite = value;
			}
		}
	}

	public string NameString
	{
		get
		{
			if (_oNameText != null)
			{
				return _oNameText.text;
			}
			return null;
		}
		set
		{
			if (NameString != value && _oNameText != null)
			{
				_oNameText.text = value;
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
			case "Honor1":
				_oHonor1 = transform.gameObject;
				break;
			case "Honor2":
				_oHonor2 = transform.gameObject;
				break;
			case "Honor3":
				_oHonor3 = transform.gameObject;
				break;
			case "Honor4":
				_oHonor4 = transform.gameObject;
				break;
			case "Honor5":
				_oHonor5 = transform.gameObject;
				break;
			case "HonorImage1":
				_oHonorImage1 = transform.gameObject;
				_oHonorImageImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonorImage2":
				_oHonorImage2 = transform.gameObject;
				_oHonorImageImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonorImage3":
				_oHonorImage3 = transform.gameObject;
				_oHonorImageImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonorImage4":
				_oHonorImage4 = transform.gameObject;
				_oHonorImageImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "HonorImage5":
				_oHonorImage5 = transform.gameObject;
				_oHonorImageImage5 = transform.gameObject.GetComponent<Image>();
				break;
			case "Glory":
				_oGlory = transform.gameObject;
				break;
			case "Icon":
				_oIcon = transform.gameObject;
				_oIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Name":
				_oName = transform.gameObject;
				_oNameText = transform.gameObject.GetComponent<Text>();
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

	public bool GetHonorShow(int index)
	{
		return index switch
		{
			1 => HonorShow1, 
			2 => HonorShow2, 
			3 => HonorShow3, 
			4 => HonorShow4, 
			5 => HonorShow5, 
			_ => false, 
		};
	}

	public void SetHonorShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			HonorShow1 = value;
			break;
		case 2:
			HonorShow2 = value;
			break;
		case 3:
			HonorShow3 = value;
			break;
		case 4:
			HonorShow4 = value;
			break;
		case 5:
			HonorShow5 = value;
			break;
		}
	}

	public int GetHonorCount()
	{
		return 5;
	}

	public Sprite GetHonorImageSprite(int index)
	{
		return index switch
		{
			1 => HonorImageSprite1, 
			2 => HonorImageSprite2, 
			3 => HonorImageSprite3, 
			4 => HonorImageSprite4, 
			5 => HonorImageSprite5, 
			_ => null, 
		};
	}

	public void SetHonorImageSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			HonorImageSprite1 = value;
			break;
		case 2:
			HonorImageSprite2 = value;
			break;
		case 3:
			HonorImageSprite3 = value;
			break;
		case 4:
			HonorImageSprite4 = value;
			break;
		case 5:
			HonorImageSprite5 = value;
			break;
		}
	}

	public int GetHonorImageCount()
	{
		return 5;
	}

	public void HonorImageNtvsize1()
	{
		if (_oHonorImageImage1 != null)
		{
			_oHonorImageImage1.SetNativeSize();
		}
	}

	public void HonorImageNtvsize2()
	{
		if (_oHonorImageImage2 != null)
		{
			_oHonorImageImage2.SetNativeSize();
		}
	}

	public void HonorImageNtvsize3()
	{
		if (_oHonorImageImage3 != null)
		{
			_oHonorImageImage3.SetNativeSize();
		}
	}

	public void HonorImageNtvsize4()
	{
		if (_oHonorImageImage4 != null)
		{
			_oHonorImageImage4.SetNativeSize();
		}
	}

	public void HonorImageNtvsize5()
	{
		if (_oHonorImageImage5 != null)
		{
			_oHonorImageImage5.SetNativeSize();
		}
	}

	public void CallHonorImageNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			HonorImageNtvsize1();
			break;
		case 2:
			HonorImageNtvsize2();
			break;
		case 3:
			HonorImageNtvsize3();
			break;
		case 4:
			HonorImageNtvsize4();
			break;
		case 5:
			HonorImageNtvsize5();
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
