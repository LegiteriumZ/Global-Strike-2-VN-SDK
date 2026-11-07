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
public class SkillCountDownViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private GameObject _odun;

	private RectTransform _odunRectTransform;

	private Image _odunImage;

	private GameObject _oDunProgress;

	private RectTransform _oDunProgressRectTransform;

	private Image _oDunProgressImage;

	private GameObject _oPowerNum;

	private RectTransform _oPowerNumRectTransform;

	private Text _oPowerNumText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "SkillCountDown";

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

	public bool RightBottomShow
	{
		get
		{
			if (_oRightBottom != null)
			{
				return _oRightBottom.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RightBottomShow != value && _oRightBottom != null)
			{
				_oRightBottom.SetObjectActive(value);
			}
		}
	}

	public bool dunShow
	{
		get
		{
			if (_odun != null)
			{
				return _odun.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (dunShow != value && _odun != null)
			{
				_odun.SetObjectActive(value);
			}
		}
	}

	public Vector2 dunAnchoredposition
	{
		get
		{
			if (_odunRectTransform != null)
			{
				return _odunRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (dunAnchoredposition != value && _odunRectTransform != null)
			{
				_odunRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 dunPosition
	{
		get
		{
			if (_odunRectTransform != null)
			{
				return _odunRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (dunPosition != value && _odunRectTransform != null)
			{
				_odunRectTransform.localPosition = value;
			}
		}
	}

	public Sprite dunSprite
	{
		get
		{
			if (_odunImage != null)
			{
				return _odunImage.sprite;
			}
			return null;
		}
		set
		{
			if (dunSprite != value && _odunImage != null)
			{
				_odunImage.sprite = value;
			}
		}
	}

	public bool DunProgressShow
	{
		get
		{
			if (_oDunProgress != null)
			{
				return _oDunProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DunProgressShow != value && _oDunProgress != null)
			{
				_oDunProgress.SetObjectActive(value);
			}
		}
	}

	public Vector2 DunProgressAnchoredposition
	{
		get
		{
			if (_oDunProgressRectTransform != null)
			{
				return _oDunProgressRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (DunProgressAnchoredposition != value && _oDunProgressRectTransform != null)
			{
				_oDunProgressRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 DunProgressPosition
	{
		get
		{
			if (_oDunProgressRectTransform != null)
			{
				return _oDunProgressRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (DunProgressPosition != value && _oDunProgressRectTransform != null)
			{
				_oDunProgressRectTransform.localPosition = value;
			}
		}
	}

	public Sprite DunProgressSprite
	{
		get
		{
			if (_oDunProgressImage != null)
			{
				return _oDunProgressImage.sprite;
			}
			return null;
		}
		set
		{
			if (DunProgressSprite != value && _oDunProgressImage != null)
			{
				_oDunProgressImage.sprite = value;
			}
		}
	}

	public float DunProgressFillamount
	{
		get
		{
			if (_oDunProgressImage != null)
			{
				return _oDunProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (DunProgressFillamount != value && _oDunProgressImage != null)
			{
				_oDunProgressImage.fillAmount = value;
			}
		}
	}

	public bool PowerNumShow
	{
		get
		{
			if (_oPowerNum != null)
			{
				return _oPowerNum.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (PowerNumShow != value && _oPowerNum != null)
			{
				_oPowerNum.SetObjectActive(value);
			}
		}
	}

	public Vector2 PowerNumAnchoredposition
	{
		get
		{
			if (_oPowerNumRectTransform != null)
			{
				return _oPowerNumRectTransform.anchoredPosition;
			}
			return Vector2.zero;
		}
		set
		{
			if (PowerNumAnchoredposition != value && _oPowerNumRectTransform != null)
			{
				_oPowerNumRectTransform.anchoredPosition = value;
			}
		}
	}

	public Vector3 PowerNumPosition
	{
		get
		{
			if (_oPowerNumRectTransform != null)
			{
				return _oPowerNumRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (PowerNumPosition != value && _oPowerNumRectTransform != null)
			{
				_oPowerNumRectTransform.localPosition = value;
			}
		}
	}

	public string PowerNumString
	{
		get
		{
			if (_oPowerNumText != null)
			{
				return _oPowerNumText.text;
			}
			return null;
		}
		set
		{
			if (PowerNumString != value && _oPowerNumText != null)
			{
				_oPowerNumText.text = value;
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
			case "RightBottom":
				_oRightBottom = transform.gameObject;
				break;
			case "dun":
				_odun = transform.gameObject;
				_odunRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_odunImage = transform.gameObject.GetComponent<Image>();
				break;
			case "DunProgress":
				_oDunProgress = transform.gameObject;
				_oDunProgressRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oDunProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "PowerNum":
				_oPowerNum = transform.gameObject;
				_oPowerNumRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oPowerNumText = transform.gameObject.GetComponent<Text>();
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

	public void dunNtvsize()
	{
		if (_odunImage != null)
		{
			_odunImage.SetNativeSize();
		}
	}

	public void DunProgressNtvsize()
	{
		if (_oDunProgressImage != null)
		{
			_oDunProgressImage.SetNativeSize();
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
		if (_oPowerNumText != null)
		{
			_holdPosTrans.Add(_oPowerNumText.GetComponent<RectTransform>());
		}
		return _holdPosTrans;
	}
}
