using Assets.Libs.NotifyLib.Simplify;
using Assets.Sources.Framework;
using Assets.Sources.Ui.ViewModel.BioChemical_Z;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NetData;
using NotifyEvent;
using SSJJBase.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Sources.Ui.Model.BioChemical_Z;

[GameUiTest]
public class BioChemical_Z_Shop_SkllModel : AbstractModel, IKeyboardResponder, ICursorControl, IPlaybackSystem
{
	private BioChemical_Z_Shop_SkllViewModel _viewModel;

	private string[] nameColor = new string[4] { "44b4f8", "10eb52", "fb9401", "bd59f7" };

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
		_viewModel = new BioChemical_Z_Shop_SkllViewModel();
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		NotifyManager.MakeNotifyClass(131, GetSkillList, SetSkillList);
		_viewModel.ShowShow = false;
		SimpleNotify.Add(GetHide, SetHide);
		_viewModel.shop_rClicked.AddListener(delegate
		{
			SendMessage(151);
		});
		_viewModel.closeClicked.AddListener(delegate
		{
			Contexts.sharedInstance.message.bioZInit.playerSkilltShow = false;
		});
		for (int i = 0; i < 41; i++)
		{
			int id = i;
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.callback = new EventTrigger.TriggerEvent();
			entry.eventID = EventTriggerType.PointerEnter;
			entry.callback.AddListener(delegate
			{
				base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/skill/msg/{Contexts.sharedInstance.message.bioZInit.nBioZPlayerAllSkillData.SkillList[id]}.png", delegate(Sprite sprite1)
				{
					_viewModel.msgSprite = sprite1;
					_viewModel.msgShow = true;
				});
			});
			_viewModel.Getl_1_skillTriggers(id + 1).Add(entry);
			EventTrigger.Entry entry2 = new EventTrigger.Entry();
			entry2.callback = new EventTrigger.TriggerEvent();
			entry2.eventID = EventTriggerType.PointerExit;
			entry2.callback.AddListener(delegate
			{
				_viewModel.msgShow = false;
			});
			_viewModel.Getl_1_skillTriggers(id + 1).Add(entry2);
		}
	}

	public bool GetHide(int arg)
	{
		return Contexts.sharedInstance.message.bioZInit.playerSkilltShow;
	}

	public void SetHide(bool arg1, int arg2)
	{
		_viewModel.ShowShow = arg1;
		if (!arg1)
		{
			_viewModel.msgShow = arg1;
		}
	}

	private void SendMessage(int msgID)
	{
		Contexts.sharedInstance.battleServer.battleServer.Server.SendTcpMessage(msgID);
	}

	public NBioZDiffSkillData GetSkillList()
	{
		return Contexts.sharedInstance.message.bioZInit.nBioZPlayerAllSkillData;
	}

	public void SetSkillList(NBioZDiffSkillData skill1, NBioZDiffSkillData skill2)
	{
		_viewModel.ShowShow = true;
		Contexts.sharedInstance.message.bioZInit.playerSkilltShow = true;
		int count = skill2.SkillList.Count;
		for (int i = 0; i < count; i++)
		{
			int id = i + 1;
			base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/skill/skillid/{skill2.SkillList[i]}.png", delegate(Sprite sprite)
			{
				_viewModel.Setl_1_skillShow(id, value: true);
				_viewModel.Setl_1_IconSprite(id, sprite);
				NBioZSkillData nBioZSkillData = new NBioZSkillData();
				for (int k = 0; k < Contexts.sharedInstance.message.bioZInit.BioZInitData.SkillTmpList.Count; k++)
				{
					if (Contexts.sharedInstance.message.bioZInit.BioZInitData.SkillTmpList[k].Id == skill2.SkillList[id - 1])
					{
						nBioZSkillData = Contexts.sharedInstance.message.bioZInit.BioZInitData.SkillTmpList[k];
					}
				}
				base.Loader.RetriveSprite("ui/biochemical_z", $"Assets/Res/Assets/ui/GameGUIRes/biochemical_z/skill/c_{nBioZSkillData.Quailiy}.png", delegate(Sprite sprite1)
				{
					_viewModel.Setl_1_IconbgSprite(id, sprite1);
				});
				_viewModel.Setl_1_NameString(id, $"<color=#{nameColor[nBioZSkillData.Quailiy - 1]}>{nBioZSkillData.SkillName}</color>");
			});
		}
		for (int j = count; j < 41; j++)
		{
			_viewModel.Setl_1_skillShow(j + 1, value: false);
		}
	}

	private void InitChips()
	{
	}

	public bool OnKeyDown(KeyCode key)
	{
		if (_viewModel.ShowShow && key == KeyCode.L)
		{
			SendMessage(151);
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

	public void OnPlayback()
	{
		if (_viewModel.msgShow)
		{
			_viewModel.msgPosition = Input.mousePosition - _viewModel.BioChemical_Z_Shop_SkllPosition;
		}
	}
}
