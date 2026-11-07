using Assets.Generated.Table;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.Biochemical2;
using Assets.Sources.Utils.Sound;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJAsset.Asset;
using SSJJBase.Singleton;
using UnityEngine;

namespace Assets.Sources.Ui.Model.Biochemical2;

[GameUiTest]
public class Biochemical2SkillMessageModel : AbstractModel, IPlaybackSystem, ISetMessageContext
{
	private Biochemical2SkillMessageViewModel _viewModel;

	private float _alphaAdd;

	private float _effectAlpha;

	private int _enterTime;

	private MessageContext _messageContext;

	protected override IUiViewModel ViewModel => _viewModel;

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new Biochemical2SkillMessageViewModel();
	}

	public void OnPlayback()
	{
		if (!_viewModel.IsInited)
		{
			return;
		}
		UpdateChips();
		_enterTime += _timeComponent.FrameInterval;
		_viewModel.ShowShow = _enterTime < 1000;
		if (_viewModel.ShowShow)
		{
			_effectAlpha += _alphaAdd * (float)_timeComponent.FrameInterval / 500f * 0.7f;
			if (_effectAlpha >= 1f)
			{
				_alphaAdd = -1f;
			}
			else if (_effectAlpha <= 0.3f)
			{
				_alphaAdd = 1f;
			}
			Biochemical2SkillMessageViewModel viewModel = _viewModel;
			float leftAlpha = (_viewModel.RightAlpha = _effectAlpha);
			viewModel.LeftAlpha = leftAlpha;
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeTempNotifyClass(UiIEventCondition.Get_bioMessageData_Bio2SKillName, SetSkillName);
		_viewModel.ShowShow = false;
		_enterTime = 1000;
	}

	private void SetSkillName(string ov, string nv)
	{
		if (string.IsNullOrEmpty(nv))
		{
			_viewModel.ShowShow = false;
		}
		else
		{
			if (Biochemical2SkillBoardModel.NatureSkills.ContainsKey(nv))
			{
				return;
			}
			_enterTime = 0;
			_alphaAdd = 1f;
			_effectAlpha = 0.3f;
			MonoBehaviourSingleton<GameSoundManager>.Instance.Play2DSound(SoundSystemTable.SoundSubtype.System, isMyself: true, new AssetInfo("sound/bio2sound", "Assets/Res/Assets/sound/bio2sound/levelup.mp3"), 1f);
			if (_messageContext.bioMessageData.Level > 1)
			{
				base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillmessage/upgrade.png", delegate(Sprite sprite)
				{
					_viewModel.EventSprite = sprite;
				});
			}
			else
			{
				base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillmessage/getskill.png", delegate(Sprite sprite)
				{
					_viewModel.EventSprite = sprite;
				});
			}
			if (Biochemical2SkillBoardModel.HumanSkills.ContainsKey(nv))
			{
				base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillmessage/human/panel.png", delegate(Sprite sprite)
				{
					_viewModel.BackSprite = sprite;
				});
				base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillmessage/human/skill/{Biochemical2SkillBoardModel.HumanSkills[nv]}.png", delegate(Sprite sprite)
				{
					_viewModel.SkillNameSprite = sprite;
				});
			}
			else if (Biochemical2SkillBoardModel.VariantSkills.ContainsKey(nv))
			{
				base.Loader.RetriveSprite("ui/bio2model", "Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillmessage/variant/panel.png", delegate(Sprite sprite)
				{
					_viewModel.BackSprite = sprite;
				});
				base.Loader.RetriveSprite("ui/bio2model", $"Assets/Res/Assets/ui/GameGUIRes/bio2Model/skillmessage/variant/skill/acquire/{Biochemical2SkillBoardModel.VariantSkills[nv]}.png", delegate(Sprite sprite)
				{
					_viewModel.SkillNameSprite = sprite;
				});
			}
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}

	public void SetMessageContext(MessageContext context)
	{
		_messageContext = context;
	}
}
