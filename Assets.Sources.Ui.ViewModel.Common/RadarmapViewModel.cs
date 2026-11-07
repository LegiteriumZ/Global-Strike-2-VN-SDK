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
public class RadarmapViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oMapRotation;

	private RectTransform _oMapRotationRectTransform;

	private GameObject _oMask;

	private GameObject _oMapBase;

	private RectTransform _oMapBaseRectTransform;

	private GameObject _oMapPosition;

	private RectTransform _oMapPositionRectTransform;

	private Image _oMapPositionImage;

	private GameObject _oCommonItems;

	private GameObject _oDuwu;

	private RectTransform _oDuwuRectTransform;

	private Image _oDuwuImage;

	private GameObject _oSafe;

	private RectTransform _oSafeRectTransform;

	private GameObject _oSelfPosition;

	private GameObject _oPlayer;

	private Image _oPlayerImage;

	private GameObject _oTacticsSound;

	private GameObject _oGrayMap;

	private GameObject _oModeName;

	private Image _oModeNameImage;

	private GameObject _oDifficulty;

	private Image _oDifficultyImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "Radarmap";

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

	public Quaternion MapRotationRotation
	{
		get
		{
			if (_oMapRotationRectTransform != null)
			{
				return _oMapRotationRectTransform.localRotation;
			}
			return Quaternion.Euler(Vector3.zero);
		}
		set
		{
			if (MapRotationRotation != value && _oMapRotationRectTransform != null)
			{
				_oMapRotationRectTransform.localRotation = value;
			}
		}
	}

	public bool MaskShow
	{
		get
		{
			if (_oMask != null)
			{
				return _oMask.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (MaskShow != value && _oMask != null)
			{
				_oMask.SetObjectActive(value);
			}
		}
	}

	public Vector3 MapBasePosition
	{
		get
		{
			if (_oMapBaseRectTransform != null)
			{
				return _oMapBaseRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MapBasePosition != value && _oMapBaseRectTransform != null)
			{
				_oMapBaseRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 MapPositionPosition
	{
		get
		{
			if (_oMapPositionRectTransform != null)
			{
				return _oMapPositionRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (MapPositionPosition != value && _oMapPositionRectTransform != null)
			{
				_oMapPositionRectTransform.localPosition = value;
			}
		}
	}

	public Sprite MapPositionSprite
	{
		get
		{
			if (_oMapPositionImage != null)
			{
				return _oMapPositionImage.sprite;
			}
			return null;
		}
		set
		{
			if (MapPositionSprite != value && _oMapPositionImage != null)
			{
				_oMapPositionImage.sprite = value;
			}
		}
	}

	public Image MapPositionImage
	{
		get
		{
			if (_oMapPositionImage != null)
			{
				return _oMapPositionImage;
			}
			return null;
		}
		set
		{
			if (MapPositionImage != value && _oMapPositionImage != null)
			{
				_oMapPositionImage = value;
			}
		}
	}

	public GameObject CommonItemsObj => _oCommonItems;

	public GameObject DuwuObj => _oDuwu;

	public bool DuwuShow
	{
		get
		{
			if (_oDuwu != null)
			{
				return _oDuwu.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DuwuShow != value && _oDuwu != null)
			{
				_oDuwu.SetObjectActive(value);
			}
		}
	}

	public Vector3 DuwuPosition
	{
		get
		{
			if (_oDuwuRectTransform != null)
			{
				return _oDuwuRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DuwuPosition != value && _oDuwuRectTransform != null)
			{
				_oDuwuRectTransform.localPosition = value;
			}
		}
	}

	public Sprite DuwuSprite
	{
		get
		{
			if (_oDuwuImage != null)
			{
				return _oDuwuImage.sprite;
			}
			return null;
		}
		set
		{
			if (DuwuSprite != value && _oDuwuImage != null)
			{
				_oDuwuImage.sprite = value;
			}
		}
	}

	public bool SafeShow
	{
		get
		{
			if (_oSafe != null)
			{
				return _oSafe.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SafeShow != value && _oSafe != null)
			{
				_oSafe.SetObjectActive(value);
			}
		}
	}

	public Vector3 SafePosition
	{
		get
		{
			if (_oSafeRectTransform != null)
			{
				return _oSafeRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (SafePosition != value && _oSafeRectTransform != null)
			{
				_oSafeRectTransform.localPosition = value;
			}
		}
	}

	public Vector3 SafeSize
	{
		get
		{
			if (_oSafeRectTransform != null)
			{
				return _oSafeRectTransform.sizeDelta;
			}
			return Vector3.zero;
		}
		set
		{
			if (SafeSize != value && _oSafeRectTransform != null)
			{
				_oSafeRectTransform.sizeDelta = value;
			}
		}
	}

	public bool SelfPositionShow
	{
		get
		{
			if (_oSelfPosition != null)
			{
				return _oSelfPosition.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SelfPositionShow != value && _oSelfPosition != null)
			{
				_oSelfPosition.SetObjectActive(value);
			}
		}
	}

	public Sprite PlayerSprite
	{
		get
		{
			if (_oPlayerImage != null)
			{
				return _oPlayerImage.sprite;
			}
			return null;
		}
		set
		{
			if (PlayerSprite != value && _oPlayerImage != null)
			{
				_oPlayerImage.sprite = value;
			}
		}
	}

	public Image PlayerImage
	{
		get
		{
			if (_oPlayerImage != null)
			{
				return _oPlayerImage;
			}
			return null;
		}
		set
		{
			if (PlayerImage != value && _oPlayerImage != null)
			{
				_oPlayerImage = value;
			}
		}
	}

	public bool TacticsSoundShow
	{
		get
		{
			if (_oTacticsSound != null)
			{
				return _oTacticsSound.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (TacticsSoundShow != value && _oTacticsSound != null)
			{
				_oTacticsSound.SetObjectActive(value);
			}
		}
	}

	public bool GrayMapShow
	{
		get
		{
			if (_oGrayMap != null)
			{
				return _oGrayMap.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GrayMapShow != value && _oGrayMap != null)
			{
				_oGrayMap.SetObjectActive(value);
			}
		}
	}

	public bool ModeNameShow
	{
		get
		{
			if (_oModeName != null)
			{
				return _oModeName.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ModeNameShow != value && _oModeName != null)
			{
				_oModeName.SetObjectActive(value);
			}
		}
	}

	public Sprite ModeNameSprite
	{
		get
		{
			if (_oModeNameImage != null)
			{
				return _oModeNameImage.sprite;
			}
			return null;
		}
		set
		{
			if (ModeNameSprite != value && _oModeNameImage != null)
			{
				_oModeNameImage.sprite = value;
			}
		}
	}

	public Image ModeNameImage
	{
		get
		{
			if (_oModeNameImage != null)
			{
				return _oModeNameImage;
			}
			return null;
		}
		set
		{
			if (ModeNameImage != value && _oModeNameImage != null)
			{
				_oModeNameImage = value;
			}
		}
	}

	public bool DifficultyShow
	{
		get
		{
			if (_oDifficulty != null)
			{
				return _oDifficulty.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DifficultyShow != value && _oDifficulty != null)
			{
				_oDifficulty.SetObjectActive(value);
			}
		}
	}

	public Sprite DifficultySprite
	{
		get
		{
			if (_oDifficultyImage != null)
			{
				return _oDifficultyImage.sprite;
			}
			return null;
		}
		set
		{
			if (DifficultySprite != value && _oDifficultyImage != null)
			{
				_oDifficultyImage.sprite = value;
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
			case "MapRotation":
				_oMapRotation = transform.gameObject;
				_oMapRotationRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "Mask":
				_oMask = transform.gameObject;
				break;
			case "MapBase":
				_oMapBase = transform.gameObject;
				_oMapBaseRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "MapPosition":
				_oMapPosition = transform.gameObject;
				_oMapPositionRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oMapPositionImage = transform.gameObject.GetComponent<Image>();
				break;
			case "CommonItems":
				_oCommonItems = transform.gameObject;
				break;
			case "Duwu":
				_oDuwu = transform.gameObject;
				_oDuwuRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oDuwuImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Safe":
				_oSafe = transform.gameObject;
				_oSafeRectTransform = transform.gameObject.GetComponent<RectTransform>();
				break;
			case "SelfPosition":
				_oSelfPosition = transform.gameObject;
				break;
			case "Player":
				_oPlayer = transform.gameObject;
				_oPlayerImage = transform.gameObject.GetComponent<Image>();
				break;
			case "TacticsSound":
				_oTacticsSound = transform.gameObject;
				break;
			case "GrayMap":
				_oGrayMap = transform.gameObject;
				break;
			case "ModeName":
				_oModeName = transform.gameObject;
				_oModeNameImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Difficulty":
				_oDifficulty = transform.gameObject;
				_oDifficultyImage = transform.gameObject.GetComponent<Image>();
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

	public void ModeNameNtvsize()
	{
		if (_oModeNameImage != null)
		{
			_oModeNameImage.SetNativeSize();
		}
	}

	public void DifficultyNtvsize()
	{
		if (_oDifficultyImage != null)
		{
			_oDifficultyImage.SetNativeSize();
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
