using Assets.Sources.Components.Player;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.Biochemical2;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.Biochemical2;

[GameUiTest]
public class Biochemical2SkillItemModel : AbstractModel, IPlaybackSystem
{
	private Biochemical2SkillItemViewModel _viewModel;

	private bool _enter;

	private int _enterTime;

	private Sprite _tipsSprite;

	private string _currSkillName;

	protected override IUiViewModel ViewModel => _viewModel;

	public GameObject Container { get; set; }

	public Biochemical2SkillBoardViewModel ParentViewModel { get; set; }

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical2SkillItemViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel.IsInited)
		{
			UpdateChips();
			if (_viewModel.Biochemical2SkillItemShow && _enter)
			{
				_enterTime += _timeComponent.FrameInterval;
				Biochemical2SkillBoardViewModel parentViewModel = ParentViewModel;
				bool tipsShow = (_viewModel.SelectBackShow = _enterTime > 500);
				parentViewModel.TipsShow = tipsShow;
			}
		}
	}

	protected override void DoSubscribe()
	{
		_viewModel.Biochemical2SkillItemObj.transform.SetParent(Container.transform);
		_viewModel.SelectBackShow = false;
		base.DoSubscribe();
		_viewModel.CreateTriggerEntry(_viewModel.BackTriggers, EventTriggerType.PointerEnter, delegate
		{
			_enter = true;
			_enterTime = 0;
			ParentViewModel.TipsSprite = _tipsSprite;
			ParentViewModel.TipsGposition = _viewModel.SelectBackGposition + new Vector3(0f, -20f);
		});
		_viewModel.CreateTriggerEntry(_viewModel.BackTriggers, EventTriggerType.PointerExit, delegate
		{
			_enter = false;
			_enterTime = 0;
			Biochemical2SkillBoardViewModel parentViewModel = ParentViewModel;
			bool tipsShow = (_viewModel.SelectBackShow = false);
			parentViewModel.TipsShow = tipsShow;
		});
	}

	public void SetInfo(PassiveSkillComponent skill)
	{
		if (skill != null)
		{
			_viewModel.Biochemical2SkillItemShow = true;
			if (_currSkillName != skill.skillName)
			{
				_currSkillName = skill.skillName;
				if (Biochemical2SkillBoardModel.HumanSkills.ContainsKey(skill.skillName))
				{
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/human/item.png", delegate(Sprite sprite)
					{
						_viewModel.BackSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/human/item2.png", delegate(Sprite sprite)
					{
						_viewModel.SelectBackSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/human/tips/{Biochemical2SkillBoardModel.HumanSkills[skill.skillName]}.png", delegate(Sprite sprite)
					{
						_tipsSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/human/skillname/{Biochemical2SkillBoardModel.HumanSkills[skill.skillName]}.png", delegate(Sprite sprite)
					{
						_viewModel.NameSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/human/bar.png", delegate(Sprite sprite)
					{
						Biochemical2SkillItemViewModel viewModel7 = _viewModel;
						Biochemical2SkillItemViewModel viewModel8 = _viewModel;
						Biochemical2SkillItemViewModel viewModel9 = _viewModel;
						Sprite sprite13 = (_viewModel.ProgressSprite4 = sprite);
						Sprite sprite15 = (viewModel9.ProgressSprite3 = sprite13);
						Sprite progressSprite3 = (viewModel8.ProgressSprite2 = sprite15);
						viewModel7.ProgressSprite1 = progressSprite3;
					});
				}
				else if (Biochemical2SkillBoardModel.NatureSkills.ContainsKey(skill.skillName))
				{
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/natureitem.png", delegate(Sprite sprite)
					{
						_viewModel.BackSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/natureitem2.png", delegate(Sprite sprite)
					{
						_viewModel.SelectBackSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/tips/nature/{Biochemical2SkillBoardModel.NatureSkills[skill.skillName]}.png", delegate(Sprite sprite)
					{
						_tipsSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/skillname/nature/{Biochemical2SkillBoardModel.NatureSkills[skill.skillName]}.png", delegate(Sprite sprite)
					{
						_viewModel.NameSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/bar.png", delegate(Sprite sprite)
					{
						Biochemical2SkillItemViewModel viewModel4 = _viewModel;
						Biochemical2SkillItemViewModel viewModel5 = _viewModel;
						Biochemical2SkillItemViewModel viewModel6 = _viewModel;
						Sprite sprite8 = (_viewModel.ProgressSprite4 = sprite);
						Sprite sprite10 = (viewModel6.ProgressSprite3 = sprite8);
						Sprite progressSprite2 = (viewModel5.ProgressSprite2 = sprite10);
						viewModel4.ProgressSprite1 = progressSprite2;
					});
				}
				else if (Biochemical2SkillBoardModel.VariantSkills.ContainsKey(skill.skillName))
				{
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/acquireitem.png", delegate(Sprite sprite)
					{
						_viewModel.BackSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/acquireitem2.png", delegate(Sprite sprite)
					{
						_viewModel.SelectBackSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/tips/acquire/{Biochemical2SkillBoardModel.VariantSkills[skill.skillName]}.png", delegate(Sprite sprite)
					{
						_tipsSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/skillname/acquire/{Biochemical2SkillBoardModel.VariantSkills[skill.skillName]}.png", delegate(Sprite sprite)
					{
						_viewModel.NameSprite = sprite;
					});
					base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillboard/variant/bar.png", delegate(Sprite sprite)
					{
						Biochemical2SkillItemViewModel viewModel = _viewModel;
						Biochemical2SkillItemViewModel viewModel2 = _viewModel;
						Biochemical2SkillItemViewModel viewModel3 = _viewModel;
						Sprite sprite3 = (_viewModel.ProgressSprite4 = sprite);
						Sprite sprite5 = (viewModel3.ProgressSprite3 = sprite3);
						Sprite progressSprite = (viewModel2.ProgressSprite2 = sprite5);
						viewModel.ProgressSprite1 = progressSprite;
					});
				}
			}
			for (int i = 0; i < 4; i++)
			{
				_viewModel.SetProgressShow(i + 1, i < skill.skillLV - 1);
			}
		}
		else
		{
			_viewModel.Biochemical2SkillItemShow = false;
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
