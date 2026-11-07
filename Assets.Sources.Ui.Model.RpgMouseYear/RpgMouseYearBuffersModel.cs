using System.Collections.Generic;
using Assets.Sources.Framework;
using Assets.Sources.Modules.Ui.UiEventCondition;
using Assets.Sources.Ui.ViewModel.RpgMouseYear;
using Assets.Tests.PlayMode;
using Assets.UiFramework.Libs;
using NotifyEvent;
using SSJJBase.String;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sources.Ui.Model.RpgMouseYear;

[GameUiTest]
public class RpgMouseYearBuffersModel : AbstractModel, IPlaybackSystem, ISetBattleRoomContext, ISetGameRuleContext
{
	public class BufferUnit
	{
		public GameObject Parent;

		public Image Icon;

		public Text Count;
	}

	private RpgMouseYearBuffersViewModel _viewModel;

	private BattleRoomContext _battleRoomContext;

	private GameRuleContext _gameRuleContext;

	private int _diffX = 50;

	private int _diffY = -50;

	private const int BufferMaxCount = 12;

	private List<BufferUnit> _bufferUnits = new List<BufferUnit>();

	private Dictionary<int, string> _bufferIcons = new Dictionary<int, string>();

	protected override IUiViewModel ViewModel => _viewModel;

	public void SetBattleRoomContext(BattleRoomContext context)
	{
		_battleRoomContext = context;
	}

	public void SetGameRuleContext(GameRuleContext context)
	{
		_gameRuleContext = context;
	}

	public override void Initialize()
	{
		CreateViewModel();
		base.Initialize();
		InitChips();
	}

	public override void CreateViewModel()
	{
		_viewModel = new RpgMouseYearBuffersViewModel();
	}

	public void OnPlayback()
	{
		if (_viewModel != null && _viewModel.IsInited)
		{
			UpdateChips();
		}
	}

	protected override void DoSubscribe()
	{
		base.DoSubscribe();
		InitBuffers();
		NotifyManager.MakeNotify(76, UiIEventCondition.Get_menu_VisibleChanged, SetBuffers);
	}

	private void InitBuffers()
	{
		for (int i = 0; i < 12; i++)
		{
			GameObject gameObject = Object.Instantiate(_viewModel.BuffersBackgroundObj);
			gameObject.transform.SetParent(_viewModel.BuffersBackgroundObj.transform.parent);
			gameObject.transform.localPosition = _viewModel.BuffersBackgroundObj.transform.localPosition + new Vector3(i % 2 * _diffX, i / 2 * _diffY, 0f);
			BufferUnit bufferUnit = new BufferUnit
			{
				Count = gameObject.transform.Find("Num").GetComponent<Text>(),
				Icon = gameObject.transform.Find("Icon").GetComponent<Image>(),
				Parent = gameObject
			};
			bufferUnit.Parent.SetObjectActive(isactive: false);
			_bufferUnits.Add(bufferUnit);
		}
		_viewModel.BuffersBackgroundShow = false;
		_bufferIcons.Add(1, "HP_BUFF");
		_bufferIcons.Add(2, "SA_BUFF");
		_bufferIcons.Add(3, "CRIT_BUFF");
		_bufferIcons.Add(4, "CRIT_VALUE_BUFF");
		_bufferIcons.Add(5, "HP_RECOVER_BUFF");
		_bufferIcons.Add(6, "SA_RECOVER_BUFF");
		_bufferIcons.Add(7, "ENEGY_RECOVER_BUFF");
		_bufferIcons.Add(8, "ALL_BLOCK_BUFF");
		_bufferIcons.Add(9, "BLOCK_RATE_BUFF");
		_bufferIcons.Add(10, "CD_REDUCE_BUFF");
		_bufferIcons.Add(11, "HALO_BUFF");
		_bufferIcons.Add(12, "DAMAGE_ADD_BUFF");
	}

	private void SetBuffers(bool arg1, bool arg2)
	{
		Dictionary<int, int> buffer = _gameRuleContext.mouseYear.Buffer;
		if (buffer == null)
		{
			return;
		}
		int num = 0;
		for (int i = 1; i <= 12; i++)
		{
			if (buffer.ContainsKey(i))
			{
				int value = buffer[i];
				_bufferUnits[num].Parent.SetObjectActive(isactive: true);
				int count = num;
				base.Loader.RetriveSprite("ui/rpgmouseyearmodel", $"Assets/Res/Assets/ui/GameGUIRes/rpgMouseYearModel/Talent/{_bufferIcons[i]}.png", delegate(Sprite sprite)
				{
					_bufferUnits[count].Icon.sprite = sprite;
				});
				_bufferUnits[num].Count.text = StringCache.IntToString(value);
				num++;
			}
		}
		for (int j = num; j < _bufferUnits.Count; j++)
		{
			_bufferUnits[j].Parent.SetObjectActive(isactive: false);
		}
	}

	private void InitChips()
	{
	}

	private void UpdateChips()
	{
	}
}
