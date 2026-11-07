using System.Collections.Generic;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using Loxodon.Framework.ViewModels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Sources.Ui.ViewModel.Group;

[GameUiTest]
public class GroupStrikeIndividualScoreInfoViewModel : ViewModelBase, IUiViewModel
{
	private GameObject _oShow;

	private GameObject _oTeamGrid1;

	private GameObject _oTeamGrid2;

	private GameObject _oTitle1;

	private GameObject _oTitle2;

	private Image _oTitleImage1;

	private Image _oTitleImage2;

	private GameObject _viewGameObject;

	private string _resourceBundleName = "uiprefabs/group";

	private string _resourceAssetName = "GroupStrikeIndividualScoreInfo";

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

	public GameObject TeamGridObj1 => _oTeamGrid1;

	public GameObject TeamGridObj2 => _oTeamGrid2;

	public Sprite TitleSprite1
	{
		get
		{
			if (_oTitleImage1 != null)
			{
				return _oTitleImage1.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite1 != value && _oTitleImage1 != null)
			{
				_oTitleImage1.sprite = value;
			}
		}
	}

	public Sprite TitleSprite2
	{
		get
		{
			if (_oTitleImage2 != null)
			{
				return _oTitleImage2.sprite;
			}
			return null;
		}
		set
		{
			if (TitleSprite2 != value && _oTitleImage2 != null)
			{
				_oTitleImage2.sprite = value;
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
			case "TeamGrid1":
				_oTeamGrid1 = transform.gameObject;
				break;
			case "TeamGrid2":
				_oTeamGrid2 = transform.gameObject;
				break;
			case "Title1":
				_oTitle1 = transform.gameObject;
				_oTitleImage1 = transform.gameObject.GetComponent<Image>();
				break;
			case "Title2":
				_oTitle2 = transform.gameObject;
				_oTitleImage2 = transform.gameObject.GetComponent<Image>();
				break;
			}
		}
	}

	public GameObject GetTeamGridObj(int index)
	{
		return index switch
		{
			1 => TeamGridObj1, 
			2 => TeamGridObj2, 
			_ => null, 
		};
	}

	public Sprite GetTitleSprite(int index)
	{
		return index switch
		{
			1 => TitleSprite1, 
			2 => TitleSprite2, 
			_ => null, 
		};
	}

	public void SetTitleSprite(int index, Sprite value)
	{
		switch (index)
		{
		case 1:
			TitleSprite1 = value;
			break;
		case 2:
			TitleSprite2 = value;
			break;
		}
	}

	public void TitleNtvsize1()
	{
		if (_oTitleImage1 != null)
		{
			_oTitleImage1.SetNativeSize();
		}
	}

	public void TitleNtvsize2()
	{
		if (_oTitleImage2 != null)
		{
			_oTitleImage2.SetNativeSize();
		}
	}

	public void CallTitleNtvsize(int index)
	{
		switch (index)
		{
		case 1:
			TitleNtvsize1();
			break;
		case 2:
			TitleNtvsize2();
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
