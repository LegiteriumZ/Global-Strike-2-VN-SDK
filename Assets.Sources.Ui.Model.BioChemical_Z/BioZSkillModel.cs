using System.Collections.Generic;
using Assets.Sources.Constant;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Sources.Utils.Chip;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using SSJJBase.String;
using UnityEngine;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioZSkillModel : AbstractModel, IPlaybackSystem, ISetPlayerContext, ISetCameraContext
{
	private BioZSkillViewModel _viewModel;

	private AlphaChip _panelAlphaChip = new AlphaChip();

	protected string _assetBundle = "ui/biomodel";

	protected string _assetPath = "Assets/Res/Assets/ui/GameGUIRes/biomodel/skillicon/";

	private int[] _skillNames = new int[5];

	private int _currCd;

	private bool _isFogCreate;

	private FrameAnimaChip[] _animaChips = new FrameAnimaChip[5];

	private PlayerContext _playerContext;

	private WorldCameraContext _cameraContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		_animaChips = new FrameAnimaChip[5];
		for (int i = 1; i < _animaChips.Length; i++)
		{
			_animaChips[i] = new FrameAnimaChip
			{
				Path = _assetPath + "effect",
				Delay = 200,
				Count = 4,
				IsLoop = false
			};
			_animaChips[i].Init();
		}
		_panelAlphaChip.Alpha = 0f;
		_panelAlphaChip.Speed = 0f;
	}

	public override void CreateViewModel()
	{
		_viewModel = new BioZSkillViewModel();
	}

	public void OnPlayback()
	{
		if (_playerContext.isMyPlayer)
		{
			UpdateSkillImage(1, 106);
			UpdateSkillImage(2, 105);
			UpdateSkillImage(3, 107);
			UpdateSkillImage(4, 0);
		}
	}

	protected virtual void UpdateSkillImage(int index, int type)
	{
		Dictionary<int, SkillInfoData> skills = _playerContext.myPlayerEntity.skill.Skills;
		if (skills.ContainsKey(type) && ShowSkill())
		{
			SkillInfoData skillInfoData = skills[type];
			if (_skillNames[index] != skillInfoData.SkillName)
			{
				_skillNames[index] = skillInfoData.SkillName;
				UpdateSkillBackImage(index, skillInfoData.SkillName);
			}
			UpdateSkillTimeImage(index, skillInfoData);
			_viewModel.SetSkillShow(index, value: true);
		}
		else
		{
			_viewModel.SetSkillShow(index, value: false);
		}
	}

	protected virtual bool ShowSkill()
	{
		return true;
	}

	private void UpdateSkillTimeImage(int index, SkillInfoData skill)
	{
		if (ActiveSkillName.IsPassiveSkill(skill.SkillName))
		{
			UpdatePassiveSkillImage(index);
		}
		else if (ActiveSkillName.IsUseEnergySkill(skill.SkillName))
		{
			UpdateEnergySkillImage(index, skill);
		}
		else if (ActiveSkillName.IsUseMpSkill(skill.SkillName))
		{
			UpdateMpSkillImage(index, skill);
		}
		else
		{
			UpdateCdTimeSkillImage(index, skill);
		}
	}

	private void UpdateCdTimeSkillImage(int index, SkillInfoData skill)
	{
		if (skill.CurrentCdTime <= 0)
		{
			SetState(index, backShow: true, waitShow: false, timeShow: false, mpShow: false, 0f);
			if (_animaChips[index].Flag)
			{
				_animaChips[index].Flag = false;
				_animaChips[index].Index = 1;
				_animaChips[index].RemainTime = 0;
			}
		}
		else
		{
			if (skill.SkillName == 145 && _isFogCreate)
			{
				SetState(index, backShow: false, waitShow: true, timeShow: false, mpShow: false, 0f);
				return;
			}
			SetState(index, backShow: false, waitShow: true, timeShow: true, mpShow: false, (float)skill.CurrentCdTime / (float)skill.CdTime);
			_animaChips[index].Flag = true;
			_viewModel.SetTimeTextShow(index, value: true);
			int num = skill.CurrentCdTime / 1000;
			if (_currCd != num)
			{
				_currCd = num;
				_viewModel.SetTimeTextString(index, StringCache.IntToString(_currCd));
			}
		}
		_animaChips[index].Update(_timeComponent);
		_viewModel.SetEffectImageShow(index, !_animaChips[index].IsOver);
		int index2 = index;
		if (_animaChips[index].Changed)
		{
			base.Loader.RetriveSprite(_assetBundle, _animaChips[index].Value, delegate(Sprite sprite)
			{
				_viewModel.SetEffectImageSprite(index2, sprite);
			});
		}
	}

	private void UpdateMpSkillImage(int index, SkillInfoData skill)
	{
		if (skill.Mp < skill.NeedMp)
		{
			SetState(index, backShow: false, waitShow: true, timeShow: false, mpShow: true, 0f);
			_viewModel.SetMpTextString(index, StringCache.IntToString(skill.Mp));
		}
		else
		{
			SetState(index, backShow: true, waitShow: false, timeShow: false, mpShow: false, 0f);
			if (_animaChips[index].Flag)
			{
				_animaChips[index].Flag = false;
				_animaChips[index].Index = 1;
				_animaChips[index].RemainTime = 0;
			}
		}
		_animaChips[index].Update(_timeComponent);
		_viewModel.SetEffectImageShow(index, !_animaChips[index].IsOver);
		if (_animaChips[index].Changed)
		{
			base.Loader.RetriveSprite(_assetBundle, _animaChips[index].Value, delegate(Sprite sprite)
			{
				_viewModel.SetEffectImageSprite(index, sprite);
			});
		}
	}

	private void UpdateEnergySkillImage(int index, SkillInfoData skill)
	{
		_viewModel.SetTimeTextShow(index, value: false);
		if (skill.Mp < skill.NeedMp)
		{
			SetState(index, backShow: false, waitShow: true, timeShow: false, mpShow: false, 0f);
		}
		else
		{
			SetState(index, backShow: true, waitShow: false, timeShow: false, mpShow: false, 0f);
		}
		_viewModel.SetEffectImageShow(index, value: false);
	}

	private void UpdatePassiveSkillImage(int index)
	{
		SetState(index, backShow: true, waitShow: false, timeShow: false, mpShow: false, 0f);
		_viewModel.SetEffectImageShow(index, value: false);
	}

	private void SetState(int index, bool backShow, bool waitShow, bool timeShow, bool mpShow, float amount)
	{
		_viewModel.SetBackImageShow(index, backShow);
		_viewModel.SetWaitImageShow(index, waitShow);
		_viewModel.SetTimeTextShow(index, timeShow);
		_viewModel.SetMpTextShow(index, mpShow);
		_viewModel.SetMaskImageFillamount(index, amount);
	}

	protected virtual void UpdateSkillBackImage(int index, int skillName)
	{
		switch (skillName)
		{
		case 1:
		case 12:
			UpdateSkillImageState(index, "accelerate", "waitaccelerate");
			break;
		case 2:
		case 6:
			UpdateSkillImageState(index, "deathcall", "waitdeathcall");
			break;
		case 4:
		case 7:
			UpdateSkillImageState(index, "energyshield", "waitenergyshield");
			break;
		case 10:
		case 64:
		case 65:
			UpdateSkillImageState(index, "disarm", "waitdisarm");
			break;
		case 5:
			UpdateSkillImageState(index, "stealth", "waitstealth");
			break;
		case 8:
			UpdateSkillImageState(index, "warrant", "waitwarrant");
			break;
		case 3:
			UpdateSkillImageState(index, "damagedeep", "waitdamagedeep");
			break;
		case 11:
			UpdateSkillImageState(index, "calldoun", "waitcalldoun");
			break;
		case 40:
			UpdateSkillImageState(index, "carboxylic", "waitcarboxylic");
			break;
		case 16:
			UpdateSkillImageByModel(index, "widlfire", "waitwidlfire");
			break;
		case 17:
			UpdateSkillImageByModel(index, "virusmoisture", "waitvirusmoisture");
			break;
		case 18:
			UpdateSkillImageByModel(index, "soullink", "waitsoullink");
			break;
		case 19:
			UpdateSkillImageByModel(index, "stealthplus", "waitstealthplus");
			break;
		case 20:
			UpdateSkillImageByModel(index, "virusmissile", "waitvirusmissile");
			break;
		case 21:
			UpdateSkillImageByModel(index, "accelerateplus", "waitaccelerateplus");
			break;
		case 22:
			UpdateSkillImageByModel(index, "thump", "waitthump");
			break;
		case 41:
			UpdateSkillImageByModel(index, "carboxylicplus", "waitcarboxylicplus");
			break;
		case 50:
			UpdateSkillImageByModel(index, "thermalfield", "waitthermalfield");
			break;
		case 51:
			UpdateSkillImageByModel(index, "supejump", "waitsupejump");
			break;
		case 52:
			UpdateSkillImageByModel(index, "shockwave", "waitshockwave");
			break;
		case 54:
			UpdateSkillImageByModel(index, "addhp", "waitaddhp");
			break;
		case 80:
			UpdateSkillImageState(index, "restorseinsecticides", "waitrestorseinsecticides");
			break;
		case 81:
			UpdateSkillImageState(index, "phasetransfer", "waitphasetransfer");
			break;
		case 132:
			UpdateSkillImageState(index, "snakersprite", "waitsnakersprite");
			break;
		case 133:
			UpdateSkillImageState(index, "snakerplus", "waitsnakerplus");
			break;
		case 141:
			UpdateSkillImageState(index, "fushipentu", "waitfushipentu");
			break;
		case 145:
			UpdateSkillImageState(index, "pandoramiwu", "waitpandoramiwu");
			break;
		case 143:
			UpdateSkillImageState(index, "releasingworms", "waitreleasingworms");
			break;
		case 148:
			UpdateSkillImageState(index, "feiwen", "waitfeiwen");
			break;
		case 149:
			UpdateSkillImageState(index, "baoqi", "waitbaoqi");
			break;
		case 150:
			UpdateSkillImageState(index, "tunshi", "waittunshi");
			break;
		case 151:
			UpdateSkillImageState(index, "shenyuanzhidu", "waitshenyuanzhidu");
			break;
		case 152:
			UpdateSkillImageState(index, "shetui", "waitshetui");
			break;
		case 170:
			UpdateSkillImageState(index, "jiewan", "waitjiewan");
			break;
		case 174:
			UpdateSkillImageState(index, "changkong", "waitchangkong");
			break;
		case 175:
			UpdateSkillImageState(index, "fuchong", "waitfuchong");
			break;
		case 171:
			UpdateSkillImageState(index, "chansi", "waitchansi");
			break;
		case 172:
			UpdateSkillImageState(index, "manwangchong", "waitmanwangchong");
			break;
		case 146:
			UpdateSkillImageState(index, "dici", "waitdici");
			break;
		case 9:
			UpdateSkillImageState(index, "phantom", "waitphantom");
			break;
		case 147:
			UpdateSkillImageState(index, "yaojixuanfeng", "waityaojixuanfeng");
			break;
		case 176:
			UpdateSkillImageState(index, "maolingfushen", "waitmaolingfushen");
			break;
		case 177:
			UpdateSkillImageState(index, "maolingfeipu", "waitmaolingfeipu");
			break;
		case 178:
			UpdateSkillImageState(index, "qingniujing", "waitqingniujing");
			break;
		}
	}

	protected void UpdateSkillImageState(int index, string image, string waitImage)
	{
		_viewModel.SetBackImageSprite(index, base.Loader.RetriveSprite(_assetBundle, _assetPath + image + ".png", delegate(Sprite sprite)
		{
			_viewModel.SetBackImageSprite(index, sprite);
		}));
		_viewModel.SetWaitImageSprite(index, base.Loader.RetriveSprite(_assetBundle, _assetPath + waitImage + ".png", delegate(Sprite sprite)
		{
			_viewModel.SetWaitImageSprite(index, sprite);
		}));
		_viewModel.SetBackImageShow(index, value: false);
		_viewModel.SetWaitImageShow(index, value: true);
	}

	protected void UpdateSkillImageByModel(int index, string image, string waitImage)
	{
		_viewModel.SetBackImageSprite(index, base.Loader.RetriveSprite(_assetBundle, _assetPath + image + ".png", delegate(Sprite sprite)
		{
			_viewModel.SetBackImageSprite(index, sprite);
		}));
		_viewModel.SetWaitImageSprite(index, base.Loader.RetriveSprite(_assetBundle, _assetPath + waitImage + ".png", delegate(Sprite sprite)
		{
			_viewModel.SetWaitImageSprite(index, sprite);
		}));
		_viewModel.SetBackImageShow(index, value: false);
		_viewModel.SetWaitImageShow(index, value: true);
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
	}

	public void SetPlayerContext(PlayerContext context)
	{
		_playerContext = context;
	}

	public void SetCameraContext(WorldCameraContext context)
	{
		_cameraContext = context;
	}
}
