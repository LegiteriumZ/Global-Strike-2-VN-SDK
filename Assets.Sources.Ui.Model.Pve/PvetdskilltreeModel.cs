using System;
using System.Collections.Generic;
using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Pve;
using Assets.Sources.Utils.UIChip;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.Pve;

public class PvetdskilltreeModel : AbstractModel, IPlaybackSystem, ICursorControl, ISetMessageContext
{
	private class SkillTreeInfo : IEquatable<SkillTreeInfo>
	{
		public PassiveSkillComponent PassiveSkill;

		public int Index;

		public int CanStudioSkillType;

		public SkillTreeInfo(int idx = 0)
		{
			CanStudioSkillType = 0;
			PassiveSkill = null;
			Index = idx;
		}

		public bool Equals(SkillTreeInfo other)
		{
			if (CanStudioSkillType != other.CanStudioSkillType)
			{
				return false;
			}
			if (Index != other.Index)
			{
				return false;
			}
			if (PassiveSkill != other.PassiveSkill)
			{
				return false;
			}
			return true;
		}
	}

	private PvetdskilltreeViewModel _viewModel;

	private Dictionary<string, SkillTreeInfo> _skillTreeInfoList = new Dictionary<string, SkillTreeInfo>();

	private Dictionary<int, SkillTreeInfo> _touchImageToSkillInfoDic = new Dictionary<int, SkillTreeInfo>();

	private int _lastSpecializationType = -1;

	private bool? SpecialMode;

	private int? _enterTime;

	private int _touchIdx;

	private PingPongChip _skillStudioSpriteChip = new PingPongChip();

	private FloatChip _skillEffectImageXChip = new FloatChip();

	private ActiveChip _skillEffectImageActiveChip = new ActiveChip();

	private ActiveChip _skillBoundImageActiveChip = new ActiveChip();

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public int CloseDelay { get; set; }

	public int GetForbidButtons()
	{
		return 0;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new PvetdskilltreeViewModel();
	}

