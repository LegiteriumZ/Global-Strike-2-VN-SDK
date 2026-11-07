using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Weapon;
using Assets.Sources.Utils.Ui;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Weapon;

public class PhotonDeformationModel : AbstractModel, IPlaybackSystem, ISetBattleServerContext, ISetGameRuleContext, ICursorControl, IKeyboardResponder
{
	private PhotonDeformationViewModel _viewModel;

	private BattleServerContext _battleServerContext;

	private string _wpName;

	private GameRuleContext _gameRuleContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public void SetBattleServerContext(BattleServerContext context)
	{
		_battleServerContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PhotonDeformationViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		if (!_gameRuleContext.currentRule.Rule.IsGeneralPve())
		{
			_viewModel.ShowShow = false;
			return;
		}
		base.DoSubscribe();
		_viewModel.ShowShow = false;
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_weaponState_WeaponName, SetWeaponName, null, initinvoke: true);
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers1, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow1)
			{
				CancelAll();
				_viewModel.SelectedIconShow1 = true;
				base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination1.png", delegate(Sprite sprite)
				{
					_viewModel.WeaponImageSprite = sprite;
				});
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers2, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow2)
			{
				CancelAll();
				_viewModel.SelectedIconShow2 = true;
				base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination2.png", delegate(Sprite sprite)
				{
					_viewModel.WeaponImageSprite = sprite;
				});
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers3, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow3)
			{
				CancelAll();
				_viewModel.SelectedIconShow3 = true;
				base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination3.png", delegate(Sprite sprite)
				{
					_viewModel.WeaponImageSprite = sprite;
				});
			}
		});
		_viewModel.CreateTriggerEntry(_viewModel.PartTriggers4, EventTriggerType.PointerClick, delegate
		{
			if (!_viewModel.ForbidIconShow4)
			{
				CancelAll();
				_viewModel.SelectedIconShow4 = true;
				base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination0.png", delegate(Sprite sprite)
				{
					_viewModel.WeaponImageSprite = sprite;
				});
			}
		});
	}

	private void CancelAll()
	{
		_viewModel.SelectedIconShow1 = false;
		_viewModel.SelectedIconShow2 = false;
		_viewModel.SelectedIconShow3 = false;
		_viewModel.SelectedIconShow4 = false;
	}

	private bool ShowUi(string weaponName)
	{
		switch (weaponName)
		{
		default:
			return weaponName == "photon_grenade_combination1";
		case "photon_deformation":
		case "photon_deformation1":
		case "photon_pistol_combination":
		case "photon_pistol_combination1":
		case "photon_sword_combination":
		case "photon_sword_combination1":
		case "photon_grenade_combination":
			return true;
		}
	}

	private void SetWeaponName(string ov, string weaponName)
	{
		if (!ShowUi(weaponName))
		{
			_viewModel.ShowShow = false;
			return;
		}
		switch (weaponName)
		{
		case "photon_deformation1":
		case "photon_pistol_combination1":
		case "photon_sword_combination1":
		case "photon_grenade_combination1":
			_wpName = "photon_deformation1";
			break;
		case "photon_deformation":
		case "photon_pistol_combination":
		case "photon_sword_combination":
		case "photon_grenade_combination":
			_wpName = "photon_deformation";
			break;
		}
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "combinationWeaponBack"), delegate(Sprite sprite)
		{
			_viewModel.ImageBGSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "weaponName"), delegate(Sprite sprite)
		{
			_viewModel.WeaponNameSprite = sprite;
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "placeSelectButton_defaultState"), delegate(Sprite sprite)
		{
			for (int num4 = 0; num4 < 4; num4++)
			{
				_viewModel.SetPartSprite(num4 + 1, sprite);
			}
		});
		SpriteState[] spriteStates = new SpriteState[4];
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "placeSelectButton_hoverState"), delegate(Sprite sprite)
		{
			for (int num3 = 0; num3 < 4; num3++)
			{
				spriteStates[num3].highlightedSprite = sprite;
				_viewModel.GetPartObj(num3 + 1).GetComponent<Button>().spriteState = spriteStates[num3];
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "placeSelectButton_downState"), delegate(Sprite sprite)
		{
			for (int num2 = 0; num2 < 4; num2++)
			{
				spriteStates[num2].pressedSprite = sprite;
				_viewModel.GetPartObj(num2 + 1).GetComponent<Button>().spriteState = spriteStates[num2];
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "placeSelectButton_disabledState"), delegate(Sprite sprite)
		{
			for (int num = 0; num < 4; num++)
			{
				spriteStates[num].disabledSprite = sprite;
				_viewModel.GetPartObj(num + 1).GetComponent<Button>().spriteState = spriteStates[num];
			}
		});
		SpriteState[] iconStates = new SpriteState[4];
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "placeSelectButton_activeDefaultState"), delegate(Sprite sprite)
		{
			for (int n = 0; n < 4; n++)
			{
				_viewModel.SetSelectedIconSprite(n + 1, sprite);
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "placeSelectButton_activeDownState"), delegate(Sprite sprite)
		{
			for (int m = 0; m < 4; m++)
			{
				iconStates[m].pressedSprite = sprite;
				_viewModel.GetSelectedIconObj(m + 1).GetComponent<Button>().spriteState = iconStates[m];
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "placeSelectButton_activeHoverState"), delegate(Sprite sprite)
		{
			for (int l = 0; l < 4; l++)
			{
				iconStates[l].highlightedSprite = sprite;
				_viewModel.GetSelectedIconObj(l + 1).GetComponent<Button>().spriteState = iconStates[l];
			}
		});
		base.Loader.RetriveSprite(UiAssetBundleUtils.GetWeaponBundleName(_wpName), UiAssetBundleUtils.GetWeaponTexturePath(_wpName, "noplace"), delegate(Sprite sprite)
		{
			for (int k = 0; k < 4; k++)
			{
				_viewModel.SetForbidIconSprite(k + 1, sprite);
			}
		});
		PlayerBagEntity currentBagEntity = Contexts.sharedInstance.playerBag.currentBagEntity;
		string text = ((currentBagEntity.basicInfo.Data.FirstWeapon != null) ? currentBagEntity.basicInfo.Data.FirstWeapon.WeaponName : "");
		string text2 = ((currentBagEntity.basicInfo.Data.SecondaryWeapon != null) ? currentBagEntity.basicInfo.Data.SecondaryWeapon.WeaponName : "");
		string text3 = ((currentBagEntity.basicInfo.Data.MeleeWeapon != null) ? currentBagEntity.basicInfo.Data.MeleeWeapon.WeaponName : "");
		string text4 = ((currentBagEntity.basicInfo.Data.BombWeapons0 != null) ? currentBagEntity.basicInfo.Data.BombWeapons0.WeaponName : "");
		string text5 = ((currentBagEntity.basicInfo.Data.BombWeapons1 != null) ? currentBagEntity.basicInfo.Data.BombWeapons1.WeaponName : "");
		string text6 = ((currentBagEntity.basicInfo.Data.BombWeapons2 != null) ? currentBagEntity.basicInfo.Data.BombWeapons2.WeaponName : "");
		_viewModel.ForbidIconShow1 = text2 != "photon_pistol" && text2 != "photon_pistol1";
		_viewModel.ForbidIconShow2 = text3 != "photon_sword" && text3 != "photon_sword1";
		_viewModel.ForbidIconShow3 = text4 != "photon_grenade" && text4 != "photon_grenade1" && text5 != "photon_grenade" && text5 != "photon_grenade1" && text6 != "photon_grenade" && text6 != "photon_grenade1";
		_viewModel.SelectedIconShow1 = !_viewModel.ForbidIconShow1 && (text == "photon_pistol_combination" || text == "photon_pistol_combination1");
		_viewModel.SelectedIconShow2 = !_viewModel.ForbidIconShow2 && (text == "photon_sword_combination" || text == "photon_sword_combination1");
		_viewModel.SelectedIconShow3 = !_viewModel.ForbidIconShow3 && (text == "photon_grenade_combination" || text == "photon_grenade_combination1");
		_viewModel.SelectedIconShow4 = !_viewModel.SelectedIconShow1 && !_viewModel.SelectedIconShow2 && !_viewModel.SelectedIconShow3;
		if (_viewModel.SelectedIconShow1)
		{
			base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination1.png", delegate(Sprite sprite)
			{
				_viewModel.WeaponImageSprite = sprite;
			});
		}
		else if (_viewModel.SelectedIconShow2)
		{
			base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination2.png", delegate(Sprite sprite)
			{
				_viewModel.WeaponImageSprite = sprite;
			});
		}
		else if (_viewModel.SelectedIconShow3)
		{
			base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination3.png", delegate(Sprite sprite)
			{
				_viewModel.WeaponImageSprite = sprite;
			});
		}
		else
		{
			base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/combination0.png", delegate(Sprite sprite)
			{
				_viewModel.WeaponImageSprite = sprite;
			});
		}
		for (int j = 1; j <= 4; j++)
		{
			int i1 = j;
			base.Loader.RetriveSprite("weapon/" + _wpName, "Assets/Res/Assets/weapon/" + _wpName + "/ui/place" + j + "Icon.png", delegate(Sprite sprite)
			{
				_viewModel.SetWeaponIconSprite(i1, sprite);
			});
		}
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
			if (!RuleUtilty.IsGeneralPve(UiIEventCondition.Get_uiRoomData_RaceType()))
			{
				return false;
			}
			if (UiIEventCondition.Get_cameraOwnerData_Observer() > 0)
			{
				_viewModel.ShowShow = false;
				return false;
			}
			string weaponState_WeaponName = UiIEventCondition.Get_weaponState_WeaponName();
			if (!ShowUi(weaponState_WeaponName))
			{
				_viewModel.ShowShow = false;
				return false;
			}
			_viewModel.ShowShow = !_viewModel.ShowShow;
			if (!_viewModel.ShowShow)
			{
				if (_viewModel.SelectedIconShow1)
				{
					_battleServerContext.battleServer.Server.SendTcpMessage(25, 1);
				}
				if (_viewModel.SelectedIconShow2)
				{
					_battleServerContext.battleServer.Server.SendTcpMessage(25, 2);
				}
				if (_viewModel.SelectedIconShow3)
				{
					_battleServerContext.battleServer.Server.SendTcpMessage(25, 3);
				}
				if (_viewModel.SelectedIconShow4)
				{
					_battleServerContext.battleServer.Server.SendTcpMessage(25, 0);
				}
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

	private void UpdateChips()
	{
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}
}
