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

namespace Assets.Sources.Ui.ViewModel.BioEvolution;

[GameUiTest]
public class BioEvolutionVariantGrowUpViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oLevel1;

	private Image _oLevelImage1;

	private GameObject _oAngle;

	private Text _oAngleText;

	private GameObject _oJump;

	private Text _oJumpText;

	private GameObject _oHp;

	private Text _oHpText;

	private GameObject _viewGameObject;

	private bool _refrencelessLoaded;

	private string _resourceBundleName = "uiprefabs/bioevolution";

	private string _resourceAssetName = "BioEvolutionVariantGrowUp";

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

	public float LevelFillamount1
	{
		get
		{
			if (_oLevelImage1 != null)
			{
				return _oLevelImage1.fillAmount;
			}
			return 0f;
		}
		set
		{
			if (LevelFillamount1 != value && _oLevelImage1 != null)
			{
				_oLevelImage1.fillAmount = value;
			}
		}
	}

	public string AngleString
	{
		get
		{
			if (_oAngleText != null)
			{
				return _oAngleText.text;
			}
			return null;
		}
		set
		{
			if (AngleString != value && _oAngleText != null)
			{
				_oAngleText.text = value;
			}
		}
	}

	public string JumpString
	{
		get
		{
			if (_oJumpText != null)
			{
				return _oJumpText.text;
			}
			return null;
		}
		set
		{
			if (JumpString != value && _oJumpText != null)
			{
				_oJumpText.text = value;
			}
		}
	}

	public string HpString
	{
		get
		{
			if (_oHpText != null)
			{
				return _oHpText.text;
			}
			return null;
		}
		set
		{
			if (HpString != value && _oHpText != null)
			{
				_oHpText.text = value;
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
			case "Level1":
				_oLevel1 = transform.gameObject;
				_oLevelImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Angle":
				_oAngle = transform.gameObject;
				_oAngleText = transform.gameObject.GetComponent<Text>();
				break;
			case "Jump":
				_oJump = transform.gameObject;
				_oJumpText = transform.gameObject.GetComponent<Text>();
				break;
			case "Hp":
				_oHp = transform.gameObject;
				_oHpText = transform.gameObject.GetComponent<Text>();
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

	public float GetLevelFillamount(int index)
	{
		if (index == 1)
		{
			return LevelFillamount1;
		}
		return 0f;
	}

	public void SetLevelFillamount(int index, float value)
	{
		if (index == 1)
		{
			LevelFillamount1 = value;
		}
	}

	public int GetLevelCount()
	{
		return 1;
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