	public virtual void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		if (_viewModel.pvetdskilltreeShow)
		{
			PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
			if (myPlayerEntity != null)
			{
				PlayerInfoData playerInfo = myPlayerEntity.GetPlayerInfo();
				_viewModel.playerMoneytextString = playerInfo.Money.ToString();
				_viewModel.playerLvtextString = playerInfo.Lv.ToString();
				_viewModel.playerGptextString = playerInfo.Gp.ToString();
			}
			UpdateAddDamagerImage();
			UpdateWeaponSkillImage();
		}
		GameUpdate(_timeComponent.FrameInterval);
	}

	protected override void DoPreSubscribe()
	{
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_SkillTreeChanged, SetPassiveMsg, _viewModel.pvetdskilltreeObj);
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		_viewModel.pvetdskilltreeShow = false;
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_pveUIMessage_SelectSkillPanel, SetSelectPanel, _viewModel.pvetdskilltreeObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_addExpData_currentExp, AddExpChange, _viewModel.pvetdskilltreeObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_addExpData_addExp, AddExpChange, _viewModel.pvetdskilltreeObj);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_addExpData_maxExp, AddExpChange, _viewModel.pvetdskilltreeObj);
	}

	protected override void OnGameobjectDestoryed()
	{
		base.OnGameobjectDestoryed();
		NotifyManager.Remove(_viewModel.pvetdskilltreeObj);
	}

	private void SetSelectPanel(int old, int newval)
	{
		if (newval == 1)
		{
			_viewModel.pvetdskilltreeShow = true;
			OnOpen();
		}
		else
		{
			_viewModel.pvetdskilltreeShow = false;
		}
	}

	private void AddExpChange(int old, int newVal)
	{
		if (UiIEventCondition.Get_addExpData_maxExp() == 0)
		{
			_viewModel.expProgressImageFillamount = 0f;
		}
		else
		{
			_viewModel.expProgressImageFillamount = (float)UiIEventCondition.Get_addExpData_currentExp() / (float)UiIEventCondition.Get_addExpData_maxExp();
		}
	}

	private void SetPassiveMsg(bool old, bool newstate)
	{
		if (newstate)
		{
			SetSkillTreeInfo(UiIEventCondition.Get_pveUIMessage_SkillTreeMsgId());
			if (_viewModel.pvetdskilltreeShow)
			{
				OnOpen();
			}
		}
		_messageContext.pveUIMessage.SkillTreeChanged = false;
		Contexts.sharedInstance.player.myPlayerEntity.passiveSkillGroup.PassiveSkillDirty = false;
	}

	private void InitChips()
	{
		_skillStudioSpriteChip.Start = 1f;
		_skillStudioSpriteChip.Target = 0.9f;
		_skillStudioSpriteChip.Time = 1428f;
		_skillEffectImageXChip.Step = 6.6666665f;
	}

	protected void GameUpdate(int frameInterval)
	{
		if (!_viewModel.pvetdskilltreeShow)
		{
			return;
		}
		UpdateTouchInfo(frameInterval);
		if (_skillTreeInfoList == null)
		{
			return;
		}
		foreach (KeyValuePair<string, SkillTreeInfo> skillTreeInfo in _skillTreeInfoList)
		{
			SkillTreeInfo value = skillTreeInfo.Value;
			UpdateSkillStudioState(value);
			UpdateSkillStudioImage(value, frameInterval);
			UpdateEnterSkillImageTime(value, frameInterval);
			UpdateSkillEffect(value, frameInterval);
			UpdateMaxSkillEffect(value);
		}
		OnStudioSkill();
	}

	private void UpdateTouchInfo(int frameinterval)
	{
		for (int i = 0; i < 13; i++)
		{
			if (IsTouchOn(i + 1))
			{
				if (_touchIdx == 0 || _touchIdx == i + 1)
				{
					_enterTime += frameinterval;
				}
				_touchIdx = i + 1;
				return;
			}
		}
		_touchIdx = 0;
		_enterTime = 0;
		_viewModel.skillTipBackImageShow = false;
	}

	private bool IsTouchOn(int idx)
	{
		if (RectTransformUtility.RectangleContainsScreenPoint(_viewModel.GetskillImageObj(idx).transform as RectTransform, Input.mousePosition, null))
		{
			return true;
		}
		return false;
	}

	private void sendStudioSkillName(string name)
	{
		StudioSkillNameData studioSkillNameData = new StudioSkillNameData();
		studioSkillNameData.SkillName = name;
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(13, studioSkillNameData);
	}

	private void OnStudioSkill()
	{
		if (!Input.GetMouseButtonDown(0) || _touchIdx <= 0)
		{
			return;
		}
		_enterTime = 0;
		if (Contexts.sharedInstance.battleRoom.roomData.IsObserver)
		{
			return;
		}
		foreach (KeyValuePair<string, SkillTreeInfo> skillTreeInfo in _skillTreeInfoList)
		{
			int index = skillTreeInfo.Value.Index;
			if (index == _touchIdx)
			{
				if (skillTreeInfo.Value.CanStudioSkillType == 0)
				{
					Vector2 vector = _viewModel.GetskilleffectAnchoredposition(index);
					Vector2 vector2 = _viewModel.GetskillbackimgAnchoredposition(index);
					_viewModel.SetskilleffectAnchoredposition(index, new Vector2(vector2.x, vector.y));
				}
				sendStudioSkillName(skillTreeInfo.Value.PassiveSkill.skillName);
				break;
			}
		}
	}

	private void UpdateSkillStudioState(SkillTreeInfo skillTreeInfo)
	{
		StudioSkillConditionGroupComponent studioSkillConditionGroup = Contexts.sharedInstance.player.myPlayerEntity.studioSkillConditionGroup;
		skillTreeInfo.CanStudioSkillType = canStudioSkillType(studioSkillConditionGroup, skillTreeInfo.PassiveSkill.skillName, skillTreeInfo.PassiveSkill.skillLV);
	}

	private void UpdateSkillStudioImage(SkillTreeInfo skillTreeInfo, int frameTime)
	{
		if (skillTreeInfo.CanStudioSkillType == 0)
		{
			_viewModel.SetskillimagestudioShow(skillTreeInfo.Index, value: true);
			float num = _skillStudioSpriteChip.Update(frameTime);
			_viewModel.SetskillimagestudioScale(skillTreeInfo.Index, new Vector3(num, num, 1f));
		}
		else
		{
			_viewModel.SetskillimagestudioShow(skillTreeInfo.Index, value: false);
		}
	}

	private void UpdateEnterSkillImageTime(SkillTreeInfo skillTreeInfo, int frameTime)
	{
		if (_enterTime.HasValue && _enterTime > 500 && _touchIdx == skillTreeInfo.Index)
		{
			_viewModel.skillTipBackImageShow = true;
			UpdateSkillTipBackImage(skillTreeInfo);
			UpdateSkillTipSpriteOrg(skillTreeInfo);
			UpdateStudioSkillCondition(skillTreeInfo);
		}
	}

	private void UpdateStudioSkillCondition(SkillTreeInfo skillTreeInfo)
	{
		if ((skillTreeInfo.CanStudioSkillType & 1) == 1)
		{
			_viewModel.skillnolvImageShow = true;
		}
		else
		{
			_viewModel.skillnolvImageShow = false;
		}
		if ((skillTreeInfo.CanStudioSkillType & 4) == 4)
		{
			_viewModel.noMoneyImageShow = true;
		}
		else
		{
			_viewModel.noMoneyImageShow = false;
		}
		if ((skillTreeInfo.CanStudioSkillType & 8) == 8)
		{
			_viewModel.noFrontSkillImageShow = true;
		}
		else
		{
			_viewModel.noFrontSkillImageShow = false;
		}
	}

	private void UpdateSkillTipSpriteOrg(SkillTreeInfo skillTreeInfo)
	{
		float x = Mathf.Clamp(Input.mousePosition.x, 0f, Screen.width - 275);
		float y = Mathf.Clamp(Input.mousePosition.y, 200f, Screen.height);
		RectTransform rectTransform = _viewModel.skillTipBackImageObj.transform as RectTransform;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, new Vector2(x, y), null, out var worldPoint))
		{
			rectTransform.position = worldPoint;
		}
	}

	private void UpdateSkillTipBackImage(SkillTreeInfo skillTreeInfo)
	{
		string arg = skillTreeInfo.PassiveSkill.skillName.Replace('_', '/');
		LoadSpr($"{arg}{skillTreeInfo.PassiveSkill.skillLV}", LoadTipBgDone);
	}

	private void UpdateSkillEffect(SkillTreeInfo skillTreeInfo, int frameTime)
	{
		float x = _viewModel.GetskillImageAnchoredposition(skillTreeInfo.Index).x;
		float x2 = _viewModel.GetskilleffectAnchoredposition(skillTreeInfo.Index).x;
		float num = x + x - ((Vector2)_viewModel.GetskilleffectSize(skillTreeInfo.Index)).x;
		_skillEffectImageXChip.Start = x2;
		_skillEffectImageXChip.Target = x + 2f * num;
		float time = _skillEffectImageXChip.Time;
		_skillEffectImageActiveChip.Time = time;
		_skillBoundImageActiveChip.Time = time;
		_viewModel.SetskilleffectShow(skillTreeInfo.Index, _skillEffectImageActiveChip.Update(frameTime));
		_viewModel.SetskillBoundImageShow(skillTreeInfo.Index, _skillBoundImageActiveChip.Update(frameTime));
		x2 = _skillEffectImageXChip.Update(frameTime);
		Color value = _viewModel.GetskillBoundImageColor(skillTreeInfo.Index);
		float num2 = 0f;
		num2 = ((!(x2 >= x + num)) ? ((x2 - x) / num) : (1f - (x2 - x - num) / num));
		value.a = num2;
		_viewModel.SetskillBoundImageColor(skillTreeInfo.Index, value);
	}

	private void UpdateMaxSkillEffect(SkillTreeInfo skillTreeInfo)
	{
		if ((skillTreeInfo.CanStudioSkillType & 0x10) == 16)
		{
			_viewModel.SetskillmaxImgShow(skillTreeInfo.Index, value: true);
		}
		else
		{
			_viewModel.SetskillmaxImgShow(skillTreeInfo.Index, value: false);
		}
	}

	private void UpdateAddDamagerImage()
	{
		int firstWeaponDamageBonus = Contexts.sharedInstance.battleRoom.playerInfo.MyPlayerSkillAdditionalData.FirstWeaponDamageBonus;
		_viewModel.addDamagertextString = firstWeaponDamageBonus.ToString();
	}

	private void UpdateWeaponSkillImage()
	{
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		Dictionary<int, SkillInfoData> skillMap = Contexts.sharedInstance.battleRoom.playerInfo.GetSkillMap(myPlayerEntity.entityId.Value);
		SkillInfoData skillInfoData = null;
		foreach (KeyValuePair<int, SkillInfoData> item in skillMap)
		{
			if (item.Value.Type == 106)
			{
				skillInfoData = item.Value;
				break;
			}
		}
		if (skillInfoData != null)
		{
			switch (skillInfoData.SkillName)
			{
			case 23:
			case 96:
				base.Loader.RetriveSprite("ui/halfloadedres/pveskilltree", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/rifleskill.png", LoadWeaponSkillImgDone);
				break;
			case 24:
			case 94:
				base.Loader.RetriveSprite("ui/halfloadedres/pveskilltree", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/machineskill.png", LoadWeaponSkillImgDone);
				break;
			case 25:
			case 98:
			case 130:
				base.Loader.RetriveSprite("ui/halfloadedres/pveskilltree", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/sniperskill.png", LoadWeaponSkillImgDone);
				break;
			case 26:
			case 97:
				base.Loader.RetriveSprite("ui/halfloadedres/pveskilltree", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/shotgunskill.png", LoadWeaponSkillImgDone);
				break;
			case 53:
			case 90:
				base.Loader.RetriveSprite("ui/halfloadedres/pveskilltree", "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/ak47heroskill.png", LoadWeaponSkillImgDone);
				break;
			}
		}
	}

	private void LoadWeaponSkillImgDone(Sprite spr)
	{
		_viewModel.weaponSkillImageSprite = spr;
	}

	private void OnOpen()
	{
		if (!Contexts.sharedInstance.player.isMyPlayer)
		{
			return;
		}
		StudioSkillConditionGroupComponent studioSkillConditionGroup = Contexts.sharedInstance.player.myPlayerEntity.studioSkillConditionGroup;
		Dictionary<string, PassiveSkillComponent> allPassiveSkills = Contexts.sharedInstance.player.myPlayerEntity.passiveSkillGroup.allPassiveSkills;
		if (allPassiveSkills == null)
		{
			return;
		}
		foreach (KeyValuePair<string, PassiveSkillComponent> item in allPassiveSkills)
		{
			PassiveSkillComponent value = item.Value;
			if (_skillTreeInfoList.TryGetValue(item.Key, out var value2))
			{
				value2.CanStudioSkillType = canStudioSkillType(studioSkillConditionGroup, value2.PassiveSkill.skillName, value2.PassiveSkill.skillLV);
				value2.PassiveSkill.skillLV = value.skillLV;
				if (value.skillLV == 0)
				{
					_viewModel.SetskillbackimgShow(value2.Index, value: false);
					_viewModel.SetskillmaxImgShow(value2.Index, value: false);
					_viewModel.SetskilllvShow(value2.Index, value: false);
				}
				else
				{
					_viewModel.SetskillbackimgShow(value2.Index, value: true);
					_viewModel.SetskilllvString(value2.Index, value2.PassiveSkill.skillLV.ToString());
					_viewModel.SetskilllvShow(value2.Index, value: true);
				}
			}
		}
	}

	private int canStudioSkillType(StudioSkillConditionGroupComponent studioSkillConditionManager, string skillName, int skillLv)
	{
		int num = 0;
		string key = skillName + "/" + skillLv;
		StudioSkillConditionComponent value = null;
		if (!studioSkillConditionManager.StudioSkillConditions.TryGetValue(key, out value))
		{
			value = new StudioSkillConditionComponent();
			num |= 0x20;
		}
		PlayerEntity myPlayerEntity = Contexts.sharedInstance.player.myPlayerEntity;
		Dictionary<string, PassiveSkillComponent> allPassiveSkills = Contexts.sharedInstance.player.myPlayerEntity.passiveSkillGroup.allPassiveSkills;
		if (value.studioLv > myPlayerEntity.GetPlayerInfo().Lv)
		{
			num |= 1;
		}
		if (value.studioMoney > myPlayerEntity.GetPlayerInfo().Money)
		{
			num |= 4;
		}
		if (value.isMaxSkillLv)
		{
			num |= 0x10;
		}
		bool flag = true;
		PassiveSkillComponent value2 = null;
		if (string.IsNullOrEmpty(value.studioSkillName1) && string.IsNullOrEmpty(value.studioSkillName2))
		{
			flag = false;
		}
		else
		{
			if (!string.IsNullOrEmpty(value.studioSkillName1) && allPassiveSkills.TryGetValue(value.studioSkillName1, out value2) && value2.skillLV >= value.studioSkillLv1)
			{
				flag = false;
			}
			if (!string.IsNullOrEmpty(value.studioSkillName2) && allPassiveSkills.TryGetValue(value.studioSkillName2, out value2) && value2.skillLV >= value.studioSkillLv2)
			{
				flag = false;
			}
		}
		if (flag)
		{
			num |= 8;
		}
		return num;
	}

	private void LoadBg(string abname, string resname)
	{
		base.Loader.RetriveSprite(abname, resname, LoadDone);
	}

	private void LoadDone(Sprite spr)
	{
		_viewModel.skillBackImageSprite = spr;
	}

	private void LoadTipBgDone(Sprite spr)
	{
		_viewModel.skillTipBackImageSprite = spr;
	}

	private void InitSpecial()
	{
		if (!SpecialMode.HasValue)
		{
			int raceType = Contexts.sharedInstance.battleRoom.roomData.Data.RaceType;
			SpecialMode = raceType == 1003 || raceType == 1002 || raceType == 1004;
		}
	}

	private string GetBundleName()
	{
		InitSpecial();
		if (SpecialMode.Value)
		{
			return "ui/halfloadedres/pve2skilltree";
		}
		return "ui/halfloadedres/pveskilltree";
	}

	private string GetBaseResPath()
	{
		InitSpecial();
		if (SpecialMode.Value)
		{
			return "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pve2skilltree/";
		}
		return "Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/";
	}

	private void SetSkillTreeInfo(int specializationType)
	{
		if (_skillTreeInfoList == null || _touchImageToSkillInfoDic == null || _lastSpecializationType != specializationType)
		{
			int num = 0;
			if (_skillTreeInfoList == null)
			{
				_skillTreeInfoList = new Dictionary<string, SkillTreeInfo>();
			}
			else
			{
				_skillTreeInfoList.Clear();
			}
			if (_touchImageToSkillInfoDic == null)
			{
				_touchImageToSkillInfoDic = new Dictionary<int, SkillTreeInfo>();
			}
			else
			{
				_touchImageToSkillInfoDic.Clear();
			}
			_lastSpecializationType = specializationType;
			switch (specializationType)
			{
			case 0:
				LoadBg(GetBundleName(), GetBaseResPath() + "machineback.png");
				AddSkillTreeInfo("GENERAL_I", num++);
				AddSkillTreeInfo("GENERAL_J", num++);
				AddSkillTreeInfo("GENERAL_K", num++);
				AddSkillTreeInfo("GENERAL_L", num++);
				AddSkillTreeInfo("GENERAL_M", num++);
				AddSkillTreeInfo("MACHINE_A", num++);
				AddSkillTreeInfo("MACHINE_B", num++);
				AddSkillTreeInfo("MACHINE_C", num++);
				AddSkillTreeInfo("MACHINE_D", num++);
				AddSkillTreeInfo("MACHINE_E", num++);
				AddSkillTreeInfo("MACHINE_F", num++);
				AddSkillTreeInfo("MACHINE_G", num++);
				AddSkillTreeInfo("MACHINE_H", num++);
				break;
			case 1:
				LoadBg(GetBundleName(), GetBaseResPath() + "rifleback.png");
				AddSkillTreeInfo("GENERAL_I", num++);
				AddSkillTreeInfo("GENERAL_J", num++);
				AddSkillTreeInfo("GENERAL_K", num++);
				AddSkillTreeInfo("GENERAL_L", num++);
				AddSkillTreeInfo("GENERAL_M", num++);
				AddSkillTreeInfo("RIFLE_A", num++);
				AddSkillTreeInfo("RIFLE_B", num++);
				AddSkillTreeInfo("RIFLE_C", num++);
				AddSkillTreeInfo("RIFLE_D", num++);
				AddSkillTreeInfo("RIFLE_E", num++);
				AddSkillTreeInfo("RIFLE_F", num++);
				AddSkillTreeInfo("RIFLE_G", num++);
				AddSkillTreeInfo("RIFLE_H", num++);
				break;
			case 2:
				LoadBg(GetBundleName(), GetBaseResPath() + "sniperback.png");
				AddSkillTreeInfo("GENERAL_I", num++);
				AddSkillTreeInfo("GENERAL_J", num++);
				AddSkillTreeInfo("GENERAL_K", num++);
				AddSkillTreeInfo("GENERAL_L", num++);
				AddSkillTreeInfo("GENERAL_M", num++);
				AddSkillTreeInfo("SNIPER_A", num++);
				AddSkillTreeInfo("SNIPER_B", num++);
				AddSkillTreeInfo("SNIPER_C", num++);
				AddSkillTreeInfo("SNIPER_D", num++);
				AddSkillTreeInfo("SNIPER_E", num++);
				AddSkillTreeInfo("SNIPER_F", num++);
				AddSkillTreeInfo("SNIPER_G", num++);
				AddSkillTreeInfo("SNIPER_H", num++);
				break;
			case 3:
				LoadBg(GetBundleName(), GetBaseResPath() + "shotgunback.png");
				AddSkillTreeInfo("GENERAL_I", num++);
				AddSkillTreeInfo("SHOTGUN_J", num++);
				AddSkillTreeInfo("GENERAL_K", num++);
				AddSkillTreeInfo("GENERAL_L", num++);
				AddSkillTreeInfo("SHOTGUN_M", num++);
				AddSkillTreeInfo("SHOTGUN_A", num++);
				AddSkillTreeInfo("SHOTGUN_B", num++);
				AddSkillTreeInfo("SHOTGUN_C", num++);
				AddSkillTreeInfo("SHOTGUN_D", num++);
				AddSkillTreeInfo("SHOTGUN_E", num++);
				AddSkillTreeInfo("SHOTGUN_F", num++);
				AddSkillTreeInfo("SHOTGUN_G", num++);
				AddSkillTreeInfo("SHOTGUN_H", num++);
				break;
			}
		}
	}

	protected Sprite LoadSpr(Image img, string sprName)
	{
		InitSpecial();
		if (SpecialMode.Value)
		{
			return base.Loader.RetriveSprite("ui/halfloadedres/pve2skilltree", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pve2skilltree/{sprName}.png", img);
		}
		return base.Loader.RetriveSprite("ui/halfloadedres/pveskilltree", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/{sprName}.png", img);
	}

	protected Sprite LoadSpr(string sprName, Action<Sprite> callback)
	{
		InitSpecial();
		if (SpecialMode.Value)
		{
			return base.Loader.RetriveSprite("ui/halfloadedres/pve2skilltree", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pve2skilltree/{sprName}.png", callback);
		}
		return base.Loader.RetriveSprite("ui/halfloadedres/pveskilltree", $"Assets/Res/Assets/ui/GameGUIRes/halfLoadedRes/pveskilltree/{sprName}.png", callback);
	}

	protected void LoadForSkillImg(int index, string sprName)
	{
		Image img = _viewModel.UI.Get<Image>(_viewModel.GetskillbackimgName(index + 1));
		LoadSpr(img, sprName);
		Image img2 = _viewModel.UI.Get<Image>(_viewModel.GetskilleffectName(index + 1));
		LoadSpr(img2, sprName);
	}

	protected void SetSkillImageUrl(string skillName, int index)
	{
		switch (skillName)
		{
		case "MACHINE_A":
			LoadForSkillImg(index, "machine/a");
			break;
		case "MACHINE_B":
			LoadForSkillImg(index, "machine/b");
			break;
		case "MACHINE_C":
			LoadForSkillImg(index, "machine/c");
			break;
		case "MACHINE_D":
			LoadForSkillImg(index, "machine/d");
			break;
		case "MACHINE_E":
			LoadForSkillImg(index, "machine/e");
			break;
		case "MACHINE_F":
			LoadForSkillImg(index, "machine/f");
			break;
		case "MACHINE_G":
			LoadForSkillImg(index, "machine/g");
			break;
		case "MACHINE_H":
			LoadForSkillImg(index, "machine/h");
			break;
		case "RIFLE_A":
			LoadForSkillImg(index, "rifle/a");
			break;
		case "RIFLE_B":
			LoadForSkillImg(index, "rifle/b");
			break;
		case "RIFLE_C":
			LoadForSkillImg(index, "rifle/c");
			break;
		case "RIFLE_D":
			LoadForSkillImg(index, "rifle/d");
			break;
		case "RIFLE_E":
			LoadForSkillImg(index, "rifle/e");
			break;
		case "RIFLE_F":
			LoadForSkillImg(index, "rifle/f");
			break;
		case "RIFLE_G":
			LoadForSkillImg(index, "rifle/g");
			break;
		case "RIFLE_H":
			LoadForSkillImg(index, "rifle/h");
			break;
		case "SNIPER_A":
			LoadForSkillImg(index, "sniper/a");
			break;
		case "SNIPER_B":
			LoadForSkillImg(index, "sniper/b");
			break;
		case "SNIPER_C":
			LoadForSkillImg(index, "sniper/c");
			break;
		case "SNIPER_D":
			LoadForSkillImg(index, "sniper/d");
			break;
		case "SNIPER_E":
			LoadForSkillImg(index, "sniper/e");
			break;
		case "SNIPER_F":
			LoadForSkillImg(index, "sniper/f");
			break;
		case "SNIPER_G":
			LoadForSkillImg(index, "sniper/g");
			break;
		case "SNIPER_H":
			LoadForSkillImg(index, "sniper/h");
			break;
		case "SHOTGUN_A":
			LoadForSkillImg(index, "shotgun/a");
			break;
		case "SHOTGUN_B":
			LoadForSkillImg(index, "shotgun/b");
			break;
		case "SHOTGUN_C":
			LoadForSkillImg(index, "shotgun/c");
			break;
		case "SHOTGUN_D":
			LoadForSkillImg(index, "shotgun/d");
			break;
		case "SHOTGUN_E":
			LoadForSkillImg(index, "shotgun/e");
			break;
		case "SHOTGUN_F":
			LoadForSkillImg(index, "shotgun/f");
			break;
		case "SHOTGUN_G":
			LoadForSkillImg(index, "shotgun/g");
			break;
		case "SHOTGUN_H":
			LoadForSkillImg(index, "shotgun/h");
			break;
		case "GENERAL_I":
			LoadForSkillImg(index, "general/i");
			break;
		case "GENERAL_J":
			LoadForSkillImg(index, "general/j");
			break;
		case "GENERAL_L":
			LoadForSkillImg(index, "general/l");
			break;
		case "GENERAL_M":
			LoadForSkillImg(index, "general/m");
			break;
		case "GENERAL_K":
			LoadForSkillImg(index, "general/k");
			break;
		case "SHOTGUN_M":
			LoadForSkillImg(index, "shotgun/m");
			break;
		case "SHOTGUN_J":
			LoadForSkillImg(index, "shotgun/j");
			break;
		}
	}

	protected void AddSkillTreeInfo(string skillName, int index)
	{
		SetSkillImageUrl(skillName, index);
		SkillTreeInfo skillTreeInfo = new SkillTreeInfo(index + 1);
		skillTreeInfo.PassiveSkill = new PassiveSkillComponent();
		skillTreeInfo.PassiveSkill.skillName = skillName;
		_skillTreeInfoList[skillName] = skillTreeInfo;
	}

	public int GetCursorState()
	{
		if (!_viewModel.pvetdskilltreeShow)
		{
			return 0;
		}
		return 64;
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
