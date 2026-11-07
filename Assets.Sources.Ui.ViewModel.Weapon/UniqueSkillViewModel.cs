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

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class UniqueSkillViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBuff1;

	private GameObject _oBuff2;

	private GameObject _oBuff3;

	private GameObject _oBuff4;

	private Image _oBuffImage1;

	private Image _oBuffImage2;

	private Image _oBuffImage3;

	private Image _oBuffImage4;

	private GameObject _oWord1;

	private GameObject _oWord2;

	private GameObject _oWord3;

	private GameObject _oWord4;

	private Image _oWordImage1;

	private Image _oWordImage2;

	private Image _oWordImage3;

	private Image _oWordImage4;

	private GameObject _oLight1;

	private GameObject _oLight2;

	private GameObject _oLight3;

	private GameObject _oLight4;

	private Image _oLightImage1;

	private Image _oLightImage2;

	private Image _oLightImage3;

	private Image _oLightImage4;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "UniqueSkill";

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

	public bool ShowShow
	{
		get
		{
			if (_oShow != null)
			{
				return _oShow.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ShowShow != value && _oShow != null)
			{
				_oShow.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow1
	{
		get
		{
			if (_oBuff1 != null)
			{
				return _oBuff1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow1 != value && _oBuff1 != null)
			{
				_oBuff1.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow2
	{
		get
		{
			if (_oBuff2 != null)
			{
				return _oBuff2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow2 != value && _oBuff2 != null)
			{
				_oBuff2.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow3
	{
		get
		{
			if (_oBuff3 != null)
			{
				return _oBuff3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow3 != value && _oBuff3 != null)
			{
				_oBuff3.SetObjectActive(value);
			}
		}
	}

	public bool BuffShow4
	{
		get
		{
			if (_oBuff4 != null)
			{
				return _oBuff4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffShow4 != value && _oBuff4 != null)
			{
				_oBuff4.SetObjectActive(value);
			}
		}
	}

	public Sprite BuffSprite1
	{
		get
		{
			if (_oBuffImage1 != null)
			{
				return _oBuffImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite1 != value && _oBuffImage1 != null)
			{
				_oBuffImage1.sprite = value;
			}
		}
	}

	public Sprite BuffSprite2
	{
		get
		{
			if (_oBuffImage2 != null)
			{
				return _oBuffImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite2 != value && _oBuffImage2 != null)
			{
				_oBuffImage2.sprite = value;
			}
		}
	}

	public Sprite BuffSprite3
	{
		get
		{
			if (_oBuffImage3 != null)
			{
				return _oBuffImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite3 != value && _oBuffImage3 != null)
			{
				_oBuffImage3.sprite = value;
			}
		}
	}

	public Sprite BuffSprite4
	{
		get
		{
			if (_oBuffImage4 != null)
			{
				return _oBuffImage4.sprite;
			}
			return null;
		}
		set
		{
			if (BuffSprite4 != value && _oBuffImage4 != null)
			{
				_oBuffImage4.sprite = value;
			}
		}
	}

	public Sprite WordSprite1
	{
		get
		{
			if (_oWordImage1 != null)
			{
				return _oWordImage1.sprite;
			}
			return null;
		}
		set
		{
			if (WordSprite1 != value && _oWordImage1 != null)
			{
				_oWordImage1.sprite = value;
			}
		}
	}

	public Sprite WordSprite2
	{
		get
		{
			if (_oWordImage2 != null)
			{
				return _oWordImage2.sprite;
			}
			return null;
		}
		set
		{
			if (WordSprite2 != value && _oWordImage2 != null)
			{
				_oWordImage2.sprite = value;
			}
		}
	}

	public Sprite WordSprite3
	{
		get
		{
			if (_oWordImage3 != null)
			{
				return _oWordImage3.sprite;
			}
			return null;
		}
		set
		{
			if (WordSprite3 != value && _oWordImage3 != null)
			{
				_oWordImage3.sprite = value;
			}
		}
	}

	public Sprite WordSprite4
	{
		get
		{
			if (_oWordImage4 != null)
			{
				return _oWordImage4.sprite;
			}
			return null;
		}
		set
		{
			if (WordSprite4 != value && _oWordImage4 != null)
			{
				_oWordImage4.sprite = value;
			}
		}
	}

	public Sprite LightSprite1
	{
		get
		{
			if (_oLightImage1 != null)
			{
				return _oLightImage1.sprite;
			}
			return null;
		}
		set
		{
			if (LightSprite1 != value && _oLightImage1 != null)
			{
				_oLightImage1.sprite = value;
			}
		}
	}

	public Sprite LightSprite2
	{
		get
		{
			if (_oLightImage2 != null)
			{
				return _oLightImage2.sprite;
			}
			return null;
		}
		set
		{
			if (LightSprite2 != value && _oLightImage2 != null)
			{
				_oLightImage2.sprite = value;
			}
		}
	}

	public Sprite LightSprite3
	{
		get
		{
			if (_oLightImage3 != null)
			{
				return _oLightImage3.sprite;
			}
			return null;
		}
		set
		{
			if (LightSprite3 != value && _oLightImage3 != null)
			{
				_oLightImage3.sprite = value;
			}
		}
	}

	public Sprite LightSprite4
	{
		get
		{
			if (_oLightImage4 != null)
			{
				return _oLightImage4.sprite;
			}
			return null;
		}
		set
		{
			if (LightSprite4 != value && _oLightImage4 != null)
			{
				_oLightImage4.sprite = value;
			}
		}
	}

	public float LightFillamount1
	{
		get
		{
			if (_oLightImage1 != null)
			{
				return _oLightImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (LightFillamount1 != value && _oLightImage1 != null)
			{
				_oLightImage1.fillAmount = value;
			}
		}
	}

	public float LightFillamount2
	{
		get
		{
			if (_oLightImage2 != null)
			{
				return _oLightImage2.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (LightFillamount2 != value && _oLightImage2 != null)
			{
				_oLightImage2.fillAmount = value;
			}
		}
	}

	public float LightFillamount3
	{
		get
		{
			if (_oLightImage3 != null)
			{
				return _oLightImage3.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (LightFillamount3 != value && _oLightImage3 != null)
			{
				_oLightImage3.fillAmount = value;
			}
		}
	}

	public float LightFillamount4
	{
		get
		{
			if (_oLightImage4 != null)
			{
				return _oLightImage4.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (LightFillamount4 != value && _oLightImage4 != null)
			{
				_oLightImage4.fillAmount = value;
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
			case "Show":
				_oShow = transform.gameObject;
				break;
			case "Buff1":
				_oBuff1 = transform.gameObject;
				_oBuffImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff2":
				_oBuff2 = transform.gameObject;
				_oBuffImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff3":
				_oBuff3 = transform.gameObject;
				_oBuffImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Buff4":
				_oBuff4 = transform.gameObject;
				_oBuffImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Word1":
				_oWord1 = transform.gameObject;
				_oWordImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Word2":
				_oWord2 = transform.gameObject;
				_oWordImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Word3":
				_oWord3 = transform.gameObject;
				_oWordImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Word4":
				_oWord4 = transform.gameObject;
				_oWordImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Light1":
				_oLight1 = transform.gameObject;
				_oLightImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Light2":
				_oLight2 = transform.gameObject;
				_oLightImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Light3":
				_oLight3 = transform.gameObject;
				_oLightImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Light4":
				_oLight4 = transform.gameObject;
				_oLightImage4 = transform.gameObject.GetComponent<Image>();
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

	public bool GetBuffShow(int index)
	{
		return index switch
		{
			1 => BuffShow1, 
			2 => BuffShow2, 
			3 => BuffShow3, 
			4 => BuffShow4, 
			_ => false, 
		};
	}

	public void SetBuffShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BuffShow1 = value;
			break;
		case 2:
			BuffShow2 = value;
			break;
		case 3:
			BuffShow3 = value;
			break;
		case 4:
			BuffShow4 = value;
			break;
		}
	}

	public Sprite GetBuffSprite(int index)
	{
		return index switch
		{
			1 => BuffSprite1, 
			2 => BuffSprite2, 
			3 => BuffSprite3, 
			4 => BuffSprite4, 
			_ => null, 
		};
	}

	public void SetBuffSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BuffSprite1 = value;
			break;
		case 2:
			BuffSprite2 = value;
			break;
		case 3:
			BuffSprite3 = value;
			break;
		case 4:
			BuffSprite4 = value;
			break;
		}
	}

	public Sprite GetWordSprite(int index)
	{
		return index switch
		{
			1 => WordSprite1, 
			2 => WordSprite2, 
			3 => WordSprite3, 
			4 => WordSprite4, 
			_ => null, 
		};
	}

	public void SetWordSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			WordSprite1 = value;
			break;
		case 2:
			WordSprite2 = value;
			break;
		case 3:
			WordSprite3 = value;
			break;
		case 4:
			WordSprite4 = value;
			break;
		}
	}

	public Sprite GetLightSprite(int index)
	{
		return index switch
		{
			1 => LightSprite1, 
			2 => LightSprite2, 
			3 => LightSprite3, 
			4 => LightSprite4, 
			_ => null, 
		};
	}

	public void SetLightSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			LightSprite1 = value;
			break;
		case 2:
			LightSprite2 = value;
			break;
		case 3:
			LightSprite3 = value;
			break;
		case 4:
			LightSprite4 = value;
			break;
		}
	}

	public float GetLightFillamount(int index)
	{
		return index switch
		{
			1 => LightFillamount1, 
			2 => LightFillamount2, 
			3 => LightFillamount3, 
			4 => LightFillamount4, 
			_ => 0f, 
		};
	}

	public void SetLightFillamount(int index, float value)
	{
		switch (index)
		{
		case 1:
			LightFillamount1 = value;
			break;
		case 2:
			LightFillamount2 = value;
			break;
		case 3:
			LightFillamount3 = value;
			break;
		case 4:
			LightFillamount4 = value;
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
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
}
