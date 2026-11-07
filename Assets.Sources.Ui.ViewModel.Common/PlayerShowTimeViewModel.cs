using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Common;

[GameUiTest]
public class PlayerShowTimeViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private CanvasGroup _oShowCanvasGroup;

	private GameObject _oKillImage;

	private Image _oKillImageImage;

	private GameObject _oContinusKill;

	private Image _oContinusKillImage;

	private GameObject _oGrade;

	private Image _oGradeImage;

	private GameObject _oRevenge;

	private GameObject _oKillScoreBack;

	private GameObject _oKillScroe;

	private Text _oKillScroeText;

	private GameObject _oRpgCombo;

	private Image _oRpgComboImage;

	private GameObject _oComboCount;

	private Text _oComboCountText;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/common";

	private string _resourceAssetName = "PlayerShowTime";

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

	public float ShowAlpha
	{
		get
		{
			if (_oShowCanvasGroup != null)
			{
				return _oShowCanvasGroup.alpha;
			}
			return 0f;
		}
		set
		{
			if (ShowAlpha != value && _oShowCanvasGroup != null)
			{
				_oShowCanvasGroup.alpha = value;
			}
		}
	}

	public bool KillImageShow
	{
		get
		{
			if (_oKillImage != null)
			{
				return _oKillImage.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillImageShow != value && _oKillImage != null)
			{
				_oKillImage.SetObjectActive(value);
			}
		}
	}

	public Sprite KillImageSprite
	{
		get
		{
			if (_oKillImageImage != null)
			{
				return _oKillImageImage.sprite;
			}
			return null;
		}
		set
		{
			if (KillImageSprite != value && _oKillImageImage != null)
			{
				_oKillImageImage.sprite = value;
			}
		}
	}

	public bool ContinusKillShow
	{
		get
		{
			if (_oContinusKill != null)
			{
				return _oContinusKill.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (ContinusKillShow != value && _oContinusKill != null)
			{
				_oContinusKill.SetObjectActive(value);
			}
		}
	}

	public Sprite ContinusKillSprite
	{
		get
		{
			if (_oContinusKillImage != null)
			{
				return _oContinusKillImage.sprite;
			}
			return null;
		}
		set
		{
			if (ContinusKillSprite != value && _oContinusKillImage != null)
			{
				_oContinusKillImage.sprite = value;
			}
		}
	}

	public bool GradeShow
	{
		get
		{
			if (_oGrade != null)
			{
				return _oGrade.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (GradeShow != value && _oGrade != null)
			{
				_oGrade.SetObjectActive(value);
			}
		}
	}

	public Sprite GradeSprite
	{
		get
		{
			if (_oGradeImage != null)
			{
				return _oGradeImage.sprite;
			}
			return null;
		}
		set
		{
			if (GradeSprite != value && _oGradeImage != null)
			{
				_oGradeImage.sprite = value;
			}
		}
	}

	public bool RevengeShow
	{
		get
		{
			if (_oRevenge != null)
			{
				return _oRevenge.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RevengeShow != value && _oRevenge != null)
			{
				_oRevenge.SetObjectActive(value);
			}
		}
	}

	public bool KillScoreBackShow
	{
		get
		{
			if (_oKillScoreBack != null)
			{
				return _oKillScoreBack.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (KillScoreBackShow != value && _oKillScoreBack != null)
			{
				_oKillScoreBack.SetObjectActive(value);
			}
		}
	}

	public string KillScroeString
	{
		get
		{
			if (_oKillScroeText != null)
			{
				return _oKillScroeText.text;
			}
			return null;
		}
		set
		{
			if (KillScroeString != value && _oKillScroeText != null)
			{
				_oKillScroeText.text = value;
			}
		}
	}

	public bool RpgComboShow
	{
		get
		{
			if (_oRpgCombo != null)
			{
				return _oRpgCombo.IsActiveSelf();
			}
			return false;
		}
		set
		{
			if (RpgComboShow != value && _oRpgCombo != null)
			{
				_oRpgCombo.SetObjectActive(value);
			}
		}
	}

	public Sprite RpgComboSprite
	{
		get
		{
			if (_oRpgComboImage != null)
			{
				return _oRpgComboImage.sprite;
			}
			return null;
		}
		set
		{
			if (RpgComboSprite != value && _oRpgComboImage != null)
			{
				_oRpgComboImage.sprite = value;
			}
		}
	}

	public string ComboCountString
	{
		get
		{
			if (_oComboCountText != null)
			{
				return _oComboCountText.text;
			}
			return null;
		}
		set
		{
			if (ComboCountString != value && _oComboCountText != null)
			{
				_oComboCountText.text = value;
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
				_oShowCanvasGroup = transform.gameObject.GetComponent<CanvasGroup>();
				break;
			case "KillImage":
				_oKillImage = transform.gameObject;
				_oKillImageImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ContinusKill":
				_oContinusKill = transform.gameObject;
				_oContinusKillImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Grade":
				_oGrade = transform.gameObject;
				_oGradeImage = transform.gameObject.GetComponent<Image>();
				break;
			case "Revenge":
				_oRevenge = transform.gameObject;
				break;
			case "KillScoreBack":
				_oKillScoreBack = transform.gameObject;
				break;
			case "KillScroe":
				_oKillScroe = transform.gameObject;
				_oKillScroeText = transform.gameObject.GetComponent<Text>();
				break;
			case "RpgCombo":
				_oRpgCombo = transform.gameObject;
				_oRpgComboImage = transform.gameObject.GetComponent<Image>();
				break;
			case "ComboCount":
				_oComboCount = transform.gameObject;
				_oComboCountText = transform.gameObject.GetComponent<Text>();
				break;
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
			Object.Destroy(_viewGameObject);
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

	public List<RectTransform> GetHoldPosIntergeTrans()
	{
		return null;
	}
}
