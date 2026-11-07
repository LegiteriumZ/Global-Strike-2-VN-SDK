using System;
using System.Collections.Generic;
using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Ui;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using I2.Loc;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using SSJJNetworking.BattleServer;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_Z_Shop_WeaponModel : AbstractModel, ICursorControl, IKeyboardResponder, IPlaybackSystem
{
	private BioChemical_Z_Shop_WeaponViewModel _viewModel;

	private int[] weaponMaxList = new int[4] { 25, 5, 5, 5 };

	private Color c1 = Color.white;

	private Color c2 = new Color(1f, 1f, 1f, 0.3f);

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioChemical_Z_Shop_WeaponViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(126, UiIEventCondition.Get_gameBioZ_DiffWeaponEvent, SetBioZDiffWeaponEvent);
		NotifyManager.MakeNotifyClass(124, UiIEventCondition.Get_gameBioZ_TipsEvent, SetBioZEvent, initinvoke: true);
		NotifyManager.MakeNotifyClass(125, UiIEventCondition.Get_gameTipsShow_TipsEvent, SetTipsEvent, initinvoke: true);
		_viewModel.ShowShow = false;
		_viewModel.shop_rClicked.AddListener(delegate
		{
			SendMessage(152);
		});
		_viewModel.shop_sClicked.AddListener(delegate
		{
			SendMessage(149);
		});
		_viewModel.shop_xClicked.AddListener(delegate
		{
			SendMessage(148);
		});
		InitUI();
		SimpleNotify.Add(Getlv, Setlv);
		SimpleNotify.Add(GetHide, SetHide);
		SimpleNotify.Add(GetGold, SetGold);
		_viewModel.gold_desString = string.Format("{0} :", ScriptLocalization.Get("HAVE_GOLD"));
		_viewModel.level_desString = string.Format("{0} :  Lv.", ScriptLocalization.Get("CURRENT_LEVEL"));
		_viewModel.closeString = ScriptLocalization.Get("BioChemical_Z_Close");
		_viewModel.level_des_sjString = ScriptLocalization.Get("BioChemical_Z_LevelMsg");
	}

	protected virtual void SetTipsEvent(List<RpgTipsEventData> ov, List<RpgTipsEventData> tipsEvent)
	{
		if (tipsEvent == null)
		{
			return;
		}
		for (int i = 0; i < tipsEvent.Count; i++)
		{
			if (tipsEvent[i].TypeId == -13534)
			{
				Contexts.sharedInstance.message.bioZInit.bioz_show_shop = false;
				tipsEvent.RemoveAt(i);
				i--;
			}
		}
	}

	public bool GetHide(int arg)
	{
		return Contexts.sharedInstance.message.bioZInit.bioz_show_shop;
	}

	public void SetHide(bool arg1, int arg2)
	{
		_viewModel.ShowShow = arg1;
	}

	public int Getlv(int arg1)
	{
		return Contexts.sharedInstance.message.bioZInit.Level;
	}

	public int GetGold(int arg1)
	{
		return Contexts.sharedInstance.message.bioZInit.gold;
	}

	public void Setlv(int arg1, int arg2)
	{
		UpdateWeapon();
	}

	public void SetGold(int arg1, int arg2)
	{
		UpdateWeapon();
	}

	private void SendMessage(int msgID)
	{
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(msgID);
	}

	private void InitUI()
	{
		for (int i = 1; i < 5; i++)
		{
			int index = i;
			Toggle.ToggleEvent toggleEvent = new Toggle.ToggleEvent();
			toggleEvent.AddListener(delegate(bool b)
			{
				if (b)
				{
					IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
					IntData message = new IntData
					{
						Data = index
					};
					server.SendTcpMessage(146, message);
				}
			});
			_viewModel.SetweaponToolTogglechanged(i, toggleEvent);
		}
	}

	private bool SetLockShow(int lv)
	{
		if (Contexts.sharedInstance.message.bioZInit.Level >= lv)
		{
			return false;
		}
		return true;
	}

	private bool SetGoldLockShow(int lv)
	{
		if (Contexts.sharedInstance.message.bioZInit.gold >= lv)
		{
			return false;
		}
		return true;
	}

	protected virtual void SetBioZDiffWeaponEvent(NBioZDiffWeaponData ov, NBioZDiffWeaponData biozData)
	{
		if (biozData != null)
		{
			for (int j = 1; j < 5; j++)
			{
				if (j == biozData.WeaponType)
				{
					_viewModel.SetweaponToolOn(biozData.WeaponType, value: true);
				}
				else
				{
					_viewModel.SetweaponToolOn(j, value: false);
				}
			}
			List<NBioZWeaponData> list = new List<NBioZWeaponData>();
			switch (biozData.WeaponType)
			{
			case 1:
				list = biozData.MasterList;
				break;
			case 2:
				list = biozData.SecondaryList;
				break;
			case 3:
				list = biozData.ClosedList;
				break;
			case 4:
				list = biozData.BomList;
				break;
			}
			int count = list.Count;
			for (int k = 0; k < count; k++)
			{
				int num = k + 1;
				_viewModel.Setr_weaponShow(num, value: true);
				bool flag = !string.IsNullOrEmpty(list[k].WeaponSkinName);
				_viewModel.Setr_nameString(num, LanguageUtils.GetWeaponCnName(flag ? list[k].WeaponSkinName : list[k].WeaponName));
				SetIcon(list[k].WeaponName, list[k].WeaponSkinName, num, delegate(int i1, Sprite sprite)
				{
					_viewModel.Setr_weaponIconSprite(i1, sprite);
				});
				_viewModel.Setr_weaponIconColor(num, (Contexts.sharedInstance.message.bioZInit.gold < list[k].NeedGold) ? c2 : c1);
				Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
				string weaponName = list[k].WeaponName;
				buttonClickedEvent.AddListener(delegate
				{
					IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
					StringData message = new StringData
					{
						Data = weaponName
					};
					server.SendTcpMessage(150, message);
				});
				_viewModel.Setr_weaponClicked(num, buttonClickedEvent);
			}
			for (int l = count; l < 5; l++)
			{
				_viewModel.Setr_weaponShow(l + 1, value: false);
			}
		}
		_viewModel.levelString = Contexts.sharedInstance.message.bioZInit.Level.ToString();
		_viewModel.goldString = Contexts.sharedInstance.message.bioZInit.gold.ToString();
		_viewModel.level_sjString = Contexts.sharedInstance.message.bioZInit.Level.ToString();
	}

	public void SetIcon(string weaponName, string weaponSkin, int i, Action<int, Sprite> action)
	{
		string assPath = $"weapon/{weaponName}";
		if (!string.IsNullOrEmpty(weaponSkin))
		{
			assPath = $"weaponskin/{weaponSkin}";
		}
		base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/weapon_Icon/{assPath}-2.png", delegate(Sprite sprite)
		{
			if (sprite == null)
			{
				assPath += "_ct";
				base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/weapon_Icon/{assPath}-2.png", delegate(Sprite sprite1)
				{
					action(i, sprite1);
				});
			}
			else
			{
				action(i, sprite);
			}
		});
	}

	protected virtual void SetBioZEvent(NBioZInitData ov, NBioZInitData biozData)
	{
		if (biozData == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		for (int j = 0; j < weaponMaxList.Length; j++)
		{
			num2 += weaponMaxList[j];
			int num3 = 0;
			List<NBioZWeaponData> list = new List<NBioZWeaponData>();
			switch (j)
			{
			case 0:
				list = biozData.MasterList;
				break;
			case 1:
				list = biozData.SecondaryList;
				break;
			case 2:
				list = biozData.ClosedList;
				break;
			case 3:
				list = biozData.BomList;
				break;
			}
			num3 = list.Count + num;
			for (int k = num; k < num3; k++)
			{
				int num4 = k + 1;
				NBioZWeaponData nBioZWeaponData = list[k - num];
				_viewModel.Setl_1_weaponShow(num4, value: true);
				bool flag = !string.IsNullOrEmpty(nBioZWeaponData.WeaponSkinName);
				_viewModel.Setl_1_nameString(num4, LanguageUtils.GetWeaponCnName(flag ? nBioZWeaponData.WeaponSkinName : nBioZWeaponData.WeaponName));
				_viewModel.Setl_1_moneyString(num4, nBioZWeaponData.NeedGold.ToString());
				_viewModel.Setl_1_lock_lvString(num4, $" Lv.{nBioZWeaponData.Lv.ToString()}");
				_viewModel.Setl_1_lockShow(num4, SetLockShow(nBioZWeaponData.Lv));
				_viewModel.Setl_1_IconColor(num4, _viewModel.Getl_1_lockShow(num4) ? c2 : c1);
				Button.ButtonClickedEvent buttonClickedEvent = new Button.ButtonClickedEvent();
				string weaponName = nBioZWeaponData.WeaponName;
				buttonClickedEvent.AddListener(delegate
				{
					IBattleServer server = Contexts.sharedInstance.battleServer.battleServer.Server;
					StringData message = new StringData
					{
						Data = weaponName
					};
					server.SendTcpMessage(147, message);
				});
				_viewModel.Setl_1_weaponClicked(num4, buttonClickedEvent);
				SetIcon(nBioZWeaponData.WeaponName, nBioZWeaponData.WeaponSkinName, num4, delegate(int i1, Sprite sprite)
				{
					_viewModel.Setl_1_IconSprite(i1, sprite);
				});
			}
			for (int l = num3; l < num2; l++)
			{
				_viewModel.Setl_1_weaponShow(l + 1, value: false);
			}
			num += weaponMaxList[j];
		}
	}

	private void UpdateWeapon()
	{
		NBioZInitData bioZInitData = Contexts.sharedInstance.message.bioZInit.BioZInitData;
		if (bioZInitData == null)
		{
			return;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < weaponMaxList.Length; i++)
		{
			num2 += weaponMaxList[i];
			int num3 = 0;
			List<NBioZWeaponData> list = new List<NBioZWeaponData>();
			switch (i)
			{
			case 0:
				list = bioZInitData.MasterList;
				break;
			case 1:
				list = bioZInitData.SecondaryList;
				break;
			case 2:
				list = bioZInitData.ClosedList;
				break;
			case 3:
				list = bioZInitData.BomList;
				break;
			}
			num3 = list.Count + num;
			for (int j = num; j < num3; j++)
			{
				int index = j + 1;
				NBioZWeaponData nBioZWeaponData = list[j - num];
				bool flag = SetGoldLockShow(nBioZWeaponData.NeedGold);
				_viewModel.Setl_1_lockShow(index, SetLockShow(nBioZWeaponData.Lv));
				_viewModel.Setl_1_IconColor(index, (_viewModel.Getl_1_lockShow(index) || flag) ? c2 : c1);
				_viewModel.Setl_1_moneyString(index, _viewModel.Getl_1_lockShow(index) ? "" : nBioZWeaponData.NeedGold.ToString());
			}
			num += weaponMaxList[i];
		}
	}

	private void InitChips()
	{
	}

	public int GetCursorState()
	{
		if (!_viewModel.ShowShow)
		{
			return 0;
		}
		return 64;
	}

	public int GetForbidButtons()
	{
		return 0;
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (key == KeyCode.R && _viewModel.ShowShow)
		{
			SendMessage(152);
		}
		else if (key == KeyCode.S && _viewModel.ShowShow)
		{
			SendMessage(149);
		}
		else if (key == KeyCode.X && _viewModel.ShowShow)
		{
			SendMessage(148);
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

	public void OnPlayback()
	{
	}
}
