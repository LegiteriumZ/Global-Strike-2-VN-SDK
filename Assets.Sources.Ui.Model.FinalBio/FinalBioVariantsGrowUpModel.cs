using Assets.Sources.Constant.Career;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Finalbio;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using UnityEngine;

namespace Assets.Sources.Ui.Model.FinalBio;

public class FinalBioVariantsGrowUpModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext
{
	private const int MaxCount = 5;

	private const int GenerationEffectTime = 1000;

	private const int FragmentationEffectTime = 1000;

	private FinalbiovariantsgrowupViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private int _totalTime;

	private FinalBioMessageType _stateType;

	private int _moveTime;

	private bool _isDead;

	private bool _isDoun;

	private string _currSprite;

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new FinalbiovariantsgrowupViewModel();
	}

	public void OnPlayback()
	{
		UpdateChips();
		if (_viewModel.BottomShow)
		{
			UpdateShellImage();
			UpdateStateType();
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.BottomShow = false;
		base.DoSubscribe();
		NotifyManager.MakeNotify(5, UiIEventCondition.Get_finalBioMessageData_VariantsGrowupChanged, SetVariantsGrowupChanged, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_Lv, SetLv, null, initinvoke: true);
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_uiMyPlayer_Career, SetCareer, null, initinvoke: true);
		NotifyManager.MakeTempNotify(UiIEventCondition.Get_uiMyPlayer_IsDead, SetIsDead, null, initinvoke: true);
	}

	private void SetIsDead(bool ov, bool value)
	{
		_isDead = value;
		CheckVisible();
	}

	private void SetCareer(string ov, string career)
	{
		_isDoun = PlayerCareerConstantUtility.IsDoun(career);
		CheckVisible();
	}

	private void CheckVisible()
	{
		_viewModel.BottomShow = _isDoun && !_isDead;
	}

	private void SetVariantsGrowupChanged(bool ov, bool changed)
	{
		if (changed)
		{
			_stateType = UiIEventCondition.Get_finalBioMessageData_VariantsGrowupType();
			_totalTime = UiIEventCondition.Get_finalBioMessageData_VariantsGrowupTime();
			_moveTime = 0;
		}
	}

	private void UpdateStateType()
	{
		_moveTime += _timeComponent.FrameInterval;
		if (_moveTime >= _totalTime)
		{
			if (_stateType == FinalBioMessageType.GENERATION)
			{
				_stateType = FinalBioMessageType.GENERATIONOVER;
				_totalTime = 1000;
				_moveTime = 0;
			}
			else if (_stateType == FinalBioMessageType.GENERATIONOVER)
			{
				_moveTime = 0;
			}
			else if (_stateType == FinalBioMessageType.FRAGMENTATION)
			{
				_stateType = FinalBioMessageType.GENERATIONOVER;
				_totalTime = 1000;
				_moveTime = 0;
			}
			else if (_stateType == FinalBioMessageType.FRAGMENTATIONOVER)
			{
				_stateType = FinalBioMessageType.INTERRUPT;
			}
			else if (_stateType == FinalBioMessageType.INTERRUPT)
			{
				_totalTime = int.MaxValue;
				_moveTime = 0;
			}
		}
	}

	private void UpdateShellImage()
	{
		if ((long)_battleRoomContext.sectionTime.SectionTime <= (long)FinalBioDecisiveBattleModel.UltimateTime)
		{
			_viewModel.GenerationImageShow = false;
			_viewModel.ProgressImageShow = false;
			_viewModel.FragmentImageShow = false;
			_viewModel.TextImageShow = false;
			return;
		}
		switch (_stateType)
		{
		case FinalBioMessageType.GENERATION:
			_viewModel.GenerationImageShow = false;
			_viewModel.FragmentImageShow = false;
			_viewModel.ProgressImageShow = true;
			_viewModel.TextImageShow = true;
			if (_currSprite != "generationrun")
			{
				_currSprite = "generationrun";
				_viewModel.TextImageSprite = base.Loader.RetriveSprite("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbioModel/variantsgrowup/generationrun.png", delegate(Sprite sprite)
				{
					_viewModel.TextImageSprite = sprite;
					_viewModel.TextImageNtvsize();
				});
			}
			UpdateProgressImage(reverse: false);
			break;
		case FinalBioMessageType.GENERATIONOVER:
			_viewModel.GenerationImageShow = true;
			_viewModel.ProgressImageShow = true;
			_viewModel.FragmentImageShow = false;
			_viewModel.TextImageShow = true;
			if (_currSprite != "generationover")
			{
				_currSprite = "generationover";
				_viewModel.TextImageSprite = base.Loader.RetriveSprite("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbioModel/variantsgrowup/generationover.png", delegate(Sprite sprite)
				{
					_viewModel.TextImageSprite = sprite;
					_viewModel.TextImageNtvsize();
				});
			}
			UpdateGenerationImage();
			break;
		case FinalBioMessageType.FRAGMENTATION:
			_viewModel.GenerationImageShow = true;
			_viewModel.ProgressImageShow = true;
			_viewModel.FragmentImageShow = false;
			_viewModel.TextImageShow = true;
			if (_currSprite != "fragmentation")
			{
				_currSprite = "fragmentation";
				_viewModel.TextImageSprite = base.Loader.RetriveSprite("ui/finalbiomodel", "Assets/Res/Assets/ui/GameGUIRes/finalbioModel/variantsgrowup/fragmentation.png", delegate(Sprite sprite)
				{
					_viewModel.TextImageSprite = sprite;
					_viewModel.TextImageNtvsize();
				});
			}
			UpdateProgressImage(reverse: true);
			UpdateGenerationImage();
			break;
		case FinalBioMessageType.FRAGMENTATIONOVER:
			_viewModel.GenerationImageShow = false;
			_viewModel.ProgressImageShow = false;
			_viewModel.FragmentImageShow = true;
			_viewModel.TextImageShow = false;
			UpdateFragmentationImage();
			break;
		case FinalBioMessageType.INTERRUPT:
			_viewModel.GenerationImageShow = false;
			_viewModel.ProgressImageShow = false;
			_viewModel.FragmentImageShow = false;
			_viewModel.TextImageShow = false;
			break;
		}
	}

	private void UpdateFragmentationImage()
	{
		if (_totalTime != 0)
		{
			float num = (float)_moveTime / (float)_totalTime;
			_viewModel.FragmentImageScale = Vector3.one + new Vector3(num, num);
			if (_moveTime >= 750)
			{
				float num2 = (float)(1000 - _moveTime) / 250f;
				_viewModel.FragmentImageAlpha = 1f - num2;
			}
			else
			{
				_viewModel.FragmentImageAlpha = 1f;
			}
		}
	}

	private void UpdateGenerationImage()
	{
		if (_totalTime != 0)
		{
			float num = ((!((double)_moveTime >= (double)_totalTime * 0.5)) ? ((float)_moveTime / ((float)_totalTime * 0.5f)) : (((float)_moveTime - (float)_totalTime * 0.5f) / ((float)_totalTime * 0.5f)));
			_viewModel.GenerationImageScale = new Vector3(1f + num, 1f + num, 1f);
		}
	}

	private void UpdateProgressImage(bool reverse)
	{
		if (_totalTime != 0)
		{
			if (reverse)
			{
				_viewModel.ProgressImageFillamount = (float)(_totalTime - _moveTime) / (float)_totalTime * 0.85f;
			}
			else
			{
				_viewModel.ProgressImageFillamount = (float)_moveTime / (float)_totalTime * 0.85f;
			}
		}
	}

	private void SetLv(int ov, int level)
	{
		for (int i = 0; i < 5; i++)
		{
			if (i < level)
			{
				_viewModel.SetSlotImageShow(i + 1, value: true);
			}
			else
			{
				_viewModel.SetSlotImageShow(i + 1, value: false);
			}
		}
		_viewModel.HeroTextString = "Lv" + level;
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
