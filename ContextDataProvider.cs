using System.Collections.Generic;
using Assets.Libs.UiEditor.RunTime;
using Assets.Sources.Components.Time;
using Assets.Sources.Constant;
using SSJJMath;

public class ContextDataProvider : IContextDataProvider, IDataProvider
{
	private int _raceType;

	private int _subRaceType;

	private GameRuleContext _gameRuleContext;

	private BattleRoomContext _battleRoomContext;

	private TimeContext _timeContext;

	private PlayerContext _playerContext;

	private Dictionary<string, List<int>> _raceDics = new Dictionary<string, List<int>>();

	public void Init(Contexts contexts)
	{
		_gameRuleContext = contexts.gameRule;
		_battleRoomContext = contexts.battleRoom;
		_playerContext = contexts.player;
		_timeContext = contexts.time;
	}

	public void OnFrame(TimeComponent time)
	{
		_raceType = _battleRoomContext.roomData.Data.RaceType;
		_subRaceType = _battleRoomContext.roomData.Data.SubRaceType;
	}

	public int GetClientTime()
	{
		return _playerContext.cameraOwnerEntity.clientTime.ClientTime;
	}

	public int GetServerTime()
	{
		return _timeContext.time.ServerTime;
	}

	public float GetUiProgress(string a)
	{
		return RunTimeBindingManager.Instance.GetUiProgress(a);
	}

	public float GetUiPositionX(string a)
	{
		return RunTimeBindingManager.Instance.GetUiPositionX(a);
	}

	public float GetUiPositionY(string a)
	{
		return RunTimeBindingManager.Instance.GetUiPositionY(a);
	}

	public float GetUiPositionZ(string a)
	{
		return RunTimeBindingManager.Instance.GetUiPositionZ(a);
	}

	public int GetMpData()
	{
		return _gameRuleContext.tdSkillStateData.CurrentMp;
	}

	public int GetMaxMpData()
	{
		return _gameRuleContext.tdSkillStateData.TotalMp;
	}

	public bool IsPve()
	{
		return RuleUtilty.IsPve(_raceType);
	}

	public bool IsGeneralPve()
	{
		return RuleUtilty.IsGeneralPve(_raceType);
	}

	public bool IsOldPve()
	{
		return RuleUtilty.IsOldPve(_raceType);
	}

	public bool IsRpg()
	{
		return RuleUtilty.IsRpgNormal(_raceType);
	}

	public bool IsBio()
	{
		return RuleUtilty.IsBioMode(_raceType);
	}

	public bool IsBigHead()
	{
		return RuleUtilty.IsBigHeadModel(_raceType);
	}

	public bool IsBlade()
	{
		return RuleUtilty.IsBlade(_raceType);
	}

	public bool IsCompetitive()
	{
		return RuleUtilty.IsCompetitive(_raceType, _subRaceType);
	}

	public bool IsKnife()
	{
		return RuleUtilty.IsKnife(_raceType, _subRaceType);
	}

	public bool IsNotExplodeOrTeam()
	{
		if (!RuleUtilty.IsGroupModel(_raceType))
		{
			return !RuleUtilty.IsExplode(_raceType);
		}
		return false;
	}

	public bool IsExplode()
	{
		return RuleUtilty.IsExplode(_raceType);
	}

	public bool IsGroup()
	{
		return RuleUtilty.IsGroupModel(_raceType);
	}

	public bool IsRule(string a)
	{
		if (!_raceDics.TryGetValue(a, out var value))
		{
			string[] array = a.Split(',');
			value = new List<int>();
			for (int i = 0; i < array.Length; i++)
			{
				value.Add(int.Parse(array[i]));
			}
			_raceDics.Add(a, value);
		}
		if (value != null)
		{
			for (int j = 0; j < value.Count; j++)
			{
				if (value[j] == _raceType)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool IsRule(string[] a)
	{
		string text = _raceType.ToString();
		for (int i = 0; i < a.Length; i++)
		{
			if (a[i] == text)
			{
				return true;
			}
		}
		return false;
	}

	public bool IsNotRule(string a)
	{
		if (a == _raceType.ToString())
		{
			return false;
		}
		return true;
	}

	public bool IsNotRule(string[] a)
	{
		string text = _raceType.ToString();
		for (int i = 0; i < a.Length; i++)
		{
			if (a[i] == text)
			{
				return false;
			}
		}
		return true;
	}

	public bool GetConstTrue()
	{
		return true;
	}

	public bool GetConstNo()
	{
		return false;
	}

	public float GetConstData(float para)
	{
		return para;
	}

	public string GetConstStr(string para)
	{
		return para;
	}

	public string GetFrameImageStr(string para)
	{
		string[] array = para.Split('&');
		string text = array[0];
		int startIndex = int.Parse(text.Substring(text.Length - 1, 1));
		text = text.Substring(0, text.Length - 1);
		int indexLength = int.Parse(array[1]);
		int num = int.Parse(array[2]);
		return text + FlashMaths.GetTextureIndex(startIndex, indexLength, num, _timeContext.time.RenderTime, repeat: true);
	}
}
