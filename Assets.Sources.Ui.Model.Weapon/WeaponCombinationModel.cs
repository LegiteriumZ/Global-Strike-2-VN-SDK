using System;
using System.Collections.Generic;
using Assets.Sources.Components.Interface;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Weapon;
using Assets.UiFramework.Libs;
using I2.Loc;
using NotifyEvent;
using SSJJBase.Input;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Weapon;

public class WeaponCombinationModel : AbstractModel, IPlaybackSystem, ISetGameRuleContext, ISetBattleServerContext, ISetWeaponContext, ICursorControl, IKeyboardResponder
{
	public static int COMPONENT1EXIST = 1;

	public static int COMPONENT1SELECTED = 2;

	public static int COMPONENT2EXIST = 4;

	public static int COMPONENT2SELECTED = 8;

	public static int COMPONENT3EXIST = 16;

	public static int COMPONENT3SELECTED = 32;

	public static int COMPONENT4EXIST = 64;

	public static int COMPONENT4SELECTED = 128;

	public static int COMPONENT5EXIST = 65536;

	public static int COMPONENT5SELECTED = 131072;

	public static int COMPONENT6EXIST = 262144;

	public static int COMPONENT6SELECTED = 524288;

	public static int COMPONENT7EXIST = 1048576;

	public static int COMPONENT7SELECTED = 2097152;

	public static int COMPONENT8EXIST = 4194304;

	public static int COMPONENT8SELECTED = 8388608;

	public static int COMPONENT9EXIST = 256;

	public static int COMPONENT9SELECTED = 512;

	public static int COMPONENT10EXIST = 1024;

	public static int COMPONENT10SELECTED = 2048;

	public static int COMPONENT11EXIST = 4096;

	public static int COMPONENT11SELECTED = 8192;

	public static int COMPONENT12EXIST = 16384;

	public static int COMPONENT12SELECTED = 32768;

	public static int WEAPONSWEEPATTACK = 1073741824;

	private WeaponCombinationViewModel _viewModel;

	private BattleServerContext _battleServerContext;

	private Dictionary<IgnoreCaseString, SkinnedMeshRenderer> skins;

	private Dictionary<IParticleKey, IPaticlePrefabInstancecs> particles;

