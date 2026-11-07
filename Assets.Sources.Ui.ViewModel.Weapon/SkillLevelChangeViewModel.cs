using System;
using System.Collections.Generic;
using Assets.Res.Assets.Scripts.Refrenceless;
using Assets.Scripts.ResScripts.Refrenceless.DyVersion;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Weapon;

[GameUiTest]
public class SkillLevelChangeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oRightBottom;

	private GameObject _oBack;

	private Image _oBackImage;

	private GameObject _oSkillBack;

	private Image _oSkillBackImage;

	private GameObject _oProgress;

	private Image _oProgressImage;

	private GameObject _oDun;

	private Image _oDunImage;

	private GameObject _oDunProgress;

	private Image _oDunProgressImage;

	private GameObject _oEffect;

	private RectTransform _oEffectRectTransform;

	private Image _oEffectImage;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/weapon";

	private string _resourceAssetName = "SkillLevelChange";

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

	public bool BackEnabled
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.enabled;
			}
			return false;
		}
		set
		{
			if (BackEnabled != value && _oBackImage != null)
			{
				_oBackImage.NotifyUiDyLoadEnable(value);
			}
		}
	}

	public Sprite BackSprite
	{
		get
		{
			if (_oBackImage != null)
			{
				return _oBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (BackSprite != value && _oBackImage != null)
			{
				_oBackImage.sprite = value;
			}
		}
	}

	public bool SkillBackShow
	{
		get
		{
			if (_oSkillBack != null)
			{
				return _oSkillBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (SkillBackShow != value && _oSkillBack != null)
			{
				_oSkillBack.SetObjectActive(value);
			}
		}
	}

	public Sprite SkillBackSprite
	{
		get
		{
			if (_oSkillBackImage != null)
			{
				return _oSkillBackImage.sprite;
			}
			return null;
		}
		set
		{
			if (SkillBackSprite != value && _oSkillBackImage != null)
			{
				_oSkillBackImage.sprite = value;
			}
		}
	}

	public bool ProgressShow
	{
		get
		{
			if (_oProgress != null)
			{
				return _oProgress.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ProgressShow != value && _oProgress != null)
			{
				_oProgress.SetObjectActive(value);
			}
		}
	}

	public Sprite ProgressSprite
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.sprite;
			}
			return null;
		}
		set
		{
			if (ProgressSprite != value && _oProgressImage != null)
			{
				_oProgressImage.sprite = value;
			}
		}
	}

	public float ProgressFillamount
	{
		get
		{
			if (_oProgressImage != null)
			{
				return _oProgressImage.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (ProgressFillamount != value && _oProgressImage != null)
			{
				_oProgressImage.fillAmount = value;
			}
		}
	}

	public bool DunShow
	{
		get
		{
			if (_oDun != null)
			{
				return _oDun.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (DunShow != value && _oDun != null)
			{
				_oDun.SetObjectActive(value);
			}
		}
	}

	public Sprite DunSprite
	{
		get
		{
			if (_oDunImage != null)
			{
				return _oDunImage.sprite;
			}
			return null;
		}
		set
		{
			if (DunSprite != value && _oDunImage != null)
			{
				_oDunImage.sprite = value;
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

	public bool EffectShow
	{
		get
		{
			if (_oEffect != null)
			{
				return _oEffect.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (EffectShow != value && _oEffect != null)
			{
				_oEffect.SetObjectActive(value);
			}
		}
	}

	public Vector3 EffectPosition
	{
		get
		{
			if (_oEffectRectTransform != null)
			{
				return _oEffectRectTransform.localPosition;
			}
			return Vector3.zero;
		}
		set
		{
			if (EffectPosition != value && _oEffectRectTransform != null)
			{
				_oEffectRectTransform.localPosition = value;
			}
		}
	}

	public Sprite EffectSprite
	{
		get
		{
			if (_oEffectImage != null)
			{
				return _oEffectImage.sprite;
			}
			return null;
		}
		set
		{
			if (EffectSprite != value && _oEffectImage != null)
			{
				_oEffectImage.sprite = value;
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
			case "Back":
				_oBack = transform.gameObject;
				_oBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "SkillBack":
				_oSkillBack = transform.gameObject;
				_oSkillBackImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Progress":
				_oProgress = transform.gameObject;
				_oProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Dun":
				_oDun = transform.gameObject;
				_oDunImage = transform.gameObject.GetComponent<Image>();
				break;
			case "DunProgress":
				_oDunProgress = transform.gameObject;
				_oDunProgressImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Effect":
				_oEffect = transform.gameObject;
				_oEffectRectTransform = transform.gameObject.GetComponent<RectTransform>();
				_oEffectImage = transform.gameObject.GetComponent<Image>();
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
