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
public class SniperGuardianBulletViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oBullet1;

	private GameObject _oBullet2;

	private GameObject _oBullet3;

	private GameObject _oBullet4;

	private GameObject _oBullet5;

	private Image _oBulletImage1;

	private Image _oBulletImage2;

	private Image _oBulletImage3;

	private Image _oBulletImage4;

	private Image _oBulletImage5;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "SniperGuardianBullet";

	private List<RectTransform> _holdPosTrans;

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

	public bool BulletShow1
	{
		get
		{
			if (_oBullet1 != null)
			{
				return _oBullet1.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BulletShow1 != value && _oBullet1 != null)
			{
				_oBullet1.SetObjectActive(value);
			}
		}
	}

	public bool BulletShow2
	{
		get
		{
			if (_oBullet2 != null)
			{
				return _oBullet2.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BulletShow2 != value && _oBullet2 != null)
			{
				_oBullet2.SetObjectActive(value);
			}
		}
	}

	public bool BulletShow3
	{
		get
		{
			if (_oBullet3 != null)
			{
				return _oBullet3.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BulletShow3 != value && _oBullet3 != null)
			{
				_oBullet3.SetObjectActive(value);
			}
		}
	}

	public bool BulletShow4
	{
		get
		{
			if (_oBullet4 != null)
			{
				return _oBullet4.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BulletShow4 != value && _oBullet4 != null)
			{
				_oBullet4.SetObjectActive(value);
			}
		}
	}

	public bool BulletShow5
	{
		get
		{
			if (_oBullet5 != null)
			{
				return _oBullet5.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BulletShow5 != value && _oBullet5 != null)
			{
				_oBullet5.SetObjectActive(value);
			}
		}
	}

	public Sprite BulletSprite1
	{
		get
		{
			if (_oBulletImage1 != null)
			{
				return _oBulletImage1.sprite;
			}
			return null;
		}
		set
		{
			if (BulletSprite1 != value && _oBulletImage1 != null)
			{
				_oBulletImage1.sprite = value;
			}
		}
	}

	public Sprite BulletSprite2
	{
		get
		{
			if (_oBulletImage2 != null)
			{
				return _oBulletImage2.sprite;
			}
			return null;
		}
		set
		{
			if (BulletSprite2 != value && _oBulletImage2 != null)
			{
				_oBulletImage2.sprite = value;
			}
		}
	}

	public Sprite BulletSprite3
	{
		get
		{
			if (_oBulletImage3 != null)
			{
				return _oBulletImage3.sprite;
			}
			return null;
		}
		set
		{
			if (BulletSprite3 != value && _oBulletImage3 != null)
			{
				_oBulletImage3.sprite = value;
			}
		}
	}

	public Sprite BulletSprite4
	{
		get
		{
			if (_oBulletImage4 != null)
			{
				return _oBulletImage4.sprite;
			}
			return null;
		}
		set
		{
			if (BulletSprite4 != value && _oBulletImage4 != null)
			{
				_oBulletImage4.sprite = value;
			}
		}
	}

	public Sprite BulletSprite5
	{
		get
		{
			if (_oBulletImage5 != null)
			{
				return _oBulletImage5.sprite;
			}
			return null;
		}
		set
		{
			if (BulletSprite5 != value && _oBulletImage5 != null)
			{
				_oBulletImage5.sprite = value;
			}
		}
	}

	public Color BulletColor1
	{
		get
		{
			if (_oBulletImage1 != null)
			{
				return _oBulletImage1.color;
			}
			return Color.white;
		}
		set
		{
			if (BulletColor1 != value && _oBulletImage1 != null)
			{
				_oBulletImage1.color = value;
			}
		}
	}

	public Color BulletColor2
	{
		get
		{
			if (_oBulletImage2 != null)
			{
				return _oBulletImage2.color;
			}
			return Color.white;
		}
		set
		{
			if (BulletColor2 != value && _oBulletImage2 != null)
			{
				_oBulletImage2.color = value;
			}
		}
	}

	public Color BulletColor3
	{
		get
		{
			if (_oBulletImage3 != null)
			{
				return _oBulletImage3.color;
			}
			return Color.white;
		}
		set
		{
			if (BulletColor3 != value && _oBulletImage3 != null)
			{
				_oBulletImage3.color = value;
			}
		}
	}

	public Color BulletColor4
	{
		get
		{
			if (_oBulletImage4 != null)
			{
				return _oBulletImage4.color;
			}
			return Color.white;
		}
		set
		{
			if (BulletColor4 != value && _oBulletImage4 != null)
			{
				_oBulletImage4.color = value;
			}
		}
	}

	public Color BulletColor5
	{
		get
		{
			if (_oBulletImage5 != null)
			{
				return _oBulletImage5.color;
			}
			return Color.white;
		}
		set
		{
			if (BulletColor5 != value && _oBulletImage5 != null)
			{
				_oBulletImage5.color = value;
			}
		}
	}

	public Image BulletImage1
	{
		get
		{
			if (_oBulletImage1 != null)
			{
				return _oBulletImage1;
			}
			return null;
		}
		set
		{
			if (BulletImage1 != value && _oBulletImage1 != null)
			{
				_oBulletImage1 = value;
			}
		}
	}

	public Image BulletImage2
	{
		get
		{
			if (_oBulletImage2 != null)
			{
				return _oBulletImage2;
			}
			return null;
		}
		set
		{
			if (BulletImage2 != value && _oBulletImage2 != null)
			{
				_oBulletImage2 = value;
			}
		}
	}

	public Image BulletImage3
	{
		get
		{
			if (_oBulletImage3 != null)
			{
				return _oBulletImage3;
			}
			return null;
		}
		set
		{
			if (BulletImage3 != value && _oBulletImage3 != null)
			{
				_oBulletImage3 = value;
			}
		}
	}

	public Image BulletImage4
	{
		get
		{
			if (_oBulletImage4 != null)
			{
				return _oBulletImage4;
			}
			return null;
		}
		set
		{
			if (BulletImage4 != value && _oBulletImage4 != null)
			{
				_oBulletImage4 = value;
			}
		}
	}

	public Image BulletImage5
	{
		get
		{
			if (_oBulletImage5 != null)
			{
				return _oBulletImage5;
			}
			return null;
		}
		set
		{
			if (BulletImage5 != value && _oBulletImage5 != null)
			{
				_oBulletImage5 = value;
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
			case "Bullet1":
				_oBullet1 = transform.gameObject;
				_oBulletImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Bullet2":
				_oBullet2 = transform.gameObject;
				_oBulletImage2 = transform.gameObject.GetComponent<Image>();
				break;
			case "Bullet3":
				_oBullet3 = transform.gameObject;
				_oBulletImage3 = transform.gameObject.GetComponent<Image>();
				break;
			case "Bullet4":
				_oBullet4 = transform.gameObject;
				_oBulletImage4 = transform.gameObject.GetComponent<Image>();
				break;
			case "Bullet5":
				_oBullet5 = transform.gameObject;
				_oBulletImage5 = transform.gameObject.GetComponent<Image>();
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

	public bool GetBulletShow(int index)
	{
		return index switch
		{
			1 => BulletShow1, 
			2 => BulletShow2, 
			3 => BulletShow3, 
			4 => BulletShow4, 
			5 => BulletShow5, 
			_ => false, 
		};
	}

	public void SetBulletShow(int index, bool value)
	{
		switch (index)
		{
		case 1:
			BulletShow1 = value;
			break;
		case 2:
			BulletShow2 = value;
			break;
		case 3:
			BulletShow3 = value;
			break;
		case 4:
			BulletShow4 = value;
			break;
		case 5:
			BulletShow5 = value;
			break;
		}
	}

	public int GetBulletCount()
	{
		return 5;
	}

	public Sprite GetBulletSprite(int index)
	{
		return index switch
		{
			1 => BulletSprite1, 
			2 => BulletSprite2, 
			3 => BulletSprite3, 
			4 => BulletSprite4, 
			5 => BulletSprite5, 
			_ => null, 
		};
	}

	public void SetBulletSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			BulletSprite1 = value;
			break;
		case 2:
			BulletSprite2 = value;
			break;
		case 3:
			BulletSprite3 = value;
			break;
		case 4:
			BulletSprite4 = value;
			break;
		case 5:
			BulletSprite5 = value;
			break;
		}
	}

	public Color GetBulletColor(int index)
	{
		return index switch
		{
			1 => BulletColor1, 
			2 => BulletColor2, 
			3 => BulletColor3, 
			4 => BulletColor4, 
			5 => BulletColor5, 
			_ => Color.white, 
		};
	}

	public void SetBulletColor(int index, Color value)
	{
		switch (index)
		{
		case 1:
			BulletColor1 = value;
			break;
		case 2:
			BulletColor2 = value;
			break;
		case 3:
			BulletColor3 = value;
			break;
		case 4:
			BulletColor4 = value;
			break;
		case 5:
			BulletColor5 = value;
			break;
		}
	}

	public Image GetBulletImage(int index)
	{
		return index switch
		{
			1 => BulletImage1, 
			2 => BulletImage2, 
			3 => BulletImage3, 
			4 => BulletImage4, 
			5 => BulletImage5, 
			_ => null, 
		};
	}

	public void SetBulletImage(int index, Image value)
	{
		switch (index)
		{
		case 1:
			BulletImage1 = value;
			break;
		case 2:
			BulletImage2 = value;
			break;
		case 3:
			BulletImage3 = value;
			break;
		case 4:
			BulletImage4 = value;
			break;
		case 5:
			BulletImage5 = value;
			break;
		}
	}

	public void BulletNtvsize1()
	{
		if (_oBulletImage1 != null)
		{
			_oBulletImage1.SetNativeSize();
		}
	}

	public void BulletNtvsize2()
	{
		if (_oBulletImage2 != null)
		{
			_oBulletImage2.SetNativeSize();
		}
	}

	public void BulletNtvsize3()
	{
		if (_oBulletImage3 != null)
		{
			_oBulletImage3.SetNativeSize();
		}
	}

	public void BulletNtvsize4()
	{
		if (_oBulletImage4 != null)
		{
			_oBulletImage4.SetNativeSize();
		}
	}

	public void BulletNtvsize5()
	{
		if (_oBulletImage5 != null)
		{
			_oBulletImage5.SetNativeSize();
		}
	}

	public void CallBulletNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			BulletNtvsize1();
			break;
		case 2:
			BulletNtvsize2();
			break;
		case 3:
			BulletNtvsize3();
			break;
		case 4:
			BulletNtvsize4();
			break;
		case 5:
			BulletNtvsize5();
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		if (_holdPosTrans != null)
		{
			return _holdPosTrans;
		}
		_holdPosTrans = new List<RectTransform>();
		return _holdPosTrans;
	}
}