	private WeaponContext _weaponContext;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public void SetWeaponContext(WeaponContext context)
	{
		_weaponContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new WeaponCombinationViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	private bool IsPrefab(GameObject go)
	{
		if (Application.isEditor && !Application.isPlaying)
		{
			throw new InvalidOperationException("MethodIsOnlyAllowedInPlayMode");
		}
		return go.scene.buildIndex < 0;
	}

	private void SetLayer(Transform trans, int layer)
	{
		if (!(trans != null))
		{
			return;
		}
		foreach (Transform tran in trans)
		{
			tran.gameObject.layer = layer;
			SetLayer(tran, layer);
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		_viewModel.TipsBackShow = false;
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		NotifyManager.MakeTempNotify(GetEffectLevel, SetEffectLevel, null, initinvoke: true);
		base.Loader.Load("weapon/hero_blade", "Assets/Res/Assets/weapon/hero_blade/scene/model.prefab", delegate(UnityEngine.Object obj)
		{
			GameObject gameObject = obj as GameObject;
			if (IsPrefab(gameObject))
			{
				gameObject = gameObject.CreateInstance();
			}
			gameObject.transform.SetParent(_viewModel.GameObjectObj.transform.Find("model"));
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localEulerAngles = Vector3.zero;
			gameObject.transform.localScale = Vector3.one;
			Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
			gameObject.layer = _viewModel.GameObjectObj.layer;
			Transform[] array = componentsInChildren;
			for (int l = 0; l < array.Length; l++)
			{
				array[l].gameObject.layer = _viewModel.GameObjectObj.layer;
			}
			skins = new Dictionary<IgnoreCaseString, SkinnedMeshRenderer>();
			WeaponUtility.GetSkins(_viewModel.GameObjectObj, skins);
			particles = new Dictionary<IParticleKey, IPaticlePrefabInstancecs>();
			WeaponUtility.GetParticles(_viewModel.GameObjectObj, particles);
			foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in particles)
			{
				IPaticlePrefabInstancecs value = particle.Value;
				SetLayer(value.GetIns().transform, _viewModel.GameObjectObj.layer);
			}
		}, typeof(GameObject));
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers1, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow1)
			{
				_viewModel.SelectedIconShow1 = true;
				_viewModel.SelectedIconShow2 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers2, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow2)
			{
				_viewModel.SelectedIconShow2 = true;
				_viewModel.SelectedIconShow1 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers3, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow3)
			{
				_viewModel.SelectedIconShow3 = true;
				_viewModel.SelectedIconShow4 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers4, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow4)
			{
				_viewModel.SelectedIconShow4 = true;
				_viewModel.SelectedIconShow3 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers5, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow5)
			{
				_viewModel.SelectedIconShow5 = true;
				_viewModel.SelectedIconShow6 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers6, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow6)
			{
				_viewModel.SelectedIconShow6 = true;
				_viewModel.SelectedIconShow5 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers7, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow7)
			{
				_viewModel.SelectedIconShow7 = true;
				_viewModel.SelectedIconShow8 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers8, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow8)
			{
				_viewModel.SelectedIconShow8 = true;
				_viewModel.SelectedIconShow7 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers9, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow9)
			{
				_viewModel.SelectedIconShow9 = true;
				_viewModel.SelectedIconShow10 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers10, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow10)
			{
				_viewModel.SelectedIconShow10 = true;
				_viewModel.SelectedIconShow9 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers11, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow11)
			{
				_viewModel.SelectedIconShow11 = true;
				_viewModel.SelectedIconShow12 = false;
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers12, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow12)
			{
				_viewModel.SelectedIconShow12 = true;
				_viewModel.SelectedIconShow11 = false;
			}
		});
		for (int j = 1; j <= 12; j++)
		{
			List<EventTrigger.Entry> partTriggers = _viewModel.GetPartTriggers(j);
			int i2 = j;
			_viewModel.CreateTriggerEntry(partTriggers, EventTriggerType.PointerEnter, delegate
			{
				_viewModel.TipsBackShow = true;
				_viewModel.TipsString = ScriptLocalization.Get("PartTips" + i2).Replace("\\n", "\n");
				_viewModel.TipsBackGposition = Input.mousePosition + new Vector3(5f, 5f);
			});
			_viewModel.CreateTriggerEntry(partTriggers, EventTriggerType.PointerExit, delegate
			{
				_viewModel.TipsBackShow = false;
			});
		}
		_viewModel.SelectedIconClicked1.AddListener(delegate
		{
			_viewModel.SelectedIconShow1 = false;
		});
		_viewModel.SelectedIconClicked2.AddListener(delegate
		{
			_viewModel.SelectedIconShow2 = false;
		});
		_viewModel.SelectedIconClicked3.AddListener(delegate
		{
			_viewModel.SelectedIconShow3 = false;
		});
		_viewModel.SelectedIconClicked4.AddListener(delegate
		{
			_viewModel.SelectedIconShow4 = false;
		});
		_viewModel.SelectedIconClicked5.AddListener(delegate
		{
			_viewModel.SelectedIconShow5 = false;
		});
		_viewModel.SelectedIconClicked6.AddListener(delegate
		{
			_viewModel.SelectedIconShow6 = false;
		});
		_viewModel.SelectedIconClicked7.AddListener(delegate
		{
			_viewModel.SelectedIconShow7 = false;
		});
		_viewModel.SelectedIconClicked8.AddListener(delegate
		{
			_viewModel.SelectedIconShow8 = false;
		});
		_viewModel.SelectedIconClicked9.AddListener(delegate
		{
			_viewModel.SelectedIconShow9 = false;
		});
		_viewModel.SelectedIconClicked10.AddListener(delegate
		{
			_viewModel.SelectedIconShow10 = false;
		});
		_viewModel.SelectedIconClicked11.AddListener(delegate
		{
			_viewModel.SelectedIconShow11 = false;
		});
		_viewModel.SelectedIconClicked12.AddListener(delegate
		{
			_viewModel.SelectedIconShow12 = false;
		});
		EventTrigger.Entry entry = new EventTrigger.Entry
		{
			callback = new EventTrigger.TriggerEvent(),
			eventID = EventTriggerType.PointerClick
		};
		entry.callback.AddListener(delegate
		{
			_viewModel.SelectedIconShow1 = !_viewModel.ForbidIconShow1;
			_viewModel.SelectedIconShow2 = false;
			_viewModel.SelectedIconShow3 = !_viewModel.ForbidIconShow3;
			_viewModel.SelectedIconShow4 = false;
			_viewModel.SelectedIconShow9 = !_viewModel.ForbidIconShow9;
			_viewModel.SelectedIconShow10 = false;
			_viewModel.SelectedIconShow11 = !_viewModel.ForbidIconShow11;
			_viewModel.SelectedIconShow12 = false;
			SetVisible(value: false);
			_battleServerContext.battleServer.Server.SendTcpMessage(26, GetCombination());
		});
		_viewModel.PvpBtnTriggers.Add(entry);
		EventTrigger.Entry entry2 = new EventTrigger.Entry
		{
			callback = new EventTrigger.TriggerEvent(),
			eventID = EventTriggerType.PointerClick
		};
		entry2.callback.AddListener(delegate
		{
			_viewModel.SelectedIconShow1 = false;
			_viewModel.SelectedIconShow2 = !_viewModel.ForbidIconShow2;
			_viewModel.SelectedIconShow3 = false;
			_viewModel.SelectedIconShow4 = !_viewModel.ForbidIconShow4;
			_viewModel.SelectedIconShow9 = false;
			_viewModel.SelectedIconShow10 = !_viewModel.ForbidIconShow10;
			_viewModel.SelectedIconShow11 = false;
			_viewModel.SelectedIconShow12 = !_viewModel.ForbidIconShow12;
			SetVisible(value: false);
			_battleServerContext.battleServer.Server.SendTcpMessage(26, GetCombination());
		});
		_viewModel.BioBtnTriggers.Add(entry2);
		for (int k = 1; k <= 12; k++)
		{
			int i1 = k;
			base.Loader.RetriveSprite("weapon/hero_blade", "Assets/Res/Assets/weapon/hero_blade/ui/part" + k + ".png", delegate(Sprite sprite)
			{
				_viewModel.SetWeaponIconSprite(i1, sprite);
			});
		}
	}

	private void SetVisible(bool value)
	{
		_viewModel.ShowShow = value;
		_gameRuleContext.weaponCombination.HideFirstPersonView = value;
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		if (weaponName != "hero_blade")
		{
			SetVisible(value: false);
		}
	}

	private int GetEffectLevel()
	{
		if (!_weaponContext.isCurrentWeapon)
		{
			return 0;
		}
		return _weaponContext.currentWeaponEntity.basicInfo.Data.EffectLevel;
	}

	private void SetEffectLevel(int ov, int data)
	{
		_viewModel.ForbidIconShow1 = (data & COMPONENT1EXIST) == 0;
		_viewModel.SelectedIconShow1 = (data & COMPONENT1SELECTED) > 0;
		_viewModel.ForbidIconShow2 = (data & COMPONENT2EXIST) == 0;
		_viewModel.SelectedIconShow2 = (data & COMPONENT2SELECTED) > 0;
		_viewModel.ForbidIconShow3 = (data & COMPONENT3EXIST) == 0;
		_viewModel.SelectedIconShow3 = (data & COMPONENT3SELECTED) > 0;
		_viewModel.ForbidIconShow4 = (data & COMPONENT4EXIST) == 0;
		_viewModel.SelectedIconShow4 = (data & COMPONENT4SELECTED) > 0;
		_viewModel.ForbidIconShow5 = (data & COMPONENT5EXIST) == 0;
		_viewModel.SelectedIconShow5 = (data & COMPONENT5SELECTED) > 0;
		_viewModel.ForbidIconShow6 = (data & COMPONENT6EXIST) == 0;
		_viewModel.SelectedIconShow6 = (data & COMPONENT6SELECTED) > 0;
		_viewModel.ForbidIconShow7 = (data & COMPONENT7EXIST) == 0;
		_viewModel.SelectedIconShow7 = (data & COMPONENT7SELECTED) > 0;
		_viewModel.ForbidIconShow8 = (data & COMPONENT8EXIST) == 0;
		_viewModel.SelectedIconShow8 = (data & COMPONENT8SELECTED) > 0;
		_viewModel.ForbidIconShow9 = (data & COMPONENT9EXIST) == 0;
		_viewModel.SelectedIconShow9 = (data & COMPONENT9SELECTED) > 0;
		_viewModel.ForbidIconShow10 = (data & COMPONENT10EXIST) == 0;
		_viewModel.SelectedIconShow10 = (data & COMPONENT10SELECTED) > 0;
		_viewModel.ForbidIconShow11 = (data & COMPONENT11EXIST) == 0;
		_viewModel.SelectedIconShow11 = (data & COMPONENT11SELECTED) > 0;
		_viewModel.ForbidIconShow12 = (data & COMPONENT12EXIST) == 0;
		_viewModel.SelectedIconShow12 = (data & COMPONENT12SELECTED) > 0;
	}

	private int GetCombination()
	{
		int num = 0;
		if (!_viewModel.ForbidIconShow1)
		{
			num += COMPONENT1EXIST;
		}
		if (!_viewModel.ForbidIconShow2)
		{
			num += COMPONENT2EXIST;
		}
		if (!_viewModel.ForbidIconShow3)
		{
			num += COMPONENT3EXIST;
		}
		if (!_viewModel.ForbidIconShow4)
		{
			num += COMPONENT4EXIST;
		}
		if (!_viewModel.ForbidIconShow5)
		{
			num += COMPONENT5EXIST;
		}
		if (!_viewModel.ForbidIconShow6)
		{
			num += COMPONENT6EXIST;
		}
		if (!_viewModel.ForbidIconShow7)
		{
			num += COMPONENT7EXIST;
		}
		if (!_viewModel.ForbidIconShow8)
		{
			num += COMPONENT8EXIST;
		}
		if (!_viewModel.ForbidIconShow9)
		{
			num += COMPONENT9EXIST;
		}
		if (!_viewModel.ForbidIconShow10)
		{
			num += COMPONENT10EXIST;
		}
		if (!_viewModel.ForbidIconShow11)
		{
			num += COMPONENT11EXIST;
		}
		if (!_viewModel.ForbidIconShow12)
		{
			num += COMPONENT12EXIST;
		}
		if (_viewModel.SelectedIconShow1 && !_viewModel.ForbidIconShow1)
		{
			num += COMPONENT1SELECTED;
		}
		if (_viewModel.SelectedIconShow2 && !_viewModel.ForbidIconShow2)
		{
			num += COMPONENT2SELECTED;
		}
		if (_viewModel.SelectedIconShow3 && !_viewModel.ForbidIconShow3)
		{
			num += COMPONENT3SELECTED;
		}
		if (_viewModel.SelectedIconShow4 && !_viewModel.ForbidIconShow4)
		{
			num += COMPONENT4SELECTED;
		}
		if (_viewModel.SelectedIconShow5 && !_viewModel.ForbidIconShow5)
		{
			num += COMPONENT5SELECTED;
		}
		if (_viewModel.SelectedIconShow6 && !_viewModel.ForbidIconShow6)
		{
			num += COMPONENT6SELECTED;
		}
		if (_viewModel.SelectedIconShow7 && !_viewModel.ForbidIconShow7)
		{
			num += COMPONENT7SELECTED;
		}
		if (_viewModel.SelectedIconShow8 && !_viewModel.ForbidIconShow8)
		{
			num += COMPONENT8SELECTED;
		}
		if (_viewModel.SelectedIconShow9 && !_viewModel.ForbidIconShow9)
		{
			num += COMPONENT9SELECTED;
		}
		if (_viewModel.SelectedIconShow10 && !_viewModel.ForbidIconShow10)
		{
			num += COMPONENT10SELECTED;
		}
		if (_viewModel.SelectedIconShow11 && !_viewModel.ForbidIconShow11)
		{
			num += COMPONENT11SELECTED;
		}
		if (_viewModel.SelectedIconShow12 && !_viewModel.ForbidIconShow12)
		{
			num += COMPONENT12SELECTED;
		}
		return num;
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 512;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.V)
		{
			if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
			{
				SetVisible(value: false);
				return false;
			}
			if (UiIEventCondition.Get_weaponState_WeaponName() != "hero_blade")
			{
				SetVisible(value: false);
				return false;
			}
			SetVisible(!_viewModel.ShowShow);
			if (!_viewModel.ShowShow)
			{
				_battleServerContext.battleServer.Server.SendTcpMessage(26, GetCombination());
			}
		}
		if (_viewModel.ShowShow && key == KeyCode.V)
		{
			return true;
		}
		return false;
	}

	public bool OnKeyUp(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyDown(KeyCode key)
	{
		return false;
	}

	public bool ForbidKeyUp(KeyCode key)
	{
		return false;
	}

	private void InitChips()
	{
	}

	private void SetPaticleBySkinName(string name, bool flag)
	{
		foreach (KeyValuePair<IParticleKey, IPaticlePrefabInstancecs> particle in particles)
		{
			if (particle.Key.JointName.Equals(name))
			{
				particle.Value.SetInsActive(flag);
			}
		}
	}

	private void UpdateChips()
	{
		if (skins != null && _viewModel.ShowShow)
		{
			int combination = GetCombination();
			skins["weaponeffect21"].enabled = (combination & COMPONENT1SELECTED) > 0;
			skins["weaponeffect22"].enabled = (combination & COMPONENT2SELECTED) > 0;
			skins["weaponeffect23"].enabled = (combination & COMPONENT3SELECTED) > 0;
			skins["weaponeffect24"].enabled = (combination & COMPONENT4SELECTED) > 0;
			skins["weaponeffect25"].enabled = (combination & COMPONENT9SELECTED) > 0;
			skins["weaponeffect26"].enabled = (combination & COMPONENT10SELECTED) > 0;
			SetPaticleBySkinName("weapon_particle_effect", (combination & COMPONENT11SELECTED) > 0);
			SetPaticleBySkinName("weapon_particle_effect1", (combination & COMPONENT12SELECTED) > 0);
		}
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
