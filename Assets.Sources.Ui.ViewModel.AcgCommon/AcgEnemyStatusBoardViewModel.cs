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

namespace Assets.Sources.Ui.ViewModel.AcgCommon;

[GameUiTest]
public class AcgEnemyStatusBoardViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oHpBarBase;

	private Image _oHpBarBaseImage;

	private GameObject _oHpBarMask;

	private Image _oHpBarMaskImage;

	private GameObject _oHpRedBar;

	private RectTransform _oHpRedBarRectTransform;

	private Image _oHpRedBarImage;

	private GameObject _oHpWhiteBar;

	private RectTransform _oHpWhiteBarRectTransform;

	private Image _oHpWhiteBarImage;

	private GameObject _oShieldBarBase;

	private RectTransform _oShieldBarBaseRectTransform;

	private GameObject _oShieldBar;

	private RectTransform _oShieldBarRectTransform;

	private Image _oShieldBarImage;

	private GameObject _oIconBorder;

	private Image _oIconBorderImage;

	private GameObject _oElementIcon;

	private Image _oElementIconImage;

	private GameObject _oEnemyIcon;

	private Image _oEnemyIconImage;

	private GameObject _oEnemyName;

	private Text _oEnemyNameText;

	private GameObject _oEnemyAttributes;

	private RectTransform _oEnemyAttributesRectTransform;

	private Text _oEnemyAttributesText;

	private GameObject _oBuffList;

	private GameObject _oBuff0;

	private RectTransform _oBuffRectTransform0;

	private Image _oBuffImage0;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/acgcommon";

	private string _resourceAssetName = "acgenemystatusboard";

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

	public Image HpBarBaseImage
	{
		get
		{
			if (_oHpBarBaseImage != null)
			{
				return _oHpBarBaseImage;
			}
			return null;
		}
		set
		{
			if (HpBarBaseImage != value && _oHpBarBaseImage != null)
			{
				_oHpBarBaseImage = value;
			}
		}
	}

	public Image HpBarMaskImage
	{
		get
		{
			if (_oHpBarMaskImage != null)
			{
				return _oHpBarMaskImage;
			}
			return null;
		}
		set
		{
			if (HpBarMaskImage != value && _oHpBarMaskImage != null)
			{
				_oHpBarMaskImage = value;
			}
		}
	}

	public Vector2 HpRedBarAnchoredposition
	{
		get
		{
			if (_oHpRedBarRectTransform != null)
			{
				return _oHpRedBarRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (HpRedBarAnchoredposition != value && _oHpRedBarRectTransform != null)
			{
				_oHpRedBarRectTransform.anchoredPosition = value;
			}
		}
	}

	public Image HpRedBarImage
	{
		get
		{
			if (_oHpRedBarImage != null)
			{
				return _oHpRedBarImage;
			}
			return null;
		}
		set
		{
			if (HpRedBarImage != value && _oHpRedBarImage != null)
			{
				_oHpRedBarImage = value;
			}
		}
	}

	public Vector2 HpWhiteBarAnchoredposition
	{
		get
		{
			if (_oHpWhiteBarRectTransform != null)
			{
				return _oHpWhiteBarRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (HpWhiteBarAnchoredposition != value && _oHpWhiteBarRectTransform != null)
			{
				_oHpWhiteBarRectTransform.anchoredPosition = value;
			}
		}
	}

	public Image HpWhiteBarImage
	{
		get
		{
			if (_oHpWhiteBarImage != null)
			{
				return _oHpWhiteBarImage;
			}
			return null;
		}
		set
		{
			if (HpWhiteBarImage != value && _oHpWhiteBarImage != null)
			{
				_oHpWhiteBarImage = value;
			}
		}
	}

	public Vector3 ShieldBarBaseSize
	{
		get
		{
			if (_oShieldBarBaseRectTransform != null)
			{
				return _oShieldBarBaseRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ShieldBarBaseSize != value && _oShieldBarBaseRectTransform != null)
			{
				_oShieldBarBaseRectTransform.sizeDelta = value;
			}
		}
	}

	public Vector3 ShieldBarSize
	{
		get
		{
			if (_oShieldBarRectTransform != null)
			{
				return _oShieldBarRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (ShieldBarSize != value && _oShieldBarRectTransform != null)
			{
				_oShieldBarRectTransform.sizeDelta = value;
			}
		}
	}

	public float ShieldBarFillamount
	{
		get
		{
			if (_oShieldBarImage != null)
			{
				return _oShieldBarImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ShieldBarFillamount != value && _oShieldBarImage != null)
			{
				_oShieldBarImage.fillAmount = value;
			}
		}
	}

	public Image ShieldBarImage
	{
		get
		{
			if (_oShieldBarImage != null)
			{
				return _oShieldBarImage;
			}
			return null;
		}
		set
		{
			if (ShieldBarImage != value && _oShieldBarImage != null)
			{
				_oShieldBarImage = value;
			}
		}
	}

	public Image IconBorderImage
	{
		get
		{
			if (_oIconBorderImage != null)
			{
				return _oIconBorderImage;
			}
			return null;
		}
		set
		{
			if (IconBorderImage != value && _oIconBorderImage != null)
			{
				_oIconBorderImage = value;
			}
		}
	}

	public Image ElementIconImage
	{
		get
		{
			if (_oElementIconImage != null)
			{
				return _oElementIconImage;
			}
			return null;
		}
		set
		{
			if (ElementIconImage != value && _oElementIconImage != null)
			{
				_oElementIconImage = value;
			}
		}
	}

	public Image EnemyIconImage
	{
		get
		{
			if (_oEnemyIconImage != null)
			{
				return _oEnemyIconImage;
			}
			return null;
		}
		set
		{
			if (EnemyIconImage != value && _oEnemyIconImage != null)
			{
				_oEnemyIconImage = value;
			}
		}
	}

	public string EnemyNameString
	{
		get
		{
			if (_oEnemyNameText != null)
			{
				return _oEnemyNameText.text;
			}
			return null;
		}
		set
		{
			if (EnemyNameString != value && _oEnemyNameText != null)
			{
				_oEnemyNameText.text = value;
			}
		}
	}

	public Vector2 EnemyAttributesAnchoredposition
	{
		get
		{
			if (_oEnemyAttributesRectTransform != null)
			{
				return _oEnemyAttributesRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (EnemyAttributesAnchoredposition != value && _oEnemyAttributesRectTransform != null)
			{
				_oEnemyAttributesRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 EnemyAttributesSize
	{
		get
		{
			if (_oEnemyAttributesRectTransform != null)
			{
				return _oEnemyAttributesRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (EnemyAttributesSize != value && _oEnemyAttributesRectTransform != null)
			{
				_oEnemyAttributesRectTransform.sizeDelta = value;
			}
		}
	}

	public string EnemyAttributesString
	{
		get
		{
			if (_oEnemyAttributesText != null)
			{
				return _oEnemyAttributesText.text;
			}
			return null;
		}
		set
		{
			if (EnemyAttributesString != value && _oEnemyAttributesText != null)
			{
				_oEnemyAttributesText.text = value;
			}
		}
	}

	public int EnemyAttributesFontsize
	{
		get
		{
			if (_oEnemyAttributesText != null)
			{
				return _oEnemyAttributesText.fontSize;
			}
			return 16;
		}
		set
		{
			if (EnemyAttributesFontsize != value && _oEnemyAttributesText != null)
			{
				_oEnemyAttributesText.fontSize = value;
			}
		}
	}

	public GameObject BuffListObj => _oBuffList;

	public bool BuffListShow
	{
		get
		{
			if (_oBuffList != null)
			{
				return _oBuffList.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (BuffListShow != value && _oBuffList != null)
			{
				_oBuffList.SetObjectActive(value);
			}
		}
	}

	public GameObject BuffObj0 => _oBuff0;

	public Vector3 BuffPosition0
	{
		get
		{
			if (_oBuffRectTransform0 != null)
			{
				return _oBuffRectTransform0.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (BuffPosition0 != value && _oBuffRectTransform0 != null)
			{
				_oBuffRectTransform0.localPosition = value;
			}
		}
	}

	public Image BuffImage0
	{
		get
		{
			if (_oBuffImage0 != null)
			{
				return _oBuffImage0;
			}
			return null;
		}
		set
		{
			if (BuffImage0 != value && _oBuffImage0 != null)
			{
				_oBuffImage0 = value;
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
			case "HpBarBase":
				_oHpBarBase = transform.gameObject;
				_oHpBarBaseImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpBarMask":
				_oHpBarMask = transform.gameObject;
				_oHpBarMaskImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpRedBar":
				_oHpRedBar = transform.gameObject;
				_oHpRedBarRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oHpRedBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "HpWhiteBar":
				_oHpWhiteBar = transform.gameObject;
				_oHpWhiteBarRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oHpWhiteBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ShieldBarBase":
				_oShieldBarBase = transform.gameObject;
				_oShieldBarBaseRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "ShieldBar":
				_oShieldBar = transform.gameObject;
				_oShieldBarRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oShieldBarImage = transform.gameObject.GetComponent<Image>();
				break;
			case "IconBorder":
				_oIconBorder = transform.gameObject;
				_oIconBorderImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ElementIcon":
				_oElementIcon = transform.gameObject;
				_oElementIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnemyIcon":
				_oEnemyIcon = transform.gameObject;
				_oEnemyIconImage = transform.gameObject.GetComponent<Image>();
				break;
			case "EnemyName":
				_oEnemyName = transform.gameObject;
				_oEnemyNameText = transform.gameObject.GetComponent<Text>();
				break;
			case "EnemyAttributes":
				_oEnemyAttributes = transform.gameObject;
				_oEnemyAttributesRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oEnemyAttributesText = transform.gameObject.GetComponent<Text>();
				break;
			case "BuffList":
				_oBuffList = transform.gameObject;
				break;
			case "Buff0":
				_oBuff0 = transform.gameObject;
				_oBuffRectTransform0 = transform.gameObject.GetComponent<RectTransform>();
				_oBuffImage0 = transform.gameObject.GetComponent<Image>();
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

	public void HpBarBaseNtvsize()
	{
		if (_oHpBarBaseImage != null)
		{
			_oHpBarBaseImage.SetNativeSize();
		}
	}

	public void HpBarMaskNtvsize()
	{
		if (_oHpBarMaskImage != null)
		{
			_oHpBarMaskImage.SetNativeSize();
		}
	}

	public void HpRedBarNtvsize()
	{
		if (_oHpRedBarImage != null)
		{
			_oHpRedBarImage.SetNativeSize();
		}
	}

	public void HpWhiteBarNtvsize()
	{
		if (_oHpWhiteBarImage != null)
		{
			_oHpWhiteBarImage.SetNativeSize();
		}
	}

	public GameObject GetBuffObj(int index)
	{
		if (index == 0)
		{
			return BuffObj0;
		}
		return null;
	}

	public int GetBuffCount()
	{
		return 0;
	}

	public Vector3 GetBuffPosition(int index)
	{
		if (index == 0)
		{
			return BuffPosition0;
		}
		return Vector3.zero;
	}

	public void SetBuffPosition(int index, Vector3 value)
	{
		if (index == 0)
		{
			BuffPosition0 = value;
		}
	}

	public Image GetBuffImage(int index)
	{
		if (index == 0)
		{
			return BuffImage0;
		}
		return null;
	}

	public void SetBuffImage(int index, Image value)
	{
		if (index == 0)
		{
			BuffImage0 = value;
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
